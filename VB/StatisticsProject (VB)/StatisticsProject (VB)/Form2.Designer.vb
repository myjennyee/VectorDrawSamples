<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.label2 = New System.Windows.Forms.Label
        Me.trackBar2 = New System.Windows.Forms.TrackBar
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.trackBar3 = New System.Windows.Forms.TrackBar
        Me.trackBar1 = New System.Windows.Forms.TrackBar
        Me.label1 = New System.Windows.Forms.Label
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        CType(Me.trackBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox2.SuspendLayout()
        CType(Me.trackBar3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(13, 74)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(50, 13)
        Me.label2.TabIndex = 3
        Me.label2.Text = "by X Axis"
        '
        'trackBar2
        '
        Me.trackBar2.Location = New System.Drawing.Point(69, 74)
        Me.trackBar2.Maximum = 21
        Me.trackBar2.Minimum = 1
        Me.trackBar2.Name = "trackBar2"
        Me.trackBar2.Size = New System.Drawing.Size(185, 45)
        Me.trackBar2.TabIndex = 1
        Me.trackBar2.Value = 1
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.trackBar3)
        Me.groupBox2.Location = New System.Drawing.Point(12, 148)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(260, 71)
        Me.groupBox2.TabIndex = 9
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Zoom"
        '
        'trackBar3
        '
        Me.trackBar3.Location = New System.Drawing.Point(6, 23)
        Me.trackBar3.Maximum = 51
        Me.trackBar3.Minimum = 1
        Me.trackBar3.Name = "trackBar3"
        Me.trackBar3.Size = New System.Drawing.Size(248, 45)
        Me.trackBar3.TabIndex = 2
        Me.trackBar3.Value = 1
        '
        'trackBar1
        '
        Me.trackBar1.Location = New System.Drawing.Point(69, 23)
        Me.trackBar1.Maximum = 21
        Me.trackBar1.Minimum = 1
        Me.trackBar1.Name = "trackBar1"
        Me.trackBar1.Size = New System.Drawing.Size(185, 45)
        Me.trackBar1.TabIndex = 0
        Me.trackBar1.Value = 1
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(13, 23)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(50, 13)
        Me.label1.TabIndex = 2
        Me.label1.Text = "by Y Axis"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.trackBar1)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.trackBar2)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Location = New System.Drawing.Point(12, 11)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(260, 122)
        Me.groupBox1.TabIndex = 8
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Rotate"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 231)
        Me.Controls.Add(Me.groupBox2)
        Me.Controls.Add(Me.groupBox1)
        Me.MaximumSize = New System.Drawing.Size(300, 269)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(300, 269)
        Me.Name = "Form2"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "3D View Edit"
        CType(Me.trackBar2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        CType(Me.trackBar3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents trackBar2 As System.Windows.Forms.TrackBar
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents trackBar3 As System.Windows.Forms.TrackBar
    Private WithEvents trackBar1 As System.Windows.Forms.TrackBar
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
End Class
