Imports VectorDraw.Serialize

Public Class Form1
#Region "Buttons & Combo events"
    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        Select Case comboBox1.Text.ToLower()
            Case "blocks"
                AddBlockItems()
            Case "layers"
                AddLayersItems()
            Case "textstyles"
                AddTextstylesItems()
            Case "dimstyles"
                AddDimstylesItems()
            Case "hatchpatterns"
                AddHatchItems()
            Case "image definitions"
                AddImageItems()
            Case "linetypes"
                AddCustomLinetype()
            Case "xproperties"
                ShowMessage()
            Case "external references"
                AddExternalReferences()
            Case "layouts"
                AddLayout()
            Case "lights"
                AddLights()
            Case "multilines"
                AddMultilineStyles()

        End Select
    End Sub

    Private Sub butRotate3d_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRotate3d.Click
        VdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VROT")
    End Sub

    Private Sub button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button2.Click

        Select Case comboBox1.Text.ToLower()
            Case "blocks"
                AddInsertObjects()
            Case "layers"
                AddEntitiesWithLayes()
            Case "textstyles"
                AddTextEntities()
            Case "dimstyles"
                AddDimensions()
            Case "hatchpatterns"
                AddHatchedEntities()
            Case "image definitions"
                AddImagesEntities()
            Case "linetypes"
                AddLines()
            Case "xproperties"
                AddXproperties()
            Case "external references"
                AddReferencesInserts()
            Case "layouts"
                AddLayoutEntities()
            Case "lights"
                Add3DEntities()
            Case "multilines"
                AddMultilines()
        End Select
    End Sub

    Private Sub button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button3.Click
        Select Case comboBox1.Text.ToLower()
            Case "blocks"
                OpenBlocksForm()
            Case "layers"
                OpenLayersDialog()
            Case "textstyles"
                OpenTextstylesDialog()
            Case "dimstyles"
                OpenDimstylesDialog()
            Case "hatchpatterns"
                OpenHatchPatternsDialog()
            Case "image definitions"
                OpenImageDefinitionsDialog()
            Case "linetypes"
                OpenLinetypesDialog()
            Case "xproperties"
                OpenXpropertiesdialog()
            Case "external references"
                OpenExternalReferencesDialog()
            Case "layouts"
                OpenLayoutsDialog()
            Case "lights"
                OpenLightsDialog()
            Case "multilines"
                OpenMultilinesDialog()
        End Select
    End Sub

    Private Sub comboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboBox1.SelectedIndexChanged
        VdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.LayoutTab, False)
        VdFramedControl1.BaseControl.ActiveDocument.[New]()
    End Sub
#End Region

#Region "Form LOAD/UNLOAD"
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        VdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.CommandLine, False)
        VdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.LayoutTab, False)
        VdFramedControl1.UnLoadMenu()
        comboBox1.SelectedIndex = 0
    End Sub
#End Region

#Region "Blocks"

    Private Sub AddBlockItems()

        'We create a block object and initialize it's default properties.
        Dim blk As VectorDraw.Professional.vdPrimaries.vdBlock = New VectorDraw.Professional.vdPrimaries.vdBlock
        blk.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        blk.setDocumentDefaults()
        blk.Origin = New VectorDraw.Geometry.gPoint(6.0, 0.0)
        blk.Name = "CustomBlock"
        'We add some entities to the block.
        Dim poly As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline()
        poly.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        poly.setDocumentDefaults()
        poly.VertexList.Add(New VectorDraw.Geometry.gPoint())
        poly.VertexList.Add(New VectorDraw.Geometry.gPoint(1.0, 0.0))
        poly.VertexList.Add(New VectorDraw.Geometry.gPoint(2.0, 1.0))
        poly.VertexList.Add(New VectorDraw.Geometry.gPoint(4.0, -1.0))
        poly.VertexList.Add(New VectorDraw.Geometry.gPoint(6.0, 1.0))
        poly.VertexList.Add(New VectorDraw.Geometry.gPoint(8.0, -1.0))
        poly.VertexList.Add(New VectorDraw.Geometry.gPoint(10.0, 1.0))
        poly.VertexList.Add(New VectorDraw.Geometry.gPoint(11.0, 0.0))
        poly.VertexList.Add(New VectorDraw.Geometry.gPoint(12.0, 0.0))
        blk.Entities.AddItem(poly)

        'We also add an attribute definition to the block.
        Dim attribdef As VectorDraw.Professional.vdFigures.vdAttribDef = New VectorDraw.Professional.vdFigures.vdAttribDef()
        attribdef.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        attribdef.setDocumentDefaults()
        attribdef.InsertionPoint = New VectorDraw.Geometry.gPoint(5.0, 1.2)
        'Name of the attribute used to be found when using the block.
        attribdef.TagString = "resistance"
        'Default value used when inserted the block from the block's dialog.
        attribdef.ValueString = "1W"
        blk.Entities.AddItem(attribdef)
        'And then we add this block to the document's blocks collection
        VdFramedControl1.BaseControl.ActiveDocument.Blocks.AddItem(blk)

        'We will also add a block from a precreated file.

        Dim path As String = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "vdblk.vdcl"
        Dim path1 As String = ""
        Dim blk2 As VectorDraw.Professional.vdPrimaries.vdBlock
        If VdFramedControl1.BaseControl.ActiveDocument.FindFile(path, path1) Then
            blk2 = VdFramedControl1.BaseControl.ActiveDocument.Blocks.AddFromFile(path, False)
            'We check if a block with name CustomBlock2 already exists and if not we change the name of the block to CustomBlock2.
            If VdFramedControl1.BaseControl.ActiveDocument.Blocks.FindName("CustomBlock2") Is Nothing Then
                blk2.Name = "CustomBlock2"
            End If
        End If
    End Sub

    Private Sub AddInsertObjects()


        'We will add 5 instances(inserts) of each block to the Document with different properties.
        'First we check if the blocks have been already added to the blocks collection.
        If Not VdFramedControl1.BaseControl.ActiveDocument.Blocks.FindName("CustomBlock") Is Nothing Then
            Dim ins As VectorDraw.Professional.vdFigures.vdInsert
            Dim i As Short
            For i = 0 To 4

                ins = New VectorDraw.Professional.vdFigures.vdInsert()
                ins.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
                ins.setDocumentDefaults()
                ins.Block = VdFramedControl1.BaseControl.ActiveDocument.Blocks.FindName("CustomBlock")
                ins.InsertionPoint = New VectorDraw.Geometry.gPoint(i * 10, 10)
                ins.PenColor.ColorIndex = i
                ins.Rotation = VectorDraw.Geometry.Globals.HALF_PI / 2.0 * i

                'This will create the necessary vdAtrib objects to the insert.
                ins.CreateDefaultAttributes()
                'Now we will change the value of the attribute
                If ins.Attributes.Count = 1 Then
                    ins.Attributes(0).ValueString = i.ToString() + "W"
                End If

                'And we add the entities to the Model Layout.
                VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(ins)

                ins = New VectorDraw.Professional.vdFigures.vdInsert()
                ins.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
                ins.setDocumentDefaults()
                ins.Block = VdFramedControl1.BaseControl.ActiveDocument.Blocks.FindName("CustomBlock2")
                ins.InsertionPoint = New VectorDraw.Geometry.gPoint(i * 10, -10)
                ins.PenColor.ColorIndex = CType((i * 40 + 10), Short)
                ins.Xscale = 2.0
                ins.Yscale = 2.0
                ins.Rotation = -VectorDraw.Geometry.Globals.HALF_PI * i

                'Since the active Layout is the model adding this insert to the Model or the ActiveLayout is the same thing.
                VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(ins)
            Next i
            'Zoom extends and redraw to see the changes.
            VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ZoomExtents()
            VdFramedControl1.BaseControl.ActiveDocument.Redraw(True)
        Else
            MessageBox.Show("Please add blocks to the collection by pressing the proper button")
        End If
    End Sub
    Private Sub OpenBlocksForm()

        Dim form As VectorDraw.Professional.Dialogs.InsertBlockDialog = VectorDraw.Professional.Dialogs.InsertBlockDialog.Show(VdFramedControl1.BaseControl.ActiveDocument, VdFramedControl1.BaseControl.ActiveControl, False, "")

        If form.DialogResult = Windows.Forms.DialogResult.OK Then
            If TypeOf form.insertionPoint Is Double() Then
                Dim pt() As Double = form.insertionPoint
                form.insertionPoint = New VectorDraw.Geometry.gPoint(pt(0), pt(1), pt(2))
            End If

            If TypeOf form.scales Is String Then
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdInsert(form.blockname, form.insertionPoint, form.scales, form.scales, form.rotationAngle)
            Else
                Dim scales() As Double = form.scales
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdInsert(form.blockname, form.insertionPoint, scales(0), scales(1), form.rotationAngle)
            End If
        End If
    End Sub


