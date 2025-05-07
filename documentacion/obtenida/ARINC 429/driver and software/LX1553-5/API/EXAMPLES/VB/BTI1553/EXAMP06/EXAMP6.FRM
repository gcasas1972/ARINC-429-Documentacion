VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI1553 Example 6"
   ClientHeight    =   5175
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4935
   LinkTopic       =   "Form1"
   ScaleHeight     =   5175
   ScaleWidth      =   4935
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton CmdClr 
      Caption         =   "Clear"
      Height          =   375
      Left            =   960
      TabIndex        =   13
      ToolTipText     =   "Clear the result from previous transmition"
      Top             =   4680
      Width           =   735
   End
   Begin VB.CheckBox checkErrInj 
      Caption         =   "Error Injection (Parity CWD1)"
      Height          =   255
      Left            =   120
      TabIndex        =   11
      Top             =   4320
      Width           =   2415
   End
   Begin VB.CommandButton CmdSend 
      Caption         =   "Send"
      Height          =   375
      Left            =   120
      TabIndex        =   1
      Top             =   4680
      Width           =   735
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   4080
      TabIndex        =   0
      Top             =   4680
      Width           =   735
   End
   Begin VB.Label Header1a 
      Alignment       =   2  'Center
      Caption         =   "Unscheduled Messages"
      Height          =   255
      Left            =   0
      TabIndex        =   12
      Top             =   240
      Width           =   4935
   End
   Begin VB.Label Core 
      Caption         =   "Core"
      Height          =   255
      Left            =   780
      TabIndex        =   10
      Top             =   2160
      Width           =   3135
   End
   Begin VB.Label Channel 
      Caption         =   "Channel"
      Height          =   255
      Left            =   780
      TabIndex        =   9
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
      TabIndex        =   8
      Top             =   0
      Width           =   4935
   End
   Begin VB.Label Label1 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Left            =   240
      TabIndex        =   7
      Top             =   1215
      Width           =   4335
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP6  (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   240
      TabIndex        =   6
      Top             =   720
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Index           =   1
      Left            =   240
      TabIndex        =   5
      Top             =   975
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   240
      TabIndex        =   4
      Top             =   1440
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   240
      TabIndex        =   3
      Top             =   1680
      Width           =   4335
   End
   Begin VB.Line Line4 
      X1              =   240
      X2              =   4680
      Y1              =   2040
      Y2              =   2040
   End
   Begin VB.Line Line5 
      X1              =   240
      X2              =   4680
      Y1              =   600
      Y2              =   600
   End
   Begin VB.Label Result1 
      Caption         =   "Result1"
      Height          =   1215
      Left            =   255
      TabIndex        =   2
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
'  BTI1553 DRIVER VB_EXAMPLE 6  (06/07/2011)
'  Copyright (c) 2002-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP6 -- Errors in BC Transmissions - Unscheduled Messages
'
'  This example requires a Ballard 1553 C version Device or higher.
'  It configures Card Number 0 as a BC and transmits a single
'  receive command each time the send button is pressed. The message will
'  containe a parity error in the command word if the Error Injection box
'  if checked.
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
Dim errval As Long

' Program specific
Dim Msg As XMITFIELDS1553
Dim infoval As Long

Private Sub CmdClr_Click()
    Result1.Caption = ""
End Sub

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
    
    'Configure the channel for bus controller mode.
    BTICard_CardReset (hCore)
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
    
    '  Initialize the message command and data words, and select
    '  a BC-RT transfer.

    Msg.ctrlflags = MSGCRT1553_BCRT
    Msg.cwd1 = &H843
    Msg.data(0) = &H1234
    Msg.data(1) = &H5678
    Msg.data(2) = &H9ABC

    ' If the error injection check box is checked
    If checkErrInj.value = Checked Then
        '  Define the type of error generation.
        Call BTI1553_ErrorDefine(ERRDEF1553_PAR, 0, 0, ERRDEF1553_CWD1, 0, channum, hCore)
        Call BTI1553_ErrorCtrl((ERRCTRL1553_ONCE Or ERRCTRL1553_ANYMSG), channum, hCore)
    End If
    
    ' Start operation of the card.
    errval = BTICard_CardStart(hCore)
    If (errval < 0) Then
        MsgBox "Error:  An error was encountered while starting the card"
        bSkipRun = True
        Exit Sub
    End If
    
    CmdSend.Enabled = False
    
    ' Transmit the message

    errval = BTI1553_BCTransmitMsg(Msg, channum, hCore)
    
    '  Test for any error results.
    '
    '  Note the distinction between card errors and bus errors.
    '  The returned value of BTI1553_BCTransmitMsg is a card error
    '  (if any occurred).  Errors related to the RT's reponse are
    '  returned in the (errflags) member of the message
    '  structure.
    
    If errval < 0 Then
        Result1.Caption = "Error: An error was encountered " & errval & " while transmitting the message."
        Exit Sub
    End If

    Dim tempStr As String
    If (Msg.errflags And MSGERR1553_NORESP) Then         ' Was there a response?
        tempStr = "Warning:  No response was received from the RT. Refer to the documentation for a description of the error flags ("
        tempStr = tempStr & Hex(Msg.errflags) & "). This is the expected result when Remote Terminal 2 is pressent and error injection is checked."
    ElseIf (Msg.errflags And MSGERR1553_ANYERR) Then     ' Was there an error?
        tempStr = "Warning:  An error occurred while receiving the response from the RT. Refer to the documentation for a description of the error flags ("
        tempStr = tempStr & Hex(Msg.errflags) & ")"
    Else                                                  ' There were no errors
        tempStr = "Success!  The message was completed successfully. The RT returned the status word " & Hex(Msg.swd1)
        tempStr = tempStr & ". This is the expected result when Remote Terminal 2 is pressent and error injection is not checked."
    End If
    Result1.Caption = tempStr
    
    ' Stop the card
    BTICard_CardStop (hCore)
    CmdSend.Enabled = True
    
End Sub

Private Sub Form_Load()
    On Error GoTo Errhandler
    
    'Initialize handle to error condition and bSkipRun
    hCard = -1
    hCore = -1
    CmdSend.Enabled = False
    bSkipRun = False
    Result1.Caption = ""
    
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
    
    CmdSend.Enabled = True
    
    Exit Sub
Errhandler:
        MsgBox "An Error Has Occured:  " & Err.Description

End Sub


