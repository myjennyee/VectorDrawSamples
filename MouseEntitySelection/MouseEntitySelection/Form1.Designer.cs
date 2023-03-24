namespace MouseEntitySelection
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
            this.vdFramedControl1 = new vdControls.vdFramedControl();
            this.radioDefaultvdImplementation = new System.Windows.Forms.RadioButton();
            this.radioOneByΟne = new System.Windows.Forms.RadioButton();
            this.radioMultipleSelect = new System.Windows.Forms.RadioButton();
            this.radioSelectParticularEntities = new System.Windows.Forms.RadioButton();
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
            this.vdFramedControl1.Location = new System.Drawing.Point(4, 35);
            this.vdFramedControl1.Name = "vdFramedControl1";
            this.vdFramedControl1.PropertyGridWidth = ((uint)(300u));
            this.vdFramedControl1.Size = new System.Drawing.Size(766, 330);
            this.vdFramedControl1.TabIndex = 0;
            // 
            // radioDefaultvdImplementation
            // 
            this.radioDefaultvdImplementation.AutoSize = true;
            this.radioDefaultvdImplementation.Checked = true;
            this.radioDefaultvdImplementation.Location = new System.Drawing.Point(4, 12);
            this.radioDefaultvdImplementation.Name = "radioDefaultvdImplementation";
            this.radioDefaultvdImplementation.Size = new System.Drawing.Size(192, 17);
            this.radioDefaultvdImplementation.TabIndex = 1;
            this.radioDefaultvdImplementation.TabStop = true;
            this.radioDefaultvdImplementation.Text = "Default VectorDraw Implementation";
            this.radioDefaultvdImplementation.UseVisualStyleBackColor = true;
            this.radioDefaultvdImplementation.CheckedChanged += new System.EventHandler(this.radioDefaultvdImplementation_CheckedChanged);
            // 
            // radioOneByΟne
            // 
            this.radioOneByΟne.AutoSize = true;
            this.radioOneByΟne.Location = new System.Drawing.Point(202, 12);
            this.radioOneByΟne.Name = "radioOneByΟne";
            this.radioOneByΟne.Size = new System.Drawing.Size(145, 17);
            this.radioOneByΟne.TabIndex = 2;
            this.radioOneByΟne.Text = "Select One By One Entity";
            this.radioOneByΟne.UseVisualStyleBackColor = true;
            this.radioOneByΟne.CheckedChanged += new System.EventHandler(this.radioOneByΟne_CheckedChanged);
            // 
            // radioMultipleSelect
            // 
            this.radioMultipleSelect.AutoSize = true;
            this.radioMultipleSelect.Location = new System.Drawing.Point(353, 12);
            this.radioMultipleSelect.Name = "radioMultipleSelect";
            this.radioMultipleSelect.Size = new System.Drawing.Size(130, 17);
            this.radioMultipleSelect.TabIndex = 3;
            this.radioMultipleSelect.TabStop = true;
            this.radioMultipleSelect.Text = "Select Multiple entities";
            this.radioMultipleSelect.UseVisualStyleBackColor = true;
            this.radioMultipleSelect.CheckedChanged += new System.EventHandler(this.radioMultipleSelect_CheckedChanged);
            // 
            // radioSelectParticularEntities
            // 
            this.radioSelectParticularEntities.AutoSize = true;
            this.radioSelectParticularEntities.Location = new System.Drawing.Point(489, 12);
            this.radioSelectParticularEntities.Name = "radioSelectParticularEntities";
            this.radioSelectParticularEntities.Size = new System.Drawing.Size(294, 17);
            this.radioSelectParticularEntities.TabIndex = 4;
            this.radioSelectParticularEntities.TabStop = true;
            this.radioSelectParticularEntities.Text = "Select only Specific Layer Entities (Layer : \"Select\"(Red))";
            this.radioSelectParticularEntities.UseVisualStyleBackColor = true;
            this.radioSelectParticularEntities.CheckedChanged += new System.EventHandler(this.radioSelectParticularEntities_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 377);
            this.Controls.Add(this.radioSelectParticularEntities);
            this.Controls.Add(this.radioMultipleSelect);
            this.Controls.Add(this.radioOneByΟne);
            this.Controls.Add(this.radioDefaultvdImplementation);
            this.Controls.Add(this.vdFramedControl1);
            this.MinimumSize = new System.Drawing.Size(790, 404);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private vdControls.vdFramedControl vdFramedControl1;
        private System.Windows.Forms.RadioButton radioDefaultvdImplementation;
        private System.Windows.Forms.RadioButton radioOneByΟne;
        private System.Windows.Forms.RadioButton radioMultipleSelect;
        private System.Windows.Forms.RadioButton radioSelectParticularEntities;

    }
}

