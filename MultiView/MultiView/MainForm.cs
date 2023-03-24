using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VectorDraw.Professional.vdPrimaries;
using VectorDraw.Render;

///Description:

///This sample's purpose is to demonstrate the Multiview capabilities of VectorDraw.
///We created a layout to support multiple viewports that can be used as the model.
///The code below demonstates a way to hide the model and have a default multiview for your files.
///After opening a file a multiview layout is created and the model is hidden.
///Also note that the multiview is saved in the vdml/vdcl format so when you open a file that is already saved having a multiview layout as activelayout 
///that layout will be shown when the file opens.


///Use:

///Press the Open button in order to open a default file that we have for this project.
///You can also open one of your files from the FramedControl's menu.
///The other button of the form will show you the Multiview form that we created to support this feature.
///If the ActiveLAyout is a multiview layout then the form will edit the existing. You can always create a new multiview layout with a different style using the bottom left checkbox.

namespace MultiView
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void butOpen_Click(object sender, EventArgs e)
        {
            // Open a default drawing
            vdFramedControl1.BaseControl.ActiveDocument.Open ("Tool.vdml");
        }

        private void butDialog_Click(object sender, EventArgs e)
        {
            // Open the dialog designed to edit (the active) or create a new Multiview Layout.
            VectorDraw.Professional.Dialogs.VdrawDialogs dialogs = new VectorDraw.Professional.Dialogs.VdrawDialogs(vdFramedControl1.BaseControl.ActiveDocument, vdFramedControl1.BaseControl.ActiveDocument.ActionControl);
            dialogs.GetMultiViewDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            vdFramedControl1.BaseControl.ActiveDocument.OnAfterOpenDocument += new VectorDraw.Professional.vdObjects.vdDocument.AfterOpenDocument(ActiveDocument_OnAfterOpenDocument);
        }

        void ActiveDocument_OnAfterOpenDocument(object sender)
        {
            
            if (vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut is vdLayoutSplit)
            {
                // After opening a file , if it is saved having a Multiview layout active simply hide the model.
                vdFramedControl1.BaseControl.ActiveDocument.Model.VisibleOnForms = false;
                vdFramedControl1.ScrollableControl.ReFillTabs();
            }
            else
            {
                // After opening a file create a new Multiview layout and apply some default values, also hide the model.
                vdLayoutSplit multiview = new vdLayoutSplit(vdFramedControl1.BaseControl.ActiveDocument, "View", vdLayoutSplit.SplitStyleEnum.Three_Left);
                ((VectorDraw.Professional.vdFigures.vdViewport)multiview.Entities[1]).RenderMode = VectorDraw.Render.vdRender.Mode.ShadeOn;
                ((VectorDraw.Professional.vdFigures.vdViewport)multiview.Entities[1]).PerspectiveMod = vdRender.VdConstPerspectiveMod.PerspectON;
                ((VectorDraw.Professional.vdFigures.vdViewport)multiview.Entities[1]).ZoomExtents();
                ((VectorDraw.Professional.vdFigures.vdViewport)multiview.Entities[2]).RenderMode = VectorDraw.Render.vdRender.Mode.Wire3d;
                ((VectorDraw.Professional.vdFigures.vdViewport)multiview.Entities[2]).ZoomExtents();
                ((VectorDraw.Professional.vdFigures.vdViewport)multiview.Entities[3]).RenderMode = VectorDraw.Render.vdRender.Mode.Render;
                ((VectorDraw.Professional.vdFigures.vdViewport)multiview.Entities[3]).ZoomExtents();
                vdFramedControl1.BaseControl.ActiveDocument.LayOuts.AddItem(multiview);
                //Hide all layouts from the layouts tab to show only the Multiview layout.
                vdFramedControl1.BaseControl.ActiveDocument.Model.VisibleOnForms = false;
                foreach (vdLayout  var in vdFramedControl1.BaseControl.ActiveDocument.LayOuts)
                {
                    if (var.Equals (multiview)) continue;
                    var.VisibleOnForms = false;
                }
                vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut = multiview;
                vdFramedControl1.ScrollableControl.ReFillTabs();
            }
        }
    }
}