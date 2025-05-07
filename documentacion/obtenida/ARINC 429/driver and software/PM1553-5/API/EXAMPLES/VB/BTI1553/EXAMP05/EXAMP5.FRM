VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI1553 Example 5"
   ClientHeight    =   3990
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4815
   LinkTopic       =   "Form1"
   ScaleHeight     =   3990
   ScaleWidth      =   4815
   StartUpPosition =   3  'Windows Default
   Begin VB.Timer Timer1 
      Interval        =   100
      Left            =   2760
      Top             =   3480
   End
   Begin VB.CommandButton CmdStop 
      Caption         =   "Stop"
      Height          =   375
      Left            =   960
      TabIndex        =   9
      Top             =   3480
      Width           =   735
   End
   Begin VB.CommandButton CmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   8
      Top             =   3480
      Width           =   735
   End
   Begin VB.CommandButton CmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   3960
      TabIndex        =   7
      Top             =   3480
      Width           =   735
   End
   Begin VB.Label Result1 
      Caption         =   "Result1"
      Height          =   255
      Left            =   240
      TabIndex        =   12
      Top             =   2640
      Width           =   4215
   End
   Begin VB.Label Channel 
      Caption         =   "Channel"
      Height          =   255
      Left            =   960
      TabIndex        =   11
      Top             =   2040
      Width           =   2895
   End
   Begin VB.Label Result2 
      Caption         =   "Result2"
      Height          =   255
      Left            =   240
      TabIndex        =   10
      Top             =   3000
      Width           =   4215
   End
   Begin VB.Line Line2 
      X1              =   120
      X2              =   4560
      Y1              =   1755
      Y2              =   1755
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP5     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   6
      Top             =   480
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   5
      Top             =   960
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   4
      Top             =   1200
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   3
      Top             =   1440
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
      TabIndex        =   2
      Top             =   1800
      Width           =   2895
   End
   Begin VB.Label Label1 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Left            =   120
      TabIndex        =   1
      Top             =   720
      Width           =   4335
   End
   Begin VB.Label Header1 
      Alignment       =   2  'Center
      Caption         =   "Simultanious BC,RT, and monitor simulation"
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
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   4815
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI1553 DRIVER VB_EXAMPLE 5  (06/07/2011)
'  Copyright (c) 2002-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP5 -- Simultaneous BC, RT, and monitor simulation
'
'  This example requires a Ballard 1553 C version Device or higher.
'  It configures Card Number 0 as a BC, an RT, and a Bus Monitor.
'  The BC transmits one BC-RT message (command word 0843H).
'  The RT is configured with terminal address 1, so the
'  simulated RT receives the simulated BC's transmissions.
'  The data word transmitted by the RT are incremented and
'  displayed.  The data words received by the RT are read and
'  also displayed.
'

Option Explicit

' Constants
Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16
Const frametime As Long = 10000

' Card specific
Dim hCard As Long
Dim hCore As Long
Dim corenum As Long
Dim channum As Long
Dim bSkipRun As Boolean
Dim bCardRunning As Boolean
Dim errval As Long

' Program specific
Dim BCMsg As Long
Dim RTMsg As Long
Dim BCData(2) As Integer
Dim RTData(2) As Integer

Private Sub CmdExit_Click()
    If (hCore >= 0) Then
        errval = BTICard_CardClose(hCore)
    End If
      
    ' End Program
    End
    
End Sub

Private Sub CmdStart_Click()

    If bSkipRun Then
        Exit Sub
    End If
    
    ' Configure the channel for bus controller mode
    BTICard_CardReset (hCore)
    errval = BTI1553_BCConfig(BCCFG1553_DEFAULT, channum, hCore)
    If (errval < 0) Then
        MsgBox "Error:  An error was encountered while while configuring for bus controller mode"
        bSkipRun = True
        Exit Sub
    End If
    
    '  Create a bus controller message and insert into the bus
    '  controller schedule.
    BCMsg = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT, &H843, 0, BCData(0), hCore)

    Call BTI1553_BCSchedFrame(frametime, channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsg, channum, hCore)

    '  Configure the channel for remote terminal mode as shown in Example 3.
    errval = BTI1553_RTConfig(RTCFG1553_DEFAULT, 1, channum, hCore)
    If (errval < 0) Then
        MsgBox "Error:  An error was encountered while while configuring for remote terminal mode"
        bSkipRun = True
        Exit Sub
    End If
    
    ' Get the message address for a receive subaddress.
    RTMsg = BTI1553_RTGetMsg(SUBADDRESS, 1, RCV, 2, channum, hCore)
    
    ' Configure the channel for monitor mode as shown in Example 4.
    errval = BTI1553_MonConfig(MONCFG1553_DEFAULT, channum, hCore)
    If (errval < 0) Then
        MsgBox "Error:  An error was encountered while while configuring for monitor mode"
        bSkipRun = True
        Exit Sub
    End If
    
    'Monitor RT address 1 only
    Call BTI1553_MonFilterTA(&H2, channum, hCore)
    
    ' Configure the sequential record.
    errval = BTICard_SeqConfig(SEQCFG_DEFAULT, hCore)
    If (errval < 0) Then
        MsgBox "Error:  An error was encountered while while configuring the sequential record"
        bSkipRun = True
        Exit Sub
    End If
    
    ' Initialize the data arrays
    BCData(0) = 0
    BCData(1) = 0
    BCData(2) = 0
    RTData(0) = 0
    RTData(1) = 0
    RTData(2) = 0
    
    ' Start operation of the card.
    errval = BTICard_CardStart(hCore)
    If (errval < 0) Then
        MsgBox "Error:  An error was encountered while starting the card"
        bSkipRun = True
        Exit Sub
    End If
    
    bCardRunning = True
    CmdStart.Enabled = False
    CmdStop.Enabled = True
    
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
    Result2.Caption = ""
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
    Result2.Caption = ""
    
    ' Open handle to card with specified card number
    errval = BTICard_CardOpen(hCard, cardnum)
    If (errval) Then
        MsgBox "Error: can not open card number " & CStr(cardnum)
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
    
    If BTI1553_ChIsC(channum, hCore) Then
        channel.Caption = "Using 1553 version C channel #" & CStr(channum)
    ElseIf BTI1553_ChIsD(channum, hCore) Then
        channel.Caption = "Using 1553 version D channel #" & CStr(channum)
    Else
        MsgBox "Error:  Example required a 1553 C or D version channel"
        bSkipRun = True
        Exit Sub
    End If
    
    Core.Caption = "Using core #" & corenum
    
    'Set flag so we run hardware
    bSkipRun = False
    
    CmdStart.Enabled = True
    CmdStop.Enabled = False
    Exit Sub
Errhandler:
        MsgBox "An Error Has Occured:  " & Err.Description

End Sub

Private Sub Timer1_Timer()
    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If
    
    ' Update the data that the BC is transmitting
    BCData(0) = BCData(0) + 2
    BCData(1) = BCData(1) + 4
    BCData(2) = BCData(2) + 6
    
    ' Update the output fields for user
    Result1.Caption = "Transmitting data {" & Hex(BCData(0)) & ", " & Hex(BCData(1)) & ", " & Hex(BCData(2)) & "}"
    
    ' Read the data received by the RT
    Call BTI1553_MsgDataWr(BCData(0), 3, BCMsg, hCore)
    Call BTI1553_MsgDataRd(RTData(0), 3, RTMsg, hCore)
    
    ' Update the output fields for user
    Result2.Caption = "Received data {" & Hex(RTData(0)) & ", " & Hex(RTData(1)) & ", " & Hex(RTData(2)) & "}"
End Sub




