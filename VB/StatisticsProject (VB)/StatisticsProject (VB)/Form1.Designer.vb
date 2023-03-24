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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.richTextBox4 = New System.Windows.Forms.RichTextBox
        Me.tabPage1 = New System.Windows.Forms.TabPage
        Me.richTextBox1 = New System.Windows.Forms.RichTextBox
        Me.chart3DCheckBox = New System.Windows.Forms.CheckBox
        Me.tabControl1 = New System.Windows.Forms.TabControl
        Me.tabPage2 = New System.Windows.Forms.TabPage
        Me.richTextBox2 = New System.Windows.Forms.RichTextBox
        Me.tabPage3 = New System.Windows.Forms.TabPage
        Me.richTextBox3 = New System.Windows.Forms.RichTextBox
        Me.tabPage4 = New System.Windows.Forms.TabPage
        Me.tabPage5 = New System.Windows.Forms.TabPage
        Me.richTextBox5 = New System.Windows.Forms.RichTextBox
        Me.tabPage6 = New System.Windows.Forms.TabPage
        Me.richTextBox6 = New System.Windows.Forms.RichTextBox
        Me.panel1 = New System.Windows.Forms.Panel
        Me.BaseControl = New VectorDraw.Professional.Control.VectorDrawBaseControl
        Me.DataGrid = New System.Windows.Forms.DataGridView
        Me.title = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.percentage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.createChart = New System.Windows.Forms.Button
        Me.tabPage1.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.tabPage2.SuspendLayout()
        Me.tabPage3.SuspendLayout()
        Me.tabPage4.SuspendLayout()
        Me.tabPage5.SuspendLayout()
        Me.tabPage6.SuspendLayout()
        Me.panel1.SuspendLayout()
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'richTextBox4
        '
        Me.richTextBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.richTextBox4.Location = New System.Drawing.Point(3, 3)
        Me.richTextBox4.Name = "richTextBox4"
        Me.richTextBox4.ReadOnly = True
        Me.richTextBox4.Size = New System.Drawing.Size(417, 131)
        Me.richTextBox4.TabIndex = 9
        Me.richTextBox4.Text = ""
        '
        'tabPage1
        '
        Me.tabPage1.Controls.Add(Me.richTextBox1)
        Me.tabPage1.Location = New System.Drawing.Point(4, 22)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(423, 137)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "Pie Chart"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'richTextBox1
        '
        Me.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.richTextBox1.Location = New System.Drawing.Point(3, 3)
        Me.richTextBox1.Name = "richTextBox1"
        Me.richTextBox1.ReadOnly = True
        Me.richTextBox1.Size = New System.Drawing.Size(417, 131)
        Me.richTextBox1.TabIndex = 8
        Me.richTextBox1.Tag = ""
        Me.richTextBox1.Text = ""
        '
        'chart3DCheckBox
        '
        Me.chart3DCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chart3DCheckBox.AutoSize = True
        Me.chart3DCheckBox.Location = New System.Drawing.Point(484, 658)
        Me.chart3DCheckBox.Name = "chart3DCheckBox"
        Me.chart3DCheckBox.Size = New System.Drawing.Size(102, 17)
        Me.chart3DCheckBox.TabIndex = 20
        Me.chart3DCheckBox.Text = "Create 3D Chart"
        Me.chart3DCheckBox.UseVisualStyleBackColor = True
        '
        'tabControl1
        '
        Me.tabControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Controls.Add(Me.tabPage3)
        Me.tabControl1.Controls.Add(Me.tabPage4)
        Me.tabControl1.Controls.Add(Me.tabPage5)
        Me.tabControl1.Controls.Add(Me.tabPage6)
        Me.tabControl1.Location = New System.Drawing.Point(12, 599)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(431, 163)
        Me.tabControl1.TabIndex = 19
        '
        'tabPage2
        '
        Me.tabPage2.Controls.Add(Me.richTextBox2)
        Me.tabPage2.Location = New System.Drawing.Point(4, 22)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.Size = New System.Drawing.Size(423, 137)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = "Bar Chart"
        Me.tabPage2.UseVisualStyleBackColor = True
        '
        'richTextBox2
        '
        Me.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.richTextBox2.Location = New System.Drawing.Point(3, 3)
        Me.richTextBox2.Name = "richTextBox2"
        Me.richTextBox2.ReadOnly = True
        Me.richTextBox2.Size = New System.Drawing.Size(417, 131)
        Me.richTextBox2.TabIndex = 9
        Me.richTextBox2.Text = ""
        '
        'tabPage3
        '
        Me.tabPage3.Controls.Add(Me.richTextBox3)
        Me.tabPage3.Location = New System.Drawing.Point(4, 22)
        Me.tabPage3.Name = "tabPage3"
        Me.tabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage3.Size = New System.Drawing.Size(423, 137)
        Me.tabPage3.TabIndex = 2
        Me.tabPage3.Text = "Line Chart"
        Me.tabPage3.UseVisualStyleBackColor = True
        '
        'richTextBox3
        '
        Me.richTextBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.richTextBox3.Location = New System.Drawing.Point(3, 3)
        Me.richTextBox3.Name = "richTextBox3"
        Me.richTextBox3.ReadOnly = True
        Me.richTextBox3.Size = New System.Drawing.Size(417, 131)
        Me.richTextBox3.TabIndex = 9
        Me.richTextBox3.Text = ""
        '
        'tabPage4
        '
        Me.tabPage4.Controls.Add(Me.richTextBox4)
        Me.tabPage4.Location = New System.Drawing.Point(4, 22)
        Me.tabPage4.Name = "tabPage4"
        Me.tabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage4.Size = New System.Drawing.Size(423, 137)
        Me.tabPage4.TabIndex = 3
        Me.tabPage4.Text = "Bars Chart"
        Me.tabPage4.UseVisualStyleBackColor = True
        '
        'tabPage5
        '
        Me.tabPage5.Controls.Add(Me.richTextBox5)
        Me.tabPage5.Location = New System.Drawing.Point(4, 22)
        Me.tabPage5.Name = "tabPage5"
        Me.tabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage5.Size = New System.Drawing.Size(423, 137)
        Me.tabPage5.TabIndex = 4
        Me.tabPage5.Text = "Wave Chart"
        Me.tabPage5.UseVisualStyleBackColor = True
        '
        'richTextBox5
        '
        Me.richTextBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.richTextBox5.Location = New System.Drawing.Point(3, 3)
        Me.richTextBox5.Name = "richTextBox5"
        Me.richTextBox5.ReadOnly = True
        Me.richTextBox5.Size = New System.Drawing.Size(417, 131)
        Me.richTextBox5.TabIndex = 9
        Me.richTextBox5.Text = ""
        '
        'tabPage6
        '
        Me.tabPage6.Controls.Add(Me.richTextBox6)
        Me.tabPage6.Location = New System.Drawing.Point(4, 22)
        Me.tabPage6.Name = "tabPage6"
        Me.tabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage6.Size = New System.Drawing.Size(423, 137)
        Me.tabPage6.TabIndex = 5
        Me.tabPage6.Text = "Horizontal Bars Chart"
        Me.tabPage6.UseVisualStyleBackColor = True
        '
        'richTextBox6
        '
        Me.richTextBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.richTextBox6.Location = New System.Drawing.Point(3, 3)
        Me.richTextBox6.Name = "richTextBox6"
        Me.richTextBox6.ReadOnly = True
        Me.richTextBox6.Size = New System.Drawing.Size(417, 131)
        Me.richTextBox6.TabIndex = 9
        Me.richTextBox6.Text = ""
        '
        'panel1
        '
        Me.panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panel1.Controls.Add(Me.BaseControl)
        Me.panel1.Location = New System.Drawing.Point(12, 12)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(1121, 581)
        Me.panel1.TabIndex = 18
        '
        'BaseControl
        '
        Me.BaseControl.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.BaseControl.AllowDrop = True
        Me.BaseControl.Cursor = System.Windows.Forms.Cursors.Default
        Me.BaseControl.DisableVdrawDxf = False
        Me.BaseControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BaseControl.EnableAutoGripOn = True
        Me.BaseControl.Location = New System.Drawing.Point(0, 0)
        Me.BaseControl.Name = "BaseControl"
        Me.BaseControl.Size = New System.Drawing.Size(1117, 577)
        Me.BaseControl.TabIndex = 0
        '
        'DataGrid
        '
        Me.DataGrid.AllowUserToResizeColumns = False
        Me.DataGrid.AllowUserToResizeRows = False
        Me.DataGrid.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.title, Me.percentage})
        Me.DataGrid.Location = New System.Drawing.Point(592, 615)
        Me.DataGrid.Name = "DataGrid"
        Me.DataGrid.Size = New System.Drawing.Size(541, 143)
        Me.DataGrid.TabIndex = 24
        '
        'title
        '
        Me.title.HeaderText = "Title"
        Me.title.Name = "title"
        Me.title.Width = 150
        '
        'percentage
        '
        Me.percentage.HeaderText = "Percentage"
        Me.percentage.Name = "percentage"
        '
        'createChart
        '
        Me.createChart.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.createChart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.createChart.Location = New System.Drawing.Point(449, 681)
        Me.createChart.Name = "createChart"
        Me.createChart.Size = New System.Drawing.Size(137, 81)
        Me.createChart.TabIndex = 21
        Me.createChart.Text = "Redraw Chart"
        Me.createChart.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1145, 774)
        Me.Controls.Add(Me.chart3DCheckBox)
        Me.Controls.Add(Me.tabControl1)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.DataGrid)
        Me.Controls.Add(Me.createChart)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(1161, 812)
        Me.MinimumSize = New System.Drawing.Size(1161, 812)
        Me.Name = "Form1"
        Me.Text = "Statistics Example"
        Me.tabPage1.ResumeLayout(False)
        Me.tabControl1.ResumeLayout(False)
        Me.tabPage2.ResumeLayout(False)
        Me.tabPage3.ResumeLayout(False)
        Me.tabPage4.ResumeLayout(False)
        Me.tabPage5.ResumeLayout(False)
        Me.tabPage6.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents richTextBox4 As System.Windows.Forms.RichTextBox
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents richTextBox1 As System.Windows.Forms.RichTextBox
    Private WithEvents chart3DCheckBox As System.Windows.Forms.CheckBox
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents richTextBox2 As System.Windows.Forms.RichTextBox
    Private WithEvents tabPage3 As System.Windows.Forms.TabPage
    Private WithEvents richTextBox3 As System.Windows.Forms.RichTextBox
    Private WithEvents tabPage4 As System.Windows.Forms.TabPage
    Private WithEvents tabPage5 As System.Windows.Forms.TabPage
    Private WithEvents richTextBox5 As System.Windows.Forms.RichTextBox
    Private WithEvents tabPage6 As System.Windows.Forms.TabPage
    Private WithEvents richTextBox6 As System.Windows.Forms.RichTextBox
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents DataGrid As System.Windows.Forms.DataGridView
    Private WithEvents title As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents percentage As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents createChart As System.Windows.Forms.Button
    Friend WithEvents BaseControl As VectorDraw.Professional.Control.VectorDrawBaseControl

End Class