#End Region

#Region "Layers"

    Private Sub AddLayersItems()
        'We will add several Layer objects to the Document's layer collection with different properties.
        'Layer1,Entities with ByLayer value at their PenColor property obtain the PenColor of the layer.
        Dim lay As VectorDraw.Professional.vdPrimaries.vdLayer = New VectorDraw.Professional.vdPrimaries.vdLayer()
        lay.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        lay.setDocumentDefaults()
        lay.Name = "Layer1"
        lay.PenColor.SystemColor = Color.Red
        VdFramedControl1.BaseControl.ActiveDocument.Layers.AddItem(lay)

        'You can also add layers using the Add function of the collection which is much easier to use.
        'Layer2,Entities with ByLayer value at their LineType property obtain the LineType of the layer.
        Dim lay2 As VectorDraw.Professional.vdPrimaries.vdLayer = VdFramedControl1.BaseControl.ActiveDocument.Layers.Add("Layer2")
        lay2.PenColor.ColorIndex = 2
        lay2.LineType = VdFramedControl1.BaseControl.ActiveDocument.LineTypes.DPIDashDotDot

        'Layer3,Entities with ByLayer value at their LineWeight property obtain the Lineweight of the layer.
        Dim lay3 As VectorDraw.Professional.vdPrimaries.vdLayer = VdFramedControl1.BaseControl.ActiveDocument.Layers.Add("Layer3")
        lay3.PenColor.ColorIndex = 3
        lay3.LineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_158

        'Layer4,Entities with frozen layers are not drawn.
        Dim lay4 As VectorDraw.Professional.vdPrimaries.vdLayer = VdFramedControl1.BaseControl.ActiveDocument.Layers.Add("Layer4")
        lay4.PenColor.ColorIndex = 4
        lay4.Frozen = True

        'Layer5,Entities with locked layers cannot be deleted.
        Dim lay5 As VectorDraw.Professional.vdPrimaries.vdLayer = VdFramedControl1.BaseControl.ActiveDocument.Layers.Add("Layer5")
        lay5.PenColor.ColorIndex = 5
        lay5.Lock = True
    End Sub
    Private Sub AddEntitiesWithLayes()
        'First we check if the Layers have been added to the collection!!!
        If VdFramedControl1.BaseControl.ActiveDocument.Layers.Count > 4 Then
            'We will add 5 circles with different layer property each.
            Dim i As Integer
            For i = 0 To 4
                Dim circ As VectorDraw.Professional.vdFigures.vdCircle = New VectorDraw.Professional.vdFigures.vdCircle()
                circ.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
                circ.setDocumentDefaults()
                circ.Center = New VectorDraw.Geometry.gPoint(i * 10.0, 10.0)
                circ.Radius = 4.0
                If Math.IEEERemainder(i, 2) = 0 Then
                    circ.ExtrusionVector = New VectorDraw.Geometry.Vector(0, 1, 1)
                End If

                'We give each circle a different layer.
                Dim layername As String = "Layer" + (i + 1).ToString()
                Dim lay As VectorDraw.Professional.vdPrimaries.vdLayer = VdFramedControl1.BaseControl.ActiveDocument.Layers.FindName(layername)
                'We check again if the layer exists because the check we did at the begining with the count does not mean that this layer exist.
                If Not lay Is Nothing Then
                    circ.Layer = VdFramedControl1.BaseControl.ActiveDocument.Layers.FindName(layername)
                    VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(circ)
                End If
            Next i

            'We Add a vdText object just to explain what these entities are.
            Dim text As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText()
            text.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
            text.setDocumentDefaults()
            text.InsertionPoint = New VectorDraw.Geometry.gPoint(5, 2)
            text.TextString = "5 Circles with different Layer and Extrusion Vector"
            VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(text)

            'Zoom and Redraw.
            VdFramedControl1.BaseControl.ActiveDocument.Model.ZoomExtents()
            VdFramedControl1.BaseControl.ActiveDocument.Redraw(True)
        Else
            MessageBox.Show("Please Add Layers With the proper button")
        End If
    End Sub
    Private Sub OpenLayersDialog()
        VectorDraw.Professional.Dialogs.LayersDialog.Show(VdFramedControl1.BaseControl.ActiveDocument)
    End Sub
#End Region

#Region "TextStyles"
    Private Sub AddTextstylesItems()
        'We add a textstyle with font name Verdana.
        Dim style1 As VectorDraw.Professional.vdPrimaries.vdTextstyle = New VectorDraw.Professional.vdPrimaries.vdTextstyle()
        style1.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        style1.setDocumentDefaults()
        style1.Name = "TextStyle1"
        style1.FontFile = "Verdana"
        VdFramedControl1.BaseControl.ActiveDocument.TextStyles.AddItem(style1)

        'You can also add Textstyles using the Add function of the collection which is much easier.
        Dim style2 As VectorDraw.Professional.vdPrimaries.vdTextstyle = VdFramedControl1.BaseControl.ActiveDocument.TextStyles.Add("Textstyle2")
        style2.Extra.IsUnderLine = True
        style2.Extra.IsStrikeOut = True
        style2.FontFile = "Wingdings 2"
    End Sub
    Private Sub AddTextEntities()
        'Just a simple check if some Textstyles have been added.
        If VdFramedControl1.BaseControl.ActiveDocument.TextStyles.Count > 2 Then
            'We will add 3 vdText objects that will have different Textstyles
            Dim i As Integer
            For i = 0 To 2
                Dim text As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText()
                text.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
                text.setDocumentDefaults()
                text.InsertionPoint = New VectorDraw.Geometry.gPoint(10.0, i * 10.0)
                Dim TextStyleName As String = "Textstyle" + i.ToString()
                'We always check if the textstyle exists.If not we set the Default STANDARD Textstyle.
                'The Default Textstyle will be set to the first text since Textstyle0 does not exist and to the others if the AddTextstyles button is not yet pressed..
                Dim style As VectorDraw.Professional.vdPrimaries.vdTextstyle = VdFramedControl1.BaseControl.ActiveDocument.TextStyles.FindName(TextStyleName)
                If Not style Is Nothing Then
                    text.Style = style
                Else
                    text.Style = VdFramedControl1.BaseControl.ActiveDocument.TextStyles.Standard
                End If

                text.TextString = "Text using " + text.Style.Name + " Textstyle"
                VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(text)
            Next i
            'Zoom and Redraw.
            VdFramedControl1.BaseControl.ActiveDocument.Model.ZoomExtents()
            VdFramedControl1.BaseControl.ActiveDocument.Redraw(True)
        Else
            MessageBox.Show("Please Add TextStyles With the proper button")
        End If

    End Sub
    Private Sub OpenTextstylesDialog()
        VectorDraw.Professional.Dialogs.frmTextStyle.Show(VdFramedControl1.BaseControl.ActiveDocument)
    End Sub
#End Region

