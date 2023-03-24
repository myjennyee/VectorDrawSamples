namespace Ruler_Magnifier
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
            this.butMagnifier = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rulerProps = new System.Windows.Forms.PropertyGrid();
            this.Ruler_Properties = new System.Windows.Forms.GroupBox();
            this.btRuler = new System.Windows.Forms.Button();
            this.Ruler_Properties.SuspendLayout();
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
            this.vdFramedControl1.Location = new System.Drawing.Point(4, 8);
            this.vdFramedControl1.Name = "vdFramedControl1";
            this.vdFramedControl1.PropertyGridWidth = ((uint)(300u));
            this.vdFramedControl1.Size = new System.Drawing.Size(902, 515);
            this.vdFramedControl1.TabIndex = 0;
            // 
            // butMagnifier
            // 
            this.butMagnifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butMagnifier.Location = new System.Drawing.Point(912, 12);
            this.butMagnifier.Name = "butMagnifier";
            this.butMagnifier.Size = new System.Drawing.Size(87, 28);
            this.butMagnifier.TabIndex = 2;
            this.butMagnifier.Text = "Magnifier Glass";
            this.butMagnifier.UseVisualStyleBackColor = true;
            this.butMagnifier.Click += new System.EventHandler(this.butMagnifier_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(396, 535);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Magnifier Glass can be used to quick select a point in a drawing without zooming " +
                "or use oSnap points. Press the Shift Key(once) which enables and disables this f" +
                "eature.";
            // 
            // rulerProps
            // 
            this.rulerProps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rulerProps.Location = new System.Drawing.Point(3, 16);
            this.rulerProps.Name = "rulerProps";
            this.rulerProps.Size = new System.Drawing.Size(270, 422);
            this.rulerProps.TabIndex = 6;
            // 
            // Ruler_Properties
            // 
            this.Ruler_Properties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Ruler_Properties.Controls.Add(this.rulerProps);
            this.Ruler_Properties.Location = new System.Drawing.Point(912, 82);
            this.Ruler_Properties.Name = "Ruler_Properties";
            this.Ruler_Properties.Size = new System.Drawing.Size(276, 441);
            this.Ruler_Properties.TabIndex = 8;
            this.Ruler_Properties.TabStop = false;
            this.Ruler_Properties.Text = "Ruler Properties";
            // 
            // btRuler
            // 
            this.btRuler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRuler.Location = new System.Drawing.Point(1013, 12);
            this.btRuler.Name = "btRuler";
            this.btRuler.Size = new System.Drawing.Size(113, 27);
            this.btRuler.TabIndex = 9;
            this.btRuler.Text = "Ruler On/Off";
            this.btRuler.UseVisualStyleBackColor = true;
            this.btRuler.Click += new System.EventHandler(this.btRuler_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 557);
            this.Controls.Add(this.btRuler);
            this.Controls.Add(this.Ruler_Properties);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butMagnifier);
            this.Controls.Add(this.vdFramedControl1);
            this.MinimumSize = new System.Drawing.Size(807, 451);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Ruler_Properties.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private vdControls.vdFramedControl vdFramedControl1;
        private System.Windows.Forms.Button butMagnifier;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PropertyGrid rulerProps;
        private System.Windows.Forms.GroupBox Ruler_Properties;
        private System.Windows.Forms.Button btRuler;

    }
}

