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
        Me.btnClearMemory = New System.Windows.Forms.Button
        Me.btnRemoveXRef = New System.Windows.Forms.Button
        Me.btnDeleteXRef = New System.Windows.Forms.Button
        Me.btnAddXRef = New System.Windows.Forms.Button
        Me.btnUndo = New System.Windows.Forms.Button
        Me.btnRedo = New System.Windows.Forms.Button
        Me.btnRemoveCircle = New System.Windows.Forms.Button
        Me.btnDeleteCircle = New System.Windows.Forms.Button
        Me.btnAddCircle = New System.Windows.Forms.Button
        Me.vdFC = New vdControls.vdFramedControl
        Me.SuspendLayout()
        '
        'btnClearMemory
        '
        Me.btnClearMemory.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnClearMemory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearMemory.Location = New System.Drawing.Point(381, 561)
        Me.btnClearMemory.Name = "btnClearMemory"
        Me.btnClearMemory.Size = New System.Drawing.Size(157, 25)
        Me.btnClearMemory.TabIndex = 19
        Me.btnClearMemory.Text = "Clear Memory"
        Me.btnClearMemory.UseVisualStyleBackColor = True
        '
        'btnRemoveXRef
        '
        Me.btnRemoveXRef.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveXRef.Location = New System.Drawing.Point(790, 525)
        Me.btnRemoveXRef.Name = "btnRemoveXRef"
        Me.btnRemoveXRef.Size = New System.Drawing.Size(117, 25)
        Me.btnRemoveXRef.TabIndex = 18
        Me.btnRemoveXRef.Text = "Remove XRef"
        Me.btnRemoveXRef.UseVisualStyleBackColor = True
        '
        'btnDeleteXRef
        '
        Me.btnDeleteXRef.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteXRef.Location = New System.Drawing.Point(667, 525)
        Me.btnDeleteXRef.Name = "btnDeleteXRef"
        Me.btnDeleteXRef.Size = New System.Drawing.Size(117, 25)
        Me.btnDeleteXRef.TabIndex = 17
        Me.btnDeleteXRef.Text = "Delete XRef"
        Me.btnDeleteXRef.UseVisualStyleBackColor = True
        '
        'btnAddXRef
        '
        Me.btnAddXRef.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddXRef.Location = New System.Drawing.Point(544, 525)
        Me.btnAddXRef.Name = "btnAddXRef"
        Me.btnAddXRef.Size = New System.Drawing.Size(117, 25)
        Me.btnAddXRef.TabIndex = 16
        Me.btnAddXRef.Text = "Add XRef"
        Me.btnAddXRef.UseVisualStyleBackColor = True
        '
        'btnUndo
        '
        Me.btnUndo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnUndo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUndo.Location = New System.Drawing.Point(258, 561)
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(117, 25)
        Me.btnUndo.TabIndex = 15
        Me.btnUndo.Text = "< Undo"
        Me.btnUndo.UseVisualStyleBackColor = True
        '
        'btnRedo
        '
        Me.btnRedo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnRedo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRedo.Location = New System.Drawing.Point(544, 561)
        Me.btnRedo.Name = "btnRedo"
        Me.btnRedo.Size = New System.Drawing.Size(117, 25)
        Me.btnRedo.TabIndex = 14
        Me.btnRedo.Text = "Redo >"
        Me.btnRedo.UseVisualStyleBackColor = True
        '
        'btnRemoveCircle
        '
        Me.btnRemoveCircle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveCircle.Location = New System.Drawing.Point(258, 525)
        Me.btnRemoveCircle.Name = "btnRemoveCircle"
        Me.btnRemoveCircle.Size = New System.Drawing.Size(117, 25)
        Me.btnRemoveCircle.TabIndex = 13
        Me.btnRemoveCircle.Text = "Remove Circle"
        Me.btnRemoveCircle.UseVisualStyleBackColor = True
        '
        'btnDeleteCircle
        '
        Me.btnDeleteCircle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDeleteCircle.Location = New System.Drawing.Point(135, 525)
        Me.btnDeleteCircle.Name = "btnDeleteCircle"
        Me.btnDeleteCircle.Size = New System.Drawing.Size(117, 25)
        Me.btnDeleteCircle.TabIndex = 12
        Me.btnDeleteCircle.Text = "Delete Circle"
        Me.btnDeleteCircle.UseVisualStyleBackColor = True
        '
        'btnAddCircle
        '
        Me.btnAddCircle.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddCircle.Location = New System.Drawing.Point(12, 525)
        Me.btnAddCircle.Name = "btnAddCircle"
        Me.btnAddCircle.Size = New System.Drawing.Size(117, 25)
        Me.btnAddCircle.TabIndex = 11
        Me.btnAddCircle.Text = "Add Circle"
        Me.btnAddCircle.UseVisualStyleBackColor = True
        '
        'vdFC
        '
        Me.vdFC.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane
        Me.vdFC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vdFC.DisplayPolarCoord = False
        Me.vdFC.HistoryLines = CType(3UI, UInteger)
        Me.vdFC.Location = New System.Drawing.Point(2, 6)
        Me.vdFC.Name = "vdFC"
        Me.vdFC.PropertyGridWidth = CType(300UI, UInteger)
        Me.vdFC.Size = New System.Drawing.Size(916, 513)
        Me.vdFC.TabIndex = 10
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 593)
        Me.Controls.Add(Me.btnClearMemory)
        Me.Controls.Add(Me.btnRemoveXRef)
        Me.Controls.Add(Me.btnDeleteXRef)
        Me.Controls.Add(Me.btnAddXRef)
        Me.Controls.Add(Me.btnUndo)
        Me.Controls.Add(Me.btnRedo)
        Me.Controls.Add(Me.btnRemoveCircle)
        Me.Controls.Add(Me.btnDeleteCircle)
        Me.Controls.Add(Me.btnAddCircle)
        Me.Controls.Add(Me.vdFC)
        Me.Name = "Form1"
        Me.Text = "Delete & Remove objects VB"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnClearMemory As System.Windows.Forms.Button
    Private WithEvents btnRemoveXRef As System.Windows.Forms.Button
    Private WithEvents btnDeleteXRef As System.Windows.Forms.Button
    Private WithEvents btnAddXRef As System.Windows.Forms.Button
    Private WithEvents btnUndo As System.Windows.Forms.Button
    Private WithEvents btnRedo As System.Windows.Forms.Button
    Private WithEvents btnRemoveCircle As System.Windows.Forms.Button
    Private WithEvents btnDeleteCircle As System.Windows.Forms.Button
    Private WithEvents btnAddCircle As System.Windows.Forms.Button
    Private WithEvents vdFC As vdControls.vdFramedControl

End Class
