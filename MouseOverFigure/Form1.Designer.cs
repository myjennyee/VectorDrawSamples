namespace MouseOverFigure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textMouseDown = new System.Windows.Forms.TextBox();
            this.textMouseUp = new System.Windows.Forms.TextBox();
            this.textMouseOverDraw = new System.Windows.Forms.TextBox();
            this.textMouseMove = new System.Windows.Forms.TextBox();
            this.textMouseLeave = new System.Windows.Forms.TextBox();
            this.textMouseEnter = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDrawline = new System.Windows.Forms.Button();
            this.checkUrls = new System.Windows.Forms.CheckBox();
            this.comboOsnaps = new System.Windows.Forms.ComboBox();
            this.checkTooltips = new System.Windows.Forms.CheckBox();
            this.checkSelectionPreview = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.vectorDrawBaseControl1 = new VectorDraw.Professional.Control.VectorDrawBaseControl();
            this.textDoubleClick = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1123, 151);
            this.panel1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(637, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(416, 131);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "Reopen file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textDoubleClick);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textMouseDown);
            this.groupBox2.Controls.Add(this.textMouseUp);
            this.groupBox2.Controls.Add(this.textMouseOverDraw);
            this.groupBox2.Controls.Add(this.textMouseMove);
            this.groupBox2.Controls.Add(this.textMouseLeave);
            this.groupBox2.Controls.Add(this.textMouseEnter);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(333, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(298, 132);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Event type";
            // 
            // textMouseDown
            // 
            this.textMouseDown.Location = new System.Drawing.Point(240, 23);
            this.textMouseDown.Name = "textMouseDown";
            this.textMouseDown.Size = new System.Drawing.Size(38, 20);
            this.textMouseDown.TabIndex = 11;
            this.textMouseDown.Text = "0";
            // 
            // textMouseUp
            // 
            this.textMouseUp.Location = new System.Drawing.Point(240, 45);
            this.textMouseUp.Name = "textMouseUp";
            this.textMouseUp.Size = new System.Drawing.Size(38, 20);
            this.textMouseUp.TabIndex = 10;
            this.textMouseUp.Text = "0";
            // 
            // textMouseOverDraw
            // 
            this.textMouseOverDraw.Location = new System.Drawing.Point(240, 68);
            this.textMouseOverDraw.Name = "textMouseOverDraw";
            this.textMouseOverDraw.Size = new System.Drawing.Size(38, 20);
            this.textMouseOverDraw.TabIndex = 9;
            this.textMouseOverDraw.Text = "0";
            // 
            // textMouseMove
            // 
            this.textMouseMove.Location = new System.Drawing.Point(103, 68);
            this.textMouseMove.Name = "textMouseMove";
            this.textMouseMove.Size = new System.Drawing.Size(38, 20);
            this.textMouseMove.TabIndex = 8;
            this.textMouseMove.Text = "0";
            // 
            // textMouseLeave
            // 
            this.textMouseLeave.Location = new System.Drawing.Point(103, 45);
            this.textMouseLeave.Name = "textMouseLeave";
            this.textMouseLeave.Size = new System.Drawing.Size(38, 20);
            this.textMouseLeave.TabIndex = 7;
            this.textMouseLeave.Text = "0";
            // 
            // textMouseEnter
            // 
            this.textMouseEnter.Location = new System.Drawing.Point(103, 21);
            this.textMouseEnter.Name = "textMouseEnter";
            this.textMouseEnter.Size = new System.Drawing.Size(38, 20);
            this.textMouseEnter.TabIndex = 6;
            this.textMouseEnter.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(147, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "MouseOverDraw";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(147, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "MouseUp";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(147, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "MouseDown";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "MouseMove";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "MouseLeave";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "MouseEnter";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.buttonDrawline);
            this.groupBox1.Controls.Add(this.checkUrls);
            this.groupBox1.Controls.Add(this.comboOsnaps);
            this.groupBox1.Controls.Add(this.checkTooltips);
            this.groupBox1.Controls.Add(this.checkSelectionPreview);
            this.groupBox1.Location = new System.Drawing.Point(104, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Use various combinations";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "osnap Mode";
            // 
            // buttonDrawline
            // 
            this.buttonDrawline.Location = new System.Drawing.Point(133, 102);
            this.buttonDrawline.Name = "buttonDrawline";
            this.buttonDrawline.Size = new System.Drawing.Size(65, 21);
            this.buttonDrawline.TabIndex = 3;
            this.buttonDrawline.Text = "Draw Line";
            this.buttonDrawline.UseVisualStyleBackColor = true;
            this.buttonDrawline.Click += new System.EventHandler(this.buttonDrawline_Click);
            // 
            // checkUrls
            // 
            this.checkUrls.AutoSize = true;
            this.checkUrls.Location = new System.Drawing.Point(6, 71);
            this.checkUrls.Name = "checkUrls";
            this.checkUrls.Size = new System.Drawing.Size(44, 17);
            this.checkUrls.TabIndex = 2;
            this.checkUrls.Text = "Urls";
            this.checkUrls.UseVisualStyleBackColor = true;
            this.checkUrls.CheckedChanged += new System.EventHandler(this.checkUrls_CheckedChanged);
            // 
            // comboOsnaps
            // 
            this.comboOsnaps.FormattingEnabled = true;
            this.comboOsnaps.Location = new System.Drawing.Point(6, 102);
            this.comboOsnaps.Name = "comboOsnaps";
            this.comboOsnaps.Size = new System.Drawing.Size(121, 21);
            this.comboOsnaps.TabIndex = 1;
            this.comboOsnaps.SelectedIndexChanged += new System.EventHandler(this.comboOsnaps_SelectedIndexChanged);
            // 
            // checkTooltips
            // 
            this.checkTooltips.AutoSize = true;
            this.checkTooltips.Location = new System.Drawing.Point(6, 48);
            this.checkTooltips.Name = "checkTooltips";
            this.checkTooltips.Size = new System.Drawing.Size(63, 17);
            this.checkTooltips.TabIndex = 1;
            this.checkTooltips.Text = "Tooltips";
            this.checkTooltips.UseVisualStyleBackColor = true;
            this.checkTooltips.CheckedChanged += new System.EventHandler(this.checkTooltips_CheckedChanged);
            // 
            // checkSelectionPreview
            // 
            this.checkSelectionPreview.AutoSize = true;
            this.checkSelectionPreview.Location = new System.Drawing.Point(6, 25);
            this.checkSelectionPreview.Name = "checkSelectionPreview";
            this.checkSelectionPreview.Size = new System.Drawing.Size(108, 17);
            this.checkSelectionPreview.TabIndex = 0;
            this.checkSelectionPreview.Text = "SelectionPreview";
            this.checkSelectionPreview.UseVisualStyleBackColor = true;
            this.checkSelectionPreview.CheckedChanged += new System.EventHandler(this.checkSelectionPreview_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.vectorDrawBaseControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 151);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1123, 516);
            this.panel2.TabIndex = 1;
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
            this.vectorDrawBaseControl1.Size = new System.Drawing.Size(1123, 516);
            this.vectorDrawBaseControl1.TabIndex = 0;
            // 
            // textDoubleClick
            // 
            this.textDoubleClick.Location = new System.Drawing.Point(103, 91);
            this.textDoubleClick.Name = "textDoubleClick";
            this.textDoubleClick.Size = new System.Drawing.Size(38, 20);
            this.textDoubleClick.TabIndex = 13;
            this.textDoubleClick.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "MouseDoubleClick";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 667);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Mouse Over Figure";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkTooltips;
        private System.Windows.Forms.CheckBox checkSelectionPreview;
        private System.Windows.Forms.CheckBox checkUrls;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboOsnaps;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textMouseOverDraw;
        private System.Windows.Forms.TextBox textMouseMove;
        private System.Windows.Forms.TextBox textMouseLeave;
        private System.Windows.Forms.TextBox textMouseEnter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textMouseDown;
        private System.Windows.Forms.TextBox textMouseUp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonDrawline;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private VectorDraw.Professional.Control.VectorDrawBaseControl vectorDrawBaseControl1;
        private System.Windows.Forms.TextBox textDoubleClick;
        private System.Windows.Forms.Label label8;
    }
}

