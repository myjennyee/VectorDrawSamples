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
        Me.butRotate3d = New System.Windows.Forms.Button
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.comboBox1 = New System.Windows.Forms.ComboBox
        Me.button3 = New System.Windows.Forms.Button
        Me.button1 = New System.Windows.Forms.Button
        Me.button2 = New System.Windows.Forms.Button
        Me.VdFramedControl1 = New vdControls.vdFramedControl
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'butRotate3d
        '
        Me.butRotate3d.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butRotate3d.Location = New System.Drawing.Point(685, 177)
        Me.butRotate3d.Name = "butRotate3d"
        Me.butRotate3d.Size = New System.Drawing.Size(114, 23)
        Me.butRotate3d.TabIndex = 8
        Me.butRotate3d.Text = "3D Rotate"
        Me.butRotate3d.UseVisualStyleBackColor = True
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.Controls.Add(Me.comboBox1)
        Me.groupBox1.Controls.Add(Me.button3)
        Me.groupBox1.Controls.Add(Me.button1)
        Me.groupBox1.Controls.Add(Me.button2)
        Me.groupBox1.Location = New System.Drawing.Point(679, 25)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(122, 146)
        Me.groupBox1.TabIndex = 7
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Collections"
        '
        'comboBox1
        '
        Me.comboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.comboBox1.DropDownHeight = 200
        Me.comboBox1.FormattingEnabled = True
        Me.comboBox1.IntegralHeight = False
        Me.comboBox1.ItemHeight = 13
        Me.comboBox1.Items.AddRange(New Object() {"Blocks", "Layers", "Textstyles", "Dimstyles", "HatchPatterns", "Image Definitions", "Linetypes", "XProperties", "External References", "Layouts", "Lights", "Multilines"})
        Me.comboBox1.Location = New System.Drawing.Point(1, 19)
        Me.comboBox1.Name = "comboBox1"
        Me.comboBox1.Size = New System.Drawing.Size(121, 21)
        Me.comboBox1.TabIndex = 5
        '
        'button3
        '
        Me.button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.button3.Location = New System.Drawing.Point(6, 105)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(114, 34)
        Me.button3.TabIndex = 4
        Me.button3.Text = "Open Collection Form"
        Me.button3.UseVisualStyleBackColor = True
        '
        'button1
        '
        Me.button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.button1.Location = New System.Drawing.Point(6, 47)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(114, 23)
        Me.button1.TabIndex = 2
        Me.button1.Text = "Add Collection items"
        Me.button1.UseVisualStyleBackColor = True
        '
        'button2
        '
        Me.button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.button2.Location = New System.Drawing.Point(6, 76)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(114, 23)
        Me.button2.TabIndex = 3
        Me.button2.Text = "Add Entities"
        Me.button2.UseVisualStyleBackColor = True
        '
        'VdFramedControl1
        '
        Me.VdFramedControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane
        Me.VdFramedControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VdFramedControl1.DisplayPolarCoord = False
        Me.VdFramedControl1.HistoryLines = CType(3UI, UInteger)
        Me.VdFramedControl1.Location = New System.Drawing.Point(13, 15)
        Me.VdFramedControl1.Name = "VdFramedControl1"
        Me.VdFramedControl1.PropertyGridWidth = CType(300UI, UInteger)
        Me.VdFramedControl1.Size = New System.Drawing.Size(649, 503)
        Me.VdFramedControl1.TabIndex = 9
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(813, 531)
        Me.Controls.Add(Me.VdFramedControl1)
        Me.Controls.Add(Me.butRotate3d)
        Me.Controls.Add(Me.groupBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.groupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents butRotate3d As System.Windows.Forms.Button
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents button3 As System.Windows.Forms.Button
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents button2 As System.Windows.Forms.Button
    Friend WithEvents VdFramedControl1 As vdControls.vdFramedControl
    Private WithEvents comboBox1 As System.Windows.Forms.ComboBox

End Class
