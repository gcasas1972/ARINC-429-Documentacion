VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI708 Example 6"
   ClientHeight    =   7080
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4800
   LinkTopic       =   "Form1"
   ScaleHeight     =   7080
   ScaleWidth      =   4800
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton CmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   3960
      TabIndex        =   17
      Top             =   6600
      Width           =   735
   End
   Begin VB.CommandButton CmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   16
      Top             =   6600
      Width           =   735
   End
   Begin VB.CommandButton CmdStop 
      Caption         =   "Stop"
      Height          =   375
      Left            =   960
      TabIndex        =   15
      Top             =   6600
      Width           =   735
   End
   Begin VB.Timer Timer1 
      Interval        =   10
      Left            =   2760
      Top             =   6600
   End
   Begin VB.TextBox label_hex 
      Height          =   285
      Left            =   1725
      TabIndex        =   14
      Text            =   "Text1"
      Top             =   3240
      Width           =   855
   End
   Begin VB.TextBox controlaccept 
      Height          =   285
      Left            =   1560
      TabIndex        =   13
      Text            =   "Text2"
      Top             =   4680
      Width           =   855
   End
   Begin VB.TextBox bits16to11 
      Height          =   285
      Left            =   3480
      TabIndex        =   12
      Text            =   "Text3"
      Top             =   4680
      Width           =   855
   End
   Begin VB.TextBox bits26to17 
      Height          =   285
      Left            =   3480
      TabIndex        =   11
      Text            =   "Text4"
      Top             =   5040
      Width           =   855
   End
   Begin VB.TextBox mode 
      Height          =   285
      Left            =   1560
      TabIndex        =   10
      Text            =   "Text5"
      Top             =   6120
      Width           =   855
   End
   Begin VB.TextBox tilt_hex 
      Height          =   285
      Left            =   1725
      TabIndex        =   9
      Text            =   "Text6"
      Top             =   3600
      Width           =   855
   End
   Begin VB.TextBox gain 
      Height          =   285
      Left            =   1560
      TabIndex        =   8
      Text            =   "Text7"
      Top             =   5760
      Width           =   855
   End
   Begin VB.TextBox range 
      Height          =   285
      Left            =   1560
      TabIndex        =   7
      Text            =   "Text8"
      Top             =   5400
      Width           =   855
   End
   Begin VB.TextBox bit49 
      Height          =   285
      Left            =   3480
      TabIndex        =   6
      Text            =   "Text9"
      Top             =   5400
      Width           =   855
   End
   Begin VB.TextBox dataaccept 
      Height          =   285
      Left            =   1560
      TabIndex        =   5
      Text            =   "Text10"
      Top             =   5040
      Width           =   855
   End
   Begin VB.TextBox scanangle_hex 
      Height          =   285
      Left            =   1725
      TabIndex        =   4
      Text            =   "Text11"
      Top             =   3960
      Width           =   855
   End
   Begin VB.TextBox bit64 
      Height          =   285
      Left            =   3480
      TabIndex        =   3
      Text            =   "Text12"
      Top             =   5760
      Width           =   855
   End
   Begin VB.TextBox label_oct 
      Height          =   285
      Left            =   2685
      TabIndex        =   2
      Text            =   "Text1"
      Top             =   3240
      Width           =   855
   End
   Begin VB.TextBox tilt_dec 
      Height          =   285
      Left            =   2685
      TabIndex        =   1
      Text            =   "Text1"
      Top             =   3600
      Width           =   855
   End
   Begin VB.TextBox scanangle_dec 
      Height          =   285
      Left            =   2685
      TabIndex        =   0
      Text            =   "Text1"
      Top             =   3960
      Width           =   855
   End
   Begin VB.Line Line2 
      X1              =   120
      X2              =   4560
      Y1              =   1875
      Y2              =   1875
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP6     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   38
      Top             =   600
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   37
      Top             =   1080
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   36
      Top             =   1320
      Width           =   4335
   End
   Begin VB.Label Header6 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   35
      Top             =   1560
      Width           =   4335
   End
   Begin VB.Line Line1 
      X1              =   120
      X2              =   4560
      Y1              =   480
      Y2              =   480
   End
   Begin VB.Label Header3 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Left            =   120
      TabIndex        =   34
      Top             =   840
      Width           =   4335
   End
   Begin VB.Label Header1 
      Caption         =   "Header Extraction Example"
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
      Left            =   893
      TabIndex        =   33
      Top             =   120
      Width           =   3015
   End
   Begin VB.Label Core 
      Caption         =   "Core"
      Height          =   255
      Left            =   375
      TabIndex        =   32
      Top             =   1920
      Width           =   4215
   End
   Begin VB.Label Result1 
      Caption         =   "Result1"
      Height          =   255
      Left            =   375
      TabIndex        =   31
      Top             =   2640
      Width           =   4215
   End
   Begin VB.Label ChanLbl 
      Caption         =   "ChanLbl"
      Height          =   255
      Left            =   375
      TabIndex        =   30
      Top             =   2280
      Width           =   4215
   End
   Begin VB.Label Label1 
      Alignment       =   1  'Right Justify
      Caption         =   "Label:"
      Height          =   255
      Left            =   1125
      TabIndex        =   29
      Top             =   3240
      Width           =   495
   End
   Begin VB.Label Label2 
      Alignment       =   1  'Right Justify
      Caption         =   "Control Accept:"
      Height          =   255
      Left            =   360
      TabIndex        =   28
      Top             =   4680
      Width           =   1095
   End
   Begin VB.Line Line3 
      X1              =   180
      X2              =   4620
      Y1              =   3000
      Y2              =   3000
   End
   Begin VB.Label label5 
      Alignment       =   1  'Right Justify
      Caption         =   "Mode:"
      Height          =   255
      Left            =   360
      TabIndex        =   27
      Top             =   6120
      Width           =   1095
   End
   Begin VB.Label Label6 
      Alignment       =   1  'Right Justify
      Caption         =   "Tilt:"
      Height          =   255
      Left            =   1245
      TabIndex        =   26
      Top             =   3600
      Width           =   375
   End
   Begin VB.Label Label7 
      Alignment       =   1  'Right Justify
      Caption         =   "Gain:"
      Height          =   255
      Left            =   360
      TabIndex        =   25
      Top             =   5760
      Width           =   1095
   End
   Begin VB.Label Label8 
      Alignment       =   1  'Right Justify
      Caption         =   "Range:"
      Height          =   255
      Left            =   360
      TabIndex        =   24
      Top             =   5400
      Width           =   1095
   End
   Begin VB.Label Label10 
      Alignment       =   1  'Right Justify
      Caption         =   "Data Accept:"
      Height          =   255
      Left            =   360
      TabIndex        =   23
      Top             =   5040
      Width           =   1095
   End
   Begin VB.Label Label11 
      Alignment       =   1  'Right Justify
      Caption         =   "Scan Angle:"
      Height          =   255
      Left            =   645
      TabIndex        =   22
      Top             =   3960
      Width           =   975
   End
   Begin VB.Label Label3 
      Alignment       =   1  'Right Justify
      Caption         =   "Bits 16-11:"
      Height          =   255
      Left            =   2520
      TabIndex        =   21
      Top             =   4680
      Width           =   855
   End
   Begin VB.Label label4 
      Alignment       =   1  'Right Justify
      Caption         =   "Bits 26-17:"
      Height          =   255
      Left            =   2520
      TabIndex        =   20
      Top             =   5040
      Width           =   855
   End
   Begin VB.Label Label9 
      Alignment       =   1  'Right Justify
      Caption         =   "Bit 49:"
      Height          =   255
      Left            =   2520
      TabIndex        =   19
      Top             =   5400
      Width           =   855
   End
   Begin VB.Label Label12 
      Alignment       =   1  'Right Justify
      Caption         =   "Bit 64:"
      Height          =   255
      Left            =   2520
      TabIndex        =   18
      Top             =   5760
      Width           =   855
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI708 DRIVER VB_EXAMPLE 6  (06/07/2011)
'  Copyright (c) 2002-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP6 -- Header extraction example
'
'  This program opens Card Number 0, and configures the
'  first compatible core to receive messages in a single
'  message record.  This message is automatically assigned
'  to message number 0.
'
'  An Event Log frequency of 0 is specifed, which will
'  not generate any Event Log List entries for this channel.
'
'  The program will display the ARINC 708 header information
'  from the message record, until the stop button is pressed.
'