#Region "DimStyles"

    Private Sub AddDimstylesItems()
        'We create a vdDimstyle object.
        Dim style1 As VectorDraw.Professional.vdPrimaries.vdDimstyle = New VectorDraw.Professional.vdPrimaries.vdDimstyle()
        style1.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        style1.setDocumentDefaults()
        'And change some properties.
        style1.Name = "DimStyle1"
        style1.TextColor.ColorIndex = 1
        style1.TextHeight = 1.0
        'And add this object to the Dimstyles collection of the document.
        VdFramedControl1.BaseControl.ActiveDocument.DimStyles.AddItem(style1)

        'We can also add dimstyles using the Add function of the dimstyles collection which is much easier.
        Dim style2 As VectorDraw.Professional.vdPrimaries.vdDimstyle = VdFramedControl1.BaseControl.ActiveDocument.DimStyles.Add("DimStyle2")
        style2.ExtLineVisible = False
        style2.TextHeight = 1.0

        Dim style3 As VectorDraw.Professional.vdPrimaries.vdDimstyle = VdFramedControl1.BaseControl.ActiveDocument.DimStyles.Add("DimStyle3")
        style3.ExtLineColor.ColorIndex = 1
        style3.DimTol = True
        style3.DimTp = 0.3
        style3.DimTm = 0.3
        style3.TextHeight = 1.0

        Dim style4 As VectorDraw.Professional.vdPrimaries.vdDimstyle = VdFramedControl1.BaseControl.ActiveDocument.DimStyles.Add("DimStyle4")
        style4.DimAdec = 0
        style4.DecimalPrecision = 0
        style4.TextHeight = 1.0

        Dim style5 As VectorDraw.Professional.vdPrimaries.vdDimstyle = VdFramedControl1.BaseControl.ActiveDocument.DimStyles.Add("DimStyle5")
        style5.ArrowBlock = VdFramedControl1.BaseControl.ActiveDocument.Blocks.VDDIM_NONE
        style5.TextHeight = 1.0

        Dim style6 As VectorDraw.Professional.vdPrimaries.vdDimstyle = VdFramedControl1.BaseControl.ActiveDocument.DimStyles.Add("DimStyle6")
        style6.ArrowSize *= 5.0
        style6.TextHeight = 1.0
    End Sub
    Private Sub AddDimensions()
        'Just a simple check to verify that the Adddimstyles button is pressed
        If VdFramedControl1.BaseControl.ActiveDocument.DimStyles.Count < 4 Then
            MessageBox.Show("Please Add some DimStyles with the proper button for better results.")
            Return
        End If

        'We will create 6 dimension of each type(6 types)
        Dim i As Integer
        For i = 0 To 6
            Dim dimname As String = "DimStyle" + (i + 1).ToString()
            Dim style As VectorDraw.Professional.vdPrimaries.vdDimstyle = VdFramedControl1.BaseControl.ActiveDocument.DimStyles.FindName(dimname)
            If style Is Nothing Then
                style = VdFramedControl1.BaseControl.ActiveDocument.DimStyles.Standard
            End If

            Dim dim1 As VectorDraw.Professional.vdFigures.vdDimension = New VectorDraw.Professional.vdFigures.vdDimension()
            dim1.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
            dim1.setDocumentDefaults()
            dim1.dimType = VectorDraw.Professional.Constants.VdConstDimType.dim_Rotated
            dim1.DefPoint1 = New VectorDraw.Geometry.gPoint(5.0, 5 * i)
            dim1.DefPoint2 = New VectorDraw.Geometry.gPoint(10.5, 5 * i + 2.0)
            dim1.LinePosition = New VectorDraw.Geometry.gPoint(7.0, 5 * i + 4.0)
            dim1.Rotation = 0.0
            'We set the dim style that we found before.
            dim1.Style = style
            'We add the object to the model entities collection
            VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(dim1)
            Dim dim2 As VectorDraw.Professional.vdFigures.vdDimension = New VectorDraw.Professional.vdFigures.vdDimension()
            dim2.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
            dim2.setDocumentDefaults()
            dim2.dimType = VectorDraw.Professional.Constants.VdConstDimType.dim_Rotated
            dim2.DefPoint1 = New VectorDraw.Geometry.gPoint(12.0, 5 * i)
            dim2.DefPoint2 = New VectorDraw.Geometry.gPoint(15.5, 5 * i + 4.5)
            dim2.LinePosition = New VectorDraw.Geometry.gPoint(17.0, 5 * i + 4.0)
            dim2.Rotation = VectorDraw.Geometry.Globals.HALF_PI
            dim2.Style = style

            VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(dim2)

            Dim dim3 As VectorDraw.Professional.vdFigures.vdDimension = New VectorDraw.Professional.vdFigures.vdDimension()
            dim3.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
            dim3.setDocumentDefaults()
            dim3.dimType = VectorDraw.Professional.Constants.VdConstDimType.dim_Aligned
            dim3.DefPoint1 = New VectorDraw.Geometry.gPoint(19, 5 * i)
            dim3.DefPoint2 = New VectorDraw.Geometry.gPoint(23.5, 5 * i + 3.0)
            dim3.LinePosition = VectorDraw.Geometry.gPoint.Polar(New VectorDraw.Geometry.gPoint(19, 5 * i), VectorDraw.Geometry.Globals.HALF_PI / 2.0, 7.0)
            dim3.Style = style

            VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(dim3)

            Dim circ As VectorDraw.Professional.vdFigures.vdCircle = New VectorDraw.Professional.vdFigures.vdCircle()
            circ.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
            circ.setDocumentDefaults()
            circ.Center = New VectorDraw.Geometry.gPoint(29, 5 * i)
            circ.Radius = 2.4
            VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(circ)

            Dim dim4 As VectorDraw.Professional.vdFigures.vdDimension = New VectorDraw.Professional.vdFigures.vdDimension()
            dim4.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
            dim4.setDocumentDefaults()
            dim4.dimType = VectorDraw.Professional.Constants.VdConstDimType.dim_Diameter
            dim4.DefPoint1 = New VectorDraw.Geometry.gPoint(31.4, 5 * i)
            dim4.DefPoint2 = New VectorDraw.Geometry.gPoint(29, 5 * i)
            dim4.DefPoint3 = New VectorDraw.Geometry.gPoint(29, 5 * i)
            dim4.DefPoint4 = New VectorDraw.Geometry.gPoint(29, 5 * i)
            dim4.LinePosition = New VectorDraw.Geometry.gPoint(26.6, 5 * i)
            dim4.Style = style

            VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(dim4)

            circ = New VectorDraw.Professional.vdFigures.vdCircle()
            circ.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
            circ.setDocumentDefaults()
            circ.Center = New VectorDraw.Geometry.gPoint(35, 5 * i)
            circ.Radius = 3.4
            VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(circ)

            dim4 = New VectorDraw.Professional.vdFigures.vdDimension()
            dim4.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
            dim4.setDocumentDefaults()
            dim4.dimType = VectorDraw.Professional.Constants.VdConstDimType.dim_Radial
            dim4.DefPoint1 = New VectorDraw.Geometry.gPoint(38.4, 5 * i)
            dim4.DefPoint2 = New VectorDraw.Geometry.gPoint(35, 5 * i)
            dim4.DefPoint3 = New VectorDraw.Geometry.gPoint(35, 5 * i)
            dim4.DefPoint4 = New VectorDraw.Geometry.gPoint(35, 5 * i)
            dim4.LinePosition = New VectorDraw.Geometry.gPoint(35, 5 * i)
            dim4.Style = style

            VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(dim4)


            Dim poly As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline()
            poly.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
            poly.setDocumentDefaults()
            poly.VertexList.Add(New VectorDraw.Geometry.gPoint(45, 5 * i + 4))
            poly.VertexList.Add(New VectorDraw.Geometry.gPoint(40, 5 * i))
            poly.VertexList.Add(New VectorDraw.Geometry.gPoint(47, 5 * i))
            VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(poly)

            dim4 = New VectorDraw.Professional.vdFigures.vdDimension()
            dim4.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
            dim4.setDocumentDefaults()
            dim4.dimType = VectorDraw.Professional.Constants.VdConstDimType.dim_Angular
            dim4.DefPoint1 = New VectorDraw.Geometry.gPoint(40, 5 * i)
            dim4.DefPoint2 = New VectorDraw.Geometry.gPoint(45, 5 * i + 4)
            dim4.DefPoint3 = New VectorDraw.Geometry.gPoint(45, 5 * i + 4)
            dim4.DefPoint4 = New VectorDraw.Geometry.gPoint(47, 5 * i)
            dim4.LinePosition = New VectorDraw.Geometry.gPoint(43, 5 * i + 2.0)
            dim4.Style = style
            VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(dim4)
        Next i
        VdFramedControl1.BaseControl.ActiveDocument.Model.ZoomExtents()
        VdFramedControl1.BaseControl.ActiveDocument.Redraw(True)
    End Sub
    Private Sub OpenDimstylesDialog()
        VectorDraw.Professional.Dialogs.frmDimStyle.Show(VdFramedControl1.BaseControl.ActiveDocument)
    End Sub
#End Region

