<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.VdFramedControl1 = New vdControls.vdFramedControl
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblInfo = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbVDFAxis = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.rdbInfo = New System.Windows.Forms.RadioButton
        Me.rdb3D = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'VdFramedControl1
        '
        Me.VdFramedControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane
        Me.VdFramedControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VdFramedControl1.DisplayPolarCoord = False
        Me.VdFramedControl1.HistoryLines = CType(3UI, UInteger)
        Me.VdFramedControl1.Location = New System.Drawing.Point(3, 84)
        Me.VdFramedControl1.Name = "VdFramedControl1"
        Me.VdFramedControl1.PropertyGridWidth = CType(300UI, UInteger)
        Me.VdFramedControl1.Size = New System.Drawing.Size(776, 473)
        Me.VdFramedControl1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lblInfo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbVDFAxis)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.rdbInfo)
        Me.GroupBox1.Controls.Add(Me.rdb3D)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(776, 74)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Information Screen Block "
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Location = New System.Drawing.Point(83, 52)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(39, 13)
        Me.lblInfo.TabIndex = 6
        Me.lblInfo.Text = "Label2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Explanation: "
        '
        'cbVDFAxis
        '
        Me.cbVDFAxis.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbVDFAxis.AutoSize = True
        Me.cbVDFAxis.Checked = True
        Me.cbVDFAxis.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbVDFAxis.Location = New System.Drawing.Point(655, 20)
        Me.cbVDFAxis.Name = "cbVDFAxis"
        Me.cbVDFAxis.Size = New System.Drawing.Size(106, 17)
        Me.cbVDFAxis.TabIndex = 4
        Me.cbVDFAxis.Text = "Display VDF Axis"
        Me.cbVDFAxis.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(655, 43)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(114, 22)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "3D Rotate View"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'rdbInfo
        '
        Me.rdbInfo.AutoSize = True
        Me.rdbInfo.Location = New System.Drawing.Point(226, 19)
        Me.rdbInfo.Name = "rdbInfo"
        Me.rdbInfo.Size = New System.Drawing.Size(119, 17)
        Me.rdbInfo.TabIndex = 2
        Me.rdbInfo.Text = "Drawing Information"
        Me.rdbInfo.UseVisualStyleBackColor = True
        '
        'rdb3D
        '
        Me.rdb3D.AutoSize = True
        Me.rdb3D.Checked = True
        Me.rdb3D.Location = New System.Drawing.Point(9, 19)
        Me.rdb3D.Name = "rdb3D"
        Me.rdb3D.Size = New System.Drawing.Size(99, 17)
        Me.rdb3D.TabIndex = 0
        Me.rdb3D.TabStop = True
        Me.rdb3D.Text = "Custom 3D Axis"
        Me.rdb3D.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.VdFramedControl1)
        Me.MinimumSize = New System.Drawing.Size(700, 500)
        Me.Name = "Form1"
        Me.Text = "ScreenBlockInfo for VB"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VdFramedControl1 As vdControls.vdFramedControl
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbInfo As System.Windows.Forms.RadioButton
    Friend WithEvents rdb3D As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cbVDFAxis As System.Windows.Forms.CheckBox
    Friend WithEvents lblInfo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