Option Explicit

' Constants
Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16

' Card specific
Dim hCard As Long
Dim hCore As Long
Dim ERRVAL As Long
Dim errstr As String
Dim corenum As Long
Dim rcvchan As Long
Dim bSkipRun As Boolean
Dim bCardRunning As Boolean

Dim Data(99) As Integer

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
    
    BTICard_CardReset (hCore)
     
    ' Configure receive channel.
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
    Result1.Caption = "Card Running"
    
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
    On Error GoTo ErrHandler
    
    'Initialize handle to error condition and bSkipRun
    hCard = -1
    hCore = -1
    CmdStart.Enabled = False
    CmdStop.Enabled = False
    bSkipRun = False
    bCardRunning = False
    Result1.Caption = "Card Stopped"
    label_hex.Text = ""
    label_oct.Text = ""
    controlaccept.Text = ""
    bits16to11.Text = ""
    bits26to17.Text = ""
    mode.Text = ""
    tilt_hex.Text = ""
    tilt_dec.Text = ""
    gain.Text = ""
    range.Text = ""
    bit49.Text = ""
    dataaccept.Text = ""
    scanangle_hex.Text = ""
    scanangle_dec.Text = ""
    bit64.Text = ""
    
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
ErrHandler:
        MsgBox "An Error Has Occured:  " & Err.Description

End Sub

Private Sub Timer1_Timer()
    Dim str As String
    
    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If
    
    Call BTI708_MsgDataRd(Data(0), 0, rcvchan, hCore)
    
    label_hex.Text = Hex(BTI708_FieldGetLabel(Data(0))) & " (Hex)"
    label_oct.Text = Oct(BTI708_FieldGetLabel(Data(0))) & " (Oct)"
    controlaccept.Text = Hex(BTI708_FieldGetControlAccept(Data(0))) & " (Hex)"
    bits16to11.Text = Hex((Data(0) / 1024) And &H3F) & " (Hex)"
    bits26to17.Text = Hex(Data(1) And &H3FF) & " (Hex)"
    mode.Text = Hex(BTI708_FieldGetMode(Data(0))) & " (Hex)"
    tilt_hex.Text = Hex(BTI708_FieldGetTilt(Data(0))) & " (Hex)"
    tilt_dec.Text = BTI708_FieldGetTilt(Data(0)) & " (Dec)"
    gain.Text = BTI708_FieldGetGain(Data(0)) & " (Dec)"
    range.Text = BTI708_FieldGetRange(Data(0)) & " (Dec)"
    bit49.Text = Hex(Data(4) And &H1) & " (Hex)"
    dataaccept.Text = Hex(BTI708_FieldGetDataAccept(Data(0))) & " (Hex)"
    scanangle_hex.Text = Hex(BTI708_FieldGetAngle(Data(0))) & " (Hex)"
    scanangle_dec.Text = BTI708_FieldGetAngle(Data(0)) & " (Dec)"
    bit64.Text = Hex((Data(4) / 32768) And &H1) & " (Hex)"
    
End Sub

