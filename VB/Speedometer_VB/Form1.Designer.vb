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
        Me.VectorDrawBaseControl1 = New VectorDraw.Professional.Control.VectorDrawBaseControl
        Me.label1 = New System.Windows.Forms.Label
        Me.comboSpeed = New System.Windows.Forms.ComboBox
        Me.butStart = New System.Windows.Forms.Button
        Me.progressBar1 = New System.Windows.Forms.ProgressBar
        Me.SuspendLayout()
        '
        'VectorDrawBaseControl1
        '
        Me.VectorDrawBaseControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.VectorDrawBaseControl1.AllowDrop = True
        Me.VectorDrawBaseControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.VectorDrawBaseControl1.DisableVdrawDxf = False
        Me.VectorDrawBaseControl1.EnableAutoGripOn = True
        Me.VectorDrawBaseControl1.Location = New System.Drawing.Point(6, 9)
        Me.VectorDrawBaseControl1.Name = "VectorDrawBaseControl1"
        Me.VectorDrawBaseControl1.Size = New System.Drawing.Size(323, 208)
        Me.VectorDrawBaseControl1.TabIndex = 0
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(335, 57)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(38, 13)
        Me.label1.TabIndex = 8
        Me.label1.Text = "Speed"
        '
        'comboSpeed
        '
        Me.comboSpeed.FormattingEnabled = True
        Me.comboSpeed.Items.AddRange(New Object() {"Very Fast", "Fast", "Slow"})
        Me.comboSpeed.Location = New System.Drawing.Point(379, 54)
        Me.comboSpeed.Name = "comboSpeed"
        Me.comboSpeed.Size = New System.Drawing.Size(96, 21)
        Me.comboSpeed.TabIndex = 7
        '
        'butStart
        '
        Me.butStart.Location = New System.Drawing.Point(338, 95)
        Me.butStart.Name = "butStart"
        Me.butStart.Size = New System.Drawing.Size(137, 28)
        Me.butStart.TabIndex = 6
        Me.butStart.Text = "Start"
        Me.butStart.UseVisualStyleBackColor = True
        '
        'progressBar1
        '
        Me.progressBar1.Location = New System.Drawing.Point(338, 12)
        Me.progressBar1.Name = "progressBar1"
        Me.progressBar1.Size = New System.Drawing.Size(137, 25)
        Me.progressBar1.TabIndex = 5
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 223)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.comboSpeed)
        Me.Controls.Add(Me.butStart)
        Me.Controls.Add(Me.progressBar1)
        Me.Controls.Add(Me.VectorDrawBaseControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Form1"
        Me.Text = "Progress"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VectorDrawBaseControl1 As VectorDraw.Professional.Control.VectorDrawBaseControl
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents comboSpeed As System.Windows.Forms.ComboBox
    Private WithEvents butStart As System.Windows.Forms.Button
    Private WithEvents progressBar1 As System.Windows.Forms.ProgressBar

End Class