#Region "HatchPatterns"

    Private Sub AddHatchItems()
        Dim myHatch As VectorDraw.Professional.vdPrimaries.vdHatchPattern
        myHatch = New VectorDraw.Professional.vdPrimaries.vdHatchPattern
        myHatch.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        myHatch.setDocumentDefaults()
        myHatch.Name = "TEST_HATCH" 'hatch is created and it is empty
        'Add 2 lines with dashes to the hatch pattern
        myHatch.PatternLines.AddItem(New VectorDraw.DrawElements.grPatternLine(0D, 0D, 0D, 0D, 5D, New Double() {3D, -3D}, False))
        myHatch.PatternLines.AddItem(New VectorDraw.DrawElements.grPatternLine(VectorDraw.Geometry.Globals.HALF_PI, 0D, 10D, 6D, 0D, New Double() {3D, -2D}, False))


        ' OR you can do the same as below:
        'myHatch.PatternLines.AddItem(New VectorDraw.DrawElements.grPatternLine(0D, 0D, 0D, 0D, 5D, New Double() {3D, -3D}, False))
        'myHatch.PatternLines.AddItem(New VectorDraw.DrawElements.grPatternLine(90D, 0D, 10D, 0D, 6D, New Double() {3, -2}, True))

        ' Important Notes: grPatternLine(angle, originX, originY, offsetX, offsetY, double[] dashes, bool applytransforms)
        ' - When you use the applytransforms = true then you have to use degrees (like 90 degrees) and not radians (like PI/2) in the angle
        ' - The point(OriginX,OriginY) remains the same as when you use applytransforms = false
        ' - The offset distance is translated accordingly with the angle. In the above example the offset distance x:6 & y:0 when is transformed by angle=90 becomes
        ' the opposite; x:0 & y:6

        myHatch.Update() 'Update the Hatch
        VdFramedControl1.BaseControl.ActiveDocument.HatchPatterns.AddItem(myHatch) 'add the hatch to the collection

        MessageBox.Show("A custom Hatch pattern has been created and added to the list with name TEST_HATCH")
    End Sub
    Private Sub AddHatchedEntities()
        Dim circ1 As VectorDraw.Professional.vdFigures.vdCircle = New VectorDraw.Professional.vdFigures.vdCircle()
        circ1.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        circ1.setDocumentDefaults()
        circ1.Center = New VectorDraw.Geometry.gPoint(10.0, 10.0)
        circ1.Radius = 7.0
        circ1.HatchProperties = New VectorDraw.Professional.vdObjects.vdHatchProperties()
        circ1.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid
        circ1.HatchProperties.FillColor.ColorIndex = 1
        VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(circ1)

        circ1 = New VectorDraw.Professional.vdFigures.vdCircle()
        circ1.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        circ1.setDocumentDefaults()
        circ1.Center = New VectorDraw.Geometry.gPoint(20.0, 10.0)
        circ1.Radius = 5.0
        circ1.HatchProperties = New VectorDraw.Professional.vdObjects.vdHatchProperties()
        circ1.HatchProperties.Solid2dTransparency = 100
        circ1.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid
        circ1.HatchProperties.FillColor.ColorIndex = 2
        VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(circ1)

        Dim poly As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline()
        poly.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        poly.setDocumentDefaults()
        poly.VertexList.Add(New VectorDraw.Geometry.gPoint(10.0, -10.0))
        poly.VertexList.Add(New VectorDraw.Geometry.gPoint(20.0, -10.0))
        poly.VertexList.Add(New VectorDraw.Geometry.gPoint(25.0, -20.0))
        poly.VertexList.Add(New VectorDraw.Geometry.gPoint(5.0, -20.0))
        poly.Flag = VectorDraw.Professional.Constants.VdConstPlineFlag.PlFlagCLOSE

        poly.HatchProperties = New VectorDraw.Professional.vdObjects.vdHatchProperties()
        poly.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModePattern
        poly.HatchProperties.FillColor.ColorIndex = 0
        poly.HatchProperties.FillBkColor.ColorIndex = 2
        poly.HatchProperties.HatchPattern = VdFramedControl1.BaseControl.ActiveDocument.HatchPatterns.FindName("TEST_HATCH")
        poly.HatchProperties.HatchScale = 0.5
        VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(poly)

        Dim arc As VectorDraw.Professional.vdFigures.vdArc = New VectorDraw.Professional.vdFigures.vdArc()
        arc.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        arc.setDocumentDefaults()
        arc.Center = New VectorDraw.Geometry.gPoint(30, -4)
        arc.Radius = 10.0
        arc.StartAngle = VectorDraw.Geometry.Globals.DegreesToRadians(13.0)
        arc.EndAngle = VectorDraw.Geometry.Globals.DegreesToRadians(175.0)

        arc.HatchProperties = New VectorDraw.Professional.vdObjects.vdHatchProperties()
        arc.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeHatchBlock
        arc.HatchProperties.FillColor.SystemColor = Color.Blue
        arc.HatchProperties.HatchBlock = VdFramedControl1.BaseControl.ActiveDocument.Blocks.VDDIM_DEFAULT
        arc.HatchProperties.HatchAngle = VectorDraw.Geometry.Globals.DegreesToRadians(33.0)
        arc.HatchProperties.HatchScale = 0.3
        VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(arc)


        VdFramedControl1.BaseControl.ActiveDocument.Model.ZoomExtents()
        VdFramedControl1.BaseControl.ActiveDocument.Redraw(True)
    End Sub
    Private Sub OpenHatchPatternsDialog()
        Dim frm As VectorDraw.Professional.Dialogs.GetHatchPatternsDialog = VectorDraw.Professional.Dialogs.GetHatchPatternsDialog.Show(VdFramedControl1.BaseControl.ActiveDocument, VdFramedControl1.BaseControl.ActiveControl, VdFramedControl1.BaseControl.ActiveDocument.HatchPatterns.Solid)
        If Not (frm.finalSelected Is Nothing) Then
            MessageBox.Show(frm.finalSelected.Name + " pattern selected")
        Else
            MessageBox.Show("Cancel button pressed")
        End If
    End Sub

#End Region

