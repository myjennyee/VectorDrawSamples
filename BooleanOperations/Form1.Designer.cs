namespace BooleanOperations
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonRevSubstraction = new System.Windows.Forms.Button();
            this.buttonIntersection = new System.Windows.Forms.Button();
            this.buttonSubstract = new System.Windows.Forms.Button();
            this.buttonUnion = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.vdraw = new VectorDraw.Professional.Control.VectorDrawBaseControl();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonRevSubstraction);
            this.panel1.Controls.Add(this.buttonIntersection);
            this.panel1.Controls.Add(this.buttonSubstract);
            this.panel1.Controls.Add(this.buttonUnion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(993, 56);
            this.panel1.TabIndex = 0;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.buttonCancel.Image = global::BooleanOperations.Properties.Resources.delete;
            this.buttonCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancel.Location = new System.Drawing.Point(615, 8);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(78, 40);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Reset";
            this.buttonCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonRevSubstraction
            // 
            this.buttonRevSubstraction.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonRevSubstraction.Enabled = false;
            this.buttonRevSubstraction.Image = global::BooleanOperations.Properties.Resources.RevSubctraction;
            this.buttonRevSubstraction.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonRevSubstraction.Location = new System.Drawing.Point(437, 4);
            this.buttonRevSubstraction.Name = "buttonRevSubstraction";
            this.buttonRevSubstraction.Size = new System.Drawing.Size(95, 47);
            this.buttonRevSubstraction.TabIndex = 3;
            this.buttonRevSubstraction.Text = "Rev-substraction";
            this.buttonRevSubstraction.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonRevSubstraction.UseVisualStyleBackColor = true;
            this.buttonRevSubstraction.Click += new System.EventHandler(this.buttonRevSubstraction_Click);
            // 
            // buttonIntersection
            // 
            this.buttonIntersection.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonIntersection.Enabled = false;
            this.buttonIntersection.Image = global::BooleanOperations.Properties.Resources.Intersection;
            this.buttonIntersection.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonIntersection.Location = new System.Drawing.Point(538, 5);
            this.buttonIntersection.Name = "buttonIntersection";
            this.buttonIntersection.Size = new System.Drawing.Size(71, 47);
            this.buttonIntersection.TabIndex = 2;
            this.buttonIntersection.Text = "Intersection";
            this.buttonIntersection.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonIntersection.UseVisualStyleBackColor = true;
            this.buttonIntersection.Click += new System.EventHandler(this.buttonIntersection_Click);
            // 
            // buttonSubstract
            // 
            this.buttonSubstract.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonSubstract.Enabled = false;
            this.buttonSubstract.Image = global::BooleanOperations.Properties.Resources.Subctraction;
            this.buttonSubstract.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonSubstract.Location = new System.Drawing.Point(355, 4);
            this.buttonSubstract.Name = "buttonSubstract";
            this.buttonSubstract.Size = new System.Drawing.Size(76, 47);
            this.buttonSubstract.TabIndex = 1;
            this.buttonSubstract.Text = "Substraction";
            this.buttonSubstract.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSubstract.UseVisualStyleBackColor = true;
            this.buttonSubstract.Click += new System.EventHandler(this.buttonSubstract_Click);
            // 
            // buttonUnion
            // 
            this.buttonUnion.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonUnion.Enabled = false;
            this.buttonUnion.Image = global::BooleanOperations.Properties.Resources.Union;
            this.buttonUnion.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonUnion.Location = new System.Drawing.Point(299, 4);
            this.buttonUnion.Name = "buttonUnion";
            this.buttonUnion.Size = new System.Drawing.Size(50, 47);
            this.buttonUnion.TabIndex = 0;
            this.buttonUnion.Text = "Union";
            this.buttonUnion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonUnion.UseVisualStyleBackColor = true;
            this.buttonUnion.Click += new System.EventHandler(this.buttonUnion_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.vdraw);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(993, 566);
            this.panel2.TabIndex = 1;
            // 
            // vdFramedControl1
            // 
            this.vdraw.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.vdraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vdraw.Location = new System.Drawing.Point(0, 0);
            this.vdraw.Name = "vdFramedControl1";
            this.vdraw.Size = new System.Drawing.Size(993, 566);
            this.vdraw.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 622);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Boolean Operations";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private VectorDraw.Professional.Control.VectorDrawBaseControl vdraw;
        private System.Windows.Forms.Button buttonUnion;
        private System.Windows.Forms.Button buttonRevSubstraction;
        private System.Windows.Forms.Button buttonIntersection;
        private System.Windows.Forms.Button buttonSubstract;
        private System.Windows.Forms.Button buttonCancel;
    }
}

