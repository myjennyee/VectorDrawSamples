using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NoGraphicsExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Form
        private void CreateForm()
        {
            VectorDraw.Professional.vdFigures.vdRect rect = new VectorDraw.Professional.vdFigures.vdRect();
            rect.SetUnRegisterDocument(vdDocumentComponent1.Document);
            rect.setDocumentDefaults();
            rect.InsertionPoint = new VectorDraw.Geometry.gPoint();
            rect.Width = 120;
            rect.Height = 240;
            vdDocumentComponent1.Document.Model.Entities.AddItem(rect);

            rect = new VectorDraw.Professional.vdFigures.vdRect();
            rect.SetUnRegisterDocument(vdDocumentComponent1.Document);
            rect.setDocumentDefaults();
            rect.InsertionPoint = new VectorDraw.Geometry.gPoint(-5.0,-5.0);
            rect.Width = 130.0;
            rect.Height = 250.0;
            vdDocumentComponent1.Document.Model.Entities.AddItem(rect);

            rect = new VectorDraw.Professional.vdFigures.vdRect();
            rect.SetUnRegisterDocument(vdDocumentComponent1.Document);
            rect.setDocumentDefaults();
            rect.InsertionPoint = new VectorDraw.Geometry.gPoint(65.0, 0.0);
            rect.Width = 55.0;
            rect.Height = 30.0;
            vdDocumentComponent1.Document.Model.Entities.AddItem(rect);

            VectorDraw.Professional.vdFigures.vdMText Signature = new VectorDraw.Professional.vdFigures.vdMText();
            Signature.SetUnRegisterDocument(vdDocumentComponent1.Document);
            Signature.setDocumentDefaults();
            Signature.InsertionPoint = new VectorDraw.Geometry.gPoint(93.0, 25.0);
            Signature.TextString = "\\C1;VectorDraw\nPlatonos 1 - Dafni - 17234\nPhone : 210-9739781\nFAX:210-9739159";
            Signature.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter;
            vdDocumentComponent1.Document.Model.Entities.AddItem(Signature);

            UpdatePicture();
        }
        private void UpdatePicture()
        {
            if (picPrev1.Width == 0 || picPrev1.Height == 0) return;

            vdDocumentComponent1.Document.CommandAction.CmdSelect("ALL");
            VectorDraw.Professional.vdCollections.vdSelection selset = vdDocumentComponent1.Document.Selections.FindName("VDRAW_PREVIOUS_SELSET");
            VectorDraw.Geometry.Box Bbox = selset.GetBoundingBox();
            Bbox.AddWidth(5.0);

            Image img1 = new Bitmap(picPrev1.Width, picPrev1.Height);
            System.Drawing.Graphics graph = Graphics.FromImage(img1);
            Bbox.TransformBy(vdDocumentComponent1.Document.ActiveLayOut.World2ViewMatrix);
            vdDocumentComponent1.Document.ActiveLayOut.RenderToGraphics(graph, Bbox, img1.Width, img1.Height);
            picPrev1.Image = img1;
        }
        #endregion

        #region Buttons
        private void butExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void butExport_Click(object sender, EventArgs e)
        {
            vdDocumentComponent1.Document.SaveAs(Application.ExecutablePath.Substring(0, Application.ExecutablePath.Length - 4) + ".svg");
            vdDocumentComponent1.Document.SaveAs(Application.ExecutablePath.Substring(0, Application.ExecutablePath.Length - 4) + ".bmp");
            vdDocumentComponent1.Document.SaveAs(Application.ExecutablePath.Substring(0, Application.ExecutablePath.Length - 4) + ".jpg");
            vdDocumentComponent1.Document.SaveAs(Application.ExecutablePath.Substring(0, Application.ExecutablePath.Length - 4) + ".png");

            vdDocumentComponent1.Document.Model.Printer.PrinterName = Application.ExecutablePath.Substring(0, Application.ExecutablePath.Length - 4) + ".pdf";
            vdDocumentComponent1.Document.Model.Printer.PrintExtents();
            vdDocumentComponent1.Document.Model.Printer.PrintWindow.AddWidth(5.0);
            vdDocumentComponent1.Document.Model.Printer.PrintScaleToFit();
            vdDocumentComponent1.Document.Model.Printer.PrintOut();

            vdDocumentComponent1.Document.Model.Printer.PrinterName = Application.ExecutablePath.Substring(0, Application.ExecutablePath.Length - 4) + ".emf";
            vdDocumentComponent1.Document.Model.Printer.PrintExtents();
            vdDocumentComponent1.Document.Model.Printer.PrintScaleToFit();
            vdDocumentComponent1.Document.Model.Printer.PrintOut();

            MessageBox.Show("6 Files have been created : PDF,EMF,SVG,BMP,JPG,PNG to tha application's path.");
        }
        #endregion

        #region Events
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateForm();
            MessageBox.Show("This sample does not contain any .NET graphical component. It contains only a vdDocument component which does all the work.");
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            UpdatePicture();
        }
        #endregion
    }
}