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
        Me.vdSC = New vdScrollableControl.vdScrollableControl
        Me.chkBox = New System.Windows.Forms.CheckBox
        Me.btLine = New System.Windows.Forms.Button
        Me.chkBox_GripDraw = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'vdSC
        '
        Me.vdSC.Location = New System.Drawing.Point(12, 12)
        Me.vdSC.Name = "vdSC"
        Me.vdSC.Size = New System.Drawing.Size(640, 370)
        Me.vdSC.TabIndex = 0
        '
        'chkBox
        '
        Me.chkBox.AutoSize = True
        Me.chkBox.Checked = True
        Me.chkBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBox.Location = New System.Drawing.Point(330, 398)
        Me.chkBox.Name = "chkBox"
        Me.chkBox.Size = New System.Drawing.Size(158, 17)
        Me.chkBox.TabIndex = 6
        Me.chkBox.Text = "Enable ActionDraw override"
        Me.chkBox.UseVisualStyleBackColor = True
        '
        'btLine
        '
        Me.btLine.Location = New System.Drawing.Point(12, 388)
        Me.btLine.Name = "btLine"
        Me.btLine.Size = New System.Drawing.Size(104, 35)
        Me.btLine.TabIndex = 5
        Me.btLine.Text = "Command Line"
        Me.btLine.UseVisualStyleBackColor = True
        '
        'chkBox_GripDraw
        '
        Me.chkBox_GripDraw.AutoSize = True
        Me.chkBox_GripDraw.Checked = True
        Me.chkBox_GripDraw.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBox_GripDraw.Location = New System.Drawing.Point(502, 398)
        Me.chkBox_GripDraw.Name = "chkBox_GripDraw"
        Me.chkBox_GripDraw.Size = New System.Drawing.Size(150, 17)
        Me.chkBox_GripDraw.TabIndex = 7
        Me.chkBox_GripDraw.Text = "Enable Draw Grip override"
        Me.chkBox_GripDraw.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 435)
        Me.Controls.Add(Me.chkBox_GripDraw)
        Me.Controls.Add(Me.chkBox)
        Me.Controls.Add(Me.btLine)
        Me.Controls.Add(Me.vdSC)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "ActionDraw Event VB Sample"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents vdSC As vdScrollableControl.vdScrollableControl
    Friend WithEvents chkBox As System.Windows.Forms.CheckBox
    Friend WithEvents btLine As System.Windows.Forms.Button
    Friend WithEvents chkBox_GripDraw As System.Windows.Forms.CheckBox

End Class
