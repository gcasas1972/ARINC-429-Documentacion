VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "BTI429 Example 11"
   ClientHeight    =   4545
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   4545
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton CmdRight 
      Height          =   500
      Left            =   3000
      Picture         =   "Examp11.frx":0000
      Style           =   1  'Graphical
      TabIndex        =   18
      Top             =   3240
      Width           =   615
   End
   Begin VB.CommandButton CmdLeft 
      Height          =   500
      Left            =   2400
      Picture         =   "Examp11.frx":0442
      Style           =   1  'Graphical
      TabIndex        =   17
      Top             =   3240
      Width           =   615
   End
   Begin VB.CommandButton CmdUp 
      Height          =   615
      Left            =   1560
      Picture         =   "Examp11.frx":0884
      Style           =   1  'Graphical
      TabIndex        =   16
      Top             =   2520
      Width           =   500
   End
   Begin VB.CommandButton CmdDown 
      Height          =   615
      Left            =   1560
      Picture         =   "Examp11.frx":0CC6
      Style           =   1  'Graphical
      TabIndex        =   15
      Top             =   3120
      Width           =   500
   End
   Begin VB.Timer Timer1 
      Interval        =   500
      Left            =   1920
      Top             =   4020
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
   Begin VB.Line Line4 
      X1              =   2160
      X2              =   2160
      Y1              =   2400
      Y2              =   3840
   End
   Begin VB.Label DivText 
      Caption         =   "Div ="
      Height          =   255
      Left            =   2400
      TabIndex        =   14
      Top             =   2760
      Width           =   2055
   End
   Begin VB.Label DacText 
      Caption         =   "Dac = "
      Height          =   255
      Left            =   120
      TabIndex        =   13
      Top             =   2760
      Width           =   1335
   End
   Begin VB.Label Label3 
      Caption         =   "Frequency:"
      Height          =   255
      Left            =   2400
      TabIndex        =   12
      Top             =   2520
      Width           =   975
   End
   Begin VB.Label Label2 
      Caption         =   "Amplitude:"
      Height          =   255
      Left            =   120
      TabIndex        =   11
      Top             =   2520
      Width           =   855
   End
   Begin VB.Line Line5 
      X1              =   120
      X2              =   4440
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
      Left            =   1193
      TabIndex        =   10
      Top             =   0
      Width           =   2295
   End
   Begin VB.Line Line2 
      X1              =   120
      X2              =   4560
      Y1              =   1740
      Y2              =   1740
   End
   Begin VB.Label Transmit 
      Caption         =   "Transmit (Parametric):"
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
'  BTI429 DRIVER VB_EXAMPLE 11  (06/07/2011)
'  Copyright (c) 2003-2011
'  Ballard Technology, Inc.
'  www.ballardtech.com
'  support@ballardtech.com
'  ALL RIGHTS RESERVED
'
'  NAME:   EXAMP11 -- Parametrics example
'
'  This program opens Card Number 0, and configures the
'  first transmit channel on the first 429 Core to build
'  a transmit schedule using transmit interval information.
'  The user can then control the amplitude using the UP and
'  DOWN arrow buttons and the frequency using the LEFT and RIGHT
'  arrow buttons.
'

Option Explicit

Const cardnum As Long = 0
Const MAX_CORES As Long = 4
Const MAX_CHANNELS As Long = 16

Const DAC_HIGH As Integer = &HFFF
Const DAC_LOW As Integer = &H599
Const DIV_HIGH As Integer = &HFF
Const DIV_LOW As Integer = &H0

Dim bCardRunning As Boolean
Dim bSkipRun As Boolean
Dim hCard As Long
Dim hCore As Long
Dim ERRVAL As Integer
Dim errstr As String
Dim corenum As Long
Dim xmtchan As Long
Dim comp_airspeed As MSGSTRUCT429
Dim tot_air_temp As MSGSTRUCT429
Dim altitude_rate As MSGSTRUCT429
Dim msgaddr(2) As Long
Dim min_intrvls(2) As Long
Dim max_intrvls(2) As Long
Dim bnr_data(2) As Long
Dim dacval As Integer
Dim divval As Integer

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
    Call BTI429_ChStop(xmtchan, hCore)
    
    ' Update the amplitude on the core
    ERRVAL = BTI429_ParamAmplitudeConfig(PARAMCFG429_DEFAULT, dacval, xmtchan, hCore)
    If (ERRVAL < 0) Then
        MsgBox "Error: can not update amplitude on core number #" & corenum
        bSkipRun = True
        BTICard_CardStop (hCore)
        Exit Sub
    End If
    
    ' Start the transmit channel
    Call BTI429_ChStart(xmtchan, hCore)
    
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

