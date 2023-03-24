using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Collections
{
    public partial class Form1 : Form
    {
        #region Form LOAD/UNLOAD
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //We add the "RequiredFiles" folder to the support path. This addition is made in order for our samples to get the required files from this extra folder used in distribution of our sample files.
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\RequiredFiles\\";
            vdFramedControl1.BaseControl.ActiveDocument.SupportPath = path;

            //Hide some controls unaccessary for this sample.
            vdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.CommandLine, false);
            vdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.LayoutTab, false);
            vdFramedControl1.UnLoadMenu();
            comboBox1.SelectedIndex = 0;
        }
        #endregion
        #region Buttons & Combo events
        private void butRotate3d_Click(object sender, EventArgs e)
        {
            vdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VROT");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text.ToLower())
            {
                case "blocks": AddBlockItems(); break;
                case "layers": AddLayersItems(); break;
                case "textstyles": AddTextstylesItems(); break;
                case "dimstyles": AddDimstylesItems(); break;
                case "hatchpatterns": AddHatchItems(); break;
                case "image definitions": AddImageItems(); break;
                case "linetypes": AddCustomLinetype(); break;
                case "xproperties": MessageBox.Show("No action taken"); break;
                case "external references": AddExternalReferences(); break;
                case "layouts": AddLayout(); break;
                case "lights": AddLights(); break;
                case "multilines": AddMultilineStyles(); break;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text.ToLower())
            {
                case "blocks": AddInsertObjects(); break;
                case "layers": AddEntitiesWithLayes(); break;
                case "textstyles": AddTextEntities(); break;
                case "dimstyles": AddDimensions(); break;
                case "hatchpatterns": AddHatchedEntities(); break;
                case "image definitions": AddImagesEntities(); break;
                case "linetypes": AddLines(); break;
                case "xproperties": AddXproperties(); break;
                case "external references": AddReferencesInserts(); break;
                case "layouts": AddLayoutEntities(); break;
                case "lights": Add3DEntities(); break;
                case "multilines": AddMultilines(); break;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text.ToLower())
            {
                case "blocks": OpenBlocksForm(); break;
                case "layers": OpenLayersDialog(); break;
                case "textstyles": OpenTextstylesDialog(); break;
                case "dimstyles": OpenDimstylesDialog(); break;
                case "hatchpatterns": OpenHatchPatternsDialog(); break;
                case "image definitions": OpenImageDefinitionsDialog(); break;
                case "linetypes": OpenLinetypesDialog(); break;
                case "xproperties": OpenXpropertiesdialog(); break;
                case "external references": OpenExternalReferencesDialog(); break;
                case "layouts": OpenLayoutsDialog(); break;
                case "lights": OpenLightsDialog(); break;
                case "multilines": OpenMultilinesDialog(); break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            vdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.LayoutTab, false);
            vdFramedControl1.BaseControl.ActiveDocument.New();
        }
        #endregion

        #region Blocks
        private void AddBlockItems()
        {
            vdFramedControl1.BaseControl.ActiveDocument.BlockColorOper = VectorDraw.Professional.vdObjects.vdDocument.BlockColorOperEnum.BlockColor;
            //We create a block object and initialize it's default properties.
            VectorDraw.Professional.vdPrimaries.vdBlock blk = new VectorDraw.Professional.vdPrimaries.vdBlock();
            blk.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            blk.setDocumentDefaults();
            //We add some entities to the block.
            VectorDraw.Professional.vdFigures.vdPolyline poly = new VectorDraw.Professional.vdFigures.vdPolyline();
            poly.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            poly.setDocumentDefaults();
            poly.VertexList.Add(new VectorDraw.Geometry.gPoint());
            poly.VertexList.Add(new VectorDraw.Geometry.gPoint(1.0,0.0));
            poly.VertexList.Add(new VectorDraw.Geometry.gPoint(2.0,1.0));
            poly.VertexList.Add(new VectorDraw.Geometry.gPoint(4.0,-1.0));
            poly.VertexList.Add(new VectorDraw.Geometry.gPoint(6.0,1.0));
            poly.VertexList.Add(new VectorDraw.Geometry.gPoint(8.0, -1.0));
            poly.VertexList.Add(new VectorDraw.Geometry.gPoint(10.0, 1.0));
            poly.VertexList.Add(new VectorDraw.Geometry.gPoint(11.0, 0.0));
            poly.VertexList.Add(new VectorDraw.Geometry.gPoint(12.0, 0.0));
            blk.Entities.AddItem(poly);
            blk.Origin = new VectorDraw.Geometry.gPoint(6.0, 0.0);
            blk.Name = "CustomBlock";

            VectorDraw.Professional.vdFigures.vdAttribDef attribdef = new VectorDraw.Professional.vdFigures.vdAttribDef();
            attribdef.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            attribdef.setDocumentDefaults();
            attribdef.InsertionPoint = new VectorDraw.Geometry.gPoint(5.0,1.2);
            //Name of the attribute used to be found when using the block.
            attribdef.TagString = "resistance";
            //Default value used when inserted the block from the block's dialog.
            attribdef.ValueString = "1W";
            blk.Entities.AddItem(attribdef);

            //And then we add this block to the document's blocks collection
            vdFramedControl1.BaseControl.ActiveDocument.Blocks.AddItem(blk);

            //We will also add a block from a precreated file.
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "vdblk.vdcl";
            string path1 = "";
            VectorDraw.Professional.vdPrimaries.vdBlock blk2;
            if (vdFramedControl1.BaseControl.ActiveDocument.FindFile(path , out path1))
            {
                blk2 = vdFramedControl1.BaseControl.ActiveDocument.Blocks.AddFromFile(path, false);
                //We check if a block with name CustomBlock2 already exists and if not we change the name of the block to CustomBlock2.
                 if (vdFramedControl1.BaseControl.ActiveDocument.Blocks.FindName ("CustomBlock2") == null) blk2.Name = "CustomBlock2";
            }
        }
        private void AddInsertObjects()
        {
            //We will add 5 instances(inserts) of each block to the Document with different properties.
            //First we check if the blocks have been already added to the blocks collection.
            if (vdFramedControl1.BaseControl.ActiveDocument.Blocks.FindName("CustomBlock") != null)
            {
                VectorDraw.Professional.vdFigures.vdInsert ins;
                for (short i = 0; i < 5; i++)
                {
                    ins = new VectorDraw.Professional.vdFigures.vdInsert();
                    ins.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
                    ins.setDocumentDefaults();
                    ins.Block = vdFramedControl1.BaseControl.ActiveDocument.Blocks.FindName("CustomBlock");
                    ins.InsertionPoint = new VectorDraw.Geometry.gPoint(i * 10, 10);
                    ins.PenColor.ColorIndex = i;
                    ins.Update();
                    ins.Block.Update();
                    ins.Rotation = VectorDraw.Geometry.Globals.HALF_PI/2.0 * i;

                    //This will create the necessary vdAtrib objects to the insert.
                    ins.CreateDefaultAttributes();
                    //Now we will change the value of the attribute
                    if (ins.Attributes.Count == 1)
                        ins.Attributes[0].ValueString = i.ToString() + "W";
                    
                    //And we add the entities to the Model Layout.
                    vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(ins);

                    ins = new VectorDraw.Professional.vdFigures.vdInsert();
                    ins.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
                    ins.setDocumentDefaults();
                    ins.Block = vdFramedControl1.BaseControl.ActiveDocument.Blocks.FindName("CustomBlock2");
                    ins.InsertionPoint = new VectorDraw.Geometry.gPoint(i * 10, -10);
                    ins.PenColor.ColorIndex = (short)(i*40+10);
                    ins.Xscale = 2.0;
                    ins.Yscale = 2.0;
                    ins.Rotation = -VectorDraw.Geometry.Globals.HALF_PI * i;
                    ins.Update();
                    ins.Block.Update();
                    //Since the active Layout is the model adding this insert to the Model or the ActiveLayout is the same thing.
                    vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(ins);
                }
                //Zoom extends and redraw to see the changes.
                vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ZoomExtents();
                vdFramedControl1.BaseControl.ActiveDocument.Redraw(true);
            }
            else
                MessageBox.Show("Please add blocks to the collection by pressing the proper button");
        }
        private void OpenBlocksForm()
        {
            VectorDraw.Professional.Dialogs.InsertBlockDialog form = VectorDraw.Professional.Dialogs.InsertBlockDialog.Show(vdFramedControl1.BaseControl.ActiveDocument, vdFramedControl1.BaseControl.ActiveControl, false, "");
            if (form.DialogResult == DialogResult.OK)
            {
                if (form.insertionPoint is double[])
                {
                    double[] pt = form.insertionPoint as double[];
                    form.insertionPoint = new VectorDraw.Geometry.gPoint (pt[0],pt[1],pt[2]);
                }
                if(form.scales is string)
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdInsert(form.blockname, form.insertionPoint, form.scales, form.scales, form.rotationAngle);
                else
                {
                    double[] scales = form.scales as double[];
                    vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdInsert(form.blockname,form.insertionPoint,scales[0],scales[1],form.rotationAngle);
                }
            }

            //The dialog can also be called using the CmdInsertBlockDialog command.
            //vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdInsertBlockDialog();

        }
        #endregion

        #region Layers
        private void AddLayersItems()
        {
            //We will add several Layer objects to the Document's layer collection with different properties.
            //Layer1,Entities with ByLayer value at their PenColor property obtain the PenColor of the layer.
            VectorDraw.Professional.vdPrimaries.vdLayer lay = new VectorDraw.Professional.vdPrimaries.vdLayer();
            lay.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            lay.setDocumentDefaults();
            lay.Name = "Layer1";
            lay.PenColor.SystemColor = Color.Red;
            vdFramedControl1.BaseControl.ActiveDocument.Layers.AddItem(lay);

            //You can also add layers using the Add function of the collection which is much easier to use.
            //Layer2,Entities with ByLayer value at their LineType property obtain the LineType of the layer.
            VectorDraw.Professional.vdPrimaries.vdLayer lay2 = vdFramedControl1.BaseControl.ActiveDocument.Layers.Add("Layer2");
            lay2.PenColor.ColorIndex = 2;
            lay2.LineType = vdFramedControl1.BaseControl.ActiveDocument.LineTypes.DPIDashDotDot;

            //Layer3,Entities with ByLayer value at their LineWeight property obtain the Lineweight of the layer.
            VectorDraw.Professional.vdPrimaries.vdLayer lay3 = vdFramedControl1.BaseControl.ActiveDocument.Layers.Add("Layer3");
            lay3.PenColor.ColorIndex = 3;
            lay3.LineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_158;

            //Layer4,Entities with frozen layers are not drawn.
            VectorDraw.Professional.vdPrimaries.vdLayer lay4 = vdFramedControl1.BaseControl.ActiveDocument.Layers.Add("Layer4");
            lay4.PenColor.ColorIndex = 4;
            lay4.Frozen = true;

            //Layer5,Entities with locked layers cannot be deleted.
            VectorDraw.Professional.vdPrimaries.vdLayer lay5 = vdFramedControl1.BaseControl.ActiveDocument.Layers.Add("Layer5");
            lay5.PenColor.ColorIndex = 5;
            lay5.Lock = true;
        }
        private void AddEntitiesWithLayes()
        {
            //First we check if the Layers have been added to the collection!!!
            if (vdFramedControl1.BaseControl.ActiveDocument.Layers.Count > 4)
            {
                //We will add 5 circles with different layer property each.
                for (int i = 0; i < 5; i++)
                {
                    VectorDraw.Professional.vdFigures.vdCircle circ = new VectorDraw.Professional.vdFigures.vdCircle();
                    circ.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
                    circ.setDocumentDefaults();
                    circ.Center = new VectorDraw.Geometry.gPoint(i * 10.0, 10.0);
                    circ.Radius = 4.0;
                    if (Math.IEEERemainder(i, 2) == 0)
                        circ.ExtrusionVector = new VectorDraw.Geometry.Vector(0, 1, 1);

                    //We give each circle a different layer.
                    string layername = "Layer" + (i+1).ToString();
                    VectorDraw.Professional.vdPrimaries.vdLayer lay = vdFramedControl1.BaseControl.ActiveDocument.Layers.FindName(layername);
                    //We check again if the layer exists because the check we did at the begining with the count does not mean that this layer exist.
                    if (lay != null)
                    {
                        circ.Layer = vdFramedControl1.BaseControl.ActiveDocument.Layers.FindName(layername);
                        vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(circ);
                    }
                }
                
                //We Add a vdText object just to explain what these entities are.
                VectorDraw.Professional.vdFigures.vdText text = new VectorDraw.Professional.vdFigures.vdText();
                text.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
                text.setDocumentDefaults();
                text.InsertionPoint = new VectorDraw.Geometry.gPoint(5, 2);
                text.TextString = "5 Circles with different Layer and Extrusion Vector";
                vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(text);

                //Zoom and Redraw.
                vdFramedControl1.BaseControl.ActiveDocument.Model.ZoomExtents();
                vdFramedControl1.BaseControl.ActiveDocument.Redraw(true);
            }
            else
                MessageBox.Show("Please Add Layers With the proper button");
        }
        private void OpenLayersDialog()
        {
            VectorDraw.Professional.Dialogs.LayersDialog.Show (vdFramedControl1.BaseControl.ActiveDocument );
        }
        #endregion

        #region TextStyles
        private void AddTextstylesItems()
        {
            //We add a textstyle with font name Verdana.
            VectorDraw.Professional.vdPrimaries.vdTextstyle style1 = new VectorDraw.Professional.vdPrimaries.vdTextstyle();
            style1.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            style1.setDocumentDefaults();
            style1.Name = "TextStyle1";
            style1.FontFile = "Verdana";
            vdFramedControl1.BaseControl.ActiveDocument.TextStyles.AddItem(style1);

            //You can also add Textstyles using the Add function of the collection which is much easier.
            VectorDraw.Professional.vdPrimaries.vdTextstyle style2 = vdFramedControl1.BaseControl.ActiveDocument.TextStyles.Add("Textstyle2");
            style2.Extra.IsUnderLine = true;
            style2.Extra.IsStrikeOut = true;
            style2.FontFile = "Wingdings 2";
        }
        private void AddTextEntities()
        {
            //Just a simple check if some Textstyles have been added.
            if (vdFramedControl1.BaseControl.ActiveDocument.TextStyles.Count > 2)
            {
                //We will add 3 vdText objects that will have different Textstyles
                for (int i = 0; i < 3; i++)
                {
                    VectorDraw.Professional.vdFigures.vdText text = new VectorDraw.Professional.vdFigures.vdText();
                    text.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
                    text.setDocumentDefaults();
                    text.InsertionPoint = new VectorDraw.Geometry.gPoint(10.0, i * 10.0);
                    string TextStyleName = "Textstyle" + i.ToString();
                    //We always check if the textstyle exists.If not we set the Default STANDARD Textstyle.
                    //The Default Textstyle will be set to the first text since Textstyle0 does not exist and to the others if the AddTextstyles button is not yet pressed..
                    VectorDraw.Professional.vdPrimaries.vdTextstyle style = vdFramedControl1.BaseControl.ActiveDocument.TextStyles.FindName(TextStyleName);
                    if (style != null)
                    {
                        text.Style = style;
                    }
                    else
                        text.Style = vdFramedControl1.BaseControl.ActiveDocument.TextStyles.Standard;

                    text.TextString = "Text using " + text.Style.Name + " Textstyle";
                    vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(text);
                }
                //Zoom and Redraw.
                vdFramedControl1.BaseControl.ActiveDocument.Model.ZoomExtents();
                vdFramedControl1.BaseControl.ActiveDocument.Redraw(true);
            }
            else
                MessageBox.Show("Please Add TextStyles With the proper button");
            
        }
        private void OpenTextstylesDialog()
        {
            VectorDraw.Professional.Dialogs.frmTextStyle.Show (vdFramedControl1.BaseControl.ActiveDocument);
        }
        #endregion

        #region DimStyles
        private void AddDimstylesItems()
        {
            //We create a vdDimstyle object.
            VectorDraw.Professional.vdPrimaries.vdDimstyle style1 = new VectorDraw.Professional.vdPrimaries.vdDimstyle();
            style1.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            style1.setDocumentDefaults();
            //And change some properties.
            style1.Name = "DimStyle1";
            style1.TextColor.ColorIndex = 1;
            style1.TextHeight = 0.5;
            //And add this object to the Dimstyles collection of the document.
            vdFramedControl1.BaseControl.ActiveDocument.DimStyles.AddItem(style1);

            //We can also add dimstyles using the Add function of the dimstyles collection which is much easier.
            VectorDraw.Professional.vdPrimaries.vdDimstyle style2 = vdFramedControl1.BaseControl.ActiveDocument.DimStyles.Add("DimStyle2");
            style2.ExtLineVisible = false;
            style2.TextHeight = 0.5;

            VectorDraw.Professional.vdPrimaries.vdDimstyle style3 = vdFramedControl1.BaseControl.ActiveDocument.DimStyles.Add("DimStyle3");
            style3.ExtLineColor.ColorIndex = 1;
            style3.DimTol = true;
            style3.DimTp = 0.3;
            style3.DimTm = 0.3;
            style3.TextHeight = 0.5;

            VectorDraw.Professional.vdPrimaries.vdDimstyle style4 = vdFramedControl1.BaseControl.ActiveDocument.DimStyles.Add("DimStyle4");
            style4.DimAdec = 0;
            style4.DecimalPrecision = 0;
            style4.TextHeight = 0.5;

            VectorDraw.Professional.vdPrimaries.vdDimstyle style5 = vdFramedControl1.BaseControl.ActiveDocument.DimStyles.Add("DimStyle5");
            style5.ArrowBlock = vdFramedControl1.BaseControl.ActiveDocument.Blocks.VDDIM_NONE;
            style5.TextHeight = 0.5;

            VectorDraw.Professional.vdPrimaries.vdDimstyle style6 = vdFramedControl1.BaseControl.ActiveDocument.DimStyles.Add("DimStyle6");
            style6.ArrowSize *= 5.0;
            style6.TextHeight = 0.5;
        }
        private void AddDimensions()
        {
            //Just a simple check to verify that the Adddimstyles button is pressed
            if (vdFramedControl1.BaseControl.ActiveDocument.DimStyles.Count < 4)
            {
                MessageBox.Show("Please Add some DimStyles with the proper button for better results.");
                return;
            }

            //We will create 6 dimension of each type(6 types)
            for (int i = 0; i < 6; i++)
            {
                string dimname = "DimStyle" + (i + 1).ToString();
                VectorDraw.Professional.vdPrimaries.vdDimstyle style = vdFramedControl1.BaseControl.ActiveDocument.DimStyles.FindName(dimname);
                if (style == null)
                    style = vdFramedControl1.BaseControl.ActiveDocument.DimStyles.Standard;

                #region Rotated 0 degrees
                VectorDraw.Professional.vdFigures.vdDimension dim1 = new VectorDraw.Professional.vdFigures.vdDimension();
                dim1.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
                dim1.setDocumentDefaults();
                dim1.dimType = VectorDraw.Professional.Constants.VdConstDimType.dim_Rotated;
                dim1.DefPoint1 = new VectorDraw.Geometry.gPoint(5.0, 5 * i);
                dim1.DefPoint2 = new VectorDraw.Geometry.gPoint(10.5, 5 * i+2.0);
                dim1.LinePosition = new VectorDraw.Geometry.gPoint(7.0, 5 * i + 4.0);
                dim1.Rotation = 0.0;
                //We set the dim style that we found before.
                dim1.Style = style;
                //We add the object to the model entities collection
                vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(dim1);
                #endregion

                #region Rotated 90 degrees
                VectorDraw.Professional.vdFigures.vdDimension dim2 = new VectorDraw.Professional.vdFigures.vdDimension();
                dim2.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
                dim2.setDocumentDefaults();
                dim2.dimType = VectorDraw.Professional.Constants.VdConstDimType.dim_Rotated;
                dim2.DefPoint1 = new VectorDraw.Geometry.gPoint(12.0, 5 * i);
                dim2.DefPoint2 = new VectorDraw.Geometry.gPoint(15.5, 5 * i + 4.5);
                dim2.LinePosition = new VectorDraw.Geometry.gPoint(17.0, 5 * i + 4.0);
                dim2.Rotation = VectorDraw.Geometry.Globals.HALF_PI;
                dim2.Style = style;
                
                vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(dim2);
                #endregion

                #region Aligned
                VectorDraw.Professional.vdFigures.vdDimension dim3 = new VectorDraw.Professional.vdFigures.vdDimension();
                dim3.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
                dim3.setDocumentDefaults();
                dim3.dimType = VectorDraw.Professional.Constants.VdConstDimType.dim_Aligned;
                dim3.DefPoint1 = new VectorDraw.Geometry.gPoint(19, 5 * i);
                dim3.DefPoint2 = new VectorDraw.Geometry.gPoint(23.5, 5 * i + 3.0);
                dim3.LinePosition = VectorDraw.Geometry.gPoint.Polar(new VectorDraw.Geometry.gPoint(19, 5 * i), VectorDraw.Geometry.Globals.HALF_PI / 2.0, 7.0);
                dim3.Style = style;

                vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(dim3);
                #endregion

                #region Diameter
                VectorDraw.Professional.vdFigures.vdCircle circ = new VectorDraw.Professional.vdFigures.vdCircle();
                circ.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
                circ.setDocumentDefaults();
                circ.Center = new VectorDraw.Geometry.gPoint(29, 5 * i);
                circ.Radius = 2.4;
                vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(circ);

                VectorDraw.Professional.vdFigures.vdDimension dim4 = new VectorDraw.Professional.vdFigures.vdDimension();
                dim4.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
                dim4.setDocumentDefaults();
                dim4.dimType = VectorDraw.Professional.Constants.VdConstDimType.dim_Diameter;
                dim4.DefPoint1 = new VectorDraw.Geometry.gPoint(31.4, 5 * i);
                dim4.DefPoint2 = new VectorDraw.Geometry.gPoint(29, 5 * i);
                dim4.DefPoint3 = new VectorDraw.Geometry.gPoint(29, 5 * i);
                dim4.DefPoint4 = new VectorDraw.Geometry.gPoint(29, 5 * i);
                dim4.LinePosition = new VectorDraw.Geometry.gPoint(26.6, 5 * i);
                dim4.Style = style;

                vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(dim4);
                #endregion

                #region Radial
                circ = new VectorDraw.Professional.vdFigures.vdCircle();
                circ.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
                circ.setDocumentDefaults();
                circ.Center = new VectorDraw.Geometry.gPoint(35, 5 * i);
                circ.Radius = 3.4;
                vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(circ);

                dim4 = new VectorDraw.Professional.vdFigures.vdDimension();
                dim4.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
                dim4.setDocumentDefaults();
                dim4.dimType = VectorDraw.Professional.Constants.VdConstDimType.dim_Radial;
                dim4.DefPoint1 = new VectorDraw.Geometry.gPoint(38.4, 5 * i);
                dim4.DefPoint2 = new VectorDraw.Geometry.gPoint(35, 5 * i);
                dim4.DefPoint3 = new VectorDraw.Geometry.gPoint(35, 5 * i);
                dim4.DefPoint4 = new VectorDraw.Geometry.gPoint(35, 5 * i);
                dim4.LinePosition = new VectorDraw.Geometry.gPoint(35, 5 * i);
                dim4.Style = style;

                vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(dim4);
                #endregion

                #region Angular
                VectorDraw.Professional.vdFigures.vdPolyline poly = new VectorDraw.Professional.vdFigures.vdPolyline();
                poly.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
                poly.setDocumentDefaults();
                poly.VertexList.Add(new VectorDraw.Geometry.gPoint(45,5*i+4));
                poly.VertexList.Add(new VectorDraw.Geometry.gPoint(40,5*i));
                poly.VertexList.Add(new VectorDraw.Geometry.gPoint(47,5*i));
                vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(poly);

                dim4 = new VectorDraw.Professional.vdFigures.vdDimension();
                dim4.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
                dim4.setDocumentDefaults();
                dim4.dimType = VectorDraw.Professional.Constants.VdConstDimType.dim_Angular;
                dim4.DefPoint1 = new VectorDraw.Geometry.gPoint(40, 5 * i);
                dim4.DefPoint2 = new VectorDraw.Geometry.gPoint(45, 5 * i+4);
                dim4.DefPoint3 = new VectorDraw.Geometry.gPoint(45, 5 * i+4);
                dim4.DefPoint4 = new VectorDraw.Geometry.gPoint(47, 5 * i);
                dim4.LinePosition = new VectorDraw.Geometry.gPoint(43, 5 * i + 2.0);
                dim4.Style = style;
                vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(dim4);
                #endregion
            }
            vdFramedControl1.BaseControl.ActiveDocument.Model.ZoomExtents();
            vdFramedControl1.BaseControl.ActiveDocument.Redraw(true);
        }
        private void OpenDimstylesDialog()
        {
            VectorDraw.Professional.Dialogs.frmDimStyle.Show (vdFramedControl1.BaseControl.ActiveDocument);
        }
        #endregion

        #region HatchPatterns
        private void AddHatchItems()
        {
            VectorDraw.Professional.vdPrimaries.vdHatchPattern myHatch = new VectorDraw.Professional.vdPrimaries.vdHatchPattern();

            myHatch.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);

            myHatch.setDocumentDefaults();

            myHatch.Name = "TEST_HATCH"; //hatch is created and it is empty

            //Add 2 lines with dashes to the hatch pattern

            myHatch.PatternLines.AddItem(new VectorDraw.DrawElements.grPatternLine(0.0d, 0.0d, 0.0d, 0.0d, 5.0d, new double[] { 3.0d, -3.0d }, false));

            myHatch.PatternLines.AddItem(new VectorDraw.DrawElements.grPatternLine(VectorDraw.Geometry.Globals.HALF_PI, 0.0d, 10.0d, 6.0d, 0.0d, new double[] { 3.0d, -2.0d }, false));


            // OR you can do the same as below:

            //myHatch.PatternLines.AddItem(new VectorDraw.DrawElements.grPatternLine(0.0d, 0.0d, 0.0d, 0.0d, 5.0d, new double[] { 3.0d, -3.0d }, false));

            //myHatch.PatternLines.AddItem(new VectorDraw.DrawElements.grPatternLine(90.0d, 0d, 10d, 0.0d, 6.0d, new double[] { 3, -2 }, true));


            // Important Notes: grPatternLine(angle, originX, originY, offsetX, offsetY, double[] dashes, bool applytransforms)

            // - When you use the applytransforms = true then you have to use degrees (like 90 degrees) and not radians (like PI/2) in the angle

            // - The point(OriginX,OriginY) remains the same as when you use applytransforms = false

            // - The offset distance is translated accordingly with the angle. In the above example the offset distance x:6 & y:0 when is transformed by angle=90 becomes

            // the opposite; x:0 & y:6


            myHatch.Update(); //Update the Hatch

            vdFramedControl1.BaseControl.ActiveDocument.HatchPatterns.AddItem(myHatch); //add the hatch to the collection

            MessageBox.Show("A custom Hatch pattern has been created and added to the list with name TEST_HATCH");
        }
        private void AddHatchedEntities()
        {
            VectorDraw.Professional.vdFigures.vdCircle circ1 = new VectorDraw.Professional.vdFigures.vdCircle();
            circ1.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            circ1.setDocumentDefaults();
            circ1.Center = new VectorDraw.Geometry.gPoint(10.0, 10.0);
            circ1.Radius = 7.0;
            circ1.HatchProperties = new VectorDraw.Professional.vdObjects.vdHatchProperties();
            circ1.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid;
            circ1.HatchProperties.FillColor.ColorIndex = 1;
            vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(circ1);

            circ1 = new VectorDraw.Professional.vdFigures.vdCircle();
            circ1.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            circ1.setDocumentDefaults();
            circ1.Center = new VectorDraw.Geometry.gPoint(20.0, 10.0);
            circ1.Radius = 5.0;
            circ1.HatchProperties = new VectorDraw.Professional.vdObjects.vdHatchProperties();
            circ1.HatchProperties.Solid2dTransparency = 100;
            circ1.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid;
            circ1.HatchProperties.FillColor.ColorIndex = 2;
            vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(circ1);

            //And a gradient fill circle
            circ1 = new VectorDraw.Professional.vdFigures.vdCircle();
            circ1.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            circ1.setDocumentDefaults();
            circ1.Center = new VectorDraw.Geometry.gPoint(40.0, 20.0);
            circ1.Radius = 10.0;
            circ1.HatchProperties = new VectorDraw.Professional.vdObjects.vdHatchProperties( VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid);
            circ1.HatchProperties.FillColor.ColorIndex = 3;
            circ1.HatchProperties.gradientColor2.ColorIndex = 4;
            circ1.HatchProperties.gradientTypeProp = VectorDraw.Render.vdGdiPenStyle.GradientType.HemiSphericalInverted;
            vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(circ1);

            VectorDraw.Professional.vdFigures.vdPolyline poly = new VectorDraw.Professional.vdFigures.vdPolyline();
            poly.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            poly.setDocumentDefaults();
            poly.VertexList.Add (new VectorDraw.Geometry.gPoint (10.0,-10.0));
            poly.VertexList.Add(new VectorDraw.Geometry.gPoint(20.0, -10.0));
            poly.VertexList.Add(new VectorDraw.Geometry.gPoint(25.0, -20.0));
            poly.VertexList.Add(new VectorDraw.Geometry.gPoint(5.0, -20.0));
            poly.Flag = VectorDraw.Professional.Constants.VdConstPlineFlag.PlFlagCLOSE;

            poly.HatchProperties = new VectorDraw.Professional.vdObjects.vdHatchProperties();
            poly.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModePattern;
            poly.HatchProperties.FillColor.ColorIndex = 0;
            poly.HatchProperties.FillBkColor.ColorIndex = 2;
            poly.HatchProperties.HatchPattern = vdFramedControl1.BaseControl.ActiveDocument.HatchPatterns.FindName("TEST_HATCH");
            poly.HatchProperties.HatchScale = 0.5;
            vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(poly);

            VectorDraw.Professional.vdFigures.vdArc arc = new VectorDraw.Professional.vdFigures.vdArc();
            arc.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            arc.setDocumentDefaults();
            arc.Center = new VectorDraw.Geometry.gPoint(30, -4);
            arc.Radius = 10.0;
            arc.StartAngle = VectorDraw.Geometry.Globals.DegreesToRadians(13.0);
            arc.EndAngle = VectorDraw.Geometry.Globals.DegreesToRadians(175.0);

            arc.HatchProperties = new VectorDraw.Professional.vdObjects.vdHatchProperties();
            arc.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeHatchBlock;
            arc.HatchProperties.FillColor.SystemColor = Color.Blue;
            arc.HatchProperties.HatchBlock = vdFramedControl1.BaseControl.ActiveDocument.Blocks.VDDIM_DEFAULT;
            arc.HatchProperties.HatchAngle = VectorDraw.Geometry.Globals.DegreesToRadians(33.0);
            arc.HatchProperties.HatchScale = 0.3;
            vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(arc);


            vdFramedControl1.BaseControl.ActiveDocument.Model.ZoomExtents();
            vdFramedControl1.BaseControl.ActiveDocument.Redraw(true);
        }
        private void OpenHatchPatternsDialog()
        {
            VectorDraw.Professional.Dialogs.GetHatchPatternsDialog frm = VectorDraw.Professional.Dialogs.GetHatchPatternsDialog.Show(vdFramedControl1.BaseControl.ActiveDocument, vdFramedControl1.BaseControl.ActiveControl, vdFramedControl1.BaseControl.ActiveDocument.HatchPatterns.Solid);
            if (frm.finalSelected!=null)
                MessageBox.Show(frm.finalSelected.Name + " pattern selected");
            else
                MessageBox.Show("Cancel button pressed");
        }
        #endregion

        #region Images
        private void AddImageItems()
        {
            //We will create an image and add it to the imageDef

            //First we create a black circle with radius 5.0 at (0.0,0.0,0.0).
            VectorDraw.Professional.vdFigures.vdCircle circle = new VectorDraw.Professional.vdFigures.vdCircle();
            circle.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            circle.setDocumentDefaults();
            circle.Center = new VectorDraw.Geometry.gPoint();
            circle.Radius = 5.0;
            circle.PenColor.SystemColor = Color.Black;
            circle.PenWidth = 0.3;

            //Then we create a layout to add this circle.Note that this is a temporary layout and it is not added to the document at all.
            VectorDraw.Professional.vdPrimaries.vdLayout lay = new VectorDraw.Professional.vdPrimaries.vdLayout();
            lay.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            lay.setDocumentDefaults();
            lay.Entities.AddItem(circle);
            lay.BkColorEx = Color.Red;
            //This property overides the general DisableShowPrinterPaper property that is located in the ActiveDocument.
            lay.DisableShowPrinterPaper = true;
            //We zoom the layout where we want to show the circle.
            lay.ZoomWindow (new VectorDraw.Geometry.gPoint(-6.0,-6.0),new VectorDraw.Geometry.gPoint(6,6));

            //We create a 250,250 image and a Graphics from that image.
            System.Drawing.Bitmap image = new Bitmap(250, 250);
            System.Drawing.Graphics gr = System.Drawing.Graphics.FromImage(image);

            //We draw the layout to that image.We first disable the layout paper and enable it again.
            lay.RenderToGraphics(gr, null, image.Width, image.Height);

            //From that image we create the imageDefinition.
            VectorDraw.Professional.vdPrimaries.vdImageDef imagedef = new VectorDraw.Professional.vdPrimaries.vdImageDef();
            imagedef.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            imagedef.setDocumentDefaults();
            imagedef.Name = "Image1";
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            imagedef.InternalSetBytes(new VectorDraw.Geometry.ByteArray(stream.ToArray()));
            vdFramedControl1.BaseControl.ActiveDocument.Images.AddItem(imagedef);

            //We dispose any objects that we don't want.
            stream.Close();
            stream.Dispose();
            gr.Dispose();
            //We could have saved the image to the drive using the Save function.
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "vdimage.bmp";
            image.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
            //And create a second imageDef from this filename.
            VectorDraw.Professional.vdPrimaries.vdImageDef imagedef1 = new VectorDraw.Professional.vdPrimaries.vdImageDef();
            imagedef1.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            imagedef1.setDocumentDefaults();
            imagedef1.Name = "Image2";

            imagedef1.FileName = path;
            vdFramedControl1.BaseControl.ActiveDocument.Images.AddItem(imagedef1);

            image.Dispose();
             
            MessageBox.Show ("An image was created (silently) from rendered objects and has been added to the Images collection of the document.");
        }
        private void AddImagesEntities()
        {
            if (vdFramedControl1.BaseControl.ActiveDocument.Images.Count == 0)
            {
                MessageBox.Show("Please Add Collection item first");
                return;
            }
            //We create an image and give the precreated image definition.
            VectorDraw.Professional.vdFigures.vdImage image = new VectorDraw.Professional.vdFigures.vdImage();
            image.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            image.setDocumentDefaults();
            //We know that the first image is what we want so we can just get the [0] item from the collection else we could have used the Find methods.
            image.ImageDefinition = vdFramedControl1.BaseControl.ActiveDocument.Images[0];
            image.InsertionPoint = new VectorDraw.Geometry.gPoint(1.0,1.0);
            vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(image);
            
            //We will also add an image that will be clipped.
            image = new VectorDraw.Professional.vdFigures.vdImage();
            image.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            image.setDocumentDefaults();
            image.ImageDefinition = vdFramedControl1.BaseControl.ActiveDocument.Images[0];
            image.InsertionPoint = new VectorDraw.Geometry.gPoint(-3.0, 1.0);
            vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(image);

            //And clip the image!!! Note that the cli points are relative to the upper corner of the image in Pixels.
            image.ClipBoundary.Add (new VectorDraw.Geometry.gPoint(0.0,0.0,0.0));
            image.ClipBoundary.Add(new VectorDraw.Geometry.gPoint(image.ImageDefinition.Width, 0.0, 0.0));
            image.ClipBoundary.Add(new VectorDraw.Geometry.gPoint(0.0, image.ImageDefinition.Height, 0.0));

            vdFramedControl1.BaseControl.ActiveDocument.Redraw(true);
            MessageBox.Show("We added two images one regular and one with clip points!!");
        }
        private void OpenImageDefinitionsDialog()
        {
            VectorDraw.Professional.Dialogs.FrmImageDefs.Show (vdFramedControl1.BaseControl.ActiveDocument);
        }
        #endregion

        #region Linetypes
        private void AddCustomLinetype()
        {
            VectorDraw.Professional.vdPrimaries.vdLineType linetype = new VectorDraw.Professional.vdPrimaries.vdLineType();
            linetype.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            linetype.setDocumentDefaults();
            linetype.Name = "MyCustomLinetype";

            linetype.Comment = "Custom _ . . _ _ . . _ _ . . _ _ . . _ _ . . _ _ . . _";
            //Dash
            linetype.Segments.AddItem(new VectorDraw.Render.LineTypeSegment(0.5));
            //Blank
            linetype.Segments.AddItem(new VectorDraw.Render.LineTypeSegment(-0.5));
            //Dash
            linetype.Segments.AddItem(new VectorDraw.Render.LineTypeSegment(0.5));
            //Blank
            linetype.Segments.AddItem(new VectorDraw.Render.LineTypeSegment(-0.5));
            //Dot
            linetype.Segments.AddItem(new VectorDraw.Render.LineTypeSegment(0.0));
            //Blank
            linetype.Segments.AddItem(new VectorDraw.Render.LineTypeSegment(-0.5));
            //Dot
            linetype.Segments.AddItem(new VectorDraw.Render.LineTypeSegment(0.0));
            //Blank
            linetype.Segments.AddItem(new VectorDraw.Render.LineTypeSegment(-0.5));
            linetype.Segments.UpdateLength();

            vdFramedControl1.BaseControl.ActiveDocument.LineTypes.AddItem(linetype);
            MessageBox.Show("We created a custom Linetype named MyCustomLinetype and looks like this:  _ . . _");

            //We will add a second Custom linetype that contains text.
            linetype = new VectorDraw.Professional.vdPrimaries.vdLineType();
            linetype.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            linetype.setDocumentDefaults();
            linetype.Name = "MyCustomLinetype2";

            linetype.Comment = "Custom2 _ VD _ _ VD _ _ VD _ _ VD _ _ VD _ _ VD _ ";
            //Dash
            linetype.Segments.AddItem(new VectorDraw.Render.LineTypeSegment(2.0));
            //Blank
            linetype.Segments.AddItem(new VectorDraw.Render.LineTypeSegment(-1.0));

            VectorDraw.Render.LineTypeSegment seg = new VectorDraw.Render.LineTypeSegment();
            seg.Flag = VectorDraw.Render.LineTypeSegment.LineTypeElementType.TTF_TEXT;
            seg.ShapeScale = 0.7;
            seg.ShapeStyle = vdFramedControl1.BaseControl.ActiveDocument.TextStyles.Standard.GrTextStyle;
            seg.ShapeText = "VD";
            linetype.Segments.AddItem(seg);
            
            //Blank
            linetype.Segments.AddItem(new VectorDraw.Render.LineTypeSegment(-2.0));
            //Dash
            linetype.Segments.AddItem(new VectorDraw.Render.LineTypeSegment(2.0));
            //Blank
            linetype.Segments.AddItem(new VectorDraw.Render.LineTypeSegment(-1.0));
            linetype.Segments.UpdateLength();
            
            vdFramedControl1.BaseControl.ActiveDocument.LineTypes.AddItem(linetype);
            MessageBox.Show("We created a custom Linetype named MyCustomLinetype2 and looks like this:  _ VD _");
        }
        private void AddLines()
        {
            //We will add several Lines with different Linetypes.
            for (short i = 0; i < 5; i++)
            {
                VectorDraw.Professional.vdFigures.vdLine line = new VectorDraw.Professional.vdFigures.vdLine(new VectorDraw.Geometry.gPoint(i * 5.0 + 5.0, -25.0), new VectorDraw.Geometry.gPoint(i * 5.0 + 5.0, 25.0));
                line.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
                line.setDocumentDefaults();
                line.PenColor.ColorIndex = i;

                //We will create a linetype for the line
                VectorDraw.Professional.vdPrimaries.vdLineType linetype = new VectorDraw.Professional.vdPrimaries.vdLineType();
                
                switch (i)
                {
                    case 0: linetype = vdFramedControl1.BaseControl.ActiveDocument.LineTypes.FindName("MyCustomLinetype"); break;
                    case 1: linetype = vdFramedControl1.BaseControl.ActiveDocument.LineTypes.FindName("MyCustomLinetype2"); break;
                    case 2: linetype = vdFramedControl1.BaseControl.ActiveDocument.LineTypes.FindName("BORDER"); break;
                    case 3: linetype = vdFramedControl1.BaseControl.ActiveDocument.LineTypes.FindName("SOLID"); break;
                    case 4: linetype = vdFramedControl1.BaseControl.ActiveDocument.LineTypes.FindName("DOTX2"); break;
                }
                //Set the found linetype to the line.
                if (linetype!=null) line.LineType = linetype;

                //Add the line to the model.
                vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(line);
            }
            //Zoom the model and redraw to see the added figures.
            vdFramedControl1.BaseControl.ActiveDocument.Model.ZoomWindow(new VectorDraw.Geometry.gPoint(0.0, -30.0), new VectorDraw.Geometry.gPoint(30.0, 30.0));
            vdFramedControl1.BaseControl.ActiveDocument.Redraw(true);
        }
        private void OpenLinetypesDialog()
        {
            VectorDraw.Professional.Dialogs.GetLineTypeDialog frm = VectorDraw.Professional.Dialogs.GetLineTypeDialog.Show(vdFramedControl1.BaseControl.ActiveDocument, vdFramedControl1.BaseControl.ActiveControl, "Solid", true);
            DialogResult res = frm.DialogResult;
            if (res == DialogResult.OK )
                MessageBox.Show(frm.finalSelected + " Linetype Selected");
            else
                MessageBox.Show("Cancel button pressed");
        }      
        #endregion

        #region Xproperties
        private void AddXproperties()
        {
            //We will add a circle to the model with several xproperties in it's collection.
            VectorDraw.Professional.vdFigures.vdCircle circle = new VectorDraw.Professional.vdFigures.vdCircle();
            circle.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            circle.setDocumentDefaults();
            circle.Radius = 5.0;

            //Add string value xproperty.
            VectorDraw.Professional.vdObjects.vdXProperty xprop = new VectorDraw.Professional.vdObjects.vdXProperty();
            xprop.Name = "str";
            xprop.PropValue = "string value";
            circle.XProperties.AddItem(xprop);

            //Add integer value xproperty.
            xprop = new VectorDraw.Professional.vdObjects.vdXProperty();
            xprop.Name = "int";
            xprop.PropValue = 5;
            circle.XProperties.AddItem(xprop);

            //Add double value xproperty.
            xprop = new VectorDraw.Professional.vdObjects.vdXProperty();
            xprop.Name = "double";
            xprop.PropValue = 3.0;
            circle.XProperties.AddItem(xprop);

            //Add gpoint value xproperty.
            xprop = new VectorDraw.Professional.vdObjects.vdXProperty();
            xprop.Name = "Point";
            xprop.PropValue = new VectorDraw.Geometry.gPoint (5.0,5.0,0.0);
            xprop.TransformID = VectorDraw.Professional.vdObjects.vdXProperty.TransformationType.None;
            circle.XProperties.AddItem(xprop);

            //Add world gpoint value xproperty.
            xprop = new VectorDraw.Professional.vdObjects.vdXProperty();
            xprop.Name = "World point";
            xprop.PropValue = new VectorDraw.Geometry.gPoint(5.0, 5.0, 0.0);
            xprop.TransformID = VectorDraw.Professional.vdObjects.vdXProperty.TransformationType.WorldDirection;
            circle.XProperties.AddItem(xprop);

            //Add distance value xproperty.
            xprop = new VectorDraw.Professional.vdObjects.vdXProperty();
            xprop.Name = "Distance";
            xprop.PropValue = 7.0;
            xprop.TransformID = VectorDraw.Professional.vdObjects.vdXProperty.TransformationType.WorldSpaceDist;
            circle.XProperties.AddItem(xprop);

            //Add an object value xproperty.
            xprop = new VectorDraw.Professional.vdObjects.vdXProperty();
            xprop.Name = "BinDATA";
            xprop.PropValue = new VectorDraw.Geometry.ByteArray ("BinDATA",Encoding.Default);
            circle.XProperties.AddItem(xprop);

            //Add an object value xproperty.
            xprop = new VectorDraw.Professional.vdObjects.vdXProperty();
            xprop.Name = "object";
            xprop.PropValue = vdFramedControl1.BaseControl.ActiveDocument.Palette[0] as object;
            circle.XProperties.AddItem(xprop);

            xprop = new VectorDraw.Professional.vdObjects.vdXProperty();
            xprop.Name = "My_Object";
            xprop.PropValue = new MyObject(10.0d, "ten");
            circle.XProperties.AddItem(xprop);

            vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(circle);
            vdFramedControl1.BaseControl.ActiveDocument.Redraw(true);
        }
        private void OpenXpropertiesdialog()
        {
            if (vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.Count == 0)
                MessageBox.Show("Please press the add entities button.");
            else
            {
                VectorDraw.Professional.vdPrimaries.vdFigure fig = vdFramedControl1.BaseControl.ActiveDocument.Model.Entities[0];
                VectorDraw.Professional.Dialogs.frmShowXProperties.Show (vdFramedControl1.BaseControl.ActiveDocument, fig.XProperties);
            }
        }
        #endregion

        #region External References
        private void AddExternalReferences()
        {
            //We will add a vdblock object as an external reference to the blocks dialog.
            
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "wmap.vdcl";
            VectorDraw.Professional.vdPrimaries.vdBlock xref = new VectorDraw.Professional.vdPrimaries.vdBlock();
            xref.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            xref.setDocumentDefaults();
            xref.Name = "wmap";
            xref.ExternalReferencePath = path;
            //With update the file is opened and the document of the file is added to the External references of the file.
            xref.Update();
            vdFramedControl1.BaseControl.ActiveDocument.Blocks.AddItem(xref);
        }
        private void AddReferencesInserts()
        {
            //Now we will add the vdinsert object that will show the external reference that we created.
            VectorDraw.Professional.vdFigures.vdInsert ins = new VectorDraw.Professional.vdFigures.vdInsert();
            ins.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            ins.setDocumentDefaults();
            //We check if the block exists and then give it to the insert.
            VectorDraw.Professional.vdPrimaries.vdBlock blk = vdFramedControl1.BaseControl.ActiveDocument.Blocks.FindName("wmap");
            if (blk != null)
            {
                ins.Block = blk;
                vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(ins);
            }
             
            //Note that the Same operation like above could have been done with the following function cmdXref.
            //string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "wmap.vdcl";
            //vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdXref("A", path, new VectorDraw.Geometry.gPoint(), new double[] { 1.0, 1.0 }, 0.0, 0);


            //Zoom the model to show the entity.
            vdFramedControl1.BaseControl.ActiveDocument.Model.ZoomExtents();
            vdFramedControl1.BaseControl.ActiveDocument.Redraw(true);
        }
        private void OpenExternalReferencesDialog()
        {
            VectorDraw.Professional.Dialogs.frmXrefManager.Show(vdFramedControl1.BaseControl.ActiveDocument);
        }
        #endregion

        #region Layouts
        private void AddLayout()
        {
            //We open a drawing to the document.
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "wmap.vdcl";
            vdFramedControl1.BaseControl.ActiveDocument.Open(path);

            //Add some gradient Background colors to the Model.
            vdFramedControl1.BaseControl.ActiveDocument.Model.BkColorEx = Color.Chocolate;
            vdFramedControl1.BaseControl.ActiveDocument.Model.BkGradientColor = Color.Black;
            vdFramedControl1.BaseControl.ActiveDocument.Model.BkGradientAngle = VectorDraw.Geometry.Globals.DegreesToRadians(270.0);

            //We will add two Layouts to the document.
            //Create a vdLayout object and add it to the layouts collection.
            VectorDraw.Professional.vdPrimaries.vdLayout lay = new VectorDraw.Professional.vdPrimaries.vdLayout();
            lay.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            lay.setDocumentDefaults();
            lay.Name = "MyLayout1";
            lay.ShowUCSAxis = false;
            vdFramedControl1.BaseControl.ActiveDocument.LayOuts.AddItem(lay);

            //Or we can add a layout like this:
            VectorDraw.Professional.vdPrimaries.vdLayout lay2 = vdFramedControl1.BaseControl.ActiveDocument.LayOuts.Add("MyLayout2");
            lay2.DisableShowPrinterPaper = true;
            //In order to see the background color you must disable the printer paper draw.
            //Add some gradient Background colors to the Layout.
            lay2.BkColorEx = Color.Aqua;
            lay2.BkGradientColor = Color.Blue;

            //The file we opened has already two layouts that we will delete.
            vdFramedControl1.BaseControl.ActiveDocument.LayOuts[0].Deleted = true;
            //or this can be done like this:
            VectorDraw.Professional.vdPrimaries.vdLayout lay3 = vdFramedControl1.BaseControl.ActiveDocument.LayOuts.FindName("PAPER_SPACE");
            if (lay3 != null) lay3.Deleted = true;
        }
        private void AddLayoutEntities()
        {
            //We check if the layouts have already been added
            if (vdFramedControl1.BaseControl.ActiveDocument.LayOuts.Count <= 2){MessageBox.Show("Please add some layouts by pressing the above button first");return;}

            //Then we add a rectangular viewport to the first added layout.
            VectorDraw.Professional.vdFigures.vdViewport view = new VectorDraw.Professional.vdFigures.vdViewport();
            view.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            view.setDocumentDefaults();
            view.ShowUCSAxis = false;
            view.Height = 100;
            view.Width = 150;
            view.Center = new VectorDraw.Geometry.gPoint(100.0, 230.0);
            view.ViewCenter = new VectorDraw.Geometry.gPoint(4.4008,6.8233);
            view.ViewSize = 0.252;
            
            //And add this viewport to the entities of the first layout.
            VectorDraw.Professional.vdPrimaries.vdLayout lay = vdFramedControl1.BaseControl.ActiveDocument.LayOuts.FindName("MyLayout1");
            //If the entities of the layout are not 0 then this means that this button is already pressed and the viewport already exists so we do not add it again.
            if (lay.Entities.Count > 0) return;
            if (lay!=null) lay.Entities.AddItem(view);

            //We also add a text entity to the layout.
            VectorDraw.Professional.vdFigures.vdText text = new VectorDraw.Professional.vdFigures.vdText();
            text.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            text.setDocumentDefaults();
            text.InsertionPoint = new VectorDraw.Geometry.gPoint(55, 155);
            text.TextString = "GREECE";
            text.Height = 15.0;
            if (lay != null) lay.Entities.AddItem(text);

            //We set as active layout the first added layout to show it.
            vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut = vdFramedControl1.BaseControl.ActiveDocument.LayOuts.FindName("MyLayout1");
            vdFramedControl1.BaseControl.ActiveDocument.Redraw(true);

            //Now we will add some viewports with reference objects to the second added layout MyLayout2.
            lay = vdFramedControl1.BaseControl.ActiveDocument.LayOuts.FindName("MyLayout2");

            //We will create two polylines and a circle to be used as viewports.
            VectorDraw.Professional.vdFigures.vdPolyline poly1 = new VectorDraw.Professional.vdFigures.vdPolyline();
            poly1.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            poly1.setDocumentDefaults();
            poly1.VertexList.Add (new VectorDraw.Geometry.gPoint(10.0d,280.0d));
            poly1.VertexList.Add(new VectorDraw.Geometry.gPoint(10.0d, 180.0d));
            poly1.VertexList.Add(new VectorDraw.Geometry.gPoint(190.0d, 180.0d));
            poly1.VertexList.Add(new VectorDraw.Geometry.gPoint(190.0d, 280.0d));
            poly1.Flag = VectorDraw.Professional.Constants.VdConstPlineFlag.PlFlagCLOSE;
            if (lay!=null) lay.Entities.AddItem(poly1);
            
            //Another polyline
            VectorDraw.Professional.vdFigures.vdPolyline poly2 = new VectorDraw.Professional.vdFigures.vdPolyline();
            poly2.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            poly2.setDocumentDefaults();
            poly2.VertexList.Add(new VectorDraw.Geometry.gPoint(50.0d, 115.0d));
            poly2.VertexList.Add(new VectorDraw.Geometry.gPoint(10.0d, 65.0d));
            poly2.VertexList.Add(new VectorDraw.Geometry.gPoint(50.0d, 15.0d));
            poly2.VertexList.Add(new VectorDraw.Geometry.gPoint(90.0d, 65.0d));
            poly2.Flag = VectorDraw.Professional.Constants.VdConstPlineFlag.PlFlagCLOSE;
            if (lay!=null) lay.Entities.AddItem(poly2);

            //A circle
            VectorDraw.Professional.vdFigures.vdCircle circle = new VectorDraw.Professional.vdFigures.vdCircle();
            circle.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            circle.setDocumentDefaults();
            circle.Center = new VectorDraw.Geometry.gPoint(160.0d,65.0d);
            circle.Radius = 50.0d;
            if (lay!=null) lay.Entities.AddItem(circle);

            //Now that we have the entities we can create 3 different viewports for these entities.
            VectorDraw.Professional.vdFigures.vdViewport vp = new VectorDraw.Professional.vdFigures.vdViewport();
            vp.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            vp.setDocumentDefaults();
            vp.ShowUCSAxis = false;
            vp.ClipObj = poly1 as VectorDraw.Professional.vdFigures.vdCurve;
            vp.ZoomExtents();
            vp.PenColor.SystemColor = Color.Red;
            //Add some different gradient collors to the viewport
            vp.BkColorEx = Color.Blue;
            vp.BkGradientColor = Color.Aqua;
            if (lay!=null) lay.Entities.AddItem(vp);
            
            //Another viewport
            vp = new VectorDraw.Professional.vdFigures.vdViewport();
            vp.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            vp.setDocumentDefaults();
            vp.ShowUCSAxis = false;
            vp.SetClipHandle(poly2.Handle);
            vp.PenColor.SystemColor = Color.Blue;
            vp.ViewCenter = new VectorDraw.Geometry.gPoint(7.1531, 5.0466);
            vp.ViewSize = 2.6962;
            vp.PenWidth = 2.2;
            //Freeze all layers and show only "AUSTRALIA" layer.
            vp.FrozenLayerList.AddItem("0");
            vp.FrozenLayerList.AddItem("Clients");
            vp.FrozenLayerList.AddItem("Land");
            if (lay!=null) lay.Entities.AddItem(vp);
            
            //And a viewport for the circle
            vp = new VectorDraw.Professional.vdFigures.vdViewport();
            vp.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            vp.setDocumentDefaults();
            vp.ShowUCSAxis = false;
            vp.SetClipHandle(circle.Handle);
            vp.PenColor.SystemColor = Color.Yellow;
            vp.ViewCenter = new VectorDraw.Geometry.gPoint(4.1837, 5.9294);
            vp.ViewSize = 2.2468;
            if (lay!=null) lay.Entities.AddItem(vp);

            //And add some texts for fun :)
            text = new VectorDraw.Professional.vdFigures.vdText();
            text.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            text.setDocumentDefaults();
            text.InsertionPoint = new VectorDraw.Geometry.gPoint(80.0d, 165.0d);
            text.TextString = "WORLD";
            text.Height = 10.0;
            if (lay != null) lay.Entities.AddItem(text);

            text = new VectorDraw.Professional.vdFigures.vdText();
            text.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            text.setDocumentDefaults();
            text.InsertionPoint = new VectorDraw.Geometry.gPoint(15.0d, 120.0d);
            text.TextString = "AUSTRALIA";
            text.Height = 10.0;
            if (lay != null) lay.Entities.AddItem(text);

            text = new VectorDraw.Professional.vdFigures.vdText();
            text.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            text.setDocumentDefaults();
            text.InsertionPoint = new VectorDraw.Geometry.gPoint(133.0d, 120.0d);
            text.TextString = "AFRICA";
            text.Height = 10.0;
            if (lay != null) lay.Entities.AddItem(text);

            MessageBox.Show("By Default you can double click the viewport entity to enter inside and pan or zoom");
        }
        private void OpenLayoutsDialog()
        {
            vdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.LayoutTab, true);
            MessageBox.Show("The Layout tab has been activated.You can navigate and see the added viewports at the bottom left of the application.");
        }
        #endregion

        #region Lights
        private void AddLights()
        {
            VectorDraw.Professional.vdFigures.vdLight light = new VectorDraw.Professional.vdFigures.vdLight();
            light.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            light.setDocumentDefaults();
            light.TypeOfLight = VectorDraw.Professional.vdFigures.LightType.Spot;
            light.Position = new VectorDraw.Geometry.gPoint(40.0d, 0.0d, 40.0d);
            light.Intensity = VectorDraw.Professional.vdFigures.vdLight.LightIntensity.Low;
            light.color = Color.Red;
            light.SpotDirection = new VectorDraw.Geometry.Vector(new VectorDraw.Geometry.gPoint(40.0d, 0.0d, 40.0d), new VectorDraw.Geometry.gPoint());
            light.SpotAngle = 30.0d;
            light.Enable = true;
            light.VisibleIn2d = true;
            light.Name = "RED";
            vdFramedControl1.BaseControl.ActiveDocument.Lights.AddItem(light);

            light = new VectorDraw.Professional.vdFigures.vdLight();
            light.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            light.setDocumentDefaults();
            light.TypeOfLight = VectorDraw.Professional.vdFigures.LightType.Spot;
            light.Position = new VectorDraw.Geometry.gPoint(-40.0d, 0.0d, 40.0d);
            light.Intensity = VectorDraw.Professional.vdFigures.vdLight.LightIntensity.Low;
            light.color = Color.Blue;
            light.SpotDirection = new VectorDraw.Geometry.Vector(new VectorDraw.Geometry.gPoint(-40.0d, 0.0d, 40.0d), new VectorDraw.Geometry.gPoint());
            light.SpotAngle = 30.0d;
            light.Enable = true;
            light.VisibleIn2d = true;
            light.Name = "BLUE";
            vdFramedControl1.BaseControl.ActiveDocument.Lights.AddItem(light);

            light = new VectorDraw.Professional.vdFigures.vdLight();
            light.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument);
            light.setDocumentDefaults();
            light.TypeOfLight = VectorDraw.Professional.vdFigures.LightType.Spot;
            light.Position = new VectorDraw.Geometry.gPoint(0.0d, 0.0d, -60.0d);
            light.Intensity = VectorDraw.Professional.vdFigures.vdLight.LightIntensity.Low;
            light.color = Color.Green;
            light.SpotDirection = new VectorDraw.Geometry.Vector(new VectorDraw.Geometry.gPoint(0.0d, 0.0d, -60.0d), new VectorDraw.Geometry.gPoint());
            light.SpotAngle = 30.0d;
            light.Enable = true;
            light.VisibleIn2d = true;
            light.Name = "GREEN";
            vdFramedControl1.BaseControl.ActiveDocument.Lights.AddItem(light);

            light = vdFramedControl1.BaseControl.ActiveDocument.Lights.Default;
            light.Enable = false;
            
            MessageBox.Show("We added 3 lights and disable the Default light for better results.Click the next button to see a sphere lighted with these lights.");
        }
        private void Add3DEntities()
        {
            //Do not add the sphere if it is already added
            if (vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.Count > 0) return;
            //Set the render mode to Render to activate the lights
            vdFramedControl1.BaseControl.ActiveDocument.Model.RenderMode = VectorDraw.Render.vdRender.Mode.Render;
            
            //We disable redraw because the cmd commands make a redraw that we don't want.We will redraw our scene later.
            vdFramedControl1.BaseControl.ActiveDocument.DisableRedraw = true;
            //We add a sphere to show the effect of the lights.
            vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdSphere(new VectorDraw.Geometry.gPoint(), 25.0, 25, 25);
            vdFramedControl1.BaseControl.ActiveDocument.DisableRedraw = false;
            //Zoom and redraw.
            vdFramedControl1.BaseControl.ActiveDocument.Model.ZoomWindow(new VectorDraw.Geometry.gPoint(-40.0d, -40.0d), new VectorDraw.Geometry.gPoint(40.0d, 40.0d));
            vdFramedControl1.BaseControl.ActiveDocument.Redraw(true);
        }
        private void OpenLightsDialog()
        {
            VectorDraw.Professional.Dialogs.frmLightManager.Show (vdFramedControl1.BaseControl.ActiveDocument);
        }
        #endregion

        #region Multilines
        private void AddMultilineStyles()
        {
            //Create a vdMultilineStyle object with 4 Element lines
            VectorDraw.Professional.vdPrimaries.vdMultilineStyle mline = new VectorDraw.Professional.vdPrimaries.vdMultilineStyle(vdFramedControl1.BaseControl.ActiveDocument, "Test1");

            //1st Element
            VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement elem = new VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement();
            elem.ElementColor.ColorIndex = 0;
            elem.ElementLineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_120;
            elem.Offset = 1.0;
            mline.Elements.Add(elem);

            //Second Element
            elem = new VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement();
            elem.ElementColor.ColorIndex = 1;
            elem.ElementLineType = vdFramedControl1.BaseControl.ActiveDocument.LineTypes.FindName("DASHDOTDOT0");
            elem.Offset = 0.25;
            mline.Elements.Add(elem);

            //Third Element
            elem = new VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement();
            elem.ElementColor.ColorIndex = 1;
            elem.ElementLineType = vdFramedControl1.BaseControl.ActiveDocument.LineTypes.FindName("DASHDOTDOT0");
            elem.Offset = -0.25;
            mline.Elements.Add(elem);

            //Fourth Element
            elem = new VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement();
            elem.ElementColor.ColorIndex = 0;
            elem.Offset = -1.0;
            mline.Elements.Add(elem);

            //Other MultilineStyle properties
            mline.Flags |= VectorDraw.Professional.Constants.VdMultilineFlags.Start_Outer_Arc;
            mline.Flags |= VectorDraw.Professional.Constants.VdMultilineFlags.End_Outer_Arc;
            mline.Update();

            //Add the MultilineStyle to the Document's collection
            vdFramedControl1.BaseControl.ActiveDocument.MultilineStyles.AddItem(mline);

            //Create a Second MultilineStyle with just 3 elements
            mline = new VectorDraw.Professional.vdPrimaries.vdMultilineStyle(vdFramedControl1.BaseControl.ActiveDocument, "Test2");

            //1st Element
            elem = new VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement();
            elem.ElementColor.ColorIndex = 3;
            elem.Offset = 1.0;
            mline.Elements.Add(elem);

            //Second Element
            elem = new VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement();
            elem.ElementColor.ColorIndex = 2;
            elem.Offset = -1.0;
            mline.Elements.Add(elem);

            //Second Element
            elem = new VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement();
            elem.ElementColor.ColorIndex = 0;
            elem.Offset = -0.5;
            mline.Elements.Add(elem);

            //Other MultilineStyle properties
            mline.Flags |= VectorDraw.Professional.Constants.VdMultilineFlags.DisplayMiters;
            mline.Flags |= VectorDraw.Professional.Constants.VdMultilineFlags.Fill_on;
            mline.FillColor.ColorIndex = 4;
            mline.Update();

            //Add the MultilineStyle to the Document's collection
            vdFramedControl1.BaseControl.ActiveDocument.MultilineStyles.AddItem(mline);

            MessageBox.Show("We added 2 Multiline Styles to the Document.");
        }
        private void AddMultilines()
        {
            if (vdFramedControl1.BaseControl.ActiveDocument.MultilineStyles.FindName("Test1") != null)
            {
                //Create a vdMultiline object
                VectorDraw.Professional.vdFigures.vdMultiline line = new VectorDraw.Professional.vdFigures.vdMultiline(vdFramedControl1.BaseControl.ActiveDocument);
                line.VertexList.Add(new VectorDraw.Geometry.Vertex(63, 5, 0));
                line.VertexList.Add(new VectorDraw.Geometry.Vertex(80, 25, 0));
                line.VertexList.Add(new VectorDraw.Geometry.Vertex(110, 25, 0));
                line.VertexList.Add(new VectorDraw.Geometry.Vertex(127, 5, 0));
                line.ScaleFactor = 10.0;

                line.MultilineStyle = vdFramedControl1.BaseControl.ActiveDocument.MultilineStyles.FindName("Test1");
                //The vdMultiline has to be added to the document.
                vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(line);

                //Create a Second Multiline
                line = new VectorDraw.Professional.vdFigures.vdMultiline(vdFramedControl1.BaseControl.ActiveDocument);
                line.VertexList.Add(new VectorDraw.Geometry.Vertex(63, 50, 0));
                line.VertexList.Add(new VectorDraw.Geometry.Vertex(63, 75, 0));
                line.VertexList.Add(new VectorDraw.Geometry.Vertex(110, 75, 0));
                line.VertexList.Add(new VectorDraw.Geometry.Vertex(110, 50, 0));
                line.Flags |= VectorDraw.Professional.Constants.VdConstMultilineFlags.IsClosed;
                line.ScaleFactor = 5.0;

                line.MultilineStyle = vdFramedControl1.BaseControl.ActiveDocument.MultilineStyles.FindName("Test2");
                //The vdMultiline has to be added to the document.
                vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(line);

                //Zoom extends and redraw to see the changes.
                vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ZoomExtents();
                vdFramedControl1.BaseControl.ActiveDocument.Redraw(true);
            }
            else
            {
                MessageBox.Show("Please add Multiline Styles to the collection by pressing the proper button");
            }
        }
        private void OpenMultilinesDialog()
        {
            //Call the Multilines styles dialog.
            DialogResult res = VectorDraw.Professional.Dialogs.frmMultilineStyles.Show(vdFramedControl1.BaseControl.ActiveDocument);
        }
        #endregion
    }

    public class MyObject : VectorDraw.Serialize.IvdProxySerializer
    {
        private double mDouble1 = 1.0d;
        private string mText1 = "one";
        public MyObject() { } // Need an EMPTY CONSTRUCTOR

        public MyObject(double dbl, string str)
        {
            mDouble1 = dbl;
            mText1 = str;
        }

        public double Double1
        {
            get
            {
                return mDouble1;
            }
            set
            {
                mDouble1 = value;
            }
        }

        public string Text1
        {
            get
            {
                return mText1;
            }
            set
            {
                mText1 = value;
            }
        }

        public override string ToString()
        {
            return "MyObject with value " + mDouble1.ToString() + " " + mText1;
        }

        #region IvdProxySerializer Members

        public virtual bool DeSerialize(VectorDraw.Serialize.DeSerializer deserializer, string fieldname, object value)
        {
            if (fieldname == "Double1") mDouble1 = (double)value;
            else if (fieldname == "Text1") mText1 = (string)value;
            else return false;
            return true;
        }

        public virtual void Serialize(VectorDraw.Serialize.Serializer serializer)
        {
            serializer.Serialize(mText1, "Text1");
            serializer.Serialize(mDouble1, "Double1");
        }

        #endregion
    }
}