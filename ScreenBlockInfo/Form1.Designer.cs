namespace ScreenBlockInfo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRotate3DView = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbVDFAxis = new System.Windows.Forms.CheckBox();
            this.rdb3D = new System.Windows.Forms.RadioButton();
            this.rdbInfo = new System.Windows.Forms.RadioButton();
            this.vdFramedControl1 = new vdControls.vdFramedControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnRotate3DView);
            this.groupBox1.Controls.Add(this.lblInfo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbVDFAxis);
            this.groupBox1.Controls.Add(this.rdb3D);
            this.groupBox1.Controls.Add(this.rdbInfo);
            this.groupBox1.Location = new System.Drawing.Point(6, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(904, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information Screen Block";
            // 
            // btnRotate3DView
            // 
            this.btnRotate3DView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRotate3DView.Location = new System.Drawing.Point(759, 49);
            this.btnRotate3DView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRotate3DView.Name = "btnRotate3DView";
            this.btnRotate3DView.Size = new System.Drawing.Size(122, 26);
            this.btnRotate3DView.TabIndex = 6;
            this.btnRotate3DView.Text = "3D Rotate View";
            this.btnRotate3DView.UseVisualStyleBackColor = true;
            this.btnRotate3DView.Click += new System.EventHandler(this.btnRotate3DView_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(96, 60);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(12, 16);
            this.lblInfo.TabIndex = 5;
            this.lblInfo.Text = " ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Explanation:";
            // 
            // cbVDFAxis
            // 
            this.cbVDFAxis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVDFAxis.AutoSize = true;
            this.cbVDFAxis.Checked = true;
            this.cbVDFAxis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbVDFAxis.Location = new System.Drawing.Point(747, 23);
            this.cbVDFAxis.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbVDFAxis.Name = "cbVDFAxis";
            this.cbVDFAxis.Size = new System.Drawing.Size(136, 20);
            this.cbVDFAxis.TabIndex = 3;
            this.cbVDFAxis.Text = "Display VDF Axis";
            this.cbVDFAxis.UseVisualStyleBackColor = true;
            this.cbVDFAxis.CheckedChanged += new System.EventHandler(this.cbVDFAxis_CheckedChanged);
            // 
            // rdb3D
            // 
            this.rdb3D.AutoSize = true;
            this.rdb3D.Checked = true;
            this.rdb3D.Location = new System.Drawing.Point(21, 22);
            this.rdb3D.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdb3D.Name = "rdb3D";
            this.rdb3D.Size = new System.Drawing.Size(127, 20);
            this.rdb3D.TabIndex = 2;
            this.rdb3D.TabStop = true;
            this.rdb3D.Text = "Custom 3D Axis";
            this.rdb3D.UseVisualStyleBackColor = true;
            this.rdb3D.CheckedChanged += new System.EventHandler(this.rdb3D_CheckedChanged);
            // 
            // rdbInfo
            // 
            this.rdbInfo.AutoSize = true;
            this.rdbInfo.Location = new System.Drawing.Point(185, 22);
            this.rdbInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbInfo.Name = "rdbInfo";
            this.rdbInfo.Size = new System.Drawing.Size(154, 20);
            this.rdbInfo.TabIndex = 1;
            this.rdbInfo.Text = "Drawing Information";
            this.rdbInfo.UseVisualStyleBackColor = true;
            this.rdbInfo.CheckedChanged += new System.EventHandler(this.rdbInfo_CheckedChanged);
            // 
            // vdFramedControl1
            // 
            this.vdFramedControl1.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.vdFramedControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vdFramedControl1.DisplayPolarCoord = false;
            this.vdFramedControl1.HistoryLines = ((uint)(3u));
            this.vdFramedControl1.Location = new System.Drawing.Point(6, 91);
            this.vdFramedControl1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.vdFramedControl1.Name = "vdFramedControl1";
            this.vdFramedControl1.PropertyGridWidth = ((uint)(300u));
            this.vdFramedControl1.Size = new System.Drawing.Size(904, 597);
            this.vdFramedControl1.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 692);
            this.Controls.Add(this.vdFramedControl1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(814, 605);
            this.Name = "Form1";
            this.Text = "ScreenBlockInfo for C#";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private vdControls.vdFramedControl vdFramedControl1;
        private System.Windows.Forms.CheckBox cbVDFAxis;
        private System.Windows.Forms.RadioButton rdb3D;
        private System.Windows.Forms.RadioButton rdbInfo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRotate3DView;
    }
}

