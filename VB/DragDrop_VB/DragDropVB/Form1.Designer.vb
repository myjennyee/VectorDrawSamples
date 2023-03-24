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
        Me.label = New System.Windows.Forms.TextBox
        Me.ImageButton = New System.Windows.Forms.Button
        Me.vdSource = New VectorDraw.Professional.Control.VectorDrawBaseControl
        Me.vdDest = New VectorDraw.Professional.Control.VectorDrawBaseControl
        Me.SuspendLayout()
        '
        'label
        '
        Me.label.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.label.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.label.ForeColor = System.Drawing.SystemColors.WindowText
        Me.label.Location = New System.Drawing.Point(307, 235)
        Me.label.Multiline = True
        Me.label.Name = "label"
        Me.label.Size = New System.Drawing.Size(255, 192)
        Me.label.TabIndex = 6
        '
        'ImageButton
        '
        Me.ImageButton.AllowDrop = True
        Me.ImageButton.Location = New System.Drawing.Point(12, 235)
        Me.ImageButton.Name = "ImageButton"
        Me.ImageButton.Size = New System.Drawing.Size(263, 192)
        Me.ImageButton.TabIndex = 7
        Me.ImageButton.Text = "ImageButton"
        Me.ImageButton.UseVisualStyleBackColor = True
        '
        'vdSource
        '
        Me.vdSource.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.vdSource.AllowDrop = True
        Me.vdSource.Cursor = System.Windows.Forms.Cursors.Default
        Me.vdSource.DisableVdrawDxf = False
        Me.vdSource.EnableAutoGripOn = True
        Me.vdSource.Location = New System.Drawing.Point(12, 12)
        Me.vdSource.Name = "vdSource"
        Me.vdSource.Size = New System.Drawing.Size(262, 214)
        Me.vdSource.TabIndex = 8
        '
        'vdDest
        '
        Me.vdDest.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.vdDest.AllowDrop = True
        Me.vdDest.Cursor = System.Windows.Forms.Cursors.Default
        Me.vdDest.DisableVdrawDxf = False
        Me.vdDest.EnableAutoGripOn = True
        Me.vdDest.Location = New System.Drawing.Point(300, 12)
        Me.vdDest.Name = "vdDest"
        Me.vdDest.Size = New System.Drawing.Size(262, 214)
        Me.vdDest.TabIndex = 9
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(574, 439)
        Me.Controls.Add(Me.vdDest)
        Me.Controls.Add(Me.vdSource)
        Me.Controls.Add(Me.ImageButton)
        Me.Controls.Add(Me.label)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label As System.Windows.Forms.TextBox
    Private WithEvents ImageButton As System.Windows.Forms.Button
    Friend WithEvents vdSource As VectorDraw.Professional.Control.VectorDrawBaseControl
    Friend WithEvents vdDest As VectorDraw.Professional.Control.VectorDrawBaseControl

End Class
