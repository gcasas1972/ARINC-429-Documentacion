VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI1553 Example 15"
   ClientHeight    =   7695
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   6015
   LinkTopic       =   "Form1"
   ScaleHeight     =   7695
   ScaleWidth      =   6015
   StartUpPosition =   3  'Windows Default
   Begin VB.ListBox List1 
      Height          =   4155
      Left            =   120
      TabIndex        =   3
      Top             =   2880
      Width           =   5775
   End
   Begin VB.CommandButton cmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   2
      Top             =   7200
      Width           =   735
   End
   Begin VB.CommandButton cmdStop 
      Caption         =   "Stop"
      Enabled         =   0   'False
      Height          =   375
      Left            =   960
      TabIndex        =   1
      Top             =   7200
      Width           =   735
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   5160
      TabIndex        =   0
      Top             =   7200
      Width           =   735
   End
   Begin VB.Timer Timer1 
      Interval        =   100
      Left            =   1920
      Top             =   7155
   End
   Begin VB.Line Line2 
      X1              =   780
      X2              =   5220
      Y1              =   1980
      Y2              =   1980
   End
   Begin VB.Label Channel 
      Caption         =   "Channel:"
      Height          =   255
      Left            =   1620
      TabIndex        =   13
      Top             =   2280
      Width           =   2895
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP15     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   780
      TabIndex        =   12
      Top             =   705
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   780
      TabIndex        =   11
      Top             =   1185
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   780
      TabIndex        =   10
      Top             =   1425
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   780
      TabIndex        =   9
      Top             =   1665
      Width           =   4335
   End
   Begin VB.Line Line1 
      X1              =   780
      X2              =   5220
      Y1              =   600
      Y2              =   600
   End
   Begin VB.Label Core 
      Caption         =   "Core:"
      Height          =   255
      Left            =   1620
      TabIndex        =   8
      Top             =   2025
      Width           =   2895
   End
   Begin VB.Label Label1 
      Caption         =   "Copyright 2003-2011"
      Height          =   255
      Left            =   780
      TabIndex        =   7
      Top             =   945
      Width           =   4335
   End
   Begin VB.Label Header1 
      Alignment       =   2  'Center
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
      Left            =   660
      TabIndex        =   6
      Top             =   0
      Width           =   4695
   End
   Begin VB.Label Header1a 
      Alignment       =   2  'Center
      Caption         =   "Monitoring The Bus"
      Height          =   255
      Left            =   660
      TabIndex        =   5
      Top             =   240
      Width           =   4695
   End
   Begin VB.Label Result1 
      Caption         =   "Result1"
      Height          =   255
      Left            =   780
      TabIndex        =   4
      Top             =   2520
      Width           =   4215
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI1553 DRIVER VB_EXAMPLE 15  (06/07/2011)
'  Copyright (c) 2003-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP15 -- IRIG Timer Example (Monitoring the bus)
'
'  This example configures Card Number 0 as a Bus Monitor
'  terminal.  It prints the time-tag (in IRIG format),
'  command words (if any), and status words (if any) for each
'  monitor record.
'

Option Explicit

' Constants
Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16

' Card specific
Dim hCard As Long
Dim hCore As Long
Dim corenum As Long
Dim channum As Long
Dim bSkipRun As Boolean
Dim bCardRunning As Boolean
Dim errval As Long
Dim errstr As String

' Program specific
Dim pRec1553 As SEQRECORD1553
Dim pRecMore As SEQRECORDMORE1553
Dim seqbuf(2047) As Integer
Dim seqcount As Long
Dim sfinfo As SEQFINDINFO
Dim moncount As Integer
Dim rightnow As Date
Dim irigtime As BTIIRIGTIME

Private Sub CmdExit_Click()
    If (hCore >= 0) Then
        errval = BTICard_CardClose(hCore)
    End If
      
    ' End Program
    End
    
End Sub

