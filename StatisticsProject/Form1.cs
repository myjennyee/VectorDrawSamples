using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

///Description:

///In this example is demonstrated how someone can use VectorDraw in order to present statistical information using charts. How, by using simple vdObjects,
///more complex shapes and charts can be created. How to convert 2D objects to 3D or combine 2D objects to make 3D shapes. In more detail, this example demonstrates
///the use of the vdPolyLine, the vdGroundSurface, the vdPolyFace, among others and how they can be used to create 3D displays. Furthermore is demonstrated
///how to insert and modify images into a Vector Draw control. Everything mentioned above, are used in order to create 2D and 3D Graphic Charts and geometrical shapes.

///Use:

///While running the example, you'll notice a Tabbed panel. Every panel is titled after a specific chart. When selecting a Tab, the described chart is drawn in
///the VectorDraw BaseControl. The values of the Chart are being extracted from the DataGrid on the right of the Panel. When selecting a tab, default values are
///inserted in the DataGrid, but if desired, the DataGrid values can be changed. By pressing the "Redraw Chart" Button, a new Chart will be drawn using the new
///values. Finally, there is the "3D Chart" CheckBox that, as its name states, when checked the Chart drawn is in 3D.

namespace StatisticsProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Pie Chart
        //This method is used to convert the percentages to rads in order to create the vdPolyLine object.
        private double PercToRads(double percentage)
        {
            return (360 * percentage / 100 * 0.01744);
        }
        //This method creates a part of a circle, the angle of the part will span from the angleStart parameter to the angleEnd one. The color of the part
        //is defined by the three r, g, b parameters, representing the three values of the RGB color map. Finally, it places the title of the Chart part next
        //to the part.
        private void CreatePiePart(double angleStart, double angleEnd, int r, int g, int b, string title)
        {
            VectorDraw.Professional.vdFigures.vdMText text = new VectorDraw.Professional.vdFigures.vdMText();
            text.SetUnRegisterDocument(BaseControl.ActiveDocument);
            text.setDocumentDefaults();
            text.TextString = title;
            text.Height = 0.5;
            //The vdMText object is colored slightly darker than the chart part in order to be easily readable.
            text.PenColor = new VectorDraw.Professional.vdObjects.vdColor(Color.FromArgb(r - 40, g - 40, b - 40));
            text.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter;
            text.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen;
            //The InsertionPoint of the vdMText is located on the bisector of the Pie Chart part, thus being above the center of the part's circumference.
            text.InsertionPoint = new VectorDraw.Geometry.gPoint(Math.Cos((angleEnd - angleStart) / 2 + angleStart) * 4.5, Math.Sin((angleEnd - angleStart) / 2 + angleStart) * 4.5, 3);
            text.Update();

            VectorDraw.Professional.vdFigures.vdPolyline polyline = new VectorDraw.Professional.vdFigures.vdPolyline();
            polyline.SetUnRegisterDocument(BaseControl.ActiveDocument);
            polyline.setDocumentDefaults();
            //The vdPolyLine object we are using to create the Pie Chart part has 5 Vertexes in its VertexList.
            polyline.VertexList.Add(Math.Cos(angleStart), Math.Sin(angleStart), 0, 0);
            polyline.VertexList.Add(0, 0, 0, 0);
            //The bulge of this Vertex is calculated in order to be the same as of a circle would. You can fine more info about the bulge calculation in the 
            //.chm Help file.
            polyline.VertexList.Add(Math.Cos(angleEnd), Math.Sin(angleEnd), 0, -Math.Tan((angleEnd - angleStart) / 4 / 2));
            //This Vertex is located in the middle between of the part's circumference. This insures that the bulge of the vdPolyLine will be correct.
            polyline.VertexList.Add(Math.Cos((angleEnd - angleStart) / 2 + angleStart), Math.Sin((angleEnd - angleStart) / 2 + angleStart), 0, -Math.Tan((angleEnd - angleStart) / 4 / 2));
            //The first and last Vertex concur.
            polyline.VertexList.Add(Math.Cos(angleStart), Math.Sin(angleStart), 0, 0);
            Color c = Color.FromArgb(r, g, b);
            polyline.PenColor = new VectorDraw.Professional.vdObjects.vdColor(c);
            polyline.Update();

            VectorDraw.Geometry.Matrix mat = new VectorDraw.Geometry.Matrix();
            mat.ScaleMatrix(3, 3, 0);
            mat.TranslateMatrix(Math.Cos((angleEnd - angleStart) / 2 + angleStart) / 5, Math.Sin((angleEnd - angleStart) / 2 + angleStart) / 5, 0);
            //If the chart3DCheckBox is checked, a 3D Chart will be created.
            if (!chart3DCheckBox.Checked)
            {
                polyline.Thickness = 0;
                polyline.Transformby(mat);
                //Using the method of the CommandAction a vdPolyFace object is created and inserted in the Entities of the ActiveDocument, without actually
                // adding it. The vdPolyLine will not be added.
                BaseControl.ActiveDocument.CommandAction.CmdPlineToMesh(polyline, 0.0, "y");
            }
            else
            {
                polyline.Thickness = 1;
                mat.RotateXMatrix(-0.35);
                mat.RotateYMatrix(-0.20);
                polyline.Transformby(mat);
                //Using the method of the CommandAction a vdPolyFace object is created and inserted in the Entities of the ActiveDocument, without actually
                // adding it. The vdPolyLine will not be added.
                BaseControl.ActiveDocument.CommandAction.CmdPlineToMesh(polyline, 1.0, "y");
            }
            //After the Pie Chart part is inserted as a vdPolyFace object, only the title need to be added.
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(text);
        }
        //This method is used to create all the needed Pie Chart parts so that a whole Pie Chart will be designed.
        private void MakePie(string[] title, double[] percentage)
        {
            int pieParts = percentage.Length;
            double totalRands = 0;
            Random randomize = new Random();
            //This loop is used to create a random color in order to draw our Pie Chart part using that.
            for (int i = 0; i < pieParts; i++)
            {
                int randomR = (int)randomize.Next(41, 200);
                int randomG = (int)randomize.Next(41, 200);
                int randomB = (int)randomize.Next(41, 200);
                CreatePiePart(totalRands, totalRands + PercToRads(percentage[i]), randomR, randomG, randomB, title[i] + "\n" + percentage[i] + "%");
                totalRands += PercToRads(percentage[i]);
            }
        }
        //This method creates a new Document to the BaseControl, accesses the data in the DataGrid and calls the method to create the Chart.
        private void DrawPieChart()
        {
            BaseControl.ActiveDocument.New();
            BaseControl.ActiveDocument.ActiveLayOut.BkColorEx = Color.Gainsboro;
            BaseControl.ActiveDocument.ShowUCSAxis = false;
            BaseControl.ActiveDocument.CommandAction.View3D("RENDER");
            int piePieces = DataGrid.RowCount;
            piePieces--;
            double[] percentages = new double[piePieces];
            string[] titles = new string[piePieces];
            for (int i = 0; i < piePieces; i++)
            {
                try { percentages[i] = double.Parse(DataGrid[1, i].Value.ToString()); }
                catch { percentages[i] = 0; }
                titles[i] = DataGrid[0, i].Value.ToString();
            }
            VectorDraw.Geometry.Matrix mat = new VectorDraw.Geometry.Matrix();
            BaseControl.ActiveDocument.Model.World2ViewMatrix = mat;
            MakePie(titles, percentages);
            BaseControl.ActiveDocument.ActiveLayOut.ZoomExtents();
            BaseControl.ActiveDocument.Redraw(false);
        }
        #endregion
        #region Bar Chart
        //This method creates a part of a bar, the height of the part will be relative to the percentage it represents. The color of the part
        //is defined by the three r, g, b parameters, representing the three values of the RGB color map. Finally, it places the title of the Chart part next
        //to the part, to the left or the right, depending on the left parameter.
        private void CreateBarPart(double totalPercentage, double percentage, string title, int r, int g, int b, bool left)
        {
            VectorDraw.Professional.vdFigures.vdRect rect = new VectorDraw.Professional.vdFigures.vdRect();
            rect.SetUnRegisterDocument(BaseControl.ActiveDocument);
            rect.setDocumentDefaults();
            rect.InsertionPoint = new VectorDraw.Geometry.gPoint(-1, -4.5 + totalPercentage * 0.1);
            rect.Height = percentage * 0.1;
            rect.Width = 2;
            rect.HatchProperties = new VectorDraw.Professional.vdObjects.vdHatchProperties();
            //HatchProperties.FillMode defines the way the vdRect object will be filled. The VdFillModeSolid selection will fill it with a solid color.
            rect.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid;
            rect.HatchProperties.FillColor = new VectorDraw.Professional.vdObjects.vdColor(Color.FromArgb(r, g, b));
            rect.PenColor = new VectorDraw.Professional.vdObjects.vdColor(Color.Black);

            VectorDraw.Professional.vdFigures.vdMText text = new VectorDraw.Professional.vdFigures.vdMText();
            text.SetUnRegisterDocument(BaseControl.ActiveDocument);
            text.setDocumentDefaults();
            text.TextString = title;
            text.Height = 0.4;
            text.PenColor = new VectorDraw.Professional.vdObjects.vdColor(Color.FromArgb(r - 30, g - 30, b - 30));
            text.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen;
            //This condition makes sure the title of the part will be placed on the left and right of the Bar Chart alternately.
            if (left)
            {
                text.InsertionPoint = new VectorDraw.Geometry.gPoint(-1.5, rect.InsertionPoint.y + rect.Height / 2);
                text.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorRight;
            }
            else
            {
                text.InsertionPoint = new VectorDraw.Geometry.gPoint(1.5, rect.InsertionPoint.y + rect.Height / 2);
                text.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorLeft;
            }
            text.Update();
            //If the chart3dCeckBox is checked, we are drawing a 3D chart;
            if (chart3DCheckBox.Checked == true)
            {
                VectorDraw.Professional.vdFigures.vdPolyface face = new VectorDraw.Professional.vdFigures.vdPolyface();
                face.SetUnRegisterDocument(BaseControl.ActiveDocument);
                face.setDocumentDefaults();
                face.PenColor = new VectorDraw.Professional.vdObjects.vdColor(Color.FromArgb(r, g, b));

                VectorDraw.Professional.vdFigures.vdLine line = new VectorDraw.Professional.vdFigures.vdLine();
                line.EndPoint = new VectorDraw.Geometry.gPoint(0, 0, -2);
                //Using the method of the CommandAction a vdPolyFace object is created and inserted in the Entities of the ActiveDocument, without actually
                // adding it. The vdRect will not be added.
                face.Generate3dPathSection(line, rect, new VectorDraw.Geometry.gPoint(), 0, 1);
                //Using the Matrix object (mat), the vdPolyFace can be rotated accordingly.
                VectorDraw.Geometry.Matrix mat = new VectorDraw.Geometry.Matrix();
                mat.RotateYMatrix(-0.20);
                mat.RotateXMatrix(0.1);
                face.Transformby(mat);
                BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(face);
            }
            else
                //If a 2D chart is being drawn, we insert the vdRect object instead.
                BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(rect);
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(text);
        }
        //This method is used to create all the needed Bar Chart parts so that a whole Bar Chart will be designed.
        private void MakeBar(string[] titles, double[] percentages)
        {
            int barParts = percentages.Length;
            double totalPercentage = 0;
            Random randomize = new Random();
            //This loop is used to create a random color in order to draw the Bar Chart part using that.
            for (int i = 0; i < barParts; i++)
            {
                int randomR = (int)randomize.Next(31, 200);
                int randomG = (int)randomize.Next(31, 200);
                int randomB = (int)randomize.Next(31, 200);
                if ((i % 2) == 0)
                    CreateBarPart(totalPercentage, percentages[i], titles[i] + "\n" + percentages[i] + "%", randomR, randomG, randomB, true);
                else
                    CreateBarPart(totalPercentage, percentages[i], titles[i] + "\n" + percentages[i] + "%", randomR, randomG, randomB, false);
                totalPercentage += percentages[i];
            }
        }
        //This method creates a new Document to the BaseControl, accesses the data in the DataGrid and calls the method to create the Chart.
        private void DrawBarChart()
        {
            BaseControl.ActiveDocument.New();
            BaseControl.ActiveDocument.ActiveLayOut.BkColorEx = Color.Gainsboro;
            BaseControl.ActiveDocument.ShowUCSAxis = false;
            BaseControl.ActiveDocument.CommandAction.View3D("RENDER");
            int barPieces = DataGrid.RowCount;
            barPieces--;
            double[] percentages = new double[barPieces];
            string[] titles = new string[barPieces];
            for (int i = 0; i < barPieces; i++)
            {
                try { percentages[i] = double.Parse(DataGrid[1, i].Value.ToString()); }
                catch { percentages[i] = 0; }
                titles[i] = DataGrid[0, i].Value.ToString();
            }
            VectorDraw.Geometry.Matrix mat = new VectorDraw.Geometry.Matrix();
            BaseControl.ActiveDocument.Model.World2ViewMatrix = mat;
            MakeBar(titles, percentages);
            BaseControl.ActiveDocument.ActiveLayOut.ZoomExtents();
            BaseControl.ActiveDocument.Redraw(false);
        }
