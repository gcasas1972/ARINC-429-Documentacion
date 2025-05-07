VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "CoPilot Automation Sample"
   ClientHeight    =   2625
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   5610
   LinkTopic       =   "Form1"
   ScaleHeight     =   2625
   ScaleWidth      =   5610
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command2 
      Caption         =   "Show/Hide"
      Height          =   375
      Left            =   2640
      TabIndex        =   13
      Top             =   480
      Width           =   975
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Refresh"
      Height          =   375
      Left            =   2160
      TabIndex        =   4
      Top             =   2160
      Width           =   1215
   End
   Begin VB.Label Label6 
      Caption         =   "View Count:"
      Height          =   255
      Left            =   240
      TabIndex        =   12
      Top             =   1800
      Width           =   975
   End
   Begin VB.Label Label5 
      Caption         =   "Card Count:"
      Height          =   255
      Left            =   240
      TabIndex        =   11
      Top             =   1440
      Width           =   855
   End
   Begin VB.Label ViewsCountText 
      Caption         =   "<count of views in current project>"
      Height          =   255
      Left            =   1320
      TabIndex        =   10
      Top             =   1800
      Width           =   2535
   End
   Begin VB.Label CardsCountText 
      Caption         =   "<count of cards in current project>"
      Height          =   255
      Left            =   1320
      TabIndex        =   9
      Top             =   1440
      Width           =   2535
   End
   Begin VB.Label RunTimeText 
      Caption         =   "<time in ms simulation has been running>"
      Height          =   495
      Left            =   3840
      TabIndex        =   8
      Top             =   840
      Width           =   1575
   End
   Begin VB.Label Label4 
      Caption         =   "Running Time:"
      Height          =   375
      Left            =   2880
      TabIndex        =   7
      Top             =   840
      Width           =   855
   End
   Begin VB.Label VisibleText 
      Caption         =   "<visible state>"
      Height          =   255
      Left            =   1320
      TabIndex        =   6
      Top             =   480
      Width           =   1215
   End
   Begin VB.Label Label3 
      Caption         =   "Visible:"
      Height          =   255
      Left            =   240
      TabIndex        =   5
      Top             =   480
      Width           =   855
   End
   Begin VB.Label RunningText 
      Caption         =   "<running state>"
      Height          =   255
      Left            =   1320
      TabIndex        =   3
      Top             =   840
      Width           =   1335
   End
   Begin VB.Label ProjectText 
      Caption         =   "<project>"
      Height          =   255
      Left            =   1320
      TabIndex        =   2
      Top             =   240
      Width           =   3375
   End
   Begin VB.Label Label2 
      Caption         =   "Running Simulation:"
      Height          =   375
      Left            =   240
      TabIndex        =   1
      Top             =   840
      Width           =   855
   End
   Begin VB.Label Label1 
      Caption         =   "Project:"
      Height          =   255
      Left            =   240
      TabIndex        =   0
      Top             =   240
      Width           =   735
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'This sample is to show the basics of connecting to a
'running CoPilot application using Automation.
'
'To use this application:
'First launch CoPilot
'Then lanuch this app to connect to CoPilot
'
'Minimum requirements:
'   Set copilot = CreateObject... to initialize the copilot object
'   ...                           user's code to run
'   Set copilot = Nothing         frees the copilot object


'Options
Option Explicit

'Variable Declarations
Dim copilot As Object

Private Sub Command1_Click()
    RefreshCoPilotInfo
End Sub

Private Sub Command2_Click()
    If copilot.Visible Then
        copilot.Visible = False
    Else
        copilot.Visible = True
    End If
    
    'Refresh Current CoPilot Info
    RefreshCoPilotInfo
End Sub

Private Sub Form_Load()
    'Initialize the copilot object
    InitialzeCoPilot
    
    'Refresh Current CoPilot Info - all optional!
    RefreshCoPilotInfo
End Sub

Private Sub Form_Terminate()
    ' Clean up any structures/objects
    If Not copilot Is Nothing Then
        'The following line stops the simulation if it is running
        'Call copilot.Stop
        
        'The following line closes the copilot project
        'Call copilot.Quit
        
        'Frees the copilot object - MUST BE CALLED
        Set copilot = Nothing
    End If
    
End Sub

Private Sub InitialzeCoPilot()
    'Create the CoPilot application automation object
    Set copilot = CreateObject("BallardTechnology.CopilotShell.1")
    'Verify copilot was created
    If copilot Is Nothing Then
        MsgBox "Unable to create CoPilot. Application will close."
        'End the application
        End
    End If

End Sub

Private Sub RefreshCoPilotInfo()
    If copilot Is Nothing Then
        MsgBox "CoPilot is not loaded."
        ProjectText.Caption = ""
        VisibleText.Caption = ""
        RunningText.Caption = ""
        RunTimeText.Caption = ""
    
        CardsCountText.Caption = ""
        ViewsCountText.Caption = ""
    Else
        ProjectText.Caption = copilot.CurProject
        VisibleText.Caption = copilot.Visible
        
        'Change text on show/hide button
        If copilot.Visible Then
            Command2.Caption = "Hide"
        Else
            Command2.Caption = "Show"
        End If
        
        RunningText.Caption = copilot.Running
        RunTimeText.Caption = copilot.RunTime
        
        CardsCountText.Caption = copilot.Cards.Count
        ViewsCountText.Caption = copilot.Views.Count
    End If
End Sub
