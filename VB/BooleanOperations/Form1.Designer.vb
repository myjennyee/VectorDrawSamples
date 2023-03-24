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
        Me.panel1 = New System.Windows.Forms.Panel
        Me.buttonCancel = New System.Windows.Forms.Button
        Me.buttonRevSubstraction = New System.Windows.Forms.Button
        Me.buttonIntersection = New System.Windows.Forms.Button
        Me.panel2 = New System.Windows.Forms.Panel
        Me.vdraw = New VectorDraw.Professional.Control.VectorDrawBaseControl
        Me.buttonSubstract = New System.Windows.Forms.Button
        Me.buttonUnion = New System.Windows.Forms.Button
        Me.panel1.SuspendLayout()
        Me.panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.buttonCancel)
        Me.panel1.Controls.Add(Me.buttonRevSubstraction)
        Me.panel1.Controls.Add(Me.buttonIntersection)
        Me.panel1.Controls.Add(Me.buttonSubstract)
        Me.panel1.Controls.Add(Me.buttonUnion)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 0)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(993, 56)
        Me.panel1.TabIndex = 2
        '
        'buttonCancel
        '
        Me.buttonCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.buttonCancel.Image = Global.BooleanOperations.My.Resources.Resources.delete
        Me.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonCancel.Location = New System.Drawing.Point(615, 8)
        Me.buttonCancel.Name = "buttonCancel"
        Me.buttonCancel.Size = New System.Drawing.Size(78, 40)
        Me.buttonCancel.TabIndex = 4
        Me.buttonCancel.Text = "Reset"
        Me.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonCancel.UseVisualStyleBackColor = True
        '
        'buttonRevSubstraction
        '
        Me.buttonRevSubstraction.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.buttonRevSubstraction.Enabled = False
        Me.buttonRevSubstraction.Image = Global.BooleanOperations.My.Resources.Resources.RevSubctraction
        Me.buttonRevSubstraction.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.buttonRevSubstraction.Location = New System.Drawing.Point(437, 4)
        Me.buttonRevSubstraction.Name = "buttonRevSubstraction"
        Me.buttonRevSubstraction.Size = New System.Drawing.Size(95, 47)
        Me.buttonRevSubstraction.TabIndex = 3
        Me.buttonRevSubstraction.Text = "Rev-substraction"
        Me.buttonRevSubstraction.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.buttonRevSubstraction.UseVisualStyleBackColor = True
        '
        'buttonIntersection
        '
        Me.buttonIntersection.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.buttonIntersection.Enabled = False
        Me.buttonIntersection.Image = Global.BooleanOperations.My.Resources.Resources.Intersection
        Me.buttonIntersection.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.buttonIntersection.Location = New System.Drawing.Point(538, 5)
        Me.buttonIntersection.Name = "buttonIntersection"
        Me.buttonIntersection.Size = New System.Drawing.Size(71, 47)
        Me.buttonIntersection.TabIndex = 2
        Me.buttonIntersection.Text = "Intersection"
        Me.buttonIntersection.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.buttonIntersection.UseVisualStyleBackColor = True
        '
        'panel2
        '
        Me.panel2.Controls.Add(Me.vdraw)
        Me.panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panel2.Location = New System.Drawing.Point(0, 0)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(993, 622)
        Me.panel2.TabIndex = 3
        '
        'vdraw
        '
        Me.vdraw.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.vdraw.AllowDrop = True
        Me.vdraw.Cursor = System.Windows.Forms.Cursors.Default
        Me.vdraw.DisableVdrawDxf = False
        Me.vdraw.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vdraw.EnableAutoGripOn = True
        Me.vdraw.Location = New System.Drawing.Point(0, 0)
        Me.vdraw.Name = "vdraw"
        Me.vdraw.Size = New System.Drawing.Size(993, 622)
        Me.vdraw.TabIndex = 0
        '
        'buttonSubstract
        '
        Me.buttonSubstract.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.buttonSubstract.Enabled = False
        Me.buttonSubstract.Image = Global.BooleanOperations.My.Resources.Resources.Subctraction
        Me.buttonSubstract.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.buttonSubstract.Location = New System.Drawing.Point(355, 4)
        Me.buttonSubstract.Name = "buttonSubstract"
        Me.buttonSubstract.Size = New System.Drawing.Size(76, 47)
        Me.buttonSubstract.TabIndex = 1
        Me.buttonSubstract.Text = "Substraction"
        Me.buttonSubstract.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.buttonSubstract.UseVisualStyleBackColor = True
        '
        'buttonUnion
        '
        Me.buttonUnion.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.buttonUnion.Enabled = False
        Me.buttonUnion.Image = Global.BooleanOperations.My.Resources.Resources.Union
        Me.buttonUnion.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.buttonUnion.Location = New System.Drawing.Point(299, 4)
        Me.buttonUnion.Name = "buttonUnion"
        Me.buttonUnion.Size = New System.Drawing.Size(50, 47)
        Me.buttonUnion.TabIndex = 0
        Me.buttonUnion.Text = "Union"
        Me.buttonUnion.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.buttonUnion.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(993, 622)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.panel2)
        Me.Name = "Form1"
        Me.Text = "Boolean Operations"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.panel1.ResumeLayout(False)
        Me.panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents buttonCancel As System.Windows.Forms.Button
    Private WithEvents buttonRevSubstraction As System.Windows.Forms.Button
    Private WithEvents buttonIntersection As System.Windows.Forms.Button
    Private WithEvents buttonSubstract As System.Windows.Forms.Button
    Private WithEvents buttonUnion As System.Windows.Forms.Button
    Private WithEvents panel2 As System.Windows.Forms.Panel
    Friend WithEvents vdraw As VectorDraw.Professional.Control.VectorDrawBaseControl

End Class