#endregion
        #region Line Chart
        //This method is used to create the X and Y axes the Line Chart will be created upon.
        private void CreateLineAxis(string labelX, string labelY, double maxValue)
        {
            VectorDraw.Professional.vdFigures.vdLine xAxis = new VectorDraw.Professional.vdFigures.vdLine();
            xAxis.SetUnRegisterDocument(BaseControl.ActiveDocument);
            xAxis.setDocumentDefaults();
            xAxis.StartPoint = new VectorDraw.Geometry.gPoint(-0.5, 0, -1);
            xAxis.EndPoint = new VectorDraw.Geometry.gPoint(10, 0, -1);
            xAxis.PenColor = new VectorDraw.Professional.vdObjects.vdColor(Color.Gray);
            VectorDraw.Professional.vdFigures.vdLine yAxis = new VectorDraw.Professional.vdFigures.vdLine();
            yAxis.SetUnRegisterDocument(BaseControl.ActiveDocument);
            yAxis.setDocumentDefaults();
            yAxis.StartPoint = new VectorDraw.Geometry.gPoint(0, -0.5, -1);
            yAxis.EndPoint = new VectorDraw.Geometry.gPoint(0, 4.95, -1);
            yAxis.PenColor = new VectorDraw.Professional.vdObjects.vdColor(Color.Gray);
            VectorDraw.Professional.vdFigures.vdText textX = new VectorDraw.Professional.vdFigures.vdText();
            textX.SetUnRegisterDocument(BaseControl.ActiveDocument);
            textX.setDocumentDefaults();
            textX.TextString = labelX;
            textX.Height = 0.3;
            textX.PenColor = new VectorDraw.Professional.vdObjects.vdColor(Color.Black);
            textX.InsertionPoint = new VectorDraw.Geometry.gPoint(xAxis.EndPoint.x, yAxis.StartPoint.y, -1);
            VectorDraw.Professional.vdFigures.vdText textY = new VectorDraw.Professional.vdFigures.vdText();
            textY.SetUnRegisterDocument(BaseControl.ActiveDocument);
            textY.setDocumentDefaults();
            textY.TextString = labelY;
            textY.Height = 0.3;
            textY.PenColor = new VectorDraw.Professional.vdObjects.vdColor(Color.Black);
            textY.InsertionPoint = new VectorDraw.Geometry.gPoint(xAxis.StartPoint.x, yAxis.EndPoint.y + 0.5, -1);
            //If the chart3DCheckBox is checked, we are drawing a 3D chart.
            if (chart3DCheckBox.Checked)
            {
                xAxis.Thickness = 3;
                xAxis.StartPoint = new VectorDraw.Geometry.gPoint(0, 0, -1);
                //Since the chart is in 3D, the Y axis will be replaced with an image and the X axis will be thickened.
                yAxis.Deleted = true;
                //A backround image will be added to be easier to read the chart in 3D.
                VectorDraw.Professional.vdPrimaries.vdImageDef img = new VectorDraw.Professional.vdPrimaries.vdImageDef();
                img.FileName = "line_chart_backround_with_lines.jpg";
                img.Name = "backroundImage";
                //When using an image in Vector Draw, we need to add it to the Images of the ActiveDocument.
                BaseControl.ActiveDocument.Images.AddItem(img);
                VectorDraw.Professional.vdFigures.vdImage imageBack = new VectorDraw.Professional.vdFigures.vdImage();
                imageBack.SetUnRegisterDocument(BaseControl.ActiveDocument);
                imageBack.setDocumentDefaults();
                imageBack.ImageDefinition = img;
                imageBack.InsertionPoint = new VectorDraw.Geometry.gPoint(0, 0, -1);
                imageBack.Height = 4.95;
                BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(imageBack);
                VectorDraw.Professional.vdPrimaries.vdImageDef img2 = new VectorDraw.Professional.vdPrimaries.vdImageDef();
                img2.FileName = "line_chart_Y_with_lines.jpg";
                img2.Name = "yAxisImage";
                BaseControl.ActiveDocument.Images.AddItem(img2);
                VectorDraw.Professional.vdFigures.vdImage imageY = new VectorDraw.Professional.vdFigures.vdImage();
                imageY.SetUnRegisterDocument(BaseControl.ActiveDocument);
                imageY.setDocumentDefaults();
                imageY.ImageDefinition = img2;
                imageY.InsertionPoint = new VectorDraw.Geometry.gPoint(0, 0, 0);
                imageY.Height = 4.95;
                VectorDraw.Geometry.Matrix mat = new VectorDraw.Geometry.Matrix();
                mat.RotateYMatrix(3.15 / 2);
                mat.TranslateMatrix(0, 0, 2);
                //Be default the image is inserted in the level created by the X and Y axes, so we need to modify it's rotation by using a Matrix object.
                imageY.Transformby(mat);
                BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(imageY);
                //In order the 3D effect to be visible, the chart must be viewd from a diagonal angle. Using the Matrix object (mat) the World View Matrix is
                //rotated accordingly.
                mat = new VectorDraw.Geometry.Matrix();
                mat.RotateYMatrix(-0.4);
                mat.RotateXMatrix(0.2);
                BaseControl.ActiveDocument.Model.World2ViewMatrix = mat;
            }
            //This loop is used to place the values on the Y axis. A slightly higher value of the max value given by the DataGrid is used as the highest
            //point on the Y axis. The bottom is 0, but someone could easily extend the value span to the other quadrants of the Cartesian system.
            for (int i = 0; i <= 11; i++)
            {
                VectorDraw.Professional.vdFigures.vdText txt = new VectorDraw.Professional.vdFigures.vdText();
                txt.SetUnRegisterDocument(BaseControl.ActiveDocument);
                txt.setDocumentDefaults();
                txt.Height = 0.2;
                txt.TextString = (maxValue * i / 10).ToString();
                txt.PenColor = new VectorDraw.Professional.vdObjects.vdColor(Color.Black);
                if (i == 0 && !chart3DCheckBox.Checked)
                    //This condition makes sure the value 0 will be places to the lowest, left corner of the axes we drew.
                    txt.InsertionPoint = new VectorDraw.Geometry.gPoint(-0.3, -0.3, -1);
                else
                    //If not 0, the values are placed upon the Y axis to the corresponding height.
                    txt.InsertionPoint = new VectorDraw.Geometry.gPoint(-0.3, 0.45 * i, -1);
                txt.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorRight;
                if (chart3DCheckBox.Checked)
                {
                    txt.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerBottom;
                    VectorDraw.Geometry.Matrix mat = new VectorDraw.Geometry.Matrix();
                    //If the chart is in 3D, the values are relocated to the right of the Chart axes, in order to be visible.
                    mat.TranslateMatrix(10.2, 0, 0.05);
                    txt.Transformby(mat);
                }
                else
                {
                    txt.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen;
                    //If in 2D, small lines are placed on the Y axis.
                    VectorDraw.Professional.vdFigures.vdLine line = new VectorDraw.Professional.vdFigures.vdLine();
                    line.SetUnRegisterDocument(BaseControl.ActiveDocument);
                    line.setDocumentDefaults();
                    line.PenColor = new VectorDraw.Professional.vdObjects.vdColor(Color.Gray);
                    line.StartPoint = new VectorDraw.Geometry.gPoint(-0.1, txt.InsertionPoint.y, -1);
                    line.EndPoint = new VectorDraw.Geometry.gPoint(0.1, txt.InsertionPoint.y, -1);
                    //No line needs to be added for 0.
                    if (i != 0)
                        BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(line);
                }
                BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(txt);
            }
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(xAxis);
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(yAxis);
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textX);
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textY);
        }
        //This method places a small vdCircle to the point a value indicates and returns that point.
        private VectorDraw.Geometry.gPoint placePoint(double x, double y, Color c)
        {
            VectorDraw.Professional.vdFigures.vdCircle circle = new VectorDraw.Professional.vdFigures.vdCircle();
            circle.SetUnRegisterDocument(BaseControl.ActiveDocument);
            circle.setDocumentDefaults();
            circle.Radius = 0.08;
            VectorDraw.Professional.vdObjects.vdHatchProperties hp = new VectorDraw.Professional.vdObjects.vdHatchProperties();
            hp.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid;
            //The vdCircle is filled with the same color as its PenColo.
            hp.FillColor = new VectorDraw.Professional.vdObjects.vdColor(c);
            circle.HatchProperties = hp;
            //The center of the circle is the center of the point the value indicates.
            circle.Center = new VectorDraw.Geometry.gPoint(x, y);
            circle.PenColor = new VectorDraw.Professional.vdObjects.vdColor(c);

            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(circle);
            return circle.Center;
        }
        //This method is used to create all the needed points as well as the vdPolyLine, so that a Line Chart will be designed.
        private void CreateLine(string[] titles, double[] values, Color c)
        {
            int valuesNum = values.Length;
            //In this xGap variable is stored the space between two consecutive points projected on the X axis. Using this variable, all the points of the chart
            //have the appropriate x value.
            double xGap = 10.0 / valuesNum;
            double maxValue = 0;
            for (int i = 0; i < valuesNum; i++)
                if (values[i] > maxValue)
                    maxValue = values[i];
            maxValue = Math.Round(maxValue);
            CreateLineAxis("Axis X", "Axis Y", maxValue);
            //This vdPolyLine object (connector) will connect all the points that we will place in the Chart.
            VectorDraw.Professional.vdFigures.vdPolyline connector = new VectorDraw.Professional.vdFigures.vdPolyline();
            connector.SetUnRegisterDocument(BaseControl.ActiveDocument);
            connector.setDocumentDefaults();
            connector.PenWidth = 0.08;
            connector.PenColor = new VectorDraw.Professional.vdObjects.vdColor(c);
            //This loop will place the title of every point in the right place on the X axis.
            for (int i = 0; i < valuesNum; i++)
            {
                VectorDraw.Professional.vdFigures.vdText title = new VectorDraw.Professional.vdFigures.vdText();
                title.SetUnRegisterDocument(BaseControl.ActiveDocument);
                title.setDocumentDefaults();
                title.PenColor = new VectorDraw.Professional.vdObjects.vdColor(Color.Black);
                title.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorRight;
                title.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen;
                title.Rotation = 3.14 / 3;
                title.Height = 0.2;
                title.TextString = titles[i];
                if (chart3DCheckBox.Checked)
                    //If we are drawing a 3D chart we'll just insert the vdPolyLine object.
                    connector.VertexList.Add(new VectorDraw.Geometry.gPoint(xGap / 2 + (i * xGap), values[i] * (4.5 / maxValue)));
                else
                {
                    //If we are drawing a 3d chart we'll insert the vdPolyLine and the points for every value.
                    connector.VertexList.Add(placePoint(xGap / 2 + (i * xGap), values[i] * (4.5 / maxValue), c));
                    title.InsertionPoint = new VectorDraw.Geometry.gPoint(connector.VertexList[i].x, -0.1);
                    BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(title);
                }
            }
            if (chart3DCheckBox.Checked)
                //If we are drawing a 3D chart, we add thickness to the vdPolyLine object.
                connector.Thickness = 1;
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(connector);
            BaseControl.ActiveDocument.ActiveLayOut.Entities.InsertAt(0, connector);
        }
        //This method creates a new Document to the BaseControl, accesses the data in the DataGrid and calls the method to create the Chart.
        private void DrawLineChart()
        {
            BaseControl.ActiveDocument.New();
            BaseControl.ActiveDocument.ActiveLayOut.BkColorEx = Color.Gainsboro;
            BaseControl.ActiveDocument.ShowUCSAxis = false;
            BaseControl.ActiveDocument.CommandAction.View3D("RENDER");
            int valuesCount = DataGrid.RowCount;
            valuesCount--;
            double[] values = new double[valuesCount];
            string[] titles = new string[valuesCount];
            for (int i = 0; i < valuesCount; i++)
            {
                try { values[i] = double.Parse(DataGrid[1, i].Value.ToString()); }
                catch { values[i] = 0; }
                titles[i] = DataGrid[0, i].Value.ToString();
            }
            VectorDraw.Geometry.Matrix mat = new VectorDraw.Geometry.Matrix();
            BaseControl.ActiveDocument.Model.World2ViewMatrix = mat;
            CreateLine(titles, values, Color.Yellow);
            BaseControl.ActiveDocument.ActiveLayOut.ZoomExtents();
            BaseControl.ActiveDocument.Redraw(false);
        }
