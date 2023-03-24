Public Class Form1

#Region "Public variables with the handles"
    Dim CircleHandle As ULong = 0
    Dim XRefBlockHandle As ULong = 0
    Dim XRefInsertHandle As ULong = 0
#End Region

    ' The UNDO GROUPING that is done in this project is not necessary and it is done for better visual result.

#Region "Basic initialization"
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        vdFC.CommandLine.Enabled = False
        vdFC.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.CommandLine, False)
        vdFC.BaseControl.ActiveDocument.ShowUCSAxis = False
        vdFC.ShowMenu(False)
        btnDeleteCircle.Enabled = False
        btnRemoveCircle.Enabled = False
        btnRemoveXRef.Enabled = False
        btnDeleteXRef.Enabled = False
    End Sub
#End Region

#Region "Circle Buttons"
    Private Sub btnAddCircle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCircle.Click

        ' A new document
        vdFC.BaseControl.ActiveDocument.[New]()

        'UNDOGROUP START : this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
        vdFC.BaseControl.ActiveDocument.CommandAction.Undo("BEGIN")
        btnAddCircle.Enabled = False

        'We will create a vdCircle object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
        Dim onecircle As VectorDraw.Professional.vdFigures.vdCircle = New VectorDraw.Professional.vdFigures.vdCircle()
        'We set the document where the circle is going to be added.This is important for the vdCircle in order to obtain initial properties with setDocumentDefaults.
        onecircle.SetUnRegisterDocument(vdFC.BaseControl.ActiveDocument)
        onecircle.setDocumentDefaults()

        'The two previus steps are important if a vdFigure object is going to be added to a document.
        'Now we will change some properties of the circle.
        onecircle.Center = New VectorDraw.Geometry.gPoint(30, 30)
        onecircle.Radius = 5
        onecircle.PenColor.SystemColor = Color.BurlyWood
        onecircle.Label = "This is a vdCircle object."
        'Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
        vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onecircle)

        'Zoom in order to see the object.
        vdFC.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-30.0, -10.0), New VectorDraw.Geometry.gPoint(80.0, 50.0))
        'Redraw the document to see the above changes.
        vdFC.BaseControl.ActiveDocument.Redraw(True)
        CircleHandle = onecircle.Handle.Value
        MessageBox.Show("The circle is created in a new document and exists in the Entities colletion of the layout with handle " + CircleHandle.ToString() + ". Entities Count is : " + vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count.ToString() + Chr(13) + Chr(10) + Chr(13) + Chr(10) _
                + "The Undo/Redo methods work with this object.", "After creating circle")

        btnDeleteCircle.Enabled = True
        btnRemoveCircle.Enabled = True
        btnAddXRef.Enabled = True
        btnDeleteXRef.Enabled = False
        btnRemoveXRef.Enabled = False

        'UNDOGROUP END: this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
        vdFC.BaseControl.ActiveDocument.CommandAction.Undo("END")
    End Sub

    Private Sub btnDeleteCircle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteCircle.Click
        'UNDOGROUP START : this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
        vdFC.BaseControl.ActiveDocument.CommandAction.Undo("BEGIN")
        ' Get the earlier created circle from its handle
        Dim onecircle As VectorDraw.Professional.vdFigures.vdCircle = vdFC.BaseControl.ActiveDocument.FindFromHandle(New VectorDraw.Professional.vdObjects.vdHandle(CircleHandle), GetType(VectorDraw.Professional.vdPrimaries.vdFigure))
        ' and delete it
        If Not (onecircle Is Nothing) Then
            onecircle.Invalidate()
            onecircle.Deleted = True
            onecircle.Update()
            ' now the circle is not visible in the screen but still exists in the entities collection as "DELETED"
            MessageBox.Show("The circle is deleted but exists in the Entities colletion of the layout as DELETED. Entities Count is : " + vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count.ToString() + Chr(13) + Chr(10) + Chr(13) + Chr(10) _
                    + "The Undo/Redo methods work with this object. " + Chr(13) + Chr(10) + Chr(13) + Chr(10) + "The circle will be removed from the memory when the drawing is saved and then opened again.", "After deleting circle")
            btnDeleteCircle.Enabled = False
        Else
            MessageBox.Show("Circle not found")
        End If

        'UNDOGROUP END: this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
        vdFC.BaseControl.ActiveDocument.CommandAction.Undo("END")
    End Sub

    Private Sub btnRemoveCircle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveCircle.Click
        'UNDOGROUP START : this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
        vdFC.BaseControl.ActiveDocument.CommandAction.Undo("BEGIN")

        ' Get the earlier created circle from its handle
        Dim onecircle As VectorDraw.Professional.vdFigures.vdCircle = vdFC.BaseControl.ActiveDocument.FindFromHandle(New VectorDraw.Professional.vdObjects.vdHandle(CircleHandle), GetType(VectorDraw.Professional.vdPrimaries.vdFigure))
        ' and delete it
        If Not (onecircle Is Nothing) Then
            MessageBox.Show("The circle has DELETED flag = " + onecircle.Deleted.ToString() + " and exists in the Entities colletion of the layout. Entities Count is : " + vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count.ToString(), "Before calling RemoveItem")
            onecircle.Invalidate()
            onecircle.Deleted = True
            onecircle.Update()
            vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.RemoveItem(onecircle)
            ' now the circle is not visible in the screen and doesn't exist in the entities collection
            MessageBox.Show("The circle doesn't exist any more in the Entities colletion of the layout. Entities Count is : " + vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count.ToString() + Chr(13) + Chr(10) + Chr(13) + Chr(10) _
                    + "The Undo/Redo methods will not work with this object although the circle is not destroyed." + Chr(13) + Chr(10) + Chr(13) + Chr(10) + "NOTE : RemoveItem is not recommended. Instead Deleted property should be used.", "After calling RemoveItem")
            vdFC.BaseControl.ActiveDocument.CommandAction.RegenAll()
            btnDeleteCircle.Enabled = False
            btnRemoveCircle.Enabled = False
            btnAddCircle.Enabled = True
        Else
            MessageBox.Show("Circle not found")
        End If

        'UNDOGROUP END: this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
        vdFC.BaseControl.ActiveDocument.CommandAction.Undo("END")
    End Sub
