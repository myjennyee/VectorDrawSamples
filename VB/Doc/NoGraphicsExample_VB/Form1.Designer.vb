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
        Me.components = New System.ComponentModel.Container
        Me.Label1 = New System.Windows.Forms.Label
        Me.picPrev1 = New System.Windows.Forms.PictureBox
        Me.ButExport = New System.Windows.Forms.Button
        Me.ButExit = New System.Windows.Forms.Button
        Me.VdDocumentComponent1 = New VectorDraw.Professional.Components.vdDocumentComponent(Me.components)
        CType(Me.picPrev1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Preview Image!"
        '
        'picPrev1
        '
        Me.picPrev1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picPrev1.Location = New System.Drawing.Point(15, 25)
        Me.picPrev1.Name = "picPrev1"
        Me.picPrev1.Size = New System.Drawing.Size(208, 253)
        Me.picPrev1.TabIndex = 1
        Me.picPrev1.TabStop = False
        '
        'ButExport
        '
        Me.ButExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButExport.Location = New System.Drawing.Point(17, 285)
        Me.ButExport.Name = "ButExport"
        Me.ButExport.Size = New System.Drawing.Size(75, 23)
        Me.ButExport.TabIndex = 2
        Me.ButExport.Text = "Export"
        Me.ButExport.UseVisualStyleBackColor = True
        '
        'ButExit
        '
        Me.ButExit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButExit.Location = New System.Drawing.Point(148, 285)
        Me.ButExit.Name = "ButExit"
        Me.ButExit.Size = New System.Drawing.Size(75, 23)
        Me.ButExit.TabIndex = 3
        Me.ButExit.Text = "Exit"
        Me.ButExit.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(235, 320)
        Me.Controls.Add(Me.ButExit)
        Me.Controls.Add(Me.ButExport)
        Me.Controls.Add(Me.picPrev1)
        Me.Controls.Add(Me.Label1)
        Me.MinimumSize = New System.Drawing.Size(214, 322)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.picPrev1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picPrev1 As System.Windows.Forms.PictureBox
    Friend WithEvents ButExport As System.Windows.Forms.Button
    Friend WithEvents ButExit As System.Windows.Forms.Button
    Friend WithEvents VdDocumentComponent1 As VectorDraw.Professional.Components.vdDocumentComponent

End Class