#Region "Images"

    Private Sub AddImageItems()
        'We will create an image and add it to the imageDef

        'First we create a black circle with radius 5.0 at (0.0,0.0,0.0).
        Dim circle As VectorDraw.Professional.vdFigures.vdCircle = New VectorDraw.Professional.vdFigures.vdCircle()
        circle.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        circle.setDocumentDefaults()
        circle.Center = New VectorDraw.Geometry.gPoint()
        circle.Radius = 5.0
        circle.PenColor.SystemColor = Color.Black
        circle.PenWidth = 0.3

        'Then we create a layout to add this circle.Note that this is a temporary layout and it is not added to the document at all.
        Dim lay As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout()
        lay.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        lay.setDocumentDefaults()
        lay.Entities.AddItem(circle)
        lay.BkColorEx = Color.Red
        'This property overides the general DisableShowPrinterPaper property that is located in the ActiveDocument.
        lay.DisableShowPrinterPaper = True
        'We zoom the layout where we want to show the circle.
        lay.ZoomWindow(New VectorDraw.Geometry.gPoint(-6.0, -6.0), New VectorDraw.Geometry.gPoint(6, 6))

        'We create a 250,250 image and a Graphics from that image.
        Dim image As System.Drawing.Bitmap = New Bitmap(250, 250)
        Dim gr As System.Drawing.Graphics = System.Drawing.Graphics.FromImage(image)

        'We draw the layout to that image.We first disable the layout paper and enable it again.
        lay.RenderToGraphics(gr, Nothing, image.Width, image.Height)

        'From that image we create the imageDefinition.
        Dim imagedef As VectorDraw.Professional.vdPrimaries.vdImageDef = New VectorDraw.Professional.vdPrimaries.vdImageDef()
        imagedef.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        imagedef.setDocumentDefaults()
        imagedef.Name = "Image1"
        Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream()
        image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp)
        imagedef.InternalSetBytes(New VectorDraw.Geometry.ByteArray(stream.ToArray()))
        VdFramedControl1.BaseControl.ActiveDocument.Images.AddItem(imagedef)

        'We dispose any objects that we don't want.
        stream.Close()
        stream.Dispose()
        gr.Dispose()
        'We could have saved the image to the drive using the Save function.
        Dim path As String = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "vdimage.bmp"

        image.Save(path, System.Drawing.Imaging.ImageFormat.Bmp)
        'And create a second imageDef from this filename.
        Dim imagedef1 As VectorDraw.Professional.vdPrimaries.vdImageDef = New VectorDraw.Professional.vdPrimaries.vdImageDef()
        imagedef1.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        imagedef1.setDocumentDefaults()
        imagedef1.Name = "Image2"

        imagedef1.FileName = path
        VdFramedControl1.BaseControl.ActiveDocument.Images.AddItem(imagedef1)

        image.Dispose()

        MessageBox.Show("An image was created (silently) from rendered objects and has been added to the Images collection of the document.")
    End Sub
    Private Sub AddImagesEntities()
        If VdFramedControl1.BaseControl.ActiveDocument.Images.Count = 0 Then
            MessageBox.Show("Please Add Collection item first")
            Return
        End If
        'We create an image and give the precreated image definition.
        Dim image As VectorDraw.Professional.vdFigures.vdImage = New VectorDraw.Professional.vdFigures.vdImage()
        image.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        image.setDocumentDefaults()
        'We know that the first image is what we want so we can just get the [0] item from the collection else we could have used the Find methods.
        image.ImageDefinition = VdFramedControl1.BaseControl.ActiveDocument.Images(0)
        image.InsertionPoint = New VectorDraw.Geometry.gPoint(1.0, 1.0)
        VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(image)

        'We will also add an image that will be clipped.
        image = New VectorDraw.Professional.vdFigures.vdImage()
        image.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        image.setDocumentDefaults()
        'We know that the first image is what we want so we can just get the [0] item from the collection else we could have used the Find methods.
        image.ImageDefinition = VdFramedControl1.BaseControl.ActiveDocument.Images(0)
        image.InsertionPoint = New VectorDraw.Geometry.gPoint(-3.0, 1.0)
        VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(image)

        'And clip the image!!! Note that the cli points are relative to the upper corner of the image in Pixels.
        image.ClipBoundary.Add(New VectorDraw.Geometry.gPoint(0.0, 0.0, 0.0))
        image.ClipBoundary.Add(New VectorDraw.Geometry.gPoint(image.ImageDefinition.Width, 0.0, 0.0))
        image.ClipBoundary.Add(New VectorDraw.Geometry.gPoint(0.0, image.ImageDefinition.Height, 0.0))

        VdFramedControl1.BaseControl.ActiveDocument.Redraw(True)
        MessageBox.Show("We added two images one regular and one with clip points!!")
    End Sub
    Private Sub OpenImageDefinitionsDialog()
        VectorDraw.Professional.Dialogs.FrmImageDefs.Show(VdFramedControl1.BaseControl.ActiveDocument)
    End Sub
#End Region

#Region "Linetypes"
    Private Sub AddCustomLinetype()
        Dim linetype As VectorDraw.Professional.vdPrimaries.vdLineType = New VectorDraw.Professional.vdPrimaries.vdLineType()
        linetype.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        linetype.setDocumentDefaults()
        linetype.Name = "MyCustomLinetype"

        linetype.Comment = "Custom _ . . _ _ . . _ _ . . _ _ . . _ _ . . _ _ . . _"
        'Dash
        linetype.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(0.5))
        'Blank
        linetype.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(-0.5))
        'Dash
        linetype.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(0.5))
        'Blank
        linetype.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(-0.5))
        'Dot
        linetype.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(0.0))
        'Blank
        linetype.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(-0.5))
        'Dot
        linetype.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(0.0))
        'Blank
        linetype.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(-0.5))
        linetype.Segments.UpdateLength()

        VdFramedControl1.BaseControl.ActiveDocument.LineTypes.AddItem(linetype)
        MessageBox.Show("We created a custom Linetype named MyCustomLinetype and looks like this:  _ . . _")

        'We will add a second Custom linetype that contains text.
        linetype = New VectorDraw.Professional.vdPrimaries.vdLineType()
        linetype.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        linetype.setDocumentDefaults()
        linetype.Name = "MyCustomLinetype2"

        linetype.Comment = "Custom2 _ VD _ _ VD _ _ VD _ _ VD _ _ VD _ _ VD _ "
        'Dash
        linetype.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(2.0))
        'Blank
        linetype.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(-1.0))

        Dim seg As VectorDraw.Render.LineTypeSegment = New VectorDraw.Render.LineTypeSegment()
        seg.Flag = VectorDraw.Render.LineTypeSegment.LineTypeElementType.TTF_TEXT
        seg.ShapeScale = 0.7
        seg.ShapeStyle = VdFramedControl1.BaseControl.ActiveDocument.TextStyles.Standard.GrTextStyle
        seg.ShapeText = "VD"
        linetype.Segments.AddItem(seg)

        'Blank
        linetype.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(-2.0))
        'Dash
        linetype.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(2.0))
        'Blank
        linetype.Segments.AddItem(New VectorDraw.Render.LineTypeSegment(-1.0))
        linetype.Segments.UpdateLength()

        VdFramedControl1.BaseControl.ActiveDocument.LineTypes.AddItem(linetype)
        MessageBox.Show("We created a custom Linetype named MyCustomLinetype2 and looks like this:  _ VD _")
    End Sub
    Private Sub AddLines()
        'We will add several Lines with different Linetypes.
        Dim i As Short
        For i = 0 To 4
            Dim line As VectorDraw.Professional.vdFigures.vdLine = New VectorDraw.Professional.vdFigures.vdLine(New VectorDraw.Geometry.gPoint(i * 5.0 + 5.0, -25.0), New VectorDraw.Geometry.gPoint(i * 5.0 + 5.0, 25.0))
            line.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
            line.setDocumentDefaults()
            line.PenColor.ColorIndex = i

            'We will create a linetype for the line
            Dim linetype As VectorDraw.Professional.vdPrimaries.vdLineType = New VectorDraw.Professional.vdPrimaries.vdLineType()

            Select Case i
                Case 0
                    linetype = VdFramedControl1.BaseControl.ActiveDocument.LineTypes.FindName("MyCustomLinetype")
                Case 1
                    linetype = VdFramedControl1.BaseControl.ActiveDocument.LineTypes.FindName("MyCustomLinetype2")
                Case 2
                    linetype = VdFramedControl1.BaseControl.ActiveDocument.LineTypes.FindName("BORDER")
                Case 3
                    linetype = VdFramedControl1.BaseControl.ActiveDocument.LineTypes.FindName("SOLID")
                Case 4
                    linetype = VdFramedControl1.BaseControl.ActiveDocument.LineTypes.FindName("DOTX2")
            End Select
            'Set the found linetype to the line.
            If Not (linetype Is Nothing) Then
                line.LineType = linetype
            End If
            'Add the line to the model.
            VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(line)
        Next i
        'Zoom the model and redraw to see the added figures.
        VdFramedControl1.BaseControl.ActiveDocument.Model.ZoomWindow(New VectorDraw.Geometry.gPoint(0.0, -30.0), New VectorDraw.Geometry.gPoint(30.0, 30.0))
        VdFramedControl1.BaseControl.ActiveDocument.Redraw(True)
    End Sub
    Private Sub OpenLinetypesDialog()
        Dim frm As VectorDraw.Professional.Dialogs.GetLineTypeDialog = VectorDraw.Professional.Dialogs.GetLineTypeDialog.Show(VdFramedControl1.BaseControl.ActiveDocument, VdFramedControl1.BaseControl.ActiveControl, "Solid", True)
        If (frm.DialogResult = Windows.Forms.DialogResult.OK) Then
            MessageBox.Show(frm.finalSelected + " Linetype Selected")
        Else
            MessageBox.Show("Cancel button pressed")
        End If
    End Sub
#End Region

