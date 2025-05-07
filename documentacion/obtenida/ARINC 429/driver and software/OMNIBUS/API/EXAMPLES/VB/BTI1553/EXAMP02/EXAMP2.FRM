VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI1553 Example 2"
   ClientHeight    =   3690
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4935
   LinkTopic       =   "Form1"
   ScaleHeight     =   3690
   ScaleWidth      =   4935
   StartUpPosition =   3  'Windows Default
   Begin VB.Timer Timer1 
      Interval        =   100
      Left            =   3480
      Top             =   3240
   End
   Begin VB.CommandButton CmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   2
      Top             =   3240
      Width           =   735
   End
   Begin VB.CommandButton CmdStop 
      Caption         =   "Stop"
      Height          =   375
      Left            =   1080
      TabIndex        =   1
      Top             =   3240
      Width           =   735
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   4080
      TabIndex        =   0
      Top             =   3240
      Width           =   735
   End
   Begin VB.Label Core 
      Caption         =   "Core"
      Height          =   255
      Left            =   900
      TabIndex        =   11
      Top             =   2040
      Width           =   3135
   End
   Begin VB.Label Channel 
      Caption         =   "Channel"
      Height          =   255
      Left            =   900
      TabIndex        =   10
      Top             =   2280
      Width           =   3135
   End
   Begin VB.Label Header1 
      Alignment       =   2  'Center
      Caption         =   "Simulating the BC - Scheduled Messages"
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
      Top             =   120
      Width           =   4935
   End
   Begin VB.Label Label1 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Left            =   255
      TabIndex        =   8
      Top             =   1095
      Width           =   4335
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP2  (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   255
      TabIndex        =   7
      Top             =   600
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Index           =   1
      Left            =   255
      TabIndex        =   6
      Top             =   855
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   255
      TabIndex        =   5
      Top             =   1320
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   255
      TabIndex        =   4
      Top             =   1560
      Width           =   4335
   End
   Begin VB.Line Line4 
      X1              =   255
      X2              =   4695
      Y1              =   1920
      Y2              =   1920
   End
   Begin VB.Line Line5 
      X1              =   255
      X2              =   4695
      Y1              =   480
      Y2              =   480
   End
   Begin VB.Label Result1 
      Caption         =   "Result1"
      Height          =   375
      Left            =   375
      TabIndex        =   3
      Top             =   2760
      Width           =   4215
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI1553 DRIVER VB_EXAMPLE 2  (06/07/2011)
'  Copyright (c) 2002-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP2 -- Simulating the BC - Scheduled Messages
'
'  This example configures Card Number 0 as a bus controller
'  to transmit a schedule of three messages.  The schedule is
'  created in such a way that the messages are transmitted at
'  frequencies of 100Hz, 50Hz, and 25Hz (or every 10ms, 20ms,
'  and 40ms, respectively).
'
'  The program watches the 'hit' bit associated with the 0842(Hex)
'  BC->RT message.  When the message is transmitted and the
'  bit is set, the program updates the data words.
'

Option Explicit

' Constants
Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16
Const CMD0 As Integer = &H843           ' Command word for first message
Const CMD1 As Integer = &H821           ' Command word for second message
Const RCV_CMD2 As Integer = &H821       ' Receive command of an RT-RT trnsfer
Const XMT_CMD2 As Integer = &H1C21      ' Transmit command of an RT-RT transfer
Const frametime As Integer = 10000      ' Frame time in microcesonds

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
Dim BCMsgs(2) As Long
Dim MsgErrors As Long
Dim data(2) As Integer

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
    
    'Configure the channel for bus controller mode.
    BTICard_CardReset (hCore)
    errval = BTI1553_BCConfig(BCCFG1553_DEFAULT, channum, hCore)
    If (errval < 0) Then
        MsgBox "Error:  An error was encountered while while configuring for bus controller mode"
        bSkipRun = True
        Exit Sub
    End If
    
    ' Create the message records for each of the three messages.
    data(0) = 0
    data(1) = 0
    data(2) = 0
    BCMsgs(0) = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT, CMD0, 0, data(0), hCore)
    BCMsgs(1) = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT, CMD1, 0, data(1), hCore)
    BCMsgs(2) = BTI1553_BCCreateMsg(MSGCRT1553_RTRT, RCV_CMD2, XMT_CMD2, data(2), hCore)
    
    ' Schedule the messages to create the desired bus controller schedule.
    Call BTI1553_BCSchedFrame(frametime, channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(1), channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(2), channum, hCore)

    Call BTI1553_BCSchedFrame(frametime, channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)

    Call BTI1553_BCSchedFrame(frametime, channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(1), channum, hCore)

    Call BTI1553_BCSchedFrame(frametime, channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)
    
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
    Result1.Caption = "Transmitting data " & Hex(data(0)) & " " & Hex(data(1)) & " " & Hex(data(2))
    
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
    bSkipRun = False
    bCardRunning = False
    CmdStart.Enabled = False
    CmdStop.Enabled = False
    Result1.Caption = "Card Stopped"
    
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
    
    '  Watch the 'hit' bit of the first message to see if it has
    '  been transmitted.  If it has, update the data words.
    
    MsgErrors = BTI1553_MsgFieldRd(FIELD1553_ERROR, BCMsgs(0), hCore)
    If (MsgErrors And MSGERR1553_HIT) Then
        ' Calculate the new data words
        data(0) = data(0) + 2
        data(1) = data(1) + 4
        data(2) = data(2) + 6
        ' Write the new data words
        Call BTI1553_MsgDataWr(data(0), 3, BCMsgs(0), hCore)
        'Clear the 'hit' bit
        Call BTI1553_MsgFieldWr(0, FIELD1553_ERROR, BCMsgs(0), hCore)
        ' Update the output text
        Result1.Caption = "Transmitting data " & Hex(data(0)) & " " & Hex(data(1)) & " " & Hex(data(2))
    End If
    
End Sub
