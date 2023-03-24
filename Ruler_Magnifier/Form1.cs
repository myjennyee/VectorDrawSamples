using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ruler_Magnifier
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            vdFramedControl1.BaseControl.vdKeyDown += new VectorDraw.Professional.Control.KeyDownEventHandler(BaseControl_vdKeyDown);
            rulerProps.SelectedObject = vdFramedControl1.ScrollableControl.RulerObject;
            vdFramedControl1.ScrollableControl.RulerObject.Visible = true;
        }

        void BaseControl_vdKeyDown(KeyEventArgs e, ref bool cancel)
        {
            VectorDraw.Actions.BaseAction Action = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.OverAllActiveAction;

            if (!(Action is VectorDraw.Professional.ActionUtility.ActionMagnifier) && VectorDraw.Actions.BaseAction.PressedKeyCode == Keys.Shift && System.Windows.Forms.Control.MouseButtons == MouseButtons.None)
            {

                VectorDraw.Geometry.gPoint retptWorld = VectorDraw.Professional.ActionUtility.ActionMagnifier.getUserMagnifierPoint(vdFramedControl1.BaseControl.ActiveDocument, 3, 210, (int)Keys.ShiftKey);
            }
        }
       
        

        private void butMagnifier_Click(object sender, EventArgs e)
        {
            VectorDraw.Geometry.gPoint retptWorld = VectorDraw.Professional.ActionUtility.ActionMagnifier.getUserMagnifierPoint(vdFramedControl1.BaseControl.ActiveDocument, 3, 210, (int)Keys.ShiftKey);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //We add the "RequiredFiles" folder to the support path. This addition is made in order for our samples to get the required files from this extra folder used in distribution of our sample files.
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\RequiredFiles\\";
            vdFramedControl1.BaseControl.ActiveDocument.SupportPath = path;

            string filename = VectorDraw.Professional.Utilities.vdGlobals.GetDirectoryName (Application.ExecutablePath) + "\\sample.vdml";
            vdFramedControl1.BaseControl.ActiveDocument.Open(filename);
        }

        private void btRuler_Click(object sender, EventArgs e)
        {
            vdFramedControl1.ScrollableControl.RulerObject.Visible = !vdFramedControl1.ScrollableControl.RulerObject.Visible;
        }
    }
}