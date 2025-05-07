VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI717 Example 8"
   ClientHeight    =   7470
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   5775
   LinkTopic       =   "Form1"
   ScaleHeight     =   7470
   ScaleWidth      =   5775
   StartUpPosition =   3  'Windows Default
   Begin VB.ListBox List2 
      Height          =   3180
      Left            =   120
      TabIndex        =   4
      Top             =   3600
      Width           =   5535
   End
   Begin VB.ListBox List1 
      Height          =   840
      Left            =   4080
      TabIndex        =   3
      Top             =   2640
      Width           =   975
   End
   Begin VB.Timer Timer1 
      Interval        =   100
      Left            =   2760
      Top             =   6960
   End
   Begin VB.CommandButton CmdStop 
      Caption         =   "Stop"
      Height          =   375
      Left            =   960
      TabIndex        =   2
      Top             =   6960
      Width           =   735
   End
   Begin VB.CommandButton CmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   1
      Top             =   6960
      Width           =   735
   End
   Begin VB.CommandButton CmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   4920
      TabIndex        =   0
      Top             =   6960
      Width           =   735
   End
   Begin VB.Label Label1 
      Caption         =   "Words Per Second"
      Height          =   255
      Index           =   1
      Left            =   3840
      TabIndex        =   14
      Top             =   2400
      Width           =   1575
   End
   Begin VB.Label Result1 
      Caption         =   "Result1"
      Height          =   375
      Left            =   600
      TabIndex        =   13
      Top             =   2880
      Width           =   3255
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
      Left            =   600
      TabIndex        =   12
      Top             =   0
      Width           =   4575
   End
   Begin VB.Line Line2 
      X1              =   690
      X2              =   5130
      Y1              =   1740
      Y2              =   1740
   End
   Begin VB.Label Channel 
      Caption         =   "Channel:"
      Height          =   255
      Left            =   1530
      TabIndex        =   11
      Top             =   2040
      Width           =   2895
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP8     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   720
      TabIndex        =   10
      Top             =   480
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   690
      TabIndex        =   9
      Top             =   945
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   690
      TabIndex        =   8
      Top             =   1185
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   660
      TabIndex        =   7
      Top             =   1425
      Width           =   4335
   End
   Begin VB.Line Line1 
      X1              =   690
      X2              =   5130
      Y1              =   360
      Y2              =   360
   End
   Begin VB.Label Core 
      Caption         =   "Core:"
      Height          =   255
      Left            =   1530
      TabIndex        =   6
      Top             =   1785
      Width           =   2895
   End
   Begin VB.Label Label1 
      Caption         =   "Copyright 2003-2011"
      Height          =   255
      Index           =   0
      Left            =   690
      TabIndex        =   5
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
'  BTI717 DRIVER VB_EXAMPLE 8  (06/07/2011)
'  Copyright (c) 2003-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP8 -- IRIG Timer Example
'
'  This program opens Card Number 0, and configures the
'  first BiPhase channel as a receiver.  The second
'  BiPhase channel is configured as a transmitter.  Both
'  channels operate on the self-test bus to electrically connect
'  them. The transmit channel is loaded with incrementing data,
'  and various words are configured for entry into the
'  Sequential Monitor.  The program will read out of the
'  Sequential Record and display the data to the screen using
'  the IRIG timer.
'

' Force explicit declaration of all variables
Option Explicit

' Constants
Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16

' Card specific
Dim hCard As Long
Dim hCore As Long
Dim corenum As Long
Dim ERRVAL As Long
Dim rcvchan As Long
Dim xmtchan As Long
Dim bSkipRun As Boolean
Dim bCardRunning As Boolean

' Program specific
Dim rightnow As Date
Dim wps As Integer
Dim superfrmaddr As Long
Dim sfblock(8199) As Integer
Dim irigtime As BTIIRIGTIME
Dim errstr As String
Dim j, jj As Integer

Private Sub CmdExit_Click()
    If (hCard >= 0) Then
        ERRVAL = BTICard_CardClose(hCard)
    End If
      
    ' End Program
    End
    
End Sub

