namespace ActionDraw_Event
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
            this.vdSC = new vdScrollableControl.vdScrollableControl();
            this.chkBox = new System.Windows.Forms.CheckBox();
            this.btLine = new System.Windows.Forms.Button();
            this.chkBox_GripDraw = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // vdSC
            // 
            this.vdSC.BackColor = System.Drawing.SystemColors.Control;
            this.vdSC.Location = new System.Drawing.Point(12, 12);
            this.vdSC.Name = "vdSC";
            this.vdSC.ShowLayoutPopupMenu = true;
            this.vdSC.Size = new System.Drawing.Size(607, 402);
            this.vdSC.TabIndex = 1;
            // 
            // chkBox
            // 
            this.chkBox.AutoSize = true;
            this.chkBox.Checked = true;
            this.chkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox.Location = new System.Drawing.Point(297, 428);
            this.chkBox.Name = "chkBox";
            this.chkBox.Size = new System.Drawing.Size(158, 17);
            this.chkBox.TabIndex = 4;
            this.chkBox.Text = "Enable ActionDraw override";
            this.chkBox.UseVisualStyleBackColor = true;
            this.chkBox.CheckedChanged += new System.EventHandler(this.chkBox_CheckedChanged);
            // 
            // btLine
            // 
            this.btLine.Location = new System.Drawing.Point(108, 418);
            this.btLine.Name = "btLine";
            this.btLine.Size = new System.Drawing.Size(104, 35);
            this.btLine.TabIndex = 3;
            this.btLine.Text = "Command Line";
            this.btLine.UseVisualStyleBackColor = true;
            this.btLine.Click += new System.EventHandler(this.btLine_Click);
            // 
            // chkBox_GripDraw
            // 
            this.chkBox_GripDraw.AutoSize = true;
            this.chkBox_GripDraw.Checked = true;
            this.chkBox_GripDraw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBox_GripDraw.Location = new System.Drawing.Point(461, 428);
            this.chkBox_GripDraw.Name = "chkBox_GripDraw";
            this.chkBox_GripDraw.Size = new System.Drawing.Size(150, 17);
            this.chkBox_GripDraw.TabIndex = 5;
            this.chkBox_GripDraw.Text = "Enable Draw Grip override";
            this.chkBox_GripDraw.UseVisualStyleBackColor = true;
            this.chkBox_GripDraw.CheckedChanged += new System.EventHandler(this.chkBox_GripDraw_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 465);
            this.Controls.Add(this.chkBox_GripDraw);
            this.Controls.Add(this.chkBox);
            this.Controls.Add(this.btLine);
            this.Controls.Add(this.vdSC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ActionDraw Event Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private vdScrollableControl.vdScrollableControl vdSC;
        internal System.Windows.Forms.CheckBox chkBox;
        internal System.Windows.Forms.Button btLine;
        internal System.Windows.Forms.CheckBox chkBox_GripDraw;
    }
}

