VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI429 Example 10"
   ClientHeight    =   6015
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   11175
   LinkTopic       =   "Form1"
   ScaleHeight     =   6015
   ScaleWidth      =   11175
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   7
      Top             =   5520
      Width           =   735
   End
   Begin VB.CommandButton cmdStop 
      Caption         =   "Stop"
      Enabled         =   0   'False
      Height          =   375
      Left            =   960
      TabIndex        =   6
      Top             =   5520
      Width           =   735
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   10320
      TabIndex        =   5
      Top             =   5520
      Width           =   735
   End
   Begin VB.Timer Timer1 
      Interval        =   500
      Left            =   1920
      Top             =   5520
   End
   Begin VB.ListBox List4 
      BackColor       =   &H80000016&
      Height          =   3765
      Left            =   8400
      TabIndex        =   4
      Top             =   1680
      Width           =   2655
   End
   Begin VB.ListBox List3 
      BackColor       =   &H80000016&
      Height          =   3765
      Left            =   5640
      TabIndex        =   3
      Top             =   1680
      Width           =   2655
   End
   Begin VB.ListBox List2 
      BackColor       =   &H80000016&
      Height          =   3765
      Left            =   2880
      TabIndex        =   2
      Top             =   1680
      Width           =   2655
   End
   Begin VB.ListBox List1 
      BackColor       =   &H80000016&
      Height          =   3765
      Left            =   120
      TabIndex        =   1
      Top             =   1680
      Width           =   2655
   End
   Begin VB.Label Label1 
      Caption         =   "Copyright 2003-2011"
      Height          =   255
      Left            =   3420
      TabIndex        =   16
      Top             =   345
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   3420
      TabIndex        =   15
      Top             =   1065
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   3420
      TabIndex        =   14
      Top             =   825
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   3420
      TabIndex        =   13
      Top             =   585
      Width           =   4335
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP10     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   3420
      TabIndex        =   12
      Top             =   105
      Width           =   4335
   End
   Begin VB.Label Label5 
      Caption         =   "Core #3"
      Height          =   255
      Left            =   8400
      TabIndex        =   11
      Top             =   1440
      Width           =   975
   End
   Begin VB.Label Label4 
      Caption         =   "Core #2"
      Height          =   255
      Left            =   5640
      TabIndex        =   10
      Top             =   1440
      Width           =   975
   End
   Begin VB.Label Label3 
      Caption         =   "Core #1"
      Height          =   255
      Left            =   2880
      TabIndex        =   9
      Top             =   1440
      Width           =   975
   End
   Begin VB.Label Label2 
      Caption         =   "Core #0"
      Height          =   255
      Left            =   120
      TabIndex        =   8
      Top             =   1440
      Width           =   975
   End
   Begin VB.Label Header1 
      Caption         =   "Multiple Core Example"
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
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   2415
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI429 DRIVER VB_EXAMPLE 10  (06/07/2011)
'  Copyright (c) 2003-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP10 -- Multiple Core Example
'
'  This program opens Card Number 0 and configures all
'  ARINC 429 cores to transmit, receive, and monitor.
'  All transmit channels and all receive channels are
'  used.It also enables the sequential monitor to record
'  transmitted and received messages.
'

Option Explicit

Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16

Dim bCardRunning As Boolean
Dim bSkipRun As Boolean
Dim hCard As Long
Dim hCores(MAX_CORES - 1) As Long
Dim bCores(MAX_CORES - 1) As Boolean
Dim ERRVAL As Long
Dim errstr As String
Dim corenum As Long
Dim chan As Long
Dim corecount As Integer
Dim seqbuf(2047) As Integer
Dim seqcount As Long
Dim blkcnt As Long
Dim pRec429 As SEQRECORD429
Dim sfinfo As SEQFINDINFO

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
    
    '  Clear all lists
    List1.Clear
    List2.Clear
    List3.Clear
    List4.Clear
    
    '
    '  Configure all transmit channels on all cores to transmit at low speed.
    '  Configure all receive channels on all cores for auto speed detection.
    '  Configure each cores sequential record.
    '
    
    For corenum = 0 To (MAX_CORES - 1)
        If bCores(corenum) Then
            BTICard_CardReset (hCores(corenum))
            
            For chan = 0 To (MAX_CHANNELS - 1)
                If BTI429_ChIsXmt(chan, hCores(corenum)) Then
                    ERRVAL = BTI429_ChConfig(CHCFG429_SEQALL, chan, hCores(corenum)) ' Configure channel
                    If (ERRVAL < 0) Then
                        errstr = "Error:  An error was encountered while configuring" & vbNewLine
                        errstr = errstr & "transmit channel #" & chan & " on core #" & corenum
                        MsgBox errstr
                        bSkipRun = True
                        Exit Sub
                    End If
    
                    Dim xmt_airspeed As MSGSTRUCT429
    
                    ' Create a message for each of the synchronous labels we are transmitting.
                    xmt_airspeed.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCores(corenum))
    
                    ' Schedule the message
                    Call BTI429_SchedMsg(xmt_airspeed.addr, chan, hCores(corenum))
                    Call BTI429_SchedGap(1218, chan, hCores(corenum))
    
                    ' Initialize the Message Record.
                    xmt_airspeed.Data = BTI429_FldPutLabel(0, &O206)   ' Init label field
                    Call BTI429_MsgDataWr(xmt_airspeed.Data, xmt_airspeed.addr, hCores(corenum))

                ElseIf BTI429_ChIsRcv(chan, hCores(corenum)) Then
                    ERRVAL = BTI429_ChConfig(CHCFG429_AUTOSPEED, chan, hCores(corenum))  ' Configure channel
                    If (ERRVAL < 0) Then
                        errstr = "Error:  An error was encountered while configuring" & vbNewLine
                        errstr = errstr & "receive channel #" & chan & " on core #" & corenum
                        MsgBox errstr
                        bSkipRun = True
                        Exit Sub
                    End If
    
                    ' Create a default filter
                    Call BTI429_FilterDefault(MSGCRT429_DEFAULT, chan, hCores(corenum))
                    
                End If
                
            Next
            
            '
            ' Configure the sequential record on each core for fill and halt mode (default).
            '
            
            ERRVAL = BTICard_SeqConfig(SEQCFG_DEFAULT, hCores(corenum))
            If (ERRVAL < 0) Then
                errstr = "Error:  An error was encounted while configuring" & vbNewLine
                errstr = errstr & "the sequential record on core #" & corenum
                MsgBox errstr
                bSkipRun = True
                Exit Sub
            End If
            
        End If
    Next
    
    '
    ' Start operation of the card.
    '
    
    For corenum = 0 To (MAX_CORES - 1)
        If bCores(corenum) Then
            BTICard_CardStart (hCores(corenum))
        End If
    Next
     
    bCardRunning = True
    cmdStart.Enabled = False
    cmdStop.Enabled = True
    
