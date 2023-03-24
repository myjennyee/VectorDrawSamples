using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ActionDraw_Event
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.vdSC.BaseControl.ActiveDocument.ShowUCSAxis = false;
            this.vdSC.BaseControl.ActiveDocument.FreezeEntityDrawEvents.Push(false);
            this.vdSC.BaseControl.ActiveDocument.OnActionDraw += new VectorDraw.Professional.vdObjects.vdDocument.ActionDrawEventHandler(ActiveDocument_OnActionDraw);
            this.vdSC.BaseControl.ActiveDocument.OnFigureDrawGrips += new VectorDraw.Professional.vdObjects.vdDocument.FigureDrawGripsEventHandler(ActiveDocument_OnFigureDrawGrips);
            this.vdSC.BaseControl.ActiveDocument.GlobalRenderProperties.GripSize = 20;
        }

        void ActiveDocument_OnFigureDrawGrips(object sender, VectorDraw.Render.vdRender render, ref bool cancel)
        {
            if (!chkBox_GripDraw.Checked) return;
            if (sender == null) return;

            VectorDraw.Geometry.Matrix mat = new VectorDraw.Geometry.Matrix(render.CurrentMatrix);
            render.PushToViewMatrix(); // you need to PopMatrix before ending this procedure
           
            try // here draw the grips as filled circles with transparency -->
            {
                VectorDraw.Professional.vdPrimaries.vdFigure fig = sender as VectorDraw.Professional.vdPrimaries.vdFigure;
                VectorDraw.Geometry.gPoints gripPTs;
                VectorDraw.Professional.vdFigures.vdCircle circ = new VectorDraw.Professional.vdFigures.vdCircle();
                circ.SetUnRegisterDocument(this.vdSC.BaseControl.ActiveDocument);
                circ.setDocumentDefaults();
                circ.PenColor = new VectorDraw.Professional.vdObjects.vdColor(Color.Red);
                circ.HatchProperties = new VectorDraw.Professional.vdObjects.vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
                circ.Radius = render.PixelSize * render.GlobalProperties.GripSize / 2.0d;
                circ.HatchProperties.FillColor.SystemColor = Color.Red;
                circ.HatchProperties.FillColor.AlphaBlending = 100;
                circ.HatchProperties.Update();
                gripPTs = fig.GetGripPoints();
                VectorDraw.Geometry.gPoint tmpPt = new VectorDraw.Geometry.gPoint();
                foreach (VectorDraw.Geometry.gPoint gripPT in gripPTs)
                {
                    tmpPt = mat.Transform(gripPT);
                    circ.Center = tmpPt;
                    circ.Draw(render);
                    circ.Update();
                }
                cancel = true;
            }
            catch { }// <-- here draw the grips as filled circles with transparency

            render.PopMatrix(); // and here is the PopMatrix
        }

        void ActiveDocument_OnActionDraw(object sender, object action, bool isHideMode, ref bool cancel)
        {
            if (!chkBox.Checked) return;
            if (!(action is VectorDraw.Actions.ActionGetRefPoint)) return;
            VectorDraw.Actions.BaseAction act = action as VectorDraw.Actions.BaseAction;
            VectorDraw.Geometry.gPoint refpoint = act.ReferencePoint;
            VectorDraw.Geometry.gPoint currentpoint = act.OrthoPoint;
            VectorDraw.Professional.vdFigures.vdCircle circle = new VectorDraw.Professional.vdFigures.vdCircle();
            circle.SetUnRegisterDocument(vdSC.BaseControl.ActiveDocument);
            circle.setDocumentDefaults();
            circle.Center = VectorDraw.Geometry.gPoint.MidPoint(refpoint, currentpoint);
            circle.Radius = circle.Center.Distance3D(refpoint);
            circle.Draw(act.Render);
        }

        private void btLine_Click(object sender, EventArgs e)
        {
            this.vdSC.BaseControl.ActiveDocument.CommandAction.CmdLine("USER");
        }

        private void chkBox_GripDraw_CheckedChanged(object sender, EventArgs e)
        {
            this.vdSC.BaseControl.Redraw();
        }

        private void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            this.vdSC.BaseControl.Redraw();
        }
    }
}