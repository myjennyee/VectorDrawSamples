namespace NoGraphicsExample
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
            this.vdDocumentComponent1 = new VectorDraw.Professional.Components.vdDocumentComponent(this.components);
            this.butExit = new System.Windows.Forms.Button();
            this.butExport = new System.Windows.Forms.Button();
            this.imgPrev = new System.Windows.Forms.Label();
            this.picPrev1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPrev1)).BeginInit();
            this.SuspendLayout();
            // 
            // butExit
            // 
            this.butExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butExit.Location = new System.Drawing.Point(131, 251);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(66, 27);
            this.butExit.TabIndex = 0;
            this.butExit.Text = "Exit";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // butExport
            // 
            this.butExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butExport.Location = new System.Drawing.Point(12, 251);
            this.butExport.Name = "butExport";
            this.butExport.Size = new System.Drawing.Size(76, 27);
            this.butExport.TabIndex = 1;
            this.butExport.Text = "Export";
            this.butExport.UseVisualStyleBackColor = true;
            this.butExport.Click += new System.EventHandler(this.butExport_Click);
            // 
            // imgPrev
            // 
            this.imgPrev.AutoSize = true;
            this.imgPrev.Location = new System.Drawing.Point(9, 9);
            this.imgPrev.Name = "imgPrev";
            this.imgPrev.Size = new System.Drawing.Size(80, 13);
            this.imgPrev.TabIndex = 2;
            this.imgPrev.Text = "Preview Image!";
            // 
            // picPrev1
            // 
            this.picPrev1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picPrev1.Location = new System.Drawing.Point(12, 21);
            this.picPrev1.Name = "picPrev1";
            this.picPrev1.Size = new System.Drawing.Size(184, 224);
            this.picPrev1.TabIndex = 3;
            this.picPrev1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 290);
            this.Controls.Add(this.picPrev1);
            this.Controls.Add(this.imgPrev);
            this.Controls.Add(this.butExport);
            this.Controls.Add(this.butExit);
            this.MinimumSize = new System.Drawing.Size(217, 317);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picPrev1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VectorDraw.Professional.Components.vdDocumentComponent vdDocumentComponent1;
        private System.Windows.Forms.Button butExit;
        private System.Windows.Forms.Button butExport;
        private System.Windows.Forms.Label imgPrev;
        private System.Windows.Forms.PictureBox picPrev1;
    }
}