#endregion
        #region Bars Chart
        //This method creates a bar given the place on the X axis it will be created and the percentage it will represent.
        private VectorDraw.Geometry.gPoint CreateBar(double x, double percentage, double maxValue, Color c, string label)
        {
            VectorDraw.Professional.vdFigures.vdRect rect = new VectorDraw.Professional.vdFigures.vdRect();
            rect.SetUnRegisterDocument(BaseControl.ActiveDocument);
            rect.setDocumentDefaults();
            rect.InsertionPoint = new VectorDraw.Geometry.gPoint(x - 0.3, 0, -1);
            rect.Height = 4.5 / maxValue * percentage;
            rect.Width = 0.6;
            rect.HatchProperties = new VectorDraw.Professional.vdObjects.vdHatchProperties();
            //The FillMode property of the HatchProperties object defines how the vdRect is filled. In this case, it uses a solid color.
            rect.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid;
            rect.HatchProperties.FillColor = new VectorDraw.Professional.vdObjects.vdColor(c);
            rect.PenColor = new VectorDraw.Professional.vdObjects.vdColor(c);
            //If the chart3DCheckBox is selected, a 3D chart is being drawn, so we add thickness to the vdRect object.
            if (chart3DCheckBox.Checked)
                rect.Thickness = 1;
            VectorDraw.Professional.vdFigures.vdText text = new VectorDraw.Professional.vdFigures.vdText();
            text.SetUnRegisterDocument(BaseControl.ActiveDocument);
            text.setDocumentDefaults();
            text.TextString = label;
            text.InsertionPoint = new VectorDraw.Geometry.gPoint(rect.InsertionPoint.x + 0.3, rect.InsertionPoint.y);
            text.Rotation = 3.14 / 2;
            text.Height = 0.25;
            text.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen;
            text.PenColor = new VectorDraw.Professional.vdObjects.vdColor(Color.Black);
            //When drawing a 3D chart, we add some minor thickness to the text, to make it easier to read.
            if (chart3DCheckBox.Checked)
                text.Thickness = 0.01;
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(rect);
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(text);
            return rect.InsertionPoint;
        }
        //This method is used to create all the Bars needed to draw the Bars Chart.
        private void CreateBarsChart(double[] values, string[] titles)
        {
            int valueNum = values.Length;
            double maxValue = 0;
            for (int i = 0; i < valueNum; i++)
            {
                if (maxValue < values[i])
                    maxValue = values[i];
            }
            maxValue = Math.Round(maxValue);
            CreateLineAxis("X", "Y", maxValue);
            Random randomize = new Random();
            //This loop provides three random numbers so that we will get a random color to make Bar with so that Every Bar gets a different color.
            for (int i = 0; i < valueNum; i++)
            {
                int r = randomize.Next(70, 255);
                int g = randomize.Next(70, 255);
                int b = randomize.Next(70, 255);
                CreateBar(10.0 / valueNum / 2 + 9.5 / valueNum * i, values[i], maxValue, Color.FromArgb(r, g, b), titles[i]);
            }
        }
        //This method creates a new Document to the BaseControl, accesses the data in the DataGrid and calls the method to create the Chart.
        private void DrawBarsChart()
        {
            BaseControl.ActiveDocument.New();
            BaseControl.ActiveDocument.ActiveLayOut.BkColorEx = Color.Gainsboro;
            BaseControl.ActiveDocument.ShowUCSAxis = false;
            BaseControl.ActiveDocument.CommandAction.View3D("RENDER");
            int barsCount = DataGrid.RowCount;
            barsCount--;
            double[] values = new double[barsCount];
            string[] titles = new string[barsCount];
            for (int i = 0; i < barsCount; i++)
            {
                try { values[i] = double.Parse(DataGrid[1, i].Value.ToString()); }
                catch { values[i] = 0; }
                titles[i] = DataGrid[0, i].Value.ToString();
            }
            VectorDraw.Geometry.Matrix mat = new VectorDraw.Geometry.Matrix();
            BaseControl.ActiveDocument.Model.World2ViewMatrix = mat;
            CreateBarsChart(values, titles);
            BaseControl.ActiveDocument.ActiveLayOut.ZoomExtents();
            BaseControl.ActiveDocument.Redraw(false);
        }
