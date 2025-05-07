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
	Public WithEvents label_hex As System.Windows.Forms.TextBox
	Public WithEvents controlaccept As System.Windows.Forms.TextBox
	Public WithEvents bits16to11 As System.Windows.Forms.TextBox
	Public WithEvents bits26to17 As System.Windows.Forms.TextBox
	Public WithEvents mode As System.Windows.Forms.TextBox
	Public WithEvents tilt_hex As System.Windows.Forms.TextBox
	Public WithEvents gain As System.Windows.Forms.TextBox
	Public WithEvents range As System.Windows.Forms.TextBox
	Public WithEvents bit49 As System.Windows.Forms.TextBox
	Public WithEvents dataaccept As System.Windows.Forms.TextBox
	Public WithEvents scanangle_hex As System.Windows.Forms.TextBox
	Public WithEvents bit64 As System.Windows.Forms.TextBox
	Public WithEvents label_oct As System.Windows.Forms.TextBox
	Public WithEvents tilt_dec As System.Windows.Forms.TextBox
	Public WithEvents scanangle_dec As System.Windows.Forms.TextBox
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
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Line3 As System.Windows.Forms.Label
	Public WithEvents label5 As System.Windows.Forms.Label
	Public WithEvents Label6 As System.Windows.Forms.Label
	Public WithEvents Label7 As System.Windows.Forms.Label
	Public WithEvents Label8 As System.Windows.Forms.Label
	Public WithEvents Label10 As System.Windows.Forms.Label
	Public WithEvents Label11 As System.Windows.Forms.Label
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents label4 As System.Windows.Forms.Label
	Public WithEvents Label9 As System.Windows.Forms.Label
	Public WithEvents Label12 As System.Windows.Forms.Label
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
		Me.CmdExit = New System.Windows.Forms.Button
		Me.CmdStart = New System.Windows.Forms.Button
		Me.CmdStop = New System.Windows.Forms.Button
		Me.Timer1 = New System.Windows.Forms.Timer(components)
		Me.label_hex = New System.Windows.Forms.TextBox
		Me.controlaccept = New System.Windows.Forms.TextBox
		Me.bits16to11 = New System.Windows.Forms.TextBox
		Me.bits26to17 = New System.Windows.Forms.TextBox
		Me.mode = New System.Windows.Forms.TextBox
		Me.tilt_hex = New System.Windows.Forms.TextBox
		Me.gain = New System.Windows.Forms.TextBox
		Me.range = New System.Windows.Forms.TextBox
		Me.bit49 = New System.Windows.Forms.TextBox
		Me.dataaccept = New System.Windows.Forms.TextBox
		Me.scanangle_hex = New System.Windows.Forms.TextBox
		Me.bit64 = New System.Windows.Forms.TextBox
		Me.label_oct = New System.Windows.Forms.TextBox
		Me.tilt_dec = New System.Windows.Forms.TextBox
		Me.scanangle_dec = New System.Windows.Forms.TextBox
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
		Me.Label2 = New System.Windows.Forms.Label
		Me.Line3 = New System.Windows.Forms.Label
		Me.label5 = New System.Windows.Forms.Label
		Me.Label6 = New System.Windows.Forms.Label
		Me.Label7 = New System.Windows.Forms.Label
		Me.Label8 = New System.Windows.Forms.Label
		Me.Label10 = New System.Windows.Forms.Label
		Me.Label11 = New System.Windows.Forms.Label
		Me.Label3 = New System.Windows.Forms.Label
		Me.label4 = New System.Windows.Forms.Label
		Me.Label9 = New System.Windows.Forms.Label
		Me.Label12 = New System.Windows.Forms.Label
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
		Me.Text = "BTI708 Example 6"
		Me.ClientSize = New System.Drawing.Size(320, 472)
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
		Me.CmdExit.Location = New System.Drawing.Point(264, 440)
		Me.CmdExit.TabIndex = 17
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
		Me.CmdStart.Location = New System.Drawing.Point(8, 440)
		Me.CmdStart.TabIndex = 16
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
		Me.CmdStop.Location = New System.Drawing.Point(64, 440)
		Me.CmdStop.TabIndex = 15
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
		Me.label_hex.AutoSize = False
		Me.label_hex.Size = New System.Drawing.Size(57, 19)
		Me.label_hex.Location = New System.Drawing.Point(115, 216)
		Me.label_hex.TabIndex = 14
		Me.label_hex.Text = "Text1"
		Me.label_hex.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.label_hex.AcceptsReturn = True
		Me.label_hex.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.label_hex.BackColor = System.Drawing.SystemColors.Window
		Me.label_hex.CausesValidation = True
		Me.label_hex.Enabled = True
		Me.label_hex.ForeColor = System.Drawing.SystemColors.WindowText
		Me.label_hex.HideSelection = True
		Me.label_hex.ReadOnly = False
		Me.label_hex.Maxlength = 0
		Me.label_hex.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.label_hex.MultiLine = False
		Me.label_hex.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label_hex.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.label_hex.TabStop = True
		Me.label_hex.Visible = True
		Me.label_hex.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.label_hex.Name = "label_hex"
		Me.controlaccept.AutoSize = False
		Me.controlaccept.Size = New System.Drawing.Size(57, 19)
		Me.controlaccept.Location = New System.Drawing.Point(104, 312)
		Me.controlaccept.TabIndex = 13
		Me.controlaccept.Text = "Text2"
		Me.controlaccept.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.controlaccept.AcceptsReturn = True
		Me.controlaccept.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.controlaccept.BackColor = System.Drawing.SystemColors.Window
		Me.controlaccept.CausesValidation = True
		Me.controlaccept.Enabled = True
		Me.controlaccept.ForeColor = System.Drawing.SystemColors.WindowText
		Me.controlaccept.HideSelection = True
		Me.controlaccept.ReadOnly = False
		Me.controlaccept.Maxlength = 0
		Me.controlaccept.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.controlaccept.MultiLine = False
		Me.controlaccept.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.controlaccept.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.controlaccept.TabStop = True
		Me.controlaccept.Visible = True
		Me.controlaccept.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.controlaccept.Name = "controlaccept"
		Me.bits16to11.AutoSize = False
		Me.bits16to11.Size = New System.Drawing.Size(57, 19)
		Me.bits16to11.Location = New System.Drawing.Point(232, 312)
		Me.bits16to11.TabIndex = 12
		Me.bits16to11.Text = "Text3"
		Me.bits16to11.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.bits16to11.AcceptsReturn = True
		Me.bits16to11.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.bits16to11.BackColor = System.Drawing.SystemColors.Window
		Me.bits16to11.CausesValidation = True
		Me.bits16to11.Enabled = True
		Me.bits16to11.ForeColor = System.Drawing.SystemColors.WindowText
		Me.bits16to11.HideSelection = True
		Me.bits16to11.ReadOnly = False
		Me.bits16to11.Maxlength = 0
		Me.bits16to11.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.bits16to11.MultiLine = False
		Me.bits16to11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.bits16to11.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.bits16to11.TabStop = True
		Me.bits16to11.Visible = True
		Me.bits16to11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.bits16to11.Name = "bits16to11"
		Me.bits26to17.AutoSize = False
		Me.bits26to17.Size = New System.Drawing.Size(57, 19)
		Me.bits26to17.Location = New System.Drawing.Point(232, 336)
		Me.bits26to17.TabIndex = 11
		Me.bits26to17.Text = "Text4"
		Me.bits26to17.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.bits26to17.AcceptsReturn = True
		Me.bits26to17.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.bits26to17.BackColor = System.Drawing.SystemColors.Window
		Me.bits26to17.CausesValidation = True
		Me.bits26to17.Enabled = True
		Me.bits26to17.ForeColor = System.Drawing.SystemColors.WindowText
		Me.bits26to17.HideSelection = True
		Me.bits26to17.ReadOnly = False
		Me.bits26to17.Maxlength = 0
		Me.bits26to17.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.bits26to17.MultiLine = False
		Me.bits26to17.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.bits26to17.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.bits26to17.TabStop = True
		Me.bits26to17.Visible = True
		Me.bits26to17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.bits26to17.Name = "bits26to17"
		Me.mode.AutoSize = False
		Me.mode.Size = New System.Drawing.Size(57, 19)
		Me.mode.Location = New System.Drawing.Point(104, 408)
		Me.mode.TabIndex = 10
		Me.mode.Text = "Text5"
		Me.mode.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.mode.AcceptsReturn = True
		Me.mode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.mode.BackColor = System.Drawing.SystemColors.Window
		Me.mode.CausesValidation = True
		Me.mode.Enabled = True
		Me.mode.ForeColor = System.Drawing.SystemColors.WindowText
		Me.mode.HideSelection = True
		Me.mode.ReadOnly = False
		Me.mode.Maxlength = 0
		Me.mode.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.mode.MultiLine = False
		Me.mode.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.mode.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.mode.TabStop = True
		Me.mode.Visible = True
		Me.mode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.mode.Name = "mode"
		Me.tilt_hex.AutoSize = False
		Me.tilt_hex.Size = New System.Drawing.Size(57, 19)
		Me.tilt_hex.Location = New System.Drawing.Point(115, 240)
		Me.tilt_hex.TabIndex = 9
		Me.tilt_hex.Text = "Text6"
		Me.tilt_hex.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tilt_hex.AcceptsReturn = True
		Me.tilt_hex.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.tilt_hex.BackColor = System.Drawing.SystemColors.Window
		Me.tilt_hex.CausesValidation = True
		Me.tilt_hex.Enabled = True
		Me.tilt_hex.ForeColor = System.Drawing.SystemColors.WindowText
		Me.tilt_hex.HideSelection = True
		Me.tilt_hex.ReadOnly = False
		Me.tilt_hex.Maxlength = 0
		Me.tilt_hex.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.tilt_hex.MultiLine = False
		Me.tilt_hex.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.tilt_hex.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.tilt_hex.TabStop = True
		Me.tilt_hex.Visible = True
		Me.tilt_hex.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.tilt_hex.Name = "tilt_hex"
		Me.gain.AutoSize = False
		Me.gain.Size = New System.Drawing.Size(57, 19)
		Me.gain.Location = New System.Drawing.Point(104, 384)
		Me.gain.TabIndex = 8
		Me.gain.Text = "Text7"
		Me.gain.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.gain.AcceptsReturn = True
		Me.gain.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.gain.BackColor = System.Drawing.SystemColors.Window
		Me.gain.CausesValidation = True
		Me.gain.Enabled = True
		Me.gain.ForeColor = System.Drawing.SystemColors.WindowText
		Me.gain.HideSelection = True
		Me.gain.ReadOnly = False
		Me.gain.Maxlength = 0
		Me.gain.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.gain.MultiLine = False
		Me.gain.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.gain.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.gain.TabStop = True
		Me.gain.Visible = True
		Me.gain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.gain.Name = "gain"
		Me.range.AutoSize = False
		Me.range.Size = New System.Drawing.Size(57, 19)
		Me.range.Location = New System.Drawing.Point(104, 360)
		Me.range.TabIndex = 7
		Me.range.Text = "Text8"
		Me.range.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.range.AcceptsReturn = True
		Me.range.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.range.BackColor = System.Drawing.SystemColors.Window
		Me.range.CausesValidation = True
		Me.range.Enabled = True
		Me.range.ForeColor = System.Drawing.SystemColors.WindowText
		Me.range.HideSelection = True
		Me.range.ReadOnly = False
		Me.range.Maxlength = 0
		Me.range.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.range.MultiLine = False
		Me.range.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.range.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.range.TabStop = True
		Me.range.Visible = True
		Me.range.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.range.Name = "range"
		Me.bit49.AutoSize = False
		Me.bit49.Size = New System.Drawing.Size(57, 19)
		Me.bit49.Location = New System.Drawing.Point(232, 360)
		Me.bit49.TabIndex = 6
		Me.bit49.Text = "Text9"
		Me.bit49.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.bit49.AcceptsReturn = True
		Me.bit49.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.bit49.BackColor = System.Drawing.SystemColors.Window
		Me.bit49.CausesValidation = True
		Me.bit49.Enabled = True
		Me.bit49.ForeColor = System.Drawing.SystemColors.WindowText
		Me.bit49.HideSelection = True
		Me.bit49.ReadOnly = False
		Me.bit49.Maxlength = 0
		Me.bit49.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.bit49.MultiLine = False
		Me.bit49.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.bit49.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.bit49.TabStop = True
		Me.bit49.Visible = True
		Me.bit49.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.bit49.Name = "bit49"
		Me.dataaccept.AutoSize = False
		Me.dataaccept.Size = New System.Drawing.Size(57, 19)
		Me.dataaccept.Location = New System.Drawing.Point(104, 336)
		Me.dataaccept.TabIndex = 5
		Me.dataaccept.Text = "Text10"
		Me.dataaccept.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.dataaccept.AcceptsReturn = True
		Me.dataaccept.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.dataaccept.BackColor = System.Drawing.SystemColors.Window
		Me.dataaccept.CausesValidation = True
		Me.dataaccept.Enabled = True
		Me.dataaccept.ForeColor = System.Drawing.SystemColors.WindowText
		Me.dataaccept.HideSelection = True
		Me.dataaccept.ReadOnly = False
		Me.dataaccept.Maxlength = 0
		Me.dataaccept.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.dataaccept.MultiLine = False
		Me.dataaccept.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.dataaccept.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.dataaccept.TabStop = True
		Me.dataaccept.Visible = True
		Me.dataaccept.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.dataaccept.Name = "dataaccept"
		Me.scanangle_hex.AutoSize = False
		Me.scanangle_hex.Size = New System.Drawing.Size(57, 19)
		Me.scanangle_hex.Location = New System.Drawing.Point(115, 264)
		Me.scanangle_hex.TabIndex = 4
		Me.scanangle_hex.Text = "Text11"
		Me.scanangle_hex.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.scanangle_hex.AcceptsReturn = True
		Me.scanangle_hex.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.scanangle_hex.BackColor = System.Drawing.SystemColors.Window
		Me.scanangle_hex.CausesValidation = True
		Me.scanangle_hex.Enabled = True
		Me.scanangle_hex.ForeColor = System.Drawing.SystemColors.WindowText
		Me.scanangle_hex.HideSelection = True
		Me.scanangle_hex.ReadOnly = False
		Me.scanangle_hex.Maxlength = 0
		Me.scanangle_hex.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.scanangle_hex.MultiLine = False
		Me.scanangle_hex.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.scanangle_hex.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.scanangle_hex.TabStop = True
		Me.scanangle_hex.Visible = True
		Me.scanangle_hex.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.scanangle_hex.Name = "scanangle_hex"
		Me.bit64.AutoSize = False
		Me.bit64.Size = New System.Drawing.Size(57, 19)
		Me.bit64.Location = New System.Drawing.Point(232, 384)
		Me.bit64.TabIndex = 3
		Me.bit64.Text = "Text12"
		Me.bit64.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.bit64.AcceptsReturn = True
		Me.bit64.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.bit64.BackColor = System.Drawing.SystemColors.Window
		Me.bit64.CausesValidation = True
		Me.bit64.Enabled = True
		Me.bit64.ForeColor = System.Drawing.SystemColors.WindowText
		Me.bit64.HideSelection = True
		Me.bit64.ReadOnly = False
		Me.bit64.Maxlength = 0
		Me.bit64.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.bit64.MultiLine = False
		Me.bit64.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.bit64.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.bit64.TabStop = True
		Me.bit64.Visible = True
		Me.bit64.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.bit64.Name = "bit64"
		Me.label_oct.AutoSize = False
		Me.label_oct.Size = New System.Drawing.Size(57, 19)
		Me.label_oct.Location = New System.Drawing.Point(179, 216)
		Me.label_oct.TabIndex = 2
		Me.label_oct.Text = "Text1"
		Me.label_oct.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.label_oct.AcceptsReturn = True
		Me.label_oct.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.label_oct.BackColor = System.Drawing.SystemColors.Window
		Me.label_oct.CausesValidation = True
		Me.label_oct.Enabled = True
		Me.label_oct.ForeColor = System.Drawing.SystemColors.WindowText
		Me.label_oct.HideSelection = True
		Me.label_oct.ReadOnly = False
		Me.label_oct.Maxlength = 0
		Me.label_oct.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.label_oct.MultiLine = False
		Me.label_oct.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label_oct.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.label_oct.TabStop = True
		Me.label_oct.Visible = True
		Me.label_oct.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.label_oct.Name = "label_oct"
		Me.tilt_dec.AutoSize = False
		Me.tilt_dec.Size = New System.Drawing.Size(57, 19)
		Me.tilt_dec.Location = New System.Drawing.Point(179, 240)
		Me.tilt_dec.TabIndex = 1
		Me.tilt_dec.Text = "Text1"
		Me.tilt_dec.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.tilt_dec.AcceptsReturn = True
		Me.tilt_dec.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.tilt_dec.BackColor = System.Drawing.SystemColors.Window
		Me.tilt_dec.CausesValidation = True
		Me.tilt_dec.Enabled = True
		Me.tilt_dec.ForeColor = System.Drawing.SystemColors.WindowText
		Me.tilt_dec.HideSelection = True
		Me.tilt_dec.ReadOnly = False
		Me.tilt_dec.Maxlength = 0
		Me.tilt_dec.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.tilt_dec.MultiLine = False
		Me.tilt_dec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.tilt_dec.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.tilt_dec.TabStop = True
		Me.tilt_dec.Visible = True
		Me.tilt_dec.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.tilt_dec.Name = "tilt_dec"
		Me.scanangle_dec.AutoSize = False
		Me.scanangle_dec.Size = New System.Drawing.Size(57, 19)
		Me.scanangle_dec.Location = New System.Drawing.Point(179, 264)
		Me.scanangle_dec.TabIndex = 0
		Me.scanangle_dec.Text = "Text1"
		Me.scanangle_dec.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.scanangle_dec.AcceptsReturn = True
		Me.scanangle_dec.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
		Me.scanangle_dec.BackColor = System.Drawing.SystemColors.Window
		Me.scanangle_dec.CausesValidation = True
		Me.scanangle_dec.Enabled = True
		Me.scanangle_dec.ForeColor = System.Drawing.SystemColors.WindowText
		Me.scanangle_dec.HideSelection = True
		Me.scanangle_dec.ReadOnly = False
		Me.scanangle_dec.Maxlength = 0
		Me.scanangle_dec.Cursor = System.Windows.Forms.Cursors.IBeam
		Me.scanangle_dec.MultiLine = False
		Me.scanangle_dec.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.scanangle_dec.ScrollBars = System.Windows.Forms.ScrollBars.None
		Me.scanangle_dec.TabStop = True
		Me.scanangle_dec.Visible = True
		Me.scanangle_dec.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.scanangle_dec.Name = "scanangle_dec"
		Me.Line2.BackColor = System.Drawing.SystemColors.WindowText
		Me.Line2.Visible = True
		Me.Line2.Location = New System.Drawing.Point(8, 125)
		Me.Line2.Size = New System.Drawing.Size(296, 1)
		Me.Line2.Name = "Line2"
        Me._Header2_0.Text = "VB_EXAMP6     (06/07/2011)"
		Me._Header2_0.Size = New System.Drawing.Size(289, 17)
		Me._Header2_0.Location = New System.Drawing.Point(8, 40)
		Me._Header2_0.TabIndex = 38
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
		Me._Header4_1.Location = New System.Drawing.Point(8, 72)
		Me._Header4_1.TabIndex = 37
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
		Me._Header5_1.Location = New System.Drawing.Point(8, 88)
		Me._Header5_1.TabIndex = 36
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
		Me._Header6_0.Location = New System.Drawing.Point(8, 104)
		Me._Header6_0.TabIndex = 35
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
		Me.Line1.Location = New System.Drawing.Point(8, 32)
		Me.Line1.Size = New System.Drawing.Size(296, 1)
		Me.Line1.Name = "Line1"
        Me.Header3.Text = "Copyright 2009-2011"
		Me.Header3.Size = New System.Drawing.Size(289, 17)
		Me.Header3.Location = New System.Drawing.Point(8, 56)
		Me.Header3.TabIndex = 34
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
		Me._Header1_1.Text = "Header Extraction Example"
		Me._Header1_1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me._Header1_1.Size = New System.Drawing.Size(201, 17)
		Me._Header1_1.Location = New System.Drawing.Point(60, 8)
		Me._Header1_1.TabIndex = 33
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
		Me.Core.Location = New System.Drawing.Point(25, 128)
		Me.Core.TabIndex = 32
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
		Me.Result1.Location = New System.Drawing.Point(25, 176)
		Me.Result1.TabIndex = 31
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
		Me.ChanLbl.Location = New System.Drawing.Point(25, 152)
		Me.ChanLbl.TabIndex = 30
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
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label1.Text = "Label:"
		Me.Label1.Size = New System.Drawing.Size(33, 17)
		Me.Label1.Location = New System.Drawing.Point(75, 216)
		Me.Label1.TabIndex = 29
		Me.Label1.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label2.Text = "Control Accept:"
		Me.Label2.Size = New System.Drawing.Size(73, 17)
		Me.Label2.Location = New System.Drawing.Point(24, 312)
		Me.Label2.TabIndex = 28
		Me.Label2.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
		Me.Line3.BackColor = System.Drawing.SystemColors.WindowText
		Me.Line3.Visible = True
		Me.Line3.Location = New System.Drawing.Point(12, 200)
		Me.Line3.Size = New System.Drawing.Size(296, 1)
		Me.Line3.Name = "Line3"
		Me.label5.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.label5.Text = "Mode:"
		Me.label5.Size = New System.Drawing.Size(73, 17)
		Me.label5.Location = New System.Drawing.Point(24, 408)
		Me.label5.TabIndex = 27
		Me.label5.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.label5.BackColor = System.Drawing.SystemColors.Control
		Me.label5.Enabled = True
		Me.label5.ForeColor = System.Drawing.SystemColors.ControlText
		Me.label5.Cursor = System.Windows.Forms.Cursors.Default
		Me.label5.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label5.UseMnemonic = True
		Me.label5.Visible = True
		Me.label5.AutoSize = False
		Me.label5.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.label5.Name = "label5"
		Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label6.Text = "Tilt:"
		Me.Label6.Size = New System.Drawing.Size(25, 17)
		Me.Label6.Location = New System.Drawing.Point(83, 240)
		Me.Label6.TabIndex = 26
		Me.Label6.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label6.BackColor = System.Drawing.SystemColors.Control
		Me.Label6.Enabled = True
		Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label6.UseMnemonic = True
		Me.Label6.Visible = True
		Me.Label6.AutoSize = False
		Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label6.Name = "Label6"
		Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label7.Text = "Gain:"
		Me.Label7.Size = New System.Drawing.Size(73, 17)
		Me.Label7.Location = New System.Drawing.Point(24, 384)
		Me.Label7.TabIndex = 25
		Me.Label7.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label7.BackColor = System.Drawing.SystemColors.Control
		Me.Label7.Enabled = True
		Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label7.UseMnemonic = True
		Me.Label7.Visible = True
		Me.Label7.AutoSize = False
		Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label7.Name = "Label7"
		Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label8.Text = "Range:"
		Me.Label8.Size = New System.Drawing.Size(73, 17)
		Me.Label8.Location = New System.Drawing.Point(24, 360)
		Me.Label8.TabIndex = 24
		Me.Label8.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label8.BackColor = System.Drawing.SystemColors.Control
		Me.Label8.Enabled = True
		Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label8.UseMnemonic = True
		Me.Label8.Visible = True
		Me.Label8.AutoSize = False
		Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label8.Name = "Label8"
		Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label10.Text = "Data Accept:"
		Me.Label10.Size = New System.Drawing.Size(73, 17)
		Me.Label10.Location = New System.Drawing.Point(24, 336)
		Me.Label10.TabIndex = 23
		Me.Label10.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label10.BackColor = System.Drawing.SystemColors.Control
		Me.Label10.Enabled = True
		Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label10.UseMnemonic = True
		Me.Label10.Visible = True
		Me.Label10.AutoSize = False
		Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label10.Name = "Label10"
		Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label11.Text = "Scan Angle:"
		Me.Label11.Size = New System.Drawing.Size(65, 17)
		Me.Label11.Location = New System.Drawing.Point(43, 264)
		Me.Label11.TabIndex = 22
		Me.Label11.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label11.BackColor = System.Drawing.SystemColors.Control
		Me.Label11.Enabled = True
		Me.Label11.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label11.UseMnemonic = True
		Me.Label11.Visible = True
		Me.Label11.AutoSize = False
		Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label11.Name = "Label11"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label3.Text = "Bits 16-11:"
		Me.Label3.Size = New System.Drawing.Size(57, 17)
		Me.Label3.Location = New System.Drawing.Point(168, 312)
		Me.Label3.TabIndex = 21
		Me.Label3.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
		Me.label4.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.label4.Text = "Bits 26-17:"
		Me.label4.Size = New System.Drawing.Size(57, 17)
		Me.label4.Location = New System.Drawing.Point(168, 336)
		Me.label4.TabIndex = 20
		Me.label4.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.label4.BackColor = System.Drawing.SystemColors.Control
		Me.label4.Enabled = True
		Me.label4.ForeColor = System.Drawing.SystemColors.ControlText
		Me.label4.Cursor = System.Windows.Forms.Cursors.Default
		Me.label4.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.label4.UseMnemonic = True
		Me.label4.Visible = True
		Me.label4.AutoSize = False
		Me.label4.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.label4.Name = "label4"
		Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label9.Text = "Bit 49:"
		Me.Label9.Size = New System.Drawing.Size(57, 17)
		Me.Label9.Location = New System.Drawing.Point(168, 360)
		Me.Label9.TabIndex = 19
		Me.Label9.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label9.BackColor = System.Drawing.SystemColors.Control
		Me.Label9.Enabled = True
		Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label9.UseMnemonic = True
		Me.Label9.Visible = True
		Me.Label9.AutoSize = False
		Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label9.Name = "Label9"
		Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
		Me.Label12.Text = "Bit 64:"
		Me.Label12.Size = New System.Drawing.Size(57, 17)
		Me.Label12.Location = New System.Drawing.Point(168, 384)
		Me.Label12.TabIndex = 18
		Me.Label12.Font = New System.Drawing.Font("Arial", 8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label12.BackColor = System.Drawing.SystemColors.Control
		Me.Label12.Enabled = True
		Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
		Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
		Me.Label12.UseMnemonic = True
		Me.Label12.Visible = True
		Me.Label12.AutoSize = False
		Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.Label12.Name = "Label12"
		Me.Controls.Add(CmdExit)
		Me.Controls.Add(CmdStart)
		Me.Controls.Add(CmdStop)
		Me.Controls.Add(label_hex)
		Me.Controls.Add(controlaccept)
		Me.Controls.Add(bits16to11)
		Me.Controls.Add(bits26to17)
		Me.Controls.Add(mode)
		Me.Controls.Add(tilt_hex)
		Me.Controls.Add(gain)
		Me.Controls.Add(range)
		Me.Controls.Add(bit49)
		Me.Controls.Add(dataaccept)
		Me.Controls.Add(scanangle_hex)
		Me.Controls.Add(bit64)
		Me.Controls.Add(label_oct)
		Me.Controls.Add(tilt_dec)
		Me.Controls.Add(scanangle_dec)
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
		Me.Controls.Add(Label2)
		Me.Controls.Add(Line3)
		Me.Controls.Add(label5)
		Me.Controls.Add(Label6)
		Me.Controls.Add(Label7)
		Me.Controls.Add(Label8)
		Me.Controls.Add(Label10)
		Me.Controls.Add(Label11)
		Me.Controls.Add(Label3)
		Me.Controls.Add(label4)
		Me.Controls.Add(Label9)
		Me.Controls.Add(Label12)
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