VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI717 Example 2"
   ClientHeight    =   5400
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4920
   LinkTopic       =   "T"
   ScaleHeight     =   5400
   ScaleWidth      =   4920
   StartUpPosition =   3  'Windows Default
   Begin VB.ListBox List1 
      Height          =   840
      Left            =   1440
      TabIndex        =   13
      Top             =   3960
      Width           =   1575
   End
   Begin VB.CommandButton cmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   2
      Top             =   4920
      Width           =   735
   End
   Begin VB.CommandButton cmdStop 
      Caption         =   "Stop"
      Enabled         =   0   'False
      Height          =   375
      Left            =   960
      TabIndex        =   1
      Top             =   4920
      Width           =   735
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   4080
      TabIndex        =   0
      Top             =   4920
      Width           =   735
   End
   Begin VB.Timer Timer1 
      Interval        =   100
      Left            =   2160
      Top             =   4920
   End
   Begin VB.Label WordLbl 
      Caption         =   "Words Per Second"
      Height          =   255
      Index           =   1
      Left            =   1440
      TabIndex        =   14
      Top             =   3720
      Width           =   1575
   End
   Begin VB.Line Line2 
      X1              =   150
      X2              =   4590
      Y1              =   1740
      Y2              =   1740
   End
   Begin VB.Label Channel 
      Caption         =   "Channel:"
      Height          =   255
      Left            =   990
      TabIndex        =   12
      Top             =   2040
      Width           =   2895
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP2     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   150
      TabIndex        =   11
      Top             =   480
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   150
      TabIndex        =   10
      Top             =   945
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   150
      TabIndex        =   9
      Top             =   1185
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   8
      Top             =   1425
      Width           =   4335
   End
   Begin VB.Line Line1 
      X1              =   150
      X2              =   4590
      Y1              =   360
      Y2              =   360
   End
   Begin VB.Label Core 
      Caption         =   "Core:"
      Height          =   255
      Left            =   990
      TabIndex        =   7
      Top             =   1785
      Width           =   2895
   End
   Begin VB.Label Label1 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Index           =   0
      Left            =   150
      TabIndex        =   6
      Top             =   705
      Width           =   4335
   End
   Begin VB.Label Header1 
      Alignment       =   2  'Center
      Caption         =   "Transmitter Example"
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
      Left            =   150
      TabIndex        =   5
      Top             =   0
      Width           =   4575
   End
   Begin VB.Label Result1 
      Caption         =   "Result1"
      Height          =   495
      Left            =   150
      TabIndex        =   4
      Top             =   2280
      Width           =   4215
   End
   Begin VB.Label Result2 
      Caption         =   "Result2"
      Height          =   495
      Left            =   150
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
'  BTI717 DRIVER VB_EXAMPLE 2  (06/07/2011)
'  Copyright (c) 2002-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP2 -- Transmitter example
'
'  This program opens Card Number 0, and configures the
'  first BiPhase channel as a transmitter.  The transmit
'  channel is loaded with incrementing data.
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
Dim xmtchan As Long
Dim bSkipRun As Boolean
Dim bCardRunning As Boolean

' Program specific
Dim wps As Integer
Dim sfblock(8199) As Integer
Dim chstatus(7) As Integer
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
            
    '
    '  Configure transmitter channel at specified words per second.
    '
    
    BTICard_CardReset (hCore)
    
    If List1.Text = "64" Then
        wps = 64
        ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_64WPS, xmtchan, hCore)
    ElseIf List1.Text = "128" Then
        wps = 128
        ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_128WPS, xmtchan, hCore)
    ElseIf List1.Text = "256" Then
        wps = 256
        ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_256WPS, xmtchan, hCore)
    ElseIf List1.Text = "512" Then
        wps = 512
        ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_512WPS, xmtchan, hCore)
    ElseIf List1.Text = "1024" Then
        wps = 1024
        ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_1024WPS, xmtchan, hCore)
    ElseIf List1.Text = "2048" Then
        wps = 2048
        ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_2048WPS Or CHCFG717_XMTSLOPEHIGH, xmtchan, hCore)
    ElseIf List1.Text = "4096" Then
        wps = 4096
        ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_4096WPS Or CHCFG717_XMTSLOPEHIGH, xmtchan, hCore)
    ElseIf List1.Text = "8192" Then
        wps = 8192
        ERRVAL = BTI717_ChConfig(CHCFG717_BIPHASEXMT Or CHCFG717_8192WPS Or CHCFG717_XMTSLOPEHIGH, xmtchan, hCore)
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
        
    '  Start operation of the card.
    ERRVAL = BTICard_CardStart(hCore)
    If (ERRVAL < 0) Then
        MsgBox "Error:  An error was encountered while starting the card"
        bSkipRun = True
        Exit Sub
    End If
    
    bCardRunning = True
    cmdStart.Enabled = False
    cmdStop.Enabled = True
    Result1.Caption = "Transmitting data...."
    
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
    Result2.Caption = ""
End Sub

Private Sub Form_Load()
    On Error GoTo Errhandler
    
    'Initialize handle to error condition and bSkipRun
    hCard = -1
    hCore = -1
    cmdStart.Enabled = False
    cmdStop.Enabled = False
    bSkipRun = False
    bCardRunning = False
    Result1.Caption = "Card Stopped"
    Result2.Caption = ""
    
    ' Open handle to card with specified card number
    ERRVAL = BTICard_CardOpen(hCard, cardnum)
    If (ERRVAL) Then
        MsgBox "Error: can not open card number " & CStr(cardnum)
        bSkipRun = True
        Exit Sub
    End If
    
    '
    ' Find the first ARINC 717 core with a BiPhase transmit channel.
    '

    For corenum = 0 To MAX_CORES - 1
        ERRVAL = BTICard_CoreOpen(hCore, corenum, hCard)
        If ERRVAL = 0 Then
            'Search for transmit
            For xmtchan = 0 To MAX_CHANNELS - 1
                If BTI717_ChIsType(CHCFG717_BIPHASEXMT, xmtchan, hCore) Then
                    Exit For
                End If
            Next

            If (xmtchan < MAX_CHANNELS) Then
                Exit For
            End If
        End If
    Next
    
    If (ERRVAL <> 0) Or (corenum >= MAX_CORES) Or (xmtchan >= MAX_CHANNELS) Then
        MsgBox "Error:  No compatible ARINC 717 core present in card #" & cardnum
        bSkipRun = True
        Exit Sub
    End If
    
    Core.Caption = "Using core #" & corenum
    Channel.Caption = "Using 717 BiPhase channel #" & xmtchan
    
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
    
    '
    ' Add code here to change data, show status, etc.
    '
    
    Call BTI717_ChStatus(chstatus(0), xmtchan, hCore)
    Result2.Caption = "Subframe:" & chstatus(2) & " Word:" & chstatus(1)
    
End Sub

