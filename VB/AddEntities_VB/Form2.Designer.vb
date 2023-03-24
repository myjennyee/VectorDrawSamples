<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.butAddContour = New System.Windows.Forms.Button
        Me.labContours = New System.Windows.Forms.Label
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.butRotate = New System.Windows.Forms.Button
        Me.radioequasion2 = New System.Windows.Forms.RadioButton
        Me.radioequasion1 = New System.Windows.Forms.RadioButton
        Me.vdFramedControl1 = New vdControls.vdFramedControl
        Me.radioMappedImage = New System.Windows.Forms.RadioButton
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'butAddContour
        '
        Me.butAddContour.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butAddContour.Location = New System.Drawing.Point(6, 51)
        Me.butAddContour.Name = "butAddContour"
        Me.butAddContour.Size = New System.Drawing.Size(112, 23)
        Me.butAddContour.TabIndex = 1
        Me.butAddContour.Text = "Add Contour"
        Me.butAddContour.UseVisualStyleBackColor = True
        '
        'labContours
        '
        Me.labContours.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labContours.AutoSize = True
        Me.labContours.Location = New System.Drawing.Point(6, 25)
        Me.labContours.Name = "labContours"
        Me.labContours.Size = New System.Drawing.Size(35, 13)
        Me.labContours.TabIndex = 0
        Me.labContours.Text = "label1"
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.Controls.Add(Me.labContours)
        Me.groupBox1.Controls.Add(Me.butAddContour)
        Me.groupBox1.Location = New System.Drawing.Point(724, 154)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(124, 83)
        Me.groupBox1.TabIndex = 4
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Contours"
        '
        'butRotate
        '
        Me.butRotate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butRotate.Location = New System.Drawing.Point(724, 243)
        Me.butRotate.Name = "butRotate"
        Me.butRotate.Size = New System.Drawing.Size(124, 23)
        Me.butRotate.TabIndex = 5
        Me.butRotate.Text = "3D Rotate"
        Me.butRotate.UseVisualStyleBackColor = True
        '
        'radioequasion2
        '
        Me.radioequasion2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.radioequasion2.AutoSize = True
        Me.radioequasion2.Location = New System.Drawing.Point(724, 48)
        Me.radioequasion2.Name = "radioequasion2"
        Me.radioequasion2.Size = New System.Drawing.Size(109, 17)
        Me.radioequasion2.TabIndex = 2
        Me.radioequasion2.Text = "Second Equasion"
        Me.radioequasion2.UseVisualStyleBackColor = True
        '
        'radioequasion1
        '
        Me.radioequasion1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.radioequasion1.AutoSize = True
        Me.radioequasion1.Location = New System.Drawing.Point(724, 25)
        Me.radioequasion1.Name = "radioequasion1"
        Me.radioequasion1.Size = New System.Drawing.Size(91, 17)
        Me.radioequasion1.TabIndex = 1
        Me.radioequasion1.Text = "First Equasion"
        Me.radioequasion1.UseVisualStyleBackColor = True
        '
        'vdFramedControl1
        '
        Me.vdFramedControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane
        Me.vdFramedControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vdFramedControl1.DisplayPolarCoord = False
        Me.vdFramedControl1.HistoryLines = CType(3UI, UInteger)
        Me.vdFramedControl1.Location = New System.Drawing.Point(1, 2)
        Me.vdFramedControl1.Name = "vdFramedControl1"
        Me.vdFramedControl1.PropertyGridWidth = CType(300UI, UInteger)
        Me.vdFramedControl1.Size = New System.Drawing.Size(717, 512)
        Me.vdFramedControl1.TabIndex = 0
        '
        'radioMappedImage
        '
        Me.radioMappedImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.radioMappedImage.AutoSize = True
        Me.radioMappedImage.Location = New System.Drawing.Point(724, 71)
        Me.radioMappedImage.Name = "radioMappedImage"
        Me.radioMappedImage.Size = New System.Drawing.Size(96, 17)
        Me.radioMappedImage.TabIndex = 3
        Me.radioMappedImage.Text = "Mapped Image"
        Me.radioMappedImage.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(860, 526)
        Me.Controls.Add(Me.radioMappedImage)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.butRotate)
        Me.Controls.Add(Me.radioequasion2)
        Me.Controls.Add(Me.radioequasion1)
        Me.Controls.Add(Me.vdFramedControl1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents butAddContour As System.Windows.Forms.Button
    Private WithEvents labContours As System.Windows.Forms.Label
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents butRotate As System.Windows.Forms.Button
    Private WithEvents radioequasion2 As System.Windows.Forms.RadioButton
    Private WithEvents radioequasion1 As System.Windows.Forms.RadioButton
    Private WithEvents vdFramedControl1 As vdControls.vdFramedControl
    Private WithEvents radioMappedImage As System.Windows.Forms.RadioButton
End Class
