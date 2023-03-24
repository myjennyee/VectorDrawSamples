namespace Invoice_Form
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.vectorDrawBaseControl1 = new VectorDraw.Professional.Control.VectorDrawBaseControl();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ItemsTable = new System.Windows.Forms.DataGrid();
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.dueDate = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbDate = new System.Windows.Forms.DateTimePicker();
            this.tbInvoiceNum = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtbEmail = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.rtbContact = new System.Windows.Forms.TextBox();
            this.rtbPhone = new System.Windows.Forms.TextBox();
            this.rtbVat = new System.Windows.Forms.TextBox();
            this.rtbFax = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.rtbZip = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.rtbArea = new System.Windows.Forms.TextBox();
            this.rtbCountry = new System.Windows.Forms.TextBox();
            this.rtbAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.rtbName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.stbPhone = new System.Windows.Forms.TextBox();
            this.stbFax = new System.Windows.Forms.TextBox();
            this.stbTax = new System.Windows.Forms.TextBox();
            this.stbAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.stbName = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.vectorDrawBaseControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.AutoScrollMinSize = new System.Drawing.Size(344, 0);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel2.Controls.Add(this.update);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(924, 703);
            this.splitContainer1.SplitterDistance = 486;
            this.splitContainer1.TabIndex = 0;
            // 
            // vectorDrawBaseControl1
            // 
            this.vectorDrawBaseControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.vectorDrawBaseControl1.AllowDrop = true;
            this.vectorDrawBaseControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.vectorDrawBaseControl1.DisableVdrawDxf = false;
            this.vectorDrawBaseControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vectorDrawBaseControl1.EnableAutoGripOn = true;
            this.vectorDrawBaseControl1.Location = new System.Drawing.Point(0, 0);
            this.vectorDrawBaseControl1.Name = "vectorDrawBaseControl1";
            this.vectorDrawBaseControl1.Size = new System.Drawing.Size(486, 703);
            this.vectorDrawBaseControl1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.ItemsTable);
            this.groupBox4.Controls.Add(this.tbTotal);
            this.groupBox4.Controls.Add(this.dueDate);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Location = new System.Drawing.Point(2, 458);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(429, 192);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Item Info";
            // 
            // ItemsTable
            // 
            this.ItemsTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemsTable.DataMember = "";
            this.ItemsTable.DataSource = this.itemsBindingSource;
            this.ItemsTable.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.ItemsTable.Location = new System.Drawing.Point(5, 19);
            this.ItemsTable.Name = "ItemsTable";
            this.ItemsTable.Size = new System.Drawing.Size(419, 132);
            this.ItemsTable.TabIndex = 17;
            this.ItemsTable.Tag = "";
            this.ItemsTable.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ItemsTable_MouseUp);
            this.ItemsTable.CurrentCellChanged += new System.EventHandler(this.ItemsTable_CurrentCellChanged);
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.AllowNew = true;
            this.itemsBindingSource.DataSource = typeof(Invoice_Form.Items);
            // 
            // tbTotal
            // 
            this.tbTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTotal.Enabled = false;
            this.tbTotal.Location = new System.Drawing.Point(310, 157);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.Size = new System.Drawing.Size(111, 20);
            this.tbTotal.TabIndex = 19;
            // 
            // dueDate
            // 
            this.dueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dueDate.Location = new System.Drawing.Point(69, 157);
            this.dueDate.Name = "dueDate";
            this.dueDate.Size = new System.Drawing.Size(86, 20);
            this.dueDate.TabIndex = 18;
            this.dueDate.ValueChanged += new System.EventHandler(this.DateValueChanged);
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(270, 160);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(34, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "Total:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(5, 160);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 13);
            this.label16.TabIndex = 3;
            this.label16.Text = "Due Date:";
            // 
            // update
            // 
            this.update.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.update.Location = new System.Drawing.Point(153, 659);
            this.update.MaximumSize = new System.Drawing.Size(143, 32);
            this.update.MinimumSize = new System.Drawing.Size(143, 32);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(143, 32);
            this.update.TabIndex = 20;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.updateClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tbDate);
            this.groupBox3.Controls.Add(this.tbInvoiceNum);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Location = new System.Drawing.Point(2, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(429, 52);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Invoice Info";
            // 
            // tbDate
            // 
            this.tbDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.tbDate.Location = new System.Drawing.Point(81, 21);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(126, 20);
            this.tbDate.TabIndex = 1;
            this.tbDate.ValueChanged += new System.EventHandler(this.DateValueChanged);
            // 
            // tbInvoiceNum
            // 
            this.tbInvoiceNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInvoiceNum.Location = new System.Drawing.Point(294, 21);
            this.tbInvoiceNum.Name = "tbInvoiceNum";
            this.tbInvoiceNum.Size = new System.Drawing.Size(127, 20);
            this.tbInvoiceNum.TabIndex = 1;
            this.tbInvoiceNum.Tag = "";
            this.tbInvoiceNum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(235, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 13);
            this.label19.TabIndex = 2;
            this.label19.Text = "Invoice#:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 24);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(33, 13);
            this.label20.TabIndex = 1;
            this.label20.Text = "Date:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rtbEmail);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.rtbContact);
            this.groupBox2.Controls.Add(this.rtbPhone);
            this.groupBox2.Controls.Add(this.rtbVat);
            this.groupBox2.Controls.Add(this.rtbFax);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.rtbZip);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.rtbArea);
            this.groupBox2.Controls.Add(this.rtbCountry);
            this.groupBox2.Controls.Add(this.rtbAddress);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.rtbName);
            this.groupBox2.Location = new System.Drawing.Point(2, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(429, 237);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Recipient Info";
            // 
            // rtbEmail
            // 
            this.rtbEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbEmail.Location = new System.Drawing.Point(81, 209);
            this.rtbEmail.Name = "rtbEmail";
            this.rtbEmail.Size = new System.Drawing.Size(339, 20);
            this.rtbEmail.TabIndex = 16;
            this.rtbEmail.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 212);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 18;
            this.label14.Text = "E-mail:";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 181);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 13);
            this.label15.TabIndex = 17;
            this.label15.Text = "Contact:";
            // 
            // rtbContact
            // 
            this.rtbContact.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbContact.Location = new System.Drawing.Point(81, 178);
            this.rtbContact.Name = "rtbContact";
            this.rtbContact.Size = new System.Drawing.Size(340, 20);
            this.rtbContact.TabIndex = 15;
            this.rtbContact.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // rtbPhone
            // 
            this.rtbPhone.Location = new System.Drawing.Point(81, 147);
            this.rtbPhone.Name = "rtbPhone";
            this.rtbPhone.Size = new System.Drawing.Size(126, 20);
            this.rtbPhone.TabIndex = 13;
            this.rtbPhone.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // rtbVat
            // 
            this.rtbVat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbVat.Location = new System.Drawing.Point(294, 116);
            this.rtbVat.Name = "rtbVat";
            this.rtbVat.Size = new System.Drawing.Size(126, 20);
            this.rtbVat.TabIndex = 12;
            this.rtbVat.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // rtbFax
            // 
            this.rtbFax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbFax.Location = new System.Drawing.Point(294, 147);
            this.rtbFax.Name = "rtbFax";
            this.rtbFax.Size = new System.Drawing.Size(126, 20);
            this.rtbFax.TabIndex = 14;
            this.rtbFax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(235, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "VAT*:";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(235, 147);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "FAX:";
            // 
            // rtbZip
            // 
            this.rtbZip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbZip.Location = new System.Drawing.Point(294, 85);
            this.rtbZip.Name = "rtbZip";
            this.rtbZip.Size = new System.Drawing.Size(127, 20);
            this.rtbZip.TabIndex = 10;
            this.rtbZip.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 150);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Phone:";
            // 
            // rtbArea
            // 
            this.rtbArea.Location = new System.Drawing.Point(81, 85);
            this.rtbArea.Name = "rtbArea";
            this.rtbArea.Size = new System.Drawing.Size(126, 20);
            this.rtbArea.TabIndex = 9;
            this.rtbArea.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // rtbCountry
            // 
            this.rtbCountry.Location = new System.Drawing.Point(81, 116);
            this.rtbCountry.Name = "rtbCountry";
            this.rtbCountry.Size = new System.Drawing.Size(126, 20);
            this.rtbCountry.TabIndex = 11;
            this.rtbCountry.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // rtbAddress
            // 
            this.rtbAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbAddress.Location = new System.Drawing.Point(81, 54);
            this.rtbAddress.Name = "rtbAddress";
            this.rtbAddress.Size = new System.Drawing.Size(339, 20);
            this.rtbAddress.TabIndex = 8;
            this.rtbAddress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(235, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Zip Code:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Country:";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Area:";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Address:";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Name:";
            // 
            // rtbName
            // 
            this.rtbName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbName.Location = new System.Drawing.Point(81, 23);
            this.rtbName.Name = "rtbName";
            this.rtbName.Size = new System.Drawing.Size(340, 20);
            this.rtbName.TabIndex = 7;
            this.rtbName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.stbPhone);
            this.groupBox1.Controls.Add(this.stbFax);
            this.groupBox1.Controls.Add(this.stbTax);
            this.groupBox1.Controls.Add(this.stbAddress);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.stbName);
            this.groupBox1.Location = new System.Drawing.Point(2, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 138);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sender Info";
            // 
            // stbPhone
            // 
            this.stbPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.stbPhone.Location = new System.Drawing.Point(81, 82);
            this.stbPhone.Name = "stbPhone";
            this.stbPhone.Size = new System.Drawing.Size(126, 20);
            this.stbPhone.TabIndex = 4;
            this.stbPhone.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // stbFax
            // 
            this.stbFax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.stbFax.Location = new System.Drawing.Point(294, 82);
            this.stbFax.Name = "stbFax";
            this.stbFax.Size = new System.Drawing.Size(127, 20);
            this.stbFax.TabIndex = 5;
            this.stbFax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // stbTax
            // 
            this.stbTax.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stbTax.Location = new System.Drawing.Point(81, 112);
            this.stbTax.Name = "stbTax";
            this.stbTax.Size = new System.Drawing.Size(340, 20);
            this.stbTax.TabIndex = 6;
            this.stbTax.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // stbAddress
            // 
            this.stbAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stbAddress.Location = new System.Drawing.Point(81, 52);
            this.stbAddress.Name = "stbAddress";
            this.stbAddress.Size = new System.Drawing.Size(340, 20);
            this.stbAddress.TabIndex = 3;
            this.stbAddress.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(235, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "FAX:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "TAX Number:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Phone:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            // 
            // stbName
            // 
            this.stbName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.stbName.Location = new System.Drawing.Point(81, 22);
            this.stbName.Name = "stbName";
            this.stbName.Size = new System.Drawing.Size(340, 20);
            this.stbName.TabIndex = 2;
            this.stbName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyPressed);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(924, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.exportToPDFToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exportToPDFToolStripMenuItem
            // 
            this.exportToPDFToolStripMenuItem.Name = "exportToPDFToolStripMenuItem";
            this.exportToPDFToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToPDFToolStripMenuItem.Text = "Export to PDF";
            this.exportToPDFToolStripMenuItem.Click += new System.EventHandler(this.exportToPDFToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 727);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(940, 765);
            this.Name = "Form1";
            this.Text = "Invoice Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }





        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private VectorDraw.Professional.Control.VectorDrawBaseControl vectorDrawBaseControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox stbTax;
        private System.Windows.Forms.TextBox stbAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox stbName;
        private System.Windows.Forms.TextBox stbPhone;
        private System.Windows.Forms.TextBox stbFax;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox rtbArea;
        private System.Windows.Forms.TextBox rtbCountry;
        private System.Windows.Forms.TextBox rtbAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox rtbName;
        private System.Windows.Forms.TextBox rtbPhone;
        private System.Windows.Forms.TextBox rtbVat;
        private System.Windows.Forms.TextBox rtbFax;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox rtbZip;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox rtbEmail;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox rtbContact;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbInvoiceNum;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.DateTimePicker tbDate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker dueDate;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGrid ItemsTable = new System.Windows.Forms.DataGrid();
        protected System.Windows.Forms.BindingSource itemsBindingSource;
    }
}

