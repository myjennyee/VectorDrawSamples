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
        Me.tabControl1 = New System.Windows.Forms.TabControl
        Me.tabPage1 = New System.Windows.Forms.TabPage
        Me.vdFramedControl1 = New vdControls.vdFramedControl
        Me.tabPage2 = New System.Windows.Forms.TabPage
        Me.VdFramedControl2 = New vdControls.vdFramedControl
        Me.panel1 = New System.Windows.Forms.Panel
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.label2 = New System.Windows.Forms.Label
        Me.checkProjection = New System.Windows.Forms.CheckBox
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.combodegrees = New System.Windows.Forms.ComboBox
        Me.label1 = New System.Windows.Forms.Label
        Me.Calculate = New System.Windows.Forms.Button
        Me.textPrecision = New System.Windows.Forms.NumericUpDown
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        CType(Me.textPrecision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControl1.HotTrack = True
        Me.tabControl1.ItemSize = New System.Drawing.Size(100, 30)
        Me.tabControl1.Location = New System.Drawing.Point(0, 0)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(798, 419)
        Me.tabControl1.TabIndex = 8
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.vdFramedControl1)
        Me.tabPage1.Location = New System.Drawing.Point(4, 34)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(790, 381)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Polyline Area"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'vdFramedControl1
        '
        Me.vdFramedControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane
        Me.vdFramedControl1.DisplayPolarCoord = False
        Me.vdFramedControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vdFramedControl1.HistoryLines = CType(3UI, UInteger)
        Me.vdFramedControl1.Location = New System.Drawing.Point(3, 3)
        Me.vdFramedControl1.Name = "vdFramedControl1"
        Me.vdFramedControl1.PropertyGridWidth = CType(300UI, UInteger)
        Me.vdFramedControl1.Size = New System.Drawing.Size(784, 375)
        Me.vdFramedControl1.TabIndex = 0
        '
        'tabPage2
        '
        Me.tabPage2.BackColor = System.Drawing.Color.Transparent
        Me.tabPage2.Controls.Add(Me.VdFramedControl2)
        Me.tabPage2.Location = New System.Drawing.Point(4, 34)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(790, 381)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "Solid Area"
        '
        'VdFramedControl2
        '
        Me.VdFramedControl2.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane
        Me.VdFramedControl2.DisplayPolarCoord = False
        Me.VdFramedControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VdFramedControl2.HistoryLines = CType(3UI, UInteger)
        Me.VdFramedControl2.Location = New System.Drawing.Point(3, 3)
        Me.VdFramedControl2.Name = "VdFramedControl2"
        Me.VdFramedControl2.PropertyGridWidth = CType(300UI, UInteger)
        Me.VdFramedControl2.Size = New System.Drawing.Size(784, 375)
        Me.VdFramedControl2.TabIndex = 1
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.groupBox2)
        Me.panel1.Controls.Add(Me.groupBox1)
        Me.panel1.Controls.Add(Me.Calculate)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.panel1.Location = New System.Drawing.Point(798, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(116, 419)
        Me.panel1.TabIndex = 7
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.textPrecision)
        Me.groupBox2.Controls.Add(Me.label2)
        Me.groupBox2.Controls.Add(Me.checkProjection)
        Me.groupBox2.Location = New System.Drawing.Point(6, 114)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(107, 80)
        Me.groupBox2.TabIndex = 8
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Solid Area"
        '
        'label2
        '
        Me.label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 16)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(50, 13)
        Me.label2.TabIndex = 5
        Me.label2.Text = "Precision"
        '
        'checkProjection
        '
        Me.checkProjection.AutoSize = True
        Me.checkProjection.Enabled = False
        Me.checkProjection.Location = New System.Drawing.Point(12, 58)
        Me.checkProjection.Name = "checkProjection"
        Me.checkProjection.Size = New System.Drawing.Size(73, 17)
        Me.checkProjection.TabIndex = 6
        Me.checkProjection.Text = "Projection"
        Me.checkProjection.UseVisualStyleBackColor = True
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.combodegrees)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Location = New System.Drawing.Point(6, 43)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(107, 63)
        Me.groupBox1.TabIndex = 7
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Polyline Area"
        '
        'combodegrees
        '
        Me.combodegrees.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.combodegrees.FormattingEnabled = True
        Me.combodegrees.Items.AddRange(New Object() {"0", "15", "30", "45", "60", "75", "90", "120", "150"})
        Me.combodegrees.Location = New System.Drawing.Point(12, 32)
        Me.combodegrees.Name = "combodegrees"
        Me.combodegrees.Size = New System.Drawing.Size(86, 21)
        Me.combodegrees.TabIndex = 2
        '
        'label1
        '
        Me.label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(47, 13)
        Me.label1.TabIndex = 3
        Me.label1.Text = "Degrees"
        '
        'Calculate
        '
        Me.Calculate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Calculate.Location = New System.Drawing.Point(18, 12)
        Me.Calculate.Name = "Calculate"
        Me.Calculate.Size = New System.Drawing.Size(86, 25)
        Me.Calculate.TabIndex = 1
        Me.Calculate.Text = "Calculate"
        Me.Calculate.UseVisualStyleBackColor = True
        '
        'textPrecision
        '
        Me.textPrecision.DecimalPlaces = 4
        Me.textPrecision.Enabled = False
        Me.textPrecision.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.textPrecision.Location = New System.Drawing.Point(12, 32)
        Me.textPrecision.Minimum = New Decimal(New Integer() {5, 0, 0, 327680})
        Me.textPrecision.Name = "textPrecision"
        Me.textPrecision.Size = New System.Drawing.Size(86, 20)
        Me.textPrecision.TabIndex = 9
        Me.textPrecision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.textPrecision.Value = New Decimal(New Integer() {5, 0, 0, 131072})
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 419)
        Me.Controls.Add(Me.tabControl1)
        Me.Controls.Add(Me.panel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tabControl1.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.tabPage2.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        CType(Me.textPrecision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents vdFramedControl1 As vdControls.vdFramedControl
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents checkProjection As System.Windows.Forms.CheckBox
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents combodegrees As System.Windows.Forms.ComboBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents Calculate As System.Windows.Forms.Button
    Private WithEvents VdFramedControl2 As vdControls.vdFramedControl
    Private WithEvents textPrecision As System.Windows.Forms.NumericUpDown

End Class
