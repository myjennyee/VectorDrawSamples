namespace Presentation
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
            this.butStart = new System.Windows.Forms.Button();
            this.butCreate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkSun = new System.Windows.Forms.CheckBox();
            this.checkRedLight = new System.Windows.Forms.CheckBox();
            this.checkSpot = new System.Windows.Forms.CheckBox();
            this.checkClipping = new System.Windows.Forms.CheckBox();
            this.vd = new VectorDraw.Professional.Control.VectorDrawBaseControl();
            this.SuspendLayout();
            // 
            // butStart
            // 
            this.butStart.Location = new System.Drawing.Point(281, 12);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(59, 27);
            this.butStart.TabIndex = 1;
            this.butStart.Text = "Start tour";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Visible = false;
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            // 
            // butCreate
            // 
            this.butCreate.Location = new System.Drawing.Point(9, 12);
            this.butCreate.Name = "butCreate";
            this.butCreate.Size = new System.Drawing.Size(107, 27);
            this.butCreate.TabIndex = 5;
            this.butCreate.Text = "Create 3D Scene";
            this.butCreate.UseVisualStyleBackColor = true;
            this.butCreate.Click += new System.EventHandler(this.butCreate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Step:";
            this.label1.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(384, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(53, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "0.08";
            this.textBox1.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 503);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "label2";
            // 
            // checkSun
            // 
            this.checkSun.AutoSize = true;
            this.checkSun.Location = new System.Drawing.Point(477, 18);
            this.checkSun.Name = "checkSun";
            this.checkSun.Size = new System.Drawing.Size(45, 17);
            this.checkSun.TabIndex = 11;
            this.checkSun.Text = "Sun";
            this.checkSun.UseVisualStyleBackColor = true;
            this.checkSun.Visible = false;
            this.checkSun.CheckedChanged += new System.EventHandler(this.checkSun_CheckedChanged);
            // 
            // checkRedLight
            // 
            this.checkRedLight.AutoSize = true;
            this.checkRedLight.Location = new System.Drawing.Point(550, 18);
            this.checkRedLight.Name = "checkRedLight";
            this.checkRedLight.Size = new System.Drawing.Size(80, 17);
            this.checkRedLight.TabIndex = 12;
            this.checkRedLight.Text = "Room Light";
            this.checkRedLight.UseVisualStyleBackColor = true;
            this.checkRedLight.Visible = false;
            this.checkRedLight.CheckedChanged += new System.EventHandler(this.checkRedLight_CheckedChanged);
            // 
            // checkSpot
            // 
            this.checkSpot.AutoSize = true;
            this.checkSpot.Location = new System.Drawing.Point(644, 18);
            this.checkSpot.Name = "checkSpot";
            this.checkSpot.Size = new System.Drawing.Size(48, 17);
            this.checkSpot.TabIndex = 13;
            this.checkSpot.Text = "Spot";
            this.checkSpot.UseVisualStyleBackColor = true;
            this.checkSpot.Visible = false;
            this.checkSpot.CheckedChanged += new System.EventHandler(this.checkSpot_CheckedChanged);
            // 
            // checkClipping
            // 
            this.checkClipping.AutoSize = true;
            this.checkClipping.Location = new System.Drawing.Point(747, 18);
            this.checkClipping.Name = "checkClipping";
            this.checkClipping.Size = new System.Drawing.Size(92, 17);
            this.checkClipping.TabIndex = 14;
            this.checkClipping.Text = "Apply Clipping";
            this.checkClipping.UseVisualStyleBackColor = true;
            this.checkClipping.Visible = false;
            this.checkClipping.CheckedChanged += new System.EventHandler(this.checkClipping_CheckedChanged);
            // 
            // vd
            // 
            this.vd.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.vd.AllowDrop = true;
            this.vd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vd.Cursor = System.Windows.Forms.Cursors.Default;
            this.vd.DisableVdrawDxf = false;
            this.vd.EnableAutoGripOn = true;
            this.vd.Location = new System.Drawing.Point(15, 45);
            this.vd.Name = "vd";
            this.vd.Size = new System.Drawing.Size(818, 455);
            this.vd.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 544);
            this.Controls.Add(this.vd);
            this.Controls.Add(this.checkClipping);
            this.Controls.Add(this.checkSpot);
            this.Controls.Add(this.checkRedLight);
            this.Controls.Add(this.checkSun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butCreate);
            this.Controls.Add(this.butStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.Button butCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkSun;
        private System.Windows.Forms.CheckBox checkRedLight;
        private System.Windows.Forms.CheckBox checkSpot;
        private System.Windows.Forms.CheckBox checkClipping;
        private VectorDraw.Professional.Control.VectorDrawBaseControl vd;
    }
}

