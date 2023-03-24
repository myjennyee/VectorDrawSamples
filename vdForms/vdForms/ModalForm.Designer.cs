namespace vdForms
{
    partial class ModalForm
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
            this.butPick = new System.Windows.Forms.Button();
            this.labX = new System.Windows.Forms.Label();
            this.labY = new System.Windows.Forms.Label();
            this.labPointX = new System.Windows.Forms.Label();
            this.labPointY = new System.Windows.Forms.Label();
            this.butExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butPick
            // 
            this.butPick.Location = new System.Drawing.Point(12, 72);
            this.butPick.Name = "butPick";
            this.butPick.Size = new System.Drawing.Size(78, 22);
            this.butPick.TabIndex = 0;
            this.butPick.Text = "Pick A Point";
            this.butPick.UseVisualStyleBackColor = true;
            this.butPick.Click += new System.EventHandler(this.butPick_Click);
            // 
            // labX
            // 
            this.labX.AutoSize = true;
            this.labX.Location = new System.Drawing.Point(12, 9);
            this.labX.Name = "labX";
            this.labX.Size = new System.Drawing.Size(20, 13);
            this.labX.TabIndex = 1;
            this.labX.Text = "X :";
            // 
            // labY
            // 
            this.labY.AutoSize = true;
            this.labY.Location = new System.Drawing.Point(12, 36);
            this.labY.Name = "labY";
            this.labY.Size = new System.Drawing.Size(20, 13);
            this.labY.TabIndex = 2;
            this.labY.Text = "Y :";
            // 
            // labPointX
            // 
            this.labPointX.AutoSize = true;
            this.labPointX.Location = new System.Drawing.Point(38, 9);
            this.labPointX.Name = "labPointX";
            this.labPointX.Size = new System.Drawing.Size(0, 13);
            this.labPointX.TabIndex = 3;
            // 
            // labPointY
            // 
            this.labPointY.AutoSize = true;
            this.labPointY.Location = new System.Drawing.Point(38, 36);
            this.labPointY.Name = "labPointY";
            this.labPointY.Size = new System.Drawing.Size(0, 13);
            this.labPointY.TabIndex = 4;
            // 
            // butExit
            // 
            this.butExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butExit.Location = new System.Drawing.Point(106, 72);
            this.butExit.Name = "butExit";
            this.butExit.Size = new System.Drawing.Size(47, 22);
            this.butExit.TabIndex = 5;
            this.butExit.Text = "Exit";
            this.butExit.UseVisualStyleBackColor = true;
            this.butExit.Click += new System.EventHandler(this.butExit_Click);
            // 
            // ModalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.butExit;
            this.ClientSize = new System.Drawing.Size(159, 106);
            this.Controls.Add(this.butExit);
            this.Controls.Add(this.labPointY);
            this.Controls.Add(this.labPointX);
            this.Controls.Add(this.labY);
            this.Controls.Add(this.labX);
            this.Controls.Add(this.butPick);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ModalForm";
            this.Text = "ModalForm";
            this.Load += new System.EventHandler(this.ModalForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butPick;
        private System.Windows.Forms.Label labX;
        private System.Windows.Forms.Label labY;
        private System.Windows.Forms.Label labPointX;
        private System.Windows.Forms.Label labPointY;
        private System.Windows.Forms.Button butExit;
    }
}