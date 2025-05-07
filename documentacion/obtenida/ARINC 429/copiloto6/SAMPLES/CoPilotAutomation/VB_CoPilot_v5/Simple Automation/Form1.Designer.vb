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
	Public WithEvents Cmd1553 As System.Windows.Forms.Button
	Public WithEvents Cmd429 As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Cmd1553 = New System.Windows.Forms.Button
        Me.Cmd429 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Cmd1553
        '
        Me.Cmd1553.BackColor = System.Drawing.SystemColors.Control
        Me.Cmd1553.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cmd1553.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd1553.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd1553.Location = New System.Drawing.Point(8, 8)
        Me.Cmd1553.Name = "Cmd1553"
        Me.Cmd1553.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cmd1553.Size = New System.Drawing.Size(225, 33)
        Me.Cmd1553.TabIndex = 1
        Me.Cmd1553.Text = "Lookup a MIL-STD-1553 Field"
        Me.Cmd1553.UseVisualStyleBackColor = False
        '
        'Cmd429
        '
        Me.Cmd429.BackColor = System.Drawing.SystemColors.Control
        Me.Cmd429.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cmd429.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Cmd429.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Cmd429.Location = New System.Drawing.Point(8, 48)
        Me.Cmd429.Name = "Cmd429"
        Me.Cmd429.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cmd429.Size = New System.Drawing.Size(225, 33)
        Me.Cmd429.TabIndex = 0
        Me.Cmd429.Text = "Lookup an ARINC 429 Label"
        Me.Cmd429.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(241, 89)
        Me.Controls.Add(Me.Cmd1553)
        Me.Controls.Add(Me.Cmd429)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Location = New System.Drawing.Point(4, 23)
        Me.Name = "Form1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Simple Automation"
        Me.ResumeLayout(False)

    End Sub
#End Region 
End Class