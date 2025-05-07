VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI1553 Example 16"
   ClientHeight    =   4470
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   4470
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   12
      Top             =   3960
      Width           =   735
   End
   Begin VB.CommandButton cmdStop 
      Caption         =   "Stop"
      Enabled         =   0   'False
      Height          =   375
      Left            =   960
      TabIndex        =   11
      Top             =   3960
      Width           =   735
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   3840
      TabIndex        =   10
      Top             =   3960
      Width           =   735
   End
   Begin VB.Timer Timer1 
      Interval        =   500
      Left            =   1920
      Top             =   3960
   End
   Begin VB.CommandButton CmdDown 
      Height          =   615
      Left            =   2760
      Picture         =   "Examp16.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   9
      Top             =   3120
      Width           =   500
   End
   Begin VB.CommandButton CmdUp 
      Height          =   615
      Left            =   2760
      Picture         =   "Examp16.frx":0442
      Style           =   1  'Graphical
      TabIndex        =   8
      Top             =   2520
      Width           =   500
   End
   Begin VB.Label Label4 
      Caption         =   "Subtract 10 from the response time"
      Height          =   615
      Left            =   3360
      TabIndex        =   16
      Top             =   3240
      Width           =   1215
   End
   Begin VB.Label Label3 
      Caption         =   "Add 10 to the response time"
      Height          =   615
      Left            =   3360
      TabIndex        =   15
      Top             =   2520
      Width           =   1215
   End
   Begin VB.Label Label2 
      Caption         =   "Response Time:"
      Height          =   255
      Left            =   840
      TabIndex        =   14
      Top             =   2880
      Width           =   1215
   End
   Begin VB.Label TimeText 
      Caption         =   "resptime ="
      Height          =   255
      Left            =   840
      TabIndex        =   13
      Top             =   3120
      Width           =   1335
   End
   Begin VB.Label Label1 
      Caption         =   "Copyright 2003-2011"
      Height          =   255
      Left            =   120
      TabIndex        =   7
      Top             =   705
      Width           =   4335
   End
   Begin VB.Label Core 
      Caption         =   "Core:"
      Height          =   255
      Left            =   360
      TabIndex        =   6
      Top             =   1785
      Width           =   2895
   End
   Begin VB.Line Line1 
      X1              =   120
      X2              =   4560
      Y1              =   345
      Y2              =   345
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
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   4
      Top             =   1185
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   3
      Top             =   945
      Width           =   4335
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP16     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   2
      Top             =   465
      Width           =   4335
   End
   Begin VB.Label Channel 
      Caption         =   "Channel:"
      Height          =   255
      Left            =   360
      TabIndex        =   1
      Top             =   2040
      Width           =   4215
   End
   Begin VB.Line Line2 
      X1              =   120
      X2              =   4560
      Y1              =   1740
      Y2              =   1740
   End
   Begin VB.Label Header1 
      Caption         =   "RT Response Time"
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
      Left            =   1200
      TabIndex        =   0
      Top             =   0
      Width           =   2295
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI1553 DRIVER VB_EXAMPLE 16  (06/07/2011)
'  Copyright (c) 2003-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP16 -- RT Response Time
'
'  This example configures Card Number 0 as an RT to receive
'  the BC-RT data transmitted by the bus controller in
'  Example 2. The programmable RT response time is set and then
'  controlled by the up and down arrow buttons.
'

Option Explicit

' Constants
Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16
Const MAX_RESPTIME As Integer = 255
Const MIN_RESPTIME As Integer = 77

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
Dim resptime As Integer

Private Sub CmdDown_Click()
    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If
    
    ' Increment dacval
    resptime = resptime - 10
    If (resptime < MIN_RESPTIME) Then
        resptime = MIN_RESPTIME
    End If
    
    ' Temporaraly Stop the channel
    Call BTI1553_ChStop(channum, hCore)
    
    ' Update the response time on the core
    errval = BTI1553_RTResponseTimeSet(resptime, 1, channum, hCore)
    If (errval < 0) Then
        MsgBox "Error:  An error was encountered while setting the RT response time"
        bSkipRun = True
        Exit Sub
    End If
    
    ' Start the channel
    Call BTI1553_ChStart(channum, hCore)
    
    ' Update text
    TimeText.Caption = "resptime = " & Hex(resptime) & "H"
    
End Sub

Private Sub CmdExit_Click()
    If (hCard >= 0) Then
        errval = BTICard_CardClose(hCard)
    End If
      
    ' End Program
    End
    
End Sub

Private Sub CmdStart_Click()

    If bSkipRun Then
        Exit Sub
    End If
    
    BTICard_CardReset (hCore)
    
    ' Configure the core for remote terminal mode.
    errval = BTI1553_RTConfig(RTCFG1553_DEFAULT, 1, channum, hCore)
    If (errval < 0) Then
        MsgBox "Error:  An error was encountered while configuring the RT"
        bSkipRun = True
        Exit Sub
    End If
    
    ' Set the RT Response Time
    resptime = 80
    errval = BTI1553_RTResponseTimeSet(resptime, 1, channum, hCore)
    If (errval < 0) Then
        MsgBox "Error:  An error was encountered while setting the RT response time"
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
    CmdDown.Enabled = True
    CmdUp.Enabled = True
    TimeText.Caption = "resptime = " & Hex(resptime) & "H"

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
    CmdDown.Enabled = False
    CmdUp.Enabled = False
    
End Sub

Private Sub CmdUp_Click()
    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If
    
    ' Increment dacval
    resptime = resptime + 10
    If (resptime > MAX_RESPTIME) Then
        resptime = MAX_RESPTIME
    End If
    
    ' Temporaraly Stop the channel
    Call BTI1553_ChStop(channum, hCore)
    
    ' Update the response time on the core
    errval = BTI1553_RTResponseTimeSet(resptime, 1, channum, hCore)
    If (errval < 0) Then
        MsgBox "Error:  An error was encountered while setting the RT response time"
        bSkipRun = True
        Exit Sub
    End If
    
    ' Start the channel
    Call BTI1553_ChStart(channum, hCore)
    
    ' Update text
    TimeText.Caption = "resptime = " & Hex(resptime) & "H"
    
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
    CmdDown.Enabled = False
    CmdUp.Enabled = False
    
    ' Open handle to card with specified card number
    errval = BTICard_CardOpen(hCard, cardnum)
    If (errval) Then
        errstr = "Error: Unable to open card number " & cardnum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Find the first 1553 core and channel capable of programable RT response time
    For corenum = 0 To MAX_CORES - 1
        errval = BTICard_CoreOpen(hCore, corenum, hCard)
        If errval = 0 Then
            For channum = 0 To MAX_CHANNELS - 1
                If BTI1553_ChIs1553(channum, hCore) Then
                    If BTI1553_ChGetInfo(INFO1553_RTRESPTIME, channum, hCore) Then
                        Exit For
                    End If
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
    channel.Caption = "Using programmable RT response time 1553 channel #" & channum
    
    'Set flag so we run hardware
    bSkipRun = False
    
    cmdStart.Enabled = True
    cmdStop.Enabled = False
    
    Exit Sub
Errhandler:
        MsgBox "An Error Has Occured:  " & Err.Description

End Sub


