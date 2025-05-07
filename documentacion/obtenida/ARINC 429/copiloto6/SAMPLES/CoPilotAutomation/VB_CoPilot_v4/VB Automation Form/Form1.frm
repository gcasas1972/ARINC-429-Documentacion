VERSION 5.00
Object = "{F9043C88-F6F2-101A-A3C9-08002B2F49FB}#1.2#0"; "comdlg32.ocx"
Begin VB.Form Form1 
   Caption         =   "CoPilot Automation Form"
   ClientHeight    =   3480
   ClientLeft      =   165
   ClientTop       =   735
   ClientWidth     =   6375
   LinkTopic       =   "Form1"
   ScaleHeight     =   3480
   ScaleWidth      =   6375
   StartUpPosition =   3  'Windows Default
   Begin MSComDlg.CommonDialog CommonDialog1 
      Left            =   5400
      Top             =   20
      _ExtentX        =   847
      _ExtentY        =   847
      _Version        =   393216
   End
   Begin VB.Timer Timer1 
      Interval        =   1000
      Left            =   5880
      Top             =   20
   End
   Begin VB.CommandButton CmdMonitor 
      Caption         =   "Read Monitor"
      Height          =   255
      Left            =   2640
      TabIndex        =   7
      Top             =   600
      Width           =   3615
   End
   Begin VB.ListBox MonRecList 
      BackColor       =   &H00FFFFFF&
      ForeColor       =   &H00000000&
      Height          =   2400
      Left            =   2640
      TabIndex        =   6
      Top             =   960
      Width           =   3615
   End
   Begin VB.ComboBox Combo1 
      BackColor       =   &H00000000&
      ForeColor       =   &H00FFFFFF&
      Height          =   315
      Left            =   120
      Style           =   2  'Dropdown List
      TabIndex        =   5
      Top             =   600
      Width           =   2415
   End
   Begin VB.ListBox OutputList 
      BackColor       =   &H00FFFFFF&
      ForeColor       =   &H00000000&
      Height          =   2400
      Left            =   120
      TabIndex        =   4
      Top             =   960
      Width           =   2415
   End
   Begin VB.CommandButton CmdOpen 
      Caption         =   "Open"
      Height          =   375
      Index           =   1
      Left            =   120
      TabIndex        =   3
      Top             =   120
      Width           =   615
   End
   Begin VB.CommandButton CmdStop 
      Caption         =   "Stop"
      Height          =   375
      Index           =   1
      Left            =   1800
      TabIndex        =   2
      Top             =   120
      Width           =   615
   End
   Begin VB.CommandButton CmdRun 
      Caption         =   "Run"
      Height          =   375
      Index           =   0
      Left            =   960
      TabIndex        =   1
      Top             =   120
      Width           =   615
   End
   Begin VB.TextBox TextStatus 
      BackColor       =   &H00000000&
      ForeColor       =   &H000000FF&
      Height          =   405
      Left            =   2640
      Locked          =   -1  'True
      TabIndex        =   0
      Text            =   "Text1"
      Top             =   120
      Width           =   2655
   End
   Begin VB.Line Line1 
      X1              =   0
      X2              =   6360
      Y1              =   0
      Y2              =   0
   End
   Begin VB.Menu MenuFile 
      Caption         =   "File"
      Begin VB.Menu MenuFileExit 
         Caption         =   "Exit"
      End
   End
   Begin VB.Menu MenuProject 
      Caption         =   "Project"
      NegotiatePosition=   1  'Left
      Begin VB.Menu MenuProjectOpen 
         Caption         =   "Open"
      End
      Begin VB.Menu MenuProjectRun 
         Caption         =   "Run"
      End
      Begin VB.Menu MenuProjectStop 
         Caption         =   "Stop"
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'Options
Option Explicit

'Variable Declarations
Dim copilot As Object