#Region "Xproperties"
    Private Sub ShowMessage()
        MessageBox.Show("No action taken")
    End Sub
    Private Sub AddXproperties()
        'We will add a circle to the model with several xproperties in it's collection.
        Dim circle As VectorDraw.Professional.vdFigures.vdCircle = New VectorDraw.Professional.vdFigures.vdCircle()
        circle.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        circle.setDocumentDefaults()
        circle.Radius = 5.0

        'Add string value xproperty.
        Dim xprop As VectorDraw.Professional.vdObjects.vdXProperty = New VectorDraw.Professional.vdObjects.vdXProperty()
        xprop.Name = "str"
        xprop.PropValue = "string value"
        circle.XProperties.AddItem(xprop)

        'Add integer value xproperty.
        xprop = New VectorDraw.Professional.vdObjects.vdXProperty()
        xprop.Name = "int"
        xprop.PropValue = 5
        circle.XProperties.AddItem(xprop)

        'Add double value xproperty.
        xprop = New VectorDraw.Professional.vdObjects.vdXProperty()
        xprop.Name = "double"
        xprop.PropValue = 3.0
        circle.XProperties.AddItem(xprop)

        'Add gpoint value xproperty.
        xprop = New VectorDraw.Professional.vdObjects.vdXProperty()
        xprop.Name = "int"
        xprop.PropValue = New VectorDraw.Geometry.gPoint(5.0, 5.0, 0.0)
        xprop.TransformID = VectorDraw.Professional.vdObjects.vdXProperty.TransformationType.None
        circle.XProperties.AddItem(xprop)

        'Add world gpoint value xproperty.
        xprop = New VectorDraw.Professional.vdObjects.vdXProperty()
        xprop.Name = "int"
        xprop.PropValue = New VectorDraw.Geometry.gPoint(5.0, 5.0, 0.0)
        xprop.TransformID = VectorDraw.Professional.vdObjects.vdXProperty.TransformationType.WorldDirection
        circle.XProperties.AddItem(xprop)

        'Add distance value xproperty.
        xprop = New VectorDraw.Professional.vdObjects.vdXProperty()
        xprop.Name = "int"
        xprop.PropValue = 7.0
        xprop.TransformID = VectorDraw.Professional.vdObjects.vdXProperty.TransformationType.WorldSpaceDist
        circle.XProperties.AddItem(xprop)

        'Add an object value xproperty.
        xprop = New VectorDraw.Professional.vdObjects.vdXProperty()
        xprop.Name = "object"
        xprop.PropValue = VdFramedControl1.BaseControl.ActiveDocument.Palette(0)
        circle.XProperties.AddItem(xprop)

        'Add an object value xproperty.
        xprop = New VectorDraw.Professional.vdObjects.vdXProperty()
        xprop.Name = "Myobject"
        xprop.PropValue = New MyObject(10, "ten")
        circle.XProperties.AddItem(xprop)

        VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(circle)
        VdFramedControl1.BaseControl.ActiveDocument.Redraw(True)
    End Sub
    Private Sub OpenXpropertiesdialog()
        If VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.Count = 0 Then
            MessageBox.Show("Please press the add entities button.")
        Else
            Dim fig As VectorDraw.Professional.vdPrimaries.vdFigure = VdFramedControl1.BaseControl.ActiveDocument.Model.Entities(0)
            VectorDraw.Professional.Dialogs.frmShowXProperties.Show(VdFramedControl1.BaseControl.ActiveDocument, fig.XProperties)
        End If
    End Sub
#End Region

#Region "External References"
    Private Sub AddExternalReferences()
        'We will add a vdblock object as an external reference to the blocks dialog.
        Dim path As String = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "wmap.vdcl"
        Dim xref As VectorDraw.Professional.vdPrimaries.vdBlock = New VectorDraw.Professional.vdPrimaries.vdBlock()
        xref.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        xref.setDocumentDefaults()
        xref.Name = "wmap"
        xref.ExternalReferencePath = path
        'With update the file is opened and the document of the file is added to the External references of the file.
        xref.Update()
        VdFramedControl1.BaseControl.ActiveDocument.Blocks.AddItem(xref)
    End Sub
    Private Sub AddReferencesInserts()
        'Now we will add the vdinsert object that will show the external reference that we created.
        Dim ins As VectorDraw.Professional.vdFigures.vdInsert = New VectorDraw.Professional.vdFigures.vdInsert()
        ins.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        ins.setDocumentDefaults()
        'We check if the block exists and then give it to the insert.
        Dim blk As VectorDraw.Professional.vdPrimaries.vdBlock = VdFramedControl1.BaseControl.ActiveDocument.Blocks.FindName("wmap")
        If Not blk Is Nothing Then
            ins.Block = blk
            VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(ins)
        End If

        'Note that the Same operation like above could have been done with the following function cmdXref.
        'Dim path As String = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "wmap.vdcl"
        'vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdXref("A", path, new VectorDraw.Geometry.gPoint(), new double[] { 1.0, 1.0 }, 0.0, 0);


        'Zoom the model to show the entity.
        VdFramedControl1.BaseControl.ActiveDocument.Model.ZoomExtents()
        VdFramedControl1.BaseControl.ActiveDocument.Redraw(True)
    End Sub
    Private Sub OpenExternalReferencesDialog()
        VectorDraw.Professional.Dialogs.frmXrefManager.Show(VdFramedControl1.BaseControl.ActiveDocument)
    End Sub
#End Region

