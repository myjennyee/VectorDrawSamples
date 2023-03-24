using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VectorDraw.Professional.vdCollections;
using VectorDraw.Geometry;
using VectorDraw.Render;
using VectorDraw.Serialize;
using VectorDraw.Generics;
using VectorDraw.Professional.vdFigures;
using VectorDraw.Professional.vdPrimaries;
using VectorDraw.Professional.vdObjects;


namespace MouseEntitySelection
{
    public partial class Form1 : Form
    {
        #region Initialization and variables
        private int state = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //We add the "RequiredFiles" folder to the support path. This addition is made in order for our samples to get the required files from this extra folder used in distribution of our sample files.
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\RequiredFiles\\";
            vdFramedControl1.BaseControl.ActiveDocument.SupportPath = path;

            vdFramedControl1.BaseControl.vdMouseDown += new VectorDraw.Professional.Control.MouseDownEventHandler(BaseControl_vdMouseDown);
            vdFramedControl1.BaseControl.vdKeyDown += new VectorDraw.Professional.Control.KeyDownEventHandler(BaseControl_vdKeyDown);
            vdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.CommandLine, false);
            vdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.LayoutTab, false);
            AddSeveralEntities();

            vdFramedControl1.BaseControl.ActiveDocument.GripSelectionModified += new vdDocument.GripSelectionModifiedEventHandler(ActiveDocument_GripSelectionModified);
        }

        void ActiveDocument_GripSelectionModified(object sender, vdLayout layout, vdSelection gripSelection)
        {
            
        }
        #endregion

        #region Needed extra methods
        private vdSelection GetGripsCollection()
        {
            string selsetname = "VDGRIPSET_" + vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Handle.ToStringValue() + (vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveViewPort != null ? vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveViewPort.Handle.ToStringValue() : "");
            vdSelection gripset = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.Selections.FindName(selsetname);
            if (gripset == null) gripset = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.Selections.Add(selsetname);
            return gripset;
        }
        private void ClearAllGrips(vdSelection GripSelection)
        {
            foreach (vdFigure fig in GripSelection)
            {
                fig.ShowGrips = false;
            }
            if (GripSelection.Count > 0)
            {
                GripSelection.RemoveAll();
                vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.RefreshGraphicsControl(vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.control);
            }
        }
        private void DrawGrips(vdSelection GripSelection)
        {
            if (GripSelection.Count == 0) return;
            bool oldScreenmode = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.SetScreenMode(true);
            bool isstarted = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.Started;
            if (!isstarted) vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.StartDraw(true);
            vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.PushPenstyle(vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.GripColor, 0.0d, null);
            int i = 0;
            foreach (vdFigure fig in GripSelection)
            {
                fig.DrawGrips(vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender); i++;
                if (!VectorDraw.WinMessages.MessageManager.IsMessageQueEmpty(IntPtr.Zero, VectorDraw.WinMessages.MessageManager.BreakMessageMethod.All)) break;
            }
            vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.PopPenstyle();
            if (!isstarted) vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.EndDraw();
            vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.SetScreenMode(oldScreenmode);
        }
        #endregion

        void BaseControl_vdKeyDown(KeyEventArgs e, ref bool cancel)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ClearAllGrips(GetGripsCollection());
            }
        }

        void BaseControl_vdMouseDown(MouseEventArgs e, ref bool cancel)
        {
            if (state == 0) return;
            if (e.Button != MouseButtons.Left) return;
            if (vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.OverAllActiveActions == null) return;
            if (vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.OverAllActiveActions.Count > 1) return;

            if (vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveAction is VectorDraw.Professional.CommandActions.ActionLine) return;
            vdSelection GripEntities = GetGripsCollection();
            gPoint p1 = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.World2Pixelmatrix.Transform(vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.OverAllActiveAction.MouseLocation);
            gPoint p1viewCS = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.CurrentMatrix.Transform(vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.OverAllActiveAction.MouseLocation);
            Point location = new Point((int)p1.x, (int)p1.y);

            #region Grip Move Code
            if (System.Windows.Forms.Control.ModifierKeys == Keys.None)
            {
                Box box = new Box();
                box.AddPoint(p1viewCS);
                box.AddWidth(vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.GripSize * vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.PixelSize / 2.0d);

                vdSelection selset = new vdSelection();
                vdArray<Int32Array> indexesArray = new vdArray<Int32Array>();
                gPoint pt = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.World2UserMatrix.Transform(vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.OverAllActiveAction.MouseLocation);
                foreach (vdFigure fig in GripEntities)
                {
                    Int32Array indexes = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.getGripIndexes(fig, box);
                    if (indexes.Count != 0)
                    {
                        selset.AddItem(fig, false, vdSelection.AddItemCheck.Nochecking);
                        indexesArray.AddItem(indexes);
                    }
                }
                if (selset.Count > 0)
                {
                    VectorDraw.Professional.ActionUtilities.CmdMoveGripPoints MoveGrips = new VectorDraw.Professional.ActionUtilities.CmdMoveGripPoints(pt, vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut, selset, indexesArray);
                    vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActionAdd(MoveGrips);
                    VectorDraw.Actions.StatusCode ret = MoveGrips.WaitToFinish();
                    cancel = true;
                    return;
                }
            }
            #endregion

            if (state == 1)
            {
                #region One by One implementation
                vdFigure Fig = null;
                Fig = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.GetEntityFromPoint(location, vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.PickSize, false, vdDocument.LockLayerMethodEnum.EnableGetObjectGrip);
                vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.LockLayerMethodStack.Push(vdDocument.LockLayerMethodEnum.DisableAll | ((vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.LockLayerMethod & vdDocument.LockLayerMethodEnum.EnableGetObjectGrip) != 0 ? vdDocument.LockLayerMethodEnum.EnableAddToSelections : 0));
                bool bShift = ((System.Windows.Forms.Control.ModifierKeys & Keys.Shift) == Keys.Shift);
                if (Fig != null)
                {
                    ClearAllGrips(GripEntities);
                    GripEntities.AddItem(Fig, true, vdSelection.AddItemCheck.RemoveInVisibleEntities);
                    Fig.ShowGrips = true;
                    DrawGrips(GripEntities);
                    vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.RefreshGraphicsControl(vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.control);
                }
                vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.LockLayerMethodStack.Pop ();
                #endregion
            }
            else if (state == 2)
            {
                #region Multiple select implementation.
                vdFigure Fig = null;
                Fig = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.GetEntityFromPoint(location, vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.PickSize, false, vdDocument.LockLayerMethodEnum.EnableGetObjectGrip);
                vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.LockLayerMethodStack.Push(vdDocument.LockLayerMethodEnum.DisableAll | ((vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.LockLayerMethod & vdDocument.LockLayerMethodEnum.EnableGetObjectGrip) != 0 ? vdDocument.LockLayerMethodEnum.EnableAddToSelections : 0));
                bool bShift = ((System.Windows.Forms.Control.ModifierKeys & Keys.Shift) == Keys.Shift);
                if (Fig != null)
                {
                    if (!bShift && vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.PickAdd == false)
                    {
                        ClearAllGrips(GripEntities);
                    }
                    if (bShift && GripEntities.FindItem(Fig))
                    {
                        GripEntities.RemoveItem(Fig);
                        Fig.ShowGrips = false;

                        DrawGrips(GripEntities);
                        vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.RefreshGraphicsControl(vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.control);
                    }
                    else
                    {
                        if (GripEntities.FindItem(Fig) == false)
                        {
                            if (GripEntities.AddItem(Fig, true, vdSelection.AddItemCheck.RemoveInVisibleEntities))
                            {
                                bool oldScreenmode = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.SetScreenMode(true);
                                bool isstarted = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.Started;
                                if (!isstarted) vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.StartDraw(true);
                                Fig.ShowGrips = true;
                                vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.PushPenstyle(vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.GripColor, 0.0d, null);
                                Fig.DrawGrips(vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender);
                                vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.PopPenstyle();
                                if (!isstarted) vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.EndDraw();
                                vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.SetScreenMode(oldScreenmode);
                                vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.RefreshGraphicsControl(vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.control);
                            }

                        }
                    }
                }
                else
                {
                    //Window selection
                    vdSelection set = null;
                    VectorDraw.Actions.StatusCode scode = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActionUtility.getUserStartWindowSelection(new Point(e.X, e.Y), out set);
                    if (scode == VectorDraw.Actions.StatusCode.Success)
                    {
                        if (!bShift && vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.PickAdd == false)
                        {
                            ClearAllGrips(GripEntities);
                        }
                        foreach (vdFigure entity in set)
                        {
                            if (bShift)
                            {

                                if (GripEntities.FindItem(entity) == true)
                                {
                                    entity.ShowGrips = false;
                                    GripEntities.RemoveItem(entity);

                                }
                                else
                                {
                                    entity.ShowGrips = true;
                                    GripEntities.AddItem(entity, false, vdSelection.AddItemCheck.RemoveInVisibleEntities);
                                }
                            }
                            else
                            {

                                if (GripEntities.FindItem(entity) == false)
                                {
                                    entity.ShowGrips = true;
                                    GripEntities.AddItem(entity, false, vdSelection.AddItemCheck.RemoveInVisibleEntities);
                                }
                            }
                        }
                        set.RemoveAll();
                        DrawGrips(GripEntities);
                        vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.RefreshGraphicsControl(vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.control);
                        
                    }
                }
                vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.LockLayerMethodStack.Pop();
                #endregion
            }
            else if (state == 3)
            {
                #region Select Specific Layer entities (red entities)
                //Almost same code as above with a Layer Check.
                vdFigure Fig = null;
                Fig = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.GetEntityFromPoint(location, vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.PickSize, false, vdDocument.LockLayerMethodEnum.EnableGetObjectGrip);
                vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.LockLayerMethodStack.Push(vdDocument.LockLayerMethodEnum.DisableAll | ((vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.LockLayerMethod & vdDocument.LockLayerMethodEnum.EnableGetObjectGrip) != 0 ? vdDocument.LockLayerMethodEnum.EnableAddToSelections : 0));
                bool bShift = ((System.Windows.Forms.Control.ModifierKeys & Keys.Shift) == Keys.Shift);
                if (Fig != null)
                {
                    if (!bShift && vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.PickAdd == false)
                    {
                        ClearAllGrips(GripEntities);
                    }
                    if (bShift && GripEntities.FindItem(Fig))
                    {
                        GripEntities.RemoveItem(Fig);
                        Fig.ShowGrips = false;
                        DrawGrips(GripEntities);
                        vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.RefreshGraphicsControl(vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.control);
                    }
                    else
                    {
                        if (GripEntities.FindItem(Fig) == false)
                        {
                            if (Fig.Layer == vdFramedControl1.BaseControl.ActiveDocument.Layers.FindName("Select"))
                            {
                                if (GripEntities.AddItem(Fig, true, vdSelection.AddItemCheck.RemoveInVisibleEntities))
                                {
                                    bool oldScreenmode = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.SetScreenMode(true);
                                    bool isstarted = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.Started;
                                    if (!isstarted) vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.StartDraw(true);
                                    Fig.ShowGrips = true;
                                    vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.PushPenstyle(vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.GripColor, 0.0d, null);
                                    Fig.DrawGrips(vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender);
                                    vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.PopPenstyle();
                                    if (!isstarted) vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.EndDraw();
                                    vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.SetScreenMode(oldScreenmode);
                                }
                            }
                        }
                    }
                }
                else
                {
                    //Window selection
                    vdSelection set = null;
                    VectorDraw.Actions.StatusCode scode = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActionUtility.getUserStartWindowSelection(new Point(e.X, e.Y), out set);
                    if (scode == VectorDraw.Actions.StatusCode.Success)
                    {
                        if (!bShift && vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.PickAdd == false)
                        {
                            ClearAllGrips(GripEntities);
                        }
                        foreach (vdFigure entity in set)
                        {
                            if (bShift)
                            {

                                if (GripEntities.FindItem(entity) == true)
                                {
                                    entity.ShowGrips = false;
                                    GripEntities.RemoveItem(entity);

                                }
                                else
                                {
                                    if (entity.Layer == vdFramedControl1.BaseControl.ActiveDocument.Layers.FindName("Select"))
                                    {
                                        entity.ShowGrips = true;
                                        GripEntities.AddItem(entity, false, vdSelection.AddItemCheck.RemoveInVisibleEntities);
                                    }
                                }
                            }
                            else
                            {

                                if (GripEntities.FindItem(entity) == false)
                                {
                                    if (entity.Layer == vdFramedControl1.BaseControl.ActiveDocument.Layers.FindName("Select"))
                                    {
                                        entity.ShowGrips = true;
                                        GripEntities.AddItem(entity, false, vdSelection.AddItemCheck.RemoveInVisibleEntities);
                                    }
                                }
                            }
                        }
                        set.RemoveAll();

                        DrawGrips(GripEntities);
                        vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.RefreshGraphicsControl(vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.control);
                    }
                }
                vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.LockLayerMethodStack.Pop();
                #endregion
            }
            else if (state == 4)
            {

            }
        }

        #region Radio Code... State selection and default vectordraw implementation Enable/Disable
        private void radioDefaultvdImplementation_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDefaultvdImplementation.Checked)
            {
                vdFramedControl1.BaseControl.ActiveDocument.EnableAutoGripOn = true;
                state = 0;
            }
            else
            {
                vdFramedControl1.BaseControl.ActiveDocument.EnableAutoGripOn = false;
            }
        }

        private void radioOneByΟne_CheckedChanged(object sender, EventArgs e)
        {
            if (radioOneByΟne.Checked) state = 1;
        }

        private void radioMultipleSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMultipleSelect.Checked) state = 2;
        }

        private void radioSelectParticularEntities_CheckedChanged(object sender, EventArgs e)
        {
            if (radioSelectParticularEntities.Checked) state = 3;
        }
        #endregion

        #region Open a File to Add some entities to the drawing
        private void AddSeveralEntities()
        {
            string filename = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\\VectorDraw.vdml";
            bool succ = vdFramedControl1.BaseControl.ActiveDocument.Open(filename);
        }
        #endregion
    }
}