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
        Me.SuspendLayout()
        '
        'VdFramedControl1
        '
        Me.VdFramedControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane
        Me.VdFramedControl1.DisplayPolarCoord = False
        Me.VdFramedControl1.HistoryLines = CType(3UI, UInteger)
        Me.VdFramedControl1.Location = New System.Drawing.Point(3, 3)
        Me.VdFramedControl1.Name = "VdFramedControl1"
        Me.VdFramedControl1.PropertyGridWidth = CType(300UI, UInteger)
        Me.VdFramedControl1.Size = New System.Drawing.Size(1131, 608)
        Me.VdFramedControl1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1138, 614)
        Me.Controls.Add(Me.VdFramedControl1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VdFramedControl1 As vdControls.vdFramedControl

End Class