Private Sub CmdLeft_Click()
    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If
    
    ' Decrement bitrate
    divval = divval - 1
    If (divval < DIV_LOW) Then
        divval = DIV_LOW
    End If
    
    ' Temporaraly Stop the transmit channel
    Call BTI429_ChStop(xmtchan, hCore)
    
    ' Update the frequency on the core
    ERRVAL = BTI429_ParamBitRateConfig(PARAMCFG429_DEFAULT, divval, xmtchan, hCore)
    If (ERRVAL < 0) Then
        MsgBox "Error: can not update frequency on core number #" & corenum
        bSkipRun = True
        BTICard_CardStop (hCore)
        Exit Sub
    End If

    ' Start the transmit channel
    Call BTI429_ChStart(xmtchan, hCore)
    
    ' Update text
    DivText.Caption = "Div = " & divval
    
End Sub

Private Sub CmdRight_Click()
    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If
    
    ' Increment bitrate
    divval = divval + 1
    If (divval > DIV_HIGH) Then
        divval = DIV_HIGH
    End If
    
    ' Temporaraly Stop the transmit channel
    Call BTI429_ChStop(xmtchan, hCore)
    
    ' Update the frequency on the core
    ERRVAL = BTI429_ParamBitRateConfig(PARAMCFG429_DEFAULT, divval, xmtchan, hCore)
    If (ERRVAL < 0) Then
        MsgBox "Error: can not update frequency on core number #" & corenum
        bSkipRun = True
        BTICard_CardStop (hCore)
        Exit Sub
    End If
    
    ' Start the transmit channel
    Call BTI429_ChStart(xmtchan, hCore)
    
    ' Update text
    DivText.Caption = "Div = " & divval
    
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
    ERRVAL = BTI429_ChConfig(CHCFG429_HIGHSPEED, xmtchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "transmit channel #" & xmtchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    '
    '  Configure Parametrics on xmtchan
    '

    If (dacval > DAC_HIGH) Then
        dacval = DAC_HIGH
    ElseIf (dacval < DAC_LOW) Then
        dacval = DAC_LOW
    End If
    
    ERRVAL = BTI429_ParamAmplitudeConfig(PARAMCFG429_DEFAULT, dacval, xmtchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "the amplitude on channel #" & xmtchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If

    If (divval > DIV_HIGH) Then
        divval = DIV_HIGH
    ElseIf (divval < DIV_LOW) Then
        divval = DIV_LOW
    End If

    ' TODO: check with Jon about this configval??????!
    ERRVAL = BTI429_ParamBitRateConfig(PARAMCFG429_DEFAULT, divval, xmtchan, hCore)
    If (ERRVAL < 0) Then
        errstr = "Error:  An error was encountered while configuring" & vbNewLine
        errstr = errstr & "the bit rate on channel #" & xmtchan & " on core #" & corenum
        MsgBox errstr
        bSkipRun = True
        Exit Sub
    End If
    
    ' Create a message for each of the labels we are transmitting.
    comp_airspeed.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCore)
    tot_air_temp.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCore)
    altitude_rate.addr = BTI429_MsgCreate(MSGCRT429_DEFAULT, hCore)
    
    ' Setup the arrays of message addresses, and intervals
    ' needed to build the schedule.  Note that the nth element
    ' in each array correspond to eachother.
    msgaddr(0) = comp_airspeed.addr
    min_intrvls(0) = 250
    max_intrvls(0) = 500
    
    msgaddr(1) = tot_air_temp.addr
    min_intrvls(1) = 250
    max_intrvls(1) = 500
    
    msgaddr(2) = altitude_rate.addr
    min_intrvls(2) = 100
    max_intrvls(2) = 200
    
    ' Next, build a schedule using the minimum and maximum
    ' transmit intervals.
    ERRVAL = BTI429_SchedBuild(3, msgaddr(0), min_intrvls(0), max_intrvls(0), xmtchan, hCore)
    If (ERRVAL < 0) Then
        MsgBox "Error:  BTI429_SchedBuild failed on channel #" & xmtchan & "on core #" & corenum & "."
        bSkipRun = True
        Exit Sub
    End If
    
    ' Initialize the three Message Records.
    comp_airspeed.Data = BTI429_FldPutLabel(0, &O206)    '/*Init label field*/
    tot_air_temp.Data = BTI429_FldPutLabel(0, &O211)
    altitude_rate.Data = BTI429_FldPutLabel(0, &O212)
    
    comp_airspeed.Data = BTI429_BNRPutMant(comp_airspeed.Data, 0, 14, 0) '/*Init BNR data*/
    tot_air_temp.Data = BTI429_BNRPutMant(tot_air_temp.Data, 0, 11, 0)
    altitude_rate.Data = BTI429_BNRPutMant(altitude_rate.Data, 0, 16, 0)
    
    Call BTI429_MsgDataWr(comp_airspeed.Data, comp_airspeed.addr, hCore)
    Call BTI429_MsgDataWr(tot_air_temp.Data, tot_air_temp.addr, hCore)
    Call BTI429_MsgDataWr(altitude_rate.Data, altitude_rate.addr, hCore)
    
    ' Start operation of the card.
    ERRVAL = BTICard_CardStart(hCore)
    If (ERRVAL < 0) Then
        MsgBox "Error:  An error was encountered while starting the card"
        bSkipRun = True
        Exit Sub
    End If
    
    ' Update text
    DacText.Caption = "Dac = " & dacval
    DivText.Caption = "Div = " & divval
     
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
    Call BTI429_ChStop(xmtchan, hCore)
    
    ' Update the amplitude on the core
    ERRVAL = BTI429_ParamAmplitudeConfig(PARAMCFG429_DEFAULT, dacval, xmtchan, hCore)
    If (ERRVAL < 0) Then
        MsgBox "Error: can not update amplitude on core number #" & corenum
        bSkipRun = True
        BTICard_CardStop (hCore)
        Exit Sub
    End If
    
    ' Start the transmit channel
    Call BTI429_ChStart(xmtchan, hCore)
    
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
    ERRVAL = BTICard_CardOpen(hCard, cardnum)
    If (ERRVAL) Then
        MsgBox "Error: can not open card number " & CStr(cardnum)
        bSkipRun = True
        Exit Sub
    End If
    
    ' Find the first 429 core with a transmit channel that supports parametrics.
    For corenum = 0 To (MAX_CORES - 1)
        ERRVAL = BTICard_CoreOpen(hCore, corenum, hCard)
        If ERRVAL = 0 Then
            For xmtchan = 0 To (MAX_CHANNELS - 1)
                If BTI429_ChIsXmt(xmtchan, hCore) Then
                    If (BTI429_ChGetInfo(INFO429_PARAM, xmtchan, hCore) > 0) Then
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
    
    Exit Sub
