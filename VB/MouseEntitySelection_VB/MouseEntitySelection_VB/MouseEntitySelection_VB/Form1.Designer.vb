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
        Me.radioSelectParticularEntities = New System.Windows.Forms.RadioButton
        Me.radioMultipleSelect = New System.Windows.Forms.RadioButton
        Me.radioOneByOne = New System.Windows.Forms.RadioButton
        Me.radioDefaultvdImplementation = New System.Windows.Forms.RadioButton
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
        Me.VdFramedControl1.Location = New System.Drawing.Point(12, 36)
        Me.VdFramedControl1.Name = "VdFramedControl1"
        Me.VdFramedControl1.PropertyGridWidth = CType(300UI, UInteger)
        Me.VdFramedControl1.Size = New System.Drawing.Size(786, 326)
        Me.VdFramedControl1.TabIndex = 0
        '
        'radioSelectParticularEntities
        '
        Me.radioSelectParticularEntities.AutoSize = True
        Me.radioSelectParticularEntities.Location = New System.Drawing.Point(498, 12)
        Me.radioSelectParticularEntities.Name = "radioSelectParticularEntities"
        Me.radioSelectParticularEntities.Size = New System.Drawing.Size(294, 17)
        Me.radioSelectParticularEntities.TabIndex = 8
        Me.radioSelectParticularEntities.TabStop = True
        Me.radioSelectParticularEntities.Text = "Select only Specific Layer Entities (Layer : ""Select""(Red))"
        Me.radioSelectParticularEntities.UseVisualStyleBackColor = True
        '
        'radioMultipleSelect
        '
        Me.radioMultipleSelect.AutoSize = True
        Me.radioMultipleSelect.Location = New System.Drawing.Point(362, 12)
        Me.radioMultipleSelect.Name = "radioMultipleSelect"
        Me.radioMultipleSelect.Size = New System.Drawing.Size(130, 17)
        Me.radioMultipleSelect.TabIndex = 7
        Me.radioMultipleSelect.TabStop = True
        Me.radioMultipleSelect.Text = "Select Multiple entities"
        Me.radioMultipleSelect.UseVisualStyleBackColor = True
        '
        'radioOneByOne
        '
        Me.radioOneByOne.AutoSize = True
        Me.radioOneByOne.Location = New System.Drawing.Point(211, 12)
        Me.radioOneByOne.Name = "radioOneByOne"
        Me.radioOneByOne.Size = New System.Drawing.Size(145, 17)
        Me.radioOneByOne.TabIndex = 6
        Me.radioOneByOne.Text = "Select One By One Entity"
        Me.radioOneByOne.UseVisualStyleBackColor = True
        '
        'radioDefaultvdImplementation
        '
        Me.radioDefaultvdImplementation.AutoSize = True
        Me.radioDefaultvdImplementation.Checked = True
        Me.radioDefaultvdImplementation.Location = New System.Drawing.Point(13, 12)
        Me.radioDefaultvdImplementation.Name = "radioDefaultvdImplementation"
        Me.radioDefaultvdImplementation.Size = New System.Drawing.Size(192, 17)
        Me.radioDefaultvdImplementation.TabIndex = 5
        Me.radioDefaultvdImplementation.TabStop = True
        Me.radioDefaultvdImplementation.Text = "Default VectorDraw Implementation"
        Me.radioDefaultvdImplementation.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 374)
        Me.Controls.Add(Me.radioSelectParticularEntities)
        Me.Controls.Add(Me.radioMultipleSelect)
        Me.Controls.Add(Me.radioOneByOne)
        Me.Controls.Add(Me.radioDefaultvdImplementation)
        Me.Controls.Add(Me.VdFramedControl1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VdFramedControl1 As vdControls.vdFramedControl
    Private WithEvents radioSelectParticularEntities As System.Windows.Forms.RadioButton
    Private WithEvents radioMultipleSelect As System.Windows.Forms.RadioButton
    Private WithEvents radioOneByOne As System.Windows.Forms.RadioButton
    Private WithEvents radioDefaultvdImplementation As System.Windows.Forms.RadioButton

End Class
