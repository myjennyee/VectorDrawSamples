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
        Me.panel1 = New System.Windows.Forms.Panel
        Me.richTextBox1 = New System.Windows.Forms.RichTextBox
        Me.button1 = New System.Windows.Forms.Button
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.textMouseDown = New System.Windows.Forms.TextBox
        Me.textMouseUp = New System.Windows.Forms.TextBox
        Me.textMouseOverDraw = New System.Windows.Forms.TextBox
        Me.textMouseMove = New System.Windows.Forms.TextBox
        Me.textMouseLeave = New System.Windows.Forms.TextBox
        Me.textMouseEnter = New System.Windows.Forms.TextBox
        Me.label7 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.label1 = New System.Windows.Forms.Label
        Me.buttonDrawline = New System.Windows.Forms.Button
        Me.checkUrls = New System.Windows.Forms.CheckBox
        Me.comboOsnaps = New System.Windows.Forms.ComboBox
        Me.checkTooltips = New System.Windows.Forms.CheckBox
        Me.checkSelectionPreview = New System.Windows.Forms.CheckBox
        Me.panel2 = New System.Windows.Forms.Panel
        Me.VectorDrawBaseControl1 = New VectorDraw.Professional.Control.VectorDrawBaseControl
        Me.panel1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        Me.panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.richTextBox1)
        Me.panel1.Controls.Add(Me.button1)
        Me.panel1.Controls.Add(Me.groupBox2)
        Me.panel1.Controls.Add(Me.groupBox1)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(1123, 151)
        Me.panel1.TabIndex = 2
        '
        'richTextBox1
        '
        Me.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.richTextBox1.Location = New System.Drawing.Point(637, 12)
        Me.richTextBox1.Name = "richTextBox1"
        Me.richTextBox1.ReadOnly = True
        Me.richTextBox1.Size = New System.Drawing.Size(416, 131)
        Me.richTextBox1.TabIndex = 4
        Me.richTextBox1.Text = resources.GetString("richTextBox1.Text")
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(12, 12)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(86, 27)
        Me.button1.TabIndex = 2
        Me.button1.Text = "Reopen file"
        Me.button1.UseVisualStyleBackColor = True
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.textMouseDown)
        Me.groupBox2.Controls.Add(Me.textMouseUp)
        Me.groupBox2.Controls.Add(Me.textMouseOverDraw)
        Me.groupBox2.Controls.Add(Me.textMouseMove)
        Me.groupBox2.Controls.Add(Me.textMouseLeave)
        Me.groupBox2.Controls.Add(Me.textMouseEnter)
        Me.groupBox2.Controls.Add(Me.label7)
        Me.groupBox2.Controls.Add(Me.label6)
        Me.groupBox2.Controls.Add(Me.label5)
        Me.groupBox2.Controls.Add(Me.label4)
        Me.groupBox2.Controls.Add(Me.label3)
        Me.groupBox2.Controls.Add(Me.label2)
        Me.groupBox2.Location = New System.Drawing.Point(333, 12)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(298, 132)
        Me.groupBox2.TabIndex = 1
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Event type"
        '
        'textMouseDown
        '
        Me.textMouseDown.Location = New System.Drawing.Point(240, 23)
        Me.textMouseDown.Name = "textMouseDown"
        Me.textMouseDown.Size = New System.Drawing.Size(38, 20)
        Me.textMouseDown.TabIndex = 11
        Me.textMouseDown.Text = "0"
        '
        'textMouseUp
        '
        Me.textMouseUp.Location = New System.Drawing.Point(240, 45)
        Me.textMouseUp.Name = "textMouseUp"
        Me.textMouseUp.Size = New System.Drawing.Size(38, 20)
        Me.textMouseUp.TabIndex = 10
        Me.textMouseUp.Text = "0"
        '
        'textMouseOverDraw
        '
        Me.textMouseOverDraw.Location = New System.Drawing.Point(240, 68)
        Me.textMouseOverDraw.Name = "textMouseOverDraw"
        Me.textMouseOverDraw.Size = New System.Drawing.Size(38, 20)
        Me.textMouseOverDraw.TabIndex = 9
        Me.textMouseOverDraw.Text = "0"
        '
        'textMouseMove
        '
        Me.textMouseMove.Location = New System.Drawing.Point(76, 69)
        Me.textMouseMove.Name = "textMouseMove"
        Me.textMouseMove.Size = New System.Drawing.Size(38, 20)
        Me.textMouseMove.TabIndex = 8
        Me.textMouseMove.Text = "0"
        '
        'textMouseLeave
        '
        Me.textMouseLeave.Location = New System.Drawing.Point(76, 46)
        Me.textMouseLeave.Name = "textMouseLeave"
        Me.textMouseLeave.Size = New System.Drawing.Size(38, 20)
        Me.textMouseLeave.TabIndex = 7
        Me.textMouseLeave.Text = "0"
        '
        'textMouseEnter
        '
        Me.textMouseEnter.Location = New System.Drawing.Point(76, 22)
        Me.textMouseEnter.Name = "textMouseEnter"
        Me.textMouseEnter.Size = New System.Drawing.Size(38, 20)
        Me.textMouseEnter.TabIndex = 6
        Me.textMouseEnter.Text = "0"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(147, 71)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(87, 13)
        Me.label7.TabIndex = 5
        Me.label7.Text = "MouseOverDraw"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(147, 48)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(53, 13)
        Me.label6.TabIndex = 4
        Me.label6.Text = "MouseUp"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(147, 25)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(67, 13)
        Me.label5.TabIndex = 3
        Me.label5.Text = "MouseDown"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(6, 72)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(66, 13)
        Me.label4.TabIndex = 2
        Me.label4.Text = "MouseMove"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(6, 49)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(69, 13)
        Me.label3.TabIndex = 1
        Me.label3.Text = "MouseLeave"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(6, 26)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(64, 13)
        Me.label2.TabIndex = 0
        Me.label2.Text = "MouseEnter"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.buttonDrawline)
        Me.groupBox1.Controls.Add(Me.checkUrls)
        Me.groupBox1.Controls.Add(Me.comboOsnaps)
        Me.groupBox1.Controls.Add(Me.checkTooltips)
        Me.groupBox1.Controls.Add(Me.checkSelectionPreview)
        Me.groupBox1.Location = New System.Drawing.Point(104, 12)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(223, 132)
        Me.groupBox1.TabIndex = 0
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Use various combinations"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(61, 86)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(66, 13)
        Me.label1.TabIndex = 2
        Me.label1.Text = "osnap Mode"
        '
        'buttonDrawline
        '
        Me.buttonDrawline.Location = New System.Drawing.Point(133, 102)
        Me.buttonDrawline.Name = "buttonDrawline"
        Me.buttonDrawline.Size = New System.Drawing.Size(65, 21)
        Me.buttonDrawline.TabIndex = 3
        Me.buttonDrawline.Text = "Draw Line"
        Me.buttonDrawline.UseVisualStyleBackColor = True
        '
        'checkUrls
        '
        Me.checkUrls.AutoSize = True
        Me.checkUrls.Location = New System.Drawing.Point(6, 71)
        Me.checkUrls.Name = "checkUrls"
        Me.checkUrls.Size = New System.Drawing.Size(44, 17)
        Me.checkUrls.TabIndex = 2
        Me.checkUrls.Text = "Urls"
        Me.checkUrls.UseVisualStyleBackColor = True
        '
        'comboOsnaps
        '
        Me.comboOsnaps.FormattingEnabled = True
        Me.comboOsnaps.Location = New System.Drawing.Point(6, 102)
        Me.comboOsnaps.Name = "comboOsnaps"
        Me.comboOsnaps.Size = New System.Drawing.Size(121, 21)
        Me.comboOsnaps.TabIndex = 1
        '
        'checkTooltips
        '
        Me.checkTooltips.AutoSize = True
        Me.checkTooltips.Location = New System.Drawing.Point(6, 48)
        Me.checkTooltips.Name = "checkTooltips"
        Me.checkTooltips.Size = New System.Drawing.Size(63, 17)
        Me.checkTooltips.TabIndex = 1
        Me.checkTooltips.Text = "Tooltips"
        Me.checkTooltips.UseVisualStyleBackColor = True
        '
        'checkSelectionPreview
        '
        Me.checkSelectionPreview.AutoSize = True
        Me.checkSelectionPreview.Location = New System.Drawing.Point(6, 25)
        Me.checkSelectionPreview.Name = "checkSelectionPreview"
        Me.checkSelectionPreview.Size = New System.Drawing.Size(108, 17)
        Me.checkSelectionPreview.TabIndex = 0
        Me.checkSelectionPreview.Text = "SelectionPreview"
        Me.checkSelectionPreview.UseVisualStyleBackColor = True
        '
        'panel2
        '
        Me.panel2.Controls.Add(Me.VectorDrawBaseControl1)
        Me.panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel2.Location = New System.Drawing.Point(0, 0)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(1123, 667)
        Me.panel2.TabIndex = 3
        '
        'VectorDrawBaseControl1
        '
        Me.VectorDrawBaseControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.VectorDrawBaseControl1.AllowDrop = True
        Me.VectorDrawBaseControl1.Cursor = System.Windows.Forms.Cursors.Default
        Me.VectorDrawBaseControl1.DisableVdrawDxf = False
        Me.VectorDrawBaseControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VectorDrawBaseControl1.EnableAutoGripOn = True
        Me.VectorDrawBaseControl1.Location = New System.Drawing.Point(0, 0)
        Me.VectorDrawBaseControl1.Name = "VectorDrawBaseControl1"
        Me.VectorDrawBaseControl1.Size = New System.Drawing.Size(1123, 667)
        Me.VectorDrawBaseControl1.TabIndex = 0
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1123, 667)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.panel2)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.panel1.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents richTextBox1 As System.Windows.Forms.RichTextBox
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents textMouseDown As System.Windows.Forms.TextBox
    Private WithEvents textMouseUp As System.Windows.Forms.TextBox
    Private WithEvents textMouseOverDraw As System.Windows.Forms.TextBox
    Private WithEvents textMouseMove As System.Windows.Forms.TextBox
    Private WithEvents textMouseLeave As System.Windows.Forms.TextBox
    Private WithEvents textMouseEnter As System.Windows.Forms.TextBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents buttonDrawline As System.Windows.Forms.Button
    Private WithEvents checkUrls As System.Windows.Forms.CheckBox
    Private WithEvents comboOsnaps As System.Windows.Forms.ComboBox
    Private WithEvents checkTooltips As System.Windows.Forms.CheckBox
    Private WithEvents checkSelectionPreview As System.Windows.Forms.CheckBox
    Private WithEvents panel2 As System.Windows.Forms.Panel
    Friend WithEvents VectorDrawBaseControl1 As VectorDraw.Professional.Control.VectorDrawBaseControl

End Class
