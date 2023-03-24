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
using System.Drawing.Drawing2D;
using VectorDraw.Professional.vdCollections;
using VectorDraw.Geometry;

namespace ScreenBlockInfo
{
    public partial class Form1 : Form
    {
        #region Variables
        //private variables required.
        private VectorDraw.Professional.vdObjects.vdDocument Doc = null; // the vdDocument object
        private vdScreenBlock ScreenBLK = new vdScreenBlock(); // The ScreenBlock object 
        #endregion

        public Form1()
        {
            InitializeComponent();
            
        }

      

        #region Form_Events_to_use
        private void Form1_Load(object sender, EventArgs e)
        {
            Doc = vdFramedControl1.BaseControl.ActiveDocument;

            // set the filename and author
            Doc.FileName = "VectorDraw.VDML";
            Doc.FileProperties.Author = "Matt";

            // hide the unnecessary components
            vdFramedControl1.BaseControl.EnableAutoGripOn = false;
            vdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.CommandLine, false);
            vdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.PropertyGrid, false);
            Doc.GlobalRenderProperties.Wire2dUseFontOutLines = VectorDraw.Render.vdRenderGlobalProperties.Wire2dUseFontOutLinesFlag.UseAPIWithScaleText;//7007.0.3 70000678
            Doc.OnDrawOverAll += new vdDocument.DrawOverAllEventHandler(Doc_OnDrawOverAll); // here we will draw the screen blocks
            Doc.OnScroll += new vdDocument.ScrollEventHandler(Doc_OnScroll);
            Doc.OnAfterOpenDocument += new vdDocument.AfterOpenDocument(Doc_OnAfterOpenDocument);// this event is used for the update of the INFO block
            Doc.OnAfterNewDocument += new vdDocument.AfterNewDocument(Doc_OnAfterNewDocument);// this event is used for the update of the INFO block
            vdFramedControl1.BaseControl.vdMouseDown += new VectorDraw.Professional.Control.MouseDownEventHandler(BaseControl_vdMouseDown);
            Doc.ViewCube.Display = vdViewCube.ViewCubeDisplayFlags.Hidden;//Do not display the default ViewCube
            // create a small 3D drawing
            Doc.CommandAction.CmdSphere(new gPoint(27,2), 4.0d, 15, 15);
            Doc.CommandAction.CmdSphere(new gPoint(9,27,2), 11.0d, 15, 15);

