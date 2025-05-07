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
	Public CommonDialog1Open As System.Windows.Forms.OpenFileDialog
	Public WithEvents CmdExit As System.Windows.Forms.Button
	Public WithEvents CmdStart As System.Windows.Forms.Button
	Public WithEvents CmdStop As System.Windows.Forms.Button
	Public WithEvents Timer1 As System.Windows.Forms.Timer
	Public WithEvents FileName As System.Windows.Forms.TextBox
	Public WithEvents CmdBrouse As System.Windows.Forms.Button
	Public WithEvents frequency As System.Windows.Forms.TextBox
	Public WithEvents blocksize As System.Windows.Forms.TextBox
	Public WithEvents Line2 As System.Windows.Forms.Label
	Public WithEvents _Header2_0 As System.Windows.Forms.Label
	Public WithEvents _Header4_1 As System.Windows.Forms.Label
	Public WithEvents _Header5_1 As System.Windows.Forms.Label
	Public WithEvents _Header6_0 As System.Windows.Forms.Label
	Public WithEvents Line1 As System.Windows.Forms.Label
	Public WithEvents Header3 As System.Windows.Forms.Label
	Public WithEvents _Header1_1 As System.Windows.Forms.Label
	Public WithEvents Core As System.Windows.Forms.Label
	Public WithEvents Result1 As System.Windows.Forms.Label
	Public WithEvents ChanLbl As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	Public WithEvents Result2 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label4 As System.Windows.Forms.Label
	Public WithEvents Label5 As System.Windows.Forms.Label
	Public WithEvents Header1 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Header2 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Header4 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Header5 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	Public WithEvents Header6 As Microsoft.VisualBasic.Compatibility.VB6.LabelArray
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
		Me.components = New System.ComponentModel.Container()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
		Me.CommonDialog1Open = New System.Windows.Forms.OpenFileDialog
		Me.CmdExit = New System.Windows.Forms.Button
		Me.CmdStart = New System.Windows.Forms.Button
		Me.CmdStop = New System.Windows.Forms.Button
		Me.Timer1 = New System.Windows.Forms.Timer(components)
		Me.FileName = New System.Windows.Forms.TextBox
		Me.CmdBrouse = New System.Windows.Forms.Button
		Me.frequency = New System.Windows.Forms.TextBox
		Me.blocksize = New System.Windows.Forms.TextBox
		Me.Line2 = New System.Windows.Forms.Label
		Me._Header2_0 = New System.Windows.Forms.Label
		Me._Header4_1 = New System.Windows.Forms.Label
		Me._Header5_1 = New System.Windows.Forms.Label
		Me._Header6_0 = New System.Windows.Forms.Label
		Me.Line1 = New System.Windows.Forms.Label
		Me.Header3 = New System.Windows.Forms.Label
		Me._Header1_1 = New System.Windows.Forms.Label
		Me.Core = New System.Windows.Forms.Label
		Me.Result1 = New System.Windows.Forms.Label
		Me.ChanLbl = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.Result2 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.Label4 = New System.Windows.Forms.Label
		Me.Label5 = New System.Windows.Forms.Label
		Me.Header1 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Header2 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Header4 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Header5 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.Header6 = New Microsoft.VisualBasic.Compatibility.VB6.LabelArray(components)
		Me.SuspendLayout()
		Me.ToolTip1.Active = True
		CType(Me.Header1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Header2, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Header4, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Header5, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.Header6, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Text = "BTI708 Example 5"
		Me.ClientSize = New System.Drawing.Size(465, 336)
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
		Me.CmdExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdExit.Text = "Exit"
		Me.CmdExit.Size = New System.Drawing.Size(49, 25)
		Me.CmdExit.Location = New System.Drawing.Point(408, 304)
		Me.CmdExit.TabIndex = 6
		Me.CmdExit.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CmdExit.BackColor = System.Drawing.SystemColors.Control
		Me.CmdExit.CausesValidation = True
		Me.CmdExit.Enabled = True
		Me.CmdExit.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdExit.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdExit.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdExit.TabStop = True
		Me.CmdExit.Name = "CmdExit"
		Me.CmdStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdStart.Text = "Start"
		Me.CmdStart.Size = New System.Drawing.Size(49, 25)
		Me.CmdStart.Location = New System.Drawing.Point(8, 304)
		Me.CmdStart.TabIndex = 5
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
		Me.CmdStop.Location = New System.Drawing.Point(64, 304)
		Me.CmdStop.TabIndex = 4
		Me.CmdStop.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CmdStop.BackColor = System.Drawing.SystemColors.Control
		Me.CmdStop.CausesValidation = True
		Me.CmdStop.Enabled = True
		Me.CmdStop.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdStop.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdStop.TabStop = True
		Me.CmdStop.Name = "CmdStop"
		Me.Timer1.Interval = 10
		Me.Timer1.Enabled = True
		Me.FileName.AutoSize = False
		Me.FileName.Size = New System.Drawing.Size(353, 27)
		Me.FileName.Location = New System.Drawing.Point(64, 256)
		Me.FileName.TabIndex = 3
		Me.FileName.Text = "EXAMP5.DAT"
		Me.ToolTip1.SetToolTip(Me.FileName, "file name or full path")
		Me.FileName.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FileName.AcceptsReturn = True
		Me.FileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.FileName.BackColor = System.Drawing.SystemColors.Window
		Me.FileName.CausesValidation = True
		Me.FileName.Enabled = True
		Me.FileName.ForeColor = System.Drawing.SystemColors.WindowText
		Me.FileName.HideSelection = True
		Me.FileName.ReadOnly = False
		Me.FileName.Maxlength = 0
		Me.FileName.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.FileName.MultiLine = False
		Me.FileName.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.FileName.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.FileName.TabStop = True
		Me.FileName.Visible = True
		Me.FileName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.FileName.Name = "FileName"
		Me.CmdBrouse.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.CmdBrouse.Text = "..."
		Me.CmdBrouse.Size = New System.Drawing.Size(33, 25)
		Me.CmdBrouse.Location = New System.Drawing.Point(424, 256)
		Me.CmdBrouse.TabIndex = 2
		Me.CmdBrouse.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CmdBrouse.BackColor = System.Drawing.SystemColors.Control
		Me.CmdBrouse.CausesValidation = True
		Me.CmdBrouse.Enabled = True
		Me.CmdBrouse.ForeColor = System.Drawing.SystemColors.ControlText
		Me.CmdBrouse.Cursor = System.Windows.Forms.Cursors.Default
		Me.CmdBrouse.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.CmdBrouse.TabStop = True
		Me.CmdBrouse.Name = "CmdBrouse"
		Me.frequency.AutoSize = False
		Me.frequency.Size = New System.Drawing.Size(49, 25)
		Me.frequency.Location = New System.Drawing.Point(104, 216)
		Me.frequency.TabIndex = 1
		Me.frequency.Text = "Text1"
		Me.frequency.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.frequency.AcceptsReturn = True
		Me.frequency.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.frequency.BackColor = System.Drawing.SystemColors.Window
		Me.frequency.CausesValidation = True
		Me.frequency.Enabled = True
		Me.frequency.ForeColor = System.Drawing.SystemColors.WindowText
		Me.frequency.HideSelection = True
		Me.frequency.ReadOnly = False
		Me.frequency.Maxlength = 0
		Me.frequency.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.frequency.MultiLine = False
		Me.frequency.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.frequency.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.frequency.TabStop = True
		Me.frequency.Visible = True
		Me.frequency.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.frequency.Name = "frequency"
		Me.blocksize.AutoSize = False
		Me.blocksize.Size = New System.Drawing.Size(73, 25)
		Me.blocksize.Location = New System.Drawing.Point(272, 216)
		Me.blocksize.TabIndex = 0
		Me.blocksize.Text = "Text2"
		Me.blocksize.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.blocksize.AcceptsReturn = True
		Me.blocksize.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.blocksize.BackColor = System.Drawing.SystemColors.Window
		Me.blocksize.CausesValidation = True
		Me.blocksize.Enabled = True
		Me.blocksize.ForeColor = System.Drawing.SystemColors.WindowText
		Me.blocksize.HideSelection = True
		Me.blocksize.ReadOnly = False
		Me.blocksize.Maxlength = 0
		Me.blocksize.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.blocksize.MultiLine = False
		Me.blocksize.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.blocksize.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.blocksize.TabStop = True
		Me.blocksize.Visible = True
		Me.blocksize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.blocksize.Name = "blocksize"
		Me.Line2.BackColor = System.Drawing.SystemColors.WindowText
		Me.Line2.Visible = True
		Me.Line2.Location = New System.Drawing.Point(84, 117)
		Me.Line2.Size = New System.Drawing.Size(296, 1)
		Me.Line2.Name = "Line2"
        Me._Header2_0.Text = "VB_EXAMP5    (06/07/2011)"
		Me._Header2_0.Size = New System.Drawing.Size(289, 17)
		Me._Header2_0.Location = New System.Drawing.Point(84, 32)
		Me._Header2_0.TabIndex = 21
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
		Me._Header4_1.Text = "Ballard Technology, Inc. Everett, WA, USA."
		Me._Header4_1.Size = New System.Drawing.Size(289, 17)
		Me._Header4_1.Location = New System.Drawing.Point(84, 64)
		Me._Header4_1.TabIndex = 20
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
		Me._Header5_1.Text = "All rights reserved."
		Me._Header5_1.Size = New System.Drawing.Size(289, 17)
		Me._Header5_1.Location = New System.Drawing.Point(84, 80)
		Me._Header5_1.TabIndex = 19
		Me._Header5_1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._Header5_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Header5_1.BackColor = System.Drawing.SystemColors.Control
		Me._Header5_1.Enabled = True
		Me._Header5_1.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Header5_1.Cursor = System.Windows.Forms.Cursors.Default
		Me._Header5_1.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Header5_1.UseMnemonic = True
		Me._Header5_1.Visible = True
		Me._Header5_1.AutoSize = False
		Me._Header5_1.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Header5_1.Name = "_Header5_1"
		Me._Header6_0.Text = "Go to www.ballardtech.com or email support@ballardtech.com"
		Me._Header6_0.Size = New System.Drawing.Size(289, 17)
		Me._Header6_0.Location = New System.Drawing.Point(84, 96)
		Me._Header6_0.TabIndex = 18
		Me._Header6_0.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._Header6_0.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me._Header6_0.BackColor = System.Drawing.SystemColors.Control
		Me._Header6_0.Enabled = True
		Me._Header6_0.ForeColor = System.Drawing.SystemColors.ControlText
		Me._Header6_0.Cursor = System.Windows.Forms.Cursors.Default
		Me._Header6_0.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me._Header6_0.UseMnemonic = True
		Me._Header6_0.Visible = True
		Me._Header6_0.AutoSize = False
		Me._Header6_0.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me._Header6_0.Name = "_Header6_0"
		Me.Line1.BackColor = System.Drawing.SystemColors.WindowText
		Me.Line1.Visible = True
		Me.Line1.Location = New System.Drawing.Point(84, 24)
		Me.Line1.Size = New System.Drawing.Size(296, 1)
		Me.Line1.Name = "Line1"
        Me.Header3.Text = "Copyright 2009-2011"
		Me.Header3.Size = New System.Drawing.Size(289, 17)
		Me.Header3.Location = New System.Drawing.Point(84, 48)
		Me.Header3.TabIndex = 17
		Me.Header3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Header3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Header3.BackColor = System.Drawing.SystemColors.Control
		Me.Header3.Enabled = True
		Me.Header3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Header3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Header3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Header3.UseMnemonic = True
		Me.Header3.Visible = True
		Me.Header3.AutoSize = False
		Me.Header3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Header3.Name = "Header3"
		Me._Header1_1.Text = "Transmitter file playback example"
		Me._Header1_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._Header1_1.Size = New System.Drawing.Size(241, 17)
		Me._Header1_1.Location = New System.Drawing.Point(112, 0)
		Me._Header1_1.TabIndex = 16
		Me._Header1_1.TextAlign = System.Drawing.ContentAlignment.TopLeft
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
		Me.Core.Text = "Core"
		Me.Core.Size = New System.Drawing.Size(281, 17)
		Me.Core.Location = New System.Drawing.Point(92, 120)
		Me.Core.TabIndex = 15
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
		Me.Result1.Text = "Result1"
		Me.Result1.Size = New System.Drawing.Size(281, 17)
		Me.Result1.Location = New System.Drawing.Point(92, 160)
		Me.Result1.TabIndex = 14
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
		Me.ChanLbl.Text = "ChanLbl"
		Me.ChanLbl.Size = New System.Drawing.Size(281, 17)
		Me.ChanLbl.Location = New System.Drawing.Point(92, 136)
		Me.ChanLbl.TabIndex = 13
		Me.ChanLbl.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ChanLbl.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.ChanLbl.BackColor = System.Drawing.SystemColors.Control
		Me.ChanLbl.Enabled = True
		Me.ChanLbl.ForeColor = System.Drawing.SystemColors.ControlText
		Me.ChanLbl.Cursor = System.Windows.Forms.Cursors.Default
		Me.ChanLbl.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.ChanLbl.UseMnemonic = True
		Me.ChanLbl.Visible = True
		Me.ChanLbl.AutoSize = False
		Me.ChanLbl.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.ChanLbl.Name = "ChanLbl"
		Me.Label1.Text = "File Name:"
		Me.Label1.Size = New System.Drawing.Size(57, 17)
		Me.Label1.Location = New System.Drawing.Point(8, 264)
		Me.Label1.TabIndex = 12
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
		Me.Result2.Text = "Result2"
		Me.Result2.Size = New System.Drawing.Size(281, 17)
		Me.Result2.Location = New System.Drawing.Point(92, 184)
		Me.Result2.TabIndex = 11
		Me.Result2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Result2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Result2.BackColor = System.Drawing.SystemColors.Control
		Me.Result2.Enabled = True
		Me.Result2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Result2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Result2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Result2.UseMnemonic = True
		Me.Result2.Visible = True
		Me.Result2.AutoSize = False
		Me.Result2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Result2.Name = "Result2"
		Me.Label2.Text = "Frequency"
		Me.Label2.Size = New System.Drawing.Size(57, 25)
		Me.Label2.Location = New System.Drawing.Point(48, 216)
		Me.Label2.TabIndex = 10
		Me.Label2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label2.BackColor = System.Drawing.SystemColors.Control
		Me.Label2.Enabled = True
		Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label2.UseMnemonic = True
		Me.Label2.Visible = True
		Me.Label2.AutoSize = False
		Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label2.Name = "Label2"
		Me.Label3.Text = "Block Size"
		Me.Label3.Size = New System.Drawing.Size(57, 17)
		Me.Label3.Location = New System.Drawing.Point(216, 216)
		Me.Label3.TabIndex = 9
		Me.Label3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label3.BackColor = System.Drawing.SystemColors.Control
		Me.Label3.Enabled = True
		Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label3.UseMnemonic = True
		Me.Label3.Visible = True
		Me.Label3.AutoSize = False
		Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label3.Name = "Label3"
		Me.Label4.Text = "Hz"
		Me.Label4.Size = New System.Drawing.Size(41, 17)
		Me.Label4.Location = New System.Drawing.Point(160, 216)
		Me.Label4.TabIndex = 8
		Me.Label4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label4.BackColor = System.Drawing.SystemColors.Control
		Me.Label4.Enabled = True
		Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label4.UseMnemonic = True
		Me.Label4.Visible = True
		Me.Label4.AutoSize = False
		Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label4.Name = "Label4"
		Me.Label5.Text = "frames"
		Me.Label5.Size = New System.Drawing.Size(57, 17)
		Me.Label5.Location = New System.Drawing.Point(352, 216)
		Me.Label5.TabIndex = 7
		Me.Label5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.Label5.BackColor = System.Drawing.SystemColors.Control
		Me.Label5.Enabled = True
		Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label5.UseMnemonic = True
		Me.Label5.Visible = True
		Me.Label5.AutoSize = False
		Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label5.Name = "Label5"
		Me.Controls.Add(CmdExit)
		Me.Controls.Add(CmdStart)
		Me.Controls.Add(CmdStop)
		Me.Controls.Add(FileName)
		Me.Controls.Add(CmdBrouse)
		Me.Controls.Add(frequency)
		Me.Controls.Add(blocksize)
		Me.Controls.Add(Line2)
		Me.Controls.Add(_Header2_0)
		Me.Controls.Add(_Header4_1)
		Me.Controls.Add(_Header5_1)
		Me.Controls.Add(_Header6_0)
		Me.Controls.Add(Line1)
		Me.Controls.Add(Header3)
		Me.Controls.Add(_Header1_1)
		Me.Controls.Add(Core)
		Me.Controls.Add(Result1)
		Me.Controls.Add(ChanLbl)
		Me.Controls.Add(Label1)
		Me.Controls.Add(Result2)
		Me.Controls.Add(Label2)
		Me.Controls.Add(Label3)
		Me.Controls.Add(Label4)
		Me.Controls.Add(Label5)
		Me.Header1.SetIndex(_Header1_1, CType(1, Short))
		Me.Header2.SetIndex(_Header2_0, CType(0, Short))
		Me.Header4.SetIndex(_Header4_1, CType(1, Short))
		Me.Header5.SetIndex(_Header5_1, CType(1, Short))
		Me.Header6.SetIndex(_Header6_0, CType(0, Short))
		CType(Me.Header6, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Header5, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Header4, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Header2, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.Header1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()
	End Sub
#End Region 
End Class