Private Sub CmdStart_Click()
    If bSkipRun Then
        Exit Sub
    End If
    
    List2.Clear
        
    '  Configure receiver channel for auto speed detection.
    '  Use the internal wrap around.
    BTICard_CardReset (hCore)
    ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASERCV Or CHCFG717_AUTOSPEED Or CHCFG717_SELFTEST, rcvchan, hCore)
    If (ERRVAL < 0) Then
        MsgBox "Error:  An error was encountered while configuring channel" & rcvchan
        bSkipRun = True
        Exit Sub
    End If
    
    '  Configure transmitter channel at specified words per second.
    '  Use the internal wrap around.
    If List1.Text = "64" Then
        wps = 64
        ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_64WPS, xmtchan, hCore)
    ElseIf List1.Text = "128" Then
        wps = 128
        ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_128WPS, xmtchan, hCore)
    ElseIf List1.Text = "256" Then
        wps = 256
        ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_256WPS, xmtchan, hCore)
    ElseIf List1.Text = "512" Then
        wps = 512
        ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_512WPS, xmtchan, hCore)
    ElseIf List1.Text = "1024" Then
        wps = 1024
        ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_1024WPS, xmtchan, hCore)
    ElseIf List1.Text = "2048" Then
        wps = 2048
        ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_2048WPS, xmtchan, hCore)
    ElseIf List1.Text = "4096" Then
        wps = 4096
        ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_4096WPS, xmtchan, hCore)
    ElseIf List1.Text = "8192" Then
        wps = 8192
        ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_SELFTEST Or CHCFG717_8192WPS, xmtchan, hCore)
    Else
        MsgBox "Error:  An error was encountered while reading words per second"
        bSkipRun = True
        Exit Sub
    End If
    If (ERRVAL < 0) Then
        MsgBox "Error:  An error was encountered while configruing channel " & xmtchan
        bSkipRun = True
        Exit Sub
    End If
    
    '  Init subframe data.
    For j = 1 To 4
        Call BTI717_SubFrmBlkRd(sfblock(0), j, xmtchan, hCore)
        For jj = 2 To wps
            sfblock(jj + 7) = ((&H100 * j) + jj) And &HFFF
        Next
        Call BTI717_SubFrmBlkWr(sfblock(0), j, xmtchan, hCore)
    Next
    
    '  Create some SuperFrame structures.
    Call BTI717_SuperFrmConfig(10, 16, xmtchan, hCore)
    
    '  Define SF2, W10 to be SuperFrame Data. Init superframe data.
    superfrmaddr = BTI717_SuperFrmDefine(2, 10, xmtchan, hCore)
    For j = 1 To 16
        Call BTI717_SuperFrmWordWr(&H500 + j, j, superfrmaddr, xmtchan, hCore)
    Next
    
    '  Set superframe counter position.
    Call BTI717_SuperFrmCounterPos(1, wps, rcvchan, hCore)
    Call BTI717_SuperFrmCounterPos(1, wps, xmtchan, hCore)
    
    '  Configure the Sequential Monitor.
    ERRVAL = BTICard_SeqConfig(SEQCFG_DEFAULT, hCore)
    If (ERRVAL < 0) Then
        MsgBox "Error:  An error was encountered while configuring the Sequential Monitor"
        bSkipRun = True
        Exit Sub
    End If
    
    '  Configure word options. (Mark word 1 of SFs 1, 2, 3, and 4 for the Sequential Monitor)
    Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 1, 1, rcvchan, hCore)
    Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 2, 1, rcvchan, hCore)
    Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 3, 1, rcvchan, hCore)
    Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 4, 1, rcvchan, hCore)

    Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 1, 1, xmtchan, hCore)
    Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 2, 1, xmtchan, hCore)
    Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 3, 1, xmtchan, hCore)
    Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 4, 1, xmtchan, hCore)
    
    '  (Mark the word at SPF 4 of our superframe word (word 10, SF 2) for the Sequential Monitor)
    Call BTI717_SuperFrmWordConfig(WRDCFG717_SEQ, 4, superfrmaddr, xmtchan, hCore)
    
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
    
    '  Start operation of the card.
    ERRVAL = BTICard_CardStart(hCore)
    If (ERRVAL < 0) Then
        MsgBox "Error:  An error was encountered while starting the card"
        bSkipRun = True
        Exit Sub
    End If
    
    bCardRunning = True
    CmdStart.Enabled = False
    CmdStop.Enabled = True
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
    
    CmdStart.Enabled = True
    CmdStop.Enabled = False
    Result1.Caption = "Card Stopped"
End Sub