            //initialization for the demonstration
            Doc.ShowUCSAxis = false; cbVDFAxis.Checked = false;
            rdb3D.Checked = true; rdb3D_CheckedChanged(sender, e);
            rdbInfo.Checked = false;
            Doc.CommandAction.Zoom("E", 0, 0);
            
        }

        //override in order to avoid the screen bitmap scrolling when we are in 2d render mode.
        void Doc_OnScroll(object sender, ref double cx, ref double cy, ref bool cancel)
        {
            VectorDraw.Render.vdRender render = sender as VectorDraw.Render.vdRender;
            if (render.PerspectiveMod == VectorDraw.Render.vdRender.VdConstPerspectiveMod.PerspectON)
            {

                VectorDraw.Geometry.Matrix m = new VectorDraw.Geometry.Matrix();
                m.TranslateMatrix(-cx, -cy, 0.0d);
                Doc.World2ViewMatrix *= m;
            }
            else
            {
                Doc.ViewCenter += new gPoint(cx, cy);
            }
            Doc.Invalidate();
            cancel = true;
        }
        //override in order to get the entities of the screen block over the mouse location
        void BaseControl_vdMouseDown(MouseEventArgs e, ref bool cancel)
        {
            if (Doc == null || ScreenBLK == null || e.Button != MouseButtons.Left) return;
            VectorDraw.Render.RenderSelect.RenterSelectObjectArray selectedObjects = ScreenBLK.HitTestEx2(Doc, e.Location);
            if (selectedObjects != null)
            {
                vdFigure fig = selectedObjects[0].Outer() as vdFigure;
                MessageBox.Show(string.Format("Screen Block Entity of type {0} was picked", fig._TypeName));
                cancel = true;

            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(ScreenBLK != null) ScreenBLK.Dispose(); // this is necessary
            ScreenBLK = null;
        }
        private void cbVDFAxis_CheckedChanged(object sender, EventArgs e)
        {
            if (Doc == null) return;
            // enable/disable the default XYZ axis icon
            Doc.ShowUCSAxis = cbVDFAxis.Checked;
            Doc.Redraw(false);
        }
       
        private void rdb3D_CheckedChanged(object sender, EventArgs e)
        {
            if (Doc == null) return;
            if (rdb3D.Checked) // enable the Custom3D  ScreenBlock
            {
                
                ScreenBLK.Rendermode = VectorDraw.Render.vdRender.Mode.Shade;
                ScreenBLK.Block = CreateCustom3D();
                ScreenBLK.Location = vdScreenBlock.LocationFlag.LeftTop;
                ScreenBLK.Tranformation = vdScreenBlock.TranformationFlag.UserCS;

                ScreenBLK.Height = 200;
                ScreenBLK.Width = 200;
                lblInfo.Text = "A custom 3D box labeled TOP, BOTTOM, LEFT etc that follow the View CS";
            }
            Doc.Redraw(false);
        }
        private void rdbInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (Doc == null) return;
            if (rdbInfo.Checked)// enable the Information ScreenBlock
            {
                
                ScreenBLK.Block = CreateInfo(); //blkInfo;
                ScreenBLK.Rendermode = VectorDraw.Render.vdRender.Mode.Wire2dGdiPlus;
                ScreenBLK.Location = vdScreenBlock.LocationFlag.RightBottom;
                ScreenBLK.Tranformation = vdScreenBlock.TranformationFlag.ViewCS;
                ScreenBLK.Height = 120;
                ScreenBLK.Width = 270;
                lblInfo.Text = "Some information, like the company name, date, author and filename";
            }
            Doc.Redraw(false);
        }
        private void btnRotate3DView_Click(object sender, EventArgs e)
        {
            Doc.CommandAction.View3D("VROT");
        }
        #endregion

        #region VDF_Events_to_use
        private void Doc_OnAfterNewDocument(object sender)
        {
            Doc.FileProperties.Author = "Matt";
        }

        private void Doc_OnAfterOpenDocument(object sender)
        {
            if (Doc.FileProperties.Author.Trim() == "") Doc.FileProperties.Author = "Matt";

        }
        void Doc_OnDrawOverAll(object sender, VectorDraw.Render.vdRender render, ref bool cancel)
        {
            // In this event the ScreenBlock in drawn
            ScreenBLK.Draw(render); // Draw the block
        }
        #endregion

        #region blocks_for_ScreenBlock
        vdBlock CreateCustom3D()
        { // create the block for the Custom 3D axis/box
            double textheight = 0.15;
            double textthick = 0.01;
            double boxsize = 0.7;
            double halfboxsize = boxsize / 2.0d;
            vdPolyhatch ph = new vdPolyhatch(Doc,
                new vdPolyCurves(new vdCurves[]{new vdCurves(new vdCurve[] {
                                new vdCircle(Doc, new gPoint(), 1.0d),
                                new vdCircle(Doc, new gPoint(), 0.8) 
                                            })}), new vdColor(Color.LightGray, 64), true
                                            );
            vdText text_N = new vdText(Doc, "N", new gPoint(0.0, 0.9), 0.5, VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter, VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen, null);
            text_N.Thickness = textthick; text_N.PenColor.FromSystemColor(Color.Green);
            
            vdText text_S = new vdText(Doc, "S", new gPoint(0.0, -0.9), 0.5, VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter, VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen, null);
            text_S.Thickness = textthick; text_S.PenColor.FromSystemColor(Color.Green);
            vdText text_E = new vdText(Doc, "E", new gPoint(0.9, 0.0), 0.5, VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter, VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen, null);
            text_E.Thickness = textthick; text_E.PenColor.FromSystemColor(Color.Red);
            vdText text_W = new vdText(Doc, "W", new gPoint(-0.9, 0.0), 0.5, VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter, VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen, null);
            text_W.Thickness = textthick; text_W.PenColor.FromSystemColor(Color.Red);
            vdPolyface box = new vdPolyface(Doc);
            box.CreateBox(new gPoint(-halfboxsize, -halfboxsize), boxsize, boxsize, boxsize, 0.0);
            VectorDraw.Geometry.Matrix m = new VectorDraw.Geometry.Matrix();
            m.SetFrom(new gPoint(0.0, 0.0, boxsize), new Vector(1, 0, 0), new Vector(0, 1, 0));
            vdText text_TOP = new vdText(Doc, "TOP", new gPoint(), textheight, VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter, VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen, null);
            text_TOP.Thickness = textthick; text_TOP.PenColor.FromSystemColor(Color.Blue);
            text_TOP.Transformby(m.GetInvertion());
            m.SetFrom(new gPoint(0.0, 0.0, 0.0), new Vector(1, 0, 0), new Vector(0, -1, 0));
            vdText text_BOTTOM = new vdText(Doc, "BOTTOM", new gPoint(), textheight, VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter, VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen, null);
            text_BOTTOM.Thickness = textthick; text_BOTTOM.PenColor.FromSystemColor(Color.Blue); text_BOTTOM.WidthFactor = 0.7;
            text_BOTTOM.Transformby(m.GetInvertion()); text_BOTTOM.Rotation = 0.0d;
            m.SetFrom(new gPoint(-halfboxsize, 0.0, halfboxsize), new Vector(0, -1, 0), new Vector(0, 0, 1));
            vdText text_LEFT = new vdText(Doc, "LEFT", new gPoint(), textheight, VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter, VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen, null);
            text_LEFT.Thickness = textthick; text_LEFT.PenColor.FromSystemColor(Color.Red);
            text_LEFT.Transformby(m.GetInvertion());
            m.SetFrom(new gPoint(halfboxsize, 0.0, halfboxsize), new Vector(0, 1, 0), new Vector(0, 0, 1));
            vdText text_RIGHT = new vdText(Doc, "RIGHT", new gPoint(), textheight, VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter, VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen, null);
            text_RIGHT.Thickness = textthick; text_RIGHT.PenColor.FromSystemColor(Color.Red);
            text_RIGHT.Transformby(m.GetInvertion()); 
            m.SetFrom(new gPoint(0.0, -halfboxsize, halfboxsize), new Vector(1, 0, 0), new Vector(0, 0, 1));
            vdText text_FRONT = new vdText(Doc, "FRONT", new gPoint(), textheight, VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter, VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen, null);
            text_FRONT.Thickness = textthick; text_FRONT.PenColor.FromSystemColor(Color.Green);
            text_FRONT.Transformby(m.GetInvertion());
            m.SetFrom(new gPoint(0.0, halfboxsize, halfboxsize), new Vector(-1, 0, 0), new Vector(0, 0, 1));
            vdText text_BACK = new vdText(Doc, "BACK", new gPoint(), textheight, VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter, VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen, null);
            text_BACK.Thickness = textthick; text_BACK.PenColor.FromSystemColor(Color.Green);
            text_BACK.Transformby(m.GetInvertion());
            vdFigure[] figs = new vdFigure[] { 
                ph, box, 
                text_N, text_S, text_E, text_W, 
                text_TOP, text_BOTTOM, text_LEFT, text_RIGHT, text_FRONT, text_BACK
            };
            vdBlock block = new vdBlock(Doc);
            block.Entities.AddItems(figs);
            return block;

        }
        
        

        vdBlock CreateInfo()
        {
            // create the block that displays the CompanyName, date, filename and author of the drawing 
            vdBlock block = new vdBlock(Doc);
            vdMText mtext = new vdMText(Doc, string.Format("{{\\C1;VectorDraw & CO. E.E.}}\\P{{\\C2;{0}}}\\P{{\\C3;{1}}}", Doc.FileProperties.Author, VectorDraw.Professional.Utilities.vdGlobals.GetFileName(Doc.FileName)), new gPoint(), 1.0);
            mtext.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter;
            block.Entities.AddItem(mtext);
            return block;
        }

        #endregion
    }
}