#Region "Layouts"
    Private Sub AddLayout()

        'We open a drawing to the document.
        Dim path As String = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "wmap.vdcl"
        VdFramedControl1.BaseControl.ActiveDocument.Open(path)

        'Add some gradient Background colors to the Model.
        VdFramedControl1.BaseControl.ActiveDocument.Model.BkColorEx = Color.Chocolate
        VdFramedControl1.BaseControl.ActiveDocument.Model.BkGradientColor = Color.Black
        VdFramedControl1.BaseControl.ActiveDocument.Model.BkGradientAngle = VectorDraw.Geometry.Globals.DegreesToRadians(270.0)


        'We will add two Layouts to the document.
        'Create a vdLayout object and add it to the layouts collection.
        Dim lay As VectorDraw.Professional.vdPrimaries.vdLayout = New VectorDraw.Professional.vdPrimaries.vdLayout()
        lay.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        lay.setDocumentDefaults()
        lay.Name = "MyLayout1"
        lay.ShowUCSAxis = False
        VdFramedControl1.BaseControl.ActiveDocument.LayOuts.AddItem(lay)

        'Or we can add a layout like this:
        Dim lay2 As VectorDraw.Professional.vdPrimaries.vdLayout = VdFramedControl1.BaseControl.ActiveDocument.LayOuts.Add("MyLayout2")
        lay2.DisableShowPrinterPaper = True
        'In order to see the background color you must disable the printer paper draw.
        'Add some gradient Background colors to the Layout.
        lay2.BkColorEx = Color.Aqua
        lay2.BkGradientColor = Color.Blue

        'The file we opened has already two layouts that we will delete.
        VdFramedControl1.BaseControl.ActiveDocument.LayOuts(0).Deleted = True
        'or this can be done like this:
        Dim lay3 As VectorDraw.Professional.vdPrimaries.vdLayout = VdFramedControl1.BaseControl.ActiveDocument.LayOuts.FindName("PAPER_SPACE")
        If Not (lay3 Is Nothing) Then lay3.Deleted = True
    End Sub
    Private Sub AddLayoutEntities()

        'We check if the layouts have already been added
        If (VdFramedControl1.BaseControl.ActiveDocument.LayOuts.Count <= 2) Then
            MessageBox.Show("Please add some layouts by pressing the above button first")
            Return
        End If


        'Then we add a rectangular viewport to the first added layout.
        Dim view As VectorDraw.Professional.vdFigures.vdViewport = New VectorDraw.Professional.vdFigures.vdViewport()
        view.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        view.setDocumentDefaults()
        view.ShowUCSAxis = False
        view.Height = 100
        view.Width = 150
        view.Center = New VectorDraw.Geometry.gPoint(100.0, 230.0)
        view.ViewCenter = New VectorDraw.Geometry.gPoint(4.4008, 6.8233)
        view.ViewSize = 0.252

        'And add this viewport to the entities of the first layout.
        Dim lay As VectorDraw.Professional.vdPrimaries.vdLayout = VdFramedControl1.BaseControl.ActiveDocument.LayOuts.FindName("MyLayout1")
        'If the entities of the layout are not 0 then this means that this button is already pressed and the viewport already exists so we do not add it again.
        If (lay.Entities.Count > 0) Then Return

        If Not (lay Is Nothing) Then lay.Entities.AddItem(view)

        'We also add a text entity to the layout.
        Dim text As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText()
        text.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        text.setDocumentDefaults()
        text.InsertionPoint = New VectorDraw.Geometry.gPoint(55, 155)
        text.TextString = "GREECE"
        text.Height = 15.0
        If Not (lay Is Nothing) Then lay.Entities.AddItem(text)

        'We set as active layout the first addede layout to show it.
        VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut = VdFramedControl1.BaseControl.ActiveDocument.LayOuts.FindName("MyLayout1")
        VdFramedControl1.BaseControl.ActiveDocument.Redraw(True)

        'Now we will add some viewports with reference objects to the second added layout MyLayout2.
        lay = VdFramedControl1.BaseControl.ActiveDocument.LayOuts.FindName("MyLayout2")

        'We will create two polylines and a circle to be used as viewports.
        Dim poly1 As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline()
        poly1.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        poly1.setDocumentDefaults()
        poly1.VertexList.Add(New VectorDraw.Geometry.gPoint(10D, 280D))
        poly1.VertexList.Add(New VectorDraw.Geometry.gPoint(10D, 180D))
        poly1.VertexList.Add(New VectorDraw.Geometry.gPoint(190D, 180D))
        poly1.VertexList.Add(New VectorDraw.Geometry.gPoint(190D, 280D))
        poly1.Flag = VectorDraw.Professional.Constants.VdConstPlineFlag.PlFlagCLOSE
        If Not (lay Is Nothing) Then lay.Entities.AddItem(poly1)

        'Another polyline
        Dim poly2 As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline()
        poly2.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        poly2.setDocumentDefaults()
        poly2.VertexList.Add(New VectorDraw.Geometry.gPoint(50D, 115D))
        poly2.VertexList.Add(New VectorDraw.Geometry.gPoint(10D, 65D))
        poly2.VertexList.Add(New VectorDraw.Geometry.gPoint(50D, 15D))
        poly2.VertexList.Add(New VectorDraw.Geometry.gPoint(90D, 65D))
        poly2.Flag = VectorDraw.Professional.Constants.VdConstPlineFlag.PlFlagCLOSE
        If Not (lay Is Nothing) Then lay.Entities.AddItem(poly2)

        'A circle
        Dim circle As VectorDraw.Professional.vdFigures.vdCircle = New VectorDraw.Professional.vdFigures.vdCircle()
        circle.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        circle.setDocumentDefaults()
        circle.Center = New VectorDraw.Geometry.gPoint(160D, 65D)
        circle.Radius = 50D
        If Not (lay Is Nothing) Then lay.Entities.AddItem(circle)

        'Now that we have the entities we can create 3 different viewports for these entities.
        Dim vp As VectorDraw.Professional.vdFigures.vdViewport = New VectorDraw.Professional.vdFigures.vdViewport()
        vp.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        vp.setDocumentDefaults()
        vp.ShowUCSAxis = False
        vp.ClipObj = poly1
        vp.ZoomExtents()
        vp.PenColor.SystemColor = Color.Red
        'Add some different gradient collors to the viewport
        vp.BkColorEx = Color.Blue
        vp.BkGradientColor = Color.Aqua
        If Not (lay Is Nothing) Then lay.Entities.AddItem(vp)

        'Another viewport
        vp = New VectorDraw.Professional.vdFigures.vdViewport()
        vp.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        vp.setDocumentDefaults()
        vp.ShowUCSAxis = False
        vp.SetClipHandle(poly2.Handle)
        vp.PenColor.SystemColor = Color.Blue
        vp.ViewCenter = New VectorDraw.Geometry.gPoint(7.1531, 5.0466)
        vp.ViewSize = 2.6962
        vp.PenWidth = 2.2
        'Freeze all layers and show only "AUSTRALIA" layer.
        vp.FrozenLayerList.AddItem("0")
        vp.FrozenLayerList.AddItem("Clients")
        vp.FrozenLayerList.AddItem("Land")
        If Not (lay Is Nothing) Then lay.Entities.AddItem(vp)

        'And a viewport for the circle
        vp = New VectorDraw.Professional.vdFigures.vdViewport()
        vp.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        vp.setDocumentDefaults()
        vp.ShowUCSAxis = False
        vp.SetClipHandle(circle.Handle)
        vp.PenColor.SystemColor = Color.Yellow
        vp.ViewCenter = New VectorDraw.Geometry.gPoint(4.1837, 5.9294)
        vp.ViewSize = 2.2468
        If Not (lay Is Nothing) Then lay.Entities.AddItem(vp)

        'And add some texts for fun :)
        text = New VectorDraw.Professional.vdFigures.vdText()
        text.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        text.setDocumentDefaults()
        text.InsertionPoint = New VectorDraw.Geometry.gPoint(80D, 165D)
        text.TextString = "WORLD"
        text.Height = 10.0
        If Not (lay Is Nothing) Then lay.Entities.AddItem(text)

        text = New VectorDraw.Professional.vdFigures.vdText()
        text.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        text.setDocumentDefaults()
        text.InsertionPoint = New VectorDraw.Geometry.gPoint(15D, 120D)
        text.TextString = "AUSTRALIA"
        text.Height = 10.0
        If Not (lay Is Nothing) Then lay.Entities.AddItem(text)

        text = New VectorDraw.Professional.vdFigures.vdText()
        text.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        text.setDocumentDefaults()
        text.InsertionPoint = New VectorDraw.Geometry.gPoint(133D, 120D)
        text.TextString = "AFRICA"
        text.Height = 10.0
        If Not (lay Is Nothing) Then lay.Entities.AddItem(text)

        MessageBox.Show("By Default you can double click the viewport entity to enter inside and pan or zoom")
    End Sub
    Private Sub OpenLayoutsDialog()
        VdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.LayoutTab, True)
        MessageBox.Show("The Layout tab has been activated.You can navigate and see the added viewports at the bottom left of the application.")
    End Sub
#End Region

#Region "Lights"
    Private Sub AddLights()
        Dim light As VectorDraw.Professional.vdFigures.vdLight = New VectorDraw.Professional.vdFigures.vdLight()
        light.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        light.setDocumentDefaults()
        light.TypeOfLight = VectorDraw.Professional.vdFigures.LightType.Spot
        light.Position = New VectorDraw.Geometry.gPoint(40D, 0D, 40D)
        light.Intensity = VectorDraw.Professional.vdFigures.vdLight.LightIntensity.Low
        light.color = Color.Red
        light.SpotDirection = New VectorDraw.Geometry.Vector(New VectorDraw.Geometry.gPoint(40D, 0D, 40D), New VectorDraw.Geometry.gPoint())
        light.SpotAngle = 30D
        light.Enable = True
        light.VisibleIn2d = True
        light.Name = "RED"
        VdFramedControl1.BaseControl.ActiveDocument.Lights.AddItem(light)

        light = New VectorDraw.Professional.vdFigures.vdLight()
        light.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        light.setDocumentDefaults()
        light.TypeOfLight = VectorDraw.Professional.vdFigures.LightType.Spot
        light.Position = New VectorDraw.Geometry.gPoint(-40D, 0D, 40D)
        light.Intensity = VectorDraw.Professional.vdFigures.vdLight.LightIntensity.Low
        light.color = Color.Blue
        light.SpotDirection = New VectorDraw.Geometry.Vector(New VectorDraw.Geometry.gPoint(-40D, 0D, 40D), New VectorDraw.Geometry.gPoint())
        light.SpotAngle = 30D
        light.Enable = True
        light.VisibleIn2d = True
        light.Name = "BLUE"
        VdFramedControl1.BaseControl.ActiveDocument.Lights.AddItem(light)

        light = New VectorDraw.Professional.vdFigures.vdLight()
        light.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        light.setDocumentDefaults()
        light.TypeOfLight = VectorDraw.Professional.vdFigures.LightType.Spot
        light.Position = New VectorDraw.Geometry.gPoint(0D, 0D, -60D)
        light.Intensity = VectorDraw.Professional.vdFigures.vdLight.LightIntensity.Low
        light.color = Color.Green
        light.SpotDirection = New VectorDraw.Geometry.Vector(New VectorDraw.Geometry.gPoint(0D, 0D, -60D), New VectorDraw.Geometry.gPoint())
        light.SpotAngle = 30D
        light.Enable = True
        light.VisibleIn2d = True
        light.Name = "GREEN"
        VdFramedControl1.BaseControl.ActiveDocument.Lights.AddItem(light)

        light = VdFramedControl1.BaseControl.ActiveDocument.Lights.Default
        light.Enable = False

        MessageBox.Show("We added 3 lights and disable the Default light for better results.Click the next button to see a sphere lighted with these lights.")
    End Sub
    Private Sub Add3DEntities()
        'Do not add the sphere if it is already added
        If VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.Count > 0 Then
            Return
        End If
        'Set the render mode to Render to activate the lights
        VdFramedControl1.BaseControl.ActiveDocument.Model.RenderMode = VectorDraw.Render.vdRender.Mode.Render

        'We disable redraw because the cmd commands make a redraw that we don't want.We will redraw our scene later.
        VdFramedControl1.BaseControl.ActiveDocument.DisableRedraw = True
        'We add a sphere to show the effect of the lights.
        VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdSphere(New VectorDraw.Geometry.gPoint(), 25.0, 25, 25)
        VdFramedControl1.BaseControl.ActiveDocument.DisableRedraw = False
        'Zoom and redraw.
        VdFramedControl1.BaseControl.ActiveDocument.Model.ZoomWindow(New VectorDraw.Geometry.gPoint(-40D, -40D), New VectorDraw.Geometry.gPoint(40D, 40D))
        VdFramedControl1.BaseControl.ActiveDocument.Redraw(True)
    End Sub
    Private Sub OpenLightsDialog()
        VectorDraw.Professional.Dialogs.frmLightManager.Show(VdFramedControl1.BaseControl.ActiveDocument)
    End Sub
