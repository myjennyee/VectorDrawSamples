using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VectorDraw.Professional.vdObjects;
using VectorDraw.Professional.vdFigures;
using VectorDraw.Geometry;
using VectorDraw.Professional.vdPrimaries;
using VectorDraw.Render;

namespace CustomActions
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        VectorDraw.Professional.Control.VectorDrawBaseControl Basedoc;
        public vdRect GLB_Rect;
        private void Form1_Load(object sender, EventArgs e)
        {
            Basedoc = VDMain.BaseControl;
            vdDocument doc = VDMain.BaseControl.ActiveDocument;

            Basedoc.vdMouseDown += new VectorDraw.Professional.Control.MouseDownEventHandler(Basedoc_vdMouseDown);

            doc.EnableAutoGripOn = false;
            doc.ShowUCSAxis = false;

            vdHatchProperties vd_hatch = new vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
            vd_hatch.FillColor = new vdColor(Color.DarkGray);

            GLB_Rect = new vdRect(doc, new gPoint(0, 0), 10, 10, 0);
            GLB_Rect.HatchProperties = vd_hatch;
            GLB_Rect.PenColor = new vdColor(Color.Yellow);
            GLB_Rect.PenWidth = 0.25;
            GLB_Rect.ShowGrips = false;
            doc.ActiveLayOut.Entities.AddItem(GLB_Rect);

            doc.ZoomExtents();
            doc.ZoomScale(4);
        }

        void Basedoc_vdMouseDown(MouseEventArgs e, ref bool cancel)
        {
            if (e.Button != MouseButtons.Left) return;

            gPoint gpt = VDMain.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.World2Pixelmatrix.Transform(VDMain.BaseControl.ActiveDocument.ActiveLayOut.OverAllActiveAction.MouseLocation);
            POINT pt = new POINT((int)gpt.x, (int)gpt.y);

            using (vdFigure vd_figure = VDMain.BaseControl.ActiveDocument.ActiveLayOut.GetEntityFromPoint(pt, VDMain.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.PickSize, false))
            {
                if (vd_figure == null) return;  // Or Else (vd_figure Is not GLB_Rect) 
                // no entities found at the cursor position

                //create a new custom action that get an existing figure a draws a new one while the mouse is moving
                DropFigureAction action = new DropFigureAction((gPoint)VDMain.BaseControl.ActiveDocument.CCS_CursorPos(), vd_figure);
                //starts the action and wait until it is finished
                vdFigure item = (vdFigure)(VDMain.BaseControl.ActiveDocument.ActionUtility.getUserActionEntity(action) as vdFigure);
                //if the action is finished successfully add the temporary create figure to the active layout entities
                if (item != null)
                {
                    VDMain.BaseControl.ActiveDocument.ActiveLayOut.Entities.Add(item);
                    item.Invalidate(); //post a redraw message for the bouding area of the new added figure
                }
            }
        }
    }

    // this object implement an action that draws an entity
    internal class DropFigureAction : VectorDraw.Professional.Actions.ActionEntity // 'default VDF action for entity
    {
        // Methods
        public DropFigureAction(gPoint refpt, vdFigure fig)
            : base(fig.Document.User2WorldMatrix.Transform(refpt), fig.Document.ActiveLayOut)
        {
            this.clonefig = null;
            this.defpt = null;
            // create a clone of the passed existing entity, temporary used to draw while the mouse is moving
            this.clonefig = fig.Clone(null) as vdFigure;
            // change the color of the new created entity to be different than the passed one
            // here you can change more properties if you like
            this.clonefig.PenColor = new vdColor(Color.FromArgb(0, 0, 0)); // 'set the pen color to black same as background in order to test the SetColorMixMode (see DrawEntity() method)
            this.defpt = new gPoint(this.ReferencePoint);
        }

        public override void MouseUp(MouseEventArgs e)
        {
            base.MouseUp(e);
            this.FinishAction(this); // The action is finished when the mouse is up
        }

        protected override void OnMyPositionChanged(gPoint newPosition)
        {
            Matrix mat = new Matrix();
            mat.TranslateMatrix((newPosition - this.defpt));
            this.clonefig.Transformby(mat);
            this.defpt = new gPoint(newPosition);
        }
        protected override vdRender.DrawStatus DrawEntity()
        {
            vdRender.DrawStatus ret;
            VectorDraw.Render.vdglTypes.COLOR_MIX oldMixMode;
            oldMixMode = Render.SetColorMixMode(vdglTypes.COLOR_MIX.Visible); // 'change the active ColorMixMode to force the color that are same as background to be visible
            ret = base.DrawEntity();
            Render.SetColorMixMode(oldMixMode); // 'restore the COLOR_MIX
            return ret;
        }
        
        // Properties
        public override vdFigure Entity
        {
            get
            {
                return this.clonefig;
            }
        }

        public override bool HideRubberLine
        {
            get
            {
                return true; // 'do not draw the ruber line between reference point and current point
            }
        }
        
        // 'the return value from the getUserActionEntity call
        public override object Value
        {
            get
            {
                return Entity;
            }
        }


        // Fields
        private vdFigure clonefig; // 'a new created entity that is a clone of an existing and modified while the the mouse is moving
        private gPoint defpt; // 'a point in world Coordinate System updated each time the mouse is moved, inside the OnMyPositionChanged method
    }
}