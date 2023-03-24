using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DeleteRemove
{
    public partial class Form1 : Form
    {
        #region Public variables with the handles
        ulong CircleHandle = 0;
        ulong XRefBlockHandle = 0;
        ulong XRefInsertHandle = 0;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }
        
        // The UNDO GROUPING that is done in this project is not necessary and it is done for better visual result.

        #region basic initialization
        private void Form1_Load(object sender, EventArgs e)
        {
            //We add the "RequiredFiles" folder to the support path. This addition is made in order for our samples to get the required files from this extra folder used in distribution of our sample files.
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\RequiredFiles\\";
            vdFC.BaseControl.ActiveDocument.SupportPath = path;

            vdFC.CommandLine.Enabled = false;
            vdFC.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.CommandLine, false);
            vdFC.BaseControl.ActiveDocument.ShowUCSAxis = false;
            vdFC.ShowMenu(false);
            btnDeleteCircle.Enabled = false;
            btnRemoveCircle.Enabled = false;
            btnRemoveXRef.Enabled = false;
            btnDeleteXRef.Enabled = false;
        }
        #endregion

        #region Circle Buttons
        private void btnAddCircle_Click(object sender, EventArgs e)
        {
            // A new document
            vdFC.BaseControl.ActiveDocument.New();
            
            //UNDOGROUP START : this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
            vdFC.BaseControl.ActiveDocument.CommandAction.Undo("BEGIN");
            btnAddCircle.Enabled = false;

            //We will create a vdCircle object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
            VectorDraw.Professional.vdFigures.vdCircle onecircle = new VectorDraw.Professional.vdFigures.vdCircle();
            //We set the document where the circle is going to be added.This is important for the vdCircle in order to obtain initial properties with setDocumentDefaults.
            onecircle.SetUnRegisterDocument(vdFC.BaseControl.ActiveDocument);
            onecircle.setDocumentDefaults();

            //The two previus steps are important if a vdFigure object is going to be added to a document.
            //Now we will change some properties of the circle.
            onecircle.Center = new VectorDraw.Geometry.gPoint(30, 30);
            onecircle.Radius = 5;
            onecircle.PenColor.SystemColor = Color.BurlyWood;
            onecircle.Label = "This is a vdCircle object.";
            //Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
            vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onecircle);

            //Zoom in order to see the object.
            vdFC.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-30.0, -10.0), new VectorDraw.Geometry.gPoint(80.0, 50.0));
            //Redraw the document to see the above changes.
            vdFC.BaseControl.ActiveDocument.Redraw(true);
            CircleHandle = onecircle.Handle.Value;
            MessageBox.Show("The circle is created in a new document and exists in the Entities colletion of the layout with handle " + CircleHandle.ToString() + ". Entities Count is : " + vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count.ToString() + "\n\r" + "\n\r"
                    + "The Undo/Redo methods work with this object.", "After creating circle");

            btnDeleteCircle.Enabled = true;
            btnRemoveCircle.Enabled = true;
            btnAddXRef.Enabled = true;
            btnDeleteXRef.Enabled = false;
            btnRemoveXRef.Enabled = false;

            //UNDOGROUP END: this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
            vdFC.BaseControl.ActiveDocument.CommandAction.Undo("END");
        }

        private void btnDeleteCircle_Click(object sender, EventArgs e)
        {
            //UNDOGROUP START : this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
            vdFC.BaseControl.ActiveDocument.CommandAction.Undo("BEGIN");
            // Get the earlier created circle from its handle
            VectorDraw.Professional.vdFigures.vdCircle onecircle = vdFC.BaseControl.ActiveDocument.FindFromHandle(new VectorDraw.Professional.vdObjects.vdHandle(CircleHandle),  typeof(VectorDraw.Professional.vdPrimaries.vdFigure)) as VectorDraw.Professional.vdFigures.vdCircle;
            // and delete it
            if (onecircle != null)
            {
                onecircle.Invalidate();
                onecircle.Deleted = true;
                onecircle.Update();
                // now the circle is not visible in the screen but still exists in the entities collection as "DELETED"
                MessageBox.Show("The circle is deleted but exists in the Entities colletion of the layout as DELETED. Entities Count is : " + vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count.ToString() + "\n\r" + "\n\r"
                    + "The Undo/Redo methods work with this object. \r\n \r\nThe circle will be removed from the memory when the drawing is saved and then opened again.", "After deleting circle");
                btnDeleteCircle.Enabled = false;
            }
            else
                MessageBox.Show("Circle not found");
            
            //UNDOGROUP END: this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
            vdFC.BaseControl.ActiveDocument.CommandAction.Undo("END");
        }

        private void btnRemoveCircle_Click(object sender, EventArgs e)
        {
            //UNDOGROUP START : this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
            vdFC.BaseControl.ActiveDocument.CommandAction.Undo("BEGIN");
            
            // Get the earlier created circle from its handle
            VectorDraw.Professional.vdFigures.vdCircle onecircle = vdFC.BaseControl.ActiveDocument.FindFromHandle(new VectorDraw.Professional.vdObjects.vdHandle(CircleHandle), typeof(VectorDraw.Professional.vdPrimaries.vdFigure)) as VectorDraw.Professional.vdFigures.vdCircle;
            // and delete it
            if (onecircle != null)
            {
                MessageBox.Show("The circle has DELETED flag = " + onecircle.Deleted.ToString() + " and exists in the Entities colletion of the layout. Entities Count is : " + vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count.ToString(), "Before calling RemoveItem");
                onecircle.Invalidate();
                onecircle.Deleted = true;
                onecircle.Update();
                vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.RemoveItem(onecircle);
                // now the circle is not visible in the screen and doesn't exist in the entities collection
                MessageBox.Show("The circle doesn't exist any more in the Entities colletion of the layout. Entities Count is : " + vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count.ToString() + "\n\r" + "\n\r"
                    + "The Undo/Redo methods will not work with this object although the circle is not destroyed. \n\r \n\rNOTE : RemoveItem is not recommended. Instead Deleted property should be used.", "After calling RemoveItem");
                vdFC.BaseControl.ActiveDocument.CommandAction.RegenAll();
                btnDeleteCircle.Enabled = false;
                btnRemoveCircle.Enabled = false;
                btnAddCircle.Enabled = true; 
            }
            else
                MessageBox.Show("Circle not found");
            
            //UNDOGROUP END: this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
            vdFC.BaseControl.ActiveDocument.CommandAction.Undo("END");
        }
        #endregion

        #region XRef Buttons
        private void btnAddXRef_Click(object sender, EventArgs e)
        {
            // A new document
            vdFC.BaseControl.ActiveDocument.New();
            
            //UNDOGROUP START : this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
            vdFC.BaseControl.ActiveDocument.CommandAction.Undo("BEGIN");

            btnAddXRef.Enabled = false;
            //We will create a vdBlock object and add it to the Blocks collection that always exist in a Document.
            //XrefName is the path of the file that will be added as a block (XRef)
            string XrefName = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "vdblk.vdcl";
            string blockname = VectorDraw.Professional.Utilities.vdGlobals.GetFileNameWithoutExtension(XrefName);
            VectorDraw.Professional.vdPrimaries.vdBlock blk = vdFC.BaseControl.ActiveDocument.Blocks.FindName(blockname);

            if (blk != null && !blk.IsXref)
            {
                if (blk.Deleted)
                    blk.Deleted = false;
                else
                    throw new Exception("Cannot attach , Blockname present.");
            }
            if (blk == null) blk = vdFC.BaseControl.ActiveDocument.Blocks.Add(blockname);
            blk.ExternalReferencePath = XrefName;
            blk.Deleted = false;
            blk.Update();
            XRefBlockHandle = blk.Handle.Value;
            MessageBox.Show("The block is created in a new document and exists in the Blocks colletion of the document with handle " + XRefBlockHandle.ToString() + ". Block Count is : " + vdFC.BaseControl.ActiveDocument.Blocks.Count.ToString() + "\n\r" + "\n\r"
        + "The Undo/Redo methods work with this object.", "After creating the XRef block");

            //We will create a vdInsert object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
            VectorDraw.Professional.vdFigures.vdInsert ins = new VectorDraw.Professional.vdFigures.vdInsert();
            //We set the document where the insert is going to be added. This is important for the vdInsert in order to obtain initial properties with setDocumentDefaults.
            ins.SetUnRegisterDocument(vdFC.BaseControl.ActiveDocument);
            ins.setDocumentDefaults();
            //Now we will change some properties of the insert and set the block that this insert will display.
            ins.InsertionPoint = new VectorDraw.Geometry.gPoint(0.0d, 0.0d, 0.0d);
            ins.Xscale = 1.0d; ins.Yscale = 1.0d; ins.Zscale = 1.0d;
            ins.Rotation = 0.0d;
            ins.Block = blk;
            ins.Label = "This is a vdInsert Object";
            //Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
            vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(ins);
            XRefInsertHandle = ins.Handle.Value;
            //Zoom in order to see the object.
            vdFC.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(-5.0, -1.0), new VectorDraw.Geometry.gPoint(5.0, 5.0));
            //Redraw the document to see the above changes.
            vdFC.BaseControl.ActiveDocument.Redraw(true);
            MessageBox.Show("The insert is created in a new document and exists in the Entities colletion of the layout with handle " + XRefInsertHandle.ToString() + ". Entities Count is : " + vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count.ToString() + "\n\r" + "\n\r"
                    + "The Undo/Redo methods work with this object.", "After creating the insert");

            btnDeleteXRef.Enabled = true;
            btnRemoveXRef.Enabled = true;
            btnAddCircle.Enabled = true;
            btnDeleteCircle.Enabled = false;
            btnRemoveCircle.Enabled = false;

            //UNDOGROUP END: this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
            vdFC.BaseControl.ActiveDocument.CommandAction.Undo("END");
        }

        private void btnDeleteXRef_Click(object sender, EventArgs e)
        {
            //UNDOGROUP START : this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
            vdFC.BaseControl.ActiveDocument.CommandAction.Undo("BEGIN");

            // Get the earlier created insert from its handle
            VectorDraw.Professional.vdFigures.vdInsert insert = vdFC.BaseControl.ActiveDocument.FindFromHandle(new VectorDraw.Professional.vdObjects.vdHandle(XRefInsertHandle), typeof(VectorDraw.Professional.vdPrimaries.vdFigure)) as VectorDraw.Professional.vdFigures.vdInsert;
            // and delete it
            if (insert != null)
            {
                insert.Invalidate();
                insert.Deleted = true;
                insert.Update();
                // now the insert is not visible in the screen but still exists in the entities collection as "DELETED"
                MessageBox.Show("The insert is deleted but exists in the Entities colletion of the layout as DELETED. Entities Count is : " + vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count.ToString() + "\n\r" + "\n\r"
                    + "The Undo/Redo methods work with this object. \r\n \r\nThe insert will be removed from the memory when the drawing is saved and then opened again.", "After deleting insert");
                btnDeleteXRef.Enabled = false;
            }
            else
                MessageBox.Show("Insert not found");
            // Get the earlier created block from its handle
            VectorDraw.Professional.vdPrimaries.vdBlock block = vdFC.BaseControl.ActiveDocument.FindFromHandle(new VectorDraw.Professional.vdObjects.vdHandle(XRefBlockHandle), typeof(VectorDraw.Professional.vdPrimaries.vdBlock)) as VectorDraw.Professional.vdPrimaries.vdBlock;
            // and delete it
            if (block != null)
            {
                block.Deleted = true;
                block.Update();
                // now the block is not visible in the property grid under Collections->Blocks but still exists in the blocks collection as "DELETED"
                MessageBox.Show("The block is deleted but exists in the Blocks colletion of the Document as DELETED. Blocks collection Count is : " + vdFC.BaseControl.ActiveDocument.Blocks.Count.ToString() + "\n\r" + "\n\r"
                    + "The Undo/Redo methods work with this object. \r\n \r\nThe block will be removed from the memory when the drawing is saved and then opened again.", "After deleting block");
                btnDeleteXRef.Enabled = false;
            }
            else
                MessageBox.Show("Block not found");
            
            //UNDOGROUP END: this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
            vdFC.BaseControl.ActiveDocument.CommandAction.Undo("END");
        }

        private void btnRemoveXRef_Click(object sender, EventArgs e)
        {
            //UNDOGROUP START : this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
            vdFC.BaseControl.ActiveDocument.CommandAction.Undo("BEGIN");

            // Get the earlier created insert from its handle
            VectorDraw.Professional.vdFigures.vdInsert insert = vdFC.BaseControl.ActiveDocument.FindFromHandle(new VectorDraw.Professional.vdObjects.vdHandle(XRefInsertHandle), typeof(VectorDraw.Professional.vdPrimaries.vdFigure)) as VectorDraw.Professional.vdFigures.vdInsert;
            // and delete it
            if (insert != null)
            {
                MessageBox.Show("The insert has DELETED flag = " + insert.Deleted.ToString() + " and exists in the Entities colletion of the layout. Entities Count is : " + vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count.ToString(), "Before calling RemoveItem");
                insert.Invalidate();
                insert.Deleted = true;
                insert.Update();
                vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.RemoveItem(insert);
                // now the insert is not visible in the screen but still exists in the entities collection as "DELETED"
                MessageBox.Show("The insert doesn't exist any more in the Entities colletion of the layout. Entities Count is : " + vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count.ToString() + "\n\r" + "\n\r"
                    + "The Undo/Redo methods will not work with this object although the insert is not destroyed. \n\r \n\rNOTE : RemoveItem is not recommended. Instead Deleted property should be used.", "After calling RemoveItem");
                btnDeleteXRef.Enabled = false;
                btnRemoveXRef.Enabled = false;
                btnAddXRef.Enabled = true;
            }
            else
                MessageBox.Show("Insert not found");

            // Get the earlier created block from its handle
            VectorDraw.Professional.vdPrimaries.vdBlock block = vdFC.BaseControl.ActiveDocument.FindFromHandle(new VectorDraw.Professional.vdObjects.vdHandle(XRefBlockHandle), typeof(VectorDraw.Professional.vdPrimaries.vdBlock)) as VectorDraw.Professional.vdPrimaries.vdBlock;
            // and delete it
            if (block != null)
            {
                MessageBox.Show("The block has DELETED flag = " + block.Deleted.ToString() + " and exists in the Blocks colletion of the layout. Blocks Collection Count is : " + vdFC.BaseControl.ActiveDocument.Blocks.Count.ToString(), "Before calling RemoveItem");
                block.Deleted = false; // if the Deleted = true then the block.ExternalReference will be null so, set it to Deleted= false
                block.Update();
                vdFC.BaseControl.ActiveDocument.Blocks.RemoveItem(block);
                vdFC.BaseControl.ActiveDocument.ExternalReferences.RemoveItem(block.ExternalReference);
              
                vdFC.BaseControl.ActiveDocument.CommandAction.RegenAll();
                // now the block doesn't exist in the Blocks collection
                MessageBox.Show("The block doesn't exist any more in the Blocks colletion and in XRefs Collection of the document. Blocks Collection Count is : " + vdFC.BaseControl.ActiveDocument.Blocks.Count.ToString() + "\n\r" + "\n\r"
                    + "The Undo/Redo methods will not work with this object although the block is not destroyed. \n\r \n\rNOTE : RemoveItem is not recommended. Instead Deleted property should be used.", "After calling RemoveItem");
                btnDeleteXRef.Enabled = false;
                btnRemoveXRef.Enabled = false;
                btnAddXRef.Enabled = true;
            }
            else
                MessageBox.Show("Block not found");
            
            //UNDOGROUP END: this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
            vdFC.BaseControl.ActiveDocument.CommandAction.Undo("END");
        }
        #endregion

        #region Clear the VDF memory
        private void btnClearMemory_Click(object sender, EventArgs e)
        {// NOTE : In big drawings this will take some time.
            object ByteArrayDoc = null;
            System.IO.MemoryStream memorystream = vdFC.BaseControl.ActiveDocument.ToStream();
            //Document is saved to memory in a ByteArray object
            if (memorystream == null)
            {
                MessageBox.Show("Method Failed , Note in evaluation mode this test is not possible because ToStream Method is not allowed to evaluation mode!!!", "Clearing Memory"); return;
            }
            ByteArrayDoc = memorystream.ToArray();
            int size = (int)memorystream.Length;
            memorystream.Close();
            //Document is saved in memory in the ByteArray.

            System.IO.MemoryStream memorystream2 = new System.IO.MemoryStream((byte[])ByteArrayDoc);
            memorystream2.Position = 0;
            vdFC.BaseControl.ActiveDocument.LoadFromMemory(memorystream2);
            memorystream2.Close();
            MessageBox.Show("Deleted and Removed items doesn't exist any more. Undo/Redo doesn't work. \n\r \n\rNote: In big drawings this might take some time.", "Memory cleared !!!");
            //Document is "LOADED" again from the ByteArray in the memory.
        }
        #endregion

        #region Undo & Redo
        private void btnUndo_Click(object sender, EventArgs e)
        {
            //undo the last action
            vdFC.BaseControl.ActiveDocument.CommandAction.Undo("");
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            //redo the last undo action
            vdFC.BaseControl.ActiveDocument.CommandAction.Redo();
        }
        #endregion
    }
}