#End Region

#Region "XRef Buttons"
    Private Sub btnAddXRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddXRef.Click
        ' A new document
        vdFC.BaseControl.ActiveDocument.[New]()

        'UNDOGROUP START : this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
        vdFC.BaseControl.ActiveDocument.CommandAction.Undo("BEGIN")

        btnAddXRef.Enabled = False
        'We will create a vdBlock object and add it to the Blocks collection that always exist in a Document.
        'XrefName is the path of the file that will be added as a block (XRef)
        Dim XRefName As String = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\" + "vdblk.vdcl"
        Dim Blockname As String = VectorDraw.Professional.Utilities.vdGlobals.GetFileNameWithoutExtension(XRefName)
        Dim blk As VectorDraw.Professional.vdPrimaries.vdBlock = vdFC.BaseControl.ActiveDocument.Blocks.FindName(Blockname)

        If Not (blk Is Nothing) Then
            If (Not blk.IsXref) And (blk.Deleted) Then
                blk.Deleted = False
            Else
                Throw New Exception("Cannot attach , Blockname present.")
            End If
        End If

        If (blk Is Nothing) Then blk = vdFC.BaseControl.ActiveDocument.Blocks.Add(Blockname)
        blk.ExternalReferencePath = XRefName
        blk.Deleted = False
        blk.Update()
        XRefBlockHandle = blk.Handle.Value
        MessageBox.Show("The block is created in a new document and exists in the Blocks colletion of the document with handle " + XRefBlockHandle.ToString() + ". Block Count is : " + vdFC.BaseControl.ActiveDocument.Blocks.Count.ToString() + Chr(13) + Chr(10) + Chr(13) + Chr(10) _
        + "The Undo/Redo methods work with this object.", "After creating the XRef block")

        'We will create a vdInsert object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
        Dim ins As VectorDraw.Professional.vdFigures.vdInsert = New VectorDraw.Professional.vdFigures.vdInsert()
        'We set the document where the insert is going to be added. This is important for the vdInsert in order to obtain initial properties with setDocumentDefaults.
        ins.SetUnRegisterDocument(vdFC.BaseControl.ActiveDocument)
        ins.setDocumentDefaults()
        'Now we will change some properties of the insert and set the block that this insert will display.
        ins.InsertionPoint = New VectorDraw.Geometry.gPoint(0D, 0D, 0D)
        ins.Xscale = 1D : ins.Yscale = 1D : ins.Zscale = 1D
        ins.Rotation = 0D
        ins.Block = blk
        ins.Label = "This is a vdInsert Object"
        'Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
        vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(ins)
        XRefInsertHandle = ins.Handle.Value
        'Zoom in order to see the object.
        vdFC.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-5.0, -1.0), New VectorDraw.Geometry.gPoint(5.0, 5.0))
        'Redraw the document to see the above changes.
        vdFC.BaseControl.ActiveDocument.Redraw(True)
        MessageBox.Show("The insert is created in a new document and exists in the Entities colletion of the layout with handle " + XRefInsertHandle.ToString() + ". Entities Count is : " + vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count.ToString() + Chr(13) + Chr(10) + Chr(13) + Chr(10) _
                + "The Undo/Redo methods work with this object.", "After creating the insert")

        btnDeleteXRef.Enabled = True
        btnRemoveXRef.Enabled = True
        btnAddCircle.Enabled = True
        btnDeleteCircle.Enabled = False
        btnRemoveCircle.Enabled = False

        'UNDOGROUP END: this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
        vdFC.BaseControl.ActiveDocument.CommandAction.Undo("END")
    End Sub

    Private Sub btnDeleteXRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteXRef.Click
        'UNDOGROUP START : this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
        vdFC.BaseControl.ActiveDocument.CommandAction.Undo("BEGIN")

        ' Get the earlier created insert from its handle
        Dim insert As VectorDraw.Professional.vdFigures.vdInsert = vdFC.BaseControl.ActiveDocument.FindFromHandle(New VectorDraw.Professional.vdObjects.vdHandle(XRefInsertHandle), GetType(VectorDraw.Professional.vdPrimaries.vdFigure))
        ' and delete it
        If Not (insert Is Nothing) Then
            insert.Invalidate()
            insert.Deleted = True
            insert.Update()
            ' now the insert is not visible in the screen but still exists in the entities collection as "DELETED"
            MessageBox.Show("The insert is deleted but exists in the Entities colletion of the layout as DELETED. Entities Count is : " + vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count.ToString() + Chr(13) + Chr(10) + Chr(13) + Chr(10) _
                + "The Undo/Redo methods work with this object. " + Chr(13) + Chr(10) + Chr(13) + Chr(10) + "The insert will be removed from the memory when the drawing is saved and then opened again.", "After deleting insert")
            btnDeleteXRef.Enabled = False
        Else
            MessageBox.Show("Insert not found")
        End If
        ' Get the earlier created block from its handle
        Dim block As VectorDraw.Professional.vdPrimaries.vdBlock = vdFC.BaseControl.ActiveDocument.FindFromHandle(New VectorDraw.Professional.vdObjects.vdHandle(XRefBlockHandle), GetType(VectorDraw.Professional.vdPrimaries.vdBlock))
        ' and delete it
        If Not (block Is Nothing) Then
            block.Deleted = True
            block.Update()
            ' now the block is not visible in the property grid under Collections->Blocks but still exists in the blocks collection as "DELETED"
            MessageBox.Show("The block is deleted but exists in the Blocks colletion of the Document as DELETED. Blocks collection Count is : " + vdFC.BaseControl.ActiveDocument.Blocks.Count.ToString() + Chr(13) + Chr(10) + Chr(13) + Chr(10) _
                + "The Undo/Redo methods work with this object. " + Chr(13) + Chr(10) + Chr(13) + Chr(10) + "The block will be removed from the memory when the drawing is saved and then opened again.", "After deleting block")
            btnDeleteXRef.Enabled = False
        Else
            MessageBox.Show("Block not found")
        End If

        'UNDOGROUP END: this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
        vdFC.BaseControl.ActiveDocument.CommandAction.Undo("END")
    End Sub

    Private Sub btnRemoveXRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveXRef.Click
        'UNDOGROUP START : this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
        vdFC.BaseControl.ActiveDocument.CommandAction.Undo("BEGIN")

        ' Get the earlier created insert from its handle
        Dim insert As VectorDraw.Professional.vdFigures.vdInsert = vdFC.BaseControl.ActiveDocument.FindFromHandle(New VectorDraw.Professional.vdObjects.vdHandle(XRefInsertHandle), GetType(VectorDraw.Professional.vdPrimaries.vdFigure))
        ' and delete it
        If Not (insert Is Nothing) Then
            MessageBox.Show("The insert has DELETED flag = " + insert.Deleted.ToString() + " and exists in the Entities colletion of the layout. Entities Count is : " + vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count.ToString(), "Before calling RemoveItem")
            insert.Invalidate()
            insert.Deleted = True
            insert.Update()
            vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.RemoveItem(insert)
            ' now the insert is not visible in the screen but still exists in the entities collection as "DELETED"
            MessageBox.Show("The insert doesn't exist any more in the Entities colletion of the layout. Entities Count is : " + vdFC.BaseControl.ActiveDocument.ActiveLayOut.Entities.Count.ToString() + Chr(13) + Chr(10) + Chr(13) + Chr(10) _
                + "The Undo/Redo methods will not work with this object although the insert is not destroyed." + Chr(13) + Chr(10) + Chr(13) + Chr(10) + "NOTE : RemoveItem is not recommended. Instead Deleted property should be used.", "After calling RemoveItem")
            btnDeleteXRef.Enabled = False
            btnRemoveXRef.Enabled = False
            btnAddXRef.Enabled = True
        Else
            MessageBox.Show("Insert not found")
        End If

        ' Get the earlier created block from its handle
        Dim block As VectorDraw.Professional.vdPrimaries.vdBlock = vdFC.BaseControl.ActiveDocument.FindFromHandle(New VectorDraw.Professional.vdObjects.vdHandle(XRefBlockHandle), GetType(VectorDraw.Professional.vdPrimaries.vdBlock))
        ' and delete it
        If Not (block Is Nothing) Then
            MessageBox.Show("The block has DELETED flag = " + block.Deleted.ToString() + " and exists in the Blocks colletion of the layout. Blocks Collection Count is : " + vdFC.BaseControl.ActiveDocument.Blocks.Count.ToString(), "Before calling RemoveItem")
            block.Deleted = False '  if the Deleted = true then the block.ExternalReference will be null so, set it to Deleted= false
            block.Update()
            vdFC.BaseControl.ActiveDocument.Blocks.RemoveItem(block)
            vdFC.BaseControl.ActiveDocument.ExternalReferences.RemoveItem(block.ExternalReference)

            vdFC.BaseControl.ActiveDocument.CommandAction.RegenAll()
            ' now the block doesn't exist in the Blocks collection
            MessageBox.Show("The block doesn't exist any more in the Blocks colletion and in XRefs Collection of the document. Blocks Collection Count is : " + vdFC.BaseControl.ActiveDocument.Blocks.Count.ToString() + Chr(13) + Chr(10) + Chr(13) + Chr(10) _
                + "The Undo/Redo methods will not work with this object although the block is not destroyed." + Chr(13) + Chr(10) + Chr(13) + Chr(10) + "NOTE : RemoveItem is not recommended. Instead Deleted property should be used.", "After calling RemoveItem")
            btnDeleteXRef.Enabled = False
            btnRemoveXRef.Enabled = False
            btnAddXRef.Enabled = True
        Else
            MessageBox.Show("Block not found")
        End If

        'UNDOGROUP END: this groups the actions in the "BEGIN" - "END" so the undo/redo will be one step for all actions in the group 
        vdFC.BaseControl.ActiveDocument.CommandAction.Undo("END")
    End Sub
