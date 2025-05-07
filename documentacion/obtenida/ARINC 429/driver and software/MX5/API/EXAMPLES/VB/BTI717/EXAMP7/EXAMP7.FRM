VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI717 Example 7"
   ClientHeight    =   4545
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4710
   LinkTopic       =   "Form1"
   ScaleHeight     =   4545
   ScaleWidth      =   4710
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton CmdDown 
      Height          =   615
      Left            =   2760
      Picture         =   "Examp7.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   14
      Top             =   3120
      Width           =   500
   End
   Begin VB.CommandButton CmdUp 
      Height          =   615
      Left            =   2760
      Picture         =   "Examp7.frx":0442
      Style           =   1  'Graphical
      TabIndex        =   13
      Top             =   2520
      Width           =   500
   End
   Begin VB.CommandButton cmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
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
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   3840
      TabIndex        =   0
      Top             =   4020
      Width           =   735
   End
   Begin VB.Label Label1 
      Caption         =   "Copyright 2003-2011"
      Height          =   255
      Left            =   120
      TabIndex        =   12
      Top             =   705
      Width           =   4335
   End
   Begin VB.Label Core 
      Caption         =   "Core:"
      Height          =   255
      Left            =   960
      TabIndex        =   11
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
      TabIndex        =   10
      Top             =   1425
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   9
      Top             =   1185
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   8
      Top             =   945
      Width           =   4335
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP7     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   7
      Top             =   465
      Width           =   4335
   End
   Begin VB.Label Transmit 
      Caption         =   "Transmit (Parametric):"
      Height          =   255
      Left            =   960
      TabIndex        =   6
      Top             =   2040
      Width           =   2895
   End
   Begin VB.Line Line2 
      X1              =   120
      X2              =   4560
      Y1              =   1740
      Y2              =   1740
   End
   Begin VB.Label Header1 
      Caption         =   "Parametrics example."
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
      TabIndex        =   5
      Top             =   0
      Width           =   2295
   End
   Begin VB.Line Line3 
      X1              =   120
      X2              =   4560
      Y1              =   2400
      Y2              =   2400
   End
   Begin VB.Line Line5 
      X1              =   120
      X2              =   4440
      Y1              =   3840
      Y2              =   3840
   End
   Begin VB.Label Label2 
      Caption         =   "Amplitude:"
      Height          =   255
      Left            =   1385
      TabIndex        =   4
      Top             =   2520
      Width           =   855
   End
   Begin VB.Label DacText 
      Caption         =   "Dac = "
      Height          =   255
      Left            =   1385
      TabIndex        =   3
      Top             =   2760
      Width           =   1335
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI717 DRIVER VB_EXAMPLE 7  (06/07/2011)
'  Copyright (c) 2003-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP7 -- Parametrics example
'
'  The user can then control the amplitude using the UP and
'  DOWN arrow keys and the frequency using the LEFT and RIGHT
'  arrow keys.
'

' Force explicit declaration of all variables
Option Explicit

Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16

Const DAC_HIGH As Integer = &HFF0
Const DAC_LOW As Integer = &H600

Dim bCardRunning As Boolean
Dim bSkipRun As Boolean
Dim hCard As Long
Dim hCore As Long
Dim ERRVAL As Long
Dim errstr As String
Dim corenum As Long
Dim xmtchan As Long

' Program specific
Dim wps As Integer
Dim superfrmaddr As Long
Dim sfblock(8199) As Integer
Dim dacval As Integer
Dim j, jj As Integer