End Sub

Private Sub cmdStop_Click()
    bCardRunning = False
        
    For corenum = 0 To (MAX_CORES - 1)
        BTICard_CardStart (hCores(corenum))
    Next
    
    cmdStart.Enabled = True
    cmdStop.Enabled = False
    
End Sub

Private Sub Form_Load()
    On Error GoTo Errhandler
    
    'Initialize handle to error condition and bSkipRun
    hCard = -1
    bSkipRun = False
    bCardRunning = False
    cmdStart.Enabled = False
    cmdStop.Enabled = False
    
    For corenum = 0 To (MAX_CORES - 1)
        hCores(corenum) = -1
        bCores(corenum) = False
    Next
    
    ' Open handle to card with specified card number
    ERRVAL = BTICard_CardOpen(hCard, cardnum)
    If (ERRVAL) Then
        MsgBox "Error: can not open card number " & CStr(cardnum)
        bSkipRun = True
        Exit Sub
    End If
    
    ' Find all ARINC 429 cores on the board
    corecount = 0
    For corenum = 0 To (MAX_CORES - 1)
        Dim hCore As Long
        Dim chan As Long
        ERRVAL = BTICard_CoreOpen(hCore, corenum, hCard)
        If ERRVAL = 0 Then
            For chan = 0 To (MAX_CHANNELS - 1)
                If BTI429_ChIsXmt(chan, hCore) Or BTI429_ChIsRcv(chan, hCore) Then
                    Exit For
                End If
            Next
            If (chan <> MAX_CHANNELS) Then
                hCores(corenum) = hCore
                bCores(corenum) = True
                corecount = corecount + 1
            End If
        End If
    Next
    
    If corecount = 0 Then
        MsgBox "Error:    Unable to find any ARINC 429 cores on card #" & cardnum
        bSkipRun = True
        Exit Sub
    End If
    
    ' Init output list 1
    List1.Clear
    If bCores(0) Then
        List1.BackColor = &H80000005
    End If
    
    ' Init output list 2
    List2.Clear
    If bCores(1) Then
        List2.BackColor = &H80000005
    End If
    
    ' Init output list 3
    List3.Clear
    If bCores(2) Then
        List3.BackColor = &H80000005
    End If
    
    ' Init output list 4
    List4.Clear
    If bCores(3) Then
        List4.BackColor = &H80000005
    End If
    
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
    ' Write data to lists
    '
    
    For corenum = 0 To (MAX_CORES - 1)
        If bCores(corenum) Then
            seqcount = BTICard_SeqBlkRd(seqbuf(0), 2047, blkcnt, hCores(corenum))
            
            If (seqcount > 0) Then
                ERRVAL = BTICard_SeqFindInit(seqbuf(0), seqcount, sfinfo)
                If (0 > ERRVAL) Then
                    MsgBox "Error: SeqFindInit failed"
                    bSkipRun = True
                    Exit Sub
                End If
                
                ' Add each 429Record in SeqBuf to List
                While (0 <= BTICard_SeqFindNext429Ex(pRec429, LenB(pRec429), sfinfo))
                    If corenum = 0 Then
                        List1.AddItem "Data: " & Hex(pRec429.Data) & "     TimeTag: " & Hex(pRec429.timestamp)
                    ElseIf corenum = 1 Then
                        List2.AddItem "Data: " & Hex(pRec429.Data) & "     TimeTag: " & Hex(pRec429.timestamp)
                    ElseIf corenum = 2 Then
                        List3.AddItem "Data: " & Hex(pRec429.Data) & "     TimeTag: " & Hex(pRec429.timestamp)
                    ElseIf corenum = 3 Then
                        List4.AddItem "Data: " & Hex(pRec429.Data) & "     TimeTag: " & Hex(pRec429.timestamp)
                    End If
                Wend
            End If
            
        End If
    Next
    
End Sub



