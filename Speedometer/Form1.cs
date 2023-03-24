using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VectorDraw.Professional.vdCollections;
using VectorDraw.Professional.vdObjects;
using VectorDraw.Professional.vdPrimaries;
using VectorDraw.Professional.vdFigures;
using VectorDraw.Geometry;

// Description : 
// This is a simple sample demonstrating another aspect of our control.
// A speedometer is created using code and then the speed is increased to show a different progress bar from 0 to 100 count.

namespace Speedometer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region Initialize Form
        private void Form1_Load(object sender, EventArgs e)
        {
            vectorDrawBaseControl1.ActiveDocument.ShowUCSAxis = false;
            vectorDrawBaseControl1.ActiveDocument.EnableAutoGripOn = false;
            vectorDrawBaseControl1.ActiveDocument.MouseWheelZoomScale = 1.0;
            this.vectorDrawBaseControl1.ActionStart += new VectorDraw.Professional.Control.ActionStartEventHandler(vectorDrawBaseControl1_ActionStart);
            this.vectorDrawBaseControl1.vdMouseEnter += new VectorDraw.Professional.Control.MouseEnterEventHandler(vectorDrawBaseControl1_vdMouseEnter);
            comboSpeed.SelectedIndex = 1;
            DrawScene();
        }
        void vectorDrawBaseControl1_vdMouseEnter(EventArgs e, ref bool cancel)
        {
            vectorDrawBaseControl1.SetCustomMousePointer(System.Windows.Forms.Cursors.No);
        }
        void vectorDrawBaseControl1_ActionStart(object sender, string actionName, ref bool cancel)
        {
            if (actionName == "BaseAction_ActionPan") cancel = true;
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.vectorDrawBaseControl1.ActionStart -= new VectorDraw.Professional.Control.ActionStartEventHandler(vectorDrawBaseControl1_ActionStart);
            this.vectorDrawBaseControl1.vdMouseEnter -= new VectorDraw.Professional.Control.MouseEnterEventHandler(vectorDrawBaseControl1_vdMouseEnter);
        }
        #endregion

        #region DrawScene
        vdLine xLine = null;
        vdText xText = null;
        private void DrawScene()
        {
            vectorDrawBaseControl1.ActiveDocument.New();

            //Draw scene
            vdCircle circle = new vdCircle();
            circle.SetUnRegisterDocument(vectorDrawBaseControl1.ActiveDocument);
            circle.setDocumentDefaults();
            circle.HatchProperties = new vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
            circle.HatchProperties.FillColor.ColorIndex = 3;
            circle.HatchProperties.gradientTypeProp = VectorDraw.Render.vdGdiPenStyle.GradientType.LinearInverted;
            circle.HatchProperties.gradientColor2.FromRGB(56, 151, 198);
            circle.HatchProperties.gradientAngle = VectorDraw.Geometry.Globals.DegreesToRadians(90.0);
            circle.Radius = 20.0;
            circle.PenColor.ColorIndex = 3;
            vectorDrawBaseControl1.ActiveDocument.Model.Entities.AddItem(circle);

            circle = new vdCircle();
            circle.SetUnRegisterDocument(vectorDrawBaseControl1.ActiveDocument);
            circle.setDocumentDefaults();
            circle.HatchProperties = new vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
            circle.HatchProperties.FillColor.ColorIndex = 249;
            circle.Radius = 2.5;
            circle.PenColor.ColorIndex = 249;
            vectorDrawBaseControl1.ActiveDocument.Model.Entities.AddItem(circle);

            circle = new vdCircle();
            circle.SetUnRegisterDocument(vectorDrawBaseControl1.ActiveDocument);
            circle.setDocumentDefaults();
            circle.HatchProperties = new vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
            circle.HatchProperties.FillColor.ColorIndex = 0;
            circle.Radius = 1.0;
            circle.PenColor.ColorIndex = 0;
            vectorDrawBaseControl1.ActiveDocument.Model.Entities.AddItem(circle);

            bool Large = true;
            double txtStr = 100.0;
            for (double i = 0.0; i <= 220.0; i += 22.0)
            {
                vdLine Line = new vdLine();
                Line.SetUnRegisterDocument(vectorDrawBaseControl1.ActiveDocument);
                Line.setDocumentDefaults();
                if (Large) Line.StartPoint = gPoint.Polar(new gPoint(), VectorDraw.Geometry.Globals.DegreesToRadians(i), 15.5);
                else Line.StartPoint = gPoint.Polar(new gPoint(), VectorDraw.Geometry.Globals.DegreesToRadians(i), 18.5);
                Line.EndPoint = gPoint.Polar(new gPoint(), VectorDraw.Geometry.Globals.DegreesToRadians(i), 19.0);
                Line.LineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_211;
                vectorDrawBaseControl1.ActiveDocument.Model.Entities.AddItem(Line);

                if (Large)
                {
                    vdText txt = new vdText();
                    txt.SetUnRegisterDocument(vectorDrawBaseControl1.ActiveDocument);
                    txt.setDocumentDefaults();
                    txt.InsertionPoint = gPoint.Polar(new gPoint(), VectorDraw.Geometry.Globals.DegreesToRadians(i), 12.0);
                    txt.TextString = txtStr.ToString();
                    txt.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter;
                    txt.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen;
                    txt.Height = 2.5;
                    vectorDrawBaseControl1.ActiveDocument.Model.Entities.AddItem(txt);
                    txtStr -= 20.0;
                }
                Large = !Large;
            }

            vdLine Line1 = new vdLine();
            Line1.SetUnRegisterDocument(vectorDrawBaseControl1.ActiveDocument);
            Line1.setDocumentDefaults();
            Line1.StartPoint = new gPoint();
            Line1.EndPoint = gPoint.Polar(new gPoint(), VectorDraw.Geometry.Globals.DegreesToRadians(220.0), 17.5);
            Line1.PenWidth = 0.7;
            Line1.PenColor.ColorIndex = 0;
            vectorDrawBaseControl1.ActiveDocument.Model.Entities.AddItem(Line1);
            xLine = Line1;

            vdRect rect = new vdRect();
            rect.SetUnRegisterDocument(vectorDrawBaseControl1.ActiveDocument);
            rect.setDocumentDefaults();
            rect.HatchProperties = new vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
            rect.HatchProperties.FillColor.ColorIndex = 249;
            rect.PenColor.ColorIndex = 249;
            rect.InsertionPoint = new gPoint(2.0, -12.0, 0.0);
            rect.Height = 7.0;
            rect.Width = 11.0;
            vectorDrawBaseControl1.ActiveDocument.Model.Entities.AddItem(rect);

            vdText txt1 = new vdText();
            txt1.SetUnRegisterDocument(vectorDrawBaseControl1.ActiveDocument);
            txt1.setDocumentDefaults();
            txt1.InsertionPoint = new gPoint(4.0, -9.0, 0.0);
            txt1.TextString = "0";
            txt1.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorLeft;
            txt1.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen;
            txt1.Height = 4.5;
            vectorDrawBaseControl1.ActiveDocument.Model.Entities.AddItem(txt1);
            xText = txt1;

            vectorDrawBaseControl1.ActiveDocument.ZoomExtents();
        }
        private void SetScene(int value)
        {
            if (vectorDrawBaseControl1.ActiveDocument == null) return;
            int val = value;
            xText.TextString = val.ToString();
            xText.Update();
            xText.Invalidate();

            Random rnd = new Random();
            int rndint = rnd.Next(0, 6);
            if (val == 100) rndint = 0;
            xLine.EndPoint = gPoint.Polar(new gPoint(), VectorDraw.Geometry.Globals.DegreesToRadians(220.0 - (2.2 * val + rndint)), 17.5);
            xLine.Update();
            vectorDrawBaseControl1.ActiveDocument.Redraw(true);
        }
        #endregion

        #region Button code
        private void butStart_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            switch (comboSpeed.SelectedIndex)
            {
                case 0: progressBar1.Maximum = 100; break;
                case 1: progressBar1.Maximum = 1000; break;
                case 2: progressBar1.Maximum = 10000; break;
            }

            for (int i = 0; i <= progressBar1.Maximum; i++)
            {
                SetScene(i / (progressBar1.Maximum / 100));
                progressBar1.Increment(1);
                if (i == progressBar1.Maximum)
                {
                    progressBar1.Value = progressBar1.Maximum;
                    progressBar1.Value = progressBar1.Maximum - 1;
                    progressBar1.Value = progressBar1.Maximum;
                }
                Application.DoEvents();
            }
        }
        #endregion

        
    }
}