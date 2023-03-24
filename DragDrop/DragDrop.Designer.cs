namespace DragDrop
{
    partial class DragDropSample
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
            this.vdSource = new VectorDraw.Professional.Control.VectorDrawBaseControl();
            this.vdDest = new VectorDraw.Professional.Control.VectorDrawBaseControl();
            this.ImageButton = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // vdSource
            // 
            this.vdSource.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.vdSource.AllowDrop = true;
            this.vdSource.Cursor = System.Windows.Forms.Cursors.Default;
            this.vdSource.DisableVdrawDxf = false;
            this.vdSource.EnableAutoGripOn = true;
            this.vdSource.Location = new System.Drawing.Point(17, 14);
            this.vdSource.Name = "vdSource";
            this.vdSource.Size = new System.Drawing.Size(248, 192);
            this.vdSource.TabIndex = 0;
            // 
            // vdDest
            // 
            this.vdDest.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.vdDest.AllowDrop = true;
            this.vdDest.Cursor = System.Windows.Forms.Cursors.Default;
            this.vdDest.DisableVdrawDxf = false;
            this.vdDest.EnableAutoGripOn = true;
            this.vdDest.Location = new System.Drawing.Point(292, 12);
            this.vdDest.Name = "vdDest";
            this.vdDest.Size = new System.Drawing.Size(248, 192);
            this.vdDest.TabIndex = 1;
            // 
            // ImageButton
            // 
            this.ImageButton.AllowDrop = true;
            this.ImageButton.Location = new System.Drawing.Point(17, 212);
            this.ImageButton.Name = "ImageButton";
            this.ImageButton.Size = new System.Drawing.Size(248, 192);
            this.ImageButton.TabIndex = 3;
            this.ImageButton.Text = "ImageButton";
            this.ImageButton.UseVisualStyleBackColor = true;
            // 
            // label
            // 
            this.label.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.label.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label.Location = new System.Drawing.Point(293, 223);
            this.label.Multiline = true;
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(246, 181);
            this.label.TabIndex = 5;
            // 
            // DragDropSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 444);
            this.Controls.Add(this.label);
            this.Controls.Add(this.ImageButton);
            this.Controls.Add(this.vdDest);
            this.Controls.Add(this.vdSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DragDropSample";
            this.Text = "Drag & Drop Example";
            this.Load += new System.EventHandler(this.DragDropSample_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VectorDraw.Professional.Control.VectorDrawBaseControl vdSource;
        private VectorDraw.Professional.Control.VectorDrawBaseControl vdDest;
        private System.Windows.Forms.Button ImageButton;
        private System.Windows.Forms.TextBox label;
    }
}

