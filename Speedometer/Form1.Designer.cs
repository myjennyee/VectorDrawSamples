namespace Speedometer
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboSpeed = new System.Windows.Forms.ComboBox();
            this.butStart = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.vectorDrawBaseControl1 = new VectorDraw.Professional.Control.VectorDrawBaseControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Speed";
            // 
            // comboSpeed
            // 
            this.comboSpeed.FormattingEnabled = true;
            this.comboSpeed.Items.AddRange(new object[] {
            "Very Fast",
            "Fast",
            "Slow"});
            this.comboSpeed.Location = new System.Drawing.Point(375, 54);
            this.comboSpeed.Name = "comboSpeed";
            this.comboSpeed.Size = new System.Drawing.Size(96, 21);
            this.comboSpeed.TabIndex = 7;
            // 
            // butStart
            // 
            this.butStart.Location = new System.Drawing.Point(334, 95);
            this.butStart.Name = "butStart";
            this.butStart.Size = new System.Drawing.Size(137, 28);
            this.butStart.TabIndex = 6;
            this.butStart.Text = "Start";
            this.butStart.UseVisualStyleBackColor = true;
            this.butStart.Click += new System.EventHandler(this.butStart_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(334, 12);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(137, 25);
            this.progressBar1.TabIndex = 5;
            // 
            // vectorDrawBaseControl1
            // 
            this.vectorDrawBaseControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.vectorDrawBaseControl1.AllowDrop = true;
            this.vectorDrawBaseControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.vectorDrawBaseControl1.DisableVdrawDxf = false;
            this.vectorDrawBaseControl1.EnableAutoGripOn = true;
            this.vectorDrawBaseControl1.Location = new System.Drawing.Point(10, 12);
            this.vectorDrawBaseControl1.Name = "vectorDrawBaseControl1";
            this.vectorDrawBaseControl1.Size = new System.Drawing.Size(315, 207);
            this.vectorDrawBaseControl1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 226);
            this.Controls.Add(this.vectorDrawBaseControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboSpeed);
            this.Controls.Add(this.butStart);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Progress";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboSpeed;
        private System.Windows.Forms.Button butStart;
        private System.Windows.Forms.ProgressBar progressBar1;
        private VectorDraw.Professional.Control.VectorDrawBaseControl vectorDrawBaseControl1;
    }
}

