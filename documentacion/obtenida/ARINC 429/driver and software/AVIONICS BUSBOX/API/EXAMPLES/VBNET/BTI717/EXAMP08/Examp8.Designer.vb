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
	Public WithEvents List2 As System.Windows.Forms.ListBox
	Public WithEvents List1 As System.Windows.Forms.ListBox
	Public WithEvents Timer1 As System.Windows.Forms.Timer
	Public WithEvents CmdStop As System.Windows.Forms.Button
	Public WithEvents CmdStart As System.Windows.Forms.Button
	Public WithEvents CmdExit As System.Windows.Forms.Button
	Public WithEvents _Label1_1 As System.Windows.Forms.Label
	Public WithEvents Result1 As System.Windows.Forms.Label
	Public WithEvents _Header1_1 As System.Windows.Forms.Label
	Public WithEvents Line2 As System.Windows.Forms.Label
	Public WithEvents Channel As System.Windows.Forms.Label
	Public WithEvents _Header2_0 As System.Windows.Forms.Label
	Public WithEvents _Heade3_1 As System.Windows.Forms.Label
	Public WithEvents _Header4_1 As System.Windows.Forms.Label
	Public WithEvents _Header5_0 As System.Windows.Forms.Label
	Public WithEvents Line1 As System.Windows.Forms.Label
	Public WithEvents Core As System.Windows.Forms.Label
	Public WithEvents _Label1_0 As System.Windows.Forms.Label
	Public WithEvents Heade3 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Header1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Header2 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Header4 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Header5 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Label1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.List2 = New System.Windows.Forms.ListBox
		Me.List1 = New System.Windows.Forms.ListBox
		Me.Timer1 = New System.Windows.Forms.Timer(components)
		Me.CmdStop = New System.Windows.Forms.Button
		Me.CmdStart = New System.Windows.Forms.Button
		Me.CmdExit = New System.Windows.Forms.Button
		Me._Label1_1 = New System.Windows.Forms.Label
		Me.Result1 = New System.Windows.Forms.Label
		Me._Header1_1 = New System.Windows.Forms.Label
		Me.Line2 = New System.Windows.Forms.Label
		Me.Channel = New System.Windows.Forms.Label
		Me._Header2_0 = New System.Windows.Forms.Label
		Me._Heade3_1 = New System.Windows.Forms.Label
		Me._Header4_1 = New System.Windows.Forms.Label
		Me._Header5_0 = New System.Windows.Forms.Label
		Me.Line1 = New System.Windows.Forms.Label
		Me.Core = New System.Windows.Forms.Label
		Me._Label1_0 = New System.Windows.Forms.Label
		Me.Heade3 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Header1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Header2 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Header4 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Header5 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Label1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.Heade3, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Header1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Header2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Header4, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Header5, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "BTI717 Example 8"
		Me.ClientSize = New System.Drawing.Size(385, 498)
		Me.Location = New System.Drawing.Point(4, 23)
		Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
		Me.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.SystemColors.Control
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
		Me.ControlBox = True
		Me.Enabled = True
		Me.KeyPreview = False
		Me.MaximizeBox = True
		Me.MinimizeBox = True
		Me.Cursor = System.Windows.Forms.Cursors.Default
		Me.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ShowInTaskbar = True
		Me.HelpButton = False
		Me.WindowState = System.Windows.Forms.FormWindowState.Normal
		Me.Name = "Form1"
		Me.List2.Size = New System.Drawing.Size(369, 215)
		Me.List2.Location = New System.Drawing.Point(8, 240)
		Me.List2.TabIndex = 4
		Me.List2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.List2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.List2.BackColor = System.Drawing.SystemColors.Window
		Me.List2.CausesValidation = True
		Me.List2.Enabled = True
		Me.List2.ForeColor = System.Drawing.SystemColors.WindowText
		Me.List2.IntegralHeight = True
		Me.List2.Cursor = System.Windows.Forms.Cursors.Default
		Me.List2.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.List2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.List2.Sorted = False
		Me.List2.TabStop = True
		Me.List2.Visible = True
		Me.List2.MultiColumn = False
		Me.List2.Name = "List2"
		Me.List1.Size = New System.Drawing.Size(65, 59)
		Me.List1.Location = New System.Drawing.Point(272, 176)
		Me.List1.TabIndex = 3
		Me.List1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.List1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.List1.BackColor = System.Drawing.SystemColors.Window
		Me.List1.CausesValidation = True
		Me.List1.Enabled = True
		Me.List1.ForeColor = System.Drawing.SystemColors.WindowText
		Me.List1.IntegralHeight = True
		Me.List1.Cursor = System.Windows.Forms.Cursors.Default
		Me.List1.SelectionMode = System.Windows.Forms.SelectionMode.One
		Me.List1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.List1.Sorted = False
		Me.List1.TabStop = True
		Me.List1.Visible = True
		Me.List1.MultiColumn = False
		Me.List1.Name = "List1"
		Me.Timer1.Interval = 100
		Me.Timer1.Enabled = True
		Me.CmdStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdStop.Text = "Stop"
		Me.CmdStop.Size = New System.Drawing.Size(49, 25)
		Me.CmdStop.Location = New System.Drawing.Point(64, 464)
		Me.CmdStop.TabIndex = 2
		Me.CmdStop.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CmdStop.BackColor = System.Drawing.SystemColors.Control
		Me.CmdStop.CausesValidation = True
		Me.CmdStop.Enabled = True
		Me.CmdStop.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdStop.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdStop.TabStop = True
		Me.CmdStop.Name = "CmdStop"
		Me.CmdStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdStart.Text = "Start"
		Me.CmdStart.Size = New System.Drawing.Size(49, 25)
		Me.CmdStart.Location = New System.Drawing.Point(8, 464)
		Me.CmdStart.TabIndex = 1
		Me.CmdStart.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CmdStart.BackColor = System.Drawing.SystemColors.Control
		Me.CmdStart.CausesValidation = True
		Me.CmdStart.Enabled = True
		Me.CmdStart.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdStart.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdStart.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdStart.TabStop = True
		Me.CmdStart.Name = "CmdStart"
		Me.CmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdExit.Text = "Exit"
		Me.CmdExit.Size = New System.Drawing.Size(49, 25)
		Me.CmdExit.Location = New System.Drawing.Point(328, 464)
		Me.CmdExit.TabIndex = 0
		Me.CmdExit.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.CmdExit.CausesValidation = True
		Me.CmdExit.Enabled = True
		Me.CmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdExit.TabStop = True
		Me.CmdExit.Name = "CmdExit"
		Me._Label1_1.Text = "Words Per Second"
		Me._Label1_1.Size = New System.Drawing.Size(105, 17)
		Me._Label1_1.Location = New System.Drawing.Point(256, 160)
		Me._Label1_1.TabIndex = 14
		Me._Label1_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._Label1_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_1.BackColor = System.Drawing.SystemColors.Control
		Me._Label1_1.Enabled = True
		Me._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_1.UseMnemonic = True
		Me._Label1_1.Visible = True
		Me._Label1_1.AutoSize = False
		Me._Label1_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_1.Name = "_Label1_1"
		Me.Result1.Text = "Result1"
		Me.Result1.Size = New System.Drawing.Size(217, 25)
		Me.Result1.Location = New System.Drawing.Point(40, 192)
		Me.Result1.TabIndex = 13
		Me.Result1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Result1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Result1.BackColor = System.Drawing.SystemColors.Control
		Me.Result1.Enabled = True
		Me.Result1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Result1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Result1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Result1.UseMnemonic = True
		Me.Result1.Visible = True
		Me.Result1.AutoSize = False
		Me.Result1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Result1.Name = "Result1"
		Me._Header1_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._Header1_1.Text = "IRIG Timer Example"
		Me._Header1_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._Header1_1.Size = New System.Drawing.Size(305, 17)
		Me._Header1_1.Location = New System.Drawing.Point(40, 0)
		Me._Header1_1.TabIndex = 12
		Me._Header1_1.BackColor = System.Drawing.SystemColors.Control
		Me._Header1_1.Enabled = True
		Me._Header1_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Header1_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Header1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Header1_1.UseMnemonic = True
		Me._Header1_1.Visible = True
		Me._Header1_1.AutoSize = False
		Me._Header1_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Header1_1.Name = "_Header1_1"
		Me.Line2.BackColor = System.Drawing.SystemColors.WindowText
		Me.Line2.Visible = True
		Me.Line2.Location = New System.Drawing.Point(46, 116)
		Me.Line2.Size = New System.Drawing.Size(296, 1)
		Me.Line2.Name = "Line2"
		Me.Channel.Text = "Channel:"
		Me.Channel.Size = New System.Drawing.Size(193, 17)
		Me.Channel.Location = New System.Drawing.Point(102, 136)
		Me.Channel.TabIndex = 11
		Me.Channel.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Channel.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Channel.BackColor = System.Drawing.SystemColors.Control
		Me.Channel.Enabled = True
		Me.Channel.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Channel.Cursor = System.Windows.Forms.Cursors.Default
		Me.Channel.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Channel.UseMnemonic = True
		Me.Channel.Visible = True
		Me.Channel.AutoSize = False
		Me.Channel.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Channel.Name = "Channel"
        Me._Header2_0.Text = "VB_EXAMP8     (06/07/2011)"
		Me._Header2_0.Size = New System.Drawing.Size(289, 17)
		Me._Header2_0.Location = New System.Drawing.Point(48, 32)
		Me._Header2_0.TabIndex = 10
		Me._Header2_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._Header2_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Header2_0.BackColor = System.Drawing.SystemColors.Control
		Me._Header2_0.Enabled = True
		Me._Header2_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Header2_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Header2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Header2_0.UseMnemonic = True
		Me._Header2_0.Visible = True
		Me._Header2_0.AutoSize = False
		Me._Header2_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Header2_0.Name = "_Header2_0"
		Me._Heade3_1.Text = "Ballard Technology, Inc. Everett, WA, USA."
		Me._Heade3_1.Size = New System.Drawing.Size(289, 17)
		Me._Heade3_1.Location = New System.Drawing.Point(46, 63)
		Me._Heade3_1.TabIndex = 9
		Me._Heade3_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._Heade3_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Heade3_1.BackColor = System.Drawing.SystemColors.Control
		Me._Heade3_1.Enabled = True
		Me._Heade3_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Heade3_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Heade3_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Heade3_1.UseMnemonic = True
		Me._Heade3_1.Visible = True
		Me._Heade3_1.AutoSize = False
		Me._Heade3_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Heade3_1.Name = "_Heade3_1"
		Me._Header4_1.Text = "All rights reserved."
		Me._Header4_1.Size = New System.Drawing.Size(289, 17)
		Me._Header4_1.Location = New System.Drawing.Point(46, 79)
		Me._Header4_1.TabIndex = 8
		Me._Header4_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._Header4_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Header4_1.BackColor = System.Drawing.SystemColors.Control
		Me._Header4_1.Enabled = True
		Me._Header4_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Header4_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Header4_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Header4_1.UseMnemonic = True
		Me._Header4_1.Visible = True
		Me._Header4_1.AutoSize = False
		Me._Header4_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Header4_1.Name = "_Header4_1"
		Me._Header5_0.Text = "Go to www.ballardtech.com or email support@ballardtech.com"
		Me._Header5_0.Size = New System.Drawing.Size(289, 17)
		Me._Header5_0.Location = New System.Drawing.Point(44, 95)
		Me._Header5_0.TabIndex = 7
		Me._Header5_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._Header5_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Header5_0.BackColor = System.Drawing.SystemColors.Control
		Me._Header5_0.Enabled = True
		Me._Header5_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Header5_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Header5_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Header5_0.UseMnemonic = True
		Me._Header5_0.Visible = True
		Me._Header5_0.AutoSize = False
		Me._Header5_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Header5_0.Name = "_Header5_0"
		Me.Line1.BackColor = System.Drawing.SystemColors.WindowText
		Me.Line1.Visible = True
		Me.Line1.Location = New System.Drawing.Point(46, 24)
		Me.Line1.Size = New System.Drawing.Size(296, 1)
		Me.Line1.Name = "Line1"
		Me.Core.Text = "Core:"
		Me.Core.Size = New System.Drawing.Size(193, 17)
		Me.Core.Location = New System.Drawing.Point(102, 119)
		Me.Core.TabIndex = 6
		Me.Core.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Core.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Core.BackColor = System.Drawing.SystemColors.Control
		Me.Core.Enabled = True
		Me.Core.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Core.Cursor = System.Windows.Forms.Cursors.Default
		Me.Core.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Core.UseMnemonic = True
		Me.Core.Visible = True
		Me.Core.AutoSize = False
		Me.Core.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Core.Name = "Core"
        Me._Label1_0.Text = "Copyright 2009-2011"
		Me._Label1_0.Size = New System.Drawing.Size(289, 17)
		Me._Label1_0.Location = New System.Drawing.Point(46, 47)
		Me._Label1_0.TabIndex = 5
		Me._Label1_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._Label1_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Label1_0.BackColor = System.Drawing.SystemColors.Control
		Me._Label1_0.Enabled = True
		Me._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Label1_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Label1_0.UseMnemonic = True
		Me._Label1_0.Visible = True
		Me._Label1_0.AutoSize = False
		Me._Label1_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Label1_0.Name = "_Label1_0"
		Me.Controls.Add(List2)
		Me.Controls.Add(List1)
		Me.Controls.Add(CmdStop)
		Me.Controls.Add(CmdStart)
		Me.Controls.Add(CmdExit)
		Me.Controls.Add(_Label1_1)
		Me.Controls.Add(Result1)
		Me.Controls.Add(_Header1_1)
		Me.Controls.Add(Line2)
		Me.Controls.Add(Channel)
		Me.Controls.Add(_Header2_0)
		Me.Controls.Add(_Heade3_1)
		Me.Controls.Add(_Header4_1)
		Me.Controls.Add(_Header5_0)
		Me.Controls.Add(Line1)
		Me.Controls.Add(Core)
		Me.Controls.Add(_Label1_0)
		Me.Heade3.SetIndex(_Heade3_1, CType(1, Short))
		Me.Header1.SetIndex(_Header1_1, CType(1, Short))
		Me.Header2.SetIndex(_Header2_0, CType(0, Short))
		Me.Header4.SetIndex(_Header4_1, CType(1, Short))
		Me.Header5.SetIndex(_Header5_0, CType(0, Short))
		Me.Label1.SetIndex(_Label1_1, CType(1, Short))
		Me.Label1.SetIndex(_Label1_0, CType(0, Short))
		CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Header5, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Header4, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Header2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Header1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Heade3, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class