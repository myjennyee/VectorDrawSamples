<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.VdFramedControl1 = New vdControls.vdFramedControl
        Me.SuspendLayout()
        '
        'label5
        '
        Me.label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(3, 465)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(960, 13)
        Me.label5.TabIndex = 10
        Me.label5.Text = "Very Important Notice:You should be very carefull when you name your custom objec" & _
            "ts.It is recommended to use unique names like (VectorDrawMultiline) to avoid ide" & _
            "ntical named custom objects later on."
        '
        'label4
        '
        Me.label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(3, 531)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(793, 13)
        Me.label4.TabIndex = 9
        Me.label4.Text = "4)MultiLine:This object inherits the vdPolyline object and with the help of the o" & _
            "ffset command the appearence is different.Check the extra properties that this o" & _
            "bject has."
        '
        'label3
        '
        Me.label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(3, 518)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(601, 13)
        Me.label3.TabIndex = 8
        Me.label3.Text = "3)Polygon:This object is inherits from the vdShape which is an object created for" & _
            " this purpose (to easily create custom objects)."
        '
        'label2
        '
        Me.label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(3, 505)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(1008, 13)
        Me.label2.TabIndex = 7
        Me.label2.Text = resources.GetString("label2.Text")
        '
        'label1
        '
        Me.label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(3, 492)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(867, 13)
        Me.label1.TabIndex = 6
        Me.label1.Text = "1)ArrowLine:This custom object has the ability to have the arrow always visible a" & _
            "nd perpedicular to the viewer's eye.3D rotate a scene having an object like this" & _
            " one and see the result."
        '
        'VdFramedControl1
        '
        Me.VdFramedControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane
        Me.VdFramedControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VdFramedControl1.DisplayPolarCoord = False
        Me.VdFramedControl1.Location = New System.Drawing.Point(12, 12)
        Me.VdFramedControl1.Name = "VdFramedControl1"
        Me.VdFramedControl1.Size = New System.Drawing.Size(852, 450)
        Me.VdFramedControl1.TabIndex = 11
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(876, 552)
        Me.Controls.Add(Me.VdFramedControl1)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Name = "Form1"
        Me.Text = "Custom Objects VB"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents VdFramedControl1 As vdControls.vdFramedControl

End Class
