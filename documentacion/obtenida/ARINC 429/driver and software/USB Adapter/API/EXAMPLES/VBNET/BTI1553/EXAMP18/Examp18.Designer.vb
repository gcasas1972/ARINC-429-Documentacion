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
	Public WithEvents Offset As System.Windows.Forms.TextBox
	Public WithEvents Resolution As System.Windows.Forms.TextBox
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents CmdStop As System.Windows.Forms.Button
	Public WithEvents CmdStart As System.Windows.Forms.Button
	Public WithEvents Timer1 As System.Windows.Forms.Timer
	Public WithEvents List1 As System.Windows.Forms.ListBox
	Public WithEvents OffSetLbl As System.Windows.Forms.Label
	Public WithEvents ResolutionLbl As System.Windows.Forms.Label
	Public WithEvents Result1 As System.Windows.Forms.Label
	Public WithEvents Line5 As System.Windows.Forms.Label
	Public WithEvents Line4 As System.Windows.Forms.Label
	Public WithEvents _Header5_0 As System.Windows.Forms.Label
	Public WithEvents _Header4_1 As System.Windows.Forms.Label
	Public WithEvents _Heade3_1 As System.Windows.Forms.Label
	Public WithEvents _Header2_0 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents _Header1_1 As System.Windows.Forms.Label
	Public WithEvents Channel As System.Windows.Forms.Label
	Public WithEvents Core As System.Windows.Forms.Label
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
		Me.Offset = New System.Windows.Forms.TextBox
		Me.Resolution = New System.Windows.Forms.TextBox
		Me.cmdExit = New System.Windows.Forms.Button
		Me.CmdStop = New System.Windows.Forms.Button
		Me.CmdStart = New System.Windows.Forms.Button
		Me.Timer1 = New System.Windows.Forms.Timer(components)
		Me.List1 = New System.Windows.Forms.ListBox
		Me.OffSetLbl = New System.Windows.Forms.Label
		Me.ResolutionLbl = New System.Windows.Forms.Label
		Me.Result1 = New System.Windows.Forms.Label
		Me.Line5 = New System.Windows.Forms.Label
		Me.Line4 = New System.Windows.Forms.Label
		Me._Header5_0 = New System.Windows.Forms.Label
		Me._Header4_1 = New System.Windows.Forms.Label
		Me._Heade3_1 = New System.Windows.Forms.Label
		Me._Header2_0 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me._Header1_1 = New System.Windows.Forms.Label
		Me.Channel = New System.Windows.Forms.Label
		Me.Core = New System.Windows.Forms.Label
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
		Me.Text = "BTI1553 Example 18"
		Me.ClientSize = New System.Drawing.Size(427, 474)
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
		Me.Offset.AutoSize = False
		Me.Offset.Size = New System.Drawing.Size(65, 25)
		Me.Offset.Location = New System.Drawing.Point(288, 184)
		Me.Offset.TabIndex = 16
		Me.Offset.Text = "Text2"
		Me.Offset.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Offset.AcceptsReturn = True
		Me.Offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.Offset.BackColor = System.Drawing.SystemColors.Window
		Me.Offset.CausesValidation = True
		Me.Offset.Enabled = True
		Me.Offset.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Offset.HideSelection = True
		Me.Offset.ReadOnly = False
		Me.Offset.Maxlength = 0
		Me.Offset.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.Offset.MultiLine = False
		Me.Offset.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Offset.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.Offset.TabStop = True
		Me.Offset.Visible = True
		Me.Offset.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Offset.Name = "Offset"
		Me.Resolution.AutoSize = False
		Me.Resolution.Size = New System.Drawing.Size(65, 25)
		Me.Resolution.Location = New System.Drawing.Point(120, 184)
		Me.Resolution.TabIndex = 15
		Me.Resolution.Text = "Text1"
		Me.Resolution.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Resolution.AcceptsReturn = True
		Me.Resolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.Resolution.BackColor = System.Drawing.SystemColors.Window
		Me.Resolution.CausesValidation = True
		Me.Resolution.Enabled = True
		Me.Resolution.ForeColor = System.Drawing.SystemColors.WindowText
		Me.Resolution.HideSelection = True
		Me.Resolution.ReadOnly = False
		Me.Resolution.Maxlength = 0
		Me.Resolution.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.Resolution.MultiLine = False
		Me.Resolution.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Resolution.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.Resolution.TabStop = True
		Me.Resolution.Visible = True
		Me.Resolution.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Resolution.Name = "Resolution"
		Me.cmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.cmdExit.Text = "Exit"
		Me.cmdExit.Size = New System.Drawing.Size(49, 25)
		Me.cmdExit.Location = New System.Drawing.Point(368, 440)
		Me.cmdExit.TabIndex = 3
		Me.cmdExit.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.cmdExit.CausesValidation = True
		Me.cmdExit.Enabled = True
		Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.cmdExit.TabStop = True
		Me.cmdExit.Name = "cmdExit"
		Me.CmdStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdStop.Text = "Stop"
		Me.CmdStop.Size = New System.Drawing.Size(49, 25)
		Me.CmdStop.Location = New System.Drawing.Point(72, 440)
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
		Me.CmdStart.Location = New System.Drawing.Point(8, 440)
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
		Me.Timer1.Interval = 100
		Me.Timer1.Enabled = True
		Me.List1.Size = New System.Drawing.Size(409, 215)
		Me.List1.Location = New System.Drawing.Point(8, 216)
		Me.List1.TabIndex = 0
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
		Me.OffSetLbl.Text = "Offset"
		Me.OffSetLbl.Size = New System.Drawing.Size(81, 17)
		Me.OffSetLbl.Location = New System.Drawing.Point(237, 188)
		Me.OffSetLbl.TabIndex = 14
		Me.OffSetLbl.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.OffSetLbl.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.OffSetLbl.BackColor = System.Drawing.SystemColors.Control
		Me.OffSetLbl.Enabled = True
		Me.OffSetLbl.ForeColor = System.Drawing.SystemColors.ControlText
		Me.OffSetLbl.Cursor = System.Windows.Forms.Cursors.Default
		Me.OffSetLbl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.OffSetLbl.UseMnemonic = True
		Me.OffSetLbl.Visible = True
		Me.OffSetLbl.AutoSize = False
		Me.OffSetLbl.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.OffSetLbl.Name = "OffSetLbl"
		Me.ResolutionLbl.Text = "Resolution"
		Me.ResolutionLbl.Size = New System.Drawing.Size(81, 17)
		Me.ResolutionLbl.Location = New System.Drawing.Point(61, 188)
		Me.ResolutionLbl.TabIndex = 13
		Me.ResolutionLbl.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ResolutionLbl.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.ResolutionLbl.BackColor = System.Drawing.SystemColors.Control
		Me.ResolutionLbl.Enabled = True
		Me.ResolutionLbl.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ResolutionLbl.Cursor = System.Windows.Forms.Cursors.Default
		Me.ResolutionLbl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ResolutionLbl.UseMnemonic = True
		Me.ResolutionLbl.Visible = True
		Me.ResolutionLbl.AutoSize = False
		Me.ResolutionLbl.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.ResolutionLbl.Name = "ResolutionLbl"
		Me.Result1.Text = "Result1"
		Me.Result1.Size = New System.Drawing.Size(209, 17)
		Me.Result1.Location = New System.Drawing.Point(97, 160)
		Me.Result1.TabIndex = 12
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
		Me.Line5.BackColor = System.Drawing.SystemColors.WindowText
		Me.Line5.Visible = True
		Me.Line5.Location = New System.Drawing.Point(65, 24)
		Me.Line5.Size = New System.Drawing.Size(296, 1)
		Me.Line5.Name = "Line5"
		Me.Line4.BackColor = System.Drawing.SystemColors.WindowText
		Me.Line4.Visible = True
		Me.Line4.Location = New System.Drawing.Point(65, 120)
		Me.Line4.Size = New System.Drawing.Size(296, 1)
		Me.Line4.Name = "Line4"
        Me._Header5_0.Text = "www.ballardtech.com or email support@ballardtech.com"
		Me._Header5_0.Size = New System.Drawing.Size(289, 17)
		Me._Header5_0.Location = New System.Drawing.Point(65, 96)
		Me._Header5_0.TabIndex = 11
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
		Me._Header4_1.Text = "All rights reserved."
		Me._Header4_1.Size = New System.Drawing.Size(289, 17)
		Me._Header4_1.Location = New System.Drawing.Point(65, 80)
		Me._Header4_1.TabIndex = 10
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
        Me._Heade3_1.Text = "Copyright 2009-2011"
		Me._Heade3_1.Size = New System.Drawing.Size(289, 17)
		Me._Heade3_1.Location = New System.Drawing.Point(65, 49)
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
        Me._Header2_0.Text = "VB.NET BTI1553 EXAMPLE 18"
		Me._Header2_0.Size = New System.Drawing.Size(289, 17)
		Me._Header2_0.Location = New System.Drawing.Point(64, 32)
		Me._Header2_0.TabIndex = 8
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
		Me.Label1.Text = "Ballard Technology, Inc. Everett, WA, USA."
		Me.Label1.Size = New System.Drawing.Size(289, 17)
		Me.Label1.Location = New System.Drawing.Point(65, 65)
		Me.Label1.TabIndex = 7
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
		Me._Header1_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
		Me._Header1_1.Text = "Engineering Unit"
		Me._Header1_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._Header1_1.Size = New System.Drawing.Size(417, 17)
		Me._Header1_1.Location = New System.Drawing.Point(0, 0)
		Me._Header1_1.TabIndex = 6
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
		Me.Channel.Text = "Channel"
		Me.Channel.Size = New System.Drawing.Size(209, 17)
		Me.Channel.Location = New System.Drawing.Point(97, 144)
		Me.Channel.TabIndex = 5
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
		Me.Core.Text = "Core"
		Me.Core.Size = New System.Drawing.Size(209, 17)
		Me.Core.Location = New System.Drawing.Point(97, 128)
		Me.Core.TabIndex = 4
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
		Me.Controls.Add(Offset)
		Me.Controls.Add(Resolution)
		Me.Controls.Add(cmdExit)
		Me.Controls.Add(CmdStop)
		Me.Controls.Add(CmdStart)
		Me.Controls.Add(List1)
		Me.Controls.Add(OffSetLbl)
		Me.Controls.Add(ResolutionLbl)
		Me.Controls.Add(Result1)
		Me.Controls.Add(Line5)
		Me.Controls.Add(Line4)
		Me.Controls.Add(_Header5_0)
		Me.Controls.Add(_Header4_1)
		Me.Controls.Add(_Heade3_1)
		Me.Controls.Add(_Header2_0)
		Me.Controls.Add(Label1)
		Me.Controls.Add(_Header1_1)
		Me.Controls.Add(Channel)
		Me.Controls.Add(Core)
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