#End Region

#Region "Multilines"
    Private Sub AddMultilineStyles()

        'Create a vdMultilineStyle object with 4 Element lines
        Dim mline As VectorDraw.Professional.vdPrimaries.vdMultilineStyle = New VectorDraw.Professional.vdPrimaries.vdMultilineStyle(VdFramedControl1.BaseControl.ActiveDocument, "Test1")

        '1st Element
        Dim elem As VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement = New VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement()
        elem.ElementColor.ColorIndex = 0
        elem.ElementLineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_120
        elem.Offset = 1.0
        mline.Elements.Add(elem)

        'Second Element
        elem = New VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement()
        elem.ElementColor.ColorIndex = 1
        elem.ElementLineType = VdFramedControl1.BaseControl.ActiveDocument.LineTypes.FindName("DASHDOTDOT0")
        elem.Offset = 0.25
        mline.Elements.Add(elem)

        'Third Element
        elem = New VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement()
        elem.ElementColor.ColorIndex = 1
        elem.ElementLineType = VdFramedControl1.BaseControl.ActiveDocument.LineTypes.FindName("DASHDOTDOT0")
        elem.Offset = -0.25
        mline.Elements.Add(elem)

        'Fourth Element
        elem = New VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement()
        elem.ElementColor.ColorIndex = 0
        elem.Offset = -1.0
        mline.Elements.Add(elem)

        'Other MultilineStyle properties
        mline.Flags = mline.Flags Or VectorDraw.Professional.Constants.VdMultilineFlags.Start_Outer_Arc
        mline.Flags = mline.Flags Or VectorDraw.Professional.Constants.VdMultilineFlags.End_Outer_Arc
        mline.Update()

        'Add the MultilineStyle to the Document's collection
        VdFramedControl1.BaseControl.ActiveDocument.MultilineStyles.AddItem(mline)

        'Create a Second MultilineStyle with just 3 elements
        mline = New VectorDraw.Professional.vdPrimaries.vdMultilineStyle(VdFramedControl1.BaseControl.ActiveDocument, "Test2")

        '1st Element
        elem = New VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement()
        elem.ElementColor.ColorIndex = 3
        elem.Offset = 1.0
        mline.Elements.Add(elem)

        'Second Element
        elem = New VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement()
        elem.ElementColor.ColorIndex = 2
        elem.Offset = -1.0
        mline.Elements.Add(elem)

        'Second Element
        elem = New VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement()
        elem.ElementColor.ColorIndex = 0
        elem.Offset = -0.5
        mline.Elements.Add(elem)

        'Other MultilineStyle properties
        mline.Flags = mline.Flags Or VectorDraw.Professional.Constants.VdMultilineFlags.DisplayMiters
        mline.Flags = mline.Flags Or VectorDraw.Professional.Constants.VdMultilineFlags.Fill_on
        mline.FillColor.ColorIndex = 4
        mline.Update()

        'Add the MultilineStyle to the Document's collection
        VdFramedControl1.BaseControl.ActiveDocument.MultilineStyles.AddItem(mline)

        MessageBox.Show("We added 2 Multiline Styles to the Document.")
    End Sub
    Private Sub AddMultilines()

        If (VdFramedControl1.BaseControl.ActiveDocument.MultilineStyles.FindName("Test1") IsNot Nothing) Then

            'Create a vdMultiline object
            Dim line As VectorDraw.Professional.vdFigures.vdMultiline = New VectorDraw.Professional.vdFigures.vdMultiline(VdFramedControl1.BaseControl.ActiveDocument)
            line.VertexList.Add(New VectorDraw.Geometry.Vertex(63, 5, 0))
            line.VertexList.Add(New VectorDraw.Geometry.Vertex(80, 25, 0))
            line.VertexList.Add(New VectorDraw.Geometry.Vertex(110, 25, 0))
            line.VertexList.Add(New VectorDraw.Geometry.Vertex(127, 5, 0))
            line.ScaleFactor = 10.0

            line.MultilineStyle = VdFramedControl1.BaseControl.ActiveDocument.MultilineStyles.FindName("Test1")
            'The vdMultiline has to be added to the document.
            VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(line)

            'Create a Second Multiline
            line = New VectorDraw.Professional.vdFigures.vdMultiline(VdFramedControl1.BaseControl.ActiveDocument)
            line.VertexList.Add(New VectorDraw.Geometry.Vertex(63, 50, 0))
            line.VertexList.Add(New VectorDraw.Geometry.Vertex(63, 75, 0))
            line.VertexList.Add(New VectorDraw.Geometry.Vertex(110, 75, 0))
            line.VertexList.Add(New VectorDraw.Geometry.Vertex(110, 50, 0))
            line.Flags = line.Flags Or VectorDraw.Professional.Constants.VdConstMultilineFlags.IsClosed
            line.ScaleFactor = 5.0

            line.MultilineStyle = VdFramedControl1.BaseControl.ActiveDocument.MultilineStyles.FindName("Test2")
            'The vdMultiline has to be added to the document.
            VdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(line)

            'Zoom extends and redraw to see the changes.
            VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ZoomExtents()
            VdFramedControl1.BaseControl.ActiveDocument.Redraw(True)

        Else

            MessageBox.Show("Please add Multiline Styles to the collection by pressing the proper button")
        End If
    End Sub
    Private Sub OpenMultilinesDialog()

        'Call the Multilines styles dialog.
        Dim res As DialogResult = VectorDraw.Professional.Dialogs.frmMultilineStyles.Show(VdFramedControl1.BaseControl.ActiveDocument)
    End Sub
#End Region

End Class

Public Class MyObject
    Implements VectorDraw.Serialize.IvdProxySerializer
    ' Methods
    Public Sub New()
        Me.mDouble1 = 1
        Me.mText1 = "one"
    End Sub

    Public Sub New(ByVal dbl As Double, ByVal str As String)
        Me.mDouble1 = 1
        Me.mText1 = "one"
        Me.mDouble1 = dbl
        Me.mText1 = str
    End Sub

    Public Overridable Function DeSerialize(ByVal deserializer As DeSerializer, ByVal fieldname As String, ByVal value As Object) As Boolean Implements VectorDraw.Serialize.IvdProxySerializer.DeSerialize
        If (fieldname = "Double1") Then
            Me.mDouble1 = CDbl(value)
        ElseIf (fieldname = "Text1") Then
            Me.mText1 = CStr(value)
        Else
            Return False
        End If
        Return True
    End Function

    Public Overridable Sub Serialize(ByVal serializer As Serializer) Implements IvdProxySerializer.Serialize
        serializer.Serialize(Me.mText1, "Text1")
        serializer.Serialize(Me.mDouble1, "Double1")
    End Sub

    Public Overrides Function ToString() As String
        Return ("MyObject with value " & Me.mDouble1.ToString & " " & Me.mText1)
    End Function


    ' Properties
    Public Property Double1() As Double
        Get
            Return Me.mDouble1
        End Get
        Set(ByVal value As Double)
            Me.mDouble1 = value
        End Set
    End Property

    Public Property Text1() As String
        Get
            Return Me.mText1
        End Get
        Set(ByVal value As String)
            Me.mText1 = value
        End Set
    End Property


    ' Fields
    Private mDouble1 As Double
    Private mText1 As String
End Class

