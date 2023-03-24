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
        Me.ButMagnifier = New System.Windows.Forms.Button
        Me.label1 = New System.Windows.Forms.Label
        Me.Ruler_Properties = New System.Windows.Forms.GroupBox
        Me.rulerProps = New System.Windows.Forms.PropertyGrid
        Me.btRuler = New System.Windows.Forms.Button
        Me.Ruler_Properties.SuspendLayout()
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
        Me.VdFramedControl1.Location = New System.Drawing.Point(3, 11)
        Me.VdFramedControl1.Name = "VdFramedControl1"
        Me.VdFramedControl1.PropertyGridWidth = CType(300UI, UInteger)
        Me.VdFramedControl1.Size = New System.Drawing.Size(885, 432)
        Me.VdFramedControl1.TabIndex = 0
        '
        'ButMagnifier
        '
        Me.ButMagnifier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButMagnifier.Location = New System.Drawing.Point(894, 12)
        Me.ButMagnifier.Name = "ButMagnifier"
        Me.ButMagnifier.Size = New System.Drawing.Size(88, 28)
        Me.ButMagnifier.TabIndex = 2
        Me.ButMagnifier.Text = "Magnifier Glass"
        Me.ButMagnifier.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(394, 453)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(775, 13)
        Me.label1.TabIndex = 4
        Me.label1.Text = "Magnifier Glass can be used to quick select a point in a drawing without zooming " & _
            "or use oSnap points. Check the Shift Key which enables and disables this feature" & _
            "."
        '
        'Ruler_Properties
        '
        Me.Ruler_Properties.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Ruler_Properties.Controls.Add(Me.rulerProps)
        Me.Ruler_Properties.Location = New System.Drawing.Point(894, 60)
        Me.Ruler_Properties.Name = "Ruler_Properties"
        Me.Ruler_Properties.Size = New System.Drawing.Size(275, 383)
        Me.Ruler_Properties.TabIndex = 9
        Me.Ruler_Properties.TabStop = False
        Me.Ruler_Properties.Text = "Ruler Properties"
        '
        'rulerProps
        '
        Me.rulerProps.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rulerProps.Location = New System.Drawing.Point(3, 16)
        Me.rulerProps.Name = "rulerProps"
        Me.rulerProps.Size = New System.Drawing.Size(269, 364)
        Me.rulerProps.TabIndex = 6
        '
        'btRuler
        '
        Me.btRuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btRuler.Location = New System.Drawing.Point(1002, 12)
        Me.btRuler.Name = "btRuler"
        Me.btRuler.Size = New System.Drawing.Size(113, 27)
        Me.btRuler.TabIndex = 10
        Me.btRuler.Text = "Ruler On/Off"
        Me.btRuler.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1194, 475)
        Me.Controls.Add(Me.btRuler)
        Me.Controls.Add(Me.Ruler_Properties)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.ButMagnifier)
        Me.Controls.Add(Me.VdFramedControl1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Ruler_Properties.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents VdFramedControl1 As vdControls.vdFramedControl
    Friend WithEvents ButMagnifier As System.Windows.Forms.Button
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents Ruler_Properties As System.Windows.Forms.GroupBox
    Private WithEvents rulerProps As System.Windows.Forms.PropertyGrid
    Private WithEvents btRuler As System.Windows.Forms.Button

End Class
