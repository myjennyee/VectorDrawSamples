using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VectorDraw.Geometry;
using VectorDraw.Actions;
using VectorDraw.Professional.vdFigures;
using VectorDraw.Professional.vdPrimaries;
using VectorDraw.Professional.vdCollections;
using VectorDraw.Professional.vdObjects;

namespace UserInteraction
{
    public partial class Form1 : Form
    {
        private bool ShowActionEntities = false;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("This sample is provided to show you ways to interact with users.Here you can find useful functions to create your own commands.");
            this.vd.BaseControl.ActiveDocument.OnActionDraw += new VectorDraw.Professional.vdObjects.vdDocument.ActionDrawEventHandler(ActiveDocument_OnActionDraw);
        }

        #region General Functions
        private void AddSomeEntities()
        {
            vdCircle circ = new vdCircle();
            vd.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(circ);
            circ.setDocumentDefaults();
            circ.PenColor.SystemColor = Color.Red;
            circ.Center = new gPoint(5, 5);
            circ.Radius = 2;

            circ = new vdCircle();
            vd.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(circ);
            circ.setDocumentDefaults();
            circ.PenColor.SystemColor = Color.Blue;
            circ.Center = new gPoint(10, 5);
            circ.Radius = 2;

            circ = new vdCircle();
            vd.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(circ);
            circ.setDocumentDefaults();
            circ.PenColor.SystemColor = Color.Green;
            circ.Center = new gPoint(15, 5);
            circ.Radius = 2;

            vd.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new gPoint(), new gPoint(20, 15));
            vd.BaseControl.ActiveDocument.Redraw(true);
        }
        #endregion
        

        void ActiveDocument_OnActionDraw(object sender, object action, bool isHideMode, ref bool cancel)
        {
            if (!ShowActionEntities) return;
            VectorDraw.Actions.BaseAction act = action as VectorDraw.Actions.BaseAction;
            VectorDraw.Geometry.gPoint refpoint = act.ReferencePoint;
            VectorDraw.Geometry.gPoint currentpoint = act.OrthoPoint;

            if (refpoint == null || currentpoint == null) return;

            vdLine line = new vdLine();
            line.SetUnRegisterDocument(vd.BaseControl.ActiveDocument);
            line.setDocumentDefaults();
            line.StartPoint = new gPoint(refpoint);
            line.EndPoint = new gPoint(refpoint.Polar(0.0, refpoint.Distance3D(currentpoint)));
            line.PenColor.SystemColor = Color.Orange;
            line.Draw(act.Render);

            vdArc arc = new vdArc();
            arc.SetUnRegisterDocument(vd.BaseControl.ActiveDocument);
            arc.setDocumentDefaults();
            arc.Radius = refpoint.Distance3D(currentpoint);
            arc.Center = new gPoint(refpoint);
            arc.StartAngle = 0.0;
            arc.EndAngle = VectorDraw.Geometry.Globals.GetAngle(refpoint, currentpoint);
            arc.PenColor.SystemColor = Color.Orange;
            arc.Draw(act.Render);
        }

        private void butGetPoint_Click(object sender, EventArgs e)
        {
            vd.BaseControl.ActiveDocument.New();
            gPoint userpoint;
            vd.BaseControl.ActiveDocument.Prompt("Select a Point:");
            //The user can either click a point or type at the command line a point like 5,5,2
            StatusCode ret = vd.BaseControl.ActiveDocument.ActionUtility.getUserPoint(out userpoint);
            vd.BaseControl.ActiveDocument.Prompt(null);
            if (ret == StatusCode.Success)
            {
                MessageBox.Show("The user selected: x:" + userpoint.x.ToString() + "  y:" + userpoint.y.ToString() + "  z:" + userpoint.z.ToString() + " In UCS(user coordinate system)");
            }
        }
        private void butUserRect_Click(object sender, EventArgs e)
        {
            vd.BaseControl.ActiveDocument.New();
            AddSomeEntities();

            vd.BaseControl.ActiveDocument.Prompt("Other corner:");
            gPoint p1 = new gPoint(2, 2);
            //The user can either click a point or type at the command line a point like 5,5,2
            object ret = vd.BaseControl.ActiveDocument.ActionUtility.getUserRect(p1);
            vd.BaseControl.ActiveDocument.Prompt(null);
            Vector v = ret as Vector;
            if (v != null)
            {
                double angle = v.x;
                double width = v.y;
                double height = v.z;

                //Calculate the point the user clicked.
                //Use polar command to find the bottom right point moving width distance from the initial point.
                gPoint pt2 = p1.Polar(0.0 , width);
                //Use the polar again to go up height distance to find the upper right point.
                pt2 = pt2.Polar(VectorDraw.Geometry.Globals.HALF_PI, height); 

                //Just zoom using the user's rect.
                vd.BaseControl.ActiveDocument.ZoomWindow(p1, pt2);
                vd.BaseControl.ActiveDocument.Redraw(true);
            }
            
        }
        private void butGetFigure_Click(object sender, EventArgs e)
        {
            vd.BaseControl.ActiveDocument.New();
            AddSomeEntities();
            vd.BaseControl.ActiveDocument.Prompt("Select a Figure");
            vdFigure fig;
            gPoint userpt;
            //This command waits until thew user clicks an entity.
            StatusCode code = vd.BaseControl.ActiveDocument.ActionUtility.getUserEntity(out fig, out userpt);
            vd.BaseControl.ActiveDocument.Prompt(null);
            if (code == StatusCode.Success)
            {
                if (fig != null)
                {
                    string handle = fig.Handle.ToStringValue();
                    string color = fig.PenColor.ToString();
                    MessageBox.Show("The user clicked the circle with handle :"+handle +" and with color:"+color+" at point X:"+userpt.x+"  Y:"+ userpt.y +"  Z:"+userpt.z);
                }
            }
            else
                MessageBox.Show("The user cancelled the command");
        }
        private void butGetDistance_Click(object sender, EventArgs e)
        {
            vd.BaseControl.ActiveDocument.New();
            gPoint start = new gPoint(0.0,0.0);
            vd.BaseControl.ActiveDocument.Prompt("Select Distance:");
            
            //The user can either click a point or type at the command line a point like 5,5,2
            object end = vd.BaseControl.ActiveDocument.ActionUtility.getUserDist(start);
            vd.BaseControl.ActiveDocument.Prompt(null);
            if (end != null)
            {
                double distance = (double)end;
                MessageBox.Show("Distance:" + distance.ToString());
            }
        }
        private void butGetAngle_Click(object sender, EventArgs e)
        {
            vd.BaseControl.ActiveDocument.New();
            //Enable the action event to draw extra figures.
            ShowActionEntities = true;
            
            gPoint start = new gPoint(2.0,3.0);
            vd.BaseControl.ActiveDocument.Prompt("Select Angle:");
            //Using the ActionDraw event we draw a line and an arc for better results.
            object end = vd.BaseControl.ActiveDocument.ActionUtility.getUserAngle(start);
            if (vd.BaseControl.ActiveDocument == null) return;
            vd.BaseControl.ActiveDocument.Prompt(null);
            if (end != null)
            {
                double radians = (double)end;
                double degrees = VectorDraw.Geometry.Globals.RadiansToDegrees (radians);
                MessageBox.Show("Angle: " + radians.ToString()+" in radians or " + degrees.ToString()+" in degrees");
            }

            ShowActionEntities = false;

        }
        private void butGetSelection_Click(object sender, EventArgs e)
        {
            vd.BaseControl.ActiveDocument.New();
            AddSomeEntities();
            vd.BaseControl.ActiveDocument.Prompt("Select Entities:");
            vdSelection selset = vd.BaseControl.ActiveDocument.ActionUtility.getUserSelection();
            vd.BaseControl.ActiveDocument.Prompt(null);
            if (selset != null)
            {
                MessageBox.Show("You have selected " + selset.Count + " figures");
                foreach (vdFigure  var in selset)
                    var.HighLight = true;
                vd.BaseControl.ActiveDocument.Redraw(true);
            }
        }
        private void butAcceptedValues_Click(object sender, EventArgs e)
        {
            vd.BaseControl.ActiveDocument.New();
            AddSomeEntities();
            //We will ask the user to select an entity or to type Red,Green,Blue in order to select the entity.
            vd.BaseControl.ActiveDocument.Prompt("Select One Entity or [Red,Blue,Green]:");
            vd.BaseControl.ActiveDocument.ActionUtility.SetAcceptedStringValues(new string[] { "Red;R;r", "Blue;B;b", "Green;G;g" }, "Red");
            object ret = vd.BaseControl.ActiveDocument.ActionUtility.getUserPoint();
            if (ret is gPoint)
            {
                gPoint p1 = vd.BaseControl.ActiveDocument.World2PixelMatrix.Transform(ret as gPoint);
                Point location = new Point((int)p1.x, (int)p1.y);
                vdFigure fig = vd.BaseControl.ActiveDocument.ActiveLayOut.GetEntityFromPoint(location, vd.BaseControl.ActiveDocument.ActiveLayOut.Render.GlobalProperties.PickSize, false);
                if (fig != null)
                {
                    fig.HighLight = true;
                }
            }
            else if (string.Compare((string)ret, "Red") == 0)
            {
                //Select the Red circle.
                gPoint p1 = vd.BaseControl.ActiveDocument.World2PixelMatrix.Transform(new gPoint(7.0,5.0));
                Point location = new Point((int)p1.x, (int)p1.y);
                vdFigure fig = vd.BaseControl.ActiveDocument.ActiveLayOut.GetEntityFromPoint(location, vd.BaseControl.ActiveDocument.ActiveLayOut.Render.GlobalProperties.PickSize, false);
                fig.HighLight = true;
            }
            else if (string.Compare((string)ret, "Blue") == 0)
            {
                //Select the Blue circle.
                gPoint p1 = vd.BaseControl.ActiveDocument.World2PixelMatrix.Transform(new gPoint(12.0, 5.0));
                Point location = new Point((int)p1.x, (int)p1.y);
                vdFigure fig = vd.BaseControl.ActiveDocument.ActiveLayOut.GetEntityFromPoint(location, vd.BaseControl.ActiveDocument.ActiveLayOut.Render.GlobalProperties.PickSize, false);
                fig.HighLight = true;
            }
            else if (string.Compare((string)ret, "Green") == 0)
            {
                //Select the Green circle.
                gPoint p1 = vd.BaseControl.ActiveDocument.World2PixelMatrix.Transform(new gPoint(17.0, 5.0));
                Point location = new Point((int)p1.x, (int)p1.y);
                vdFigure fig = vd.BaseControl.ActiveDocument.ActiveLayOut.GetEntityFromPoint(location, vd.BaseControl.ActiveDocument.ActiveLayOut.Render.GlobalProperties.PickSize, false);
                fig.HighLight = true;
            }
            else { vd.BaseControl.ActiveDocument.Prompt(null);  return; }
            vd.BaseControl.ActiveDocument.Prompt(null);
            vd.BaseControl.ActiveDocument.Redraw(true);
        }
    }
}