#endregion
        #region Wave Chart
        //This method is used to create the X and Y axes the Wave Chart will be created upon.
        private void CreateWaveAxis(string labelX, string labelY, double maxValue)
        {
            VectorDraw.Professional.vdPrimaries.vdImageDef img = new VectorDraw.Professional.vdPrimaries.vdImageDef();
            img.FileName = "wave_chart_backround.jpg";
            img.Name = "backroundImage";
            //Before an image can be used, it needs to be inserted to the Images list of the ActiveDocument.
            BaseControl.ActiveDocument.Images.AddItem(img);
            VectorDraw.Professional.vdFigures.vdImage imageBack = new VectorDraw.Professional.vdFigures.vdImage();
            imageBack.SetUnRegisterDocument(BaseControl.ActiveDocument);
            imageBack.setDocumentDefaults();
            imageBack.ImageDefinition = img;
            imageBack.InsertionPoint = new VectorDraw.Geometry.gPoint(0, 0, 0);
            //When changing the Height of an image, the Width will change according to the aspect ratio, keeping the proportions intact.
            imageBack.Height = 4.95;

            VectorDraw.Geometry.Matrix mat = new VectorDraw.Geometry.Matrix();
            mat.RotateXMatrix(3.14 / 2);
            imageBack.Transformby(mat);
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(imageBack);
            VectorDraw.Professional.vdPrimaries.vdImageDef img2 = new VectorDraw.Professional.vdPrimaries.vdImageDef();
            img2.FileName = "wave_chart_Y_axis.jpg";
            img2.Name = "yAxisImage";
            BaseControl.ActiveDocument.Images.AddItem(img2);
            VectorDraw.Professional.vdFigures.vdImage imageY = new VectorDraw.Professional.vdFigures.vdImage();
            imageY.SetUnRegisterDocument(BaseControl.ActiveDocument);
            imageY.setDocumentDefaults();
            imageY.ImageDefinition = img2;
            imageY.InsertionPoint = new VectorDraw.Geometry.gPoint(0, 0, 0);
            imageY.Height = 4.95;
            mat = new VectorDraw.Geometry.Matrix();
            mat.RotateXMatrix(3.14 / 2);
            mat.RotateZMatrix(-3.14 / 2);
            imageY.Transformby(mat);
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(imageY);

            img2 = new VectorDraw.Professional.vdPrimaries.vdImageDef();
            img2.FileName = "wave_chart_bottom.jpg";
            img2.Name = "yBottomImage";
            BaseControl.ActiveDocument.Images.AddItem(img2);
            VectorDraw.Professional.vdFigures.vdImage imageBottom = new VectorDraw.Professional.vdFigures.vdImage();
            imageBottom.SetUnRegisterDocument(BaseControl.ActiveDocument);
            imageBottom.setDocumentDefaults();
            imageBottom.ImageDefinition = img2;
            imageBottom.InsertionPoint = new VectorDraw.Geometry.gPoint(0, 0, 0);
            imageBottom.Height = 4;
            mat = new VectorDraw.Geometry.Matrix();
            mat.TranslateMatrix(0, -4, 0);
            imageBottom.Transformby(mat);
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(imageBottom);

        }
        //This method creates the vdGroundSurface object with all its points that will be the wave of the Wave Chart.
        private void CreateWaveChart()
        {
            VectorDraw.Professional.vdFigures.vdGroundSurface waveChart = new VectorDraw.Professional.vdFigures.vdGroundSurface();
            waveChart.SetUnRegisterDocument(BaseControl.ActiveDocument);
            waveChart.setDocumentDefaults();
            VectorDraw.Geometry.gPoints points = new VectorDraw.Geometry.gPoints();
            for (int i = 0; i > -DataGrid.ColumnCount; i--)
            {
                for (int j = 0; j < DataGrid.RowCount - 1; j++)
                {
                    //A vdGroundSurface is very easy to create. Someone just need to provide a list of points and the vdGroudSurface will create the mesh
                    //and PolyFaces neede on its own. It is important to remember though, that the vdGroudSurface is designed to use the Z axis as the 
                    //height dimension and it's not advisable trying to rotate it.
                    points.Add(j * 0.1, i * 0.4, double.Parse(DataGrid[Math.Abs(i), j].Value.ToString()));
                }
            }
            //The DispMode property of the vdGroundSurface gives the option of the way the object will be displayed. The Mesh option allows to mofify the size of it
            //so offering more or less smoothness (the smaller the Mesh size, the smoother the surface).
            waveChart.DispMode = VectorDraw.Professional.vdFigures.vdGroundSurface.DisplayMode.Mesh;
            waveChart.MeshSize = 0.4;
            waveChart.GradientFill = true;
            //The Gradient of a vdGroundSurface colors the highest points (bigger Z value) with a color and the lower points (smaller Z value) with a different one.
            //All the points in between are colored relatively to which side are closer to.
            waveChart.GradientMaximunColor.FromRGB(42, 220, 19);
            waveChart.GradientMinimunColor.FromRGB(255, 81, 88);
            waveChart.Points = points;
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(waveChart);
        }
        //This method creates a new Document to the BaseControl, accesses the data in the DataGrid, sets the diagonal view to the Chart
        //and calls the method to create the Chart.
        private void DrawWaveChart()
        {
            BaseControl.ActiveDocument.New();
            BaseControl.ActiveDocument.ActiveLayOut.BkColorEx = Color.Gainsboro;
            BaseControl.ActiveDocument.CommandAction.View3D("RENDER");
            CreateWaveAxis("x", "y", 45);
            CreateWaveChart();
            VectorDraw.Geometry.Matrix mat = new VectorDraw.Geometry.Matrix();
            //This String (str) contains the definition of the matrix of a specific view we want to use. Using this String we create a new Matrix (mat)
            //and replace the World2ViewMatrix with this one. By replacing the World2ViewMatrix with the new Matrix (mat) we get exactly the angle, we want
            //the user to see our chart from.
            //You can find this number by doing this.
            //Go to a running vdFramedControl and adjust the camera as you wish it to be. On the Properties List to the left go to the Collections->vdViews property.
            //Create a new vdView, select the current Layout you have just edited and export the World2ViewMatrix of the vdView, using the toString method. 
            string str = "0.68563743,0.72791465,0.00644788,-1.90495088,-0.61329384,0.5728569,0.54378823,2.7252583,0.39213771,-0.37679601,0.8391977,-4.79055158,0,0,0,1";
            mat.FromString(str);
            BaseControl.ActiveDocument.Model.World2ViewMatrix = mat;
            BaseControl.ActiveDocument.Model.ZoomExtents();
            BaseControl.Redraw();
        }
