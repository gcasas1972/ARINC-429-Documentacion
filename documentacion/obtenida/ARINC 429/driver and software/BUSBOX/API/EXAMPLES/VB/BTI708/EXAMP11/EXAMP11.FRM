VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI708 Example 11"
   ClientHeight    =   4485
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   4485
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton CmdLeft 
      Height          =   500
      Left            =   1680
      Picture         =   "Examp11.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   14
      Top             =   3240
      Width           =   615
   End
   Begin VB.CommandButton CmdRight 
      Height          =   500
      Left            =   2280
      Picture         =   "Examp11.frx":0442
      Style           =   1  'Graphical
      TabIndex        =   13
      Top             =   3240
      Width           =   615
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   3840
      TabIndex        =   2
      Top             =   4020
      Width           =   735
   End
   Begin VB.CommandButton cmdStop 
      Caption         =   "Stop"
      Enabled         =   0   'False
      Height          =   375
      Left            =   960
      TabIndex        =   1
      Top             =   4020
      Width           =   735
   End
   Begin VB.CommandButton cmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   0
      Top             =   4020
      Width           =   735
   End
   Begin VB.Label Length 
      Caption         =   "Length ="
      Height          =   255
      Left            =   1695
      TabIndex        =   12
      Top             =   2760
      Width           =   1335
   End
   Begin VB.Label Label2 
      Caption         =   "Bit Length:"
      Height          =   255
      Left            =   1695
      TabIndex        =   11
      Top             =   2520
      Width           =   855
   End
   Begin VB.Line Line5 
      X1              =   120
      X2              =   4560
      Y1              =   3840
      Y2              =   3840
   End
   Begin VB.Line Line3 
      X1              =   120
      X2              =   4560
      Y1              =   2400
      Y2              =   2400
   End
   Begin VB.Label Header1 
      Caption         =   "Variable Bit Length Example."
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
      Left            =   833
      TabIndex        =   10
      Top             =   0
      Width           =   3015
   End
   Begin VB.Line Line2 
      X1              =   120
      X2              =   4560
      Y1              =   1740
      Y2              =   1740
   End
   Begin VB.Label Transmit 
      Caption         =   "Transmit:"
      Height          =   255
      Left            =   960
      TabIndex        =   9
      Top             =   2040
      Width           =   2895
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP11     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   8
      Top             =   465
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   7
      Top             =   945
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   6
      Top             =   1185
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   5
      Top             =   1425
      Width           =   4335
   End
   Begin VB.Line Line1 
      X1              =   120
      X2              =   4560
      Y1              =   345
      Y2              =   345
   End
   Begin VB.Label Core 
      Caption         =   "Core:"
      Height          =   255
      Left            =   960
      TabIndex        =   4
      Top             =   1785
      Width           =   2895
   End
   Begin VB.Label Label1 
      Caption         =   "Copyright 2003-2011"
      Height          =   255
      Left            =   120
      TabIndex        =   3
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
'  BTI708 DRIVER VB_EXAMPLE 11  (06/07/2011)
'  Copyright (c) 2003-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP11 -- Variable Bit Length Example
'
'  This program opens Card Number 0, and configures the
'  first transmit channel on the first 708 Core to transmit
'  a sequence of 32 messages at a rate of 200Hz. The messages
'  are automatically assigned the numbers 0 through 31.
'
'  The user can then control the bit length using the LEFT and
'  RIGHT arrow buttons.
'

Option Explicit

Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16

Const FRAMEFREQ As Integer = 200              'Frame frequency of 200Hz
Const logfreq As Integer = 16                 'Generate a Log Event after every 16th message
Const FRAMECOUNT As Integer = 32              'Transmit a total of 32 messages

Const BIT_HIGH As Integer = &H740
Const BIT_LOW As Integer = &H1

Dim bCardRunning As Boolean
Dim bSkipRun As Boolean
Dim hCard As Long
Dim hCore As Long
Dim ERRVAL As Long
Dim errstr As String
Dim corenum As Long
Dim xmtchan As Long
Dim Data(115) As Integer
Dim offset As Integer
Dim bitlength As Integer
Dim j As Integer
Dim jj As Integer

Private Sub CmdLeft_Click()
    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If
    
    ' Decrement dacval
    bitlength = bitlength - 16
    If (bitlength < BIT_LOW) Then
        bitlength = BIT_LOW
    End If
    
    ' Update the bitlength on the messages
    If (bitlength > BIT_HIGH) Then
        bitlength = BIT_HIGH
    ElseIf (bitlength < BIT_LOW) Then
        bitlength = BIT_LOW
    End If

    For j = 0 To FRAMECOUNT - 1                             'Loop through all the messages
        For jj = 0 To (bitlength / 16) + 1
            If (jj < 116) Then Data(jj) = j + (offset * FRAMECOUNT)
        Next
            
        Call BTI708_MsgVarDataWr(Data(0), bitlength, j, xmtchan, hCore)   'Write data to the Device
    Next
    offset = offset + 1
    
    ' Update text
    Length.Caption = "Length = " & bitlength
    
