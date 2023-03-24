using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VectorDraw.Geometry;
using VectorDraw.Professional.vdFigures;
using VectorDraw.Professional.vdPrimaries;

namespace MouseOverFigure
{
    /// <summary>
    /// OnFigureMouseOver is a new event added in version 7 of vdraw. This event was designed in order for users to be able to get control of when
    /// the cursor moves over a vdFigure object. Using this event you can achieve many things easily like perform custom highlight, select entities
    /// in a customized way and generally interact with entities under your cursor. To understand better how it works use this sample. 
    /// Keep in mind that this event has 6 types defined by the MouseAction property. 
    /// •MouseEnter - Fired when a cursor first hovers over a vdFigure.
    /// •MouseLeave - Fired when a cursor hovers off a vdFigure.
    /// •MouseMove - Fired whenever the cursor is moved and lies over a vdFigure.
    /// •MouseDown - Fired when a mouse button is pressed down over a vdFigure.
    /// •MouseUp - Fired when a mouse button is released over a vdFigure.
    /// •MouseOverDraw - Fired whenever the cursor is moved over a vdFigure and this figure is about to be drawn.
    /// 
    /// Also you should know that it fires only under specific conditions.
    /// •If the MouseEnter event is cancelled (setting the Cancel property of arguments object to true) all subsequent events won't fire.
    /// •The MouseOverDraw event will not fire unless the SelectionPreview of GlobalRenderProperties is set to ON.
    /// •The MouseEnter, MouseLeave and MouseMove events won't fire unless SelectionPreview, URLs or ToolTips are enabled.
    /// •There is an exception to the above condition, during an action if there are oSnaps activated the MouseEnter, MouseLeave and MouseMove fire.
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public VectorDraw.Professional.vdObjects.vdDocument doc
        {
            get { return vectorDrawBaseControl1.ActiveDocument; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            doc.OnFigureMouseOver += new VectorDraw.Professional.vdObjects.vdDocument.FigureMouseOverEventHandler(doc_OnFigureMouseOver);
            doc.EnableAutoGripOn = false;

            doc.GlobalRenderProperties.SelectionPreview = VectorDraw.Render.vdRenderGlobalProperties.SelectionPreviewFlags.ON;
            checkSelectionPreview.Checked = true;
            doc.EnableToolTips = true;
            checkTooltips.Checked = true;
            doc.EnableUrls = true;
            checkUrls.Checked = true;

            string[] snaps = Enum.GetNames(typeof(VectorDraw.Geometry.OsnapMode));
            foreach (string osnap in snaps)
                comboOsnaps.Items.Add(osnap);
            comboOsnaps.SelectedIndex = 1;
            text = new vdText(doc);
            h_rect = new vdRect(doc);
            h_rect.HatchProperties = new VectorDraw.Professional.vdObjects.vdHatchProperties();

            doc.Open("MouseOverFigure.vdml");
        }
        vdRect h_rect;
        vdText text;
        int[] eventCounter = new int[7];
        void doc_OnFigureMouseOver(object sender, VectorDraw.Professional.vdPrimaries.vdFigure.FigureMouseEventArgs args)
        {
            switch (args.MouseAction)
            {
                case VectorDraw.Professional.vdPrimaries.vdFigure.FigureMouseEventArgs.FigureMouseAction.MouseDown:
                    eventCounter[0] += 1;
                    break;
                case VectorDraw.Professional.vdPrimaries.vdFigure.FigureMouseEventArgs.FigureMouseAction.MouseEnter:
                    eventCounter[1] += 1;
                    break;
                case VectorDraw.Professional.vdPrimaries.vdFigure.FigureMouseEventArgs.FigureMouseAction.MouseLeave:
                    eventCounter[2] += 1;
                    break;
                case VectorDraw.Professional.vdPrimaries.vdFigure.FigureMouseEventArgs.FigureMouseAction.MouseMove:                    
                    eventCounter[3] += 1;
                    break;
                case VectorDraw.Professional.vdPrimaries.vdFigure.FigureMouseEventArgs.FigureMouseAction.MouseOverDraw:
                    args.Cancel = true;
                    if (args.Entity.Label == "sun")
                    {
                        vdCircle cir = args.Entity as vdCircle;
                        drawSun(args.ActionRender, cir.Center);
                    }
                    else if (args.Entity.Label == "rect")
                    {
                        drawRect(args.ActionRender, args.Entity as vdRect, args.Entity.BoundingBox.MidPoint);
                    }
                    else if (args.Entity.Label == "transparency")
                    {
                        drawTransparent(args.ActionRender, args.Entity.BoundingBox.MidPoint);
                    }
                    else if (args.Entity.Label == "insert")
                    {
                        drawInsert(args.ActionRender, args.Entity.BoundingBox.MidPoint, args.Entity, args.InnerEntity);
                    }
                    eventCounter[4] += 1;
                    break;
                case VectorDraw.Professional.vdPrimaries.vdFigure.FigureMouseEventArgs.FigureMouseAction.MouseUp:
                    eventCounter[5] += 1;
                    break;
                case VectorDraw.Professional.vdPrimaries.vdFigure.FigureMouseEventArgs.FigureMouseAction.MouseDoubleClick:
                    eventCounter[6] += 1;
                    break;
                default:
                    break;
            }
            updateTextBoxes();
        }
        private void drawSun(VectorDraw.Render.vdRender render, VectorDraw.Geometry.gPoint p)
        {
            render.LockPenStyle = new VectorDraw.Render.vdGdiPenStyle(Color.Yellow, 255);

            render.DrawLine(null, p + new gPoint(0,1.2), p + new gPoint(0,2));
            render.DrawLine(null, p + new gPoint(0.84, 0.84), p + new gPoint(1.4, 1.4));
            render.DrawLine(null, p + new gPoint(1.2, 0), p + new gPoint(2, 0));
            render.DrawLine(null, p + new gPoint(0.84, -0.84), p + new gPoint(1.4, -1.4));
            render.DrawLine(null, p + new gPoint(0, -1.2), p + new gPoint(0, -2));
            render.DrawLine(null, p + new gPoint(-0.84, -0.84), p + new gPoint(-1.4, -1.4));
            render.DrawLine(null, p + new gPoint(-1.2, 0), p + new gPoint(-2, 0));
            render.DrawLine(null, p + new gPoint(-0.84, 0.84), p + new gPoint(-1.4, 1.4));
            
            text.TextString = "Draw on the fly";
            text.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter;
            text.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen;
            text.Style = doc.TextStyles.Standard;
            text.InsertionPoint = p;
            text.Height = 0.2;
            text.Update();
            text.Draw(render);

            render.LockPenStyle = null;
        }
        private void drawRect(VectorDraw.Render.vdRender render, vdRect rect, VectorDraw.Geometry.gPoint p)
        {
            render.LockPenStyle = new VectorDraw.Render.vdGdiPenStyle(Color.LightGreen, 255);
            h_rect.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeNone;

            h_rect.InsertionPoint = p + new gPoint(-1.05, -1.05);
            h_rect.Width = 2.1;
            h_rect.Height = 2.1;
            h_rect.Update();
            h_rect.Draw(render);

            h_rect.InsertionPoint = p + new gPoint(-0.95, -0.95);
            h_rect.Width = 1.9;
            h_rect.Height = 1.9;
            h_rect.Update();
            h_rect.Draw(render);

            text.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter;
            text.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen;
            text.Style = doc.TextStyles.Standard;
            text.InsertionPoint = p + new gPoint(0, 2);
            text.TextString = "Hightlight entities however you want";
            text.Height = 0.3;
            text.Update();
            text.Draw(render);

            render.LockPenStyle = null;
        }
        private void drawTransparent(VectorDraw.Render.vdRender render, VectorDraw.Geometry.gPoint p)
        {
            render.LockPenStyle = new VectorDraw.Render.vdGdiPenStyle(Color.Cyan, 150);

            h_rect.InsertionPoint = p + new gPoint(-1,-1);
            h_rect.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid;
            h_rect.Width = 2;
            h_rect.Height = 2;
            h_rect.Update();
            h_rect.Draw(render);

            text.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter;
            text.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen;
            text.Style = doc.TextStyles.Standard;
            text.InsertionPoint = p + new gPoint(0, 2);
            text.TextString = "Draw using transparency";
            text.Height = 0.3;
            text.Update();
            text.Draw(render);

            render.LockPenStyle = null;
        }
        private void drawInsert(VectorDraw.Render.vdRender render, VectorDraw.Geometry.gPoint p, vdFigure top, vdFigure inner)
        {
            h_rect.PenColor.Dispose();
            h_rect.PenColor = new VectorDraw.Professional.vdObjects.vdColor(Color.Red);
            h_rect.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid;
            h_rect.HatchProperties.FillColor.Dispose();
            h_rect.HatchProperties.FillColor = null;
            h_rect.HatchProperties.FillColor = new VectorDraw.Professional.vdObjects.vdColor(Color.Red, 100);

            h_rect.InsertionPoint = p + new gPoint(-1.05, -1.05);
            h_rect.Width = 2.1;
            h_rect.Height = 2.1;
            h_rect.Update();
            h_rect.Draw(render);

            text.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter;
            text.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen;
            text.Style = doc.TextStyles.Standard;
            text.InsertionPoint = p - new gPoint(0, 2);
            text.TextString = String.Format("Top entity:  {0} --- Inner entity:  {1}", top.GetType().ToString(), inner.GetType().ToString());
            text.Height = 0.2;
            text.Update();
            text.Draw(render);
        }
        private void updateTextBoxes()
        {
            textMouseDown.Text = eventCounter[0].ToString();
            textMouseEnter.Text = eventCounter[1].ToString();
            textMouseLeave.Text = eventCounter[2].ToString();
            textMouseMove.Text = eventCounter[3].ToString();
            textMouseOverDraw.Text = eventCounter[4].ToString();
            textMouseUp.Text = eventCounter[5].ToString();
            textDoubleClick.Text = eventCounter[6].ToString();
        }
        private void comboOsnaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            string snap = comboOsnaps.Items[comboOsnaps.SelectedIndex] as string;
            doc.osnapMode = (VectorDraw.Geometry.OsnapMode)Enum.Parse(typeof(VectorDraw.Geometry.OsnapMode), snap);
        }

        private void checkSelectionPreview_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSelectionPreview.Checked)
                doc.GlobalRenderProperties.SelectionPreview = VectorDraw.Render.vdRenderGlobalProperties.SelectionPreviewFlags.ON;
            else
                doc.GlobalRenderProperties.SelectionPreview = VectorDraw.Render.vdRenderGlobalProperties.SelectionPreviewFlags.OFF;
        }

        private void checkTooltips_CheckedChanged(object sender, EventArgs e)
        {
            doc.EnableToolTips = checkTooltips.Checked;
        }

        private void checkUrls_CheckedChanged(object sender, EventArgs e)
        {
            doc.EnableUrls = checkUrls.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doc.Open("MouseOverFigure.vdml");
            doc.Redraw(true);
            for (int i = 0; i < eventCounter.Length; i++)
            {
                eventCounter[i] = 0;
            }
            updateTextBoxes();
        }

        private void buttonDrawline_Click(object sender, EventArgs e)
        {
            doc.CommandAction.CmdLine(null);
        }
    }
}