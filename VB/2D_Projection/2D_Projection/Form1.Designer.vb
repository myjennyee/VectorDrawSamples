<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TwoD_Projection
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
        Me.button3 = New System.Windows.Forms.Button
        Me.button2 = New System.Windows.Forms.Button
        Me.button1 = New System.Windows.Forms.Button
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
        Me.VdFramedControl1.Location = New System.Drawing.Point(3, 5)
        Me.VdFramedControl1.Name = "VdFramedControl1"
        Me.VdFramedControl1.PropertyGridWidth = CType(300UI, UInteger)
        Me.VdFramedControl1.Size = New System.Drawing.Size(794, 497)
        Me.VdFramedControl1.TabIndex = 0
        '
        'button3
        '
        Me.button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.button3.BackColor = System.Drawing.Color.Cyan
        Me.button3.Location = New System.Drawing.Point(409, 508)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(197, 27)
        Me.button3.TabIndex = 6
        Me.button3.Text = "Create 2D Projection Area3"
        Me.button3.UseVisualStyleBackColor = False
        '
        'button2
        '
        Me.button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.button2.BackColor = System.Drawing.Color.Lime
        Me.button2.Location = New System.Drawing.Point(206, 508)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(197, 27)
        Me.button2.TabIndex = 5
        Me.button2.Text = "Create 2D Projection Area2"
        Me.button2.UseVisualStyleBackColor = False
        '
        'button1
        '
        Me.button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.button1.BackColor = System.Drawing.Color.Yellow
        Me.button1.Location = New System.Drawing.Point(3, 508)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(197, 27)
        Me.button1.TabIndex = 4
        Me.button1.Text = "Create 2D Projection Area1"
        Me.button1.UseVisualStyleBackColor = False
        '
        'TwoD_Projection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 544)
        Me.Controls.Add(Me.button3)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.VdFramedControl1)
        Me.Name = "TwoD_Projection"
        Me.Text = "2D Projection - This sample demonstrates how to create a 2D projection of a drawi" & _
            "ng"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VdFramedControl1 As vdControls.vdFramedControl
    Private WithEvents button3 As System.Windows.Forms.Button
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents button1 As System.Windows.Forms.Button

End Class