Private Sub Form_Load()
    On Error GoTo Errhandler
    
    'Initialize handle to error condition and bSkipRun
    hCard = -1
    hCore = -1
    CmdStart.Enabled = False
    CmdStop.Enabled = False
    bSkipRun = False
    bCardRunning = False
    Result1.Caption = "Card Stopped"
    
    ' Open handle to card with specified card number
    ERRVAL = BTICard_CardOpen(hCard, cardnum)
    If (ERRVAL) Then
        MsgBox "Error: can not open card number " & CStr(cardnum)
        bSkipRun = True
        Exit Sub
    End If
    
    '
    ' Find the first ARINC 717 core with both BiPhase receive and transmit channels.
    '

    For corenum = 0 To MAX_CORES - 1
        ERRVAL = BTICard_CoreOpen(hCore, corenum, hCard)
        If ERRVAL = 0 Then
            'Search for receive
            For rcvchan = 0 To MAX_CHANNELS - 1
                If BTI717_ChIsType(CHCFG717_BIPHASERCV, rcvchan, hCore) Then
                    Exit For
                End If
            Next
            'Search for transmit
            For xmtchan = 0 To MAX_CHANNELS - 1
                If xmtchan <> rcvchan Then
                    If BTI717_ChIsType(CHCFG717_BIPHASERCV, xmtchan, hCore) Then
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
        MsgBox "Error:  No compatible ARINC 717 core present in card #" & cardnum
        bSkipRun = True
        Exit Sub
    End If
    
    Core.Caption = "Using core #" & corenum
    Channel.Caption = "Using 717 BiPhase channel " & rcvchan & " and " & xmtchan
    
    ' Init the list box
    List1.Clear
    List1.AddItem (64)
    List1.AddItem (128)
    List1.AddItem (256)
    List1.AddItem (512)
    List1.AddItem (1024)
    List1.AddItem (2048)
    List1.AddItem (4096)
    List1.AddItem (8192)
    List1.ListIndex = 3
    
    'Set flag so we run hardware
    bSkipRun = False
    
    CmdStart.Enabled = True
    CmdStop.Enabled = False
    Exit Sub
Errhandler:
        MsgBox "An Error Has Occured:  " & Err.Description

End Sub


Private Sub Timer1_Timer()
    Dim seqbuf(2047) As Integer
    Dim seqcount As Integer
    Dim rec717 As SEQRECORD717
    Dim sfinfo As SEQFINDINFO
    Dim myStr As String
    Dim timestr As String

    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If
    
    '
    ' Read the Sequential Record and display to screen.
    '
    
    seqcount = BTICard_SeqRd(seqbuf(0), hCore)
    
    ERRVAL = BTICard_SeqFindInit(seqbuf(0), seqcount, sfinfo)
    If (0 > ERRVAL) Then
        MsgBox "Error: SeqFindInit failed"
        bSkipRun = True
        Exit Sub
    End If
    
    ' Add each 717Record in SeqBuf to List2
    While (0 <= BTICard_SeqFindNext717Ex(rec717, LenB(rec717), sfinfo))
        'Create list item to add
        myStr = "Ch:" & ShiftRight(rec717.activity And MSGACT717_CHMASK, MSGACT717_CHSHIFT)
        myStr = myStr & " Word:" & rec717.wordnum
        myStr = myStr & " SF:" & rec717.subframe
        myStr = myStr & " SPF:" & ((rec717.superframe Mod 16) + 1)
        myStr = myStr & " Value:" & Oct(rec717.data) & " (Octal)"
        
        timestr = "TimeStamp:"
        timestr = timestr & " " & BTICard_IRIGFieldGetHours(rec717.timestamp, rec717.timestamph)
        timestr = timestr & ":" & BTICard_IRIGFieldGetMin(rec717.timestamp, rec717.timestamph)
        timestr = timestr & " " & BTICard_IRIGFieldGetSec(rec717.timestamp, rec717.timestamph)
        timestr = timestr & "." & BTICard_IRIGFieldGetMillisec(rec717.timestamp, rec717.timestamph)
        timestr = timestr & "." & BTICard_IRIGFieldGetMicrosec(rec717.timestamp, rec717.timestamph)
        
        myStr = myStr & timestr
        
        'Add item to List2
        List2.AddItem (myStr)
    Wend
    
End Sub
























