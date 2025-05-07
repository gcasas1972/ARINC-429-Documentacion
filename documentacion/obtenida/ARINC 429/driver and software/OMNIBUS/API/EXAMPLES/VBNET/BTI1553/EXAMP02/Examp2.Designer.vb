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
	Public WithEvents Timer1 As System.Windows.Forms.Timer
	Public WithEvents CmdStart As System.Windows.Forms.Button
	Public WithEvents CmdStop As System.Windows.Forms.Button
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents Core As System.Windows.Forms.Label
	Public WithEvents Channel As System.Windows.Forms.Label
	Public WithEvents _Header1_1 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents _Header2_0 As System.Windows.Forms.Label
	Public WithEvents _Heade3_1 As System.Windows.Forms.Label
	Public WithEvents _Header4_1 As System.Windows.Forms.Label
	Public WithEvents _Header5_0 As System.Windows.Forms.Label
	Public WithEvents Line4 As System.Windows.Forms.Label
	Public WithEvents Line5 As System.Windows.Forms.Label
	Public WithEvents Result1 As System.Windows.Forms.Label
	Public WithEvents Heade3 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Header1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Header2 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Header4 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Header5 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.Timer1 = New System.Windows.Forms.Timer(components)
		Me.CmdStart = New System.Windows.Forms.Button
		Me.CmdStop = New System.Windows.Forms.Button
		Me.cmdExit = New System.Windows.Forms.Button
		Me.Core = New System.Windows.Forms.Label
		Me.Channel = New System.Windows.Forms.Label
		Me._Header1_1 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me._Header2_0 = New System.Windows.Forms.Label
		Me._Heade3_1 = New System.Windows.Forms.Label
		Me._Header4_1 = New System.Windows.Forms.Label
		Me._Header5_0 = New System.Windows.Forms.Label
		Me.Line4 = New System.Windows.Forms.Label
		Me.Line5 = New System.Windows.Forms.Label
		Me.Result1 = New System.Windows.Forms.Label
		Me.Heade3 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Header1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Header2 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Header4 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Header5 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.Heade3, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Header1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Header2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Header4, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Header5, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "BTI1553 Example 2"
		Me.ClientSize = New System.Drawing.Size(329, 246)
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
		Me.Timer1.Interval = 100
		Me.Timer1.Enabled = True
		Me.CmdStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdStart.Text = "Start"
		Me.CmdStart.Size = New System.Drawing.Size(49, 25)
		Me.CmdStart.Location = New System.Drawing.Point(8, 216)
		Me.CmdStart.TabIndex = 2
		Me.CmdStart.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CmdStart.BackColor = System.Drawing.SystemColors.Control
		Me.CmdStart.CausesValidation = True
		Me.CmdStart.Enabled = True
		Me.CmdStart.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdStart.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdStart.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdStart.TabStop = True
		Me.CmdStart.Name = "CmdStart"
		Me.CmdStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdStop.Text = "Stop"
		Me.CmdStop.Size = New System.Drawing.Size(49, 25)
		Me.CmdStop.Location = New System.Drawing.Point(72, 216)
		Me.CmdStop.TabIndex = 1
		Me.CmdStop.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CmdStop.BackColor = System.Drawing.SystemColors.Control
		Me.CmdStop.CausesValidation = True
		Me.CmdStop.Enabled = True
		Me.CmdStop.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdStop.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdStop.TabStop = True
		Me.CmdStop.Name = "CmdStop"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "Exit"
		Me.cmdExit.Size = New System.Drawing.Size(49, 25)
		Me.cmdExit.Location = New System.Drawing.Point(272, 216)
		Me.cmdExit.TabIndex = 0
		Me.cmdExit.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.TabStop = True
		Me.cmdExit.Name = "cmdExit"
		Me.Core.Text = "Core"
		Me.Core.Size = New System.Drawing.Size(209, 17)
		Me.Core.Location = New System.Drawing.Point(60, 136)
		Me.Core.TabIndex = 11
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
		Me.Channel.Text = "Channel"
		Me.Channel.Size = New System.Drawing.Size(209, 17)
		Me.Channel.Location = New System.Drawing.Point(60, 152)
		Me.Channel.TabIndex = 10
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
		Me._Header1_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._Header1_1.Text = "Simulating the BC - Scheduled Messages"
		Me._Header1_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._Header1_1.Size = New System.Drawing.Size(329, 17)
		Me._Header1_1.Location = New System.Drawing.Point(0, 8)
		Me._Header1_1.TabIndex = 9
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
		Me.Label1.Text = "Ballard Technology, Inc. Everett, WA, USA."
		Me.Label1.Size = New System.Drawing.Size(289, 17)
		Me.Label1.Location = New System.Drawing.Point(17, 73)
		Me.Label1.TabIndex = 8
		Me.Label1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label1.BackColor = System.Drawing.SystemColors.Control
		Me.Label1.Enabled = True
		Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label1.UseMnemonic = True
		Me.Label1.Visible = True
		Me.Label1.AutoSize = False
		Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label1.Name = "Label1"
        Me._Header2_0.Text = "VB.NET BTI1553 EXAMPLE 2"
		Me._Header2_0.Size = New System.Drawing.Size(289, 17)
		Me._Header2_0.Location = New System.Drawing.Point(17, 40)
		Me._Header2_0.TabIndex = 7
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
        Me._Heade3_1.Text = "Copyright 2009-2011"
		Me._Heade3_1.Size = New System.Drawing.Size(289, 17)
		Me._Heade3_1.Location = New System.Drawing.Point(17, 57)
		Me._Heade3_1.TabIndex = 6
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
		Me._Header4_1.Location = New System.Drawing.Point(17, 88)
		Me._Header4_1.TabIndex = 5
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
        Me._Header5_0.Text = "www.ballardtech.com or email support@ballardtech.com"
		Me._Header5_0.Size = New System.Drawing.Size(289, 17)
		Me._Header5_0.Location = New System.Drawing.Point(17, 104)
		Me._Header5_0.TabIndex = 4
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
		Me.Line4.BackColor = System.Drawing.SystemColors.WindowText
		Me.Line4.Visible = True
		Me.Line4.Location = New System.Drawing.Point(17, 128)
		Me.Line4.Size = New System.Drawing.Size(296, 1)
		Me.Line4.Name = "Line4"
		Me.Line5.BackColor = System.Drawing.SystemColors.WindowText
		Me.Line5.Visible = True
		Me.Line5.Location = New System.Drawing.Point(17, 32)
		Me.Line5.Size = New System.Drawing.Size(296, 1)
		Me.Line5.Name = "Line5"
		Me.Result1.Text = "Result1"
		Me.Result1.Size = New System.Drawing.Size(281, 25)
		Me.Result1.Location = New System.Drawing.Point(25, 184)
		Me.Result1.TabIndex = 3
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
		Me.Controls.Add(CmdStart)
		Me.Controls.Add(CmdStop)
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(Core)
		Me.Controls.Add(Channel)
		Me.Controls.Add(_Header1_1)
		Me.Controls.Add(Label1)
		Me.Controls.Add(_Header2_0)
		Me.Controls.Add(_Heade3_1)
		Me.Controls.Add(_Header4_1)
		Me.Controls.Add(_Header5_0)
		Me.Controls.Add(Line4)
		Me.Controls.Add(Line5)
		Me.Controls.Add(Result1)
		Me.Heade3.SetIndex(_Heade3_1, CType(1, Short))
		Me.Header1.SetIndex(_Header1_1, CType(1, Short))
		Me.Header2.SetIndex(_Header2_0, CType(0, Short))
		Me.Header4.SetIndex(_Header4_1, CType(1, Short))
		Me.Header5.SetIndex(_Header5_0, CType(0, Short))
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