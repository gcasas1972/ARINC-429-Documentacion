<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Form1
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.RunTimeText = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ViewsCountText = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CardsCountText = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.RunningText = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.VisibleText = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ProjectText = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.HideBtn = New System.Windows.Forms.Button
        Me.RefreshBtn = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(294, 114)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(21, 14)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "ms"
        '
        'RunTimeText
        '
        Me.RunTimeText.Location = New System.Drawing.Point(109, 107)
        Me.RunTimeText.Name = "RunTimeText"
        Me.RunTimeText.ReadOnly = True
        Me.RunTimeText.Size = New System.Drawing.Size(182, 20)
        Me.RunTimeText.TabIndex = 24
        Me.RunTimeText.Text = "<time in ms simulation has been run>"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 14)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Running Time:"
        '
        'ViewsCountText
        '
        Me.ViewsCountText.Location = New System.Drawing.Point(120, 179)
        Me.ViewsCountText.Name = "ViewsCountText"
        Me.ViewsCountText.ReadOnly = True
        Me.ViewsCountText.Size = New System.Drawing.Size(59, 20)
        Me.ViewsCountText.TabIndex = 28
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 186)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 14)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "View Count:"
        '
        'CardsCountText
        '
        Me.CardsCountText.Location = New System.Drawing.Point(120, 153)
        Me.CardsCountText.Name = "CardsCountText"
        Me.CardsCountText.ReadOnly = True
        Me.CardsCountText.Size = New System.Drawing.Size(59, 20)
        Me.CardsCountText.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 14)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Card Count:"
        '
        'RunningText
        '
        Me.RunningText.Location = New System.Drawing.Point(109, 82)
        Me.RunningText.Name = "RunningText"
        Me.RunningText.ReadOnly = True
        Me.RunningText.Size = New System.Drawing.Size(145, 20)
        Me.RunningText.TabIndex = 22
        Me.RunningText.Text = "<running state>"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 14)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Running Simulation:"
        '
        'VisibleText
        '
        Me.VisibleText.Location = New System.Drawing.Point(109, 56)
        Me.VisibleText.Name = "VisibleText"
        Me.VisibleText.ReadOnly = True
        Me.VisibleText.Size = New System.Drawing.Size(145, 20)
        Me.VisibleText.TabIndex = 19
        Me.VisibleText.Text = "<visible state>"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 14)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Visible:"
        '
        'ProjectText
        '
        Me.ProjectText.Location = New System.Drawing.Point(109, 12)
        Me.ProjectText.Name = "ProjectText"
        Me.ProjectText.ReadOnly = True
        Me.ProjectText.Size = New System.Drawing.Size(205, 20)
        Me.ProjectText.TabIndex = 17
        Me.ProjectText.Text = "<project>"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 14)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Project:"
        '
        'HideBtn
        '
        Me.HideBtn.Location = New System.Drawing.Point(258, 53)
        Me.HideBtn.Name = "HideBtn"
        Me.HideBtn.Size = New System.Drawing.Size(56, 23)
        Me.HideBtn.TabIndex = 20
        Me.HideBtn.Text = "Hide"
        Me.HideBtn.UseVisualStyleBackColor = True
        '
        'RefreshBtn
        '
        Me.RefreshBtn.Location = New System.Drawing.Point(86, 208)
        Me.RefreshBtn.Name = "RefreshBtn"
        Me.RefreshBtn.Size = New System.Drawing.Size(149, 23)
        Me.RefreshBtn.TabIndex = 29
        Me.RefreshBtn.Text = "Refresh"
        Me.RefreshBtn.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(326, 243)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.RunTimeText)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.ViewsCountText)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CardsCountText)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.RunningText)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.VisibleText)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ProjectText)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.HideBtn)
        Me.Controls.Add(Me.RefreshBtn)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Simple Automation"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RunTimeText As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ViewsCountText As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CardsCountText As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RunningText As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents VisibleText As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ProjectText As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents HideBtn As System.Windows.Forms.Button
    Friend WithEvents RefreshBtn As System.Windows.Forms.Button
#End Region 
End Class