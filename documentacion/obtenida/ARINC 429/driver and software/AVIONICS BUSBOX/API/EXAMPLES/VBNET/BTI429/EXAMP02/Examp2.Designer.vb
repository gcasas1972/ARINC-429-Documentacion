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
	Public WithEvents cmdExit As System.Windows.Forms.Button
	Public WithEvents Timer1 As System.Windows.Forms.Timer
	Public WithEvents CmdStop As System.Windows.Forms.Button
	Public WithEvents CmdStart As System.Windows.Forms.Button
	Public WithEvents Transmit As System.Windows.Forms.Label
	Public WithEvents airspeed As System.Windows.Forms.Label
	Public WithEvents temp As System.Windows.Forms.Label
	Public WithEvents altitude As System.Windows.Forms.Label
	Public WithEvents Line5 As System.Windows.Forms.Label
	Public WithEvents Line4 As System.Windows.Forms.Label
    Public WithEvents _Header2_0 As System.Windows.Forms.Label
	Public WithEvents _Header1_1 As System.Windows.Forms.Label
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
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdExit = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CmdStop = New System.Windows.Forms.Button
        Me.CmdStart = New System.Windows.Forms.Button
        Me.Transmit = New System.Windows.Forms.Label
        Me.airspeed = New System.Windows.Forms.Label
        Me.temp = New System.Windows.Forms.Label
        Me.altitude = New System.Windows.Forms.Label
        Me.Line5 = New System.Windows.Forms.Label
        Me.Line4 = New System.Windows.Forms.Label
        Me._Header2_0 = New System.Windows.Forms.Label
        Me._Header1_1 = New System.Windows.Forms.Label
        Me.Core = New System.Windows.Forms.Label
        Me.Heade3 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.Header1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.Header2 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.Header4 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me.Header5 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(Me.components)
        Me._Header5_0 = New System.Windows.Forms.Label
        Me._Header4_1 = New System.Windows.Forms.Label
        Me._Heade3_1 = New System.Windows.Forms.Label
        Me.Line3 = New System.Windows.Forms.Label
        CType(Me.Heade3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Header1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Header2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Header4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Header5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdExit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdExit.Location = New System.Drawing.Point(256, 272)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdExit.Size = New System.Drawing.Size(49, 25)
        Me.cmdExit.TabIndex = 2
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 500
        '
        'CmdStop
        '
        Me.CmdStop.BackColor = System.Drawing.SystemColors.Control
        Me.CmdStop.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdStop.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdStop.Location = New System.Drawing.Point(72, 272)
        Me.CmdStop.Name = "CmdStop"
        Me.CmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdStop.Size = New System.Drawing.Size(49, 25)
        Me.CmdStop.TabIndex = 1
        Me.CmdStop.Text = "Stop"
        Me.CmdStop.UseVisualStyleBackColor = False
        '
        'CmdStart
        '
        Me.CmdStart.BackColor = System.Drawing.SystemColors.Control
        Me.CmdStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdStart.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdStart.Location = New System.Drawing.Point(8, 272)
        Me.CmdStart.Name = "CmdStart"
        Me.CmdStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdStart.Size = New System.Drawing.Size(49, 25)
        Me.CmdStart.TabIndex = 0
        Me.CmdStart.Text = "Start"
        Me.CmdStart.UseVisualStyleBackColor = False
        '
        'Transmit
        '
        Me.Transmit.BackColor = System.Drawing.SystemColors.Control
        Me.Transmit.Cursor = System.Windows.Forms.Cursors.Default
        Me.Transmit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Transmit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Transmit.Location = New System.Drawing.Point(71, 130)
        Me.Transmit.Name = "Transmit"
        Me.Transmit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Transmit.Size = New System.Drawing.Size(193, 17)
        Me.Transmit.TabIndex = 13
        Me.Transmit.Text = "Transmit:"
        '
        'airspeed
        '
        Me.airspeed.BackColor = System.Drawing.SystemColors.Control
        Me.airspeed.Cursor = System.Windows.Forms.Cursors.Default
        Me.airspeed.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.airspeed.ForeColor = System.Drawing.SystemColors.ControlText
        Me.airspeed.Location = New System.Drawing.Point(56, 184)
        Me.airspeed.Name = "airspeed"
        Me.airspeed.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.airspeed.Size = New System.Drawing.Size(185, 17)
        Me.airspeed.TabIndex = 12
        Me.airspeed.Text = "comp_airspeed"
        '
        'temp
        '
        Me.temp.BackColor = System.Drawing.SystemColors.Control
        Me.temp.Cursor = System.Windows.Forms.Cursors.Default
        Me.temp.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.temp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.temp.Location = New System.Drawing.Point(56, 212)
        Me.temp.Name = "temp"
        Me.temp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.temp.Size = New System.Drawing.Size(185, 17)
        Me.temp.TabIndex = 11
        Me.temp.Text = "tot_air_temp"
        '
        'altitude
        '
        Me.altitude.BackColor = System.Drawing.SystemColors.Control
        Me.altitude.Cursor = System.Windows.Forms.Cursors.Default
        Me.altitude.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.altitude.ForeColor = System.Drawing.SystemColors.ControlText
        Me.altitude.Location = New System.Drawing.Point(56, 240)
        Me.altitude.Name = "altitude"
        Me.altitude.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.altitude.Size = New System.Drawing.Size(185, 17)
        Me.altitude.TabIndex = 10
        Me.altitude.Text = "altitude_rate"
        '
        'Line5
        '
        Me.Line5.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line5.Location = New System.Drawing.Point(9, 24)
        Me.Line5.Name = "Line5"
        Me.Line5.Size = New System.Drawing.Size(296, 1)
        Me.Line5.TabIndex = 14
        '
        'Line4
        '
        Me.Line4.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line4.Location = New System.Drawing.Point(9, 98)
        Me.Line4.Name = "Line4"
        Me.Line4.Size = New System.Drawing.Size(296, 1)
        Me.Line4.TabIndex = 15
        '
        '_Header2_0
        '
        Me._Header2_0.BackColor = System.Drawing.SystemColors.Control
        Me._Header2_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Header2_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Header2_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header2.SetIndex(Me._Header2_0, CType(0, Short))
        Me._Header2_0.Location = New System.Drawing.Point(8, 32)
        Me._Header2_0.Name = "_Header2_0"
        Me._Header2_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Header2_0.Size = New System.Drawing.Size(289, 17)
        Me._Header2_0.TabIndex = 6
        Me._Header2_0.Text = "VB.NET BTI429 EXAMP2"
        '
        '_Header1_1
        '
        Me._Header1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Header1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Header1_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Header1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header1.SetIndex(Me._Header1_1, CType(1, Short))
        Me._Header1_1.Location = New System.Drawing.Point(92, 3)
        Me._Header1_1.Name = "_Header1_1"
        Me._Header1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Header1_1.Size = New System.Drawing.Size(129, 17)
        Me._Header1_1.TabIndex = 5
        Me._Header1_1.Text = "Transmit Example"
        Me._Header1_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Core
        '
        Me.Core.BackColor = System.Drawing.SystemColors.Control
        Me.Core.Cursor = System.Windows.Forms.Cursors.Default
        Me.Core.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Core.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Core.Location = New System.Drawing.Point(71, 114)
        Me.Core.Name = "Core"
        Me.Core.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Core.Size = New System.Drawing.Size(193, 17)
        Me.Core.TabIndex = 3
        Me.Core.Text = "Core"
        '
        '_Header5_0
        '
        Me._Header5_0.BackColor = System.Drawing.SystemColors.Control
        Me._Header5_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._Header5_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Header5_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Header5_0.Location = New System.Drawing.Point(8, 77)
        Me._Header5_0.Name = "_Header5_0"
        Me._Header5_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Header5_0.Size = New System.Drawing.Size(289, 17)
        Me._Header5_0.TabIndex = 27
        Me._Header5_0.Text = "www.ballardtech.com or email support@ballardtech.com"
        '
        '_Header4_1
        '
        Me._Header4_1.BackColor = System.Drawing.SystemColors.Control
        Me._Header4_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Header4_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Header4_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Header4_1.Location = New System.Drawing.Point(8, 62)
        Me._Header4_1.Name = "_Header4_1"
        Me._Header4_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Header4_1.Size = New System.Drawing.Size(289, 17)
        Me._Header4_1.TabIndex = 26
        Me._Header4_1.Text = "All rights reserved."
        '
        '_Heade3_1
        '
        Me._Heade3_1.BackColor = System.Drawing.SystemColors.Control
        Me._Heade3_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Heade3_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Heade3_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Heade3_1.Location = New System.Drawing.Point(8, 47)
        Me._Heade3_1.Name = "_Heade3_1"
        Me._Heade3_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Heade3_1.Size = New System.Drawing.Size(289, 17)
        Me._Heade3_1.TabIndex = 25
        Me._Heade3_1.Text = "Ballard Technology, Inc. Everett, WA, USA."
        '
        'Line3
        '
        Me.Line3.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line3.Location = New System.Drawing.Point(9, 163)
        Me.Line3.Name = "Line3"
        Me.Line3.Size = New System.Drawing.Size(296, 1)
        Me.Line3.TabIndex = 33
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(314, 304)
        Me.Controls.Add(Me.Line3)
        Me.Controls.Add(Me._Header5_0)
        Me.Controls.Add(Me._Header4_1)
        Me.Controls.Add(Me._Heade3_1)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.CmdStop)
        Me.Controls.Add(Me.CmdStart)
        Me.Controls.Add(Me.Transmit)
        Me.Controls.Add(Me.airspeed)
        Me.Controls.Add(Me.temp)
        Me.Controls.Add(Me.altitude)
        Me.Controls.Add(Me.Line5)
        Me.Controls.Add(Me.Line4)
        Me.Controls.Add(Me._Header2_0)
        Me.Controls.Add(Me._Header1_1)
        Me.Controls.Add(Me.Core)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(330, 340)
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "BTI429 Example 2"
        CType(Me.Heade3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Header1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Header2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Header4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Header5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents _Header5_0 As System.Windows.Forms.Label
    Public WithEvents _Header4_1 As System.Windows.Forms.Label
    Public WithEvents _Heade3_1 As System.Windows.Forms.Label
    Public WithEvents Line3 As System.Windows.Forms.Label
#End Region 
End Class