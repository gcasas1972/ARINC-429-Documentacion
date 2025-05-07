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
	Public WithEvents Timer1 As System.Windows.Forms.Timer
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents _Header2_0 As System.Windows.Forms.Label
    Public WithEvents _Header4_1 As System.Windows.Forms.Label
	Public WithEvents _Header5_0 As System.Windows.Forms.Label
	Public WithEvents Core As System.Windows.Forms.Label
	Public WithEvents _Header1_1 As System.Windows.Forms.Label
	Public WithEvents Line1 As System.Windows.Forms.Label
	Public WithEvents Line2 As System.Windows.Forms.Label
	Public WithEvents Transmit As System.Windows.Forms.Label
	Public WithEvents Receive As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
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
        Me.cmdStart = New System.Windows.Forms.Button
        Me.cmdStop = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me._Header2_0 = New System.Windows.Forms.Label
        Me._Header4_1 = New System.Windows.Forms.Label
        Me._Header5_0 = New System.Windows.Forms.Label
        Me.Core = New System.Windows.Forms.Label
        Me._Header1_1 = New System.Windows.Forms.Label
        Me.Line1 = New System.Windows.Forms.Label
        Me.Line2 = New System.Windows.Forms.Label
        Me.Transmit = New System.Windows.Forms.Label
        Me.Receive = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
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
        Me.cmdStart.Location = New System.Drawing.Point(8, 252)
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
        Me.cmdStop.Location = New System.Drawing.Point(64, 252)
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
        Me.cmdExit.Location = New System.Drawing.Point(256, 252)
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
        Me.Timer1.Interval = 500
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(8, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(297, 19)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Ballard Technology, Inc. Everett, WA, USA."
        '
        '_Header2_0
        '
        Me._Header2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Header2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Header2_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Header2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header2.SetIndex(Me._Header2_0, CType(0, Short))
        Me._Header2_0.Location = New System.Drawing.Point(8, 40)
        Me._Header2_0.Name = "_Header2_0"
        Me._Header2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Header2_0.Size = New System.Drawing.Size(289, 17)
        Me._Header2_0.TabIndex = 12
        Me._Header2_0.Text = "VB.NET BTI429 EXAMP4"
        '
        '_Header4_1
        '
        Me._Header4_1.BackColor = System.Drawing.SystemColors.Control
        Me._Header4_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Header4_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Header4_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header4.SetIndex(Me._Header4_1, CType(1, Short))
        Me._Header4_1.Location = New System.Drawing.Point(8, 71)
        Me._Header4_1.Name = "_Header4_1"
        Me._Header4_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Header4_1.Size = New System.Drawing.Size(297, 19)
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
        Me._Header5_0.Location = New System.Drawing.Point(8, 87)
        Me._Header5_0.Name = "_Header5_0"
        Me._Header5_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Header5_0.Size = New System.Drawing.Size(297, 19)
        Me._Header5_0.TabIndex = 9
        Me._Header5_0.Text = "www.ballardtech.com or email support@ballardtech.com"
        '
        'Core
        '
        Me.Core.BackColor = System.Drawing.SystemColors.Control
        Me.Core.Cursor = System.Windows.Forms.Cursors.Default
        Me.Core.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Core.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Core.Location = New System.Drawing.Point(48, 120)
        Me.Core.Name = "Core"
        Me.Core.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Core.Size = New System.Drawing.Size(193, 17)
        Me.Core.TabIndex = 8
        Me.Core.Text = "Core:"
        '
        '_Header1_1
        '
        Me._Header1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Header1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Header1_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Header1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header1.SetIndex(Me._Header1_1, CType(1, Short))
        Me._Header1_1.Location = New System.Drawing.Point(36, 8)
        Me._Header1_1.Name = "_Header1_1"
        Me._Header1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Header1_1.Size = New System.Drawing.Size(241, 17)
        Me._Header1_1.TabIndex = 7
        Me._Header1_1.Text = "Explicit Message Timing Example"
        Me._Header1_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line1.Location = New System.Drawing.Point(8, 32)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(296, 1)
        Me.Line1.TabIndex = 14
        '
        'Line2
        '
        Me.Line2.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line2.Location = New System.Drawing.Point(8, 108)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(296, 1)
        Me.Line2.TabIndex = 15
        '
        'Transmit
        '
        Me.Transmit.BackColor = System.Drawing.SystemColors.Control
        Me.Transmit.Cursor = System.Windows.Forms.Cursors.Default
        Me.Transmit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Transmit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Transmit.Location = New System.Drawing.Point(48, 157)
        Me.Transmit.Name = "Transmit"
        Me.Transmit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Transmit.Size = New System.Drawing.Size(193, 17)
        Me.Transmit.TabIndex = 6
        Me.Transmit.Text = "Transmit:"
        '
        'Receive
        '
        Me.Receive.BackColor = System.Drawing.SystemColors.Control
        Me.Receive.Cursor = System.Windows.Forms.Cursors.Default
        Me.Receive.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Receive.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Receive.Location = New System.Drawing.Point(48, 138)
        Me.Receive.Name = "Receive"
        Me.Receive.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Receive.Size = New System.Drawing.Size(193, 17)
        Me.Receive.TabIndex = 5
        Me.Receive.Text = "Receive:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(24, 189)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(249, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Airspeed:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(24, 213)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(249, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Altitude:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(314, 284)
        Me.Controls.Add(Me.cmdStart)
        Me.Controls.Add(Me.cmdStop)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me._Header2_0)
        Me.Controls.Add(Me._Header4_1)
        Me.Controls.Add(Me._Header5_0)
        Me.Controls.Add(Me.Core)
        Me.Controls.Add(Me._Header1_1)
        Me.Controls.Add(Me.Line1)
        Me.Controls.Add(Me.Line2)
        Me.Controls.Add(Me.Transmit)
        Me.Controls.Add(Me.Receive)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(330, 320)
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "BTI429 Example 4"
        CType(Me.Heade3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Header1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Header2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Header4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Header5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class