End Sub

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
    
    '
    ' Configure xmtchan to transmit at high speed.
    '

    BTICard_CardReset (hCore)
    
    'Configure channel
    ERRVAL = BTI708_ChConfig(CHCFG708_DEFAULT, xmtchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    '
    '  Build the transmit channel messages.
    '
    
    ERRVAL = BTI708_XmtBuild(MSGCRT708_DEFAULT, FRAMEFREQ, logfreq, FRAMECOUNT, xmtchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while building" & vbNewLine
        errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    '
    '  Create and write the data for the messages.
    '
    
    If (bitlength > BIT_HIGH) Then
        bitlength = BIT_HIGH
    ElseIf (bitlength < BIT_LOW) Then
        bitlength = BIT_LOW
    End If

    For j = 0 To FRAMECOUNT - 1                             'Loop through all the messages
        For jj = 0 To (bitlength / 16) + 1
            If (jj < 116) Then Data(jj) = j + (offset * FRAMECOUNT)
        Next
            
        Call BTI708_MsgVarDataWr(Data(0), bitlength, j, xmtchan, hCore)   'Write data to the Device
    Next
    offset = offset + 1

    ' Start operation of the card.
    ERRVAL = BTICard_CardStart(hCore)
    If (ERRVAL < 0) Then
        MsgBox "Error:  An error was encountered while starting the card"
        bSkipRun = True
        Exit Sub
    End If
    
    ' Update text
    Length.Caption = "Length = " & bitlength
     
    bCardRunning = True
    cmdStart.Enabled = False
    cmdStop.Enabled = True
    CmdLeft.Enabled = True
    CmdRight.Enabled = True
    
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
    CmdLeft.Enabled = False
    CmdRight.Enabled = False
    
End Sub

Private Sub CmdRight_Click()
    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If
    
    ' Increment bitlength
    bitlength = bitlength + 16
    If (bitlength > BIT_HIGH) Then
        bitlength = BIT_HIGH
    End If
    
    ' Update the amplitude on the core
    If (bitlength > BIT_HIGH) Then
        bitlength = BIT_HIGH
    ElseIf (bitlength < BIT_LOW) Then
        bitlength = BIT_LOW
    End If

    For j = 0 To FRAMECOUNT - 1                             'Loop through all the messages
        For jj = 0 To (bitlength / 16) + 1
            If (jj < 116) Then Data(jj) = j + (offset * FRAMECOUNT)
        Next
            
        Call BTI708_MsgVarDataWr(Data(0), bitlength, j, xmtchan, hCore)   'Write data to the Device
    Next
    offset = offset + 1
    
    ' Update text
    Length.Caption = "Length = " & bitlength
    
End Sub

Private Sub Form_Load()
    On Error GoTo Errhandler
    
    'Initialize handle to error condition and bSkipRun
    hCard = -1
    hCore = -1
    offset = 0
    bitlength = 1600
    bSkipRun = False
    bCardRunning = False
    cmdStart.Enabled = False
    cmdStop.Enabled = False
    CmdLeft.Enabled = False
    CmdRight.Enabled = False
    
    ' Open handle to card with specified card number
    ERRVAL = BTICard_CardOpen(hCard, cardnum)
    If (ERRVAL) Then
        MsgBox "Error: can not open card number " & CStr(cardnum)
        bSkipRun = True
        Exit Sub
    End If
    
    ' Find the first ARINC 708 core with a transmit channel that variable bitlength
    For corenum = 0 To (MAX_CORES - 1)
        ERRVAL = BTICard_CoreOpen(hCore, corenum, hCard)
        If ERRVAL = 0 Then
            For xmtchan = 0 To (MAX_CHANNELS - 1)
                If BTI708_ChIsXmt(xmtchan, hCore) Then
                    If (BTI708_ChGetInfo(INFO708_VARBIT, xmtchan, hCore) > 0) Then
                        Exit For
                    End If
                End If
            Next
            If (corenum < MAX_CORES) And (xmtchan < MAX_CHANNELS) Then
                Exit For
            End If
        End If
    Next
    
    If (hCore = 0) Or (corenum = MAX_CORES) Or (xmtchan = MAX_CHANNELS) Then
        MsgBox "Error:  No variable bit length ARINC 708 core present in card #" & cardnum
        bSkipRun = True
        Exit Sub
    End If

    Core.Caption = "Using core #" & corenum
    Transmit.Caption = "Using transmit channel #" & xmtchan
    
    'Set flag so we run hardware
    bSkipRun = False
    
    cmdStart.Enabled = True
    cmdStop.Enabled = False
    
    Exit Sub
Errhandler:
        MsgBox "An Error Has Occured:  " & Err.Description

End Sub





