using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AreaCalculation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //We add the "RequiredFiles" folder to the support path. This addition is made in order for our samples to get the required files from this extra folder used in distribution of our sample files.
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\RequiredFiles\\";
            vdFramedControl1.BaseControl.ActiveDocument.SupportPath = path;

            OpenDrawing(vdFramedControl1);
            combodegrees.SelectedIndex = 0;
        }

        private void OpenDrawing(vdControls.vdFramedControl vdraw)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                vdraw.BaseControl.ActiveDocument.Open(Application.StartupPath + "\\Testdrawing.vdml");
                vdraw.BaseControl.ActiveDocument.RenderMode = VectorDraw.Render.vdRender.Mode.Wire2d;
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                vdraw.BaseControl.ActiveDocument.Open(Application.StartupPath + "\\Testdrawing 2.vdml");
                vdraw.BaseControl.ActiveDocument.RenderMode = VectorDraw.Render.vdRender.Mode.Render;
            }
            vdraw.BaseControl.ActiveDocument.ShowUCSAxis = false;
            vdraw.BaseControl.ActiveDocument.Invalidate();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                if (vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count == 0) return;

                double degrees = double.Parse(combodegrees.Text, VectorDraw.Serialize.Activator.GetNumberFormat());
                double radians = VectorDraw.Geometry.Globals.DegreesToRadians(degrees);

                //We will provide 4 different ways to get entities and then we will calculate the area of these polylines and make a quick representation in the CalculateArea Method.

                //1)Get the first polyline dirrectly from the entities collection knowing it's position to the entities collection.
                VectorDraw.Professional.vdFigures.vdPolyline poly = vdFramedControl1.BaseControl.ActiveDocument.Model.Entities[1] as VectorDraw.Professional.vdFigures.vdPolyline;
                if (poly != null && !poly.Deleted) CalculateArea(poly, radians);


                //2) Get the second polyline from it's handle
                poly = vdFramedControl1.BaseControl.ActiveDocument.FindFromHandle(new VectorDraw.Professional.vdObjects.vdHandle(106), typeof(VectorDraw.Professional.vdFigures.vdPolyline)) as VectorDraw.Professional.vdFigures.vdPolyline;
                if (poly != null && !poly.Deleted) CalculateArea(poly, radians);

                //3) Get the third polyline from a point in the drawing.
                VectorDraw.Geometry.gPoint point = new VectorDraw.Geometry.gPoint(-0.0576, -15.7993, 0.0);
                VectorDraw.Geometry.gPoint pt = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.World2Pixelmatrix.Transform(point);

                poly = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.GetEntityFromPoint(new Point((int)pt.x, (int)pt.y), vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.PickSize, false) as VectorDraw.Professional.vdFigures.vdPolyline;
                if (poly != null && !poly.Deleted) CalculateArea(poly, radians);

                //4) Get the last polyline from an XProperty that has been added to this vdFigure named "AreaCalculation" with value "Area".
                //Create a filter.
                VectorDraw.Professional.vdObjects.vdFilterObject filter = new VectorDraw.Professional.vdObjects.vdFilterObject();
                filter.Types.AddItem("vdPolyline");
                filter.XProperties.AddItem("AreaCalculation");

                //Create a selection set to apply the filter.
                VectorDraw.Professional.vdCollections.vdSelection selset = new VectorDraw.Professional.vdCollections.vdSelection("Myselset");
                selset.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
                selset.FilterSelect(filter);

                //Get the polyline from the selection set.
                if (selset.Count != 0)
                {
                    poly = selset[0] as VectorDraw.Professional.vdFigures.vdPolyline;
                    if (poly != null && !poly.Deleted) CalculateArea(poly, radians);
                }
            }
            //The second tab describes the measurement of solid surfaces like Polyfaces.
            else if (tabControl1.SelectedIndex == 1)
            {
                VectorDraw.Professional.vdObjects.vdDocument doc = vdFramedControl2.BaseControl.ActiveDocument;
                //Cleaning our document from unwanted, previously created texts and points.
                foreach (VectorDraw.Professional.vdPrimaries.vdFigure entity in doc.ActiveLayOut.Entities)
                {
                    if (entity is VectorDraw.Professional.vdFigures.vdMText || entity is VectorDraw.Professional.vdFigures.vdPoint)
                        entity.Deleted = true;
                }
                //The precision actually means how big the squares will be. These squares will be used to measure how many fit in every one of our solid surface.
                double precision = (double) textPrecision.Value;
                //The 0,0,1 Vector transformed from Vew to World coordination system, points from the user's eyes towards the screen. So, we will always get the
                //entities that are visible to the user. Different vectors can be used to calculate the "visible" areas from different directions.
                VectorDraw.Geometry.Vector viewVector = new VectorDraw.Geometry.Vector(0, 0, 1);
                doc.View2WorldMatrix.TransformVector(viewVector);

                VectorDraw.Professional.vdCollections.vdEntities ents = new VectorDraw.Professional.vdCollections.vdEntities();
                foreach (VectorDraw.Professional.vdPrimaries.vdFigure entity in doc.ActiveLayOut.Entities)
                {                    
                    if (!(entity is VectorDraw.Professional.vdFigures.vdDimension))
                        if (entity.visibility == VectorDraw.Professional.vdPrimaries.vdFigure.VisibilityEnum.Visible && entity.Deleted == false)
                            ents.AddItem(entity);
                }
                //The GetVisibleArea method of vdDocument, returns a collection of EntityViewArea objects. Within these objects lie the properties that allow us 
                //to extract the visible area for each of the entities we pass as arguments, or for all of them together.
                VectorDraw.Render.PrimitivesExport.RenderProperties.EntityViewAreas areas = doc.GetVisibleArea(ents, viewVector, precision);

                string str = "";
                int counter = 0;
                foreach (VectorDraw.Professional.vdPrimaries.vdFigure entity in ents)
                {
                    string tempStr = entity.GetType().Name + " entity -> " + CalculateAreaSolid(areas, counter, precision).ToString("0.0000") + "\nSquare Drawing Units";
                    str += tempStr;
                    double posX = entity.BoundingBox.Left + 0.1;
                    double posY = entity.BoundingBox.Bottom - 0.5;
                    VectorDraw.Professional.vdFigures.vdMText text = new VectorDraw.Professional.vdFigures.vdMText(doc, tempStr, new VectorDraw.Geometry.gPoint(posX, posY), 0.3);
                    doc.Model.Entities.AddItem(text);
                    counter++;
                }
                doc.Redraw(true);
            }
        }
        //Returns the visible area for the corresponding entity, defined by the index.
        private double CalculateAreaSolid(VectorDraw.Render.PrimitivesExport.RenderProperties.EntityViewAreas areas, int index, double precision)
        {
            //We can extract the visible area of a specific EntityViewArea object, using "[]". If we needed the total visible area, we could call areas.Area().
            //When the projection argument is true, the surface is calculated as if projected to the plane that would have the viewDirection vector as extrusion Vector.
            //In this case, this plane is the user's View.
            return areas[index].Area(checkProjection.Checked);
        }

        private void CalculateArea(VectorDraw.Professional.vdFigures.vdPolyline poly, double radians)
        {
            VectorDraw.Generics.vdArray <VectorDraw.Geometry.SimplePolygonSegment> areas = poly.GetPolygonsAreas(radians);

            double area1 = poly.Area();
            double area2 = 0.0;

            VectorDraw.Geometry.Matrix mattWidth = new VectorDraw.Geometry.Matrix();
            mattWidth.TranslateMatrix(new VectorDraw.Geometry.gPoint(poly.BoundingBox.Width + 0.5, 0.0, 0.0));

            VectorDraw.Geometry.Matrix mattHeight = new VectorDraw.Geometry.Matrix();
            mattHeight.TranslateMatrix(new VectorDraw.Geometry.gPoint(0.0, -poly.BoundingBox.Height - 0.5, 0.0));

            int count = 1;
            string str = "";

            vdFramedControl1.BaseControl.ActiveDocument.UndoHistory.StoreUndoGroup(true);
            foreach (VectorDraw.Geometry.SimplePolygonSegment item in areas)
            {
                if (!item.IsValid) continue;
                str += count.ToString() + ") " + item.SegmentType.ToString() + ":" + (item.ToString() + "\\P");
                area2 += item.Area;
                VectorDraw.Geometry.Vertexes verts = item.ToPolylineVertexes();
                VectorDraw.Professional.vdFigures.vdPolyline tmppoly = new VectorDraw.Professional.vdFigures.vdPolyline();
                tmppoly.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
                tmppoly.setDocumentDefaults();
                tmppoly.MatchProperties(poly, null);
                tmppoly.VertexList = verts;
                if (!item.IsSubtructed)
                {
                    tmppoly.HatchProperties = new VectorDraw.Professional.vdObjects.vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
                    tmppoly.HatchProperties.DrawBoundary = true;
                    tmppoly.HatchProperties.FillColor = new VectorDraw.Professional.vdObjects.vdColor(Color.Green);
                }
                else
                {
                    tmppoly.HatchProperties = new VectorDraw.Professional.vdObjects.vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
                    tmppoly.HatchProperties.DrawBoundary = false;
                    tmppoly.HatchProperties.FillColor = new VectorDraw.Professional.vdObjects.vdColor(Color.Yellow);
                    tmppoly.HatchProperties.Solid2dTransparency = 100;
                }
                tmppoly.Transformby(item.EcsMatrix);
                tmppoly.Transformby(mattWidth);  //Move the polyline segments a bit to the right.

                VectorDraw.Geometry.gPoints pts = new VectorDraw.Geometry.gPoints();
                pts = tmppoly.GetSamplePoints(0, 0);
                VectorDraw.Geometry.gPoint inspt = pts.Centroid();

                VectorDraw.Professional.vdFigures.vdText indextest = new VectorDraw.Professional.vdFigures.vdText();
                indextest.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
                indextest.setDocumentDefaults();
                indextest.TextString = count.ToString();
                indextest.InsertionPoint = inspt;
                indextest.Height = 0.3;
                indextest.PenColor.ColorIndex = 0;
               
                vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(tmppoly);
                vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(indextest);
                count++;
            }

            str += "Total : " + area2.ToString();

            VectorDraw.Professional.vdFigures.vdMText mt = new VectorDraw.Professional.vdFigures.vdMText();
            mt.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            mt.setDocumentDefaults();
            mt.TextString = str;
            mt.InsertionPoint = new VectorDraw.Geometry.gPoint(poly.BoundingBox.Left, poly.BoundingBox.Top, 0.0);
            mt.Transformby(mattHeight);
            mt.Height = 0.9;
            vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(mt);

            vdFramedControl1.BaseControl.ActiveDocument.UndoHistory.StoreUndoGroup(false);
            vdFramedControl1.BaseControl.ActiveDocument.Redraw(true);

        }

        private void combodegrees_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenDrawing(vdFramedControl1);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                textPrecision.Enabled = false;
                combodegrees.Enabled = true;
                checkProjection.Enabled = false;
                OpenDrawing(vdFramedControl1);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                textPrecision.Enabled = true;
                combodegrees.Enabled = false;
                checkProjection.Enabled = true;
                OpenDrawing(vdFramedControl2);
            }
        }

        private void checkProjection_CheckedChanged(object sender, EventArgs e)
        {
            String msg = "When projection is checked, the surface calculated is the one that is projected on the user's View, not the " +
                "real surface of a plane. So for example, if you have a sphere and use projection, the result area will be this of a circle.";
            MessageBox.Show(msg, "Projection", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}