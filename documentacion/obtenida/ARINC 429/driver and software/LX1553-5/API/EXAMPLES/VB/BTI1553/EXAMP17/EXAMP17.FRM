VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI1553 Example 17"
   ClientHeight    =   4530
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4695
   LinkTopic       =   "Form1"
   ScaleHeight     =   4530
   ScaleWidth      =   4695
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdStart 
      Caption         =   "Start"
      Height          =   375
      Left            =   120
      TabIndex        =   6
      Top             =   4020
      Width           =   735
   End
   Begin VB.CommandButton cmdStop 
      Caption         =   "Stop"
      Enabled         =   0   'False
      Height          =   375
      Left            =   960
      TabIndex        =   5
      Top             =   4020
      Width           =   735
   End
   Begin VB.CommandButton cmdExit 
      Caption         =   "Exit"
      Height          =   375
      Left            =   3840
      TabIndex        =   4
      Top             =   4020
      Width           =   735
   End
   Begin VB.CommandButton CmdDown 
      Height          =   615
      Left            =   1560
      Picture         =   "Examp17.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   3
      Top             =   3120
      Width           =   500
   End
   Begin VB.CommandButton CmdUp 
      Height          =   615
      Left            =   1560
      Picture         =   "Examp17.frx":0442
      Style           =   1  'Graphical
      TabIndex        =   2
      Top             =   2520
      Width           =   500
   End
   Begin VB.CommandButton CmdLeft 
      Height          =   500
      Left            =   2760
      Picture         =   "Examp17.frx":0884
      Style           =   1  'Graphical
      TabIndex        =   1
      Top             =   3240
      Width           =   615
   End
   Begin VB.CommandButton CmdRight 
      Height          =   500
      Left            =   3360
      Picture         =   "Examp17.frx":0CC6
      Style           =   1  'Graphical
      TabIndex        =   0
      Top             =   3240
      Width           =   615
   End
   Begin VB.Label Label1 
      Caption         =   "Copyright 2003-2011"
      Height          =   255
      Left            =   120
      TabIndex        =   18
      Top             =   705
      Width           =   4335
   End
   Begin VB.Label Core 
      Caption         =   "Core:"
      Height          =   255
      Left            =   960
      TabIndex        =   17
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
      TabIndex        =   16
      Top             =   1425
      Width           =   4335
   End
   Begin VB.Label Header4 
      Caption         =   "All rights reserved."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   15
      Top             =   1185
      Width           =   4335
   End
   Begin VB.Label Heade3 
      Caption         =   "Ballard Technology, Inc. Everett, WA, USA."
      Height          =   255
      Index           =   1
      Left            =   120
      TabIndex        =   14
      Top             =   945
      Width           =   4335
   End
   Begin VB.Label Header2 
      Caption         =   "VB_EXAMP17     (06/07/2011)"
      Height          =   255
      Index           =   0
      Left            =   120
      TabIndex        =   13
      Top             =   465
      Width           =   4335
   End
   Begin VB.Label Channel 
      Caption         =   "Channel (Parametric):"
      Height          =   255
      Left            =   960
      TabIndex        =   12
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
      TabIndex        =   11
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
      Left            =   120
      TabIndex        =   10
      Top             =   2520
      Width           =   855
   End
   Begin VB.Label Label3 
      Caption         =   "Mid-Bid Error Offset"
      Height          =   255
      Left            =   2400
      TabIndex        =   9
      Top             =   2520
      Width           =   1455
   End
   Begin VB.Label DacText 
      Caption         =   "Dac = "
      Height          =   255
      Left            =   120
      TabIndex        =   8
      Top             =   2760
      Width           =   1335
   End
   Begin VB.Label OffsetText 
      Caption         =   "Offset = "
      Height          =   255
      Left            =   2400
      TabIndex        =   7
      Top             =   2760
      Width           =   2055
   End
   Begin VB.Line Line4 
      X1              =   2160
      X2              =   2160
      Y1              =   2400
      Y2              =   3840
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'
'  BTI1553 DRIVER VB_EXAMPLE 17  (06/07/2011)
'  Copyright (c) 2003-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP17 -- Parametrics example
'
'  This example configures Card Number 0 as a bus controller
'  to transmit a schedule of three messages.  The schedule is
'  created in such a way that the messages are transmitted at
'  frequencies of 100Hz, 50Hz, and 25Hz (or every 10ms, 20ms,
'  and 40ms, respectively).
'
'  The program uses the up and down arrow buttons to control the
'  frequency output on the bus. The left and right arrow buttons
'  are used to control the offset associated with the mid-bit
'  crossing.
'

