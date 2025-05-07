VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "COMDLG32.OCX"
Begin VB.Form Form1 
   Caption         =   "BTI429 Example 7"
   ClientHeight    =   3990
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   7695
   LinkTopic       =   "Form1"
   ScaleHeight     =   3990
   ScaleWidth      =   7695
   StartUpPosition =   3  'Windows Default
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   7080
      Top             =   2880
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.TextBox fileName 
      BackColor       =   &H80000004&
      Height          =   375
      Left            =   1080
      TabIndex        =   5
      Text            =   "EXAMP7.DAT"
      Top             =   2040
      Width           =   5895
   End
   Begin VB.CommandButton cmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   4
      Top             =   3480
      Width           =   735
   End
   Begin VB.CommandButton cmdStop 
      Caption         =   "Stop"
      Enabled         =   0   'False
      Height          =   375
      Left            =   960
      TabIndex        =   3
      Top             =   3480
      Width           =   735
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   6840
      TabIndex        =   2
      Top             =   3480
      Width           =   735
   End
   Begin VB.TextBox labelNum 
      BeginProperty DataFormat 
         Type            =   1
         Format          =   "0"
         HaveTrueFalseNull=   0
         FirstDayOfWeek  =   0
         FirstWeekOfYear =   0
         LCID            =   1033
         SubFormatType   =   1
      EndProperty
      Height          =   285
      Left            =   1080
      MaxLength       =   3
      TabIndex        =   1
      Text            =   "172"
      Top             =   2520
      Width           =   375
   End
   Begin VB.CommandButton CmdBrouse 
      Caption         =   "..."
      Height          =   375
      Left            =   7080
      TabIndex        =   0
      Top             =   2040
      Width           =   495
   End
   Begin VB.Label Label4 
      Caption         =   "Copyright 2002-2011"
      Height          =   255
      Left            =   2280
      TabIndex        =   18
      Top             =   840
      Width           =   4335
   End
   Begin VB.Label Header5 
      Caption         =   "www.ballardtech.com or email support@ballardtech.com"
      Height          =   255
      Index           =   0
      Left            =   2280
      TabIndex        =   17
      Top             =   1560
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   2280
      TabIndex        =   16
      Top             =   1320
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   2280
      TabIndex        =   15
      Top             =   1080
      Width           =   4335
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP7     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   2280
      TabIndex        =   14
      Top             =   600
      Width           =   4335
   End
   Begin VB.Label Core 
      Caption         =   "Core:"
      Height          =   255
      Left            =   120
      TabIndex        =   13
      Top             =   2880
      Width           =   2175
   End
   Begin VB.Label Transmit 
      Caption         =   "Transmit:"
      Height          =   255
      Left            =   120
      TabIndex        =   12
      Top             =   3120
      Width           =   2175
   End
   Begin VB.Label status1 
      Caption         =   "Status:"
      Height          =   375
      Left            =   2280
      TabIndex        =   11
      Top             =   2880
      Width           =   3855
   End
   Begin VB.Label status2 
      Caption         =   "Status:"
      Height          =   375
      Left            =   2880
      TabIndex        =   10
      Top             =   3240
      Width           =   3255
   End
   Begin VB.Label Label1 
      Caption         =   "File Name:"
      Height          =   255
      Left            =   120
      TabIndex        =   9
      Top             =   2160
      Width           =   855
   End
   Begin VB.Label Label2 
      Caption         =   "Label (oct):"
      Height          =   285
      Left            =   120
      TabIndex        =   8
      Top             =   2520
      Width           =   855
   End
   Begin VB.Label Label3 
      Caption         =   "Warning: Program may take a few minutes to load card."
      Height          =   375
      Left            =   2280
      TabIndex        =   7
      Top             =   2520
      Width           =   4095
   End
   Begin VB.Label Header1 
      Caption         =   "FileTransfer Example"
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
      Left            =   2700
      TabIndex        =   6
      Top             =   120
      Width           =   2295
   End
   Begin VB.Line Line1 
      X1              =   120
      X2              =   7440
      Y1              =   480
      Y2              =   480
   End
   Begin VB.Line Line2 
      X1              =   120
      X2              =   7440
      Y1              =   1920
      Y2              =   1920
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI429 DRIVER VB_EXAMPLE 7  (06/07/2011)
'  Copyright (c) 2002-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP7 -- File transfer example
'
'  This program opens Card Number 0, finds the first
'  compatible core, and configures an asynchronous transmit
'  list buffer.  The program reads a data file and transmits
'  that data with a user specified label.  If no data file
'  or label is specifed by the user the default values are
'  examp7.dat, and label 0172.
'

