VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI708 Example 2"
   ClientHeight    =   6000
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   6735
   LinkTopic       =   "Form1"
   ScaleHeight     =   6000
   ScaleWidth      =   6735
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton CmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   5880
      TabIndex        =   3
      Top             =   5520
      Width           =   735
   End
   Begin VB.CommandButton CmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   2
      Top             =   5520
      Width           =   735
   End
   Begin VB.CommandButton CmdStop 
      Caption         =   "Stop"
      Height          =   375
      Left            =   960
      TabIndex        =   1
      Top             =   5520
      Width           =   735
   End
   Begin VB.Timer Timer1 
      Interval        =   10
      Left            =   2760
      Top             =   5520
   End
   Begin VB.ListBox List1 
      BeginProperty Font 
         Name            =   "Courier"
         Size            =   9.75
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   2595
      Left            =   120
      TabIndex        =   0
      Top             =   2760
      Width           =   6495
   End
   Begin VB.Label Core 
      Caption         =   "Core"
      Height          =   255
      Left            =   1200
      TabIndex        =   12
      Top             =   1800
      Width           =   4215
   End
   Begin VB.Label Header1 
      Caption         =   "Receiver Example"
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
      Left            =   2280
      TabIndex        =   11
      Top             =   0
      Width           =   2175
   End
   Begin VB.Label Header3 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Left            =   1140
      TabIndex        =   10
      Top             =   720
      Width           =   4335
   End
   Begin VB.Line Line1 
      X1              =   1140
      X2              =   5580
      Y1              =   360
      Y2              =   360
   End
   Begin VB.Label Header6 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   1140
      TabIndex        =   9
      Top             =   1440
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   1140
      TabIndex        =   8
      Top             =   1200
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   1140
      TabIndex        =   7
      Top             =   960
      Width           =   4335
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP2     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   1140
      TabIndex        =   6
      Top             =   480
      Width           =   4335
   End
   Begin VB.Line Line2 
      X1              =   1140
      X2              =   5580
      Y1              =   1755
      Y2              =   1755
   End
   Begin VB.Label Result1 
      Caption         =   "Result1"
      Height          =   255
      Left            =   1200
      TabIndex        =   5
      Top             =   2400
      Width           =   4215
   End
   Begin VB.Label ChanLbl 
      Caption         =   "ChanLbl"
      Height          =   255
      Left            =   1200
      TabIndex        =   4
      Top             =   2040
      Width           =   4215
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI708 DRIVER VB_EXAMPLE 2  (06/07/2011)
'  Copyright (c) 2002-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP2 -- Receiver example
'
'  This program opens Card Number 0, and configures the
'  firtst compatable core to receive messages in a single
'  message record.  This message is automatically assigned
'  to message number 0.
'
'  An Event Log frequency of 0 is specifed, which will
'  not generate any Event Log List entries for this channel.
'
'  The program will display the data from the message record,
'  until a Stop button is pressed.
'

Option Explicit

' Constants
Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16

Const FRAMEFREQ As Integer = 200        ' Frame frequency of 200Hz
Const logfreq As Integer = 16           ' Generate a Log Event after every 16th message
Const FRAMECOUNT As Integer = 32        ' Transmit a total of 32 messages


' Card specific
Dim hCard As Long
Dim hCore As Long
Dim ERRVAL As Long
Dim errstr As String
Dim corenum As Long
Dim rcvchan As Long
Dim bSkipRun As Boolean
Dim bCardRunning As Boolean

' Program specific
Dim Data(0 To 99) As Integer
Dim j As Integer
Dim jj As Integer

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
    
    ' Clear all contents from the list control
    List1.Clear
    
    ' Configure receive channel.
    BTICard_CardReset (hCore)
    ERRVAL = BTI708_ChConfig(CHCFG708_DEFAULT, rcvchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Build the receive channel messages.
    ERRVAL = BTI708_RcvBuild(MSGCRT708_DEFAULT, 0, 1, rcvchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while building" & vbNewLine
        errstr = errstr & "receive channel #" & rcvchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
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
    Result1.Caption = "Receiving data"
    
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
        errstr = "Error: Unable to open card number " & cardnum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Find the first ARINC 708 core with a receive channel
    For corenum = 0 To MAX_CORES - 1
        ERRVAL = BTICard_CoreOpen(hCore, corenum, hCard)
        If ERRVAL = 0 Then
            For rcvchan = 0 To MAX_CHANNELS - 1
                If BTI708_ChIsRcv(rcvchan, hCore) Then
                   Exit For
                End If
            Next
            If rcvchan < MAX_CHANNELS Then
                Exit For
            End If
        End If
    Next
    
    If (ERRVAL <> 0) Or (corenum >= MAX_CORES) Or (rcvchan >= MAX_CHANNELS) Then
        MsgBox "Error:  No compatible ARINC 708 core present in card #" & cardnum
        bSkipRun = True
        Exit Sub
    End If
    
    Core.Caption = "Using core #" & corenum
    ChanLbl.Caption = "Using ARINC 708 receive channel #" & rcvchan
    
    'Set flag so we run hardware
    bSkipRun = False
    
    CmdStart.Enabled = True
    CmdStop.Enabled = False
    Exit Sub
Errhandler:
        MsgBox "An Error Has Occured:  " & Err.Description

End Sub

Private Sub Timer1_Timer()
    Dim tempstr As String
    Dim str As String
    
    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If
    
    '
    ' Loop until Stop button is hit.
    '
    
    Call BTI708_MsgDataRd(Data(0), 0, rcvchan, hCore)
    
    List1.Clear
    
    For j = 0 To 9
        str = j & " "
        For jj = 0 To 9
            tempstr = CStr(Hex(Data((j * 10) + jj)))
            If Len(tempstr) = 1 Then
                tempstr = "000" & tempstr
            ElseIf Len(tempstr) = 2 Then
                tempstr = "00" & tempstr
            ElseIf Len(tempstr) = 3 Then
                tempstr = "0" & tempstr
            End If
            str = str & " " & tempstr
        Next
        List1.AddItem (str)
    Next
    
End Sub

