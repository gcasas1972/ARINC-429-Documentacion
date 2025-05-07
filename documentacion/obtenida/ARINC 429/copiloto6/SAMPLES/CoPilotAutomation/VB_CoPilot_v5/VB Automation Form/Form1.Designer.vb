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
			Static fTerminateCalled As Boolean
			If Not fTerminateCalled Then
				Form_Terminate_renamed()
				fTerminateCalled = True
			End If
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
	Public CommonDialog1Open As System.Windows.Forms.OpenFileDialog
	Public WithEvents Timer1 As System.Windows.Forms.Timer
	Public WithEvents CmdMonitor As System.Windows.Forms.Button
	Public WithEvents MonRecList As System.Windows.Forms.ListBox
	Public WithEvents Combo1 As System.Windows.Forms.ComboBox
	Public WithEvents OutputList As System.Windows.Forms.ListBox
	Public WithEvents _CmdOpen_1 As System.Windows.Forms.Button
	Public WithEvents _CmdStop_1 As System.Windows.Forms.Button
	Public WithEvents _CmdRun_0 As System.Windows.Forms.Button
	Public WithEvents TextStatus As System.Windows.Forms.TextBox
	Public WithEvents Line1 As System.Windows.Forms.Label
	Public WithEvents CmdOpen As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
	Public WithEvents CmdRun As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
	Public WithEvents CmdStop As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
	Public WithEvents MenuFileExit As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MenuFile As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MenuProjectOpen As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MenuProjectRun As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MenuProjectStop As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MenuProject As System.Windows.Forms.ToolStripMenuItem
	Public WithEvents MainMenu1 As System.Windows.Forms.MenuStrip
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CmdMonitor = New System.Windows.Forms.Button
        Me.MonRecList = New System.Windows.Forms.ListBox
        Me.Combo1 = New System.Windows.Forms.ComboBox
        Me.OutputList = New System.Windows.Forms.ListBox
        Me._CmdOpen_1 = New System.Windows.Forms.Button
        Me._CmdStop_1 = New System.Windows.Forms.Button
        Me._CmdRun_0 = New System.Windows.Forms.Button
        Me.TextStatus = New System.Windows.Forms.TextBox
        Me.Line1 = New System.Windows.Forms.Label
        Me.CmdOpen = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.CmdRun = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.CmdStop = New Microsoft.VisualBasic.Compatibility.VB6.ButtonArray(Me.components)
        Me.MainMenu1 = New System.Windows.Forms.MenuStrip
        Me.MenuFile = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuFileExit = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuProject = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuProjectOpen = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuProjectRun = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuProjectStop = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.CmdOpen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmdRun, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmdStop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MainMenu1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'CmdMonitor
        '
        Me.CmdMonitor.BackColor = System.Drawing.SystemColors.Control
        Me.CmdMonitor.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmdMonitor.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdMonitor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdMonitor.Location = New System.Drawing.Point(176, 58)
        Me.CmdMonitor.Name = "CmdMonitor"
        Me.CmdMonitor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdMonitor.Size = New System.Drawing.Size(241, 17)
        Me.CmdMonitor.TabIndex = 7
        Me.CmdMonitor.Text = "Read Monitor"
        Me.CmdMonitor.UseVisualStyleBackColor = False
        '
        'MonRecList
        '
        Me.MonRecList.BackColor = System.Drawing.Color.White
        Me.MonRecList.Cursor = System.Windows.Forms.Cursors.Default
        Me.MonRecList.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MonRecList.ForeColor = System.Drawing.Color.Black
        Me.MonRecList.ItemHeight = 14
        Me.MonRecList.Location = New System.Drawing.Point(176, 82)
        Me.MonRecList.Name = "MonRecList"
        Me.MonRecList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MonRecList.Size = New System.Drawing.Size(241, 158)
        Me.MonRecList.TabIndex = 6
        '
        'Combo1
        '
        Me.Combo1.BackColor = System.Drawing.Color.Black
        Me.Combo1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Combo1.ForeColor = System.Drawing.Color.White
        Me.Combo1.Location = New System.Drawing.Point(8, 58)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Combo1.Size = New System.Drawing.Size(161, 22)
        Me.Combo1.TabIndex = 5
        '
        'OutputList
        '
        Me.OutputList.BackColor = System.Drawing.Color.White
        Me.OutputList.Cursor = System.Windows.Forms.Cursors.Default
        Me.OutputList.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputList.ForeColor = System.Drawing.Color.Black
        Me.OutputList.ItemHeight = 14
        Me.OutputList.Location = New System.Drawing.Point(8, 82)
        Me.OutputList.Name = "OutputList"
        Me.OutputList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.OutputList.Size = New System.Drawing.Size(161, 158)
        Me.OutputList.TabIndex = 4
        '
        '_CmdOpen_1
        '
        Me._CmdOpen_1.BackColor = System.Drawing.SystemColors.Control
        Me._CmdOpen_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._CmdOpen_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._CmdOpen_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdOpen.SetIndex(Me._CmdOpen_1, CType(1, Short))
        Me._CmdOpen_1.Location = New System.Drawing.Point(8, 26)
        Me._CmdOpen_1.Name = "_CmdOpen_1"
        Me._CmdOpen_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._CmdOpen_1.Size = New System.Drawing.Size(41, 25)
        Me._CmdOpen_1.TabIndex = 3
        Me._CmdOpen_1.Text = "Open"
        Me._CmdOpen_1.UseVisualStyleBackColor = False
        '
        '_CmdStop_1
        '
        Me._CmdStop_1.BackColor = System.Drawing.SystemColors.Control
        Me._CmdStop_1.Cursor = System.Windows.Forms.Cursors.Default
        Me._CmdStop_1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._CmdStop_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdStop.SetIndex(Me._CmdStop_1, CType(1, Short))
        Me._CmdStop_1.Location = New System.Drawing.Point(120, 26)
        Me._CmdStop_1.Name = "_CmdStop_1"
        Me._CmdStop_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._CmdStop_1.Size = New System.Drawing.Size(41, 25)
        Me._CmdStop_1.TabIndex = 2
        Me._CmdStop_1.Text = "Stop"
        Me._CmdStop_1.UseVisualStyleBackColor = False
        '
        '_CmdRun_0
        '
        Me._CmdRun_0.BackColor = System.Drawing.SystemColors.Control
        Me._CmdRun_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._CmdRun_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._CmdRun_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdRun.SetIndex(Me._CmdRun_0, CType(0, Short))
        Me._CmdRun_0.Location = New System.Drawing.Point(64, 26)
        Me._CmdRun_0.Name = "_CmdRun_0"
        Me._CmdRun_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._CmdRun_0.Size = New System.Drawing.Size(41, 25)
        Me._CmdRun_0.TabIndex = 1
        Me._CmdRun_0.Text = "Run"
        Me._CmdRun_0.UseVisualStyleBackColor = False
        '
        'TextStatus
        '
        Me.TextStatus.AcceptsReturn = True
        Me.TextStatus.BackColor = System.Drawing.Color.Black
        Me.TextStatus.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextStatus.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextStatus.ForeColor = System.Drawing.Color.Red
        Me.TextStatus.Location = New System.Drawing.Point(176, 26)
        Me.TextStatus.MaxLength = 0
        Me.TextStatus.Name = "TextStatus"
        Me.TextStatus.ReadOnly = True
        Me.TextStatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextStatus.Size = New System.Drawing.Size(177, 20)
        Me.TextStatus.TabIndex = 0
        Me.TextStatus.Text = "Text1"
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.SystemColors.WindowText
        Me.Line1.Location = New System.Drawing.Point(0, 0)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(424, 1)
        Me.Line1.TabIndex = 8
        '
        'CmdOpen
        '
        '
        'CmdRun
        '
        '
        'CmdStop
        '
        '
        'MainMenu1
        '
        Me.MainMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuFile, Me.MenuProject})
        Me.MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu1.Name = "MainMenu1"
        Me.MainMenu1.Size = New System.Drawing.Size(425, 24)
        Me.MainMenu1.TabIndex = 9
        '
        'MenuFile
        '
        Me.MenuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuFileExit})
        Me.MenuFile.Name = "MenuFile"
        Me.MenuFile.Size = New System.Drawing.Size(37, 20)
        Me.MenuFile.Text = "File"
        '
        'MenuFileExit
        '
        Me.MenuFileExit.Name = "MenuFileExit"
        Me.MenuFileExit.Size = New System.Drawing.Size(92, 22)
        Me.MenuFileExit.Text = "Exit"
        '
        'MenuProject
        '
        Me.MenuProject.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuProjectOpen, Me.MenuProjectRun, Me.MenuProjectStop})
        Me.MenuProject.Name = "MenuProject"
        Me.MenuProject.Size = New System.Drawing.Size(56, 20)
        Me.MenuProject.Text = "Project"
        '
        'MenuProjectOpen
        '
        Me.MenuProjectOpen.Name = "MenuProjectOpen"
        Me.MenuProjectOpen.Size = New System.Drawing.Size(103, 22)
        Me.MenuProjectOpen.Text = "Open"
        '
        'MenuProjectRun
        '
        Me.MenuProjectRun.Name = "MenuProjectRun"
        Me.MenuProjectRun.Size = New System.Drawing.Size(103, 22)
        Me.MenuProjectRun.Text = "Run"
        '
        'MenuProjectStop
        '
        Me.MenuProjectStop.Name = "MenuProjectStop"
        Me.MenuProjectStop.Size = New System.Drawing.Size(103, 22)
        Me.MenuProjectStop.Text = "Stop"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(425, 255)
        Me.Controls.Add(Me.CmdMonitor)
        Me.Controls.Add(Me.MonRecList)
        Me.Controls.Add(Me.Combo1)
        Me.Controls.Add(Me.OutputList)
        Me.Controls.Add(Me._CmdOpen_1)
        Me.Controls.Add(Me._CmdStop_1)
        Me.Controls.Add(Me._CmdRun_0)
        Me.Controls.Add(Me.TextStatus)
        Me.Controls.Add(Me.Line1)
        Me.Controls.Add(Me.MainMenu1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(11, 49)
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "CoPilot Automation Form"
        CType(Me.CmdOpen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmdRun, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmdStop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MainMenu1.ResumeLayout(False)
        Me.MainMenu1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region 
End Class