using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VectorDraw.Professional.vdFigures;
using VectorDraw.Professional.vdPrimaries;
using VectorDraw.Professional.vdCollections;
using VectorDraw.Geometry;

namespace DragDrop
{
    public partial class DragDropSample : Form
    {
        public DragDropSample()
        {
            InitializeComponent();
        }

        private void CreateSourceEntities()
        {
            //Set the axis size of the cursor smaller for better visual result.
            vdSource.ActiveDocument.GlobalRenderProperties.AxisSize  = 10;
            vdDest.ActiveDocument.GlobalRenderProperties.AxisSize = 10;

            //create entities to drop over to the Source BaseControl
            vdCircle circle = new vdCircle();
            circle.SetUnRegisterDocument(vdSource.ActiveDocument);
            circle.setDocumentDefaults();
            circle.Center = new VectorDraw.Geometry.gPoint();
            circle.Radius = vdSource.ActiveDocument.ViewSize / 4.0d;
            vdSource.ActiveDocument.ActiveLayOut.Entities.AddItem(circle);
            vdSource.Redraw();
        }

        private void DragDropSample_Load(object sender, EventArgs e)
        {
            MessageBox.Show("This Sample will NOT work on evaluation mode, because the stream methods are not allowed!!!");
            label.Text = "Click Mouse down over the top-left VectorDraw control and drag \r\n Drop on the top-right VectorDraw Control to insert the data as block \r\nor on the bottom-left button to insert the data as bitmap.\r\n\r\n You can also drag from the top left and drop to an explorer(or desktop) to create a vdml file with the destination's entities.\r\n \r\nYou can also drag a file from a file explorer and drop it to the top left Base control and it will be opened there.";
            CreateSourceEntities();

            vdSource.vdMouseDown += new VectorDraw.Professional.Control.MouseDownEventHandler(vdSource_vdMouseDown);
            vdSource.vdDragEnter += new VectorDraw.Professional.Control.DragEnterEventHandler(vdSource_vdDragEnter);
            vdSource.vdDragDrop += new VectorDraw.Professional.Control.DragDropEventHandler(vdSource_vdDragDrop);

            vdDest.vdDragEnter += new VectorDraw.Professional.Control.DragEnterEventHandler(vdDest_vdDragEnter);
            vdDest.vdDragDrop += new VectorDraw.Professional.Control.DragDropEventHandler(vdDest_vdDragDrop);
            
            ImageButton.DragEnter += new DragEventHandler(ImageButton_DragEnter);
            ImageButton.DragDrop += new DragEventHandler(ImageButton_DragDrop);
        }

        

        #region Button Control
        void ImageButton_DragDrop(object sender, DragEventArgs e)
        {//drop the bitmap image to the Button control
            System.Drawing.Bitmap bmp = e.Data.GetData(typeof(System.Drawing.Bitmap)) as System.Drawing.Bitmap;
            if (bmp == null) return;
            ImageButton.Image = bmp;
        }

        void ImageButton_DragEnter(object sender, DragEventArgs e)
        {//allow drop for the Image to the Button control
            e.Effect = DragDropEffects.Copy;
        }
        #endregion

        #region Source BaseControl
        void vdSource_vdDragEnter(DragEventArgs drgevent, ref bool cancel)
        {//Show the copy drag icon to the source control. This means that also accepts drag objects.
            drgevent.Effect = DragDropEffects.Copy;
        }

        void vdSource_vdDragDrop(DragEventArgs drgevent, ref bool cancel)
        {
            //by default VectorDraw attaches the dropped file as xref to the current file. We will change
            //this behaviour in order to open the dropped file.
            cancel = true;
            System.Windows.Forms.DataObject dataobject = new DataObject(drgevent.Data);
            System.Collections.Specialized.StringCollection strings = dataobject.GetFileDropList();
            bool success = vdSource.ActiveDocument.Open(strings[0]);
            vdSource.ActiveDocument.Redraw(false);
            if (!success)
                MessageBox.Show("The file could not be opened");
        }

        void vdSource_vdMouseDown(MouseEventArgs e, ref bool cancel)
        {//begin a drag drop to the Source BaseCotnrol
            if (e.Button == MouseButtons.Left)
            {
                cancel = true;
                vdSelection set = vdSource.ActiveDocument.Selections.Add("dragdrop");
                set.RemoveAll();
                set.Select(VectorDraw.Render.RenderSelect.SelectingMode.All, null);
                Box setBound = set.GetBoundingBox();
                gPoint dragOrigin = setBound.MidPoint;
                //The DoDragDrop (with flag = 3) command will create a stream vdml file from the selection , an image and a vdml file to drop.
                //The stream will be used to the destination BaseControl in order to add the entities to a block .
                //The image is going to be used in the Button Control in order to show the image.
                //The file can be dropped in a file explorer (desktop) in order to create a vdml file. 
                vdSource.ActiveDocument.CommandAction.DoDragDrop(set, vdSelection.DragDropEffects.Copy, dragOrigin, ImageButton.Width, ImageButton.Height, 3);
            }
        }
        #endregion

        #region Destination Source
        void vdDest_vdDragEnter(DragEventArgs drgevent, ref bool cancel)
        {//allow drop to the Destination BaseControl
            drgevent.Effect = DragDropEffects.Copy;
        }
        void vdDest_vdDragDrop(DragEventArgs drgevent, ref bool cancel)
        {//drop the stream as block to the Destination BaseControl
            cancel = true;
            
            System.IO.MemoryStream stream = drgevent.Data.GetData("VectorDraw.6") as System.IO.MemoryStream;
            if (stream == null) return;
            vdBlock block = vdDest.ActiveDocument.Blocks.AddFromStream("dragdrop", stream);
            if (block == null) return;
            gPoint pt = vdDest.ActiveDocument.CCS_CursorPos();
            vdDest.ActiveDocument.CommandAction.CmdInsert(block.Name, pt, 1.0d, 1.0d, 0.0d);
            vdInsert ins = vdDest.ActiveDocument.ActiveLayOut.Entities.Last as vdInsert;
            if (ins == null) return;
            ins.Update();
            ins.Invalidate();
        }
        #endregion

    }
}