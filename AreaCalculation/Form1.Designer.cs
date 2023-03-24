namespace AreaCalculation
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
            this.vdFramedControl1 = new vdControls.vdFramedControl();
            this.Calculate = new System.Windows.Forms.Button();
            this.combodegrees = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textPrecision = new System.Windows.Forms.NumericUpDown();
            this.checkProjection = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.vdFramedControl2 = new vdControls.vdFramedControl();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textPrecision)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // vdFramedControl1
            // 
            this.vdFramedControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.vdFramedControl1.DisplayPolarCoord = false;
            this.vdFramedControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vdFramedControl1.HistoryLines = ((uint)(3u));
            this.vdFramedControl1.Location = new System.Drawing.Point(3, 3);
            this.vdFramedControl1.Name = "vdFramedControl1";
            this.vdFramedControl1.PropertyGridWidth = ((uint)(300u));
            this.vdFramedControl1.Size = new System.Drawing.Size(751, 398);
            this.vdFramedControl1.TabIndex = 0;
            // 
            // Calculate
            // 
            this.Calculate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Calculate.Location = new System.Drawing.Point(18, 12);
            this.Calculate.Name = "Calculate";
            this.Calculate.Size = new System.Drawing.Size(86, 25);
            this.Calculate.TabIndex = 1;
            this.Calculate.Text = "Calculate";
            this.Calculate.UseVisualStyleBackColor = true;
            this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
            // 
            // combodegrees
            // 
            this.combodegrees.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.combodegrees.FormattingEnabled = true;
            this.combodegrees.Items.AddRange(new object[] {
            "0",
            "15",
            "30",
            "45",
            "60",
            "75",
            "90",
            "120",
            "150"});
            this.combodegrees.Location = new System.Drawing.Point(12, 32);
            this.combodegrees.Name = "combodegrees";
            this.combodegrees.Size = new System.Drawing.Size(86, 21);
            this.combodegrees.TabIndex = 2;
            this.combodegrees.SelectedIndexChanged += new System.EventHandler(this.combodegrees_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Degrees";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.Calculate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(765, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(116, 442);
            this.panel1.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textPrecision);
            this.groupBox2.Controls.Add(this.checkProjection);
            this.groupBox2.Location = new System.Drawing.Point(6, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(107, 80);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Solid Area";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Precision";
            // 
            // textPrecision
            // 
            this.textPrecision.DecimalPlaces = 4;
            this.textPrecision.Enabled = false;
            this.textPrecision.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.textPrecision.Location = new System.Drawing.Point(12, 32);
            this.textPrecision.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            327680});
            this.textPrecision.Name = "textPrecision";
            this.textPrecision.Size = new System.Drawing.Size(86, 20);
            this.textPrecision.TabIndex = 4;
            this.textPrecision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textPrecision.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            // 
            // checkProjection
            // 
            this.checkProjection.AutoSize = true;
            this.checkProjection.Checked = true;
            this.checkProjection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkProjection.Enabled = false;
            this.checkProjection.Location = new System.Drawing.Point(12, 58);
            this.checkProjection.Name = "checkProjection";
            this.checkProjection.Size = new System.Drawing.Size(73, 17);
            this.checkProjection.TabIndex = 6;
            this.checkProjection.Text = "Projection";
            this.checkProjection.UseVisualStyleBackColor = true;
            this.checkProjection.CheckedChanged += new System.EventHandler(this.checkProjection_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.combodegrees);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(107, 63);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Polyline Area";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 30);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(765, 442);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.vdFramedControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(757, 404);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Polyline Area";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.vdFramedControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(757, 404);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Solid Area";
            // 
            // vdFramedControl2
            // 
            this.vdFramedControl2.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.vdFramedControl2.DisplayPolarCoord = false;
            this.vdFramedControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vdFramedControl2.HistoryLines = ((uint)(3u));
            this.vdFramedControl2.Location = new System.Drawing.Point(3, 3);
            this.vdFramedControl2.Name = "vdFramedControl2";
            this.vdFramedControl2.PropertyGridWidth = ((uint)(300u));
            this.vdFramedControl2.Size = new System.Drawing.Size(751, 398);
            this.vdFramedControl2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 442);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textPrecision)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private vdControls.vdFramedControl vdFramedControl1;
        private System.Windows.Forms.Button Calculate;
        private System.Windows.Forms.ComboBox combodegrees;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private vdControls.vdFramedControl vdFramedControl2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown textPrecision;
        private System.Windows.Forms.CheckBox checkProjection;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}

