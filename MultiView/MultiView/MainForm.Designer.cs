namespace MultiView
{
    partial class MainForm
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
            this.butOpen = new System.Windows.Forms.Button();
            this.butDialog = new System.Windows.Forms.Button();
            this.vdFramedControl1 = new vdControls.vdFramedControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butOpen
            // 
            this.butOpen.Location = new System.Drawing.Point(12, 25);
            this.butOpen.Name = "butOpen";
            this.butOpen.Size = new System.Drawing.Size(98, 23);
            this.butOpen.TabIndex = 1;
            this.butOpen.Text = "Open";
            this.butOpen.UseVisualStyleBackColor = true;
            this.butOpen.Click += new System.EventHandler(this.butOpen_Click);
            // 
            // butDialog
            // 
            this.butDialog.Location = new System.Drawing.Point(116, 25);
            this.butDialog.Name = "butDialog";
            this.butDialog.Size = new System.Drawing.Size(98, 23);
            this.butDialog.TabIndex = 2;
            this.butDialog.Text = "MultiView Dialog";
            this.butDialog.UseVisualStyleBackColor = true;
            this.butDialog.Click += new System.EventHandler(this.butDialog_Click);
            // 
            // vdFramedControl1
            // 
            this.vdFramedControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.vdFramedControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vdFramedControl1.DisplayPolarCoord = false;
            this.vdFramedControl1.HistoryLines = ((uint)(3u));
            this.vdFramedControl1.Location = new System.Drawing.Point(1, 73);
            this.vdFramedControl1.Name = "vdFramedControl1";
            this.vdFramedControl1.PropertyGridWidth = ((uint)(300u));
            this.vdFramedControl1.Size = new System.Drawing.Size(1241, 622);
            this.vdFramedControl1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(951, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Press the open button to open a default drawing. After opening the drawing a mult" +
                "iview layout is created and added to the Document. Note that the Model is being " +
                "hidden from the bottom layout toolbar.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(220, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(390, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "The Multiview Dialog can help you either modify the current or create a new one. " +
                "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(220, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(802, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "You can activate a viewport by simply clicking on it. In some modes you can resiz" +
                "e the scene by clicking on the separator. All viewports recieve commands when ac" +
                "tive. ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(484, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Doubleclick on any viewport to maximise it , doubleclicking again will return to " +
                "the multi viewport view.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(291, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "With Ctrl(left) + Tab you can navigate through the viewports.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 697);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butDialog);
            this.Controls.Add(this.butOpen);
            this.Controls.Add(this.vdFramedControl1);
            this.Name = "MainForm";
            this.Text = "MultiView Sample";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private vdControls.vdFramedControl vdFramedControl1;
        private System.Windows.Forms.Button butOpen;
        private System.Windows.Forms.Button butDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

