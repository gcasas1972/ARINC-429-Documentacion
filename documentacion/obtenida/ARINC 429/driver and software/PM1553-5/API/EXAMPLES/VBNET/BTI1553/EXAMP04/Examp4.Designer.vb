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
	Public WithEvents List1 As System.Windows.Forms.ListBox
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
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.List1 = New System.Windows.Forms.ListBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
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
        Me.Heade3 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.Header1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.Header2 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.Header4 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.Header5 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        CType(Me.Heade3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Header1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Header2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Header4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Header5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'List1
        '
        Me.List1.BackColor = System.Drawing.SystemColors.Window
        Me.List1.Cursor = System.Windows.Forms.Cursors.Default
        Me.List1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.List1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.List1.ItemHeight = 14
        Me.List1.Location = New System.Drawing.Point(8, 192)
        Me.List1.Name = "List1"
        Me.List1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.List1.Size = New System.Drawing.Size(409, 228)
        Me.List1.TabIndex = 12
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'CmdStart
        '
        Me.CmdStart.BackColor = System.Drawing.SystemColors.Control
        Me.CmdStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdStart.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdStart.Location = New System.Drawing.Point(8, 440)
        Me.CmdStart.Name = "CmdStart"
        Me.CmdStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdStart.Size = New System.Drawing.Size(49, 25)
        Me.CmdStart.TabIndex = 2
        Me.CmdStart.Text = "Start"
        Me.CmdStart.UseVisualStyleBackColor = False
        '
        'CmdStop
        '
        Me.CmdStop.BackColor = System.Drawing.SystemColors.Control
        Me.CmdStop.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdStop.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdStop.Location = New System.Drawing.Point(72, 440)
        Me.CmdStop.Name = "CmdStop"
        Me.CmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdStop.Size = New System.Drawing.Size(49, 25)
        Me.CmdStop.TabIndex = 1
        Me.CmdStop.Text = "Stop"
        Me.CmdStop.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(368, 440)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(49, 25)
        Me.cmdExit.TabIndex = 0
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'Core
        '
        Me.Core.BackColor = System.Drawing.SystemColors.Control
        Me.Core.Cursor = System.Windows.Forms.Cursors.Default
        Me.Core.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Core.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Core.Location = New System.Drawing.Point(100, 128)
        Me.Core.Name = "Core"
        Me.Core.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Core.Size = New System.Drawing.Size(209, 17)
        Me.Core.TabIndex = 11
        Me.Core.Text = "Core"
        '
        'Channel
        '
        Me.Channel.BackColor = System.Drawing.SystemColors.Control
        Me.Channel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Channel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Channel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Channel.Location = New System.Drawing.Point(100, 144)
        Me.Channel.Name = "Channel"
        Me.Channel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Channel.Size = New System.Drawing.Size(209, 17)
        Me.Channel.TabIndex = 10
        Me.Channel.Text = "Channel"
        '
        '_Header1_1
        '
        Me._Header1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Header1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Header1_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Header1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header1.SetIndex(Me._Header1_1, CType(1, Short))
        Me._Header1_1.Location = New System.Drawing.Point(0, 0)
        Me._Header1_1.Name = "_Header1_1"
        Me._Header1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Header1_1.Size = New System.Drawing.Size(417, 17)
        Me._Header1_1.TabIndex = 9
        Me._Header1_1.Text = "Monitoring The Bus"
        Me._Header1_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(64, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(289, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Ballard Technology, Inc. Everett, WA, USA."
        '
        '_Header2_0
        '
        Me._Header2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Header2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Header2_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Header2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header2.SetIndex(Me._Header2_0, CType(0, Short))
        Me._Header2_0.Location = New System.Drawing.Point(64, 32)
        Me._Header2_0.Name = "_Header2_0"
        Me._Header2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Header2_0.Size = New System.Drawing.Size(289, 17)
        Me._Header2_0.TabIndex = 7
        Me._Header2_0.Text = "VB.NET BTI1553 EXAMPLE 4"
        '
        '_Heade3_1
        '
        Me._Heade3_1.BackColor = System.Drawing.SystemColors.Control
        Me._Heade3_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Heade3_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Heade3_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Heade3.SetIndex(Me._Heade3_1, CType(1, Short))
        Me._Heade3_1.Location = New System.Drawing.Point(64, 49)
        Me._Heade3_1.Name = "_Heade3_1"
        Me._Heade3_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Heade3_1.Size = New System.Drawing.Size(289, 17)
        Me._Heade3_1.TabIndex = 6
        Me._Heade3_1.Text = "Copyright 2009-2011"
        '
        '_Header4_1
        '
        Me._Header4_1.BackColor = System.Drawing.SystemColors.Control
        Me._Header4_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Header4_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Header4_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header4.SetIndex(Me._Header4_1, CType(1, Short))
        Me._Header4_1.Location = New System.Drawing.Point(64, 80)
        Me._Header4_1.Name = "_Header4_1"
        Me._Header4_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Header4_1.Size = New System.Drawing.Size(289, 17)
        Me._Header4_1.TabIndex = 5
        Me._Header4_1.Text = "All rights reserved."
        '
        '_Header5_0
        '
        Me._Header5_0.BackColor = System.Drawing.SystemColors.Control
        Me._Header5_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Header5_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Header5_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header5.SetIndex(Me._Header5_0, CType(0, Short))
        Me._Header5_0.Location = New System.Drawing.Point(64, 96)
        Me._Header5_0.Name = "_Header5_0"
        Me._Header5_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Header5_0.Size = New System.Drawing.Size(289, 17)
        Me._Header5_0.TabIndex = 4
        Me._Header5_0.Text = "www.ballardtech.com or email support@ballardtech.com"
        '
        'Line4
        '
        Me.Line4.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line4.Location = New System.Drawing.Point(64, 120)
        Me.Line4.Name = "Line4"
        Me.Line4.Size = New System.Drawing.Size(296, 1)
        Me.Line4.TabIndex = 13
        '
        'Line5
        '
        Me.Line5.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line5.Location = New System.Drawing.Point(64, 24)
        Me.Line5.Name = "Line5"
        Me.Line5.Size = New System.Drawing.Size(296, 1)
        Me.Line5.TabIndex = 14
        '
        'Result1
        '
        Me.Result1.BackColor = System.Drawing.SystemColors.Control
        Me.Result1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Result1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Result1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Result1.Location = New System.Drawing.Point(8, 168)
        Me.Result1.Name = "Result1"
        Me.Result1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Result1.Size = New System.Drawing.Size(281, 17)
        Me.Result1.TabIndex = 3
        Me.Result1.Text = "Result1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(424, 472)
        Me.Controls.Add(Me.List1)
        Me.Controls.Add(Me.CmdStart)
        Me.Controls.Add(Me.CmdStop)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.Core)
        Me.Controls.Add(Me.Channel)
        Me.Controls.Add(Me._Header1_1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me._Header2_0)
        Me.Controls.Add(Me._Heade3_1)
        Me.Controls.Add(Me._Header4_1)
        Me.Controls.Add(Me._Header5_0)
        Me.Controls.Add(Me.Line4)
        Me.Controls.Add(Me.Line5)
        Me.Controls.Add(Me.Result1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "BTI1553 Example 4"
        CType(Me.Heade3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Header1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Header2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Header4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Header5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class