namespace CommandButtonImages
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
            this.vectorDrawBaseControl1 = new VectorDraw.Professional.Control.VectorDrawBaseControl();
            this.SuspendLayout();
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
            this.vectorDrawBaseControl1.Size = new System.Drawing.Size(903, 375);
            this.vectorDrawBaseControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 375);
            this.Controls.Add(this.vectorDrawBaseControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private VectorDraw.Professional.Control.VectorDrawBaseControl vectorDrawBaseControl1;
    }
}

