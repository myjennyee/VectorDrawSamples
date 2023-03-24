namespace UserInteraction
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
            this.vd = new vdControls.vdFramedControl();
            this.butGetPoint = new System.Windows.Forms.Button();
            this.butUserRect = new System.Windows.Forms.Button();
            this.butGetFigure = new System.Windows.Forms.Button();
            this.butGetDistance = new System.Windows.Forms.Button();
            this.butGetAngle = new System.Windows.Forms.Button();
            this.butGetSelection = new System.Windows.Forms.Button();
            this.butAcceptedValues = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // vd
            // 
            this.vd.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.vd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vd.DisplayPolarCoord = false;
            this.vd.Location = new System.Drawing.Point(5, 7);
            this.vd.Name = "vd";
            this.vd.Size = new System.Drawing.Size(831, 539);
            this.vd.TabIndex = 0;
            // 
            // butGetPoint
            // 
            this.butGetPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butGetPoint.Location = new System.Drawing.Point(843, 7);
            this.butGetPoint.Name = "butGetPoint";
            this.butGetPoint.Size = new System.Drawing.Size(108, 25);
            this.butGetPoint.TabIndex = 1;
            this.butGetPoint.Text = "Get Point";
            this.butGetPoint.UseVisualStyleBackColor = true;
            this.butGetPoint.Click += new System.EventHandler(this.butGetPoint_Click);
            // 
            // butUserRect
            // 
            this.butUserRect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butUserRect.Location = new System.Drawing.Point(843, 39);
            this.butUserRect.Name = "butUserRect";
            this.butUserRect.Size = new System.Drawing.Size(108, 25);
            this.butUserRect.TabIndex = 2;
            this.butUserRect.Text = "Get Rect";
            this.butUserRect.UseVisualStyleBackColor = true;
            this.butUserRect.Click += new System.EventHandler(this.butUserRect_Click);
            // 
            // butGetFigure
            // 
            this.butGetFigure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butGetFigure.Location = new System.Drawing.Point(843, 71);
            this.butGetFigure.Name = "butGetFigure";
            this.butGetFigure.Size = new System.Drawing.Size(108, 25);
            this.butGetFigure.TabIndex = 3;
            this.butGetFigure.Text = "Get Figure";
            this.butGetFigure.UseVisualStyleBackColor = true;
            this.butGetFigure.Click += new System.EventHandler(this.butGetFigure_Click);
            // 
            // butGetDistance
            // 
            this.butGetDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butGetDistance.Location = new System.Drawing.Point(843, 103);
            this.butGetDistance.Name = "butGetDistance";
            this.butGetDistance.Size = new System.Drawing.Size(108, 25);
            this.butGetDistance.TabIndex = 4;
            this.butGetDistance.Text = "Get Distance";
            this.butGetDistance.UseVisualStyleBackColor = true;
            this.butGetDistance.Click += new System.EventHandler(this.butGetDistance_Click);
            // 
            // butGetAngle
            // 
            this.butGetAngle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butGetAngle.Location = new System.Drawing.Point(843, 135);
            this.butGetAngle.Name = "butGetAngle";
            this.butGetAngle.Size = new System.Drawing.Size(108, 25);
            this.butGetAngle.TabIndex = 5;
            this.butGetAngle.Text = "Get Angle";
            this.butGetAngle.UseVisualStyleBackColor = true;
            this.butGetAngle.Click += new System.EventHandler(this.butGetAngle_Click);
            // 
            // butGetSelection
            // 
            this.butGetSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butGetSelection.Location = new System.Drawing.Point(843, 167);
            this.butGetSelection.Name = "butGetSelection";
            this.butGetSelection.Size = new System.Drawing.Size(108, 25);
            this.butGetSelection.TabIndex = 6;
            this.butGetSelection.Text = "Get Selection";
            this.butGetSelection.UseVisualStyleBackColor = true;
            this.butGetSelection.Click += new System.EventHandler(this.butGetSelection_Click);
            // 
            // butAcceptedValues
            // 
            this.butAcceptedValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butAcceptedValues.Location = new System.Drawing.Point(843, 198);
            this.butAcceptedValues.Name = "butAcceptedValues";
            this.butAcceptedValues.Size = new System.Drawing.Size(108, 36);
            this.butAcceptedValues.TabIndex = 7;
            this.butAcceptedValues.Text = "User Accepted Values";
            this.butAcceptedValues.UseVisualStyleBackColor = true;
            this.butAcceptedValues.Click += new System.EventHandler(this.butAcceptedValues_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 558);
            this.Controls.Add(this.butAcceptedValues);
            this.Controls.Add(this.butGetSelection);
            this.Controls.Add(this.butGetAngle);
            this.Controls.Add(this.butGetDistance);
            this.Controls.Add(this.butGetFigure);
            this.Controls.Add(this.butUserRect);
            this.Controls.Add(this.butGetPoint);
            this.Controls.Add(this.vd);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private vdControls.vdFramedControl vd;
        private System.Windows.Forms.Button butGetPoint;
        private System.Windows.Forms.Button butUserRect;
        private System.Windows.Forms.Button butGetFigure;
        private System.Windows.Forms.Button butGetDistance;
        private System.Windows.Forms.Button butGetAngle;
        private System.Windows.Forms.Button butGetSelection;
        private System.Windows.Forms.Button butAcceptedValues;
    }
}

