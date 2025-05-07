VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI1553 Example 1"
   ClientHeight    =   4065
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   5070
   LinkTopic       =   "Form1"
   ScaleHeight     =   4065
   ScaleWidth      =   5070
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   4200
      TabIndex        =   1
      Top             =   3600
      Width           =   735
   End
   Begin VB.CommandButton CmdSend 
      Caption         =   "Send"
      Height          =   375
      Left            =   120
      TabIndex        =   0
      Top             =   3600
      Width           =   735
   End
   Begin VB.Label Result1 
      Height          =   735
      Left            =   435
      TabIndex        =   10
      Top             =   2760
      Width           =   4215
   End
   Begin VB.Line Line5 
      X1              =   308
      X2              =   4748
      Y1              =   480
      Y2              =   480
   End
   Begin VB.Line Line4 
      X1              =   308
      X2              =   4748
      Y1              =   1920
      Y2              =   1920
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   308
      TabIndex        =   9
      Top             =   1560
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   308
      TabIndex        =   8
      Top             =   1320
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Index           =   1
      Left            =   308
      TabIndex        =   7
      Top             =   855
      Width           =   4335
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP1  (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   308
      TabIndex        =   6
      Top             =   600
      Width           =   4335
   End
   Begin VB.Label Label1 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Left            =   308
      TabIndex        =   5
      Top             =   1095
      Width           =   4335
   End
   Begin VB.Label Header1 
      Alignment       =   2  'Center
      Caption         =   "Simulating the BC - Unscheduled Messages"
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
      Left            =   60
      TabIndex        =   4
      Top             =   120
      Width           =   4935
   End
   Begin VB.Label Channel 
      Caption         =   "Channel"
      Height          =   255
      Left            =   960
      TabIndex        =   3
      Top             =   2280
      Width           =   3135
   End
   Begin VB.Label Core 
      Caption         =   "Core"
      Height          =   255
      Left            =   960
      TabIndex        =   2
      Top             =   2040
      Width           =   3135
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI1553 DRIVER VB_EXAMPLE 1  (06/07/2011)
'  Copyright (c) 2002-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP1 -- Simulating the BC - Unscheduled Messages
'
'  This example configures Card Number 0 as a BC to transmit
'  the receive command 0843(Hex) with data words 1234(Hex), 5678(Hex),
'  and 9ABC(Hex).  If the message is completed successfully, it
'  displays the responding RT's status word.  Otherwise it
'  displays the value of any errors.
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
Dim Msg As XMITFIELDS1553
Dim infoval As Long

Private Sub CmdExit_Click()
    If (hCore >= 0) Then
        errval = BTICard_CardClose(hCore)
    End If
      
    ' End Program
    End
    
End Sub

Private Sub CmdSend_Click()

    If bSkipRun Then
        Exit Sub
    End If
    
    BTICard_CardReset (hCore)
    
    'Configure the channel for bus controller mode.
    errval = BTI1553_BCConfig(BCCFG1553_DEFAULT, channum, hCore)
    If (errval < 0) Then
        MsgBox "Error:  An error was encountered while while configuring for bus controller mode"
        Exit Sub
    End If
    
    '  Create an empty frame in the BC Schedule.
    '
    '  BTI1553_BCTransmitMsg uses an asynchronous Message Record
    '  that is transmitted at the end of every frame.  Therefore,
    '  even though we aren't scheduling messages, we must still
    '  schedule a frame.

    Call BTI1553_BCSchedFrame(1000, channum, hCore)

    CmdSend.Enabled = False
    
    ' Start operation of the card.
    errval = BTICard_CardStart(hCore)
    If (errval < 0) Then
        MsgBox "Error:  An error was encountered while starting the card"
        bSkipRun = True
        Exit Sub
    End If
    
    '  Initialize the message command and data words, and select
    '  a BC-RT transfer.
    
    Msg.ctrlflags = MSGCRT1553_BCRT                    ' Selects BC->RT transfer
    Msg.cwd1 = BTI1553_ValPackCWD(1, 0, 2, 3)          ' Receive command word
    Msg.data(0) = &H1234                               ' Data word 0
    Msg.data(1) = &H5678                               ' Data word 1
    Msg.data(2) = &H9ABC                               ' Data word

    '   Transmit the message
    errval = BTI1553_BCTransmitMsg(Msg, channum, hCore)
    
    '  Test for any error results.
    '
    '  Note the distinction between card errors and bus errors.
    '  The returned value of BTI1553_BCTransmitMsg is a card error
    '  (if any occurred).  Errors related to the RT's response are
    '  returned in the (errflags) member of the message
    '  structure.
    
    If errval < 0 Then
        Result1.Caption = "Error: An error was encountered " & errval & " while transmitting the message."
    End If

    If (Msg.errflags And MSGERR1553_NORESP) Then         ' Was there a response?
        Result1.Caption = "Warning:  No response was received from the RT. Refer to the documentation for a description of the error flags (" & Hex(Msg.errflags) & ")"
    ElseIf (Msg.errflags And MSGERR1553_ANYERR) Then     ' Was there an error?
        Result1.Caption = "Warning:  An error occurred while receiving the response from the RT. Refer to the documentation for a description of the error flags (" & Hex(Msg.errflags) & ")"
    Else                                                 ' There were no errors
        Result1.Caption = "Success!  The message was completed successfully. The RT returned the status word " & Hex(Msg.swd1)
    End If
    
    ' Stop the card
    BTICard_CardStop (hCore)
    CmdSend.Enabled = True
    
End Sub

Private Sub Form_Load()
    On Error GoTo Errhandler
    
    'Initialize handle to error condition and bSkipRun
    hCard = -1
    hCore = -1
    bSkipRun = False
    bCardRunning = False
    CmdSend.Enabled = False
    
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
    
    CmdSend.Enabled = True
    
    Exit Sub
Errhandler:
        MsgBox "An Error Has Occured:  " & Err.Description

End Sub