Private Sub CmdDown_Click()
    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If
    
    ' Decrement dacval
    dacval = dacval - 16
    If (dacval < DAC_LOW) Then
        dacval = DAC_LOW
    End If
    
    ' Temporaraly Stop the transmit channel
    Call BTI717_ChStop(xmtchan, hCore)
    
    ' Update the amplitude on the core
    ERRVAL = BTI717_ParamAmplitudeConfig(PARAMCFG717_DEFAULT, dacval, xmtchan, hCore)
    If (ERRVAL < 0) Then
        MsgBox "Error: can not update amplitude on core number #" & corenum
        bSkipRun = True
        BTICard_CardStop (hCore)
        Exit Sub
    End If
    
    ' Start the transmit channel
    Call BTI717_ChStart(xmtchan, hCore)
    
    ' Update text
    DacText.Caption = "Dac = " & dacval
    
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
    Call BTI717_SuperFrmCounterPos(1, wps, xmtchan, hCore)
    
    '  Configure word options. (Mark word 1 of SFs 1, 2, 3, and 4 for the Sequential Monitor)
    Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 1, 1, xmtchan, hCore)
    Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 2, 1, xmtchan, hCore)
    Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 3, 1, xmtchan, hCore)
    Call BTI717_SubFrmWordConfig(WRDCFG717_SEQ, 4, 1, xmtchan, hCore)
    
    '  (Mark the word at SPF 4 of our superframe word (word 10, SF 2) for the Sequential Monitor)
    Call BTI717_SuperFrmWordConfig(WRDCFG717_SEQ, 4, superfrmaddr, xmtchan, hCore)
    
    '
    '  Configure Parametrics on xmtchan
    '

    If (dacval > DAC_HIGH) Then
        dacval = DAC_HIGH
    ElseIf (dacval < DAC_LOW) Then
        dacval = DAC_LOW
    End If
    
    ERRVAL = BTI717_ParamAmplitudeConfig(PARAMCFG717_DEFAULT, dacval, xmtchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "the amplitude on channel #" & xmtchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Start operation of the card.
    ERRVAL = BTICard_CardStart(hCore)
    If (ERRVAL < 0) Then
        MsgBox "Error:  An error was encountered while starting the card"
        bSkipRun = True
        Exit Sub
    End If
    
    ' Update text
    DacText.Caption = "Dac = " & dacval
     
    bCardRunning = True
    cmdStart.Enabled = False
    cmdStop.Enabled = True
    CmdUp.Enabled = True
    CmdDown.Enabled = True
    
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
    CmdUp.Enabled = False
    CmdDown.Enabled = False
    
End Sub

Private Sub CmdUp_Click()
    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If
    
    ' Increment dacval
    dacval = dacval + 16
    If (dacval > DAC_HIGH) Then
        dacval = DAC_HIGH
    End If
    
    ' Temporaraly Stop the transmit channel
    Call BTI717_ChStop(xmtchan, hCore)
    
    ' Update the amplitude on the core
    ERRVAL = BTI717_ParamAmplitudeConfig(PARAMCFG717_DEFAULT, dacval, xmtchan, hCore)
    If (ERRVAL < 0) Then
        MsgBox "Error: can not update amplitude on core number #" & corenum
        bSkipRun = True
        BTICard_CardStop (hCore)
        Exit Sub
    End If
    
    ' Start the transmit channel
    Call BTI717_ChStart(xmtchan, hCore)
    
    ' Update text
    DacText.Caption = "Dac = " & dacval
    
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
    CmdUp.Enabled = False
    CmdDown.Enabled = False
    
    ' Init the words-per-second
    wps = 128
    
    ' Open handle to card with specified card number
    ERRVAL = BTICard_CardOpen(hCard, cardnum)
    If (ERRVAL) Then
        MsgBox "Error: can not open card number " & CStr(cardnum)
        bSkipRun = True
        Exit Sub
    End If
    
    '  Find the first ARINC 717 core with a BiPhase transmit channel that supports parametrics.
    For corenum = 0 To (MAX_CORES - 1)
        ERRVAL = BTICard_CoreOpen(hCore, corenum, hCard)
        If ERRVAL = 0 Then
            For xmtchan = 0 To (MAX_CHANNELS - 1)
                If BTI717_ChIsType(CHCFG717_BIPHASEXMT, xmtchan, hCore) Then
                    If BTI717_ChGetInfo(INFO717_PARAM, xmtchan, hCore) Then
                        Exit For
                    End If
                End If
            Next
            
            If (corenum < MAX_CORES) And (xmtchan < MAX_CHANNELS) Then
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
    Transmit.Caption = "Using BiPhase parametric transmit channel #" & xmtchan
    
    'Set flag so we run hardware
    bSkipRun = False
    
    cmdStart.Enabled = True
    cmdStop.Enabled = False
    
    Exit Sub
Errhandler:
        MsgBox "An Error Has Occured:  " & Err.Description

End Sub