Private Sub CmdMonitor_Click()
    Dim card, monitor, record As Object
    Dim index As Integer
    Dim itemStr As String
    
    MonRecList.Clear
    
    If Combo1.ListIndex > 0 Then
        ' Get the card object
        Set card = copilot.Cards.Item(Combo1.ItemData(Combo1.ListIndex))
        
        ' MONITOR
        For Each monitor In card.Monitors
            index = 0
            MonRecList.AddItem (monitor.Description)
        
            '1553 RECORD
            For Each record In monitor.Record1553s
                itemStr = "  " & Format(index, "0000")
                itemStr = itemStr & " Cwd1:" & Hex(record.Cwd1)
                itemStr = itemStr & " Swd1:" & Hex(record.Swd1)
                'Look for no response error
                If record.ErrorVal And &H8000 Then
                    itemStr = itemStr & " No Response!"
                End If
                'Add item to list
                MonRecList.AddItem (itemStr)
                index = index + 1
            Next '1553 RECORD
            
            '429 RECORD
            For Each record In monitor.Record429s
                itemStr = "  " & Format(index, "0000")
                itemStr = itemStr & " Label:" & Format(Oct(record.LabelNum), "000")
                itemStr = itemStr & " " & Hex(record.MsgVal)
                'Add item to list
                MonRecList.AddItem (itemStr)
                index = index + 1
            Next '429 RECORD
            
            '708 RECORD
            For Each record In monitor.Record708s
                itemStr = "  " & Format(index, "0000")
                itemStr = itemStr & " Data Count:" & record.DataCount
                'Add item to list
                MonRecList.AddItem (itemStr)
                index = index + 1
            Next '708 RECORD
            
        Next ' MONITOR
        
        Set card = Nothing
    End If
End Sub

Private Sub CmdOpen_Click(index As Integer)
    On Error GoTo ErrHandler
    
    'If running then stop
    If copilot.Running Then
        Call copilot.Stop
    End If
    
    'Close the current project
    Call copilot.Close(False)
    
    'Browse for new project
    CommonDialog1.Filter = "CoPilot Projects (*.CPJ)|*.CPJ"   ' Set Filters
    CommonDialog1.FilterIndex = 1                             ' Specify default filter
    CommonDialog1.InitDir = copilot.ProjectDir                ' Specify initial path
    CommonDialog1.ShowOpen                                    ' Display the Open dialog box
    
    'Open new project
    If "" <> CommonDialog1.FileName Then
        Call copilot.Open(CommonDialog1.FileName, True)
        TextStatus.Text = copilot.ProjectName & " - Stopped..."
    End If
    
    Call InitCombo
    
ErrHandler:
    ' User pressed Cancel button
    Exit Sub
    
End Sub

Private Sub InitCombo()
    'Fill the combo box with boards from the project
    Dim index As Long
    
    OutputList.Clear
    MonRecList.Clear
    
    Combo1.Clear
    Combo1.AddItem ("Select A Card")
    Combo1.ListIndex = 0
    
    For index = 1 To copilot.Cards.Count
        Combo1.AddItem (copilot.Cards.Item(index).Description & " #" & copilot.Cards.Item(index).CardNum)
        Combo1.ItemData(Combo1.NewIndex) = index
    Next
End Sub

Private Sub CmdRun_Click(index As Integer)
    MonRecList.Clear
    If "" <> copilot.CurProject Then
        Call copilot.Run
        TextStatus.Text = copilot.ProjectName & " - Running"
    Else
        Call MsgBox("No project is open.", vbOKOnly, "Error")
    End If
End Sub

Private Sub CmdStop_Click(index As Integer)
    Call copilot.Stop
    Call RefreshOutput
    TextStatus.Text = copilot.ProjectName & " - Stopped..."
End Sub

