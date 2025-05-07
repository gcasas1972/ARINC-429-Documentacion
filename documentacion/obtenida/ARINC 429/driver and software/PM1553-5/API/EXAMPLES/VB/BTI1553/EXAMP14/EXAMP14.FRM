VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI1553 Example 14"
   ClientHeight    =   6015
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   11070
   LinkTopic       =   "Form1"
   ScaleHeight     =   6015
   ScaleWidth      =   11070
   StartUpPosition =   3  'Windows Default
   Begin VB.ListBox List1 
      BackColor       =   &H80000016&
      Height          =   1620
      Left            =   120
      TabIndex        =   6
      Top             =   1695
      Width           =   5295
   End
   Begin VB.ListBox List2 
      BackColor       =   &H80000016&
      Height          =   1620
      Left            =   120
      TabIndex        =   5
      Top             =   3720
      Width           =   5295
   End
   Begin VB.ListBox List3 
      BackColor       =   &H80000016&
      Height          =   1620
      Left            =   5640
      TabIndex        =   4
      Top             =   1695
      Width           =   5295
   End
   Begin VB.ListBox List4 
      BackColor       =   &H80000016&
      Height          =   1620
      Left            =   5640
      TabIndex        =   3
      Top             =   3720
      Width           =   5295
   End
   Begin VB.Timer Timer1 
      Interval        =   100
      Left            =   1920
      Top             =   5520
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   10200
      TabIndex        =   2
      Top             =   5535
      Width           =   735
   End
   Begin VB.CommandButton cmdStop 
      Caption         =   "Stop"
      Enabled         =   0   'False
      Height          =   375
      Left            =   960
      TabIndex        =   1
      Top             =   5535
      Width           =   735
   End
   Begin VB.CommandButton cmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   0
      Top             =   5535
      Width           =   735
   End
   Begin VB.Label Header1a 
      Caption         =   "Monitor all busses"
      Height          =   255
      Left            =   120
      TabIndex        =   17
      Top             =   480
      Width           =   2415
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
      TabIndex        =   16
      Top             =   135
      Width           =   2415
   End
   Begin VB.Label Label2 
      Caption         =   "Core A"
      Height          =   255
      Left            =   120
      TabIndex        =   15
      Top             =   1455
      Width           =   975
   End
   Begin VB.Label Label3 
      Caption         =   "Core B"
      Height          =   255
      Left            =   120
      TabIndex        =   14
      Top             =   3480
      Width           =   975
   End
   Begin VB.Label Label4 
      Caption         =   "Core C"
      Height          =   255
      Left            =   5640
      TabIndex        =   13
      Top             =   1455
      Width           =   975
   End
   Begin VB.Label Label5 
      Caption         =   "Core D"
      Height          =   255
      Left            =   5640
      TabIndex        =   12
      Top             =   3480
      Width           =   975
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP14     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   3420
      TabIndex        =   11
      Top             =   120
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   3420
      TabIndex        =   10
      Top             =   600
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   3420
      TabIndex        =   9
      Top             =   840
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   3420
      TabIndex        =   8
      Top             =   1080
      Width           =   4335
   End
   Begin VB.Label Label1 
      Caption         =   "Copyright 2003-2011"
      Height          =   255
      Left            =   3420
      TabIndex        =   7
      Top             =   360
      Width           =   4335
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI1553 DRIVER VB_EXAMPLE 14  (06/07/2011)
'  Copyright (c) 2003-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP14 -- Multi Core - Monitor all busses (channels) on all cores
'

Option Explicit

' Constants
Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16

' Card/Program specific
Dim hCard As Long
Dim hCores(MAX_CORES - 1) As Long
Dim bCores(MAX_CORES - 1) As Boolean
Dim bSkipRun As Boolean
Dim bCardRunning As Boolean
Dim errval As Long
Dim errstr As String
Dim corenum As Long
Dim chan As Long
Dim corecount As Integer
Dim seqbuf(2047) As Integer
Dim seqcount As Long
Dim blkcnt As Long
Dim pRec1553 As SEQRECORD1553
Dim sfinfo As SEQFINDINFO
Dim recstr As String

