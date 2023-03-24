namespace AddEntities
{
    partial class Form2
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
            this.vdFramedControl1 = new vdControls.vdFramedControl();
            this.radioequasion1 = new System.Windows.Forms.RadioButton();
            this.radioequasion2 = new System.Windows.Forms.RadioButton();
            this.butRotate = new System.Windows.Forms.Button();
            this.butAddContour = new System.Windows.Forms.Button();
            this.labContours = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioequasion3 = new System.Windows.Forms.RadioButton();
            this.radioMappedImage = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vdFramedControl1
            // 
            this.vdFramedControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.vdFramedControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vdFramedControl1.DisplayPolarCoord = false;
            this.vdFramedControl1.HistoryLines = ((uint)(3u));
            this.vdFramedControl1.Location = new System.Drawing.Point(0, 0);
            this.vdFramedControl1.Name = "vdFramedControl1";
            this.vdFramedControl1.PropertyGridWidth = ((uint)(300u));
            this.vdFramedControl1.Size = new System.Drawing.Size(756, 492);
            this.vdFramedControl1.TabIndex = 0;
            // 
            // radioequasion1
            // 
            this.radioequasion1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioequasion1.AutoSize = true;
            this.radioequasion1.Location = new System.Drawing.Point(763, 21);
            this.radioequasion1.Name = "radioequasion1";
            this.radioequasion1.Size = new System.Drawing.Size(91, 17);
            this.radioequasion1.TabIndex = 1;
            this.radioequasion1.Text = "First Equasion";
            this.radioequasion1.UseVisualStyleBackColor = true;
            this.radioequasion1.CheckedChanged += new System.EventHandler(this.radioequasion1_CheckedChanged);
            // 
            // radioequasion2
            // 
            this.radioequasion2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioequasion2.AutoSize = true;
            this.radioequasion2.Location = new System.Drawing.Point(763, 44);
            this.radioequasion2.Name = "radioequasion2";
            this.radioequasion2.Size = new System.Drawing.Size(109, 17);
            this.radioequasion2.TabIndex = 2;
            this.radioequasion2.Text = "Second Equasion";
            this.radioequasion2.UseVisualStyleBackColor = true;
            this.radioequasion2.CheckedChanged += new System.EventHandler(this.radioequasion2_CheckedChanged);
            // 
            // butRotate
            // 
            this.butRotate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butRotate.Location = new System.Drawing.Point(763, 263);
            this.butRotate.Name = "butRotate";
            this.butRotate.Size = new System.Drawing.Size(124, 23);
            this.butRotate.TabIndex = 3;
            this.butRotate.Text = "3D Rotate";
            this.butRotate.UseVisualStyleBackColor = true;
            this.butRotate.Click += new System.EventHandler(this.butRotate_Click);
            // 
            // butAddContour
            // 
            this.butAddContour.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddContour.Location = new System.Drawing.Point(6, 51);
            this.butAddContour.Name = "butAddContour";
            this.butAddContour.Size = new System.Drawing.Size(112, 23);
            this.butAddContour.TabIndex = 4;
            this.butAddContour.Text = "Add Contour";
            this.butAddContour.UseVisualStyleBackColor = true;
            this.butAddContour.Click += new System.EventHandler(this.butAddContour_Click);
            // 
            // labContours
            // 
            this.labContours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labContours.AutoSize = true;
            this.labContours.Location = new System.Drawing.Point(6, 25);
            this.labContours.Name = "labContours";
            this.labContours.Size = new System.Drawing.Size(35, 13);
            this.labContours.TabIndex = 5;
            this.labContours.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labContours);
            this.groupBox1.Controls.Add(this.butAddContour);
            this.groupBox1.Location = new System.Drawing.Point(763, 174);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(124, 83);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contours";
            // 
            // radioequasion3
            // 
            this.radioequasion3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioequasion3.AutoSize = true;
            this.radioequasion3.Location = new System.Drawing.Point(763, 67);
            this.radioequasion3.Name = "radioequasion3";
            this.radioequasion3.Size = new System.Drawing.Size(108, 17);
            this.radioequasion3.TabIndex = 7;
            this.radioequasion3.Text = "Colored Equasion";
            this.radioequasion3.UseVisualStyleBackColor = true;
            this.radioequasion3.CheckedChanged += new System.EventHandler(this.radioequasion3_CheckedChanged);
            // 
            // radioMappedImage
            // 
            this.radioMappedImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioMappedImage.AutoSize = true;
            this.radioMappedImage.Location = new System.Drawing.Point(763, 90);
            this.radioMappedImage.Name = "radioMappedImage";
            this.radioMappedImage.Size = new System.Drawing.Size(96, 17);
            this.radioMappedImage.TabIndex = 8;
            this.radioMappedImage.Text = "Mapped Image";
            this.radioMappedImage.UseVisualStyleBackColor = true;
            this.radioMappedImage.CheckedChanged += new System.EventHandler(this.radioMappedImage_CheckedChanged);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 493);
            this.Controls.Add(this.radioMappedImage);
            this.Controls.Add(this.radioequasion3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.butRotate);
            this.Controls.Add(this.radioequasion2);
            this.Controls.Add(this.radioequasion1);
            this.Controls.Add(this.vdFramedControl1);
            this.Name = "Form2";
            this.Text = "Ground Surface";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private vdControls.vdFramedControl vdFramedControl1;
        private System.Windows.Forms.RadioButton radioequasion1;
        private System.Windows.Forms.RadioButton radioequasion2;
        private System.Windows.Forms.Button butRotate;
        private System.Windows.Forms.Button butAddContour;
        private System.Windows.Forms.Label labContours;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioequasion3;
        private System.Windows.Forms.RadioButton radioMappedImage;
    }
}