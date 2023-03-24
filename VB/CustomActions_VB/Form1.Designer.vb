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
        Me.Label1 = New System.Windows.Forms.Label
        Me.VDMain = New vdScrollableControl.vdScrollableControl
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, -3)
        Me.Label1.MinimumSize = New System.Drawing.Size(848, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(848, 50)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "With this form size small, click anywhere on the rectangle to start dragging it a" & _
            "round. It moves quicly and smoothly."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'VDMain
        '
        Me.VDMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VDMain.BackColor = System.Drawing.SystemColors.Control
        Me.VDMain.Location = New System.Drawing.Point(3, 55)
        Me.VDMain.Margin = New System.Windows.Forms.Padding(1)
        Me.VDMain.Name = "VDMain"
        Me.VDMain.ShowLayoutPopupMenu = True
        Me.VDMain.Size = New System.Drawing.Size(839, 472)
        Me.VDMain.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(845, 530)
        Me.Controls.Add(Me.VDMain)
        Me.Controls.Add(Me.Label1)
        Me.MinimumSize = New System.Drawing.Size(861, 568)
        Me.Name = "Form1"
        Me.Text = "Custom Action Sample VB"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents VDMain As vdScrollableControl.vdScrollableControl

End Class
