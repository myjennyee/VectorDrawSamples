using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AddEntities
{
    public partial class Form2 : Form
    {
        private VectorDraw.Geometry.DoubleArray contours = new VectorDraw.Geometry.DoubleArray();
        private double MaxCountour = 0.0;
        private double MinCountour = 0.0;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            vdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.CommandLine, false);
            vdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.LayoutTab, false);
            vdFramedControl1.UnLoadMenu();
            contours.RemoveAll();
            labContours.Text = contours.Count.ToString() + " contours active";
            radioequasion1.Checked = true;
            vdFramedControl1.BaseControl.ActiveDocument.ShowUCSAxis = false;
        }
       
        
        #region Equasions
        private VectorDraw.Geometry.gPoints Equasion1()
        {
            VectorDraw.Geometry.gPoints points = new VectorDraw.Geometry.gPoints();

            for(double x=-1.5;x<1.5;x+=0.2)
                for (double y = -1.5; y < 1.5; y += 0.2)
                {
                    double num1 = ((x * x) + (y - 0.842) * (y + 0.842));
                    double num2 = (x*(y-0.842)+ (x*(y+0.842)));
                    double z = 1 / ((num1 * num1)+ (num2 * num2));
                    points.Add (new VectorDraw.Geometry.gPoint (x*10.0,y*10.0,z));
                }

            return points;
        }
        private VectorDraw.Geometry.gPoints Equasion2()
        {
            VectorDraw.Geometry.gPoints points = new VectorDraw.Geometry.gPoints();

            for (double x = -VectorDraw.Geometry.Globals.VD_TWOPI; x < VectorDraw.Geometry.Globals.VD_TWOPI; x += 0.5)
                for (double y = -VectorDraw.Geometry.Globals.VD_TWOPI; y < VectorDraw.Geometry.Globals.VD_TWOPI; y += 0.5)
                {
                    double z = Math.Sin(Math.Pow((x * x + y * y), 0.5)) + 1 / (Math.Pow((Math.Pow((x - 1), 2) + y * y), 0.5));
                    points.Add(new VectorDraw.Geometry.gPoint(x, y, z*5.0));
                }

            return points;
        }
        #endregion

        #region Contours & Add GroundSurface Code
        private void AddContour()
        {
            VectorDraw.Professional.vdFigures.vdGroundSurface ground = new VectorDraw.Professional.vdFigures.vdGroundSurface();
            //We know that the only entity of the document od the GroundSurface so we can obtain this object simply by getting the 0 item of the entities collection.
            ground = vdFramedControl1.BaseControl.ActiveDocument.Model.Entities[0] as VectorDraw.Professional.vdFigures.vdGroundSurface;

            if (ground != null)
            {
                //We add levels.This means that points that have z value equal to the values added will be added to the contours PolyCurves.Then we will add these creates polylines to the document with different colors.
                ground.ContourLevels.RemoveAll();
                foreach (double var in contours)
                {
                    ground.ContourLevels.Add(var);
                }
                ground.Update();
                //We add the Contours polylines.
                if (ground.Contours != null)
                {
                    short i = 0;
                    foreach (VectorDraw.Professional.vdCollections.vdCurves var1 in ground.Contours)
                    {
                        foreach (VectorDraw.Professional.vdFigures.vdCurve var in var1)
                        {
                            var.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
                            var.setDocumentDefaults();
                            var.PenColor.ColorIndex = i;
                            var.PenWidth = 0.3;
                            vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(var.Clone(vdFramedControl1.BaseControl.ActiveDocument));
                        }
                        i++;
                    }
                }
                vdFramedControl1.BaseControl.ActiveDocument.Redraw(true);
            }
        }
        private void LoadEquasion(int equa)
        {
            groupBox1.Enabled = true;
            vdFramedControl1.BaseControl.ActiveDocument.New();
            vdFramedControl1.BaseControl.ActiveDocument.ShowUCSAxis = false;
            VectorDraw.Professional.vdFigures.vdGroundSurface ground = new VectorDraw.Professional.vdFigures.vdGroundSurface();
            ground.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            ground.setDocumentDefaults();
            //We will fill the GroundFurface object's points using mathematical equasions that generate points that look like mountains.
            
            if (equa == 1)
                ground.Points = Equasion1();
            else
                ground.Points = Equasion2();
            MaxCountour = ground.MaxLevel();
            MinCountour = ground.MinLevel();

            //Display properties.
            ground.DispMode = VectorDraw.Professional.vdFigures.vdGroundSurface.DisplayMode.Triangle;
            ground.MeshSize = 0.3;
            ground.PenColor.ColorIndex = 250;

            //We add the groundSurface object to the Model Layout.
            vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(ground);
            
            VectorDraw.Professional.ActionUtilities.vdCommandAction.View3D_VLeft(vdFramedControl1.BaseControl.ActiveDocument);
            vdFramedControl1.BaseControl.ActiveDocument.Redraw(true);
        }
        private void LoadColoredEquasion()
        {
            groupBox1.Enabled = false;


            vdFramedControl1.BaseControl.ActiveDocument.New();
            vdFramedControl1.BaseControl.ActiveDocument.ShowUCSAxis = false;
            VectorDraw.Professional.vdFigures.vdGroundSurface ground = new VectorDraw.Professional.vdFigures.vdGroundSurface();
            ground.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            ground.setDocumentDefaults();

            //We will fill the GroundFurface object's points using mathematical equasions that generate points that look like mountains.
            ground.Points = Equasion1();

            ground.DispMode = VectorDraw.Professional.vdFigures.vdGroundSurface.DisplayMode.Contours;
            ground.MeshSize = 0.3;
            ground.PenColor.ColorIndex = 250;

            //We set the minimum and maximum color of the contours.
            ground.GradientFill = true;
            ground.GradientMinimunColor.SystemColor = Color.Blue;
            ground.GradientMaximunColor.SystemColor = Color.Red;

            //Now we have to add contours levels close to each other depending how accurate we want the colors to be.
            MaxCountour = ground.MaxLevel();
            MinCountour = ground.MinLevel();
            for (double i = MinCountour + 1.0; i < MaxCountour; i += 0.1)
            {
                ground.ContourLevels.Add(i);
            }

            //We add the groundSurface object to the Model Layout.
            vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(ground);

            vdFramedControl1.BaseControl.ActiveDocument.CommandAction.Zoom("E", 0, 0);
            vdFramedControl1.BaseControl.ActiveDocument.Redraw(true);
        }

        private void LoadMappedImage()
        {
            groupBox1.Enabled = false;
            vdFramedControl1.BaseControl.ActiveDocument.New();
            vdFramedControl1.BaseControl.ActiveDocument.ShowUCSAxis = false;
            //open a drawing that contains a predefined ground surface.
            bool success = vdFramedControl1.BaseControl.ActiveDocument.Open("ground.vdcl");
            if (!success) return;
            VectorDraw.Professional.vdFigures.vdGroundSurface ground = vdFramedControl1.BaseControl.ActiveDocument.Model.Entities[0] as VectorDraw.Professional.vdFigures.vdGroundSurface;
            //we add an image definition representing an aerial photo of the ground surface area.
            VectorDraw.Professional.vdPrimaries.vdImageDef idef = vdFramedControl1.BaseControl.ActiveDocument.Images.Add("ground.jpg");
            //we create a new vdMapped Image object and attach it in to our surface object, using a rectangle that represents the tranformation matrix from image object on to our surface coordinate system.
            ground.MappedImages.AddItem(new VectorDraw.Professional.vdObjects.vdMappedImage(idef, new VectorDraw.Geometry.Box(new VectorDraw.Geometry.gPoint(17, 29), new VectorDraw.Geometry.gPoint(3317, 2183)), VectorDraw.Render.vdRectangle.Empty));

            vdFramedControl1.BaseControl.ActiveDocument.CommandAction.Zoom("E", 0, 0);
            vdFramedControl1.BaseControl.ActiveDocument.Redraw(true);
        }
        #endregion

        #region Buttons code
        private void butRotate_Click(object sender, EventArgs e)
        {
            VectorDraw.Professional.ActionUtilities.vdCommandAction.View3D_Vrot (vdFramedControl1.BaseControl.ActiveDocument );
        }
        private void butAddContour_Click(object sender, EventArgs e)
        {
            
            string level = VectorDraw.Professional.Dialogs.frmInputText.Show("From " + MaxCountour.ToString("0.00") + " to " + MinCountour.ToString("0.00") + ")", "Countour level", "0.0",vdFramedControl1.BaseControl.ActiveDocument.ActionControl);
            if (level != "0.0")
            {
                double val = 0.0;
                try
                {
                    val = double.Parse(level);
                }
                catch { val = 0.0; }
                contours.Add(val);
                labContours.Text = contours.Count.ToString() + " contours active";

                AddContour();
            }

        }
        #endregion

        #region Radion Buttons Code
        private void radioequasion1_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioequasion1.Checked) return;
            contours.RemoveAll();
            labContours.Text = contours.Count.ToString() + " contours active";
            LoadEquasion(1);
        }
        private void radioequasion2_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioequasion2.Checked) return;
            contours.RemoveAll();
            labContours.Text = contours.Count.ToString() + " contours active";
            LoadEquasion(2);
        }
        private void radioequasion3_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioequasion3.Checked) return;
            contours.RemoveAll();
            labContours.Text = contours.Count.ToString() + " contours active";
            LoadColoredEquasion();
        }
        private void radioMappedImage_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioMappedImage.Checked) return;
            contours.RemoveAll();
            labContours.Text = contours.Count.ToString() + " contours active";
            LoadMappedImage();
        }
        #endregion

        
    }
}
