VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Simple Automation"
   ClientHeight    =   1335
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   3615
   LinkTopic       =   "Form1"
   ScaleHeight     =   1335
   ScaleWidth      =   3615
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Cmd1553 
      Caption         =   "Lookup a MIL-STD-1553 Field"
      Height          =   495
      Left            =   120
      TabIndex        =   1
      Top             =   120
      Width           =   3375
   End
   Begin VB.CommandButton Cmd429 
      Caption         =   "Lookup ARINC 429 Label 310"
      Height          =   495
      Left            =   120
      TabIndex        =   0
      Top             =   720
      Width           =   3375
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

'Global Variables
'Const filename As String = "C:\CoPilot Projects\Samples\CoPilotAutomation\VB\Simple Automation\Example Project\Example.CPJ"
Const filename As String = "C:\Working\CoPilotAutomation\VB\Simple Automation\Example Project\Example.CPJ"

Private Sub Cmd1553_Click()
    'Variable Declaration
    Dim copilot As Object
    Dim msgText As String
    msgText = "Error"
    
    'Create the CoPilot application automation object
    Set copilot = CreateObject("BallardTechnology.CopilotShell.1")
    
    'Open the example project
    Call copilot.Open(filename, True)
    copilot.Visible = True
    
    'Find the target object and value
    For Each card In copilot.cards
        If card.Description = "Demo card MIL1553" Then
            For Each chan In card.Chan1553s
                If chan.ChanNum = 0 Then
                    For Each rt In chan.RTs
                        If rt.RTNum = 1 Then
                            For Each sa In rt.SAs
                                If sa.SANum = 1 Then
                                    For Each field In sa.Field1553s
                                        If field.Name = "Latitude" Then
                                           'Format the result string
                                            msgText = "Card: " & card.Description & vbNewLine
                                            msgText = msgText & "Channel: " & chan.Description & vbNewLine
                                            msgText = msgText & "RT: " & rt.Name & vbNewLine
                                            msgText = msgText & "SA: " & sa.Name & vbNewLine
                                            msgText = msgText & "Field: " & field.Name & vbNewLine
                                            msgText = msgText & "Value: " & field.Value & " " & field.Units
                                        End If
                                    Next
                                End If
                            Next
                        End If
                    Next
                End If
            Next
        End If
    Next
    
    'Show the message
    Call MsgBox(msgText, vbSystemModal And vbInformation, "Result")
    
    ' Clean up any structures/objects
    copilot.Visible = False
    Call copilot.Quit
    Set copilot = Nothing
End Sub

Private Sub Cmd429_Click()
    'Variable Declaration
    Dim copilot As Object
    Dim msgText As String
    msgText = "Error"
    
    'Create the CoPilot application automation object
    Set copilot = CreateObject("BallardTechnology.CopilotShell.1")
    
    'Open the example project
    Call copilot.Open(filename, True)
    copilot.Visible = True
    
    'Find the target object and value
    For Each card In copilot.cards
        If card.Description = "Demo card ARINC429" Then
            For Each chan In card.Chan429s
                If chan.EquipmentNum = &O2 Then
                    For Each Label In chan.Labels
                        If Label.LabelNum = &O310 Then
                            'Format the result string
                            msgText = "Card: " & card.Description & vbNewLine
                            msgText = msgText & "Channel: " & chan.Description & vbNewLine
                            msgText = msgText & "Label: " & Label.Description & vbNewLine
                            msgText = msgText & "Value: " & Label.ValueString & " " & Label.Units
                        End If
                    Next
                End If
            Next
        End If
    Next
    
    'Show the message
    Call MsgBox(msgText, vbSystemModal And vbInformation, "Result")
    
    ' Clean up any structures/objects
    copilot.Visible = False
    Call copilot.Quit
    Set copilot = Nothing
End Sub