Option Explicit

Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16

Const CMD0 As Integer = &H843
Const CMD1 As Integer = &H821
Const RCV_CMD2 As Integer = &H821
Const XMT_CMD2 As Integer = &H1C21

Const frametime As Long = 10000

Const DAC_HIGH As Integer = &HFFF
Const DAC_LOW As Integer = &H599
Const OFFSET_HIGH As Integer = &H64
Const OFFSET_LOW As Integer = &H0

Dim bCardRunning As Boolean
Dim bSkipRun As Boolean
Dim hCard As Long
Dim hCore As Long
Dim errval As Long
Dim errstr As String
Dim corenum As Long
Dim channum As Long

Dim dacval As Integer
Dim offset As Integer
Dim BCMsgs(2) As Long
Dim data(2) As Integer

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
    Call BTI1553_ChStop(channum, hCore)
    
    ' Update the amplitude on the core
    errval = BTI1553_ParamAmplitudeConfig(PARAMCFG1553_DEFAULT, dacval, channum, hCore)
    If (errval < 0) Then
        MsgBox "Error: can not update amplitude on core number #" & corenum
        bSkipRun = True
        BTICard_CardStop (hCore)
        Exit Sub
    End If
    
    ' Start the transmit channel
    Call BTI1553_ChStart(channum, hCore)
    
    ' Update text
    DacText.Caption = "Dac = " & dacval
    
End Sub

Private Sub cmdExit_Click()
    If (hCard >= 0) Then
        errval = BTICard_CardClose(hCard)
    End If
      
    ' End Program
    End
    
End Sub

Private Sub CmdLeft_Click()
    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If
    
    ' Decrement bitrate
    offset = offset - 1
    If (offset < OFFSET_LOW) Then
        offset = OFFSET_LOW
    End If
    
    ' Temporaraly Stop the transmit channel
    Call BTI1553_ChStop(channum, hCore)
    
    ' Update the error on the bus
    errval = BTI1553_ErrorDefine(ERRDEF1553_ZEROX2, 0, offset, 0, 0, channum, hCore)
    If (errval < 0) Then
        errstr = "Error:  An error was encountered while defining" & vbNewLine
        errstr = errstr & "the error on channel #" & channum & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If

    ' Start the transmit channel
    Call BTI1553_ChStart(channum, hCore)
    
    ' Update text
    OffsetText.Caption = "Offset = " & offset
    
End Sub

Private Sub CmdRight_Click()
    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If
    
    ' Increment bitrate
    offset = offset + 1
    If (offset > OFFSET_HIGH) Then
        offset = OFFSET_HIGH
    End If
    
    ' Temporaraly Stop the transmit channel
    Call BTI1553_ChStop(channum, hCore)
    
    ' Update the error on the bus
    errval = BTI1553_ErrorDefine(ERRDEF1553_ZEROX2, 0, offset, 0, 0, channum, hCore)
    If (errval < 0) Then
        errstr = "Error:  An error was encountered while defining" & vbNewLine
        errstr = errstr & "the error on channel #" & channum & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If

    ' Start the transmit channel
    Call BTI1553_ChStart(channum, hCore)
    
    ' Update text
    OffsetText.Caption = "Offset = " & offset
    
End Sub