#endregion
        #region Horizontal Bars Chart
        //This method is used to create all the Bars needed to draw the Horizontal Bars Chart.
        private void DrawHorBarChart()
        {
            BaseControl.ActiveDocument.New();
            BaseControl.ActiveDocument.ActiveLayOut.BkColorEx = Color.Gainsboro;
            BaseControl.ActiveDocument.ShowUCSAxis = false;
            BaseControl.ActiveDocument.CommandAction.View3D("RENDER");
            int barsCount = DataGrid.RowCount;
            barsCount--;
            double[] values = new double[barsCount];
            string[] titles = new string[barsCount];
            for (int i = 0; i < barsCount; i++)
            {
                try { values[i] = double.Parse(DataGrid[1, i].Value.ToString()); }
                catch { values[i] = 0; }
                titles[i] = DataGrid[0, i].Value.ToString();
            }
            VectorDraw.Geometry.Matrix mat = new VectorDraw.Geometry.Matrix();
            BaseControl.ActiveDocument.Model.World2ViewMatrix = mat;
            BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-2, -5.5), new VectorDraw.Geometry.gPoint(2, 5.5));
            CreateHorBarChart(values, titles);
            BaseControl.ActiveDocument.Redraw(false);
        }
        //This method is used to create the X and Y axes the Horizontal Bars Chart will be created upon.
        private void CreateHorBarsAxis(string labelX, string labelY, double maxValue)
        {
            //This method is almost identical to the CreateLineAxis. The only difference is where the labels are located, since this chart places the bars
            //horizontally unlike the BarsChart that places them vertically. For more details, see the CreateLineAxis method.
            VectorDraw.Professional.vdFigures.vdLine xAxis = new VectorDraw.Professional.vdFigures.vdLine();
            xAxis.SetUnRegisterDocument(BaseControl.ActiveDocument);
            xAxis.setDocumentDefaults();
            xAxis.StartPoint = new VectorDraw.Geometry.gPoint(-0.5, 0, 0);
            xAxis.EndPoint = new VectorDraw.Geometry.gPoint(10, 0, 0);
            xAxis.PenColor = new VectorDraw.Professional.vdObjects.vdColor(Color.Gray);
            xAxis.PenWidth = 0.1;
            VectorDraw.Professional.vdFigures.vdLine yAxis = new VectorDraw.Professional.vdFigures.vdLine();
            yAxis.SetUnRegisterDocument(BaseControl.ActiveDocument);
            yAxis.setDocumentDefaults();
            yAxis.StartPoint = new VectorDraw.Geometry.gPoint(0, -0.5, 0);
            yAxis.EndPoint = new VectorDraw.Geometry.gPoint(0, 4.95, 0);
            yAxis.PenColor = new VectorDraw.Professional.vdObjects.vdColor(Color.Gray);
            yAxis.PenWidth = 0.1;
            VectorDraw.Professional.vdFigures.vdText textX = new VectorDraw.Professional.vdFigures.vdText();
            textX.SetUnRegisterDocument(BaseControl.ActiveDocument);
            textX.setDocumentDefaults();
            textX.TextString = labelX;
            textX.Height = 0.3;
            textX.PenColor = new VectorDraw.Professional.vdObjects.vdColor(Color.Black);
            textX.InsertionPoint = new VectorDraw.Geometry.gPoint(xAxis.EndPoint.x + 0.2, yAxis.StartPoint.y, 0);
            VectorDraw.Professional.vdFigures.vdText textY = new VectorDraw.Professional.vdFigures.vdText();
            textY.SetUnRegisterDocument(BaseControl.ActiveDocument);
            textY.setDocumentDefaults();
            textY.TextString = labelY;
            textY.Height = 0.3;
            textY.PenColor = new VectorDraw.Professional.vdObjects.vdColor(Color.Black);
            textY.InsertionPoint = new VectorDraw.Geometry.gPoint(xAxis.StartPoint.x, yAxis.EndPoint.y + 0.5, 0);
            BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(yAxis.EndPoint.x - 2, yAxis.EndPoint.y - 2), new VectorDraw.Geometry.gPoint(xAxis.EndPoint.x + 2, xAxis.EndPoint.y + 2));
            VectorDraw.Geometry.Matrix matt = new VectorDraw.Geometry.Matrix();
            BaseControl.ActiveDocument.Model.World2ViewMatrix = matt;
            for (int i = 0; i <= 11; i++)
            {
                VectorDraw.Professional.vdFigures.vdText txt = new VectorDraw.Professional.vdFigures.vdText();
                txt.SetUnRegisterDocument(BaseControl.ActiveDocument);
                txt.setDocumentDefaults();
                txt.Height = 0.2;
                txt.TextString = (maxValue * i / 10).ToString();
                txt.PenColor = new VectorDraw.Professional.vdObjects.vdColor(Color.Black);
                if (i == 0)
                    txt.InsertionPoint = new VectorDraw.Geometry.gPoint(-0.3, -0.3);
                else
                {
                    txt.InsertionPoint = new VectorDraw.Geometry.gPoint(i * 10.0 / 11.0, -0.2, 0);
                    txt.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorLeft;
                    txt.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen;
                    txt.Rotation = -3.14 / 2;
                    VectorDraw.Professional.vdFigures.vdLine line = new VectorDraw.Professional.vdFigures.vdLine();
                    line.SetUnRegisterDocument(BaseControl.ActiveDocument);
                    line.setDocumentDefaults();
                    line.PenColor = new VectorDraw.Professional.vdObjects.vdColor(Color.Gray);
                    line.StartPoint = new VectorDraw.Geometry.gPoint(txt.InsertionPoint.x, -0.1, 0);
                    line.EndPoint = new VectorDraw.Geometry.gPoint(txt.InsertionPoint.x, 0.1, 0);
                    BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(line);
                }
                BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(txt);
            }
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(xAxis);
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(yAxis);
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textX);
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textY);
        }
        //This method creates a bar given the place on the Y axis it will be created and the value it represents.
        private void CreateHorBar(double y, double value, double maxValue, Color c, string label)
        {
            //This vdCircle will be the base shape the vdPolyFace will use as shape.
            VectorDraw.Professional.vdFigures.vdCircle circle = new VectorDraw.Professional.vdFigures.vdCircle();
            circle.SetUnRegisterDocument(BaseControl.ActiveDocument);
            circle.setDocumentDefaults();
            circle.Radius = 0.2;
            VectorDraw.Professional.vdObjects.vdHatchProperties hp = new VectorDraw.Professional.vdObjects.vdHatchProperties();
            hp.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid;
            circle.HatchProperties = hp;
            //This vdLine will be used to provide the path that the vdPolyFace object will be drawn on.
            VectorDraw.Professional.vdFigures.vdLine line = new VectorDraw.Professional.vdFigures.vdLine();
            line.SetUnRegisterDocument(BaseControl.ActiveDocument);
            line.setDocumentDefaults();
            line.StartPoint = new VectorDraw.Geometry.gPoint(0, y);
            line.EndPoint = new VectorDraw.Geometry.gPoint(value * 9.09 / maxValue, y);

            VectorDraw.Professional.vdFigures.vdText text = new VectorDraw.Professional.vdFigures.vdText();
            text.SetUnRegisterDocument(BaseControl.ActiveDocument);
            text.setDocumentDefaults();
            text.Height = 0.2;
            text.TextString = label;
            text.InsertionPoint = line.EndPoint;
            text.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorLeft;
            text.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen;
            text.PenColor = new VectorDraw.Professional.vdObjects.vdColor(Color.Black);
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(text);

            VectorDraw.Professional.vdFigures.vdPolyface face = new VectorDraw.Professional.vdFigures.vdPolyface();
            face.SetUnRegisterDocument(BaseControl.ActiveDocument);
            face.setDocumentDefaults();
            face.PenColor = new VectorDraw.Professional.vdObjects.vdColor(c);
            //This chart uses the Generate3dPathSection method of the vdPolyFace object, similarly to the Bar Chart. A vdCircle and a vdLine are used as parameters
            //to create a vdPolyface shaping a 3D cylinder.
            face.Generate3dPathSection(line, circle, new VectorDraw.Geometry.gPoint(), 0, 1);
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(face);
        }
        //This method creates a new Document to the BaseControl, accesses the data in the DataGrid and calls the method to create the Chart.
        private void CreateHorBarChart(double[] values, string[] titles)
        {
            int valueNum = values.Length;
            if ((valueNum % 2) == 1)
            {
                MessageBox.Show("For this chart, you need to enter an even number of values");
                return;
            }
            double maxValue = 0;
            for (int i = 0; i < valueNum; i++)
            {
                if (maxValue < values[i])
                    maxValue = values[i];
            }
            maxValue = Math.Round(maxValue);
            CreateHorBarsAxis("X", "Y", maxValue);
            //A random color is used for every two horizontal bars in this chart, by getting three random integers that represent the RGB color map.
            //The second bar is slightly darker, we achieve that by bringing all the r, g, b variables closer to 0, wich is the RBG number for Black.
            Random randomize = new Random();
            for (int i = valueNum; i >= 1; i -= 2)
            {
                int r = randomize.Next(50, 255);
                int g = randomize.Next(50, 255);
                int b = randomize.Next(50, 255);
                CreateHorBar(4.75 / valueNum * i, values[valueNum - i], maxValue, Color.FromArgb(r, g, b), titles[valueNum - i]);
                CreateHorBar(4.75 / valueNum * i - 0.4, values[valueNum - (i - 1)], maxValue, Color.FromArgb(r - 40, g - 40, b - 40), titles[valueNum - (i - 1)]);
            }
        }
#endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            //We add the "RequiredFiles" folder to the support path. This addition is made in order for our samples to get the required files from this extra folder used in distribution of our sample files.
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\RequiredFiles\\";
            BaseControl.ActiveDocument.SupportPath = path;

            //By using this method of the Base Control, we change the Mouse Pointer to the pointer of the cursor1.cur file.
            if (System.IO.Directory.Exists (path))
                BaseControl.SetCustomMousePointer(new System.Windows.Forms.Cursor(path + "cursor1.cur"));
            else
                BaseControl.SetCustomMousePointer(new System.Windows.Forms.Cursor("cursor1.cur"));

            BaseControl.ActiveDocument.ActiveLayOut.BkColorEx = Color.Gainsboro;
            BaseControl.ActiveDocument.ShowUCSAxis = false;
            BaseControl.ActiveDocument.EnableAutoGripOn = false;
            //This method shows all the objects of the ActiveDocument in RENDER mode.
            BaseControl.ActiveDocument.CommandAction.View3D("RENDER");
            DataGrid.RowCount = 9;
            DataGrid["title", 0].Value = "Label 1";
            DataGrid["percentage", 0].Value = 15.3;
            DataGrid["title", 1].Value = "Label 2";
            DataGrid["percentage", 1].Value = 8.9;
            DataGrid["title", 2].Value = "Label 3";
            DataGrid["percentage", 2].Value = 25.4;
            DataGrid["title", 3].Value = "Label 4";
            DataGrid["percentage", 3].Value = 2.6;
            DataGrid["title", 4].Value = "Label 5";
            DataGrid["percentage", 4].Value = 15.8;
            DataGrid["title", 5].Value = "Label 6";
            DataGrid["percentage", 5].Value = 8.9;
            DataGrid["title", 6].Value = "Label 7";
            DataGrid["percentage", 6].Value = 19.3;
            DataGrid["title", 7].Value = "Label 8";
            DataGrid["percentage", 7].Value = 3.8;
            DrawPieChart();
            richTextBox1.Text = "Pie Chart\n\n" +
                                "This chart is created part by part. Every part represents a " +
                                "portion of the total 100%. For every part, we use a closed " +
                                "polyline with five vertexes (the last vertex concurs with the " +
                                "first one). The angle of the polyline is calculated by the " +
                                "percentage a chart part is given. For example, a 50% chart part " +
                                "would be 180 degrees. After the polyline is created we convert " +
                                "it into a vdPolyFace object and either add thickness or not (we add thickness " +
                                "to present a 3D chart).";
            richTextBox2.Text = "Bar Chart\n\n" +
                                 "The Bar Chart again is used to represent percentages. In this " +
                                 "chart, we create a VDRect object with the solid fill mode of the " +
                                 "HatchProperties object (this fills the VDrect object with a " +
                                 "solid color instead of just drawing the outline). In case we " +
                                 "want a 2D chart, we add the VDRect object to the Entities of the " +
                                 "Document. If a 3D chart is needed, we convert the VDRect object " +
                                 "to a VDPolyface object with the Generate3dPathSection method of " +
                                 "the VDPolyface object and add the VDPolyface instead.";
            richTextBox3.Text = "Line Chart\n\n" +
                                "This chart is created in three steps. First we create the X and " +
                                "Y axes. Two VDLine objects in 2D mode, two jpg images in 3D " +
                                "mode. After we insert the axes, we create small circles in the " +
                                "appropriate spots, to represent the points of the values " +
                                "inserted in our DataGrid. Finally, we create a VDPolyline object " +
                                "that connects all the points. In 3D mode, we don't insert the " +
                                "points rather just the VDPolyline object and give it an one " +
                                "point thickness.";
            richTextBox4.Text = "Bars Chart\n\n" +
                                "The Bars Chart creates the X and Y axes the same way the Line " +
                                "Chart does. Once the axes are there, it uses VDRect objects to " +
                                "represent the values given by the DataGrid. The VDRect objects " +
                                "have a solid color using the VdFillModeSolid mode of the " +
                                "FillMode of the VDHatchProperties object. In 3D mode, we simply " +
                                "add Thickness to the VDRect object.";
            richTextBox5.Text = "Wave Chart\n\n" +
                                "This chart demonstrates how a user can visually display " +
                                "coordinates that are referring to the three dimensional axes " +
                                "system, for example the ground altitude of a part of the earth, or " +
                                "coordinates that represent the values of a sound frequency as " +
                                "time passes. This chart is very easily created by using the " +
                                "VDGroundSurface object, by adding a list of points.";
            richTextBox6.Text = "Horizontal Bars Chart\n\n" +
                                "In this Chart we use the same method (Generate3dPathSection as used in the Bar Chart) of " +
                                "the VDPolyFace object, using a circle in order to create a 3D " +
                                "cylinder. The length of the cylinder represents the value given " +
                                "in the DataGrid. The 3D object is used, even if the chart is 2D " +
                                "in its essence, to offer a nice aesthetic touch.";
            BaseControl.ActiveDocument.Redraw(false);
        }
        //This event handler makes sure that when creating a new line in the DataGrid, the content of the cells won't be NULL resulting in an Runtime Error.
        private void dataGridViewCellContentClick(object sender, EventArgs e)
        {
            DataGridView dataGrid = (DataGridView)sender;
            if (dataGrid.CurrentCell != null)
            {
                dataGrid[0, dataGrid.CurrentCell.RowIndex].Value += "";
                dataGrid[1, dataGrid.CurrentCell.RowIndex].Value += "";
            }
        }
        //This event handler is triggered whenever we change the active Tab.
        private void tabSelected(object sender, System.EventArgs e)
        {
            TabControl tc = sender as TabControl;
            //We insert random values into the DataGrid.
            if (tc.SelectedTab.Name.Equals("tabPage3") || tc.SelectedTab.Name.Equals("tabPage4") || tc.SelectedTab.Name.Equals("tabPage6"))
            {
                DataGrid.ColumnCount = 2;
                DataGrid.RowCount = 11;
                DataGrid.Columns[0].HeaderText = "Title";
                DataGrid.Columns[0].Width = 150;
                DataGrid.Columns[1].HeaderText = "Value";
                DataGrid.Columns[1].Width = 100;
                Random randomize = new Random();
                for (int i = 0; i < 10; i++)
                {
                    double value = randomize.Next(40, 100) * 0.1;
                    DataGrid[0, i].Value = "Label " + i + " - " + value;
                    DataGrid[1, i].Value = value;
                }
            }
            //Percentages are inserted into the Datagrid. The sum of those values is 100.
            else if (tc.SelectedTab.Name.Equals("tabPage1") || tc.SelectedTab.Name.Equals("tabPage2"))
            {
                DataGrid.ColumnCount = 2;
                DataGrid.RowCount = 9;
                DataGrid.Columns[0].HeaderText = "Title";
                DataGrid.Columns[0].Width = 150;
                DataGrid.Columns[1].HeaderText = "Percentage";
                DataGrid.Columns[1].Width = 100;
                DataGrid["title", 0].Value = "Label 1";
                DataGrid["percentage", 0].Value = 15.3;
                DataGrid["title", 1].Value = "Label 2 ";
                DataGrid["percentage", 1].Value = 8.9;
                DataGrid["title", 2].Value = "Label 3";
                DataGrid["percentage", 2].Value = 25.4;
                DataGrid["title", 3].Value = "Label 4";
                DataGrid["percentage", 3].Value = 2.6;
                DataGrid["title", 4].Value = "Label 5";
                DataGrid["percentage", 4].Value = 15.8;
                DataGrid["title", 5].Value = "Label 6";
                DataGrid["percentage", 5].Value = 8.9;
                DataGrid["title", 6].Value = "Label 7";
                DataGrid["percentage", 6].Value = 19.3;
                DataGrid["title", 7].Value = "Label 8";
                DataGrid["percentage", 7].Value = 3.8;
            }
            //Values that follow the pattern of the Cos and Sin functions are inserted in the DataGrid.
            else if (tc.SelectedTab.Name.Equals("tabPage5"))
            {
                DataGrid.ColumnCount = 10;
                DataGrid.RowCount = 101;
                for (int i = 1; i < 11; i++)
                {
                    DataGrid.Columns[i - 1].HeaderText = "z" + (i);
                    DataGrid.Columns[i - 1].Width = 60;
                    for (int j = 1; j < 101; j++)
                    {
                        double value = Math.Cos(j * 3.14 * 100) * (1 - (j * 0.01));
                        DataGrid[i - 1, j - 1].Value = 2 + value * Math.Cos(i * 0.628);
                    }
                }
            }
            //Depending on the Tab that is selected, the appropriate Chart is drawn.
            switch (tc.SelectedTab.Name)
            {
                case "tabPage1":
                    DrawPieChart();
                    chart3DCheckBox.Enabled = true;
                    break;
                case "tabPage2":
                    DrawBarChart();
                    chart3DCheckBox.Enabled = true;
                    break;
                case "tabPage3":
                    DrawLineChart();
                    chart3DCheckBox.Enabled = true;
                    break;
                case "tabPage4":
                    DrawBarsChart();
                    chart3DCheckBox.Enabled = true;
                    break;
                case "tabPage5":
                    DrawWaveChart();
                    chart3DCheckBox.Enabled = false;
                    break;
                case "tabPage6":
                    DrawHorBarChart();
                    chart3DCheckBox.Enabled = false;
                    break;
                default:
                    break;
            }
        }
        //Draws the appropriate Chart, according to the selected Tab.
        private void createChart_Click(object sender, EventArgs e)
        {
            //Depending on the Tab that is selected, the appropriate Chart is drawn.
            switch (tabControl1.SelectedTab.Name)
            {
                case "tabPage1":
                    DrawPieChart();
                    chart3DCheckBox.Enabled = true;
                    break;
                case "tabPage2":
                    DrawBarChart();
                    chart3DCheckBox.Enabled = true;
                    break;
                case "tabPage3":
                    DrawLineChart();
                    chart3DCheckBox.Enabled = true;
                    break;
                case "tabPage4":
                    DrawBarsChart();
                    chart3DCheckBox.Enabled = true;
                    break;
                case "tabPage5":
                    DrawWaveChart();
                    chart3DCheckBox.Enabled = false;
                    break;
                case "tabPage6":
                    DrawHorBarChart();
                    chart3DCheckBox.Enabled = false;
                    break;
                default:
                    break;
            }
        }
    }
}