Private Sub RefreshOutput()
    Dim card, chan, msg, label, field, monitor As Object
    Dim BC, RT, SA As Object
    Dim recCount As Integer
    
    OutputList.Clear
    
    If Combo1.ListIndex > 0 Then
        ' CARD
        Set card = copilot.Cards.Item(Combo1.ItemData(Combo1.ListIndex))
        
        ' 1553 CHANNELS
        For Each chan In card.Chan1553s
            OutputList.AddItem ("-- " & chan.Description)
            
            ' BUS CONTROLLER
            Set BC = chan.BC
                OutputList.AddItem ("    -- " & BC.Description)
                ' BC MESSAGES
                For Each msg In BC.BCMsgs
                    OutputList.AddItem ("      -- " & msg.Description)
                    ' FIELDS
                    For Each field In msg.Field1553s
                        OutputList.AddItem ("        -- " & field.Description)
                    Next ' FIELDS
                Next ' BC MESSAGES
            Set BC = Nothing
            
            ' RTS
            For Each RT In chan.RTs
                OutputList.AddItem ("    -- " & RT.Description)
                ' SAS
                For Each SA In RT.SAs
                    OutputList.AddItem ("      -- " & SA.Description)
                    ' FIELDS
                    For Each field In SA.Field1553s
                        OutputList.AddItem ("        -- " & field.Description)
                    Next ' FIELDS
                Next ' SAS
            Next ' RTS
            
        Next '1553 CHANNEL
        
        ' 429 CHANNEL
        For Each chan In card.Chan429s
            OutputList.AddItem ("-- " & chan.Description)
            ' 429 LABEL
            For Each label In chan.Labels
                OutputList.AddItem ("    -- " & label.Description)
                ' 429 FIELDS
                For Each field In label.Field429s
                    OutputList.AddItem ("        -- " & field.Description)
                Next ' 429 FIELDS
            Next ' 429 LABEL
        Next '429 CHANNEL
                
        ' 708 CHANNEL
        For Each chan In card.Chan708s
            OutputList.AddItem ("-- " & chan.Description)
        Next ' 708 CHANNEL
        
        ' MONITOR
        For Each monitor In card.Monitors
            recCount = 0
            recCount = recCount + monitor.Record1553s.Count
            recCount = recCount + monitor.Record429s.Count
            recCount = recCount + monitor.Record708s.Count
            OutputList.AddItem ("-- " & monitor.Description & " (" & recCount & ")")
        Next ' MONITOR
        
        Set card = Nothing
    End If
    
    If copilot.Running Then
        TextStatus.Text = copilot.ProjectName & " - Running " & CStr(CLng(copilot.runtime) / 1000)
    End If

End Sub

Private Sub Combo1_Click()
    Call RefreshOutput
    MonRecList.Clear
End Sub

Private Sub Form_Load()
    'Create the CoPilot application automation object
    Set copilot = CreateObject("BallardTechnology.CopilotShell.1")
    'Verify copilot was created
    If copilot Is Nothing Then
        MsgBox "Unable to create CoPilot. Application will close."
        'End the application
        End
    End If
    'Init the status text
    TextStatus.Text = "Open a project..."
    'Init the board combo box
    Combo1.Clear
    'Init the OutputList
    OutputList.Clear
    'Init the MonRecList
    MonRecList.Clear
End Sub

Private Sub Form_Terminate()
    ' Clean up any structures/objects
    If Not copilot Is Nothing Then
        Call copilot.Stop
        Call copilot.Quit
        Set copilot = Nothing
    End If
    
End Sub

Private Sub MenuFileExit_Click()
    ' Clean up any structures/objects
    Form_Terminate
    ' End the application
    End
End Sub

Private Sub MenuProjectOpen_Click()
    CmdOpen_Click (0)
End Sub

Private Sub MenuProjectRun_Click()
    CmdRun_Click (0)
End Sub

Private Sub MenuProjectStop_Click()
    CmdStop_Click (0)
End Sub

Private Sub Timer1_Timer()
    If Not copilot Is Nothing Then
        If copilot.Running Then
            Call RefreshOutput
        End If
    End If
End Sub