Errhandler:
        MsgBox "An Error Has Occured:  " & Err.Description

End Sub

Private Sub Timer1_Timer()

    If (bSkipRun = True) Or (bCardRunning = False) Then
        Exit Sub
    End If
    
    '
    ' Update values in messages
    '
    
    comp_airspeed.Data = BTI429_MsgDataRd(comp_airspeed.addr, hCore)               ' Read messages back
    tot_air_temp.Data = BTI429_MsgDataRd(tot_air_temp.addr, hCore)
    altitude_rate.Data = BTI429_MsgDataRd(altitude_rate.addr, hCore)

    bnr_data(0) = BTI429_BNRGetMant(comp_airspeed.Data, 14)                        'Extract BNR data
    bnr_data(1) = BTI429_BNRGetMant(tot_air_temp.Data, 11)
    bnr_data(2) = BTI429_BNRGetMant(altitude_rate.Data, 16)

    bnr_data(0) = bnr_data(0) + 1   ' Change BNR data
    bnr_data(1) = bnr_data(1) + 1
    bnr_data(2) = bnr_data(2) + 1

    comp_airspeed.Data = BTI429_BNRPutMant(comp_airspeed.Data, bnr_data(0), 14, 0) ' Put BNR data
    tot_air_temp.Data = BTI429_BNRPutMant(tot_air_temp.Data, bnr_data(1), 11, 0)   ' back into
    altitude_rate.Data = BTI429_BNRPutMant(altitude_rate.Data, bnr_data(2), 16, 0) ' messages

    Call BTI429_MsgDataWr(comp_airspeed.Data, comp_airspeed.addr, hCore)           ' Write new message values
    Call BTI429_MsgDataWr(tot_air_temp.Data, tot_air_temp.addr, hCore)
    Call BTI429_MsgDataWr(altitude_rate.Data, altitude_rate.addr, hCore)
    
End Sub