Private Sub CmdStart_Click()
    ' Clear the list control contents and counter
    List1.Clear
    moncount = 0

    If bSkipRun Then
        Exit Sub
    End If
    
    ' Configure the channel for monitor mode.
    BTICard_CardReset (hCore)
    
    errval = BTI1553_MonConfig(MONCFG1553_DEFAULT, channum, hCore)
    If (errval < 0) Then
        MsgBox "Error:  An error was encountered while while configuring for monitor mode"
        bSkipRun = True
        Exit Sub
    End If
    
    ' Configure the sequential record
    errval = BTICard_SeqConfig(SEQCFG_DEFAULT, hCore)
    If (errval < 0) Then
        MsgBox "Error:  An error was encountered while configuring sequential record"
        bSkipRun = True
        Exit Sub
    End If
    
    ' Configure the IRIG timer. (DEFAULT -> bit rate = IRIGB, internal, slave/reciever)
    ' Sequential monitor will store IRIG time in sequetial records
    errval = BTICard_IRIGConfig(IRIGCFG_DEFAULT, hCore)
    If (errval < 0) Then
        errstr = "Error:  An error was encountered while configuring " & vbNewLine
        errstr = errstr & "the IRIG timer on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If

    ' Synchronize the on core IRIG timer with the computer local time
    rightnow = Now              ' Now returns the current date/time.
    irigtime.days = DateDiff("d", DateSerial(Year(rightnow), 1, 1), rightnow) + 1
    irigtime.hours = Hour(rightnow)
    irigtime.min = Minute(rightnow)
    irigtime.sec = Second(rightnow)
    irigtime.msec = 0          ' The Date structure does not include milliseconds.
    irigtime.usec = 0          ' The Date structure does not include microseconds.

    errval = BTICard_IRIGWr(irigtime, hCore)
    If (errval < 0) Then
        errstr = "Error:  An error was encountered while writting" & vbNewLine
        errstr = errstr & "the IRIG time on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Start operation of the card.
    errval = BTICard_CardStart(hCore)
    If (errval < 0) Then
        MsgBox "Error:  An error was encountered while starting the card"
        bSkipRun = True
        Exit Sub
    End If
    
    bCardRunning = True
    cmdStart.Enabled = False
    cmdStop.Enabled = True
    Result1.Caption = "Card Running"
    
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
    Result1.Caption = "Card Stopped"
    List1.Clear
    
    ' Open handle to card with specified card number
    errval = BTICard_CardOpen(hCard, cardnum)
    If (errval) Then
        errstr = "Error: Unable to open card number " & cardnum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Find the first 1553 core and channel
    For corenum = 0 To MAX_CORES - 1
        errval = BTICard_CoreOpen(hCore, corenum, hCard)
        If errval = 0 Then
            For channum = 0 To MAX_CHANNELS - 1
                If BTI1553_ChIs1553(channum, hCore) Then
                   Exit For
                End If
            Next
            If channum < MAX_CHANNELS Then
                Exit For
            End If
        End If
    Next
    
    If (errval <> 0) Or (corenum >= MAX_CORES) Or (channum >= MAX_CHANNELS) Then
        MsgBox "Error:  No compatible MIL-STD-1553 core present in card #" & cardnum
        bSkipRun = True
        Exit Sub
    End If
    
    Core.Caption = "Using core #" & corenum
    channel.Caption = "Using 1553 channel #" & channum
    
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
    seqcount = BTICard_SeqRd(seqbuf(0), hCore)
    If (0 = seqcount) Then
        Exit Sub
    End If
    
    errval = BTICard_SeqFindInit(seqbuf(0), seqcount, sfinfo)
    If (0 > errval) Then
        MsgBox "Error: SeqFindInit failed"
        bSkipRun = True
        Exit Sub
    End If
    
    ' Add each 1553Record in SeqBuf to List1
    While (0 <= BTICard_SeqFindNext1553Ex(pRec1553, LenB(pRec1553), sfinfo))
        Dim str As String
        Dim timestr As String
        Dim recChanNum As Long
        
        'Inc the record number
        moncount = moncount + 1
        
        'Get extended data for this record
        Call BTICard_SeqFindMore1553Ex(pRecMore, LenB(pRecMore), pRec1553)
        
        'Calc the Chan number
        recChanNum = pRec1553.activity And MSGACT1553_CHMASK
        recChanNum = ShiftRight(recChanNum, MSGACT1553_CHSHIFT)
        
        ' Format the output string
        timestr = " Time:"
        timestr = timestr & " " & BTICard_IRIGFieldGetHours(pRecMore.timestamph, pRec1553.timestamp)
        timestr = timestr & ":" & BTICard_IRIGFieldGetMin(pRecMore.timestamph, pRec1553.timestamp)
        timestr = timestr & " " & BTICard_IRIGFieldGetSec(pRecMore.timestamph, pRec1553.timestamp)
        timestr = timestr & "." & BTICard_IRIGFieldGetMillisec(pRecMore.timestamph, pRec1553.timestamp)
        timestr = timestr & "." & BTICard_IRIGFieldGetMicrosec(pRecMore.timestamph, pRec1553.timestamp)
        
        str = "Rec:" & CStr(moncount)
        str = str & "  Ch:" & CStr(recChanNum)
        str = str & timestr
        
        If (pRec1553.activity And MSGACT1553_RCVCWD1) Then
            str = str & "      Cwd1:" & Hex(pRec1553.cwd1)
        End If
        If (pRec1553.activity And MSGACT1553_RCVCWD2) Then
            str = str & "  Cwd2:" & Hex(pRec1553.cwd2)
        End If
        If (pRec1553.activity And MSGACT1553_RCVSWD1) Then
            str = str & "  Swd1:" & Hex(pRec1553.swd1)
        End If
        If (pRec1553.activity And MSGACT1553_RCVSWD2) Then
            str = str & "  Swd2:" & Hex(pRec1553.swd2)
        End If
        If (pRec1553.errorval And MSGERR1553_NORESP) Then
            str = str & "  No response!"
        End If
        If (pRec1553.errorval And MSGERR1553_ANYERR) Then
            str = str & "  Error!"
        End If
        
        ' Output the result
        List1.AddItem str
        
    Wend
    
End Sub




