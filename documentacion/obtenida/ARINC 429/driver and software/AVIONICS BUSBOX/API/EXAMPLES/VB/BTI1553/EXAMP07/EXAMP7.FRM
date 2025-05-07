VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI1553 Example 7"
   ClientHeight    =   3855
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4950
   LinkTopic       =   "Form1"
   ScaleHeight     =   3855
   ScaleWidth      =   4950
   StartUpPosition =   3  'Windows Default
   Begin VB.Timer Timer1 
      Interval        =   100
      Left            =   3480
      Top             =   3360
   End
   Begin VB.CommandButton CmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   60
      TabIndex        =   2
      Top             =   3360
      Width           =   735
   End
   Begin VB.CommandButton CmdStop 
      Caption         =   "Stop"
      Height          =   375
      Left            =   1020
      TabIndex        =   1
      Top             =   3360
      Width           =   735
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   4140
      TabIndex        =   0
      Top             =   3360
      Width           =   735
   End
   Begin VB.Label Header1a 
      Alignment       =   2  'Center
      Caption         =   "Scheduled Messages"
      Height          =   255
      Left            =   0
      TabIndex        =   12
      Top             =   240
      Width           =   4935
   End
   Begin VB.Label Core 
      Caption         =   "Core"
      Height          =   255
      Left            =   900
      TabIndex        =   11
      Top             =   2160
      Width           =   3135
   End
   Begin VB.Label Channel 
      Caption         =   "Channel"
      Height          =   255
      Left            =   900
      TabIndex        =   10
      Top             =   2400
      Width           =   3135
   End
   Begin VB.Label Header1 
      Alignment       =   2  'Center
      Caption         =   "Errors in BC Transmissions --"
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
      TabIndex        =   9
      Top             =   0
      Width           =   4935
   End
   Begin VB.Label Label1 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Left            =   255
      TabIndex        =   8
      Top             =   1215
      Width           =   4335
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP7  (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   255
      TabIndex        =   7
      Top             =   720
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Index           =   1
      Left            =   255
      TabIndex        =   6
      Top             =   975
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   255
      TabIndex        =   5
      Top             =   1440
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   255
      TabIndex        =   4
      Top             =   1680
      Width           =   4335
   End
   Begin VB.Line Line4 
      X1              =   255
      X2              =   4695
      Y1              =   2040
      Y2              =   2040
   End
   Begin VB.Line Line5 
      X1              =   255
      X2              =   4695
      Y1              =   600
      Y2              =   600
   End
   Begin VB.Label Result1 
      Caption         =   "Result1"
      Height          =   375
      Left            =   375
      TabIndex        =   3
      Top             =   2880
      Width           =   4215
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI1553 DRIVER VB_EXAMPLE 7  (06/07/2011)
'  Copyright (c) 2002-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP7 -- Errors in BC Transmissions - Scheduled Messages
'
'  This example requires a Ballard 1553 C version Device or higher.
'  It configures Card Number 0 as a BC and creates a schedule
'  containing a receive command each for terminal address 1
'  and terminal address 2.  Both receive commands send 2 data
'  words to the remote terminal.  The example then alternates
'  a bit count error between the first data word of both
'  commands.
'

Option Explicit

' Constants
Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16
Const frametime As Long = 100000          'Frame time in microseconds

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
Dim BCMsgs(0 To 1) As Long
Dim ErrorCount As Integer
Dim InitialData1 As Integer
Dim InitialData2 As Integer

Private Sub CmdExit_Click()
    If (hCore >= 0) Then
        errval = BTICard_CardClose(hCore)
    End If
      
    ' End Program
    End
    
End Sub

Private Sub CmdStart_Click()
    ErrorCount = 0

    If bSkipRun Then
        Exit Sub
    End If
    
    BTICard_CardReset (hCore)
    
    errval = BTI1553_BCConfig(BCCFG1553_DEFAULT, channum, hCore)
    If (errval < 0) Then
        MsgBox "Error:  An error was encountered while while configuring for bus controller mode"
        bSkipRun = True
        Exit Sub
    End If
    
    ' Create the message records
    BCMsgs(0) = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT, &H842, 0, InitialData1, hCore)
    BCMsgs(1) = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT, &H1042, 0, InitialData2, hCore)
    
    '  Schedule the messages to create the desired bus controller schedule.
    Call BTI1553_BCSchedFrame(frametime, channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(1), channum, hCore)

    '  Define the type of error generation.  One of the bus
    '  controller messages is tagged to generate errors once.
    Call BTI1553_ErrorDefine(ERRDEF1553_CNTBIT, 3, 2, 0, 0, channum, hCore)
    Call BTI1553_ErrorTagBC(True, BCMsgs(0), channum, hCore)
    Call BTI1553_ErrorCtrl((ERRCTRL1553_ONCE Or ERRCTRL1553_TAGMSG), channum, hCore)
    
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
    Result1.Caption = ""
    
    ' Open handle to card with specified card number
    errval = BTICard_CardOpen(hCard, cardnum)
    If (errval) Then
        MsgBox "Error: can not open card number " & CStr(cardnum)
        bSkipRun = True
        Exit Sub
    End If
    
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
    
    '  When the error is generated once, tag another message for
    '  error generation and enable another single error.
    
    If BTI1553_ErrorSent(channum, hCore) Then
        ErrorCount = ErrorCount + 1                             ' Inc the ErrorCount
        If (ErrorCount And 1) Then
            Call BTI1553_ErrorTagBC(False, BCMsgs(0), channum, hCore)
            Call BTI1553_ErrorTagBC(True, BCMsgs(1), channum, hCore)
        Else
            Call BTI1553_ErrorTagBC(True, BCMsgs(0), channum, hCore)
            Call BTI1553_ErrorTagBC(False, BCMsgs(1), channum, hCore)
        End If

        Call BTI1553_ErrorCtrl((ERRCTRL1553_ONCE Or ERRCTRL1553_TAGMSG), channum, hCore)
        
        ' Update the display
        Result1.Caption = "Error Count = " & CStr(ErrorCount)
    End If
    
End Sub




