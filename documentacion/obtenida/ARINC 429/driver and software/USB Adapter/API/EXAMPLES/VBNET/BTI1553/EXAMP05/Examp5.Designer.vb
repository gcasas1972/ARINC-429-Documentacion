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
	Public WithEvents CmdExit As System.Windows.Forms.Button
	Public WithEvents CmdStart As System.Windows.Forms.Button
	Public WithEvents CmdStop As System.Windows.Forms.Button
	Public WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents Line1 As System.Windows.Forms.Label
	Public WithEvents Result2 As System.Windows.Forms.Label
	Public WithEvents ChanLbl As System.Windows.Forms.Label
	Public WithEvents Header4 As System.Windows.Forms.Label
	Public WithEvents Header3 As System.Windows.Forms.Label
	Public WithEvents Header2 As System.Windows.Forms.Label
	Public WithEvents Header1 As System.Windows.Forms.Label
	Public WithEvents Result1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CmdExit = New System.Windows.Forms.Button
        Me.CmdStart = New System.Windows.Forms.Button
        Me.CmdStop = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Line1 = New System.Windows.Forms.Label
        Me.Result2 = New System.Windows.Forms.Label
        Me.ChanLbl = New System.Windows.Forms.Label
        Me.Header4 = New System.Windows.Forms.Label
        Me.Header3 = New System.Windows.Forms.Label
        Me.Header2 = New System.Windows.Forms.Label
        Me.Header1 = New System.Windows.Forms.Label
        Me.Result1 = New System.Windows.Forms.Label
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.CmdAssync = New System.Windows.Forms.Button
        Me.CoreLbl = New System.Windows.Forms.Label
        Me._Header1_1 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me._Heade3_1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'CmdExit
        '
        Me.CmdExit.BackColor = System.Drawing.SystemColors.Control
        Me.CmdExit.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdExit.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdExit.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdExit.Location = New System.Drawing.Point(302, 436)
        Me.CmdExit.Name = "CmdExit"
        Me.CmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdExit.Size = New System.Drawing.Size(49, 25)
        Me.CmdExit.TabIndex = 2
        Me.CmdExit.Text = "Exit"
        Me.CmdExit.UseVisualStyleBackColor = False
        '
        'CmdStart
        '
        Me.CmdStart.BackColor = System.Drawing.SystemColors.Control
        Me.CmdStart.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdStart.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdStart.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdStart.Location = New System.Drawing.Point(21, 436)
        Me.CmdStart.Name = "CmdStart"
        Me.CmdStart.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdStart.Size = New System.Drawing.Size(49, 25)
        Me.CmdStart.TabIndex = 1
        Me.CmdStart.Text = "Start"
        Me.CmdStart.UseVisualStyleBackColor = False
        '
        'CmdStop
        '
        Me.CmdStop.BackColor = System.Drawing.SystemColors.Control
        Me.CmdStop.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdStop.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdStop.Location = New System.Drawing.Point(71, 436)
        Me.CmdStop.Name = "CmdStop"
        Me.CmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdStop.Size = New System.Drawing.Size(49, 25)
        Me.CmdStop.TabIndex = 0
        Me.CmdStop.Text = "Stop"
        Me.CmdStop.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line1.Location = New System.Drawing.Point(24, 125)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(328, 1)
        Me.Line1.TabIndex = 4
        '
        'Result2
        '
        Me.Result2.BackColor = System.Drawing.SystemColors.Control
        Me.Result2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Result2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Result2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Result2.Location = New System.Drawing.Point(48, 186)
        Me.Result2.Name = "Result2"
        Me.Result2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Result2.Size = New System.Drawing.Size(281, 17)
        Me.Result2.TabIndex = 10
        Me.Result2.Text = "Result2"
        '
        'ChanLbl
        '
        Me.ChanLbl.BackColor = System.Drawing.SystemColors.Control
        Me.ChanLbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.ChanLbl.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChanLbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ChanLbl.Location = New System.Drawing.Point(48, 152)
        Me.ChanLbl.Name = "ChanLbl"
        Me.ChanLbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChanLbl.Size = New System.Drawing.Size(281, 17)
        Me.ChanLbl.TabIndex = 9
        Me.ChanLbl.Text = "ChanLbl"
        '
        'Header4
        '
        Me.Header4.BackColor = System.Drawing.SystemColors.Control
        Me.Header4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Header4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Header4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header4.Location = New System.Drawing.Point(45, 40)
        Me.Header4.Name = "Header4"
        Me.Header4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Header4.Size = New System.Drawing.Size(241, 17)
        Me.Header4.TabIndex = 8
        Me.Header4.Text = "VB.NET BTI1553 EXAMPLE 5"
        '
        'Header3
        '
        Me.Header3.BackColor = System.Drawing.SystemColors.Control
        Me.Header3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Header3.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Header3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header3.Location = New System.Drawing.Point(45, 108)
        Me.Header3.Name = "Header3"
        Me.Header3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Header3.Size = New System.Drawing.Size(291, 17)
        Me.Header3.TabIndex = 7
        Me.Header3.Text = "www.ballardtech.com or email support@ballardtech.com"
        '
        'Header2
        '
        Me.Header2.BackColor = System.Drawing.SystemColors.Control
        Me.Header2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Header2.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Header2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header2.Location = New System.Drawing.Point(45, 91)
        Me.Header2.Name = "Header2"
        Me.Header2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Header2.Size = New System.Drawing.Size(281, 17)
        Me.Header2.TabIndex = 6
        Me.Header2.Text = "All rights reserved."
        '
        'Header1
        '
        Me.Header1.BackColor = System.Drawing.SystemColors.Control
        Me.Header1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Header1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Header1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Header1.Location = New System.Drawing.Point(45, 74)
        Me.Header1.Name = "Header1"
        Me.Header1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Header1.Size = New System.Drawing.Size(291, 17)
        Me.Header1.TabIndex = 5
        Me.Header1.Text = "Ballard Technology, Inc. Everett, WA, USA."
        '
        'Result1
        '
        Me.Result1.BackColor = System.Drawing.SystemColors.Control
        Me.Result1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Result1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Result1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Result1.Location = New System.Drawing.Point(48, 169)
        Me.Result1.Name = "Result1"
        Me.Result1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Result1.Size = New System.Drawing.Size(281, 17)
        Me.Result1.TabIndex = 4
        Me.Result1.Text = "Result1"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 14
        Me.ListBox1.Location = New System.Drawing.Point(23, 204)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(328, 228)
        Me.ListBox1.TabIndex = 11
        '
        'CmdAssync
        '
        Me.CmdAssync.Location = New System.Drawing.Point(162, 436)
        Me.CmdAssync.Name = "CmdAssync"
        Me.CmdAssync.Size = New System.Drawing.Size(101, 25)
        Me.CmdAssync.TabIndex = 12
        Me.CmdAssync.Text = "Transmit Msg"
        Me.CmdAssync.UseVisualStyleBackColor = True
        '
        'CoreLbl
        '
        Me.CoreLbl.BackColor = System.Drawing.SystemColors.Control
        Me.CoreLbl.Cursor = System.Windows.Forms.Cursors.Default
        Me.CoreLbl.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CoreLbl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CoreLbl.Location = New System.Drawing.Point(48, 135)
        Me.CoreLbl.Name = "CoreLbl"
        Me.CoreLbl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CoreLbl.Size = New System.Drawing.Size(281, 17)
        Me.CoreLbl.TabIndex = 13
        Me.CoreLbl.Text = "CoreLbl"
        '
        '_Header1_1
        '
        Me._Header1_1.BackColor = System.Drawing.SystemColors.Control
        Me._Header1_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Header1_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Header1_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Header1_1.Location = New System.Drawing.Point(39, 9)
        Me._Header1_1.Name = "_Header1_1"
        Me._Header1_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Header1_1.Size = New System.Drawing.Size(297, 17)
        Me._Header1_1.TabIndex = 14
        Me._Header1_1.Text = "Simultaneous BC, RT, and monitor simulation"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.WindowText
        Me.Label1.Location = New System.Drawing.Point(23, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(328, 1)
        Me.Label1.TabIndex = 15
        '
        '_Heade3_1
        '
        Me._Heade3_1.BackColor = System.Drawing.SystemColors.Control
        Me._Heade3_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._Heade3_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Heade3_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._Heade3_1.Location = New System.Drawing.Point(45, 57)
        Me._Heade3_1.Name = "_Heade3_1"
        Me._Heade3_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._Heade3_1.Size = New System.Drawing.Size(289, 17)
        Me._Heade3_1.TabIndex = 16
        Me._Heade3_1.Text = "Copyright 2009-2011"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(374, 474)
        Me.Controls.Add(Me._Heade3_1)
        Me.Controls.Add(Me._Header1_1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CoreLbl)
        Me.Controls.Add(Me.CmdAssync)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.CmdExit)
        Me.Controls.Add(Me.CmdStart)
        Me.Controls.Add(Me.CmdStop)
        Me.Controls.Add(Me.Line1)
        Me.Controls.Add(Me.Result2)
        Me.Controls.Add(Me.ChanLbl)
        Me.Controls.Add(Me.Header4)
        Me.Controls.Add(Me.Header3)
        Me.Controls.Add(Me.Header2)
        Me.Controls.Add(Me.Header1)
        Me.Controls.Add(Me.Result1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.MinimumSize = New System.Drawing.Size(390, 510)
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BTI1553 Example 5"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents CmdAssync As System.Windows.Forms.Button
    Public WithEvents CoreLbl As System.Windows.Forms.Label
    Public WithEvents _Header1_1 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents _Heade3_1 As System.Windows.Forms.Label
#End Region
End Class