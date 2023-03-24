using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VectorDraw.Geometry;

namespace CustomObjects
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path = "";

            //We add the "RequiredFiles" folder to the support path. This addition is made in order for our samples to get the required files from this extra folder used in distribution of our sample files.
            path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\RequiredFiles\\";
            if (System.IO.Directory.Exists(path))
                vdFramedControl1.BaseControl.ActiveDocument.SupportPath = path;
            else
            {
                //Set the support path for the dll that contains the custom objects so the commands of the command line can find the dll and load the specified static method action that implements the custom object.
                path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\";
                vdFramedControl1.BaseControl.ActiveDocument.SupportPath += path;
            }

            vdFramedControl1.UnLoadCommands();
            vdFramedControl1.UnLoadMenu();
            bool res = vdFramedControl1.LoadCommands(path, "Commands.txt");
            vdFramedControl1.LoadMenu(path, "Menu.txt");
            vdFramedControl1.ShowMenu(true);

            //Very Important for owner custom objects
            vdFramedControl1.BaseControl.ActiveDocument.ProxyClasses.Add(typeof(VectorDrawCustomFigs.MyObject));
            vdFramedControl1.BaseControl.ActiveDocument.ProxyClasses.Add(typeof(VectorDrawCustomFigs.MyObject2));


            vdFramedControl1.BaseControl.ActiveDocument.OnAfterOpenDocument += new VectorDraw.Professional.vdObjects.vdDocument.AfterOpenDocument(ActiveDocument_OnAfterOpenDocument);

            AddSomeCustomObjectsByCode();
        }

        private void AddSomeCustomObjectsByCode()
        {
            VectorDrawCustomFigs.VectorDrawArrowLine arrowline = new VectorDrawCustomFigs.VectorDrawArrowLine(vdFramedControl1.BaseControl.ActiveDocument);
            arrowline.StartPoint = new VectorDraw.Geometry.gPoint(10, 10);
            arrowline.EndPoint = new VectorDraw.Geometry.gPoint(20, 20);
            vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(arrowline);

            VectorDrawCustomFigs.VectorDrawBlink blink = new VectorDrawCustomFigs.VectorDrawBlink(vdFramedControl1.BaseControl.ActiveDocument);
            blink.Origin = new VectorDraw.Geometry.gPoint(-20, -20);
            blink.Radius = 8;
            vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(blink);

            VectorDrawCustomFigs.VectorDrawOffsetLine multiline = new VectorDrawCustomFigs.VectorDrawOffsetLine(vdFramedControl1.BaseControl.ActiveDocument);
            multiline.VertexList.Add(new gPoint(0, 0));
            multiline.VertexList.Add(new gPoint(-10, 10));
            multiline.VertexList.Add(new gPoint(-20, 15));
            multiline.VertexList.Add(new gPoint(-10, 20));
            multiline.Flag = VectorDraw.Professional.Constants.VdConstPlineFlag.PlFlagCLOSE;
            multiline.NumOfLines = 3;
            multiline.LinesColor.ColorIndex = 1;
            multiline.PenColor.ColorIndex = 0;
            multiline.LinesDistance = 0.7;
            vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(multiline);

            VectorDrawCustomFigs.VectorDrawPolygon polygon = new VectorDrawCustomFigs.VectorDrawPolygon(vdFramedControl1.BaseControl.ActiveDocument);
            polygon.Origin = new gPoint(30, -10);
            polygon.NumSides = 5;
            polygon.Radius = 10;
            polygon.PenColor.ColorIndex = 4;
            polygon.TextString = "Hello World";
            polygon.AddSomeValues();
            vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(polygon);

            VectorDrawCustomFigs.RectEx rect = new VectorDrawCustomFigs.RectEx (vdFramedControl1.BaseControl.ActiveDocument);
            rect.Origin = new gPoint(45, 20);
            rect.RectHeight = 20;
            rect.RectWidth = 30;
            rect.Rotation = VectorDraw.Geometry.Globals.DegreesToRadians(25);
            vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(rect);

            VectorDrawCustomFigs.VectorDrawSimpleRect simplerect = new VectorDrawCustomFigs.VectorDrawSimpleRect(vdFramedControl1.BaseControl.ActiveDocument);
            simplerect.InsertionPoint = new gPoint(55, -15);
            simplerect.Height = 15;
            simplerect.Width = 25;
            simplerect.PenColor.FromRGB(200, 0, 0);
            simplerect.obj1 = new VectorDrawCustomFigs.MyObject(5.0, "hello");
            vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(simplerect);

            VectorDrawCustomFigs.vdSuperPoly pl = new VectorDrawCustomFigs.vdSuperPoly(vdFramedControl1.BaseControl.ActiveDocument);
            pl.VertexList.Add(0, 0, 0, 0);
            pl.VertexList.Add(10, 15, 0, 0);
            pl.VertexList.Add(40, 10, 0, 0);
            pl.VertexList.Add(40, 0, 0, 0);
            pl.Flag = VectorDraw.Professional.Constants.VdConstPlineFlag.PlFlagCLOSE;


            VectorDrawCustomFigs.LabelLine LBLLine = new VectorDrawCustomFigs.LabelLine(vdFramedControl1.BaseControl.ActiveDocument);
            LBLLine.TextLabel = new VectorDraw.Professional.vdFigures.vdText(vdFramedControl1.BaseControl.ActiveDocument);
            LBLLine.TextLabel.TextString = "hello world !!";
            LBLLine.TextLabel.PenColor.FromSystemColor(Color.LawnGreen);
            LBLLine.StartPoint = new gPoint(12, -30, 0);
            LBLLine.EndPoint = new gPoint(39, -21, 0);
            LBLLine.PenColor.FromSystemColor(Color.Green);
            vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(LBLLine);

            VectorDraw.Professional.vdFigures.vdCircle c = new VectorDraw.Professional.vdFigures.vdCircle(vdFramedControl1.BaseControl.ActiveDocument, new gPoint(85.0, 40.0), 3.0);
            vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(c);

            Vertexes verts = new Vertexes ();
            verts.Add (new gPoint (134.0,-11.0));
            verts.Add (new gPoint (148.0,-6.0));
            verts.Add (new gPoint (161.0,-28.0));
            verts.Add(new gPoint(143.0, -30.0));
            VectorDraw.Professional.vdFigures.vdPolyline poly = new VectorDraw.Professional.vdFigures.vdPolyline(vdFramedControl1.BaseControl.ActiveDocument, verts);
            poly.VertexList.makeClosed();
            vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(poly);

            VectorDrawCustomFigs.vdLineConnection lineconnection = new VectorDrawCustomFigs.vdLineConnection(vdFramedControl1.BaseControl.ActiveDocument);
            lineconnection.Figure1 = c;
            lineconnection.Figure2 = poly;
            vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(lineconnection);

            vdFramedControl1.BaseControl.ActiveDocument.CommandAction.Zoom("E", 0, 0);
        }

        void ActiveDocument_OnAfterOpenDocument(object sender)
        {
            VectorDraw.Professional.vdObjects.vdFilterObject filter = new VectorDraw.Professional.vdObjects.vdFilterObject();
            filter.XProperties.AddItem("vdRealPosition");
            filter.NestedObjects = true;

            VectorDraw.Professional.vdCollections.vdSelection selset = new VectorDraw.Professional.vdCollections.vdSelection("Myselset");
            selset.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            selset.FilterSelect(filter);

            //These two arrays are being used to insert the object at it's original position.
            //Note that the insertion must be commited after the extra objects are erased(see below).
            //Also note that if other custom objects are present in the Document and are not being used in this way then the object's real position
            //will not be exactly correct since other objects will be added to the Document when it is saved.
            VectorDraw.Generics.vdArray<VectorDraw.Professional.vdPrimaries.vdFigure> figurearray = new VectorDraw.Generics.vdArray<VectorDraw.Professional.vdPrimaries.vdFigure>();
            VectorDraw.Generics.vdArray<int> positionarray = new VectorDraw.Generics.vdArray<int>();
            int NumberOfExplodedEntities = 0;

            if (selset.Count > 0)
            {
                foreach (VectorDraw.Professional.vdPrimaries.vdFigure var in selset)
                {
                    VectorDrawCustomFigs.VectorDrawOffsetLine mline = new VectorDrawCustomFigs.VectorDrawOffsetLine(vdFramedControl1.BaseControl.ActiveDocument);
                    mline.MatchProperties(var, vdFramedControl1.BaseControl.ActiveDocument);
                    mline.XProperties.RemoveItem (mline.XProperties.FindName ("NumLines"));
                    mline.XProperties.RemoveItem (mline.XProperties.FindName ("LinesColor"));
                    mline.XProperties.RemoveItem (mline.XProperties.FindName ("LinesDistance"));
                    mline.XProperties.RemoveItem (mline.XProperties.FindName ("vdRealPosition"));
                    mline.XProperties.RemoveItem(mline.XProperties.FindName("PenColor"));
                    mline.XProperties.RemoveItem (mline.XProperties.FindName ("vdDWGXprop"));
                    

                    VectorDraw.Professional.vdObjects.vdXProperty xprop = var.XProperties.FindName("NumLines");
                    int numlines = (int)xprop.PropValue;
                    mline.NumOfLines = numlines;

                    xprop = var.XProperties.FindName("LinesColor");
                    int linescolor = (int)xprop.PropValue;
                    mline.LinesColor = new VectorDraw.Professional.vdObjects.vdColor();
                    mline.LinesColor.FromInt32(linescolor);

                    xprop = var.XProperties.FindName("PenColor");
                    int pencolor = (int)xprop.PropValue;
                    mline.PenColor.FromInt32(pencolor);

                    xprop = var.XProperties.FindName("LinesDistance");
                    double linesdistance = (double)xprop.PropValue;
                    mline.LinesDistance = linesdistance;

                    xprop = var.XProperties.FindName("vdRealPosition");
                    int pos = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.GetObjectRealPosition(var);

                    xprop = var.XProperties.FindName("NumberOfExplodedEntities");
                    if (xprop!= null) NumberOfExplodedEntities = (int)xprop.PropValue;

                    VectorDraw.Professional.vdCollections.vdEntities ents = var.Owner as VectorDraw.Professional.vdCollections.vdEntities;
                    if (ents != null && ents.Count > 0)
                    {
                        figurearray.AddItem (mline);
                        positionarray.AddItem(pos);
                        ents.AddItem(mline);
                    }
                }                
            }




            filter = new VectorDraw.Professional.vdObjects.vdFilterObject();
            filter.XProperties.AddItem("vdDWGXprop");
            filter.NestedObjects = true;

            selset.RemoveAll();
            selset.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            selset.FilterSelect(filter);

            if (selset.Count > 0)
            {
                int count = 0;
                foreach (VectorDraw.Professional.vdPrimaries.vdFigure var in figurearray)
                {
                    int pos = positionarray[count];
                    VectorDraw.Professional.vdCollections.vdEntities ents = var.Owner as VectorDraw.Professional.vdCollections.vdEntities;
                    if (ents == null) ents = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities;
                    if (ents != null && ents.Count > 0)
                    {
                        ents.RemoveItem(var);
                        if (ents.Count < pos)
                            ents.AddItem(var);
                        else
                        {
                            ents.InsertAt(pos, var);
                            for (int i = pos+1; i < pos + NumberOfExplodedEntities; i++)
                            {
                                ents[i].Deleted = true;
                            }
                        }
                    }
                    count++;
                }


                vdFramedControl1.BaseControl.ActiveDocument.ClearEraseItems();

            }

        }
    }
}