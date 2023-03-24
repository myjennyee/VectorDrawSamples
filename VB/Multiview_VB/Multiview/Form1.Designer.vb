<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.butDialog = New System.Windows.Forms.Button
        Me.butOpen = New System.Windows.Forms.Button
        Me.VdFramedControl1 = New vdControls.vdFramedControl
        Me.SuspendLayout()
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(216, 62)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(291, 13)
        Me.label5.TabIndex = 14
        Me.label5.Text = "With Ctrl(left) + Tab you can navigate through the viewports."
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(216, 49)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(484, 13)
        Me.label4.TabIndex = 13
        Me.label4.Text = "Doubleclick on any viewport to maximise it , doubleclicking again will return to " & _
            "the multi viewport view."
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(216, 36)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(802, 13)
        Me.label3.TabIndex = 12
        Me.label3.Text = "You can activate a viewport by simply clicking on it. In some modes you can resiz" & _
            "e the scene by clicking on the separator. All viewports recieve commands when ac" & _
            "tive. "
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(216, 23)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(390, 13)
        Me.label2.TabIndex = 11
        Me.label2.Text = "The Multiview Dialog can help you either modify the current or create a new one. " & _
            ""
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(216, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(951, 13)
        Me.label1.TabIndex = 10
        Me.label1.Text = "Press the open button to open a default drawing. After opening the drawing a mult" & _
            "iview layout is created and added to the Document. Note that the Model is being " & _
            "hidden from the bottom layout toolbar."
        '
        'butDialog
        '
        Me.butDialog.Location = New System.Drawing.Point(112, 29)
        Me.butDialog.Name = "butDialog"
        Me.butDialog.Size = New System.Drawing.Size(98, 23)
        Me.butDialog.TabIndex = 9
        Me.butDialog.Text = "MultiView Dialog"
        Me.butDialog.UseVisualStyleBackColor = True
        '
        'butOpen
        '
        Me.butOpen.Location = New System.Drawing.Point(8, 29)
        Me.butOpen.Name = "butOpen"
        Me.butOpen.Size = New System.Drawing.Size(98, 23)
        Me.butOpen.TabIndex = 8
        Me.butOpen.Text = "Open"
        Me.butOpen.UseVisualStyleBackColor = True
        '
        'VdFramedControl1
        '
        Me.VdFramedControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane
        Me.VdFramedControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VdFramedControl1.DisplayPolarCoord = False
        Me.VdFramedControl1.HistoryLines = CType(3UI, UInteger)
        Me.VdFramedControl1.Location = New System.Drawing.Point(8, 78)
        Me.VdFramedControl1.Name = "VdFramedControl1"
        Me.VdFramedControl1.PropertyGridWidth = CType(300UI, UInteger)
        Me.VdFramedControl1.Size = New System.Drawing.Size(1184, 472)
        Me.VdFramedControl1.TabIndex = 15
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1194, 552)
        Me.Controls.Add(Me.VdFramedControl1)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.butDialog)
        Me.Controls.Add(Me.butOpen)
        Me.Name = "MainForm"
        Me.Text = "MultiView Sample"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents butDialog As System.Windows.Forms.Button
    Private WithEvents butOpen As System.Windows.Forms.Button
    Friend WithEvents VdFramedControl1 As vdControls.vdFramedControl

End Class
