using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AddEntities
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            mtimer.Tick += new EventHandler(mtimer_Tick);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //Hide some controls unaccessary for this sample.
            vdFramedControl.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.CommandLine, false);
            vdFramedControl.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.LayoutTab, false);
            vdFramedControl.UnLoadMenu();
            vdFramedControl.BaseControl.ActiveDocument.ShowUCSAxis = false;

            //We add the "RequiredFiles" folder to the support path. This addition is made in order for our samples to get the required files from this extra folder used in distribution of our sample files.
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\RequiredFiles\\";
            vdFramedControl.BaseControl.ActiveDocument.SupportPath = path;
        }
        #region Buttons
        private void butNew_Click(object sender, EventArgs e)
        {
            vdFramedControl.BaseControl.ActiveDocument.New();
            vdFramedControl.BaseControl.ActiveDocument.ShowUCSAxis = false;
            butLine.Enabled = true;
            butCircle.Enabled = true;
            butEllipse.Enabled = true;
            butArc.Enabled = true;
            butRect.Enabled = true;
            butText.Enabled = true;
            butPoint.Enabled = true;
            butImage.Enabled = true;
            butDims.Enabled = true;
            butInserts.Enabled = true;
            butPolyline.Enabled = true;
            butSpline.Enabled = true;
            buthatch.Enabled = true;
            butMtext.Enabled = true;
            butLeader.Enabled = true;
            but3dobjects.Enabled = true;
            butMultiline.Enabled = true;
            butConstructionLines.Enabled = true;
        }
        private void butLine_Click(object sender, EventArgs e)
        {
            butLine.Enabled = false;
            //We will create a vdLine object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
            VectorDraw.Professional.vdFigures.vdLine oneline = new VectorDraw.Professional.vdFigures.vdLine();
            //We set the document where the line is going to be added.This is important for the vdLine in order to obtain initial properties with setDocumentDefaults.
            oneline.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            oneline.setDocumentDefaults();

            //The two previus steps are important if a vdFigure object is going to be added to a document.
            //Now we will change some properties of the line.
            oneline.StartPoint = new VectorDraw.Geometry.gPoint(10.0, 10.0);
            oneline.EndPoint = new VectorDraw.Geometry.gPoint(30.0, 30.0, 0.0);
            oneline.PenColor.ColorIndex = 3;
            //Pen width is depended from the zoom.See in the vdRect object about LineWeight.
            oneline.PenWidth = 0.4;
            oneline.ToolTip = "This is a vdLine object \n Click to see it's properties.";

            //Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(oneline);

            //Zoom in order to see the object.
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-100.0, -40.0), new VectorDraw.Geometry.gPoint(140.0, 90.0));
            //Redraw the document to see the above changes.
            vdFramedControl.BaseControl.ActiveDocument.Redraw(true);
        }
        private void butCircle_Click(object sender, EventArgs e)
        {
            butCircle.Enabled = false;
            //We will create a vdCircle object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
            VectorDraw.Professional.vdFigures.vdCircle onecircle = new VectorDraw.Professional.vdFigures.vdCircle();
            //We set the document where the circle is going to be added.This is important for the vdCircle in order to obtain initial properties with setDocumentDefaults.
            onecircle.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            onecircle.setDocumentDefaults();

            //The two previus steps are important if a vdFigure object is going to be added to a document.
            //Now we will change some properties of the circle.
            onecircle.Center = new VectorDraw.Geometry.gPoint(30, 30);
            onecircle.Radius = 5;
            onecircle.PenColor.SystemColor = Color.BurlyWood;
            onecircle.Label = "This is a vdCircle object.";
            //This line Type is the same indipending from the zoom.Also the LineTypeScale has no effect,See next object for other linetypes.
            onecircle.LineType = vdFramedControl.BaseControl.ActiveDocument.LineTypes.DPIDashDotDot;

            //Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onecircle);

            //Zoom in order to see the object.
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-100.0, -40.0), new VectorDraw.Geometry.gPoint(140.0, 90.0));
            //Redraw the document to see the above changes.
            vdFramedControl.BaseControl.ActiveDocument.Redraw(true);
        }
        private void butEllipse_Click(object sender, EventArgs e)
        {
            butEllipse.Enabled = false;
            //We will create a vdEllipse object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
            VectorDraw.Professional.vdFigures.vdEllipse oneellipse = new VectorDraw.Professional.vdFigures.vdEllipse();
            //We set the document where the ellipse is going to be added.This is important for the vdEllipse in order to obtain initial properties with setDocumentDefaults.
            oneellipse.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            oneellipse.setDocumentDefaults();

            //The two previus steps are important if a vdFigure object is going to be added to a document.
            //Now we will change some properties of the ellipse.
            oneellipse.Center = new VectorDraw.Geometry.gPoint(10.0, 10.0);
            oneellipse.MajorLength = 7.0;
            //We get the angle of the previously added vdLine object using a globals utility.
            oneellipse.MajorAngle = VectorDraw.Geometry.Globals.GetAngle(new VectorDraw.Geometry.gPoint(0.0, 0.0), new VectorDraw.Geometry.gPoint(30.0, 30.0));
            oneellipse.MinorLength = 5.0;
            oneellipse.PenColor.FromRGB(255, 0, 128);
            oneellipse.URL = "www.vdraw.com";
            oneellipse.ToolTip = "Go to : www.vdraw.com";
            //For Linetype we choose a linetype called DOT2 from the Linetypes collection.
            oneellipse.LineType = vdFramedControl.BaseControl.ActiveDocument.LineTypes.FindName("DOT2");
            oneellipse.LineTypeScale = 6;

            //Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(oneellipse);

            //Zoom in order to see the object.
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-100.0, -40.0), new VectorDraw.Geometry.gPoint(140.0, 90.0));
            //Redraw the document to see the above changes.
            vdFramedControl.BaseControl.ActiveDocument.Redraw(true);
        }
        private void butArc_Click(object sender, EventArgs e)
        {
            butArc.Enabled = false;
            //We will create a vdArc object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
            VectorDraw.Professional.vdFigures.vdArc onearc = new VectorDraw.Professional.vdFigures.vdArc();
            //We set the document where the arc is going to be added.This is important for the vdArc in order to obtain initial properties with setDocumentDefaults.
            onearc.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            onearc.setDocumentDefaults();

            //The two previus steps are important if a vdFigure object is going to be added to a document.
            //Now we will change some properties of the arc.
            onearc.Center = new VectorDraw.Geometry.gPoint(20, 22);
            onearc.Radius = 4;
            onearc.PenColor.Green = 200;
            onearc.StartAngle = VectorDraw.Geometry.Globals.GetAngle(new VectorDraw.Geometry.gPoint(0.0, 0.0), new VectorDraw.Geometry.gPoint(30.0, 30.0));
            onearc.EndAngle = onearc.StartAngle + VectorDraw.Geometry.Globals.PI; 

            //Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onearc);

            //Zoom in order to see the object.
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-100.0, -40.0), new VectorDraw.Geometry.gPoint(140.0, 90.0));
            //Redraw the document to see the above changes.
            vdFramedControl.BaseControl.ActiveDocument.Redraw(true);
        }
        private void butRect_Click(object sender, EventArgs e)
        {
            butRect.Enabled = false;
            //We will create a vdRect object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
            VectorDraw.Professional.vdFigures.vdRect onerect = new VectorDraw.Professional.vdFigures.vdRect();
            //We set the document where the rect is going to be added.This is important for the vdRect in order to obtain initial properties with setDocumentDefaults.
            onerect.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            onerect.setDocumentDefaults();

            //The two previus steps are important if a vdFigure object is going to be added to a document.
            //Now we will change some properties of the rect.
            onerect.InsertionPoint = new VectorDraw.Geometry.gPoint();//Initial value for a gPoint is (0.0,0.0)
            onerect.Width = 40;
            onerect.Height = 40;
            onerect.PenColor.Red = 255;
            onerect.PenColor.Blue = 0;
            onerect.PenColor.Green = 0;
            //This gives Depth to the vdFigure object visible in 3D.
            onerect.Thickness = 5.0;
            //LineWeight is indipended from the zoom.
            onerect.LineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_140;

            //Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onerect);

            //Zoom in order to see the object.
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-100.0, -40.0), new VectorDraw.Geometry.gPoint(140.0, 90.0));
            //Redraw the document to see the above changes.
            vdFramedControl.BaseControl.ActiveDocument.Redraw(true);
        }
        private void butText_Click(object sender, EventArgs e)
        {
            butText.Enabled = false;
            //We will create a vdText object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
            VectorDraw.Professional.vdFigures.vdText onetext = new VectorDraw.Professional.vdFigures.vdText();
            //We set the document where the text is going to be added.This is important for the vdText in order to obtain initial properties with setDocumentDefaults.
            onetext.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            onetext.setDocumentDefaults();

            //The two previus steps are important if a vdFigure object is going to be added to a document.
            //Now we will change some properties of the text.
            onetext.PenColor.ColorIndex = 3;
            onetext.TextString = "Vectordraw Development Framework";
            //vdText object with setDocumentDefaults has the STANDARD TextStyle.We will change the font of this textstyle to Verdana.
            vdFramedControl.BaseControl.ActiveDocument.TextStyles.Standard.FontFile = "Verdana";
            //We set the insertion point depending the width of the Text from the vdFigure's BoundingBox
            onetext.InsertionPoint = new VectorDraw.Geometry.gPoint(40.0 - onetext.BoundingBox.Width, 2);
            onetext.TextLine = VectorDraw.Render.grTextStyleExtra.TextLineFlags.OverLine;
            //Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onetext);

            //Zoom in order to see the object.
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-100.0, -40.0), new VectorDraw.Geometry.gPoint(140.0, 90.0));
            //Redraw the document to see the above changes.
            vdFramedControl.BaseControl.ActiveDocument.Redraw(true);
        }
        private void butPoint_Click(object sender, EventArgs e)
        {
            butPoint.Enabled = false;
            //We change the global PointStyle and PointSize used for all added points.You can set these values to the property list using the 
            //PointStyle form by pressing the button at the right of these Document's properties.
            vdFramedControl.BaseControl.ActiveDocument.PointStyleMode = 36;
            vdFramedControl.BaseControl.ActiveDocument.PointStyleSize = 1.2;

            //We will create a vdPoint object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
            VectorDraw.Professional.vdFigures.vdPoint  onepoint = new VectorDraw.Professional.vdFigures.vdPoint();
            //We set the document where the point is going to be added.This is important for the vdPoint in order to obtain initial properties with setDocumentDefaults.
            onepoint.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            onepoint.setDocumentDefaults();

            //The two previus steps are important if a vdFigure object is going to be added to a document.
            //Now we will change some properties of the point.
            onepoint.InsertionPoint = new VectorDraw.Geometry.gPoint(20, 22);
            onepoint.PenColor.ColorIndex = 1;
            onepoint.ToolTip = "vdPoint object";

            //Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onepoint);

            //Zoom in order to see the object.
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-100.0, -40.0), new VectorDraw.Geometry.gPoint(140.0, 90.0));
            //Redraw the document to see the above changes.
            vdFramedControl.BaseControl.ActiveDocument.Redraw(true);
        }
        private void butImage_Click(object sender, EventArgs e)
        {
            butImage.Enabled = false;
            //We will create a vdImage object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
            VectorDraw.Professional.vdFigures.vdImage oneimage = new VectorDraw.Professional.vdFigures.vdImage();
            //We set the document where the point is going to be added.This is important for the vdPoint in order to obtain initial properties with setDocumentDefaults.
            oneimage.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            oneimage.setDocumentDefaults();

            //The two previus steps are important if a vdFigure object is going to be added to a document.
            //Now we will change some properties of the point.
            oneimage.InsertionPoint = new VectorDraw.Geometry.gPoint(10, 1.1);
            oneimage.Width = 2.9;

           
            //We add a new image definition to the document and set this object to be the ImageDef of this image.
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "vdimage.bmp";
            oneimage.ImageDefinition = vdFramedControl.BaseControl.ActiveDocument.Images.Add(path);
            
            //Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(oneimage);

            //Zoom in order to see the object.
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-100.0, -40.0), new VectorDraw.Geometry.gPoint(140.0, 90.0));
            //Redraw the document to see the above changes.
            vdFramedControl.BaseControl.ActiveDocument.Redraw(true);
        }
        private void butDims_Click(object sender, EventArgs e)
        {
            butDims.Enabled = false;
            //To add a dimension object more easily see the command Action sample.
            //We will create vdDimension objects and add them to the Active Layout which is the basic Model Layout always existing in a Document.
            VectorDraw.Professional.vdFigures.vdDimension onedim1 = new VectorDraw.Professional.vdFigures.vdDimension();
            //We set the document where the dimension is going to be added.This is important for the vdDimension in order to obtain initial properties with setDocumentDefaults.
            onedim1.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            onedim1.setDocumentDefaults();

            //The two previus steps are important if a vdFigure object is going to be added to a document.
            //Now we will change some properties of the point.
            onedim1.PenColor.SystemColor = Color.BlanchedAlmond ;
            onedim1.dimType = VectorDraw.Professional.Constants.VdConstDimType.dim_Aligned;
            onedim1.DefPoint1 = new VectorDraw.Geometry.gPoint(10, 10);
            onedim1.DefPoint2 = new VectorDraw.Geometry.gPoint(30, 30);
            onedim1.LinePosition = VectorDraw.Geometry.gPoint.Polar(new VectorDraw.Geometry.gPoint(10, 10), -VectorDraw.Geometry.Globals.HALF_PI / 2.0, 3);
            onedim1.Rotation = VectorDraw.Geometry.Globals.HALF_PI;
            onedim1.ArrowSize = 2.0;
            onedim1.TextHeight = 1.0;

            //Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onedim1);

            //We also will add a diameter dimension.
            VectorDraw.Professional.vdFigures.vdDimension onedim2 = new VectorDraw.Professional.vdFigures.vdDimension();
            onedim2.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            onedim2.setDocumentDefaults();
            onedim2.PenColor.SystemColor = Color.Azure;
            onedim2.dimType = VectorDraw.Professional.Constants.VdConstDimType.dim_Diameter;
            onedim2.DefPoint1 = new VectorDraw.Geometry.gPoint(25, 30);
            onedim2.DefPoint2 = new VectorDraw.Geometry.gPoint(30, 30);
            onedim2.DefPoint3 = new VectorDraw.Geometry.gPoint(30, 30);
            onedim2.DefPoint4 = new VectorDraw.Geometry.gPoint(30, 30);
            onedim2.LinePosition = new VectorDraw.Geometry.gPoint(35, 30);
            onedim2.ArrowSize = 1.5;
            onedim2.TextHeight = 0.8;
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onedim2);


            //Zoom in order to see the object.
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-100.0, -40.0), new VectorDraw.Geometry.gPoint(140.0, 90.0));
            //Redraw the document to see the above changes.
            vdFramedControl.BaseControl.ActiveDocument.Redraw(true);
        }
        private void butInserts_Click(object sender, EventArgs e)
        {
            butInserts.Enabled = false;
            //We will add a simple block at the Blocks collection consisting of two circles and one line.
            VectorDraw.Professional.vdFigures.vdCircle circ1 = new VectorDraw.Professional.vdFigures.vdCircle();
            circ1.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            circ1.setDocumentDefaults();
            circ1.Radius = 2.5;

            VectorDraw.Professional.vdFigures.vdCircle circ2 = new VectorDraw.Professional.vdFigures.vdCircle();
            circ2.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            circ2.setDocumentDefaults();
            circ2.Radius = 5;

            VectorDraw.Professional.vdFigures.vdLine line = new VectorDraw.Professional.vdFigures.vdLine();
            line.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            line.setDocumentDefaults();
            line.StartPoint = new VectorDraw.Geometry.gPoint(-2.5, 0);
            line.EndPoint = new VectorDraw.Geometry.gPoint(2.5, 0);
            //We check if the block already exists.
            if (vdFramedControl.BaseControl.ActiveDocument.Blocks.FindName("BLK1") == null)
            {
                VectorDraw.Professional.vdPrimaries.vdBlock blk = vdFramedControl.BaseControl.ActiveDocument.Blocks.Add("BLK1");
                blk.Entities.AddItem(circ1);
                blk.Entities.AddItem(circ2);
                blk.Entities.AddItem(line);
                blk.Update();

                //Now we will add two inserts of this block to the Model layout.
                VectorDraw.Professional.vdFigures.vdInsert ins1 = new VectorDraw.Professional.vdFigures.vdInsert();
                ins1.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
                ins1.setDocumentDefaults();
                ins1.Block = vdFramedControl.BaseControl.ActiveDocument.Blocks.FindName("BLK1");
                ins1.InsertionPoint = new VectorDraw.Geometry.gPoint(10, 30);
                ins1.PenColor.ColorIndex = 55;
                ins1.Rotation = VectorDraw.Geometry.Globals.HALF_PI;
                vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(ins1);

                VectorDraw.Professional.vdFigures.vdInsert ins2 = new VectorDraw.Professional.vdFigures.vdInsert();
                ins2.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
                ins2.setDocumentDefaults();
                ins2.Block = vdFramedControl.BaseControl.ActiveDocument.Blocks.FindName("BLK1");
                ins2.InsertionPoint = new VectorDraw.Geometry.gPoint(30, 10);
                ins2.PenColor.ColorIndex = 75;
                vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(ins2);
            }
            //Zoom in order to see the object.
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-100.0, -40.0), new VectorDraw.Geometry.gPoint(140.0, 90.0));
            //Redraw the document to see the above changes.
            vdFramedControl.BaseControl.ActiveDocument.Redraw(true);
        }
        private void butPolyline_Click(object sender, EventArgs e)
        {
            butPolyline.Enabled = false;

            //We will create a vdPolyline object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
            VectorDraw.Professional.vdFigures.vdPolyline onepoly = new VectorDraw.Professional.vdFigures.vdPolyline();
            //We set the document where the polyline is going to be added.This is important for the vdPolyline in order to obtain initial properties with setDocumentDefaults.
            onepoly.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            onepoly.setDocumentDefaults();

            //The two previus steps are important if a vdFigure object is going to be added to a document.
            //Now we will change some properties of the polyline.
            onepoly.VertexList.Add (new VectorDraw.Geometry.gPoint (-10,-10));
            onepoly.VertexList.Add (new VectorDraw.Geometry.gPoint ( 50,-10));
            onepoly.VertexList.Add(new VectorDraw.Geometry.Vertex ( 50, 50,0,0.5));
            onepoly.VertexList.Add (new VectorDraw.Geometry.Vertex (20,70,0,0.5));
            onepoly.VertexList.Add(new VectorDraw.Geometry.Vertex(-10, 50, 0));
            onepoly.Flag = VectorDraw.Professional.Constants.VdConstPlineFlag.PlFlagCLOSE;
            onepoly.PenColor.ColorIndex = 200;

            //Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onepoly);

            //Zoom in order to see the object.
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-100.0, -40.0), new VectorDraw.Geometry.gPoint(140.0, 90.0));
            //Redraw the document to see the above changes.
            vdFramedControl.BaseControl.ActiveDocument.Redraw(true);
        }
        private void butSpline_Click(object sender, EventArgs e)
        {
            butSpline.Enabled = false;
            //We will create a vdPolyline object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
            VectorDraw.Professional.vdFigures.vdPolyline onepoly = new VectorDraw.Professional.vdFigures.vdPolyline();
            //We set the document where the polyline is going to be added.This is important for the vdPolyline in order to obtain initial properties with setDocumentDefaults.
            onepoly.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            onepoly.setDocumentDefaults();

            //The two previus steps are important if a vdFigure object is going to be added to a document.
            //Now we will change some properties of the polyline.
            onepoly.VertexList.Add(new VectorDraw.Geometry.gPoint(10, 60));
            onepoly.VertexList.Add(new VectorDraw.Geometry.gPoint(30, 60));
            onepoly.VertexList.Add(new VectorDraw.Geometry.gPoint(30, 50));
            onepoly.VertexList.Add(new VectorDraw.Geometry.gPoint(10, 50));
            onepoly.ToolTip = "vdPolyline Quadratic";
            onepoly.Flag = VectorDraw.Professional.Constants.VdConstPlineFlag.PlFlagCLOSE;
            onepoly.SPlineFlag = VectorDraw.Professional.Constants.VdConstSplineFlag.SFlagQUADRATIC;
            onepoly.PenColor.SystemColor = Color.Red;
            //Now we will change the hacth properties of this polyline.Hatch propertis have all curve figures(circle,arc,ellipse,rect,polyline).
            //Initialize the hatch properties object.
            onepoly.HatchProperties = new VectorDraw.Professional.vdObjects.vdHatchProperties();
            //And change it's properties
            onepoly.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid;
            onepoly.HatchProperties.FillColor.ColorIndex = 156;

            //Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onepoly);

            //Zoom in order to see the object.
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-100.0, -40.0), new VectorDraw.Geometry.gPoint(140.0, 90.0));
            //Redraw the document to see the above changes.
            vdFramedControl.BaseControl.ActiveDocument.Redraw(true);
        }
        private void buthatch_Click(object sender, EventArgs e)
        {
            buthatch.Enabled = false;
            //We will create a vdPolyHatch object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
            VectorDraw.Professional.vdFigures.vdPolyhatch  onehatch = new VectorDraw.Professional.vdFigures.vdPolyhatch();
            //We set the document where the hatch is going to be added.This is important for the vdPolyhatch in order to obtain initial properties with setDocumentDefaults.
            onehatch.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            onehatch.setDocumentDefaults();

            //The two previus steps are important if a vdFigure object is going to be added to a document.
            //Now we will change some properties of the hatch.
            
            //First we will set the polycurves of the hatch.We will add the rect the spline and the polyline(with bulges) as one curves collection each.Each curves collection added to the hatch 
            //must be a closed sum of entities.
            foreach (VectorDraw.Professional.vdPrimaries.vdFigure  var in vdFramedControl.BaseControl.ActiveDocument.Model.Entities)
            {
                if (var is VectorDraw.Professional.vdFigures.vdPolyline || var is VectorDraw.Professional.vdFigures.vdRect)
                {
                    if (var is VectorDraw.Professional.vdFigures.vdImage) continue;
                    VectorDraw.Professional.vdCollections.vdCurves curves = new VectorDraw.Professional.vdCollections.vdCurves();
                    curves.AddItem (var.Clone(vdFramedControl.BaseControl.ActiveDocument) as VectorDraw.Professional.vdFigures.vdCurve);
                    onehatch.PolyCurves.AddItem(curves);
                }
            }

            if (onehatch.PolyCurves.Count > 2)
            {
                
                onehatch.HatchProperties = new VectorDraw.Professional.vdObjects.vdHatchProperties();
                onehatch.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModePattern;
                onehatch.HatchProperties.HatchPattern = vdFramedControl.BaseControl.ActiveDocument.HatchPatterns.FindName("STARS");
                onehatch.HatchProperties.HatchScale = 0.5;
                onehatch.HatchProperties.FillColor.SystemColor = Color.Blue;
                onehatch.HatchProperties.FillBkColor.SystemColor = Color.Aquamarine;


                //Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
                vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onehatch);

                //Zoom in order to see the object.
                vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-100.0, -40.0), new VectorDraw.Geometry.gPoint(140.0, 90.0));
                //Redraw the document to see the above changes.
                vdFramedControl.BaseControl.ActiveDocument.Redraw(true);
            }
            else
            {
                buthatch.Enabled = true;
                MessageBox.Show("Please Add All entities for better result.");
            }
        }
        private void butMtext_Click(object sender, EventArgs e)
        {
            butMtext.Enabled = false;
            //We will create a vdMText object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
            VectorDraw.Professional.vdFigures.vdMText onemtext = new VectorDraw.Professional.vdFigures.vdMText();
            //We set the document where the Mtext is going to be added.This is important for the vdMText in order to obtain initial properties with setDocumentDefaults.
            onemtext.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            onemtext.setDocumentDefaults();

            //The two previus steps are important if a vdFigure object is going to be added to a document.
            //Now we will change some properties of the text.
            onemtext.InsertionPoint = new VectorDraw.Geometry.gPoint(20, -15);
            onemtext.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter;
            onemtext.BoxWidth = 30;
            onemtext.TextString = "\\C1;\\H5.0;VectorDraw \\C2;\\H2x;Development \\C3;\\H2.5;Framework";

            /*
            \0...\o             Turns overline on and off 
            \L...\l               Turns underline on and off 
            \\                      Inserts a backslash 
            \{...\}                Inserts an opening and closing brace 
            \Cindex;        Changes to the  specified color 
            \Hvalue;       Changes to the text height specified in drawing units 
            \Hvaluex;     Changes the text height  to a multiple of the current text height 
            \Tvalue;       Adjusts the space between characters, from .75 to 4 times 
            \Qangle;      Changes obliquing angle 
            \Wvalue;     Changes width factor to produce wide text 
            \Ffile name; Changes to the specified font file  
            \A                   Sets the alignment value for fractions; valid values: 0 (baseline) , 1 (centered) , 2 (top aligned) 
            \P                   Ends paragraph 
            \S...^...;         Stacks the subsequent text at the \, #, or ^ symbol 
            \p.....;     Several props like xi,t,l,i that determine tabs,paragraphs etc...
            */

            //Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onemtext);

            //Zoom in order to see the object.
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-100.0, -40.0), new VectorDraw.Geometry.gPoint(140.0, 90.0));
            //Redraw the document to see the above changes.
            vdFramedControl.BaseControl.ActiveDocument.Redraw(true);
        }
        private void butLeader_Click(object sender, EventArgs e)
        {
            butLeader.Enabled = false;
            //We will add 2 vdLeader objects with Low Level code changing some basic properties of the object that affect it's appearence.
            VectorDraw.Professional.vdFigures.vdLeader lead1 = new VectorDraw.Professional.vdFigures.vdLeader();
            //We set the document where the leader is going to be added.This is important for the vdLeader in order to obtain initial properties with setDocumentDefaults.
            lead1.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            lead1.setDocumentDefaults();
            //Now we will change some properties of the leader.
            lead1.VertexList.Add (new VectorDraw.Geometry.gPoint (60.0,30.0));
            lead1.VertexList.Add(new VectorDraw.Geometry.gPoint(75.0, 50.0));
            lead1.VertexList.Add(new VectorDraw.Geometry.gPoint(78.0, 60.0));
            lead1.ArrowSize = 5.0;
            lead1.PenColor.ColorIndex = 169;

            //We will create an Mtext object (described above) and we will give it to the leader object.
            VectorDraw.Professional.vdFigures.vdMText mtext1 = new VectorDraw.Professional.vdFigures.vdMText();
            mtext1.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            mtext1.setDocumentDefaults();
            mtext1.InsertionPoint = new VectorDraw.Geometry.gPoint(81.5, 61.5);
            mtext1.TextString = "\\C1;\\H5.0;VectorDraw Objects";
            mtext1.BoxWidth = 40.0;
            mtext1.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerBottom;
            mtext1.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorLeft;
            mtext1.Update();
            //Assign the Mtext to the Leader object.
            lead1.LeaderMText = mtext1;
            lead1.Update(); lead1.Invalidate();
            //Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(lead1);
            //Also the Mtext has to be added to the document after the vdLeader object.
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(mtext1);

            
            //And we add the second Leader object...
            VectorDraw.Professional.vdFigures.vdLeader lead2 = new VectorDraw.Professional.vdFigures.vdLeader();
            lead2.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            lead2.setDocumentDefaults();
            lead2.VertexList.Add(new VectorDraw.Geometry.gPoint(-20.0, 30.0));
            lead2.VertexList.Add(new VectorDraw.Geometry.gPoint(-38.0, 45.0));
            lead2.VertexList.Add(new VectorDraw.Geometry.gPoint(-38.0, 60.0));
            lead2.ArrowSize = 5.0;
            lead2.PenColor.ColorIndex = 230;
            lead2.LeaderType = VectorDraw.Professional.vdFigures.vdLeader.DimLeaderType.Spline_with_arrow;

            VectorDraw.Professional.vdFigures.vdMText mtext2 = new VectorDraw.Professional.vdFigures.vdMText();
            mtext2.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            mtext2.setDocumentDefaults();
            mtext2.InsertionPoint = new VectorDraw.Geometry.gPoint(-41.5, 61.5);
            mtext2.TextString = "\\H5.0;VectorDraw Objects";
            mtext2.BoxWidth = 40.0;
            mtext2.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerBottom;
            mtext2.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorRight;
            mtext2.PenColor.ColorIndex = 230;
            mtext2.Update();
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(lead2);
            lead2.LeaderMText = mtext2;
            lead2.Invalidate();lead2.Update();
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(mtext2);


            //Zoom in order to see the object.
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-100.0, -40.0), new VectorDraw.Geometry.gPoint(140.0, 90.0));
            //Redraw the document to see the above changes.
            vdFramedControl.BaseControl.ActiveDocument.Redraw(true);
        }
        private void but3dobjects_Click(object sender, EventArgs e)
        {
            but3dobjects.Enabled = false;
            //We will create a vdPolyface object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
            VectorDraw.Professional.vdFigures.vdPolyface onepolyface = new VectorDraw.Professional.vdFigures.vdPolyface();
            //We set the document where the polyface is going to be added.This is important for the vdPolyface in order to obtain initial properties with setDocumentDefaults.
            onepolyface.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            onepolyface.setDocumentDefaults();

            //The two previus steps are important if a vdFigure object is going to be added to a document.
            //Now we will change some properties of the circle.
            onepolyface.VertexList.Add(new VectorDraw.Geometry.gPoint(-10, 85));
            onepolyface.VertexList.Add(new VectorDraw.Geometry.gPoint(-10, 75));
            onepolyface.VertexList.Add(new VectorDraw.Geometry.gPoint(0, 85, 10));
            onepolyface.VertexList.Add(new VectorDraw.Geometry.gPoint(0, 75, 10));
            onepolyface.VertexList.Add(new VectorDraw.Geometry.gPoint(10, 85));
            onepolyface.VertexList.Add(new VectorDraw.Geometry.gPoint(10, 75));
            onepolyface.VertexList.Add(new VectorDraw.Geometry.gPoint(20, 85, 10));
            onepolyface.VertexList.Add(new VectorDraw.Geometry.gPoint(20, 75, 10));
            onepolyface.VertexList.Add(new VectorDraw.Geometry.gPoint(30, 85));
            onepolyface.VertexList.Add(new VectorDraw.Geometry.gPoint(30, 75));
            onepolyface.VertexList.Add(new VectorDraw.Geometry.gPoint(40, 85, 10));
            onepolyface.VertexList.Add(new VectorDraw.Geometry.gPoint(40, 75, 10));
            onepolyface.VertexList.Add(new VectorDraw.Geometry.gPoint(50, 85));
            onepolyface.VertexList.Add(new VectorDraw.Geometry.gPoint(50, 75));

            onepolyface.AddFaceItem(1, 2, 4, 3, 1);
            onepolyface.AddFaceItem(3, 4, 6, 5, 2);
            onepolyface.AddFaceItem(5, 6, 8, 7, 3);
            onepolyface.AddFaceItem(7, 8, 10, 9, 4);
            onepolyface.AddFaceItem(9, 10, 12, 11, 5);
            onepolyface.AddFaceItem(11, 12, 14, 13, 6);

            //Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onepolyface);

            //We change the active pen color so the created(and added to the document by the cmdSphere function) spheres will take this color.More information about command action functions in other sample.
            vdFramedControl.BaseControl.ActiveDocument.ActivePenColor.ColorIndex = 9;
            vdFramedControl.BaseControl.ActiveDocument.CommandAction.CmdSphere(new VectorDraw.Geometry.gPoint(-15, 80), 5.0, 10, 10);
            vdFramedControl.BaseControl.ActiveDocument.CommandAction.CmdSphere(new VectorDraw.Geometry.gPoint(55, 80), 5.0, 10, 10);

            //Zoom in order to see the object.
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-100.0, -40.0), new VectorDraw.Geometry.gPoint(140.0, 90.0));
            //Redraw the document to see the above changes.
            vdFramedControl.BaseControl.ActiveDocument.Redraw(true);
        }
        private void butConstructionLines_Click(object sender, EventArgs e)
        {
            butConstructionLines.Enabled = false;

            //We will AddEntities 2 construction lines.
            VectorDraw.Professional.vdFigures.vdInfinityLine ConstructionLine = new VectorDraw.Professional.vdFigures.vdInfinityLine();
            //We set the document where the ConstructionLines are going to be added.This is important for the vdInfinityLine object in order to obtain initial properties with setDocumentDefaults.
            ConstructionLine.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            ConstructionLine.setDocumentDefaults();
            //Now we will change some properties of the vdInfinityLine.
            ConstructionLine.BasePoint = new VectorDraw.Geometry.gPoint(19.3, -12.4);
            ConstructionLine.Direction = new VectorDraw.Geometry.Vector(1.0, 0.0, 0.0);
            ConstructionLine.PenColor.ColorIndex = 3;
            //And also we set the type of the construction line (Ray or Xline).
            ConstructionLine.InfinityType = VectorDraw.Professional.vdFigures.vdInfinityLine.InfinityTypes.XLine;

            //The vdInfinityLine has to be added to the document.
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(ConstructionLine);

            //And another one but Ray this time...
            ConstructionLine = new VectorDraw.Professional.vdFigures.vdInfinityLine();
            //We set the document where the ConstructionLines are going to be added.This is important for the vdInfinityLine object in order to obtain initial properties with setDocumentDefaults.
            ConstructionLine.SetUnRegisterDocument(vdFramedControl.BaseControl.ActiveDocument);
            ConstructionLine.setDocumentDefaults();
            //Now we will change some properties of the vdInfinityLine.
            ConstructionLine.BasePoint = new VectorDraw.Geometry.gPoint(-25.0 , -12.4);
            ConstructionLine.Direction = new VectorDraw.Geometry.Vector(0.0, 1.0, 0.0);
            ConstructionLine.PenColor.ColorIndex = 2;
            //And also we set the type of the construction line (Ray or Xline).
            ConstructionLine.InfinityType = VectorDraw.Professional.vdFigures.vdInfinityLine.InfinityTypes.Ray;

            //The vdInfinityLine has to be added to the document.
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(ConstructionLine);
            
            //Zoom in order to see the object.
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-100.0, -40.0), new VectorDraw.Geometry.gPoint(140.0, 90.0));
            //Redraw the document to see the above changes.
            vdFramedControl.BaseControl.ActiveDocument.Redraw(true);
        }
        private void butSurf_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.ShowDialog(this);
        }
        private void butMultiline_Click(object sender, EventArgs e)
        {
            butMultiline.Enabled = false;

            //Create a vdMultiline object
            VectorDraw.Professional.vdFigures.vdMultiline line = new VectorDraw.Professional.vdFigures.vdMultiline(vdFramedControl.BaseControl.ActiveDocument);
            line.VertexList.Add(new VectorDraw.Geometry.Vertex(63,5,0));
            line.VertexList.Add(new VectorDraw.Geometry.Vertex(80,25,0));
            line.VertexList.Add(new VectorDraw.Geometry.Vertex(110, 25,0));
            line.VertexList.Add(new VectorDraw.Geometry.Vertex(127, 5,0));
            line.ScaleFactor = 10.0;

            //The vdMultiline has to be added to the document.
            vdFramedControl.BaseControl.ActiveDocument.Model.Entities.AddItem(line);

            //Create a vdMultilineStyle object with 4 Element lines
            VectorDraw.Professional.vdPrimaries.vdMultilineStyle mline = new VectorDraw.Professional.vdPrimaries.vdMultilineStyle(vdFramedControl.BaseControl.ActiveDocument, "Test");

            //1st Element
            VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement elem = new VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement();
            elem.ElementColor.ColorIndex = 0;
            elem.ElementLineType = vdFramedControl.BaseControl.ActiveDocument.LineTypes.FindName("DASHDOT0");
            elem.ElementLineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_120;
            elem.Offset = 1.0;
            mline.Elements.Add(elem);

            //Second Element
            elem = new VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement();
            elem.ElementColor.ColorIndex = 1;
            elem.ElementLineType = vdFramedControl.BaseControl.ActiveDocument.LineTypes.FindName("DASHDOTDOT0");
            elem.Offset = 0.25;
            mline.Elements.Add(elem);

            //Third Element
            elem = new VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement();
            elem.ElementColor.ColorIndex = 1;
            elem.ElementLineType = vdFramedControl.BaseControl.ActiveDocument.LineTypes.FindName("DASHDOTDOT0");
            elem.Offset = -0.25;
            mline.Elements.Add(elem);

            //Fourth Element
            elem = new VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement();
            elem.ElementColor.ColorIndex = 0;
            elem.ElementLineType = vdFramedControl.BaseControl.ActiveDocument.LineTypes.FindName("DASHDOT0");
            elem.Offset = -1.0;
            mline.Elements.Add(elem);

            //Other MultilineStyle properties
            mline.StartAngle = VectorDraw.Geometry.Globals.DegreesToRadians(90.0);
            mline.EndAngle = VectorDraw.Geometry.Globals.DegreesToRadians(90.0);
            mline.Flags |= VectorDraw.Professional.Constants.VdMultilineFlags.Start_Square_Line;
            mline.Flags |= VectorDraw.Professional.Constants.VdMultilineFlags.End_Square_Line;
            mline.Flags |= VectorDraw.Professional.Constants.VdMultilineFlags.DisplayMiters;
            mline.Flags |= VectorDraw.Professional.Constants.VdMultilineFlags.Start_Outer_Arc;
            mline.Flags |= VectorDraw.Professional.Constants.VdMultilineFlags.Start_Inner_Arc;
            mline.Flags |= VectorDraw.Professional.Constants.VdMultilineFlags.End_Inner_Arc;
            mline.Flags |= VectorDraw.Professional.Constants.VdMultilineFlags.End_Outer_Arc;
            mline.Update();

            //Add the MultilineStyle to the Document's collection
            vdFramedControl.BaseControl.ActiveDocument.MultilineStyles.AddItem(mline);

            //Assign the newlly created MultilineStyle to the Multiline.
            line.Invalidate();
            line.MultilineStyle = mline;
            line.Update();
            line.Invalidate();

            //Zoom in order to see the object.
            vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-100.0, -40.0), new VectorDraw.Geometry.gPoint(140.0, 90.0));
            //Redraw the document to see the above changes.
            vdFramedControl.BaseControl.ActiveDocument.Redraw(true);
        }
        #endregion
        
        #region Rotate Scene
        double degrees = 0.0;
        private Timer mtimer = new Timer();
        void mtimer_Tick(object sender, EventArgs e)
        {
            if (degrees > 360.0) degrees = 0.0;
            degrees += 1.0;
            VectorDraw.Geometry.Matrix matt = new VectorDraw.Geometry.Matrix();
            matt.RotateXMatrix(VectorDraw.Geometry.Globals.DegreesToRadians(degrees));
            matt.RotateYMatrix(VectorDraw.Geometry.Globals.DegreesToRadians(degrees));
            matt.RotateZMatrix(VectorDraw.Geometry.Globals.DegreesToRadians(degrees));
            Console.WriteLine(degrees.ToString());
            vdFramedControl.BaseControl.ActiveDocument.Model.World2ViewMatrix = matt;
            vdFramedControl.BaseControl.ActiveDocument.Redraw(false);
        }
        private void checkRot_CheckedChanged(object sender, EventArgs e)
        {
            mtimer.Interval = 80;
            if (checkRot.Checked)
            {
                vdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-140.0, -70.0), new VectorDraw.Geometry.gPoint(140.0, 100.0));
                mtimer.Start();
            }
            else
                mtimer.Stop();
        }
        #endregion
    }
}