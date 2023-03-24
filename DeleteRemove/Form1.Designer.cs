namespace DeleteRemove
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
            this.vdFC = new vdControls.vdFramedControl();
            this.btnAddCircle = new System.Windows.Forms.Button();
            this.btnDeleteCircle = new System.Windows.Forms.Button();
            this.btnRemoveCircle = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnRemoveXRef = new System.Windows.Forms.Button();
            this.btnDeleteXRef = new System.Windows.Forms.Button();
            this.btnAddXRef = new System.Windows.Forms.Button();
            this.btnClearMemory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // vdFC
            // 
            this.vdFC.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.vdFC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.vdFC.DisplayPolarCoord = false;
            this.vdFC.HistoryLines = ((uint)(3u));
            this.vdFC.Location = new System.Drawing.Point(2, 1);
            this.vdFC.Name = "vdFC";
            this.vdFC.PropertyGridWidth = ((uint)(300u));
            this.vdFC.Size = new System.Drawing.Size(915, 513);
            this.vdFC.TabIndex = 0;
            // 
            // btnAddCircle
            // 
            this.btnAddCircle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddCircle.Location = new System.Drawing.Point(12, 520);
            this.btnAddCircle.Name = "btnAddCircle";
            this.btnAddCircle.Size = new System.Drawing.Size(117, 25);
            this.btnAddCircle.TabIndex = 1;
            this.btnAddCircle.Text = "Add Circle";
            this.btnAddCircle.UseVisualStyleBackColor = true;
            this.btnAddCircle.Click += new System.EventHandler(this.btnAddCircle_Click);
            // 
            // btnDeleteCircle
            // 
            this.btnDeleteCircle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteCircle.Location = new System.Drawing.Point(135, 520);
            this.btnDeleteCircle.Name = "btnDeleteCircle";
            this.btnDeleteCircle.Size = new System.Drawing.Size(117, 25);
            this.btnDeleteCircle.TabIndex = 2;
            this.btnDeleteCircle.Text = "Delete Circle";
            this.btnDeleteCircle.UseVisualStyleBackColor = true;
            this.btnDeleteCircle.Click += new System.EventHandler(this.btnDeleteCircle_Click);
            // 
            // btnRemoveCircle
            // 
            this.btnRemoveCircle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveCircle.Location = new System.Drawing.Point(258, 520);
            this.btnRemoveCircle.Name = "btnRemoveCircle";
            this.btnRemoveCircle.Size = new System.Drawing.Size(117, 25);
            this.btnRemoveCircle.TabIndex = 3;
            this.btnRemoveCircle.Text = "Remove Circle";
            this.btnRemoveCircle.UseVisualStyleBackColor = true;
            this.btnRemoveCircle.Click += new System.EventHandler(this.btnRemoveCircle_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRedo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRedo.Location = new System.Drawing.Point(544, 556);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(117, 25);
            this.btnRedo.TabIndex = 4;
            this.btnRedo.Text = "Redo >";
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnUndo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUndo.Location = new System.Drawing.Point(258, 556);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(117, 25);
            this.btnUndo.TabIndex = 5;
            this.btnUndo.Text = "< Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRemoveXRef
            // 
            this.btnRemoveXRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveXRef.Location = new System.Drawing.Point(790, 520);
            this.btnRemoveXRef.Name = "btnRemoveXRef";
            this.btnRemoveXRef.Size = new System.Drawing.Size(117, 25);
            this.btnRemoveXRef.TabIndex = 8;
            this.btnRemoveXRef.Text = "Remove XRef";
            this.btnRemoveXRef.UseVisualStyleBackColor = true;
            this.btnRemoveXRef.Click += new System.EventHandler(this.btnRemoveXRef_Click);
            // 
            // btnDeleteXRef
            // 
            this.btnDeleteXRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteXRef.Location = new System.Drawing.Point(667, 520);
            this.btnDeleteXRef.Name = "btnDeleteXRef";
            this.btnDeleteXRef.Size = new System.Drawing.Size(117, 25);
            this.btnDeleteXRef.TabIndex = 7;
            this.btnDeleteXRef.Text = "Delete XRef";
            this.btnDeleteXRef.UseVisualStyleBackColor = true;
            this.btnDeleteXRef.Click += new System.EventHandler(this.btnDeleteXRef_Click);
            // 
            // btnAddXRef
            // 
            this.btnAddXRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddXRef.Location = new System.Drawing.Point(544, 520);
            this.btnAddXRef.Name = "btnAddXRef";
            this.btnAddXRef.Size = new System.Drawing.Size(117, 25);
            this.btnAddXRef.TabIndex = 6;
            this.btnAddXRef.Text = "Add XRef";
            this.btnAddXRef.UseVisualStyleBackColor = true;
            this.btnAddXRef.Click += new System.EventHandler(this.btnAddXRef_Click);
            // 
            // btnClearMemory
            // 
            this.btnClearMemory.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClearMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearMemory.Location = new System.Drawing.Point(381, 556);
            this.btnClearMemory.Name = "btnClearMemory";
            this.btnClearMemory.Size = new System.Drawing.Size(157, 25);
            this.btnClearMemory.TabIndex = 9;
            this.btnClearMemory.Text = "Clear Memory";
            this.btnClearMemory.UseVisualStyleBackColor = true;
            this.btnClearMemory.Click += new System.EventHandler(this.btnClearMemory_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 593);
            this.Controls.Add(this.btnClearMemory);
            this.Controls.Add(this.btnRemoveXRef);
            this.Controls.Add(this.btnDeleteXRef);
            this.Controls.Add(this.btnAddXRef);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.btnRemoveCircle);
            this.Controls.Add(this.btnDeleteCircle);
            this.Controls.Add(this.btnAddCircle);
            this.Controls.Add(this.vdFC);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.Text = "Delete and Remove Objects";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private vdControls.vdFramedControl vdFC;
        private System.Windows.Forms.Button btnAddCircle;
        private System.Windows.Forms.Button btnDeleteCircle;
        private System.Windows.Forms.Button btnRemoveCircle;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRemoveXRef;
        private System.Windows.Forms.Button btnDeleteXRef;
        private System.Windows.Forms.Button btnAddXRef;
        private System.Windows.Forms.Button btnClearMemory;
    }
}