Private Sub cmdExit_Click()
    If (hCard >= 0) Then
        errval = BTICard_CardClose(hCard)
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
    '  Configure the sequential record on each 1553 core
    '  Configure all 1553 channels for monitor mode.
    '
    
    For corenum = 0 To (MAX_CORES - 1)
        If bCores(corenum) Then
            BTICard_CardReset (hCores(corenum))
            
            ' Configure the sequential record on each core for fill and halt mode (default).
            errval = BTICard_SeqConfig(SEQCFG_DEFAULT, hCores(corenum))
            If (errval < 0) Then
                errstr = "Error:  An error was encounted while configuring" & vbNewLine
                errstr = errstr & "the sequential record on core #" & corenum
                MsgBox errstr
                bSkipRun = True
                Exit Sub
            End If

            ' Configure each MIL-STD-1553 channel to monitor
            For chan = 0 To (MAX_CHANNELS - 1)
                If BTI1553_ChIs1553(chan, hCores(corenum)) Then
                    errval = BTI1553_MonConfig(MONCFG1553_DEFAULT, chan, hCores(corenum)) ' Configure channel
                    If (errval < 0) Then
                        errstr = "Error:  An error was encountered while configuring" & vbNewLine
                        errstr = errstr & "channel #" & chan & " on core #" & corenum
                        MsgBox errstr
                        bSkipRun = True
                        Exit Sub
                    End If
                End If
            Next
             
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
    
    ' Initialize handle to error condition and bSkipRun
    hCard = -1
    bSkipRun = False
    bCardRunning = False
    cmdStart.Enabled = False
    cmdStop.Enabled = False
    
    ' Initialize the core handles and flags
    For corenum = 0 To (MAX_CORES - 1)
        hCores(corenum) = -1
        bCores(corenum) = False
    Next
    
    ' Open handle to card with specified card number
    errval = BTICard_CardOpen(hCard, cardnum)
    If (errval) Then
        MsgBox "Error: can not open card number " & CStr(cardnum)
        bSkipRun = True
        Exit Sub
    End If
    
    ' Find all MIL-STD-1553 cores on the board
    corecount = 0
    For corenum = 0 To (MAX_CORES - 1)
        errval = BTICard_CoreOpen(hCores(corenum), corenum, hCard)
        If errval = 0 Then
            For chan = 0 To (MAX_CHANNELS - 1)
                If BTI1553_ChIs1553(chan, hCores(corenum)) Then
                    Exit For
                End If
            Next
            If (chan <> MAX_CHANNELS) Then
                bCores(corenum) = True
                corecount = corecount + 1
            End If
        End If
    Next
    
    If corecount = 0 Then
        MsgBox "Error:    Unable to find any MIL-STD-1553 cores on card #" & CStr(cardnum)
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
                errval = BTICard_SeqFindInit(seqbuf(0), seqcount, sfinfo)
                If (0 > errval) Then
                    MsgBox "Error: SeqFindInit failed"
                    bSkipRun = True
                    Exit Sub
                End If
                
                ' Add each 1553Record in SeqBuf to List
                While (0 <= BTICard_SeqFindNext1553Ex(pRec1553, LenB(pRec1553), sfinfo))
                
                    ' Format the output string
                    recstr = "Ch:" & CStr(ShiftRight(pRec1553.activity And MSGACT1553_CHMASK, MSGACT1553_CHSHIFT))
                    recstr = recstr & " Time:" & CStr(pRec1553.timestamp)
                    If pRec1553.activity And MSGACT1553_RCVCWD1 Then
                        recstr = recstr & " Cwd1:" & CStr(pRec1553.cwd1)
                    End If
                    If pRec1553.activity And MSGACT1553_RCVCWD2 Then
                        recstr = recstr & " Cwd2:" & CStr(pRec1553.cwd2)
                    End If
                    If pRec1553.activity And MSGACT1553_RCVSWD1 Then
                        recstr = recstr & " Swd1:" & CStr(pRec1553.swd1)
                    End If
                    If pRec1553.activity And MSGACT1553_RCVSWD2 Then
                        recstr = recstr & " Swd2:" & CStr(pRec1553.swd2)
                    End If
                    If pRec1553.errorval And MSGERR1553_NORESP Then
                        recstr = recstr & " No response!"
                    End If
                    If pRec1553.errorval And MSGERR1553_ANYERR Then
                        recstr = recstr & " Error!"
                    End If
                    
                    ' Print output in correct core list
                    If corenum = 0 Then
                        List1.AddItem recstr
                    ElseIf corenum = 1 Then
                        List2.AddItem recstr
                    ElseIf corenum = 2 Then
                        List3.AddItem recstr
                    ElseIf corenum = 3 Then
                        List4.AddItem recstr
                    End If
                Wend
            End If
            
        End If
    Next
    
End Sub




