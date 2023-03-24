using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VectorDraw.Geometry;
using VectorDraw.Professional.vdObjects;
using VectorDraw.Professional.vdPrimaries;
using VectorDraw.Professional.vdFigures;
using VectorDraw.Professional.vdCollections;

namespace Presentation
{
    public partial class Form1 : Form
    {
#region Initialize
        _3DObjects mUtilities = null;
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //We add the "RequiredFiles" folder to the support path. This addition is made in order for our samples to get the required files from this extra folder used in distribution of our sample files.
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\RequiredFiles\\";
            vd.ActiveDocument.SupportPath = path;
            vd.ActiveDocument.GlobalRenderProperties.CustomRenderTypeName = "VectorDraw.Render.opengllist#VectorDraw.Professional.dll";
            mUtilities = new _3DObjects(this.vd.ActiveDocument);
            vd.KeyDown += new KeyEventHandler(BaseControl_KeyDown);

            label2.Text = "";
            vd.ActiveDocument.EnableAutoGripOn = false;
            vd.ActiveDocument.ShowUCSAxis = false;
            vd.vdMouseEnter += new VectorDraw.Professional.Control.MouseEnterEventHandler(vd_vdMouseEnter);
        }
        
        void vd_vdMouseEnter(EventArgs e, ref bool cancel)
        {
            vd.SetCustomMousePointer(new System.Windows.Forms.Cursor(Presentation.Properties.Resources.Cursor.Handle));
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            double degree = 5.0;

            double step = 0.1;
            try
            {
                step = double.Parse(textBox1.Text, VectorDraw.Serialize.Activator.GetNumberFormat());
            }
            catch { step = 0.1; }

            vdDocument mDocument = vd.ActiveDocument;
            VectorDraw.Geometry.Matrix m = new VectorDraw.Geometry.Matrix();

            if (msg.WParam.ToInt32() == (int)Keys.Up)
            {
                m.TranslateMatrix(0, 0, step);
                mDocument.World2ViewMatrix *= m;
                mDocument.Redraw(false);
                return true;
            }
            else if (msg.WParam.ToInt32() == (int)Keys.Down)
            {
                m.TranslateMatrix(0, 0, -step);
                mDocument.World2ViewMatrix *= m;
                mDocument.Redraw(false);
                return true;
            }
            else if (msg.WParam.ToInt32 () == (int)Keys.Left)
            {
                m.RotateYMatrix(VectorDraw.Geometry.Globals.DegreesToRadians(-degree));
                mDocument.World2ViewMatrix *= m;
                mDocument.Redraw(false);
                return true;
            }
            else if (msg.WParam.ToInt32 () == (int)Keys.Right)
            {
                m.RotateYMatrix(VectorDraw.Geometry.Globals.DegreesToRadians(degree));
                mDocument.World2ViewMatrix *= m;
                mDocument.Redraw(false);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        void BaseControl_KeyDown(object sender, KeyEventArgs e)
        {   
            double step = 0.1;
            try
            {
                step = double.Parse(textBox1.Text, VectorDraw.Serialize.Activator.GetNumberFormat());
            }
            catch { step = 0.1; }
            
            vdDocument mDocument = vd.ActiveDocument;
            VectorDraw.Geometry.Matrix m = new VectorDraw.Geometry.Matrix();
            switch (e.KeyCode)
            {
                //case Keys.Left:
                //    m.RotateYMatrix(VectorDraw.Geometry.Globals.DegreesToRadians(-degree));
                //    mDocument.World2ViewMatrix *= m;
                //    mDocument.Redraw(false);
                //    break;
                //case Keys.Right:
                //    m.RotateYMatrix(VectorDraw.Geometry.Globals.DegreesToRadians(degree));
                //    mDocument.World2ViewMatrix *= m;
                //    mDocument.Redraw(false);
                //    break;
                //case Keys.Up:
                //    m.TranslateMatrix(0, 0, step);
                //    mDocument.World2ViewMatrix *= m;
                //    mDocument.Redraw(false);
                //    break;
                //case Keys.Down:
                //    m.TranslateMatrix(0, 0, -step);
                //    mDocument.World2ViewMatrix *= m;
                //    mDocument.Redraw(false);
                //    break;
                case Keys.PageUp:
                    m.TranslateMatrix(0, -step, 0.0);
                    mDocument.World2ViewMatrix *= m;
                    mDocument.Redraw(false);
                    break;
                case Keys.PageDown:
                    m.TranslateMatrix(0, step, 0.0);
                    mDocument.World2ViewMatrix *= m;
                    mDocument.Redraw(false);
                    break;
            }
        }
        private void checkSun_CheckedChanged(object sender, EventArgs e)
        {
            vdLight sun = vd.ActiveDocument.Lights.FindName("Sun");
            if (sun != null)
            {
                sun.Enable = checkSun.Checked;
                vd.ActiveDocument.Redraw(true);
            }
        }

        private void checkRedLight_CheckedChanged(object sender, EventArgs e)
        {
            vdLight red = vd.ActiveDocument.Lights.FindName("RoomLightPositional");
            if (red != null)
            {
                red.Enable = checkRedLight.Checked;
                vd.ActiveDocument.Redraw(true);
            }
        }
        private void checkSpot_CheckedChanged(object sender, EventArgs e)
        {
            vdLight spot = vd.ActiveDocument.Lights.FindName("PaintingSpot");
            if (spot != null)
            {

                spot.Enable = checkSpot.Checked;
                vd.ActiveDocument.Redraw(true);
            }
        }
        private void CreateNewDocument()
        {
            vd.ActiveDocument.New();
            vd.ActiveDocument.EnableAutoGripOn = false;
            vd.ActiveDocument.ShowUCSAxis = false;
        }
        private void FixCheckBoxes()
        {
            checkClipping.Visible = true;
            textBox1.Visible = true;
            label1.Visible = true;
            butStart.Visible = true;
            checkRedLight.Visible = true;
            checkSun.Visible = true;
            checkSpot.Visible = true;
            checkSun.Checked = true;
            checkRedLight.Checked = true;
            checkSpot.Checked = true;
            
        }
#endregion

        private void butStart_Click(object sender, EventArgs e)
        {


            double step = 0.1;
            try
            {
                step = double.Parse(textBox1.Text, VectorDraw.Serialize.Activator.GetNumberFormat());
            }
            catch{step = 0.1;}

            //First path.
            vdPolyline path1 = new vdPolyline();
            path1.SetUnRegisterDocument(vd.ActiveDocument);
            path1.setDocumentDefaults();
            
            path1.VertexList.Add (new gPoint (3.0, -10.0, 7.5));
            path1.VertexList.Add(new gPoint(4.5, -5.0, 1.7));

            path1.VertexList = new Vertexes(path1.Measure(step));
            path1.VertexList.Add(new gPoint(4.5, -5.0, 1.7));

            //Second Path.
            vdPolyline path2 = new vdPolyline();
            path2.SetUnRegisterDocument(vd.ActiveDocument);
            path2.setDocumentDefaults();
            path2.VertexList.Add (new gPoint(4.5,-5.0,1.7));
            path2.VertexList.Add(new gPoint(4.5, 0.5, 1.7));

            path2.VertexList.Add(new gPoint(4.5, 3.2, 1.7));
            path2.VertexList.Add(new gPoint(2.0, 3.2, 1.7));
            path2.VertexList.Add(new gPoint(1.5, 2.3, 1.7));
            path2.VertexList.Add(new gPoint(1.0, 1.3, 1.7));
            path2.VertexList.Add(new gPoint(1.0, 0.8, 1.7));
            path2.VertexList.Add(new gPoint(4.5, 0.8, 1.7));

            double len = path2.Length();
            double dist = gPoint.Distance2D(path2.VertexList[0], path2.VertexList[1]);
            int r = (int)(len / dist);

            //We use Fillet to make the turns smooth.
            path2.FilletRadius(0.5);
            path2.VertexList = new Vertexes(path2.Measure(step));

            int turn = path2.VertexList.Count / r;//This is the point where the 70 degrees turn is going to happen

            VectorDraw.Geometry.gPoint pTargetPath1 = new gPoint(4.5, 4.0, 1.7);

            Vertexes pts = path1.VertexList;
            for (int i = 0; i < pts.Count - 1; i++)
            {
                VectorDraw.Geometry.gPoint p1 = pts[i].Clone() as VectorDraw.Geometry.gPoint;

                vd.ActiveDocument.CommandAction.LookAt(p1, pTargetPath1);
                vd.Update();
                Application.DoEvents();
            }

            bool didturn = false;

            pts = path2.VertexList;
            for (int i = 1; i < pts.Count - 1; i++)
            {
                VectorDraw.Geometry.gPoint p1 = pts[i].Clone() as VectorDraw.Geometry.gPoint;
                VectorDraw.Geometry.gPoint p2 = pts[i + 1].Clone() as VectorDraw.Geometry.gPoint;

                p2.z = p1.z - 0.01;
                vd.ActiveDocument.CommandAction.LookAt(p1, p2);
                vd.Update();

                if ( i >turn && didturn == false )
                {
                    didturn = true;
                    p1 = pts[i].Clone() as VectorDraw.Geometry.gPoint;
                    //Make a 70 degrees turn.
                    for (int j = 0; j < 80; j += 5)
                    {
                        p2 = p1.Polar (VectorDraw.Geometry.Globals.HALF_PI + VectorDraw.Geometry.Globals.DegreesToRadians (j) ,step);
                        p2.z = p1.z - 0.01;
                        vd.ActiveDocument.CommandAction.LookAt(p1, p2);
                        vd.Update();
                        Application.DoEvents();
                    }
                    for (int j = 70; j > 0; j -= 5)
                    {
                        p2 = p1.Polar(VectorDraw.Geometry.Globals.HALF_PI + VectorDraw.Geometry.Globals.DegreesToRadians(j), step);
                        p2.z = p1.z - 0.01;
                        vd.ActiveDocument.CommandAction.LookAt(p1, p2);
                        vd.Update();
                        Application.DoEvents();
                    }
                }
            }

            MessageBox.Show("End of path");

            VectorDraw.Geometry.gPoint pend = new gPoint(3.0, -10.0, 7.5);
            VectorDraw.Geometry.gPoint p2end = new gPoint(3.0, 4.0, 1.5);
            vd.ActiveDocument.CommandAction.LookAt(pend, p2end);
            vd.Update();
            vd.Focus();
            
        }

        private void butCreate_Click(object sender, EventArgs e)
        {            
            string message = "These Objects are created with code.\r\nYou can use the arrow keys and PageUp PageDown to move around \r\nor press the start button to take a tour.";
            label2.Text = message;
            label2.Update();

            vd.Focus();
            CreateNewDocument();
            FixCheckBoxes();
            
            //Add the table with the chairs.
            mUtilities.AddTableWchairsAndGlass(new gPoint(2.0, 1.5));
            //Add the Room.
            mUtilities.AddRoom(new gPoint(0, 0));
            //Add the painting.
            mUtilities.AddPainting(new gPoint(4.0, 3.78, 1.2), VectorDraw.Geometry.Globals.HALF_PI, 0.0, 0.0);
            //Add the light.
            mUtilities.AddLight(new gPoint(0.8, 3.2,0.001));
            //Add exterior objects
            mUtilities.AddExterior (new gPoint(-5.0,-8.0,-0.002));

            //Add 2 lights and disable the global light for better results.
            vd.ActiveDocument.Lights.Default.Enable = false;
            vdLight light = new vdLight();
            light.SetUnRegisterDocument(vd.ActiveDocument);
            light.setDocumentDefaults();
            light.Name = "RoomLightPositional";
            light.color = Color.YellowGreen;
            light.TypeOfLight = LightType.Positional;
            light.Position = new gPoint(3.5, 1.5, 1.5);

            light.Intensity = vdLight.LightIntensity.LowMedium;
            light.Update();
            vd.ActiveDocument.Lights.AddItem(light);

            light = new vdLight();
            light.SetUnRegisterDocument(vd.ActiveDocument);
            light.setDocumentDefaults();
            light.Name = "Sun";
            light.color = Color.White;
            light.TypeOfLight = LightType.Directional;
            light.Direction = new Vector(new gPoint(3.0, 25.0, 50.0) , new gPoint(3.0, 2.0, 0.0));
            light.Intensity = vdLight.LightIntensity.Medium;
            light.Update();
            vd.ActiveDocument.Lights.AddItem(light);

            light = new vdLight();
            light.SetUnRegisterDocument(vd.ActiveDocument);
            light.setDocumentDefaults();
            light.Name = "PaintingSpot";
            light.color = Color.Blue;
            light.TypeOfLight = LightType.Spot;
            light.Position = new gPoint(4.75, 2.5, 1.7);
            light.SpotDirection = new Vector(new gPoint(0, 1, 0));
            
            light.Intensity = vdLight.LightIntensity.LowMedium;
            light.SpotAngle = 50;
            
            light.Update();
            vd.ActiveDocument.Lights.AddItem(light);
            vd.Update();



            //Place the camera for better view of our scene.
            vd.ActiveDocument.RenderMode = VectorDraw.Render.vdRender.Mode.Render;
            vd.ActiveDocument.PerspectiveMod = VectorDraw.Render.vdRender.VdConstPerspectiveMod.PerspectON;
            VectorDraw.Geometry.gPoint p1 = new gPoint(3.0, -10.0, 6.5);
            VectorDraw.Geometry.gPoint p2 = new gPoint(3.0, 4.5, 1.5);
            vd.ActiveDocument.CommandAction.LookAt(p1, p2);
            vd.Update();
            vd.ActiveDocument.Redraw(true);
            //vd.ActiveDocument.SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\test.vdcl");
        }

        private void checkClipping_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkClipping.Checked)
            {
                //We create a clip which will hide the roof of our room.
                vd.ActiveDocument.ActiveLayOut.Sections.RemoveAll();
                vdSectionClip clip = new vdSectionClip();
                clip.SetUnRegisterDocument(vd.ActiveDocument);
                clip.Name = "SLICE";
                clip.Enable = true;
                clip.OriginPoint = new gPoint(3.0, 3.5, 2.7);
                clip.Direction = new Vector(0, 0, -1);  //This is the direction where we want the visible abjects to be.
                vd.ActiveDocument.ActiveLayOut.Sections.AddItem(clip);

                //We create another clip that will hide the front wall
                clip = new vdSectionClip();
                clip.SetUnRegisterDocument(vd.ActiveDocument);
                clip.Name = "SLICE2";
                clip.Enable = true;
                clip.OriginPoint = new gPoint(3.0, 0.5, 0.0);
                clip.Direction = new Vector(0, 1, 0);  //This is the direction where we want the visible abjects to be.
                vd.ActiveDocument.ActiveLayOut.Sections.AddItem(clip);

                vd.Redraw();
            }
            else
            {
                vd.ActiveDocument.ActiveLayOut.Sections.RemoveAll();
                vd.Redraw();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vd.ActiveDocument.SaveAs("c:\\temp\\vd.vdml");
        }
    }
}