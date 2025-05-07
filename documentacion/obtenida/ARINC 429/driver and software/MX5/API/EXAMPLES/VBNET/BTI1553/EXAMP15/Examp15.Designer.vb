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
	Public WithEvents cmdStart As System.Windows.Forms.Button
	Public WithEvents cmdStop As System.Windows.Forms.Button
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents Timer1 As System.Windows.Forms.Timer
	Public WithEvents Line2 As System.Windows.Forms.Label
	Public WithEvents Channel As System.Windows.Forms.Label
	Public WithEvents _Header2_0 As System.Windows.Forms.Label
	Public WithEvents _Heade3_1 As System.Windows.Forms.Label
	Public WithEvents _Header4_1 As System.Windows.Forms.Label
	Public WithEvents _Header5_0 As System.Windows.Forms.Label
	Public WithEvents Line1 As System.Windows.Forms.Label
	Public WithEvents Core As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents _Header1_1 As System.Windows.Forms.Label
	Public WithEvents Header1a As System.Windows.Forms.Label
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
        Me.cmdStart = New System.Windows.Forms.Button
        Me.cmdStop = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Line2 = New System.Windows.Forms.Label
        Me.Channel = New System.Windows.Forms.Label
        Me._Header2_0 = New System.Windows.Forms.Label
        Me._Heade3_1 = New System.Windows.Forms.Label
        Me._Header4_1 = New System.Windows.Forms.Label
        Me._Header5_0 = New System.Windows.Forms.Label
        Me.Line1 = New System.Windows.Forms.Label
        Me.Core = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me._Header1_1 = New System.Windows.Forms.Label
        Me.Header1a = New System.Windows.Forms.Label
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
        Me.List1.Size = New System.Drawing.Size(385, 270)
        Me.List1.TabIndex = 3
        '
        'cmdStart
        '
        Me.cmdStart.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStart.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStart.Location = New System.Drawing.Point(8, 480)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStart.Size = New System.Drawing.Size(49, 25)
        Me.cmdStart.TabIndex = 2
        Me.cmdStart.Text = "Start"
        Me.cmdStart.UseVisualStyleBackColor = False
        '
        'cmdStop
        '
        Me.cmdStop.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStop.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStop.Enabled = False
        Me.cmdStop.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStop.Location = New System.Drawing.Point(64, 480)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStop.Size = New System.Drawing.Size(49, 25)
        Me.cmdStop.TabIndex = 1
        Me.cmdStop.Text = "Stop"
        Me.cmdStop.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(344, 480)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(49, 25)
        Me.cmdExit.TabIndex = 0
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Line2
        '
        Me.Line2.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line2.Location = New System.Drawing.Point(52, 132)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(296, 1)
        Me.Line2.TabIndex = 4
        '
        'Channel
        '
        Me.Channel.BackColor = System.Drawing.SystemColors.Control
        Me.Channel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Channel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Channel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Channel.Location = New System.Drawing.Point(108, 152)
        Me.Channel.Name = "Channel"
        Me.Channel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Channel.Size = New System.Drawing.Size(193, 17)
        Me.Channel.TabIndex = 13
        Me.Channel.Text = "Channel:"
        '
        '_Header2_0
        '
        Me._Header2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Header2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Header2_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Header2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header2.SetIndex(Me._Header2_0, CType(0, Short))
        Me._Header2_0.Location = New System.Drawing.Point(52, 47)
        Me._Header2_0.Name = "_Header2_0"
        Me._Header2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Header2_0.Size = New System.Drawing.Size(289, 17)
        Me._Header2_0.TabIndex = 12
        Me._Header2_0.Text = "VB.NET BTI1553 EXAMPLE 15"
        '
        '_Heade3_1
        '
        Me._Heade3_1.BackColor = System.Drawing.SystemColors.Control
        Me._Heade3_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Heade3_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Heade3_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Heade3.SetIndex(Me._Heade3_1, CType(1, Short))
        Me._Heade3_1.Location = New System.Drawing.Point(52, 79)
        Me._Heade3_1.Name = "_Heade3_1"
        Me._Heade3_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Heade3_1.Size = New System.Drawing.Size(289, 17)
        Me._Heade3_1.TabIndex = 11
        Me._Heade3_1.Text = "Ballard Technology, Inc. Everett, WA, USA."
        '
        '_Header4_1
        '
        Me._Header4_1.BackColor = System.Drawing.SystemColors.Control
        Me._Header4_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Header4_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Header4_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header4.SetIndex(Me._Header4_1, CType(1, Short))
        Me._Header4_1.Location = New System.Drawing.Point(52, 95)
        Me._Header4_1.Name = "_Header4_1"
        Me._Header4_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Header4_1.Size = New System.Drawing.Size(289, 17)
        Me._Header4_1.TabIndex = 10
        Me._Header4_1.Text = "All rights reserved."
        '
        '_Header5_0
        '
        Me._Header5_0.BackColor = System.Drawing.SystemColors.Control
        Me._Header5_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Header5_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Header5_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header5.SetIndex(Me._Header5_0, CType(0, Short))
        Me._Header5_0.Location = New System.Drawing.Point(52, 111)
        Me._Header5_0.Name = "_Header5_0"
        Me._Header5_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Header5_0.Size = New System.Drawing.Size(289, 17)
        Me._Header5_0.TabIndex = 9
        Me._Header5_0.Text = "www.ballardtech.com or email support@ballardtech.com"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line1.Location = New System.Drawing.Point(52, 40)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(296, 1)
        Me.Line1.TabIndex = 14
        '
        'Core
        '
        Me.Core.BackColor = System.Drawing.SystemColors.Control
        Me.Core.Cursor = System.Windows.Forms.Cursors.Default
        Me.Core.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Core.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Core.Location = New System.Drawing.Point(108, 135)
        Me.Core.Name = "Core"
        Me.Core.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Core.Size = New System.Drawing.Size(193, 17)
        Me.Core.TabIndex = 8
        Me.Core.Text = "Core:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(52, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(289, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Copyright 2009-2011"
        '
        '_Header1_1
        '
        Me._Header1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Header1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Header1_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Header1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header1.SetIndex(Me._Header1_1, CType(1, Short))
        Me._Header1_1.Location = New System.Drawing.Point(44, 0)
        Me._Header1_1.Name = "_Header1_1"
        Me._Header1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Header1_1.Size = New System.Drawing.Size(313, 17)
        Me._Header1_1.TabIndex = 6
        Me._Header1_1.Text = "IRIG Timer Example"
        Me._Header1_1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Header1a
        '
        Me.Header1a.BackColor = System.Drawing.SystemColors.Control
        Me.Header1a.Cursor = System.Windows.Forms.Cursors.Default
        Me.Header1a.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Header1a.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header1a.Location = New System.Drawing.Point(44, 16)
        Me.Header1a.Name = "Header1a"
        Me.Header1a.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Header1a.Size = New System.Drawing.Size(313, 17)
        Me.Header1a.TabIndex = 5
        Me.Header1a.Text = "Monitoring The Bus"
        Me.Header1a.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Result1
        '
        Me.Result1.BackColor = System.Drawing.SystemColors.Control
        Me.Result1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Result1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Result1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Result1.Location = New System.Drawing.Point(52, 168)
        Me.Result1.Name = "Result1"
        Me.Result1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Result1.Size = New System.Drawing.Size(281, 17)
        Me.Result1.TabIndex = 4
        Me.Result1.Text = "Result1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(401, 513)
        Me.Controls.Add(Me.List1)
        Me.Controls.Add(Me.cmdStart)
        Me.Controls.Add(Me.cmdStop)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.Line2)
        Me.Controls.Add(Me.Channel)
        Me.Controls.Add(Me._Header2_0)
        Me.Controls.Add(Me._Heade3_1)
        Me.Controls.Add(Me._Header4_1)
        Me.Controls.Add(Me._Header5_0)
        Me.Controls.Add(Me.Line1)
        Me.Controls.Add(Me.Core)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me._Header1_1)
        Me.Controls.Add(Me.Header1a)
        Me.Controls.Add(Me.Result1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "BTI1553 Example 15"
        CType(Me.Heade3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Header1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Header2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Header4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Header5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class