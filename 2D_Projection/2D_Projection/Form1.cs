using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VectorDraw.Professional;
using VectorDraw.Professional.vdObjects;
using VectorDraw.Geometry;
using VectorDraw.Professional.vdFigures;
using VectorDraw.Professional.vdPrimaries;

//
//Description : 
//  In tis sample a drawing is loaded into a vdFramedControl and some already fixed areas in
//  this drawing are exported to simple 2D line-segemnts. Then these line segments are added 
//  to a new vdLayout object as vdLine objects
// 
//Use:
//  This sample uses the GetModel2dProjection function to create the segment lines from the 
//  model. This function needs two parameters: i) the "eye" position and "direction" that the
//  eye looks to. It also needs a rotation of the view, but in this sample the 0 rotation is
//  the rotation that should be used to get the correct results.
//

namespace TwoD_Projection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        vdDocument doc;// document that will be used
        private void Form1_Load(object sender, EventArgs e)
        {
            doc = vdFramedControl1.BaseControl.ActiveDocument;
            
            //We add the "RequiredFiles" folder to the support path. This addition is made in order for our samples to get the required files from this extra folder used in distribution of our sample files.
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\RequiredFiles\\";
            doc.SupportPath = path;

            if (doc.Open(@"kindergarden.vdcl"))
            {
                doc.Redraw(true);
                vdFramedControl1.UnLoadCommands(); // commands are not necessary
                vdFramedControl1.UnLoadMenu();//menu is not necessary
                vdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.CommandLine, false);// commandline is not necessary
                MessageBox.Show("3D Drawing opened. The roof of this drawing is set to be transparent for better visual result");
            }

        }
        private void AnnotationLayers(bool frozen)
        {
            doc.Layers.FindName("Annotations1").Frozen = frozen; // setting the yelow rect and label to frozen/thaw as thay were added for demonstration issues
            doc.Layers.FindName("Annotations2").Frozen = frozen; // setting the green rect and label to frozen/thaw as thay were added for demonstration issues
            doc.Layers.FindName("Annotations3").Frozen = frozen; // setting the blue rect and label to frozen/thaw as thay were added for demonstration issues
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnnotationLayers(true);
            linesegments segs = new linesegments(); // this is the collection of the simple line segments where will be calculated by GetModel2dProjection
            
            //1st Layout - 2D projection
            gPoint origin = new gPoint(0, -11.3, 0); // set origin point of the "eye"
            gPoint dir = new gPoint(0,0,0);;
            segs = doc.GetModel2dProjection(origin, new Vector(origin, dir), 0.0); // get the 2D projection as line-segments
            vdLayout layout = doc.LayOuts.Add("2DProjection_Area1"); // add a layout to add the results
            layout.Entities.RemoveAll();
            foreach (linesegment line in segs)
            {
                layout.Entities.AddItem(new vdLine(doc, line.StartPoint, line.EndPoint)); // add each line-segment as vdLine
            }
            AddSectionViewPort(layout, origin, dir);
            layout.DisableShowPrinterPaper = true; layout.ZoomExtents();
            MessageBox.Show("The 2D projection (as simple lines) of the model for this yellow area is created and is available in the layout: "+layout.Name+". Click on this layout to see the results");

            AnnotationLayers(false);

            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AnnotationLayers(true);

            //2nd Layout - 2D projection
            linesegments segs = new linesegments(); // this is the collection of the simple line segments where will be calculated by GetModel2dProjection
            gPoint origin = new gPoint(0, -5.3, 0); // set origin point of the "eye"
            gPoint dir = new gPoint(0, 0, 0); ; // and direction of the "eye"
            vdLayout layout = doc.LayOuts.Add("2DProjection_Area2");// add a layout to add the results
            layout.Entities.RemoveAll();
            segs.RemoveAll();
            segs = doc.GetModel2dProjection(origin, new Vector(origin, dir), 0.0);// get the 2D projection as line-segments

            foreach (linesegment line in segs)
            {
                layout.Entities.AddItem(new vdLine(doc, line.StartPoint, line.EndPoint));// add each line-segment as vdLine
            }
            AddSectionViewPort(layout, origin, dir);
            layout.DisableShowPrinterPaper = true; layout.ZoomExtents();
            MessageBox.Show("The 2D projection (as simple lines) of the model for this green area is created and is available in the layout: " + layout.Name + ". Click on this layout to see the results");

            AnnotationLayers(false);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnnotationLayers(true);
            //3rd Layout - 2D projection
            // some section clips will be applied to isolate the area from the other objects
            linesegments segs = new linesegments(); // this is the collection of the simple line segments where will be calculated by GetModel2dProjection

          
            doc.Model.Sections.AddItem(new vdSectionClip(doc, "clip1", new gPoint(0.3, 8, 0), new Vector(1, 0, 0), true));
        
            doc.Model.Sections.AddItem(new vdSectionClip(doc, "clip2", new gPoint(5.3, 8, 0), new Vector(-1, 0, 0), true));
        
            doc.Model.Sections.AddItem(new vdSectionClip(doc, "clip3", new gPoint(1.8, 5.8, 0), new Vector(0, 1, 0), true));


            gPoint origin = new gPoint(2.8, 6.8, 0); // set origin point
            gPoint dir = new gPoint(2.8, 9.8, 0); ; //and direction of the "eye"
            vdLayout layout = doc.LayOuts.Add("2DProjection_Area3");  // add a layout to add the results
            layout.Entities.RemoveAll();
            segs.RemoveAll();
            segs = doc.GetModel2dProjection(origin, new Vector(origin, dir), 0.0);// get the 2D projection as line-segments

            foreach (linesegment line in segs)
            {
                layout.Entities.AddItem(new vdLine(doc, line.StartPoint, line.EndPoint));// add each line-segment as vdLine
            }


            AddSectionViewPort(layout, origin, dir);

            foreach (vdSectionClip clip in doc.Model.Sections) clip.Deleted = true;// disable the Model's clip-sections are not necessary any more
            doc.Model.Sections.RemoveAll();

            layout.DisableShowPrinterPaper = true; layout.ZoomExtents();
            doc.ActiveLayOut = doc.Model;

            AnnotationLayers(false);
            MessageBox.Show("The 2D projection (as simple lines) of the model for this blue area is created and is available in the layout: " + layout.Name + ". Click on this layout to see the results, note also that this layout has also a viewport with section clipping for comparing.");
            

        }

        /// <summary>
        /// create a viewport in hide mode in order to compare the GetModel2dProjection results
        /// </summary>
        void AddSectionViewPort(vdLayout layout, gPoint origin, gPoint dir)
        {
            Box ext = new Box(layout.Entities.GetBoundingBox(true, false));
            vdViewport view = new vdViewport(doc); // create a vdViewport that has the same view as the area that was exported as 2D using GetModel2dProjection
            layout.Entities.AddItem(view); // for more information on vdLayouts/vdViewports see sample "Collections"
            doc.ActiveLayOut = layout; //with this viewport that will displayed above the line segments you would be able to compare the results
            Matrix m = new Matrix();
            m.SetLookAt(origin, dir, 0.0);
            view.World2ViewMatrix = m;

            
            view.Center = ext.MidPoint + new gPoint(0, ext.Height * 1.1);
            view.Height = ext.Height;
            view.Width = ext.Width;
            
            view.ViewSize = ext.Height * 1.5;
            view.RenderMode = VectorDraw.Render.vdRender.Mode.Hide;
            view.Sections.AddItem(new vdSectionClip(doc, "viewclip1", origin, new Vector(origin, dir),true));

            foreach (vdSectionClip clip in doc.Model.Sections)
            {
                vdSectionClip vclip = clip.Clone() as vdSectionClip;
                vclip.Enable = true;
                view.Sections.AddItem(vclip);
            }

            
        }
    }
}