#End Region

#Region "UNDO & REDO"
    Private Sub btnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndo.Click
        'undo the last action
        vdFC.BaseControl.ActiveDocument.CommandAction.Undo("")
    End Sub

    Private Sub btnRedo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedo.Click
        'redo the last undo action
        vdFC.BaseControl.ActiveDocument.CommandAction.Redo()
    End Sub
#End Region

#Region "Clear the VDF memory"
    Private Sub btnClearMemory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearMemory.Click
        'NOTE : In big drawings this will take some time.
        Dim ByteArrayDoc As Object = Nothing
        Dim memorystream As System.IO.MemoryStream = vdFC.BaseControl.ActiveDocument.ToStream()
        'Document is saved to memory in a ByteArray object
        If (memorystream Is Nothing) Then
            MessageBox.Show("Method Failed", "Clearing Memory")
            Exit Sub
        End If


        ByteArrayDoc = memorystream.ToArray()
        Dim size As Long = memorystream.Length
        memorystream.Close()
        'Document is saved in memory in the ByteArray.
        Dim TempA As Byte() = ByteArrayDoc
        Dim memorystream2 As System.IO.MemoryStream = New System.IO.MemoryStream(TempA)
        memorystream2.Position = 0
        vdFC.BaseControl.ActiveDocument.LoadFromMemory(memorystream2)
        memorystream2.Close()
        MessageBox.Show("Deleted and Removed items doesn't exist any more. Undo/Redo doesn't work. \n\r \n\rNote: In big drawings this might take some time.", "Memory cleared !!!")
        'Document is "LOADED" again from the ByteArray in the memory.
    End Sub
#End Region

End Class
