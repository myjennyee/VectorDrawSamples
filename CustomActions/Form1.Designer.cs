namespace CustomActions
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
            this.Label1 = new System.Windows.Forms.Label();
            this.VDMain = new vdScrollableControl.vdScrollableControl();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(-2, -3);
            this.Label1.MinimumSize = new System.Drawing.Size(848, 50);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(848, 50);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "With this form size small, click anywhere on the rectangle to start dragging it a" +
                "round. It moves quicly and smoothly.";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VDMain
            // 
            this.VDMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.VDMain.BackColor = System.Drawing.SystemColors.Control;
            this.VDMain.Location = new System.Drawing.Point(1, 48);
            this.VDMain.Margin = new System.Windows.Forms.Padding(1);
            this.VDMain.Name = "VDMain";
            this.VDMain.ShowLayoutPopupMenu = true;
            this.VDMain.Size = new System.Drawing.Size(843, 479);
            this.VDMain.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 530);
            this.Controls.Add(this.VDMain);
            this.Controls.Add(this.Label1);
            this.MinimumSize = new System.Drawing.Size(861, 568);
            this.Name = "Form1";
            this.Text = "Custom Action Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        private vdScrollableControl.vdScrollableControl VDMain;
    }
}

