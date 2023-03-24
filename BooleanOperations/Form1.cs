using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VectorDraw.Professional.vdFigures;
using VectorDraw.Geometry;

namespace BooleanOperations
{
    /// <summary>
    /// This sample project aims to present the new boolean operations developed in the Vectordraw framework.
    /// You can check the capabilities by using the four different buttons. 
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        VectorDraw.Professional.vdObjects.vdDocument doc
        {
            get { return vdraw.ActiveDocument; }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            globalTimer.Tick += new EventHandler(globalTimer_Tick);
            globalTimer.Start();
        }

        void globalTimer_Tick(object sender, EventArgs e)
        {
            demo();
        }
        private void createScene(int state)
        {
            if (state == 2)
            {
                doc.CommandAction.CmdBox3d(new VectorDraw.Geometry.gPoint(-1.5, -1.5, -1.5), 3, 3, 3, 0);
            }
            else if (state == 3)
            {
                //doc.CommandAction.CmdSphere(new VectorDraw.Geometry.gPoint(0, 0, 0), 1.8, 20, 20);
                doc.CommandAction.CmdTorus(new VectorDraw.Geometry.gPoint(0, 0, 0), 1.9, 0.5, 20, 20);
                doc.CommandAction.CmdRotate3d("x", doc.Model.Entities.Last, new gPoint(), 45.0);
                doc.CommandAction.CmdRotate3d("y", doc.Model.Entities.Last, new gPoint(), 45.0);
                doc.Model.Entities.Last.Update();
            }
        }
        private void initDoc()
        {
            doc.New();
            VectorDraw.Professional.ActionUtilities.vdCommandAction.View3D_VTop(doc);
            doc.RenderMode = VectorDraw.Render.vdRender.Mode.ShadeOn;
            doc.Redraw(true);
            doc.CommandAction.Zoom("w", new VectorDraw.Geometry.gPoint(-11, -10), new VectorDraw.Geometry.gPoint(10, 10));
            doc.GlobalRenderProperties.SelectionPreview = VectorDraw.Render.vdRenderGlobalProperties.SelectionPreviewFlags.ON;            
            doc.FreezeActions = true;
        }

        static int step = 1;
        Timer globalTimer = new Timer();
        vdPolyface mergedPlface = null;
        vdText txt = null;
        private void demo()
        {
            
            globalTimer.Stop();

            int delay = 1000;
            if (step == 1)
            {
                initDoc();                
            }
            else if (step == 2)
            {
                createScene(2);
                doc.Redraw(true);
            }
            else if (step == 3)
            {
                createScene(3);
                doc.Redraw(true);
            }
            else if (step == 4)
            {
                PerformOperation(BooleanOperation.Union, Color.FromArgb(255, 200, 200));
            }
            else if (step > 4 && step < 15)
            {
                delay = 50;
                translatePlFaces(new gPoint(-1, 0.5));
            }
            else if (step == 15)
            {
                PerformOperation(BooleanOperation.Intersection, Color.FromArgb(200, 255, 200));
            }
            else if (step > 15 && step < 26)
            {
                delay = 50;
                translatePlFaces(new gPoint(1, 0.5));
            }
            else if (step == 26)
            {
                PerformOperation(BooleanOperation.Substraction, Color.FromArgb(200, 200, 255));
            }
            else if (step > 26 && step < 37)
            {
                delay = 50;
                translatePlFaces(new gPoint(1, -0.5));
            }
            else if (step == 37)
            {
                PerformOperation(BooleanOperation.ReverseSubsctraction, Color.FromArgb(255, 255, 200));
            }
            else if (step > 37 && step < 48)
            {
                delay = 50;
                translatePlFaces(new gPoint(-1, -0.5));
            }
            else
            {
                endDemo();
                return;
            }

            step += 1;
            globalTimer.Interval = delay;
            globalTimer.Start();
        }

        private void endDemo()
        {
            buttonIntersection.Enabled = true;
            buttonRevSubstraction.Enabled = true;
            buttonUnion.Enabled = true;
            buttonSubstract.Enabled = true;
            doc.FreezeActions = false;
        }

        //This function handles the several boolean operations.
        private void PerformOperation(VectorDraw.Professional.vdFigures.BooleanOperation operation, Color color)
        {
            vdPolyface plface1 = doc.Model.Entities[0] as VectorDraw.Professional.vdFigures.vdPolyface;
            vdPolyface plface2 = doc.Model.Entities[1] as VectorDraw.Professional.vdFigures.vdPolyface;

            //The result of every boolean operation are triangles.
            VectorDraw.Geometry.gTriangles triangles = vdPolyface.CombinePolyfaces(plface1, plface2, operation);

            mergedPlface = new vdPolyface(doc);
            //Triangles with zero area are removed from the collection.
            triangles.RemoveZeroAreaTriangles();
            //All the created triangles are merged in this polyface object. This object is now the result of the
            //boolean operation.
            mergedPlface.MergeTriangles(triangles);
            mergedPlface.PenColor = new VectorDraw.Professional.vdObjects.vdColor(color);

            txt = new vdText(doc, operation.ToString(), new gPoint(), 1);
            txt.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter;
            txt.InsertionPoint = new gPoint(0, 2);

            doc.Model.Entities.AddItem(mergedPlface);
            doc.Model.Entities.AddItem(txt);
            doc.Redraw(true);
        }
        //Used to move the result polyface.
        private void translatePlFaces(gPoint p)
        {
            doc.CommandAction.CmdMove(mergedPlface, new gPoint(0, 0, 0), p);
            txt.InsertionPoint = mergedPlface.BoundingBox.MidPoint + new gPoint(0, 2);
            txt.Update();
            doc.Invalidate();
        }

        private void buttonUnion_Click(object sender, EventArgs e)
        {
            if (!doc.CommandAction.CmdCombinePolyfaces(null, null, VectorDraw.Professional.vdFigures.BooleanOperation.Union))
                return;
        }        

        private void buttonSubstract_Click(object sender, EventArgs e)
        {
            if (!doc.CommandAction.CmdCombinePolyfaces(null, null, VectorDraw.Professional.vdFigures.BooleanOperation.Substraction))
                return;
        }

        private void buttonIntersection_Click(object sender, EventArgs e)
        {
            if (!doc.CommandAction.CmdCombinePolyfaces(null, null, VectorDraw.Professional.vdFigures.BooleanOperation.Intersection))
                return;
        }

        private void buttonRevSubstraction_Click(object sender, EventArgs e)
        {
            if (!doc.CommandAction.CmdCombinePolyfaces(null, null, VectorDraw.Professional.vdFigures.BooleanOperation.ReverseSubsctraction))
                return;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            globalTimer.Stop();
            initDoc();
            createScene(2);
            createScene(3);
            endDemo();
        }
    }
}