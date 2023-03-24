using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Commands
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            vdFramedControl1.UnLoadMenu();
            vdFramedControl1.UnLoadCommands();
        }

        private void closeDropDownItems(object sender)
        {
            ((ToolStripDropDownItem)sender).DropDown.Hide();
            foreach (ToolStripDropDownItem var in menuStrip1.Items)
            {
                var.DropDown.Hide();
            }
            vdFramedControl1.Focus();
        }
        private void MnFile_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string command = e.ClickedItem.Text;
            if (command != "Zoom" && command != "UCS" && command != "Clip Actions" && command != "Circles" && command != "Arcs" && command != "3D Surfaces" && command != "Utility" && command != "Dimensions" && command != "Array Entities" && command != "Views")
            {
                closeDropDownItems(sender);
                ExecuteCommand(command);    
            }
        }

        private void ExecuteCommand(string command)
        {
            switch (command.ToLower())
            {
                #region Menu File
                case "new":
                    //Just call the New function that clears the document to it's defaults.
                    vdFramedControl1.BaseControl.ActiveDocument.New();
                    break;
                case "open":
                    {
                        //First we call the dialog to select the file to open and then open the file.
                        object ret = vdFramedControl1.BaseControl.ActiveDocument.GetOpenFileNameDlg(0, "", 0);
                        if (ret == null) return;
                        string fname = (string)ret;
                        bool success = vdFramedControl1.BaseControl.ActiveDocument.Open(fname);
                        if (success) vdFramedControl1.BaseControl.ActiveDocument.Redraw(true);
                    }
                    break;
                case "save":
                    //Save the document using it's own filename.
                    if (vdFramedControl1.BaseControl.ActiveDocument.FileName!=null && vdFramedControl1.BaseControl.ActiveDocument.FileName.Trim()!= "" )
                        vdFramedControl1.BaseControl.ActiveDocument.SaveAs(vdFramedControl1.BaseControl.ActiveDocument.FileName);
                    break;
                case "saveas":
                    {
                        //First we open a dialog to get the save filename and then save the document to the specified filename by ther user.
                        string ver = "";
                        string fname = vdFramedControl1.BaseControl.ActiveDocument.GetSaveFileNameDlg(vdFramedControl1.BaseControl.ActiveDocument.FileName, out ver);
                        if (fname != null)
                            vdFramedControl1.BaseControl.ActiveDocument.SaveAs(fname);
                    }
                    break;
                case "print":
                    //Open the print dialog for printing using Extends and scaletoFit default options.
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdPrintDialog("E", "F");
                    break;
                #endregion

                #region Menu Edit
                case "undo":
                    vdFramedControl1.BaseControl.ActiveDocument.UndoHistory.Undo();
                    break;
                case "redo":
                    vdFramedControl1.BaseControl.ActiveDocument.UndoHistory.Redo();
                    break;
                case "redraw":
                    vdFramedControl1.BaseControl.ActiveDocument.Redraw(false);
                    break;
                case "regen":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.RegenAll();
                    //Or you can use the following sequence of commands to do the same thing.
                    //vdFramedControl1.BaseControl.ActiveDocument.Update();
                    //vdFramedControl1.BaseControl.ActiveDocument.Redraw(false);
                    break;
                case "extends":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.Zoom("e", null, null);
                    //or
                    //vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ZoomExtents();
                    break;
                case "window":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.Zoom("w", null, null);
                    //Or
                    //vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(), new VectorDraw.Geometry.gPoint(100.0, 100.0));
                    break;
                case "all":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.Zoom("A", null, null);
                    //Or
                    //vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ZoomAll();
                    break;
                case "previous":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.Zoom("p", null, null);
                    //Or
                    //vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ZoomPrevious();
                    break;
                case "in 20%":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.Zoom("s", 1.0/0.8d, null);
                    //Or
                    //vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ZoomPrevious();
                    break;
                case "out 20%":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.Zoom("S", 0.8d, null);
                    //Or
                    //vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ZoomPrevious();
                    break;

                case "view":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.UCS("VIEW", null, null);
                    break;
                case "world":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.UCS("WORLD", null, null);
                    break;
                case "clip copy":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdClipCopy(null);
                    break;
                case "clip paste":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdClipPaste(null);
                    break;
                case "clip cut":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdClipCut(null);
                    break;
                #endregion

                #region Menu Draw
                    //parameter null means that the user will pick the required point- distance or everything that is required for the command.
                case "line":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdLine(null);
                    break;
                case "xline":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdXLine(null);
                    break;
                case "ray":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdRay(null);
                    break;
                case "point":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdPoint(null);
                    break;
                case "arc":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdArc(null, null, null, null);
                    break;
                case "3 points arc":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdArc("3p", null, null, null);
                    break;
                case "center-radius circle":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdCircle(null, null);
                    break;
                case "2 points circle":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdCircle("2p", null);
                    break;
                case "3 points circle":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdCircle("3p", null);
                    break;
                case "ellipse":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdEllipse(null, null, null);
                    break;
                case "polyline":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdPolyLine (null);
                    break;
                case "text":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdText(null, null, null);
                    break;
                case "rectangle":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdRect(null, null);
                    break;
                case "image":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdImage("", null);
                    break;
                case "add attribute":
                    VectorDraw.Professional.vdFigures.vdAttribDef def = VectorDraw.Professional.Dialogs.frmAddAttribute.Show(vdFramedControl1.BaseControl.ActiveDocument);
                    vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(def);
                    vdFramedControl1.BaseControl.ActiveDocument.ActionDrawFigure(def);
                    break;
                case "vertical":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdDim(VectorDraw.Professional.Constants.VdConstDimType.dim_Rotated, null, null, VectorDraw.Geometry.Globals.HALF_PI);
                    break;
                case "horizontal":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdDim(VectorDraw.Professional.Constants.VdConstDimType.dim_Rotated ,null,null,0.0);
                    break;
                case "aligned":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdDim(VectorDraw.Professional.Constants.VdConstDimType.dim_Aligned, null, null, 0.0);
                    break;
                case "angular":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdDim(VectorDraw.Professional.Constants.VdConstDimType.dim_Angular, null, null, 0.0);
                    break;
                case "diameter":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdDim(VectorDraw.Professional.Constants.VdConstDimType.dim_Diameter, null, null, 0.0);
                    break;
                case "radial":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdDim(VectorDraw.Professional.Constants.VdConstDimType.dim_Radial, null, null, 0.0);
                    break;
                case "box":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdBox3d(null, null, null, null, null);
                    break;
                case "sphere":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdSphere(null, null, null, null);
                    break;
                case "cone":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdCone(null, null, null, null, null);
                    break;
                case "3dmesh":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.Cmd3DMesh(null, null, null);
                    break;
                case "3dface":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.Cmd3dFace(null);
                    break;
                case "bhatch":
                    VectorDraw.Professional.Dialogs.frmGetHatchDialog.Show(null, vdFramedControl1.BaseControl.ActiveDocument , vdFramedControl1.BaseControl.ActiveDocument.ActionControl);
                    break;
                case "plinetomesh":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdPlineToMesh(null, null, null);
                    break;
                case "leader":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdLeader(null, null);
                    break;
                case "multiline":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdMultiLine(null);
                    break;
                #endregion

                #region Menu Blocks
                case "edit attribute":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.EditAttrib(null);
                    break;
                case "make block":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdMakeBlock(null, null, null);
                    break;
                case "insert block":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdInsertBlockDialog();
                    break;
                #endregion

                #region Menu Modify
                case "rotate":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdRotate(null, null, null);
                    break;
                case "copy":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdCopy(null, null, null);
                    break;
                case "erase":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdErase(null);
                    break;
                case "move":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdMove(null, null, null);
                    break;
                case "explode":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdExplode(null);
                    break;
                case "mirror":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdMirror(null, null, null, null);
                    break;
                case "break":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdBreak(null, null, null);
                    break;
                case "offset":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdOffset(null, null, null);
                    break;
                case "extend":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdExtend(null, null);
                    break;
                case "trim":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdTrim(null, null);
                    break;
                case "fillet":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdFillet(null, null);
                    break;
                case "stretch":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdStretch(null, null, null, null, null);
                    break;
                case "polar array":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdArrayPolar(null, null, null, null, null);
                    break;
                case "rectangular array":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdArrayRectangular(null, null, null, null, null);
                    break;
                #endregion

                #region View 3D
                case "rotate 3d":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VROT");
                    break;
                case "render":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("RENDER");
                    break;
                case "shade":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("SHADE");
                    break;
                case "shadeon":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("SHADEON");
                    break;
                case "hide":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("HIDE");
                    break;
                case "wire":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("WIRE");
                    break;
                case "wire 2d":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("WIRE2D");
                    break;
                case "top":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VTOP");
                    break;
                case "bottom":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VBOTTOM");
                    break;
                case "left":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VLEFT");
                    break;
                case "right":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VRIGHT");
                    break;
                case "front":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VFRONT");
                    break;
                case "back":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VBACK");
                    break;
                case "ne":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VINE");
                    break;
                case "nw":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VINW");
                    break;
                case "se":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VISE");
                    break;
                case "sw":
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VISW");
                    break;
                #endregion
                //default : MessageBox.Show ("Wrong command:" + command);break;
            }
        }

 
    }
}