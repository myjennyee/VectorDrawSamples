namespace AddEntities
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
            this.vdFramedControl = new vdControls.vdFramedControl();
            this.butLine = new System.Windows.Forms.Button();
            this.butNew = new System.Windows.Forms.Button();
            this.butCircle = new System.Windows.Forms.Button();
            this.butEllipse = new System.Windows.Forms.Button();
            this.butRect = new System.Windows.Forms.Button();
            this.butText = new System.Windows.Forms.Button();
            this.butArc = new System.Windows.Forms.Button();
            this.butPoint = new System.Windows.Forms.Button();
            this.butPolyline = new System.Windows.Forms.Button();
            this.butImage = new System.Windows.Forms.Button();
            this.butDims = new System.Windows.Forms.Button();
            this.butInserts = new System.Windows.Forms.Button();
            this.butSpline = new System.Windows.Forms.Button();
            this.buthatch = new System.Windows.Forms.Button();
            this.butMtext = new System.Windows.Forms.Button();
            this.butSurf = new System.Windows.Forms.Button();
            this.but3dobjects = new System.Windows.Forms.Button();
            this.checkRot = new System.Windows.Forms.CheckBox();
            this.butLeader = new System.Windows.Forms.Button();
            this.butConstructionLines = new System.Windows.Forms.Button();
            this.butMultiline = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // vdFramedControl
            // 
            this.vdFramedControl.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.vdFramedControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vdFramedControl.DisplayPolarCoord = false;
            this.vdFramedControl.HistoryLines = ((uint)(3u));
            this.vdFramedControl.Location = new System.Drawing.Point(0, -2);
            this.vdFramedControl.Name = "vdFramedControl";
            this.vdFramedControl.PropertyGridWidth = ((uint)(300u));
            this.vdFramedControl.Size = new System.Drawing.Size(744, 733);
            this.vdFramedControl.TabIndex = 0;
            // 
            // butLine
            // 
            this.butLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butLine.Location = new System.Drawing.Point(750, 40);
            this.butLine.Name = "butLine";
            this.butLine.Size = new System.Drawing.Size(93, 23);
            this.butLine.TabIndex = 1;
            this.butLine.Text = "Add Line";
            this.butLine.UseVisualStyleBackColor = true;
            this.butLine.Click += new System.EventHandler(this.butLine_Click);
            // 
            // butNew
            // 
            this.butNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butNew.Location = new System.Drawing.Point(750, 12);
            this.butNew.Name = "butNew";
            this.butNew.Size = new System.Drawing.Size(93, 23);
            this.butNew.TabIndex = 2;
            this.butNew.Text = "New Document";
            this.butNew.UseVisualStyleBackColor = true;
            this.butNew.Click += new System.EventHandler(this.butNew_Click);
            // 
            // butCircle
            // 
            this.butCircle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butCircle.Location = new System.Drawing.Point(750, 69);
            this.butCircle.Name = "butCircle";
            this.butCircle.Size = new System.Drawing.Size(93, 23);
            this.butCircle.TabIndex = 3;
            this.butCircle.Text = "Add Circle";
            this.butCircle.UseVisualStyleBackColor = true;
            this.butCircle.Click += new System.EventHandler(this.butCircle_Click);
            // 
            // butEllipse
            // 
            this.butEllipse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butEllipse.Location = new System.Drawing.Point(750, 98);
            this.butEllipse.Name = "butEllipse";
            this.butEllipse.Size = new System.Drawing.Size(93, 23);
            this.butEllipse.TabIndex = 4;
            this.butEllipse.Text = "Add Ellipse";
            this.butEllipse.UseVisualStyleBackColor = true;
            this.butEllipse.Click += new System.EventHandler(this.butEllipse_Click);
            // 
            // butRect
            // 
            this.butRect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butRect.Location = new System.Drawing.Point(750, 158);
            this.butRect.Name = "butRect";
            this.butRect.Size = new System.Drawing.Size(93, 23);
            this.butRect.TabIndex = 5;
            this.butRect.Text = "Add Rect";
            this.butRect.UseVisualStyleBackColor = true;
            this.butRect.Click += new System.EventHandler(this.butRect_Click);
            // 
            // butText
            // 
            this.butText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butText.Location = new System.Drawing.Point(750, 187);
            this.butText.Name = "butText";
            this.butText.Size = new System.Drawing.Size(93, 23);
            this.butText.TabIndex = 6;
            this.butText.Text = "Add Text";
            this.butText.UseVisualStyleBackColor = true;
            this.butText.Click += new System.EventHandler(this.butText_Click);
            // 
            // butArc
            // 
            this.butArc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butArc.Location = new System.Drawing.Point(750, 129);
            this.butArc.Name = "butArc";
            this.butArc.Size = new System.Drawing.Size(93, 23);
            this.butArc.TabIndex = 7;
            this.butArc.Text = "Add Arc";
            this.butArc.UseVisualStyleBackColor = true;
            this.butArc.Click += new System.EventHandler(this.butArc_Click);
            // 
            // butPoint
            // 
            this.butPoint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPoint.Location = new System.Drawing.Point(750, 216);
            this.butPoint.Name = "butPoint";
            this.butPoint.Size = new System.Drawing.Size(93, 23);
            this.butPoint.TabIndex = 8;
            this.butPoint.Text = "Add Point";
            this.butPoint.UseVisualStyleBackColor = true;
            this.butPoint.Click += new System.EventHandler(this.butPoint_Click);
            // 
            // butPolyline
            // 
            this.butPolyline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butPolyline.Location = new System.Drawing.Point(750, 345);
            this.butPolyline.Name = "butPolyline";
            this.butPolyline.Size = new System.Drawing.Size(93, 38);
            this.butPolyline.TabIndex = 9;
            this.butPolyline.Text = "Add Polyline with Bulges";
            this.butPolyline.UseVisualStyleBackColor = true;
            this.butPolyline.Click += new System.EventHandler(this.butPolyline_Click);
            // 
            // butImage
            // 
            this.butImage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butImage.Location = new System.Drawing.Point(750, 245);
            this.butImage.Name = "butImage";
            this.butImage.Size = new System.Drawing.Size(93, 23);
            this.butImage.TabIndex = 10;
            this.butImage.Text = "Add Image";
            this.butImage.UseVisualStyleBackColor = true;
            this.butImage.Click += new System.EventHandler(this.butImage_Click);
            // 
            // butDims
            // 
            this.butDims.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butDims.Location = new System.Drawing.Point(750, 274);
            this.butDims.Name = "butDims";
            this.butDims.Size = new System.Drawing.Size(93, 23);
            this.butDims.TabIndex = 11;
            this.butDims.Text = "Add Dimensions";
            this.butDims.UseVisualStyleBackColor = true;
            this.butDims.Click += new System.EventHandler(this.butDims_Click);
            // 
            // butInserts
            // 
            this.butInserts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butInserts.Location = new System.Drawing.Point(750, 303);
            this.butInserts.Name = "butInserts";
            this.butInserts.Size = new System.Drawing.Size(93, 36);
            this.butInserts.TabIndex = 12;
            this.butInserts.Text = "Add Block && Inserts";
            this.butInserts.UseVisualStyleBackColor = true;
            this.butInserts.Click += new System.EventHandler(this.butInserts_Click);
            // 
            // butSpline
            // 
            this.butSpline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSpline.Location = new System.Drawing.Point(750, 389);
            this.butSpline.Name = "butSpline";
            this.butSpline.Size = new System.Drawing.Size(93, 36);
            this.butSpline.TabIndex = 13;
            this.butSpline.Text = "Add Spline with hatch properties";
            this.butSpline.UseVisualStyleBackColor = true;
            this.butSpline.Click += new System.EventHandler(this.butSpline_Click);
            // 
            // buthatch
            // 
            this.buthatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buthatch.Location = new System.Drawing.Point(750, 460);
            this.buthatch.Name = "buthatch";
            this.buthatch.Size = new System.Drawing.Size(93, 27);
            this.buthatch.TabIndex = 14;
            this.buthatch.Text = "Add Polyhatch";
            this.buthatch.UseVisualStyleBackColor = true;
            this.buthatch.Click += new System.EventHandler(this.buthatch_Click);
            // 
            // butMtext
            // 
            this.butMtext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butMtext.Location = new System.Drawing.Point(750, 493);
            this.butMtext.Name = "butMtext";
            this.butMtext.Size = new System.Drawing.Size(93, 24);
            this.butMtext.TabIndex = 15;
            this.butMtext.Text = "Add MText";
            this.butMtext.UseVisualStyleBackColor = true;
            this.butMtext.Click += new System.EventHandler(this.butMtext_Click);
            // 
            // butSurf
            // 
            this.butSurf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butSurf.Location = new System.Drawing.Point(750, 634);
            this.butSurf.Name = "butSurf";
            this.butSurf.Size = new System.Drawing.Size(93, 34);
            this.butSurf.TabIndex = 16;
            this.butSurf.Text = "Add GroundSurface";
            this.butSurf.UseVisualStyleBackColor = true;
            this.butSurf.Click += new System.EventHandler(this.butSurf_Click);
            // 
            // but3dobjects
            // 
            this.but3dobjects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but3dobjects.Location = new System.Drawing.Point(750, 550);
            this.but3dobjects.Name = "but3dobjects";
            this.but3dobjects.Size = new System.Drawing.Size(93, 27);
            this.but3dobjects.TabIndex = 17;
            this.but3dobjects.Text = "Add 3D objects";
            this.but3dobjects.UseVisualStyleBackColor = true;
            this.but3dobjects.Click += new System.EventHandler(this.but3dobjects_Click);
            // 
            // checkRot
            // 
            this.checkRot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkRot.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkRot.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkRot.Location = new System.Drawing.Point(750, 708);
            this.checkRot.Name = "checkRot";
            this.checkRot.Size = new System.Drawing.Size(93, 23);
            this.checkRot.TabIndex = 18;
            this.checkRot.Text = "Rotate Scene";
            this.checkRot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkRot.UseVisualStyleBackColor = true;
            this.checkRot.CheckedChanged += new System.EventHandler(this.checkRot_CheckedChanged);
            // 
            // butLeader
            // 
            this.butLeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butLeader.Location = new System.Drawing.Point(750, 523);
            this.butLeader.Name = "butLeader";
            this.butLeader.Size = new System.Drawing.Size(93, 24);
            this.butLeader.TabIndex = 19;
            this.butLeader.Text = "Add Leader";
            this.butLeader.UseVisualStyleBackColor = true;
            this.butLeader.Click += new System.EventHandler(this.butLeader_Click);
            // 
            // butConstructionLines
            // 
            this.butConstructionLines.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butConstructionLines.Location = new System.Drawing.Point(750, 582);
            this.butConstructionLines.Name = "butConstructionLines";
            this.butConstructionLines.Size = new System.Drawing.Size(93, 47);
            this.butConstructionLines.TabIndex = 20;
            this.butConstructionLines.Text = "Add Construction Lines";
            this.butConstructionLines.UseVisualStyleBackColor = true;
            this.butConstructionLines.Click += new System.EventHandler(this.butConstructionLines_Click);
            // 
            // butMultiline
            // 
            this.butMultiline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butMultiline.Location = new System.Drawing.Point(750, 431);
            this.butMultiline.Name = "butMultiline";
            this.butMultiline.Size = new System.Drawing.Size(93, 23);
            this.butMultiline.TabIndex = 21;
            this.butMultiline.Text = "Add Multiline";
            this.butMultiline.UseVisualStyleBackColor = true;
            this.butMultiline.Click += new System.EventHandler(this.butMultiline_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 743);
            this.Controls.Add(this.butMultiline);
            this.Controls.Add(this.butConstructionLines);
            this.Controls.Add(this.butLeader);
            this.Controls.Add(this.checkRot);
            this.Controls.Add(this.but3dobjects);
            this.Controls.Add(this.butSurf);
            this.Controls.Add(this.butMtext);
            this.Controls.Add(this.buthatch);
            this.Controls.Add(this.butSpline);
            this.Controls.Add(this.butInserts);
            this.Controls.Add(this.butDims);
            this.Controls.Add(this.butImage);
            this.Controls.Add(this.butPolyline);
            this.Controls.Add(this.butPoint);
            this.Controls.Add(this.butArc);
            this.Controls.Add(this.butText);
            this.Controls.Add(this.butRect);
            this.Controls.Add(this.butEllipse);
            this.Controls.Add(this.butCircle);
            this.Controls.Add(this.butNew);
            this.Controls.Add(this.butLine);
            this.Controls.Add(this.vdFramedControl);
            this.Name = "Form1";
            this.Text = "Add Entities";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private vdControls.vdFramedControl vdFramedControl;
        private System.Windows.Forms.Button butLine;
        private System.Windows.Forms.Button butNew;
        private System.Windows.Forms.Button butCircle;
        private System.Windows.Forms.Button butEllipse;
        private System.Windows.Forms.Button butRect;
        private System.Windows.Forms.Button butText;
        private System.Windows.Forms.Button butArc;
        private System.Windows.Forms.Button butPoint;
        private System.Windows.Forms.Button butPolyline;
        private System.Windows.Forms.Button butImage;
        private System.Windows.Forms.Button butDims;
        private System.Windows.Forms.Button butInserts;
        private System.Windows.Forms.Button butSpline;
        private System.Windows.Forms.Button buthatch;
        private System.Windows.Forms.Button butMtext;
        private System.Windows.Forms.Button butSurf;
        private System.Windows.Forms.Button but3dobjects;
        private System.Windows.Forms.CheckBox checkRot;
        private System.Windows.Forms.Button butLeader;
        private System.Windows.Forms.Button butConstructionLines;
        private System.Windows.Forms.Button butMultiline;
    }
}