Private Sub cmdStart_Click()
    
    If (bSkipRun = True) Then
        Exit Sub
    End If

    BTICard_CardReset (hCore)
    
    ' Configure the channel for bus controller mode.
    errval = BTI1553_BCConfig(BCCFG1553_DEFAULT, channum, hCore)
    If (errval < 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "the BC on channel #" & channum & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Create the message records for each of the three messages.
    data(0) = 0
    data(1) = 0
    data(2) = 0

    BCMsgs(0) = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT, CMD0, 0, data(0), hCore)
    BCMsgs(1) = BTI1553_BCCreateMsg(MSGCRT1553_DEFAULT, CMD1, 0, 0, hCore)
    BCMsgs(2) = BTI1553_BCCreateMsg(MSGCRT1553_RTRT, RCV_CMD2, XMT_CMD2, 0, hCore)

   
    '  Schedule the messages to create the desired bus controller schedule.

    Call BTI1553_BCSchedFrame(frametime, channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(1), channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(2), channum, hCore)

    Call BTI1553_BCSchedFrame(frametime, channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)

    Call BTI1553_BCSchedFrame(frametime, channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(1), channum, hCore)

    Call BTI1553_BCSchedFrame(frametime, channum, hCore)
    Call BTI1553_BCSchedMsg(BCMsgs(0), channum, hCore)
 
    '  Configure Parametrics on channum
    If (dacval > DAC_HIGH) Then
        dacval = DAC_HIGH
    ElseIf (dacval < DAC_LOW) Then
        dacval = DAC_LOW
    End If
    
    errval = BTI1553_ParamAmplitudeConfig(PARAMCFG1553_DEFAULT, dacval, channum, hCore)
    If (errval < 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "the amplitude on channel #" & channum & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If

    '  Define the type of error generation.  One of the bus
    '  controller messages is tagged to generate errors.
    
    If (offset > OFFSET_HIGH) Then
        offset = OFFSET_HIGH
    ElseIf (offset < OFFSET_LOW) Then
        offset = OFFSET_LOW
    End If

    errval = BTI1553_ErrorDefine(ERRDEF1553_ZEROX2, 0, offset, 0, 0, channum, hCore)
    If (errval < 0) Then
        errstr = "Error:  An error was encountered while defining" & vbNewLine
        errstr = errstr & "the error on channel #" & channum & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If

    Call BTI1553_ErrorTagBC(True, BCMsgs(0), channum, hCore)
    Call BTI1553_ErrorCtrl(ERRCTRL1553_ON Or ERRCTRL1553_TAGMSG, channum, hCore)
    
    ' Start operation of the card.
    errval = BTICard_CardStart(hCore)
    If (errval < 0) Then
        MsgBox "Error:  An error was encountered while starting the card"
        bSkipRun = True
        Exit Sub
    End If
    
    ' Update text
    DacText.Caption = "Dac = " & dacval
    OffsetText.Caption = "Offset = " & offset
     
    bCardRunning = True
    cmdStart.Enabled = False
    cmdStop.Enabled = True
    CmdUp.Enabled = True
    CmdDown.Enabled = True
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
    CmdUp.Enabled = False
    CmdDown.Enabled = False
    CmdLeft.Enabled = False
    CmdRight.Enabled = False
    
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
    Call BTI1553_ChStop(channum, hCore)
    
    ' Update the amplitude on the core
    errval = BTI1553_ParamAmplitudeConfig(PARAMCFG1553_DEFAULT, dacval, channum, hCore)
    If (errval < 0) Then
        MsgBox "Error: can not update amplitude on core number #" & corenum
        bSkipRun = True
        BTICard_CardStop (hCore)
        Exit Sub
    End If
    
    ' Start the transmit channel
    Call BTI1553_ChStart(channum, hCore)
    
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
    CmdLeft.Enabled = False
    CmdRight.Enabled = False
    
    ' Open handle to card with specified card number
    errval = BTICard_CardOpen(hCard, cardnum)
    If (errval) Then
        MsgBox "Error: can not open card number " & CStr(cardnum)
        bSkipRun = True
        Exit Sub
    End If
    
    ' Find the first 1553 channel that supports parametrics.
    For corenum = 0 To (MAX_CORES - 1)
        errval = BTICard_CoreOpen(hCore, corenum, hCard)
        If errval = 0 Then
            For channum = 0 To (MAX_CHANNELS - 1)
                If BTI1553_ChIs1553(channum, hCore) Then
                    If BTI1553_ChGetInfo(INFO1553_PARAM, channum, hCore) Then
                        If BTI1553_ChGetInfo(INFO1553_ERRORGEN, channum, hCore) Then
                            Exit For
                        End If
                    End If
                End If
            Next
            If (corenum < MAX_CORES) And (channum < MAX_CHANNELS) Then
                Exit For
            End If
        End If
    Next
    
    If (hCore = 0) Or (corenum = MAX_CORES) Or (channum = MAX_CHANNELS) Then
        MsgBox "Error:  No compatible MIL-STD-1553 core present in card #" & cardnum
        bSkipRun = True
        Exit Sub
    End If

    Core.Caption = "Using core #" & corenum
    channel.Caption = "Using parametric channel #" & channum
    
    'Set flag so we run hardware
    bSkipRun = False
    
    cmdStart.Enabled = True
    cmdStop.Enabled = False
    
    Exit Sub
Errhandler:
        MsgBox "An Error Has Occured:  " & Err.Description

End Sub




