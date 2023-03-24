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
        Me.vd = New vdControls.vdFramedControl
        Me.ButGetPoint = New System.Windows.Forms.Button
        Me.ButUserRect = New System.Windows.Forms.Button
        Me.butAcceptedValues = New System.Windows.Forms.Button
        Me.butGetSelection = New System.Windows.Forms.Button
        Me.butGetAngle = New System.Windows.Forms.Button
        Me.butGetDistance = New System.Windows.Forms.Button
        Me.butGetFigure = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'vd
        '
        Me.vd.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane
        Me.vd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vd.DisplayPolarCoord = False
        Me.vd.Location = New System.Drawing.Point(12, 12)
        Me.vd.Name = "vd"
        Me.vd.Size = New System.Drawing.Size(810, 507)
        Me.vd.TabIndex = 0
        '
        'ButGetPoint
        '
        Me.ButGetPoint.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButGetPoint.Location = New System.Drawing.Point(832, 12)
        Me.ButGetPoint.Name = "ButGetPoint"
        Me.ButGetPoint.Size = New System.Drawing.Size(108, 25)
        Me.ButGetPoint.TabIndex = 1
        Me.ButGetPoint.Text = "Get Point"
        Me.ButGetPoint.UseVisualStyleBackColor = True
        '
        'ButUserRect
        '
        Me.ButUserRect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButUserRect.Location = New System.Drawing.Point(832, 43)
        Me.ButUserRect.Name = "ButUserRect"
        Me.ButUserRect.Size = New System.Drawing.Size(108, 25)
        Me.ButUserRect.TabIndex = 2
        Me.ButUserRect.Text = "Get Rect"
        Me.ButUserRect.UseVisualStyleBackColor = True
        '
        'butAcceptedValues
        '
        Me.butAcceptedValues.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butAcceptedValues.Location = New System.Drawing.Point(832, 201)
        Me.butAcceptedValues.Name = "butAcceptedValues"
        Me.butAcceptedValues.Size = New System.Drawing.Size(108, 36)
        Me.butAcceptedValues.TabIndex = 12
        Me.butAcceptedValues.Text = "User Accepted Values"
        Me.butAcceptedValues.UseVisualStyleBackColor = True
        '
        'butGetSelection
        '
        Me.butGetSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butGetSelection.Location = New System.Drawing.Point(832, 170)
        Me.butGetSelection.Name = "butGetSelection"
        Me.butGetSelection.Size = New System.Drawing.Size(108, 25)
        Me.butGetSelection.TabIndex = 11
        Me.butGetSelection.Text = "Get Selection"
        Me.butGetSelection.UseVisualStyleBackColor = True
        '
        'butGetAngle
        '
        Me.butGetAngle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butGetAngle.Location = New System.Drawing.Point(832, 138)
        Me.butGetAngle.Name = "butGetAngle"
        Me.butGetAngle.Size = New System.Drawing.Size(108, 25)
        Me.butGetAngle.TabIndex = 10
        Me.butGetAngle.Text = "Get Angle"
        Me.butGetAngle.UseVisualStyleBackColor = True
        '
        'butGetDistance
        '
        Me.butGetDistance.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butGetDistance.Location = New System.Drawing.Point(832, 106)
        Me.butGetDistance.Name = "butGetDistance"
        Me.butGetDistance.Size = New System.Drawing.Size(108, 25)
        Me.butGetDistance.TabIndex = 9
        Me.butGetDistance.Text = "Get Distance"
        Me.butGetDistance.UseVisualStyleBackColor = True
        '
        'butGetFigure
        '
        Me.butGetFigure.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butGetFigure.Location = New System.Drawing.Point(832, 74)
        Me.butGetFigure.Name = "butGetFigure"
        Me.butGetFigure.Size = New System.Drawing.Size(108, 25)
        Me.butGetFigure.TabIndex = 8
        Me.butGetFigure.Text = "Get Figure"
        Me.butGetFigure.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 531)
        Me.Controls.Add(Me.butAcceptedValues)
        Me.Controls.Add(Me.butGetSelection)
        Me.Controls.Add(Me.butGetAngle)
        Me.Controls.Add(Me.butGetDistance)
        Me.Controls.Add(Me.butGetFigure)
        Me.Controls.Add(Me.ButUserRect)
        Me.Controls.Add(Me.ButGetPoint)
        Me.Controls.Add(Me.vd)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents vd As vdControls.vdFramedControl
    Friend WithEvents ButGetPoint As System.Windows.Forms.Button
    Friend WithEvents ButUserRect As System.Windows.Forms.Button
    Private WithEvents butAcceptedValues As System.Windows.Forms.Button
    Private WithEvents butGetSelection As System.Windows.Forms.Button
    Private WithEvents butGetAngle As System.Windows.Forms.Button
    Private WithEvents butGetDistance As System.Windows.Forms.Button
    Private WithEvents butGetFigure As System.Windows.Forms.Button

End Class
