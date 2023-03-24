Public Class Form1
    'Description:

    'In the following example is demonstrated how someone can create an Invoice Form Application. This is achieved by using an existing
    'Vector Draw .vdml document template and modifying its Attributes, using a Vector Draw BaseControl and other simple controls,
    'such as Textboxes and Buttons. In further detail someone can review the use, creation and removal of Insert objects. How to search
    'for an Insert object using its BlockName or its Label. The way to locate and control an Insert's Attributes in order to present text
    'dynamically, and finally how to rearrange- move shapes or inserts pressing a button. 

    'Use:

    'Once the Application is started, the template .vdml document is loaded. By using the Application's Components (TextBoxes, DataGrid etc),
    'the values of the various Attributes can be altered. Whenever an Attribute needs to be modified, all we have to do is insert the value in
    'the right TextBox and press "Enter" (or press the "Update" button at the bottom). Finally the Items DataGrid. We can add, remove and modify
    'up to 4 items (Due to the functionality of the component, pressing "Enter" won't work in the DataGrid).

    Shadows width As Integer
    'This Boolean Array is set to true if a specific row has been initialized.
    Dim initializedRow() As Boolean = {False, False, False, False}

#Region "EVENT HANDLERS"
    '
    'Using the width variable we keep the width of the Panel2 steady.
    Private Sub splitContainer1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles splitContainer1.Resize
        splitContainer1.SplitterDistance = splitContainer1.Width - width
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'The invoice.vdml file that is located in the application's home folder, is used as template. If we need to use another file,
        'we should use the full pathname as parameter.
        vectorDrawBaseControl1.ActiveDocument.Open("invoice.vdml")
        loadForm()
        'We store the initial width of the Panel2 in order to keep the size of the panel that contains the textboxes steady.
        width = splitContainer1.Panel2.Width

        vectorDrawBaseControl1.Redraw()
    End Sub
    'This Event Handler ensures that whenever we enter, click or change the current cell of the DataGrid control the whole row of the current Cell will be filled with ""
    'so that we won't get an Exception when inserting the Item details into the Invoice Form.
    Private Sub ItemsTableInit(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemsTable.Enter, ItemsTable.CurrentCellChanged
        InitRows()
    End Sub

    Private Sub ItemsTableInit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ItemsTable.MouseUp
        InitRows()
    End Sub

    Private Sub UpdateClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles updateButton.Click
        updateInvoiceForm()
    End Sub
    Private Sub DateValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbDate.ValueChanged, dueDate.ValueChanged
        updateInvoiceForm()
    End Sub
    Private Sub KeyPressed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbTax.KeyUp, stbName.KeyUp, tbInvoiceNum.KeyUp, stbAddress.KeyUp, stbPhone.KeyUp, stbFax.KeyUp, rtbName.KeyUp, rtbAddress.KeyUp, rtbArea.KeyUp, rtbZip.KeyUp, rtbCountry.KeyUp, rtbVat.KeyUp, rtbPhone.KeyUp, rtbFax.KeyUp, rtbContact.KeyUp, rtbEmail.KeyUp
        If e.KeyCode = Keys.Enter Then
            updateInvoiceForm()
        End If
    End Sub
#Region "FILE MENU"
    '
    Private Sub ToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles newToolStripMenuItem.Click, printToolStripMenuItem.Click, exportToPDFToolStripMenuItem.Click
        Dim menu As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        If menu.Name.Equals("newToolStripMenuItem") Then
            VectorDrawBaseControl1.ActiveDocument.Open("invoice.vdml")
            loadForm()
        ElseIf menu.Name.Equals("printToolStripMenuItem") Then
            VectorDrawBaseControl1.ActiveDocument.CommandAction.CmdPrintDialog("E", "F")
        ElseIf menu.Name.Equals("exportToPDFToolStripMenuItem") Then
            VectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Printer.PrinterName = Application.ExecutablePath.Substring(0, Application.ExecutablePath.Length - 4) + ".pdf"
            VectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Printer.PrintExtents()
            VectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Printer.PrintWindow.AddWidth(5.0)
            VectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Printer.PrintScaleToFit()
            VectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Printer.PrintOut()
            MessageBox.Show("A PDF file was created in the home folder of the application.")
        End If
    End Sub
    '
#End Region
    '
#End Region

#Region "APPLICATION FORM HANDLING"
    '
    'This method makes the value of all the cells in the current Row equal to "".
    Private Sub InitRows()
        Dim row As Integer = ItemsTable.CurrentRowIndex
        If row < 4 Then
            If Not initializedRow(row) Then
                Dim i As Integer
                For i = 0 To 4
                    ItemsTable(row, i) = ""
                Next i
                initializedRow(row) = True
            End If
        End If

    End Sub
    'Initialization of the Application Form's TextBoxes.
    Private Sub loadForm()
        'The user cannot alter the way he views the Invoice Form, on the left part of the Window, or alter any objects in it.
        VectorDrawBaseControl1.Enabled = False
        VectorDrawBaseControl1.ActiveDocument.ShowUCSAxis = False

        setAttrValue("invoiceInfo", "date", tbDate.Text)
        tbInvoiceNum.Text = getAttrValue("invoiceInfo", "invoiceNum")

        stbName.Text = getAttrValue("fromCredentials", "fromName")
        stbAddress.Text = getAttrValue("fromCredentials", "fromAddress")
        stbPhone.Text = getAttrValue("fromCredentials", "fromPhones").Replace("Phone: ", "")
        stbFax.Text = getAttrValue("fromCredentials", "fromFax").Replace("Fax: ", "")
        stbTax.Text = getAttrValue("fromCredentials", "fromTaxNum").Replace("TAX Number: ", "")

        rtbName.Text = getAttrValue("toCredentials", "toCompany")
        rtbAddress.Text = getAttrValue("toCredentials", "toAddress")
        rtbArea.Text = getAttrValue("toCredentials", "toArea")
        rtbCountry.Text = getAttrValue("toCredentials", "toCountry")
        rtbPhone.Text = getAttrValue("toCredentials", "toPhone")
        rtbZip.Text = getAttrValue("toCredentials", "toZipCode")
        rtbFax.Text = getAttrValue("toCredentials", "toFAX")
        rtbVat.Text = getAttrValue("toCredentials", "toVAT")
        rtbContact.Text = getAttrValue("toContactInfo", "toContact")
        rtbEmail.Text = getAttrValue("toContactInfo", "toEmail")

        setAttrValue("dueDate", "dueDate", dueDate.Text)
    End Sub
#End Region

#Region "INVOICE FORM MODIFYING"
    '
    'This method Updates the Invoice Form, according to the contents of the TextBoxes of the Application Form.
    Private Sub updateInvoiceForm()
        setAttrValue("fromCredentials", "fromName", stbName.Text)

        setAttrValue("fromCredentials", "fromAddress", stbAddress.Text)
        setAttrValue("fromCredentials", "fromPhones", "Phone: " + stbPhone.Text)
        setAttrValue("fromCredentials", "fromFax", "Fax: " + stbFax.Text)
        setAttrValue("fromCredentials", "fromTaxNum", "TAX Number: " + stbTax.Text)

        setAttrValue("invoiceInfo", "date", tbDate.Text)
        setAttrValue("invoiceInfo", "invoiceNum", tbInvoiceNum.Text)

        setAttrValue("toCredentials", "toCompany", rtbName.Text)
        setAttrValue("toCredentials", "toAddress", rtbAddress.Text)
        setAttrValue("toCredentials", "toArea", rtbArea.Text)
        setAttrValue("toCredentials", "toCountry", rtbCountry.Text)
        setAttrValue("toCredentials", "toPhone", rtbPhone.Text)
        setAttrValue("toCredentials", "toZipCode", rtbZip.Text)
        setAttrValue("toCredentials", "toFAX", rtbFax.Text)
        setAttrValue("toCredentials", "toVAT", rtbVat.Text)
        setAttrValue("toContactInfo", "toContact", rtbContact.Text)
        setAttrValue("toContactInfo", "toEmail", rtbEmail.Text)

        setAttrValue("dueDate", "duedate", dueDate.Text)

        updateItems()
        'After the completion of the alterations in the Invoice Form's data, we use the Redraw method to make them visible to the user.
        VectorDrawBaseControl1.Redraw()
    End Sub
    'The following method is used whenever we want to insert/modify/delete data the user has inserted in the ItemsTable, into the Invoice Form.
    Private Sub updateItems()
        Dim total As Double = 0
        clearItemBlocks(ItemsTable.BindingContext(ItemsTable.DataSource).Count)
        'This for loop is executed as many times, as many rows we have in our DataGrid (ItemsTable) control.
        Dim repeat As Integer
        For repeat = 0 To ItemsTable.BindingContext(ItemsTable.DataSource).Count - 1
            'Incase more than 1 items are inserted, we have to create additional Item Blocks in the Invoice Form.
            If repeat > 0 Then
                If repeat > 3 Then
                    MessageBox.Show("You can insert up to 4 items.")
                    Exit For
                End If
                Dim itemBlockExists As Boolean = False
                Dim lastItemBlock As VectorDraw.Professional.vdFigures.vdInsert = Nothing
                Dim insertTotal As VectorDraw.Professional.vdFigures.vdInsert = Nothing
                'We check every object in our Document.
                For Each item As VectorDraw.Professional.vdPrimaries.vdFigure In VectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Entities
                    Dim ins As VectorDraw.Professional.vdFigures.vdInsert = Nothing
                    ins = DirectCast(item, VectorDraw.Professional.vdFigures.vdInsert)
                    'If the object is not an Insert we check the next.
                    If ins Is Nothing Then
                        Continue For
                    End If
                    'When this foreach loop is completed lastItemBlock will be referencing the last Item Block that is inserted
                    If ins.Block.Name.Equals("itemBlock") Then
                        lastItemBlock = ins
                    End If
                    'When this foreach loop is completed isertTotal will be referencing the Item Total Block
                    If ins.Block.Name.Equals("itemTotal") Then
                        insertTotal = ins
                    End If
                    'If an insert labeled with the current repeat exists, it was created earlier, so we just need to update the content.
                    'If it does not exist, we need to insert one more Item Block.
                    If ins.Label.CompareTo(repeat.ToString()) = 0 Then
                        'If the current Insert was created and deleted before, we just change the Deleted property of the Insert to false.
                        If ins.Deleted Then
                            ins.Deleted = False
                        End If
                        itemBlockExists = True
                        Exit For
                    End If
                Next item
                'If an insert labeled with the current repeat does not exist, we will clone the latest Item Block that was inserted and label it
                'with the current repeat.
                If Not itemBlockExists Then
                    Dim ins As VectorDraw.Professional.vdFigures.vdInsert = New VectorDraw.Professional.vdFigures.vdInsert()
                    ins = DirectCast(lastItemBlock.Clone(VectorDrawBaseControl1.ActiveDocument), VectorDraw.Professional.vdFigures.vdInsert)
                    'The new Item Block will be inserted right under the last Item Block inserted.
                    ins.InsertionPoint = New VectorDraw.Geometry.gPoint(lastItemBlock.BoundingBox.Left, (lastItemBlock.BoundingBox.Top - lastItemBlock.BoundingBox.Height))
                    ins.Label = repeat.ToString()
                    VectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Entities.AddItem(ins)
                End If
                'The Item Total Block will be moved under the last inserted Item Block.
                insertTotal.InsertionPoint = New VectorDraw.Geometry.gPoint(insertTotal.BoundingBox.Left, (110 - (repeat + 1) * lastItemBlock.BoundingBox.Height))
                insertTotal.Update()
            End If
            setItemAttrValue("itemBlock", "item", ItemsTable(repeat, 0).ToString(), repeat.ToString())
            'In this "Set Description Value" region, we make sure that if the text in the description column of the DataGrid is more than
            '30 characters will be wraped, so that it won't exceed the borders of its box.
            '
            'Set Description Value
            Dim descriptionValue As String = ItemsTable(repeat, 1).ToString()
            If descriptionValue.Length > 30 Then
                Dim j As Integer = ItemsTable(repeat, 1).ToString().Length
                Dim description As String = Nothing
                Dim str(j / 30 + 1) As String
                Dim k As Integer
                Dim forEnd As Integer = j \ 30
                For k = 0 To forEnd
                    If k <> j \ 30 Then
                        str(k) = descriptionValue.Substring(k * 30, 30)
                        If Not descriptionValue.Substring((k + 1) * 30, 1).Equals(" ") And Not descriptionValue.Substring(((k + 1) * 30) - 1, 1).Equals(" ") Then
                            str(k) += "-"
                        End If
                    Else
                        str(k) = descriptionValue.Substring(k * 30, j Mod 30)
                    End If
                    description += str(k) + vbNewLine
                Next k
                setItemAttrValue("itemBlock", "description", description, repeat.ToString())

            Else
                setItemAttrValue("itemBlock", "description", descriptionValue, repeat.ToString())
            End If
            'Set Description Value
            '
            setItemAttrValue("itemBlock", "quantity", ItemsTable(repeat, 2).ToString(), repeat.ToString())
            setItemAttrValue("itemBlock", "rate", ItemsTable(repeat, 3).ToString() + " EUR", repeat.ToString())

            'The following lines (try - catch), calculate the total amount of an item. If the value inserted is not numeric, the amount
            'is set to 0 automatically.
            Try
                Dim subtotal As Double
                Dim quantity As Double = Double.Parse(ItemsTable(repeat, 2).ToString())
                Dim rate As Double = Double.Parse(ItemsTable(repeat, 3).ToString())
                subtotal = quantity * rate
                total += subtotal
                setItemAttrValue("itemBlock", "amount", subtotal.ToString() + " EUR", repeat.ToString())
                ItemsTable(repeat, 4) = subtotal.ToString()
            Catch
                setItemAttrValue("itemBlock", "amount", "0 EUR", repeat.ToString())
                ItemsTable(repeat, 4) = "0"
            End Try
        Next repeat
        tbTotal.Text = total.ToString() + " EUR"
        setAttrValue("itemTotal", "total", tbTotal.Text)
    End Sub
    'The following method makes sure that there are as many Item Blocks as there are Items in the DataGrid (ItemsTable)
    Private Sub clearItemBlocks(ByVal rows As Integer)
        Dim itemTotal As VectorDraw.Professional.vdFigures.vdInsert = Nothing
        For Each item As VectorDraw.Professional.vdPrimaries.vdFigure In VectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Entities
            Dim ins As VectorDraw.Professional.vdFigures.vdInsert = DirectCast(item, VectorDraw.Professional.vdFigures.vdInsert)
            Dim i As Integer
            If ins Is Nothing Then
                Continue For
            End If
            If ins.Block.Name.Equals("itemTotal") Then
                itemTotal = ins
            End If
            If ins.Block.Name.Equals("itemBlock") Then
                i = Integer.Parse(ins.Label.ToString())
                If i >= rows And i <> 0 Then
                    'If there are more Item Blocks than the Items the user has inserted in the DataGrid (ItemsTable), they are removed
                    'from the Entities of the vectorDrawBaseControl and the Item Total Block is relocated accordingly.
                    If rows > 0 Then
                        itemTotal.InsertionPoint = New VectorDraw.Geometry.gPoint(itemTotal.BoundingBox.Left, 110 - (rows * ins.BoundingBox.Height))
                        itemTotal.Update()
                        'vectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Entities.RemoveItem(ins)
                        ins.Deleted = True
                        initializedRow(i) = False
                    End If
                End If
            End If
        Next item
    End Sub
    '
#End Region

#Region "ATTRIBUTE MODIFYING"
    '
    'This method is used to change the values of the Attributes in the Invoice Form (except the Attributes in the Item Blocks).
    Private Sub setAttrValue(ByVal blockName As String, ByVal attrName As String, ByVal value As String)

        Dim attr As VectorDraw.Professional.vdFigures.vdAttrib = Nothing
        For Each item As VectorDraw.Professional.vdPrimaries.vdFigure In VectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Entities
            Dim ins As VectorDraw.Professional.vdFigures.vdInsert = DirectCast(item, VectorDraw.Professional.vdFigures.vdInsert)
            If ins Is Nothing Then
                Continue For
            End If
            If ins.Block.Name.CompareTo(blockName) = 0 Then
                'Once we locate the insert with the corresponding Block name we edit the attribute we want, using its Tag name.
                attr = ins.Attributes.FindTagName(attrName)
                attr.ValueString = value
            End If
        Next item
        'Every time we modify an attribute we shoule use the Update method to make sure the modifications are visible.
        attr.Update()
    End Sub

    'This method is used to change the values of the Attributes of the Item Blocks in the Invoice Form.
    'We use a different method, because the Item Block Inserts can be multiple so we can't identify them by their Block names. Instead we 
    'use their labels.
    Private Sub setItemAttrValue(ByVal blockName As String, ByVal attrName As String, ByVal value As String, ByVal insertLabel As String)
        Dim attr As VectorDraw.Professional.vdFigures.vdAttrib = Nothing
        For Each item As VectorDraw.Professional.vdPrimaries.vdFigure In VectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Entities
            Dim ins As VectorDraw.Professional.vdFigures.vdInsert = DirectCast(item, VectorDraw.Professional.vdFigures.vdInsert)
            If ins Is Nothing Then
                Continue For
            End If
            If ins.Label.CompareTo(insertLabel) = 0 Then
                'Once we locate the insert with the corresponding Label we edit the attribute we want, using its Tag name.
                attr = ins.Attributes.FindTagName(attrName)
                attr.ValueString = value
            End If
        Next item
        attr.Update()
    End Sub
    'This method returns the value string of the corresponding Attribute, from a specific Block.
    Private Function getAttrValue(ByVal blockName As String, ByVal attrName As String) As String
        For Each item As VectorDraw.Professional.vdPrimaries.vdFigure In VectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Entities
            Dim ins As VectorDraw.Professional.vdFigures.vdInsert = DirectCast(item, VectorDraw.Professional.vdFigures.vdInsert)
            If ins Is Nothing Then
                Continue For
            End If
            If ins.Block.Name.CompareTo(blockName) = 0 Then
                Return ins.Attributes.FindTagName(attrName).ValueString
            End If
        Next item
        Return Nothing
    End Function
    '
#End Region

End Class

'//This class is used as a template for the Form's DataGrid (ItemsTable).
Public Class Items
    Private items As String
    Private descriptions As String
    Private quantities As String
    Private rates As String
    Private amounts As String
    Public Property item() As String
        Get
            Return items
        End Get
        Set(ByVal value As String)
            items = value
        End Set
    End Property
    Public Property description() As String
        Get
            Return descriptions
        End Get
        Set(ByVal value As String)
            descriptions = value
        End Set
    End Property
    Public Property quantity() As String
        Get
            Return quantities
        End Get
        Set(ByVal value As String)
            quantities = value
        End Set
    End Property
    Public Property rate() As String
        Get
            Return rates
        End Get
        Set(ByVal value As String)
            rates = value
        End Set
    End Property
    Public Property amount() As String
        Get
            Return amounts
        End Get
        Set(ByVal value As String)
            amounts = value
        End Set
    End Property
End Class
