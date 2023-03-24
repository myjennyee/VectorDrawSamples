using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VectorDraw.Professional.vdObjects;
using VectorDraw.Professional.vdPrimaries;
using VectorDraw.Professional.vdFigures;
using VectorDraw.Render;
using VectorDraw.Geometry;

//Purpose  of this sample is to show how to add button images on the rendering view of VectorDraw Base Control that will execute a command.
namespace CommandButtonImages
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// This is the class that implements a Button Image
        /// </summary>
        class ButtonImage
        {
            // The rectangle in pixels of VectorDraw view Device in which the image will fit.
            Rectangle Rect = Rectangle.Empty;
            // The file name of the image that will be used
            string ImageName = string.Empty;
            // A string that represents the executing command 
            string CommandName = string.Empty;
            //Tooltip text that will displayed when the cursor is over the button
            string ToolTipText = string.Empty;
            // the color to be used as transparent for the image.The pixel with this color will not be drawn
            Color Transparency = Color.Empty;
            // Controls the AlphaBlending for all pixels of the image
            byte AlphaBlending = 255;
            // Represents a value that defines if the cursor is over the button image.
            bool isMouseOn = false;
            // The document component where the button is drawn
            vdDocument Document;
            // The VectorDraw objects that initialized from previous properties and used to draw the item.
            vdImage Image;
            vdImageDef ImageDef;
            VectorDraw.Professional.Control.VectorDrawBaseControl mvDBaseControl;
            //The constructor of the object
            public ButtonImage(VectorDraw.Professional.Control.VectorDrawBaseControl vDBaseControl, vdDocument document, string imageName, Rectangle rect, string commandName, string toolTipText, Color transparency, byte alphaBlending)
            {
                Document = document;
                ImageName = imageName;
                Rect = rect;
                CommandName = commandName;
                ToolTipText = toolTipText;
                Transparency = transparency;
                AlphaBlending = alphaBlending;
                mvDBaseControl = vDBaseControl;


                ImageDef = new vdImageDef();
                ImageDef.SetUnRegisterDocument(document);
                ImageDef.setDocumentDefaults();
                ImageDef.FileName = ImageName;
                ImageDef.Transparency = Transparency;

                Image = new vdImage();
                Image.SetUnRegisterDocument(document);
                Image.setDocumentDefaults();

                Image.ImageDefinition = ImageDef;
                Image.PenColor = new vdColor(Color.White);
                Image.PenColor.AlphaBlending = AlphaBlending;
                Image.Display = VectorDraw.Professional.Constants.VdConstImg.VdImageShowAllTransparent;//use this for draw rectangle round the image


            }
            public bool HasFocus
            {
                get { return isMouseOn; }
            }
            private bool CanBeExecuted()
            {
                return (Document.ActiveLayOut.OverAllActiveActions != null && Document.ActiveLayOut.OverAllActiveActions.Count == 1);
            }
            //Draw the image in the VectorDraw active render.
            public void Draw(vdRender render)
            {
                if (render.IsOpenGLRender) render.OpenGLRender.UnlockTovdRender();

                Image.Height = Rect.Height * render.PixelSize;
                Image.InsertionPoint = render.Pixel2View(new Point(Rect.Left, Rect.Bottom));
                Image.Update();

                render.PushToViewMatrix();

                Image.Draw(render);

                render.PopMatrix();

                if (render.IsOpenGLRender) render.OpenGLRender.LockTovdRender();
            }
            // Handles the MouseEnter event and changes the cursor to Cursors.Arrow
            public bool OnMouseEnter(MouseEventArgs e, ButtonImage lostfocus)
            {
                if (!CanBeExecuted()) return false;
                if (!Rect.Contains(e.Location)) return false;
                if (isMouseOn) return true;
                if (lostfocus != null && !object.ReferenceEquals(this, lostfocus)) lostfocus.OnMouseLeave();
                isMouseOn = true;
                Document.GlobalRenderProperties.ShowCursor = false;
                mvDBaseControl.SetCustomMousePointer(Cursors.Hand);
                Document.ToolTipText = ToolTipText;
                return true;
            }
            // Handles the MouseLeave event and changes the cursor to standard VectorDraw Cursor
            public void OnMouseLeave()
            {
                if (!isMouseOn) return;
                isMouseOn = false;
                mvDBaseControl.SetCustomMousePointer(null);
                Document.GlobalRenderProperties.ShowCursor = true;
                Document.ToolTipText = "";
            }

            //Implements a command when a MouseDown is occured and the cursor is over the Button
            public bool OnMouseDown(MouseEventArgs e)
            {
                if (e.Button != MouseButtons.Left) return false;
                if (!CanBeExecuted()) return false;
                if (!Rect.Contains(e.Location)) return false;
                if (!isMouseOn) return false;
                switch (CommandName.ToLower())
                {
                    case "zoome":
                        VectorDraw.Professional.ActionUtilities.vdCommandAction.ZoomE_Ex(Document);
                        break;
                    case "zoomw":
                        VectorDraw.Professional.ActionUtilities.vdCommandAction.ZoomW_Ex(Document);
                        break;
                    case "open":
                        VectorDraw.Professional.ActionUtilities.vdCommandAction.OpenEx(Document);
                        break;
                }
                return true;
            }
        }
        ButtonImage[] mButtons;
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //We add the "RequiredFiles" folder to the support path. This addition is made in order for our samples to get the required files from this extra folder used in distribution of our sample files.
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\RequiredFiles\\";
            this.vectorDrawBaseControl1.ActiveDocument.SupportPath = path;


            //Create three button 
            int buttonsize = 24;
            byte alphablend = 192;
            mButtons = new ButtonImage[] 
              { new ButtonImage(vectorDrawBaseControl1 , vectorDrawBaseControl1.ActiveDocument, "zoome.bmp", new Rectangle(0*buttonsize, 0, buttonsize, buttonsize),"zoome","Zoom Extents", Color.White, alphablend) ,
                new ButtonImage(vectorDrawBaseControl1 , vectorDrawBaseControl1.ActiveDocument, "zoomw.bmp", new Rectangle(1*buttonsize, 0, buttonsize, buttonsize),"zoomw", "Zoom Window",Color.White, alphablend),
                new ButtonImage(vectorDrawBaseControl1 , vectorDrawBaseControl1.ActiveDocument, "openfile.bmp", new Rectangle(2*buttonsize, 0, buttonsize, buttonsize),"open", "Open",Color.White, alphablend)
              };
            //Add the enets that will implement the mouse actions and draw for the Image buttons  
            this.vectorDrawBaseControl1.vdMouseMove += new VectorDraw.Professional.Control.MouseMoveEventHandler(vectorDrawBaseControl1_vdMouseMove);
            this.vectorDrawBaseControl1.vdMouseLeave += new VectorDraw.Professional.Control.MouseLeaveEventHandler(vectorDrawBaseControl1_vdMouseLeave);
            this.vectorDrawBaseControl1.vdMouseDown += new VectorDraw.Professional.Control.MouseDownEventHandler(vectorDrawBaseControl1_vdMouseDown);
            this.vectorDrawBaseControl1.ActiveDocument.OnDrawOverAll += new vdDocument.DrawOverAllEventHandler(ActiveDocument_OnDrawOverAll);
            this.vectorDrawBaseControl1.ActiveDocument.OnScroll += new vdDocument.ScrollEventHandler(ActiveDocument_OnScroll);
            this.vectorDrawBaseControl1.ActiveDocument.ToolTipDispProps.SetOffsetXY(20, 20);
        }

        void ActiveDocument_OnScroll(object sender, ref double cx, ref double cy, ref bool cancel)
        {
            vdRender render = sender as vdRender;
            VectorDraw.Geometry.Matrix m = new VectorDraw.Geometry.Matrix();
            m.TranslateMatrix(-cx, -cy, 0.0d);
            this.vectorDrawBaseControl1.ActiveDocument.World2ViewMatrix *= m;
            render.Invalidate();
            cancel = true;
        }


        void ActiveDocument_OnDrawOverAll(object sender, vdRender render, ref bool cancel)
        {
            if (render.OwnerObject is vdViewport) return; // do not draw these icons inside viewports
            foreach (ButtonImage button in mButtons)
            {
                button.Draw(render);
            }
        }

        void vectorDrawBaseControl1_vdMouseDown(MouseEventArgs e, ref bool cancel)
        {
            foreach (ButtonImage button in mButtons)
            {
                if (button.OnMouseDown(e))
                {
                    cancel = true;
                    break;
                }
            }
        }

        void vectorDrawBaseControl1_vdMouseLeave(EventArgs e, ref bool cancel)
        {
            foreach (ButtonImage button in mButtons)
            {
                button.OnMouseLeave();
            }
        }
        ButtonImage GetActiveButton()
        {
            foreach (ButtonImage button in mButtons)
            {
                if (button.HasFocus) return button;
            }
            return null;
        }
        void vectorDrawBaseControl1_vdMouseMove(MouseEventArgs e, ref bool cancel)
        {
            ButtonImage active = GetActiveButton();
            foreach (ButtonImage button in mButtons)
            {
                if (button.OnMouseEnter(e, active)) return;
            }
            foreach (ButtonImage button in mButtons)
            {
                button.OnMouseLeave();
            }
        }
    }
}