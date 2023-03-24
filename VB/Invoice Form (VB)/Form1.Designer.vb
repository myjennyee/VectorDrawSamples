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
        Me.components = New System.ComponentModel.Container
        Me.stbPhone = New System.Windows.Forms.TextBox
        Me.stbFax = New System.Windows.Forms.TextBox
        Me.stbTax = New System.Windows.Forms.TextBox
        Me.label5 = New System.Windows.Forms.Label
        Me.exportToPDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.stbAddress = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.stbName = New System.Windows.Forms.TextBox
        Me.newToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.printToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.menuStrip1 = New System.Windows.Forms.MenuStrip
        Me.rtbEmail = New System.Windows.Forms.TextBox
        Me.rtbContact = New System.Windows.Forms.TextBox
        Me.tbTotal = New System.Windows.Forms.TextBox
        Me.updateButton = New System.Windows.Forms.Button
        Me.groupBox3 = New System.Windows.Forms.GroupBox
        Me.tbDate = New System.Windows.Forms.DateTimePicker
        Me.tbInvoiceNum = New System.Windows.Forms.TextBox
        Me.label19 = New System.Windows.Forms.Label
        Me.label20 = New System.Windows.Forms.Label
        Me.ItemsTable = New System.Windows.Forms.DataGrid
        Me.ItemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.label15 = New System.Windows.Forms.Label
        Me.groupBox4 = New System.Windows.Forms.GroupBox
        Me.dueDate = New System.Windows.Forms.DateTimePicker
        Me.label17 = New System.Windows.Forms.Label
        Me.label16 = New System.Windows.Forms.Label
        Me.label14 = New System.Windows.Forms.Label
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer
        Me.VectorDrawBaseControl1 = New VectorDraw.Professional.Control.VectorDrawBaseControl
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.rtbPhone = New System.Windows.Forms.TextBox
        Me.rtbVat = New System.Windows.Forms.TextBox
        Me.rtbFax = New System.Windows.Forms.TextBox
        Me.label11 = New System.Windows.Forms.Label
        Me.label12 = New System.Windows.Forms.Label
        Me.rtbZip = New System.Windows.Forms.TextBox
        Me.label13 = New System.Windows.Forms.Label
        Me.rtbArea = New System.Windows.Forms.TextBox
        Me.rtbCountry = New System.Windows.Forms.TextBox
        Me.rtbAddress = New System.Windows.Forms.TextBox
        Me.label6 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.label9 = New System.Windows.Forms.Label
        Me.label10 = New System.Windows.Forms.Label
        Me.rtbName = New System.Windows.Forms.TextBox
        Me.groupBox1.SuspendLayout()
        Me.menuStrip1.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        CType(Me.ItemsTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox4.SuspendLayout()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'stbPhone
        '
        Me.stbPhone.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbPhone.Location = New System.Drawing.Point(81, 82)
        Me.stbPhone.Name = "stbPhone"
        Me.stbPhone.Size = New System.Drawing.Size(126, 20)
        Me.stbPhone.TabIndex = 4
        '
        'stbFax
        '
        Me.stbFax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stbFax.Location = New System.Drawing.Point(294, 82)
        Me.stbFax.Name = "stbFax"
        Me.stbFax.Size = New System.Drawing.Size(127, 20)
        Me.stbFax.TabIndex = 5
        '
        'stbTax
        '
        Me.stbTax.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stbTax.Location = New System.Drawing.Point(81, 112)
        Me.stbTax.Name = "stbTax"
        Me.stbTax.Size = New System.Drawing.Size(340, 20)
        Me.stbTax.TabIndex = 6
        '
        'label5
        '
        Me.label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(235, 89)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(30, 13)
        Me.label5.TabIndex = 5
        Me.label5.Text = "FAX:"
        '
        'exportToPDFToolStripMenuItem
        '
        Me.exportToPDFToolStripMenuItem.Name = "exportToPDFToolStripMenuItem"
        Me.exportToPDFToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.exportToPDFToolStripMenuItem.Text = "Export to PDF"
        '
        'stbAddress
        '
        Me.stbAddress.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stbAddress.Location = New System.Drawing.Point(81, 52)
        Me.stbAddress.Name = "stbAddress"
        Me.stbAddress.Size = New System.Drawing.Size(340, 20)
        Me.stbAddress.TabIndex = 3
        '
        'label4
        '
        Me.label4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(7, 115)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(71, 13)
        Me.label4.TabIndex = 4
        Me.label4.Text = "TAX Number:"
        '
        'groupBox1
        '
        Me.groupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox1.Controls.Add(Me.stbPhone)
        Me.groupBox1.Controls.Add(Me.stbFax)
        Me.groupBox1.Controls.Add(Me.stbTax)
        Me.groupBox1.Controls.Add(Me.stbAddress)
        Me.groupBox1.Controls.Add(Me.label5)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Controls.Add(Me.label1)
        Me.groupBox1.Controls.Add(Me.stbName)
        Me.groupBox1.Location = New System.Drawing.Point(2, 70)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(429, 138)
        Me.groupBox1.TabIndex = 1
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Sender Info"
        '
        'label3
        '
        Me.label3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(7, 85)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(41, 13)
        Me.label3.TabIndex = 3
        Me.label3.Text = "Phone:"
        '
        'label2
        '
        Me.label2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(7, 55)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(48, 13)
        Me.label2.TabIndex = 2
        Me.label2.Text = "Address:"
        '
        'label1
        '
        Me.label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(7, 25)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(38, 13)
        Me.label1.TabIndex = 1
        Me.label1.Text = "Name:"
        '
        'stbName
        '
        Me.stbName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stbName.Location = New System.Drawing.Point(81, 22)
        Me.stbName.Name = "stbName"
        Me.stbName.Size = New System.Drawing.Size(340, 20)
        Me.stbName.TabIndex = 2
        '
        'newToolStripMenuItem
        '
        Me.newToolStripMenuItem.Name = "newToolStripMenuItem"
        Me.newToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.newToolStripMenuItem.Text = "New"
        '
        'fileToolStripMenuItem
        '
        Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newToolStripMenuItem, Me.toolStripSeparator1, Me.printToolStripMenuItem, Me.exportToPDFToolStripMenuItem})
        Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
        Me.fileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.fileToolStripMenuItem.Text = "File"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(142, 6)
        '
        'printToolStripMenuItem
        '
        Me.printToolStripMenuItem.Name = "printToolStripMenuItem"
        Me.printToolStripMenuItem.Size = New System.Drawing.Size(145, 22)
        Me.printToolStripMenuItem.Text = "Print"
        '
        'menuStrip1
        '
        Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem})
        Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.menuStrip1.Name = "menuStrip1"
        Me.menuStrip1.Size = New System.Drawing.Size(924, 24)
        Me.menuStrip1.TabIndex = 5
        Me.menuStrip1.Text = "menuStrip1"
        '
        'rtbEmail
        '
        Me.rtbEmail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbEmail.Location = New System.Drawing.Point(81, 209)
        Me.rtbEmail.Name = "rtbEmail"
        Me.rtbEmail.Size = New System.Drawing.Size(339, 20)
        Me.rtbEmail.TabIndex = 16
        '
        'rtbContact
        '
        Me.rtbContact.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbContact.Location = New System.Drawing.Point(81, 178)
        Me.rtbContact.Name = "rtbContact"
        Me.rtbContact.Size = New System.Drawing.Size(340, 20)
        Me.rtbContact.TabIndex = 15
        '
        'tbTotal
        '
        Me.tbTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbTotal.Enabled = False
        Me.tbTotal.Location = New System.Drawing.Point(310, 157)
        Me.tbTotal.Name = "tbTotal"
        Me.tbTotal.Size = New System.Drawing.Size(111, 20)
        Me.tbTotal.TabIndex = 19
        '
        'updateButton
        '
        Me.updateButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.updateButton.Location = New System.Drawing.Point(153, 659)
        Me.updateButton.MaximumSize = New System.Drawing.Size(143, 32)
        Me.updateButton.MinimumSize = New System.Drawing.Size(143, 32)
        Me.updateButton.Name = "updateButton"
        Me.updateButton.Size = New System.Drawing.Size(143, 32)
        Me.updateButton.TabIndex = 20
        Me.updateButton.Text = "Update"
        Me.updateButton.UseVisualStyleBackColor = True
        '
        'groupBox3
        '
        Me.groupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox3.Controls.Add(Me.tbDate)
        Me.groupBox3.Controls.Add(Me.tbInvoiceNum)
        Me.groupBox3.Controls.Add(Me.label19)
        Me.groupBox3.Controls.Add(Me.label20)
        Me.groupBox3.Location = New System.Drawing.Point(2, 12)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(429, 52)
        Me.groupBox3.TabIndex = 0
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Invoice Info"
        '
        'tbDate
        '
        Me.tbDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.tbDate.Location = New System.Drawing.Point(81, 21)
        Me.tbDate.Name = "tbDate"
        Me.tbDate.Size = New System.Drawing.Size(126, 20)
        Me.tbDate.TabIndex = 1
        '
        'tbInvoiceNum
        '
        Me.tbInvoiceNum.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbInvoiceNum.Location = New System.Drawing.Point(294, 21)
        Me.tbInvoiceNum.Name = "tbInvoiceNum"
        Me.tbInvoiceNum.Size = New System.Drawing.Size(127, 20)
        Me.tbInvoiceNum.TabIndex = 1
        Me.tbInvoiceNum.Tag = ""
        '
        'label19
        '
        Me.label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label19.AutoSize = True
        Me.label19.Location = New System.Drawing.Point(235, 24)
        Me.label19.Name = "label19"
        Me.label19.Size = New System.Drawing.Size(52, 13)
        Me.label19.TabIndex = 2
        Me.label19.Text = "Invoice#:"
        '
        'label20
        '
        Me.label20.AutoSize = True
        Me.label20.Location = New System.Drawing.Point(7, 24)
        Me.label20.Name = "label20"
        Me.label20.Size = New System.Drawing.Size(33, 13)
        Me.label20.TabIndex = 1
        Me.label20.Text = "Date:"
        '
        'ItemsTable
        '
        Me.ItemsTable.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ItemsTable.DataMember = ""
        Me.ItemsTable.DataSource = Me.ItemsBindingSource
        Me.ItemsTable.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.ItemsTable.Location = New System.Drawing.Point(5, 19)
        Me.ItemsTable.Name = "ItemsTable"
        Me.ItemsTable.Size = New System.Drawing.Size(419, 132)
        Me.ItemsTable.TabIndex = 17
        Me.ItemsTable.Tag = ""
        '
        'ItemsBindingSource
        '
        Me.ItemsBindingSource.DataSource = GetType(Invoice_Form__VB_.Items)
        '
        'label15
        '
        Me.label15.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label15.AutoSize = True
        Me.label15.Location = New System.Drawing.Point(6, 181)
        Me.label15.Name = "label15"
        Me.label15.Size = New System.Drawing.Size(47, 13)
        Me.label15.TabIndex = 17
        Me.label15.Text = "Contact:"
        '
        'groupBox4
        '
        Me.groupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox4.Controls.Add(Me.ItemsTable)
        Me.groupBox4.Controls.Add(Me.tbTotal)
        Me.groupBox4.Controls.Add(Me.dueDate)
        Me.groupBox4.Controls.Add(Me.label17)
        Me.groupBox4.Controls.Add(Me.label16)
        Me.groupBox4.Location = New System.Drawing.Point(2, 458)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(429, 192)
        Me.groupBox4.TabIndex = 4
        Me.groupBox4.TabStop = False
        Me.groupBox4.Text = "Item Info"
        '
        'dueDate
        '
        Me.dueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dueDate.Location = New System.Drawing.Point(69, 157)
        Me.dueDate.Name = "dueDate"
        Me.dueDate.Size = New System.Drawing.Size(86, 20)
        Me.dueDate.TabIndex = 18
        '
        'label17
        '
        Me.label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label17.AutoSize = True
        Me.label17.Location = New System.Drawing.Point(270, 160)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(34, 13)
        Me.label17.TabIndex = 4
        Me.label17.Text = "Total:"
        '
        'label16
        '
        Me.label16.AutoSize = True
        Me.label16.Location = New System.Drawing.Point(5, 160)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(56, 13)
        Me.label16.TabIndex = 3
        Me.label16.Text = "Due Date:"
        '
        'label14
        '
        Me.label14.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label14.AutoSize = True
        Me.label14.Location = New System.Drawing.Point(6, 212)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(38, 13)
        Me.label14.TabIndex = 18
        Me.label14.Text = "E-mail:"
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.splitContainer1.Name = "splitContainer1"
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.VectorDrawBaseControl1)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.AutoScroll = True
        Me.splitContainer1.Panel2.AutoScrollMinSize = New System.Drawing.Size(344, 0)
        Me.splitContainer1.Panel2.Controls.Add(Me.groupBox4)
        Me.splitContainer1.Panel2.Controls.Add(Me.updateButton)
        Me.splitContainer1.Panel2.Controls.Add(Me.groupBox3)
        Me.splitContainer1.Panel2.Controls.Add(Me.groupBox2)
        Me.splitContainer1.Panel2.Controls.Add(Me.groupBox1)
        Me.splitContainer1.Size = New System.Drawing.Size(924, 703)
        Me.splitContainer1.SplitterDistance = 486
        Me.splitContainer1.TabIndex = 4
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
        Me.VectorDrawBaseControl1.Size = New System.Drawing.Size(486, 703)
        Me.VectorDrawBaseControl1.TabIndex = 0
        '
        'groupBox2
        '
        Me.groupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.groupBox2.Controls.Add(Me.rtbEmail)
        Me.groupBox2.Controls.Add(Me.label14)
        Me.groupBox2.Controls.Add(Me.label15)
        Me.groupBox2.Controls.Add(Me.rtbContact)
        Me.groupBox2.Controls.Add(Me.rtbPhone)
        Me.groupBox2.Controls.Add(Me.rtbVat)
        Me.groupBox2.Controls.Add(Me.rtbFax)
        Me.groupBox2.Controls.Add(Me.label11)
        Me.groupBox2.Controls.Add(Me.label12)
        Me.groupBox2.Controls.Add(Me.rtbZip)
        Me.groupBox2.Controls.Add(Me.label13)
        Me.groupBox2.Controls.Add(Me.rtbArea)
        Me.groupBox2.Controls.Add(Me.rtbCountry)
        Me.groupBox2.Controls.Add(Me.rtbAddress)
        Me.groupBox2.Controls.Add(Me.label6)
        Me.groupBox2.Controls.Add(Me.label7)
        Me.groupBox2.Controls.Add(Me.label8)
        Me.groupBox2.Controls.Add(Me.label9)
        Me.groupBox2.Controls.Add(Me.label10)
        Me.groupBox2.Controls.Add(Me.rtbName)
        Me.groupBox2.Location = New System.Drawing.Point(2, 214)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(429, 237)
        Me.groupBox2.TabIndex = 2
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Recipient Info"
        '
        'rtbPhone
        '
        Me.rtbPhone.Location = New System.Drawing.Point(81, 147)
        Me.rtbPhone.Name = "rtbPhone"
        Me.rtbPhone.Size = New System.Drawing.Size(126, 20)
        Me.rtbPhone.TabIndex = 13
        '
        'rtbVat
        '
        Me.rtbVat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbVat.Location = New System.Drawing.Point(294, 116)
        Me.rtbVat.Name = "rtbVat"
        Me.rtbVat.Size = New System.Drawing.Size(126, 20)
        Me.rtbVat.TabIndex = 12
        '
        'rtbFax
        '
        Me.rtbFax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbFax.Location = New System.Drawing.Point(294, 147)
        Me.rtbFax.Name = "rtbFax"
        Me.rtbFax.Size = New System.Drawing.Size(126, 20)
        Me.rtbFax.TabIndex = 14
        '
        'label11
        '
        Me.label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(235, 116)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(35, 13)
        Me.label11.TabIndex = 13
        Me.label11.Text = "VAT*:"
        '
        'label12
        '
        Me.label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label12.AutoSize = True
        Me.label12.Location = New System.Drawing.Point(235, 147)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(30, 13)
        Me.label12.TabIndex = 13
        Me.label12.Text = "FAX:"
        '
        'rtbZip
        '
        Me.rtbZip.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbZip.Location = New System.Drawing.Point(294, 85)
        Me.rtbZip.Name = "rtbZip"
        Me.rtbZip.Size = New System.Drawing.Size(127, 20)
        Me.rtbZip.TabIndex = 10
        '
        'label13
        '
        Me.label13.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label13.AutoSize = True
        Me.label13.Location = New System.Drawing.Point(6, 150)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(41, 13)
        Me.label13.TabIndex = 12
        Me.label13.Text = "Phone:"
        '
        'rtbArea
        '
        Me.rtbArea.Location = New System.Drawing.Point(81, 85)
        Me.rtbArea.Name = "rtbArea"
        Me.rtbArea.Size = New System.Drawing.Size(126, 20)
        Me.rtbArea.TabIndex = 9
        '
        'rtbCountry
        '
        Me.rtbCountry.Location = New System.Drawing.Point(81, 116)
        Me.rtbCountry.Name = "rtbCountry"
        Me.rtbCountry.Size = New System.Drawing.Size(126, 20)
        Me.rtbCountry.TabIndex = 11
        '
        'rtbAddress
        '
        Me.rtbAddress.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbAddress.Location = New System.Drawing.Point(81, 54)
        Me.rtbAddress.Name = "rtbAddress"
        Me.rtbAddress.Size = New System.Drawing.Size(339, 20)
        Me.rtbAddress.TabIndex = 8
        '
        'label6
        '
        Me.label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(235, 85)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(53, 13)
        Me.label6.TabIndex = 5
        Me.label6.Text = "Zip Code:"
        '
        'label7
        '
        Me.label7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(6, 119)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(46, 13)
        Me.label7.TabIndex = 4
        Me.label7.Text = "Country:"
        '
        'label8
        '
        Me.label8.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(6, 88)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(32, 13)
        Me.label8.TabIndex = 3
        Me.label8.Text = "Area:"
        '
        'label9
        '
        Me.label9.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(6, 57)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(48, 13)
        Me.label9.TabIndex = 2
        Me.label9.Text = "Address:"
        '
        'label10
        '
        Me.label10.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(6, 26)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(38, 13)
        Me.label10.TabIndex = 1
        Me.label10.Text = "Name:"
        '
        'rtbName
        '
        Me.rtbName.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbName.Location = New System.Drawing.Point(81, 23)
        Me.rtbName.Name = "rtbName"
        Me.rtbName.Size = New System.Drawing.Size(340, 20)
        Me.rtbName.TabIndex = 7
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(924, 727)
        Me.Controls.Add(Me.splitContainer1)
        Me.Controls.Add(Me.menuStrip1)
        Me.MinimumSize = New System.Drawing.Size(940, 765)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.menuStrip1.ResumeLayout(False)
        Me.menuStrip1.PerformLayout()
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox3.PerformLayout()
        CType(Me.ItemsTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox4.ResumeLayout(False)
        Me.groupBox4.PerformLayout()
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel2.ResumeLayout(False)
        Me.splitContainer1.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        Me.groupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents stbPhone As System.Windows.Forms.TextBox
    Private WithEvents stbFax As System.Windows.Forms.TextBox
    Private WithEvents stbTax As System.Windows.Forms.TextBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents exportToPDFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents stbAddress As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents stbName As System.Windows.Forms.TextBox
    Private WithEvents newToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents printToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents menuStrip1 As System.Windows.Forms.MenuStrip
    Private WithEvents rtbEmail As System.Windows.Forms.TextBox
    Private WithEvents rtbContact As System.Windows.Forms.TextBox
    Private WithEvents tbTotal As System.Windows.Forms.TextBox
    Private WithEvents updateButton As System.Windows.Forms.Button
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents tbDate As System.Windows.Forms.DateTimePicker
    Private WithEvents tbInvoiceNum As System.Windows.Forms.TextBox
    Private WithEvents label19 As System.Windows.Forms.Label
    Private WithEvents label20 As System.Windows.Forms.Label
    Private WithEvents ItemsTable As System.Windows.Forms.DataGrid
    Friend WithEvents ItemsBindingSource As System.Windows.Forms.BindingSource
    Private WithEvents label15 As System.Windows.Forms.Label
    Private WithEvents groupBox4 As System.Windows.Forms.GroupBox
    Private WithEvents dueDate As System.Windows.Forms.DateTimePicker
    Private WithEvents label17 As System.Windows.Forms.Label
    Private WithEvents label16 As System.Windows.Forms.Label
    Private WithEvents label14 As System.Windows.Forms.Label
    Private WithEvents splitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents VectorDrawBaseControl1 As VectorDraw.Professional.Control.VectorDrawBaseControl
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents rtbPhone As System.Windows.Forms.TextBox
    Private WithEvents rtbVat As System.Windows.Forms.TextBox
    Private WithEvents rtbFax As System.Windows.Forms.TextBox
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents rtbZip As System.Windows.Forms.TextBox
    Private WithEvents label13 As System.Windows.Forms.Label
    Private WithEvents rtbArea As System.Windows.Forms.TextBox
    Private WithEvents rtbCountry As System.Windows.Forms.TextBox
    Private WithEvents rtbAddress As System.Windows.Forms.TextBox
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents rtbName As System.Windows.Forms.TextBox

End Class