Option Explicit

Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16

Dim bCardRunning As Boolean
Dim bSkipRun As Boolean
Dim hCard As Long
Dim hCore As Long
Dim corenum As Long
Dim ERRVAL As Long
Dim errstr As String
Dim xmtchan As Long
Dim fileNum As Integer
Dim asynclistaddr As Long
Dim Data As Long

Private Sub CmdBrouse_Click()
    On Error GoTo ErrHandler
    
    CommonDialog1.Filter = "Data Files (*.DAT)|*.DAT"   ' Set Filters
    CommonDialog1.FilterIndex = 1                       ' Specify default filter
    CommonDialog1.InitDir = App.Path                    ' Specify initial path
    CommonDialog1.ShowOpen                              ' Display the Open dialog box
    
    ' Update fileName text
    fileName.Text = CommonDialog1.fileName
    
    Exit Sub
ErrHandler:
    ' User pressed Cancel button
    Exit Sub
End Sub

Private Sub cmdExit_Click()
    If (hCard >= 0) Then
        ERRVAL = BTICard_CardClose(hCard)
    End If
    
    ' Close I/O file
    Close #fileNum
      
    ' End Program
    End
    
End Sub

Private Sub cmdStart_Click()
    On Error GoTo ErrHandler
    
    If (bSkipRun = True) Then
        Exit Sub
    End If
    
    ' Attempt to open the user specified file
    fileNum = FreeFile()
    Dim Result
    Result = GetAttr(fileName.Text)
    Open fileName.Text For Binary Access Read As #fileNum
    
    ' Read in labelNum and test
    Dim lblNum As Integer
    lblNum = val("&O" & LTrim(labelNum.Text))
    
    If (lblNum < 0) Or (lblNum > 255) Then
        ' Use default lable number
        MsgBox "Error: Using label 0172. User label out of range: " & Oct(lblNum)
        lblNum = &O172
    End If
    
    ' Updata the status text
    status1.Caption = "Status: Initializing the card"
    status2.Caption = ""
    
    ' Configure xmtchan to transmit at low speed.
    BTICard_CardReset (hCore)
    ERRVAL = BTI429_ChConfig(CHCFG429_DEFAULT, xmtchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring " & vbNewLine
        errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Create the asynchronous list buffer
    asynclistaddr = BTI429_ListAsyncCreate(LISTCRT429_FIFO, 8192, xmtchan, hCore)
    If (asynclistaddr = 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "the list buffer on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    '  Next, a schedule is built by creating explicit message timing.
    '  While creating a schedule we can still use the SchedGap() funciton
    '  to create our gap times.  This function will determine that an
    '  asynchronous list buffer has been created for the channel, and will
    '  internally call the SchedGapList() function with appropriate parameters.
    '  Alternatively, we could use the SchedGapList() function directly
    '  and specify the address value ourselves. This method is usefull if
    '  more than one asynchronoous list buffer is desired per channel.

    Call BTI429_SchedGap(1024, xmtchan, hCore)
    
    ' Start operation of the card.
    ERRVAL = BTICard_CardStart(hCore)
    If (ERRVAL < 0) Then
        MsgBox "Error:  An error was encountered while starting core #" & corenum
        bSkipRun = True
        Exit Sub
    End If
    
    bCardRunning = True
    cmdStart.Enabled = False
    cmdStop.Enabled = True
    
    ' Updata the status text
    status1.Caption = "Status: Loading data on to the card."
    status2.Caption = ""
    
    ' Read data from file and transmit unill end of file or the stop is pressed
    Dim bSuccess As Boolean
    Dim mask As Integer
    
    Do While Not EOF(fileNum)
        ' Read from file
        Get #1, , Data
        ' Mask value
        mask = lblNum And &HFF
        'data = data And &HFFFFFF00
        Data = Data Or mask
        ' Write to card
        bSuccess = False
        While (False = bSuccess)
            bSuccess = BTI429_ListDataWr(Data, asynclistaddr, hCore)
        Wend
    Loop
    
    ' Update the status text
    status1.Caption = "Status: Finished loading data on to the card."
    status2.Caption = "Card may still be transmitting."
    
    ' Close I/O file
    Close #fileNum
    
     Exit Sub
ErrHandler:
        MsgBox "An Error Has Occured:  " & Err.Description
    
End Sub


Private Sub cmdStop_Click()
    'Clear state of bRunning before card is stopped (so timer event is not processed)
    Dim bTemp As Boolean
    bTemp = bCardRunning
    bCardRunning = False
        
    If (bTemp = True) Then
        BTICard_CardStop (hCore)
    End If
    
    ' Close I/O file
    Close #fileNum
    
    ' Update the status text
    status1.Caption = "Status: Card stopped."
    status2.Caption = ""
    
    cmdStart.Enabled = True
    cmdStop.Enabled = False
    
End Sub

Private Sub Form_Load()
    On Error GoTo ErrHandler
    
    'Initialize handle to error condition and bSkipRun
    hCard = -1
    hCore = -1
    bSkipRun = False
    bCardRunning = False
    cmdStart.Enabled = False
    cmdStop.Enabled = False
    
    ' Open handle to card with specified card number
    ERRVAL = BTICard_CardOpen(hCard, cardnum)
    If (ERRVAL) Then
        MsgBox "Error: Unable to open card number " & CStr(cardnum)
        bSkipRun = True
        Exit Sub
    End If
    
    ' Find the first 429 core with a transmit channel
    For corenum = 0 To MAX_CORES - 1
        ERRVAL = BTICard_CoreOpen(hCore, corenum, hCard)
        If ERRVAL = 0 Then
            For xmtchan = 0 To MAX_CHANNELS - 1
                If BTI429_ChIsXmt(xmtchan, hCore) Then
                   Exit For
                End If
            Next
            If xmtchan < MAX_CHANNELS Then
                Exit For
            End If
        End If
    Next
    
    If (ERRVAL <> 0) Or (corenum >= MAX_CORES) Or (xmtchan >= MAX_CHANNELS) Then
        MsgBox "Error:  No compatible ARINC 429 core present in card #" & cardnum
        bSkipRun = True
        Exit Sub
    End If
    
    Core.Caption = "Using core #" & corenum
    Transmit.Caption = "Using transmit channel #" & xmtchan
    
    'Set flag so we run hardware
    bSkipRun = False
    
    cmdStart.Enabled = True
    cmdStop.Enabled = False
    
    ' Update the status text
    status1.Caption = "Status: Card stopped."
    status2.Caption = ""
    
    ' Set the default name in fileName and set to ReadOnly
    fileName.Text = App.Path & "\EXAMP7.DAT"
    fileName.Locked = True
    
    Exit Sub
ErrHandler:
        MsgBox "An Error Has Occured:  " & Err.Description

End Sub

Private Sub labelNum_KeyPress(KeyAscii As Integer)
    ' Only accept octal digits and the backspace characters
    If KeyAscii = 8 Then    ' Backspace character
        Exit Sub
    End If
    If KeyAscii < Asc("0") Or KeyAscii > Asc("7") Then
        KeyAscii = 0        ' Cancel the character
        Beep                ' Sound error signal
    End If
End Sub

