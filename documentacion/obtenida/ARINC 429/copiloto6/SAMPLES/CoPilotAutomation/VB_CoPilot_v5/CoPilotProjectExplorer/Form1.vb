Option Strict Off
Option Explicit On

Friend Class Form1
    Inherits System.Windows.Forms.Form

    'Global Variables
    Dim copilot As Object


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub HideBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideBtn.Click
        If copilot.Visible Then
            copilot.Visible = False
        Else
            copilot.Visible = True
        End If

        'Refresh Current CoPilot Info
        RefreshCoPilotInfo()
    End Sub

    Private Sub RefreshBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshBtn.Click
        RefreshCoPilotInfo()
    End Sub

    Private Sub Dialog1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        ' Clean up any structures/objects
        If Not copilot Is Nothing Then
            'The following line stops the simulation if it is running
            'Call copilot.Stop

            'The following line closes the copilot project
            'Call copilot.Quit

            'Frees the copilot object - MUST BE CALLED
            copilot = Nothing
        End If

    End Sub

    Private Sub Dialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Initialize the copilot object
        InitialzeCoPilot()

        'Refresh Current CoPilot Info - all optional!
        RefreshCoPilotInfo()
    End Sub

    Private Sub InitialzeCoPilot()
        'Create the CoPilot application automation object
        If Equals(Nothing, copilot) Then
            copilot = CreateObject("BallardCoPilot.CopilotShell.1")
        End If

        'Verify copilot was created
        If copilot Is Nothing Then
            MsgBox("Unable to create CoPilot. Application will close.")
            'End the application
            End
        End If

    End Sub

    Private Sub RefreshCoPilotInfo()
        If copilot Is Nothing Then
            MsgBox("CoPilot is not loaded.")
            ProjectText.Text = ""
            VisibleText.Text = ""
            RunningText.Text = ""
            RunTimeText.Text = ""

            CardsCountText.Text = ""
            ViewsCountText.Text = ""
        Else
            ProjectText.Text = copilot.CurProject
            VisibleText.Text = copilot.Visible

            'Change text on show/hide button
            If copilot.Visible Then
                HideBtn.Text = "Hide"
            Else
                HideBtn.Text = "Show"
            End If

            RunningText.Text = copilot.Running
            RunTimeText.Text = copilot.RunTime

            CardsCountText.Text = copilot.Cards.Count
            ViewsCountText.Text = copilot.Views.Count
        End If
    End Sub

    'Public Sub New()

    ' This call is required by the Windows Form Designer.
    '   InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.
    'End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub


End Class
