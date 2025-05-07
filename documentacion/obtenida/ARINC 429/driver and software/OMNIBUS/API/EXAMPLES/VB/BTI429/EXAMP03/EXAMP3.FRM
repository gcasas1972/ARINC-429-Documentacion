VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI429 Example 3"
   ClientHeight    =   6435
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4695
   LinkTopic       =   "Form1"
   ScaleHeight     =   6435
   ScaleWidth      =   4695
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   113
      TabIndex        =   3
      Top             =   5955
      Width           =   735
   End
   Begin VB.CommandButton cmdStop 
      Caption         =   "Stop"
      Enabled         =   0   'False
      Height          =   375
      Left            =   953
      TabIndex        =   2
      Top             =   5955
      Width           =   735
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   3833
      TabIndex        =   1
      Top             =   5955
      Width           =   735
   End
   Begin VB.Timer Timer1 
      Interval        =   500
      Left            =   1913
      Top             =   5955
   End
   Begin VB.ListBox List1 
      Height          =   3180
      Left            =   113
      TabIndex        =   0
      Top             =   2715
      Width           =   4455
   End
   Begin VB.Label Header1 
      Caption         =   "Monitor Example"
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
      Left            =   1440
      TabIndex        =   12
      Top             =   120
      Width           =   1815
   End
   Begin VB.Label Label1 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Left            =   120
      TabIndex        =   11
      Top             =   840
      Width           =   4335
   End
   Begin VB.Label Core 
      Caption         =   "Core:"
      Height          =   255
      Left            =   960
      TabIndex        =   10
      Top             =   1920
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
      TabIndex        =   9
      Top             =   1560
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   8
      Top             =   1320
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   7
      Top             =   1080
      Width           =   4335
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP3     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   6
      Top             =   600
      Width           =   4335
   End
   Begin VB.Label Receive 
      Caption         =   "Receive:"
      Height          =   255
      Left            =   960
      TabIndex        =   5
      Top             =   2190
      Width           =   2895
   End
   Begin VB.Label Transmit 
      Caption         =   "Transmit:"
      Height          =   255
      Left            =   960
      TabIndex        =   4
      Top             =   2475
      Width           =   2895
   End
   Begin VB.Line Line2 
      X1              =   120
      X2              =   4560
      Y1              =   1875
      Y2              =   1875
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI429 DRIVER VB_EXAMPLE 3  (06/07/2011)
'  Copyright (c) 2002-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP3 -- Monitor example
'
'  This program opens Card Number 0, finds the first
'  compatible core, builds a transmit schedule using
'  transmit interval information, and creates filters
'  for two receive messages.  It also enables the
'  sequential monitor to record transmitted and
'  received messages.
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
Dim msgdefault As MSGSTRUCT429
Dim latitude As MSGSTRUCT429
Dim longitude As MSGSTRUCT429
Dim comp_airspeed As MSGSTRUCT429
Dim tot_air_temp As MSGSTRUCT429
Dim altitude_rate As MSGSTRUCT429
Dim msgaddr(2) As Long
Dim min_intrvls(2) As Long
Dim max_intrvls(2) As Long
Dim seqbuf(2047) As Integer
Dim seqcount As Long
Dim blkcnt As Long
Dim pRec429 As SEQRECORD429
Dim sfinfo As SEQFINDINFO

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
    ' Configure xmtchan to transmit at low speed.
    
    ' Record all of xmtchan data in sequential record
    BTICard_CardReset (hCore)
    
    'Configure channel
    ERRVAL = BTI429_ChConfig(CHCFG429_AUTOSPEED, rcvchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    'Configure channel
    ERRVAL = BTI429_ChConfig(CHCFG429_SEQALL, xmtchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring " & vbNewLine
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
    ' in each array correspond to each other.
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
        MsgBox "Error:  BTI429_SchedBuild failed on core #" & corenum & "."
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
    
    ' Before any messages can be received, filters must be set
    ' for the receive channel.  First, the default filter is
    ' created.  Then, two filters are set for the two messages
    ' of interest.
    
    ' Record the two filtered messages.
    msgdefault.addr = BTI429_FilterDefault(MSGCRT429_DEFAULT, rcvchan, hCore)
    latitude.addr = BTI429_FilterSet(MSGCRT429_SEQ, &O310, SDIALL, rcvchan, hCore)
    longitude.addr = BTI429_FilterSet(MSGCRT429_SEQ, &O311, SDIALL, rcvchan, hCore)
    
    ' Configure the sequential record for fill and halt mode (default).
    ERRVAL = BTICard_SeqConfig(SEQCFG_DEFAULT, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "the sequential record on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
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
    List1.Clear
    
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
    List1.Clear
    
    Exit Sub
Errhandler:
        MsgBox "An Error Has Occured:  " & Err.Description

End Sub

Private Sub Timer1_Timer()

    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If
    
    ' Display data on the screen.
    seqcount = BTICard_SeqBlkRd(seqbuf(0), 2047, blkcnt, hCore)
    If (0 = seqcount) Then
        Exit Sub
    End If
    
    ERRVAL = BTICard_SeqFindInit(seqbuf(0), seqcount, sfinfo)
    If (0 > ERRVAL) Then
        MsgBox "Error: SeqFindInit failed"
        bSkipRun = True
        Exit Sub
    End If
    
    ' Add each 429Record in SeqBuf to List1
    While (0 <= BTICard_SeqFindNext429Ex(pRec429, LenB(pRec429), sfinfo))
        List1.AddItem "Data: " & Hex(pRec429.Data) & " (Hex)     TimeTag: " & Hex(pRec429.timestamp) & " (Hex)"
    Wend
    
End Sub

