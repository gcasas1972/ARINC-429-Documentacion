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
	Public WithEvents cmdStart As System.Windows.Forms.Button
	Public WithEvents cmdStop As System.Windows.Forms.Button
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents CmdDown As System.Windows.Forms.Button
	Public WithEvents CmdUp As System.Windows.Forms.Button
	Public WithEvents CmdLeft As System.Windows.Forms.Button
	Public WithEvents CmdRight As System.Windows.Forms.Button
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Core As System.Windows.Forms.Label
	Public WithEvents Line1 As System.Windows.Forms.Label
	Public WithEvents _Header5_0 As System.Windows.Forms.Label
	Public WithEvents _Header4_1 As System.Windows.Forms.Label
	Public WithEvents _Heade3_1 As System.Windows.Forms.Label
	Public WithEvents _Header2_0 As System.Windows.Forms.Label
	Public WithEvents Channel As System.Windows.Forms.Label
	Public WithEvents Line2 As System.Windows.Forms.Label
	Public WithEvents _Header1_1 As System.Windows.Forms.Label
	Public WithEvents Line3 As System.Windows.Forms.Label
	Public WithEvents Line5 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents DacText As System.Windows.Forms.Label
	Public WithEvents OffsetText As System.Windows.Forms.Label
	Public WithEvents Line4 As System.Windows.Forms.Label
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdStart = New System.Windows.Forms.Button
        Me.cmdStop = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.CmdDown = New System.Windows.Forms.Button
        Me.CmdUp = New System.Windows.Forms.Button
        Me.CmdLeft = New System.Windows.Forms.Button
        Me.CmdRight = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Core = New System.Windows.Forms.Label
        Me.Line1 = New System.Windows.Forms.Label
        Me._Header5_0 = New System.Windows.Forms.Label
        Me._Header4_1 = New System.Windows.Forms.Label
        Me._Heade3_1 = New System.Windows.Forms.Label
        Me._Header2_0 = New System.Windows.Forms.Label
        Me.Channel = New System.Windows.Forms.Label
        Me.Line2 = New System.Windows.Forms.Label
        Me._Header1_1 = New System.Windows.Forms.Label
        Me.Line3 = New System.Windows.Forms.Label
        Me.Line5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DacText = New System.Windows.Forms.Label
        Me.OffsetText = New System.Windows.Forms.Label
        Me.Line4 = New System.Windows.Forms.Label
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
        'cmdStart
        '
        Me.cmdStart.BackColor = System.Drawing.SystemColors.Control
        Me.cmdStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdStart.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStart.Location = New System.Drawing.Point(8, 268)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStart.Size = New System.Drawing.Size(49, 25)
        Me.cmdStart.TabIndex = 6
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
        Me.cmdStop.Location = New System.Drawing.Point(64, 268)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStop.Size = New System.Drawing.Size(49, 25)
        Me.cmdStop.TabIndex = 5
        Me.cmdStop.Text = "Stop"
        Me.cmdStop.UseVisualStyleBackColor = False
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(256, 268)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(49, 25)
        Me.cmdExit.TabIndex = 4
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'CmdDown
        '
        Me.CmdDown.BackColor = System.Drawing.SystemColors.Control
        Me.CmdDown.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdDown.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdDown.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdDown.Image = CType(resources.GetObject("CmdDown.Image"), System.Drawing.Image)
        Me.CmdDown.Location = New System.Drawing.Point(104, 208)
        Me.CmdDown.Name = "CmdDown"
        Me.CmdDown.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdDown.Size = New System.Drawing.Size(34, 41)
        Me.CmdDown.TabIndex = 3
        Me.CmdDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdDown.UseVisualStyleBackColor = False
        '
        'CmdUp
        '
        Me.CmdUp.BackColor = System.Drawing.SystemColors.Control
        Me.CmdUp.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdUp.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdUp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdUp.Image = CType(resources.GetObject("CmdUp.Image"), System.Drawing.Image)
        Me.CmdUp.Location = New System.Drawing.Point(104, 168)
        Me.CmdUp.Name = "CmdUp"
        Me.CmdUp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdUp.Size = New System.Drawing.Size(34, 41)
        Me.CmdUp.TabIndex = 2
        Me.CmdUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdUp.UseVisualStyleBackColor = False
        '
        'CmdLeft
        '
        Me.CmdLeft.BackColor = System.Drawing.SystemColors.Control
        Me.CmdLeft.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdLeft.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdLeft.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdLeft.Image = CType(resources.GetObject("CmdLeft.Image"), System.Drawing.Image)
        Me.CmdLeft.Location = New System.Drawing.Point(184, 216)
        Me.CmdLeft.Name = "CmdLeft"
        Me.CmdLeft.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdLeft.Size = New System.Drawing.Size(41, 34)
        Me.CmdLeft.TabIndex = 1
        Me.CmdLeft.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdLeft.UseVisualStyleBackColor = False
        '
        'CmdRight
        '
        Me.CmdRight.BackColor = System.Drawing.SystemColors.Control
        Me.CmdRight.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdRight.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdRight.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdRight.Image = CType(resources.GetObject("CmdRight.Image"), System.Drawing.Image)
        Me.CmdRight.Location = New System.Drawing.Point(224, 216)
        Me.CmdRight.Name = "CmdRight"
        Me.CmdRight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdRight.Size = New System.Drawing.Size(41, 34)
        Me.CmdRight.TabIndex = 0
        Me.CmdRight.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CmdRight.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(8, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(289, 17)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Copyright 2009-2011"
        '
        'Core
        '
        Me.Core.BackColor = System.Drawing.SystemColors.Control
        Me.Core.Cursor = System.Windows.Forms.Cursors.Default
        Me.Core.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Core.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Core.Location = New System.Drawing.Point(64, 119)
        Me.Core.Name = "Core"
        Me.Core.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Core.Size = New System.Drawing.Size(193, 17)
        Me.Core.TabIndex = 17
        Me.Core.Text = "Core:"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line1.Location = New System.Drawing.Point(8, 23)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(296, 1)
        Me.Line1.TabIndex = 19
        '
        '_Header5_0
        '
        Me._Header5_0.BackColor = System.Drawing.SystemColors.Control
        Me._Header5_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Header5_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Header5_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header5.SetIndex(Me._Header5_0, CType(0, Short))
        Me._Header5_0.Location = New System.Drawing.Point(8, 95)
        Me._Header5_0.Name = "_Header5_0"
        Me._Header5_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Header5_0.Size = New System.Drawing.Size(289, 17)
        Me._Header5_0.TabIndex = 16
        Me._Header5_0.Text = "www.ballardtech.com or email support@ballardtech.com"
        '
        '_Header4_1
        '
        Me._Header4_1.BackColor = System.Drawing.SystemColors.Control
        Me._Header4_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Header4_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Header4_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header4.SetIndex(Me._Header4_1, CType(1, Short))
        Me._Header4_1.Location = New System.Drawing.Point(8, 79)
        Me._Header4_1.Name = "_Header4_1"
        Me._Header4_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Header4_1.Size = New System.Drawing.Size(289, 17)
        Me._Header4_1.TabIndex = 15
        Me._Header4_1.Text = "All rights reserved."
        '
        '_Heade3_1
        '
        Me._Heade3_1.BackColor = System.Drawing.SystemColors.Control
        Me._Heade3_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Heade3_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Heade3_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Heade3.SetIndex(Me._Heade3_1, CType(1, Short))
        Me._Heade3_1.Location = New System.Drawing.Point(8, 63)
        Me._Heade3_1.Name = "_Heade3_1"
        Me._Heade3_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Heade3_1.Size = New System.Drawing.Size(289, 17)
        Me._Heade3_1.TabIndex = 14
        Me._Heade3_1.Text = "Ballard Technology, Inc. Everett, WA, USA."
        '
        '_Header2_0
        '
        Me._Header2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Header2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Header2_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Header2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header2.SetIndex(Me._Header2_0, CType(0, Short))
        Me._Header2_0.Location = New System.Drawing.Point(8, 31)
        Me._Header2_0.Name = "_Header2_0"
        Me._Header2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Header2_0.Size = New System.Drawing.Size(289, 17)
        Me._Header2_0.TabIndex = 13
        Me._Header2_0.Text = "VB.NET BTI1553 EXAMPLE 17"
        '
        'Channel
        '
        Me.Channel.BackColor = System.Drawing.SystemColors.Control
        Me.Channel.Cursor = System.Windows.Forms.Cursors.Default
        Me.Channel.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Channel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Channel.Location = New System.Drawing.Point(64, 136)
        Me.Channel.Name = "Channel"
        Me.Channel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Channel.Size = New System.Drawing.Size(193, 17)
        Me.Channel.TabIndex = 12
        Me.Channel.Text = "Channel (Parametric):"
        '
        'Line2
        '
        Me.Line2.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line2.Location = New System.Drawing.Point(8, 116)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(296, 1)
        Me.Line2.TabIndex = 20
        '
        '_Header1_1
        '
        Me._Header1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Header1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Header1_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Header1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header1.SetIndex(Me._Header1_1, CType(1, Short))
        Me._Header1_1.Location = New System.Drawing.Point(80, 0)
        Me._Header1_1.Name = "_Header1_1"
        Me._Header1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Header1_1.Size = New System.Drawing.Size(153, 17)
        Me._Header1_1.TabIndex = 11
        Me._Header1_1.Text = "Parametrics example."
        '
        'Line3
        '
        Me.Line3.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line3.Location = New System.Drawing.Point(8, 160)
        Me.Line3.Name = "Line3"
        Me.Line3.Size = New System.Drawing.Size(296, 1)
        Me.Line3.TabIndex = 21
        '
        'Line5
        '
        Me.Line5.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line5.Location = New System.Drawing.Point(8, 256)
        Me.Line5.Name = "Line5"
        Me.Line5.Size = New System.Drawing.Size(288, 1)
        Me.Line5.TabIndex = 22
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(8, 168)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Amplitude:"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(160, 168)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(136, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Mid-Bid Error Offset"
        '
        'DacText
        '
        Me.DacText.BackColor = System.Drawing.SystemColors.Control
        Me.DacText.Cursor = System.Windows.Forms.Cursors.Default
        Me.DacText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DacText.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DacText.Location = New System.Drawing.Point(8, 184)
        Me.DacText.Name = "DacText"
        Me.DacText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DacText.Size = New System.Drawing.Size(89, 17)
        Me.DacText.TabIndex = 8
        Me.DacText.Text = "Dac = "
        '
        'OffsetText
        '
        Me.OffsetText.BackColor = System.Drawing.SystemColors.Control
        Me.OffsetText.Cursor = System.Windows.Forms.Cursors.Default
        Me.OffsetText.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OffsetText.ForeColor = System.Drawing.SystemColors.ControlText
        Me.OffsetText.Location = New System.Drawing.Point(160, 184)
        Me.OffsetText.Name = "OffsetText"
        Me.OffsetText.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OffsetText.Size = New System.Drawing.Size(137, 17)
        Me.OffsetText.TabIndex = 7
        Me.OffsetText.Text = "Offset = "
        '
        'Line4
        '
        Me.Line4.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line4.Location = New System.Drawing.Point(144, 160)
        Me.Line4.Name = "Line4"
        Me.Line4.Size = New System.Drawing.Size(1, 96)
        Me.Line4.TabIndex = 23
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(313, 302)
        Me.Controls.Add(Me.cmdStart)
        Me.Controls.Add(Me.cmdStop)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.CmdDown)
        Me.Controls.Add(Me.CmdUp)
        Me.Controls.Add(Me.CmdLeft)
        Me.Controls.Add(Me.CmdRight)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Core)
        Me.Controls.Add(Me.Line1)
        Me.Controls.Add(Me._Header5_0)
        Me.Controls.Add(Me._Header4_1)
        Me.Controls.Add(Me._Heade3_1)
        Me.Controls.Add(Me._Header2_0)
        Me.Controls.Add(Me.Channel)
        Me.Controls.Add(Me.Line2)
        Me.Controls.Add(Me._Header1_1)
        Me.Controls.Add(Me.Line3)
        Me.Controls.Add(Me.Line5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DacText)
        Me.Controls.Add(Me.OffsetText)
        Me.Controls.Add(Me.Line4)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "BTI1553 Example 17"
        CType(Me.Heade3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Header1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Header2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Header4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Header5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class