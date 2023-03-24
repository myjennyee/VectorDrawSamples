Public Class Form1

    'Description:

    'In this example is demonstrated how someone can use VectorDraw in order to present statistical information using charts. How, by using simple vdObjects,
    'more complex shapes and charts can be created. How to convert 2D objects to 3D or combine 2D objects to make 3D shapes. In more detail, this example demonstrates
    'the use of the vdPolyLine, the vdGroundSurface, the vdPolyFace, among others and how they can be used to create 3D displays. Furthermore is demonstrated
    'how to insert and modify images into a Vector Draw control. Everything mentioned above, are used in order to create 2D and 3D Graphic Charts and geometrical shapes.

    'Use:

    'While running the example, you'll notice a Tabbed panel. Every panel is titled after a specific chart. When selecting a Tab, the described chart is drawn in
    'the VectorDraw BaseControl. The values of the Chart are being extracted from the DataGrid on the right of the Panel. When selecting a tab, default values are
    'inserted in the DataGrid, but if desired, the DataGrid values can be changed. By pressing the "Redraw Chart" Button, a new Chart will be drawn using the new
    'values. Finally, there is the "3D Chart" CheckBox that, as its name states, when checked the Chart drawn is in 3D.

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BaseControl.ActiveDocument.ActiveLayOut.BkColorEx = Color.Gainsboro
        BaseControl.ActiveDocument.ShowUCSAxis = False
        BaseControl.ActiveDocument.EnableAutoGripOn = False
        'This method shows all the objects of the ActiveDocument in RENDER mode.
        BaseControl.ActiveDocument.CommandAction.View3D("RENDER")
        DataGrid.RowCount = 9
        DataGrid("title", 0).Value = "Label 1"
        DataGrid("percentage", 0).Value = 15.3
        DataGrid("title", 1).Value = "Label 2"
        DataGrid("percentage", 1).Value = 8.9
        DataGrid("title", 2).Value = "Label 3"
        DataGrid("percentage", 2).Value = 25.4
        DataGrid("title", 3).Value = "Label 4"
        DataGrid("percentage", 3).Value = 2.6
        DataGrid("title", 4).Value = "Label 5"
        DataGrid("percentage", 4).Value = 15.8
        DataGrid("title", 5).Value = "Label 6"
        DataGrid("percentage", 5).Value = 8.9
        DataGrid("title", 6).Value = "Label 7"
        DataGrid("percentage", 6).Value = 19.3
        DataGrid("title", 7).Value = "Label 8"
        DataGrid("percentage", 7).Value = 3.8
        DrawPieChart()
        richTextBox1.Text = "Pie Chart \n This chart is created part by part. Every part represents a portion of the total 100%. For every part, we use a closed polyline with five vertexes (the last vertex concurs with the first one). The angle of the polyline is calculated by the percentage a chart part is given. For example, a 50% chart part would be 180 degrees. After the polyline is created we convert it into a vdPolyFace object and either add thickness or not (we add thickness to present a 3D chart)."
        richTextBox2.Text = "Bar Chart \n The Bar Chart again is used to represent percentages. In this chart, we create a VDRect object with the solid fill mode of the HatchProperties object (this fills the VDrect object with a solid color instead of just drawing the outline). In case we want a 2D chart, we add the VDRect object to the Entities of the Document. If a 3D chart is needed, we convert the VDRect object to a VDPolyface object with the Generate3dPathSection method of the VDPolyface object and add the VDPolyface instead."
        richTextBox3.Text = "Line Chart \n This chart is created in three steps. First we create the X and  Y axes. Two VDLine objects in 2D mode, two jpg images in 3D mode. After we insert the axes, we create small circles in the appropriate spots, to represent the points of the values inserted in our DataGrid. Finally, we create a VDPolyline object that connects all the points. In 3D mode, we don't insert the points rather just the VDPolyline object and give it an one point thickness."
        richTextBox4.Text = "Bars Chart \n The Bars Chart creates the X and Y axes the same way the Line Chart does. Once the axes are there, it uses VDRect objects to represent the values given by the DataGrid. The VDRect objects have a solid color using the VdFillModeSolid mode of the FillMode of the VDHatchProperties object. In 3D mode, we simply add Thickness to the VDRect object."
        richTextBox5.Text = "Wave Chart \n This chart demonstrates how a user can visually display coordinates that are referring to the three dimensional axes system, for example the ground altitude of a part of the earth, or  coordinates that represent the values of a sound frequency as time passes. This chart is very easily created by using the VDGroundSurface object, by adding a list of points."
        richTextBox6.Text = "Horizontal Bars Chart \n In this Chart we use the same method (Generate3dPathSection as used in the Bar Chart) of the VDPolyFace object, using a circle in order to create a 3D cylinder. The length of the cylinder represents the value given in the DataGrid. The 3D object is used, even if the chart is 2D in its essence, to offer a nice aesthetic touch."
        'By using this method of the Base Control, we change the Mouse Pointer to the pointer of the cursor1.cur file.
        'BaseControl.SetCustomMousePointer(New System.Windows.Forms.Cursor("cursor1.cur"))
        BaseControl.ActiveDocument.Redraw(False)
    End Sub
    'This event handler is triggered whenever we change the active Tab.
    Private Sub tabControl1_TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabControl1.SelectedIndexChanged
        Dim tc As TabControl = DirectCast(sender, TabControl)
        'We insert random values into the DataGrid.
        If tc.SelectedTab.Name.Equals("tabPage3") Or tc.SelectedTab.Name.Equals("tabPage4") Or tc.SelectedTab.Name.Equals("tabPage6") Then

            DataGrid.ColumnCount = 2
            DataGrid.RowCount = 10
            DataGrid.Columns(0).HeaderText = "Title"
            DataGrid.Columns(0).Width = 150
            DataGrid.Columns(1).HeaderText = "Value"
            DataGrid.Columns(1).Width = 100
            Dim randomise As Random = New Random()
            Dim i As Integer
            For i = 0 To 9
                Dim value As Double = randomise.Next(40, 100) * 0.1
                DataGrid(0, i).Value = "Label " + i.ToString() + " - " + value.ToString()
                DataGrid(1, i).Value = value
            Next i
            'Percentages are inserted into the Datagrid. The sum of those values is 100.
        ElseIf tc.SelectedTab.Name.Equals("tabPage1") Or tc.SelectedTab.Name.Equals("tabPage2") Then

            DataGrid.ColumnCount = 2
            DataGrid.RowCount = 9
            DataGrid.Columns(0).HeaderText = "Title"
            DataGrid.Columns(0).Width = 150
            DataGrid.Columns(1).HeaderText = "Percentage"
            DataGrid.Columns(1).Width = 100
            DataGrid("title", 0).Value = "Label 1"
            DataGrid("percentage", 0).Value = 15.3
            DataGrid("title", 1).Value = "Label 2 "
            DataGrid("percentage", 1).Value = 8.9
            DataGrid("title", 2).Value = "Label 3"
            DataGrid("percentage", 2).Value = 25.4
            DataGrid("title", 3).Value = "Label 4"
            DataGrid("percentage", 3).Value = 2.6
            DataGrid("title", 4).Value = "Label 5"
            DataGrid("percentage", 4).Value = 15.8
            DataGrid("title", 5).Value = "Label 6"
            DataGrid("percentage", 5).Value = 8.9
            DataGrid("title", 6).Value = "Label 7"
            DataGrid("percentage", 6).Value = 19.3
            DataGrid("title", 7).Value = "Label 8"
            DataGrid("percentage", 7).Value = 3.8

            'Values that follow the pattern of the Cos and Sin functions are inserted in the DataGrid.
        ElseIf tc.SelectedTab.Name.Equals("tabPage5") Then
            Dim i As Integer
            DataGrid.ColumnCount = 10
            DataGrid.RowCount = 101
            For i = 1 To 10

                DataGrid.Columns(i - 1).HeaderText = "z" + i.ToString()
                DataGrid.Columns(i - 1).Width = 60
                Dim j As Integer
                For j = 1 To 100
                    Dim value As Double = Math.Cos(j * 3.14 * 100) * (1 - (j * 0.01))
                    DataGrid(i - 1, j - 1).Value = 2 + value * Math.Cos(i * 0.628)
                Next j
            Next i
        End If
        'Depending on the Tab that is selected, the appropriate Chart is drawn.
        Select Case tc.SelectedTab.Name
            Case "tabPage1"
                DrawPieChart()
                chart3DCheckBox.Enabled = True
                Exit Select
            Case "tabPage2"
                DrawBarChart()
                chart3DCheckBox.Enabled = True
                Exit Select
            Case "tabPage3"
                DrawLineChart()
                chart3DCheckBox.Enabled = True
                Exit Select
            Case "tabPage4"
                DrawBarsChart()
                chart3DCheckBox.Enabled = True
                Exit Select
            Case "tabPage5"
                DrawWaveChart()
                chart3DCheckBox.Enabled = False
                Exit Select
            Case "tabPage6"
                DrawHorBarChart()
                chart3DCheckBox.Enabled = False
                Exit Select
            Case Else
                Exit Select

        End Select
    End Sub
    'Draws the appropriate Chart, according to the selected Tab.
    Private Sub createChart_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles createChart.Click
        'Depending on the Tab that is selected, the appropriate Chart is drawn.
        Select Case tabControl1.SelectedTab.Name
            Case "tabPage1"
                DrawPieChart()
                chart3DCheckBox.Enabled = True
                Exit Select
            Case "tabPage2"
                DrawBarChart()
                chart3DCheckBox.Enabled = True
                Exit Select
            Case "tabPage3"
                DrawLineChart()
                chart3DCheckBox.Enabled = True
                Exit Select
            Case "tabPage4"
                DrawBarsChart()
                chart3DCheckBox.Enabled = True
                Exit Select
            Case "tabPage5"
                DrawWaveChart()
                chart3DCheckBox.Enabled = False
                Exit Select
            Case "tabPage6"
                DrawHorBarChart()
                chart3DCheckBox.Enabled = False
                Exit Select
            Case Else
                Exit Select
        End Select
    End Sub


#Region "Pie Chart"
    'This method is used to convert the percentages to rads in order to create the vdPolyLine object.
    Private Function PercToRads(ByVal percentage As Double) As Double
        Return (360 * percentage / 100 * 0.01744)
    End Function
    'This method creates a part of a circle, the angle of the part will span from the angleStart parameter to the angleEnd one. The color of the part
    'is defined by the three r, g, b parameters, representing the three values of the RGB color map. Finally, it places the title of the Chart part next
    'to the part.
    Private Sub CreatePiePart(ByVal angleStart As Double, ByVal angleEnd As Double, ByVal r As Integer, ByVal g As Integer, ByVal b As Integer, ByVal title As String)
        Dim Text As VectorDraw.Professional.vdFigures.vdMText = New VectorDraw.Professional.vdFigures.vdMText()
        Text.SetUnRegisterDocument(BaseControl.ActiveDocument)
        Text.setDocumentDefaults()
        Text.TextString = title
        Text.Height = 0.5
        'The vdMText object is colored slightly darker than the chart part in order to be easily readable.
        Text.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.FromArgb(r - 40, g - 40, b - 40))
        Text.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        Text.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        'The InsertionPoint of the vdMText is located on the bisector of the Pie Chart part, thus being above the center of the part's circumference.
        Text.InsertionPoint = New VectorDraw.Geometry.gPoint(Math.Cos((angleEnd - angleStart) / 2 + angleStart) * 4.5, Math.Sin((angleEnd - angleStart) / 2 + angleStart) * 4.5, 3)
        Text.Update()

        Dim polyline As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline()
        polyline.SetUnRegisterDocument(BaseControl.ActiveDocument)
        polyline.setDocumentDefaults()
        'The vdPolyLine object we are using to create the Pie Chart part has 5 Vertexes in its VertexList.
        polyline.VertexList.Add(Math.Cos(angleStart), Math.Sin(angleStart), 0, 0)
        polyline.VertexList.Add(0, 0, 0, 0)
        'The bulge of this Vertex is calculated in order to be the same as of a circle would. You can fine more info about the bulge calculation in the 
        '.chm Help file.
        polyline.VertexList.Add(Math.Cos(angleEnd), Math.Sin(angleEnd), 0, -Math.Tan((angleEnd - angleStart) / 4 / 2))
        'This Vertex is located in the middle between of the part's circumference. This insures that the bulge of the vdPolyLine will be correct.
        polyline.VertexList.Add(Math.Cos((angleEnd - angleStart) / 2 + angleStart), Math.Sin((angleEnd - angleStart) / 2 + angleStart), 0, -Math.Tan((angleEnd - angleStart) / 4 / 2))
        'The first and last Vertex concur.
        polyline.VertexList.Add(Math.Cos(angleStart), Math.Sin(angleStart), 0, 0)
        Dim c As Color = Color.FromArgb(r, g, b)
        polyline.PenColor = New VectorDraw.Professional.vdObjects.vdColor(c)
        polyline.Update()

        Dim mat As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix()
        mat.ScaleMatrix(3, 3, 0)
        mat.TranslateMatrix(Math.Cos((angleEnd - angleStart) / 2 + angleStart) / 5, Math.Sin((angleEnd - angleStart) / 2 + angleStart) / 5, 0)
        'If the chart3DCheckBox is checked, a 3D Chart will be created.
        If Not chart3DCheckBox.Checked Then
            polyline.Thickness = 0
            polyline.Transformby(mat)
            'Using the method of the CommandAction a vdPolyFace object is created and inserted in the Entities of the ActiveDocument, without actually
            ' adding it. The vdPolyLine will not be added.
            BaseControl.ActiveDocument.CommandAction.CmdPlineToMesh(polyline, 0.0, "y")
        Else
            polyline.Thickness = 1
            mat.RotateXMatrix(-0.35)
            mat.RotateYMatrix(-0.2)
            polyline.Transformby(mat)
            'Using the method of the CommandAction a vdPolyFace object is created and inserted in the Entities of the ActiveDocument, without actually
            ' adding it. The vdPolyLine will not be added.
            BaseControl.ActiveDocument.CommandAction.CmdPlineToMesh(polyline, 1.0, "y")
        End If
        'After the Pie Chart part is inserted as a vdPolyFace object, only the title need to be added.
        BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(Text)
    End Sub
    'This method is used to create all the needed Pie Chart parts so that a whole Pie Chart will be designed.
    Private Sub MakePie(ByVal title As String(), ByVal percentage As Double())
        Dim pieParts As Integer = percentage.Length
        Dim totalRands As Double = 0
        Dim randomize As Random = New Random()
        'This loop is used to create a random color in order to draw our Pie Chart part using that.
        Dim i As Integer
        For i = 0 To pieParts - 1

            Dim randomR As Integer = DirectCast(randomize.Next(41, 200), Integer)
            Dim randomG As Integer = DirectCast(randomize.Next(41, 200), Integer)
            Dim randomB As Integer = DirectCast(randomize.Next(41, 200), Integer)
            CreatePiePart(totalRands, totalRands + PercToRads(percentage(i)), randomR, randomG, randomB, title(i) + vbCrLf + percentage(i).ToString() + "%")
            totalRands += PercToRads(percentage(i))
        Next i
    End Sub
    'This method creates a new Document to the BaseControl, accesses the data in the DataGrid and calls the method to create the Chart.
    Private Sub DrawPieChart()
        BaseControl.ActiveDocument.[New]()
        BaseControl.ActiveDocument.ActiveLayOut.BkColorEx = Color.Gainsboro
        BaseControl.ActiveDocument.ShowUCSAxis = False
        BaseControl.ActiveDocument.CommandAction.View3D("RENDER")
        Dim piePieces As Integer = DataGrid.RowCount
        piePieces -= 1
        Dim percentages(0 To piePieces - 1) As Double
        Dim titles(0 To piePieces - 1) As String
        Dim i As Integer
        For i = 0 To piePieces - 1
            Try
                percentages(i) = Double.Parse(DataGrid(1, i).Value.ToString())
            Catch
                percentages(i) = 0
            End Try
            titles(i) = DataGrid(0, i).Value.ToString()
        Next i
        Dim mat As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix()
        BaseControl.ActiveDocument.Model.World2ViewMatrix = mat
        MakePie(titles, percentages)
        BaseControl.ActiveDocument.ActiveLayOut.ZoomExtents()
        BaseControl.ActiveDocument.Redraw(False)
    End Sub
#End Region
#Region "Bar Chart"
    'This method creates a part of a bar, the height of the part will be relative to the percentage it represents. The color of the part
    'is defined by the three r, g, b parameters, representing the three values of the RGB color map. Finally, it places the title of the Chart part next
    'to the part, to the left or the right, depending on the left parameter.
    Private Sub CreateBarPart(ByVal totalPercentage As Double, ByVal percentage As Double, ByVal title As String, ByVal r As Integer, ByVal g As Integer, ByVal b As Integer, ByVal left As Boolean)
        Dim rect As VectorDraw.Professional.vdFigures.vdRect = New VectorDraw.Professional.vdFigures.vdRect()
        rect.SetUnRegisterDocument(BaseControl.ActiveDocument)
        rect.setDocumentDefaults()
        rect.InsertionPoint = New VectorDraw.Geometry.gPoint(-1, -4.5 + totalPercentage * 0.1)
        rect.Height = percentage * 0.1
        rect.Width = 2
        rect.HatchProperties = New VectorDraw.Professional.vdObjects.vdHatchProperties()
        'HatchProperties.FillMode defines the way the vdRect object will be filled. The VdFillModeSolid selection will fill it with a solid color.
        rect.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid
        rect.HatchProperties.FillColor = New VectorDraw.Professional.vdObjects.vdColor(Color.FromArgb(r, g, b))
        rect.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Black)

        Dim Text As VectorDraw.Professional.vdFigures.vdMText = New VectorDraw.Professional.vdFigures.vdMText()
        Text.SetUnRegisterDocument(BaseControl.ActiveDocument)
        Text.setDocumentDefaults()
        Text.TextString = title
        Text.Height = 0.4
        Text.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.FromArgb(r - 30, g - 30, b - 30))
        Text.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        'This condition makes sure the title of the part will be placed on the left and right of the Bar Chart alternately.
        If left Then

            Text.InsertionPoint = New VectorDraw.Geometry.gPoint(-1.5, rect.InsertionPoint.y + rect.Height / 2)
            Text.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorRight

        Else

            Text.InsertionPoint = New VectorDraw.Geometry.gPoint(1.5, rect.InsertionPoint.y + rect.Height / 2)
            Text.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorLeft
        End If
        Text.Update()
        'If the chart3dCeckBox is checked, we are drawing a 3D chart
        If chart3DCheckBox.Checked = True Then
            Dim face As VectorDraw.Professional.vdFigures.vdPolyface = New VectorDraw.Professional.vdFigures.vdPolyface()
            face.SetUnRegisterDocument(BaseControl.ActiveDocument)
            face.setDocumentDefaults()
            face.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.FromArgb(r, g, b))

            Dim line As VectorDraw.Professional.vdFigures.vdLine = New VectorDraw.Professional.vdFigures.vdLine()
            line.EndPoint = New VectorDraw.Geometry.gPoint(0, 0, -2)
            'Using the method of the CommandAction a vdPolyFace object is created and inserted in the Entities of the ActiveDocument, without actually
            ' adding it. The vdRect will not be added.
            face.Generate3dPathSection(line, rect, New VectorDraw.Geometry.gPoint(), 0, 1)
            'Using the Matrix object (mat), the vdPolyFace can be rotated accordingly.
            Dim mat As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix()
            mat.RotateYMatrix(-0.2)
            mat.RotateXMatrix(0.1)
            face.Transformby(mat)
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(face)
        Else
            'If a 2D chart is being drawn, we insert the vdRect object instead.
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(rect)
        End If
        BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(Text)
    End Sub
    'This method is used to create all the needed Bar Chart parts so that a whole Bar Chart will be designed.
    Private Sub MakeBar(ByVal titles As String(), ByVal percentages As Double())
        Dim barParts As Integer = percentages.Length
        Dim totalPercentage As Double = 0
        Dim randomize As Random = New Random()
        'This loop is used to create a random color in order to draw the Bar Chart part using that.
        Dim i As Integer
        For i = 0 To barParts - 1
            Dim randomR As Integer = DirectCast(randomize.Next(31, 200), Integer)
            Dim randomG As Integer = DirectCast(randomize.Next(31, 200), Integer)
            Dim randomB As Integer = DirectCast(randomize.Next(31, 200), Integer)
            If i Mod 2 = 0 Then
                CreateBarPart(totalPercentage, percentages(i), titles(i) + vbCrLf + percentages(i).ToString() + "%", randomR, randomG, randomB, True)
            Else
                CreateBarPart(totalPercentage, percentages(i), titles(i) + vbCrLf + percentages(i).ToString() + "%", randomR, randomG, randomB, False)
            End If
            totalPercentage += percentages(i)
        Next i
    End Sub
    'This method creates a new Document to the BaseControl, accesses the data in the DataGrid and calls the method to create the Chart.
    Private Sub DrawBarChart()
        BaseControl.ActiveDocument.[New]()
        BaseControl.ActiveDocument.ActiveLayOut.BkColorEx = Color.Gainsboro
        BaseControl.ActiveDocument.ShowUCSAxis = False
        BaseControl.ActiveDocument.CommandAction.View3D("RENDER")
        Dim barPieces As Integer = DataGrid.RowCount
        barPieces -= 1
        Dim percentages(0 To barPieces - 1) As Double
        Dim titles(0 To barPieces - 1) As String
        Dim i As Integer
        For i = 0 To barPieces - 1
            Try
                percentages(i) = Double.Parse(DataGrid(1, i).Value.ToString())
            Catch
                percentages(i) = 0
            End Try
            titles(i) = DataGrid(0, i).Value.ToString()
        Next i
        Dim mat As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix()
        BaseControl.ActiveDocument.Model.World2ViewMatrix = mat
        MakeBar(titles, percentages)
        BaseControl.ActiveDocument.ActiveLayOut.ZoomExtents()
        BaseControl.ActiveDocument.Redraw(False)
    End Sub
#End Region
#Region "Line Chart"
    'This method is used to create the X and Y axes the Line Chart will be created upon.
    Private Sub CreateLineAxis(ByVal labelX As String, ByVal labelY As String, ByVal maxValue As Double)
        Dim xAxis As VectorDraw.Professional.vdFigures.vdLine = New VectorDraw.Professional.vdFigures.vdLine()
        xAxis.SetUnRegisterDocument(BaseControl.ActiveDocument)
        xAxis.setDocumentDefaults()
        xAxis.StartPoint = New VectorDraw.Geometry.gPoint(-0.5, 0, -1)
        xAxis.EndPoint = New VectorDraw.Geometry.gPoint(10, 0, -1)
        xAxis.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Gray)
        Dim yAxis As VectorDraw.Professional.vdFigures.vdLine = New VectorDraw.Professional.vdFigures.vdLine()
        yAxis.SetUnRegisterDocument(BaseControl.ActiveDocument)
        yAxis.setDocumentDefaults()
        yAxis.StartPoint = New VectorDraw.Geometry.gPoint(0, -0.5, -1)
        yAxis.EndPoint = New VectorDraw.Geometry.gPoint(0, 4.95, -1)
        yAxis.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Gray)
        Dim textX As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText()
        textX.SetUnRegisterDocument(BaseControl.ActiveDocument)
        textX.setDocumentDefaults()
        textX.TextString = labelX
        textX.Height = 0.3
        textX.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Black)
        textX.InsertionPoint = New VectorDraw.Geometry.gPoint(xAxis.EndPoint.x, yAxis.StartPoint.y, -1)
        Dim textY As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText()
        textY.SetUnRegisterDocument(BaseControl.ActiveDocument)
        textY.setDocumentDefaults()
        textY.TextString = labelY
        textY.Height = 0.3
        textY.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Black)
        textY.InsertionPoint = New VectorDraw.Geometry.gPoint(xAxis.StartPoint.x, yAxis.EndPoint.y + 0.5, -1)
        'If the chart3DCheckBox is checked, we are drawing a 3D chart.
        If chart3DCheckBox.Checked Then
            xAxis.Thickness = 3
            xAxis.StartPoint = New VectorDraw.Geometry.gPoint(0, 0, -1)
            'Since the chart is in 3D, the Y axis will be replaced with an image and the X axis will be thickened.
            yAxis.Deleted = True
            'A backround image will be added to be easier to read the chart in 3D.
            Dim img As VectorDraw.Professional.vdPrimaries.vdImageDef = New VectorDraw.Professional.vdPrimaries.vdImageDef()
            img.FileName = "line_chart_backround_with_lines.jpg"
            img.Name = "backroundImage"
            'When using an image in Vector Draw, we need to add it to the Images of the ActiveDocument.
            BaseControl.ActiveDocument.Images.AddItem(img)
            Dim imageBack As VectorDraw.Professional.vdFigures.vdImage = New VectorDraw.Professional.vdFigures.vdImage()
            imageBack.SetUnRegisterDocument(BaseControl.ActiveDocument)
            imageBack.setDocumentDefaults()
            imageBack.ImageDefinition = img
            imageBack.InsertionPoint = New VectorDraw.Geometry.gPoint(0, 0, -1)
            imageBack.Height = 4.95
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(imageBack)
            Dim img2 As VectorDraw.Professional.vdPrimaries.vdImageDef = New VectorDraw.Professional.vdPrimaries.vdImageDef()
            img2.FileName = "line_chart_Y_with_lines.jpg"
            img2.Name = "yAxisImage"
            BaseControl.ActiveDocument.Images.AddItem(img2)
            Dim imageY As VectorDraw.Professional.vdFigures.vdImage = New VectorDraw.Professional.vdFigures.vdImage()
            imageY.SetUnRegisterDocument(BaseControl.ActiveDocument)
            imageY.setDocumentDefaults()
            imageY.ImageDefinition = img2
            imageY.InsertionPoint = New VectorDraw.Geometry.gPoint(0, 0, 0)
            imageY.Height = 4.95
            Dim mat As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix()
            mat.RotateYMatrix(3.15 / 2)
            mat.TranslateMatrix(0, 0, 2)
            'Be default the image is inserted in the level created by the X and Y axes, so we need to modify it's rotation by using a Matrix object.
            imageY.Transformby(mat)
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(imageY)
            'In order the 3D effect to be visible, the chart must be viewd from a diagonal angle. Using the Matrix object (mat) the World View Matrix is
            'rotated accordingly.
            mat = New VectorDraw.Geometry.Matrix()
            mat.RotateYMatrix(-0.4)
            mat.RotateXMatrix(0.2)
            BaseControl.ActiveDocument.Model.World2ViewMatrix = mat
        End If
        'This loop is used to place the values on the Y axis. A slightly higher value of the max value given by the DataGrid is used as the highest
        'point on the Y axis. The bottom is 0, but someone could easily extend the value span to the other quadrants of the Cartesian system.
        Dim i As Integer
        For i = 0 To 11
            Dim txt As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText()
            txt.SetUnRegisterDocument(BaseControl.ActiveDocument)
            txt.setDocumentDefaults()
            txt.Height = 0.2
            txt.TextString = (maxValue * i / 10).ToString()
            txt.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Black)
            If i = 0 And Not chart3DCheckBox.Checked Then
                'This condition makes sure the value 0 will be places to the lowest, left corner of the axes we drew.
                txt.InsertionPoint = New VectorDraw.Geometry.gPoint(-0.3, -0.3, -1)
            Else
                'If not 0, the values are placed upon the Y axis to the corresponding height.
                txt.InsertionPoint = New VectorDraw.Geometry.gPoint(-0.3, 0.45 * i, -1)
                txt.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorRight
            End If
            If chart3DCheckBox.Checked Then
                txt.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerBottom
                Dim mat As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix()
                'If the chart is in 3D, the values are relocated to the right of the Chart axes, in order to be visible.
                mat.TranslateMatrix(10.2, 0, 0.05)
                txt.Transformby(mat)
            Else
                txt.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
                'If in 2D, small lines are placed on the Y axis.
                Dim line As VectorDraw.Professional.vdFigures.vdLine = New VectorDraw.Professional.vdFigures.vdLine()
                line.SetUnRegisterDocument(BaseControl.ActiveDocument)
                line.setDocumentDefaults()
                line.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Gray)
                line.StartPoint = New VectorDraw.Geometry.gPoint(-0.1, txt.InsertionPoint.y, -1)
                line.EndPoint = New VectorDraw.Geometry.gPoint(0.1, txt.InsertionPoint.y, -1)
                'No line needs to be added for 0.
                If i <> 0 Then
                    BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(line)
                End If
            End If
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(txt)
        Next i
        BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(xAxis)
        BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(yAxis)
        BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textX)
        BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textY)
    End Sub
    'This method places a small vdCircle to the point a value indicates and returns that point.
    Private Function placePoint(ByVal x As Double, ByVal y As Double, ByVal c As Color) As VectorDraw.Geometry.gPoint
        Dim circle As VectorDraw.Professional.vdFigures.vdCircle = New VectorDraw.Professional.vdFigures.vdCircle()
        circle.SetUnRegisterDocument(BaseControl.ActiveDocument)
        circle.setDocumentDefaults()
        circle.Radius = 0.08
        Dim hp As VectorDraw.Professional.vdObjects.vdHatchProperties = New VectorDraw.Professional.vdObjects.vdHatchProperties()
        hp.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid
        'The vdCircle is filled with the same color as its PenColo.
        hp.FillColor = New VectorDraw.Professional.vdObjects.vdColor(c)
        circle.HatchProperties = hp
        'The center of the circle is the center of the point the value indicates.
        circle.Center = New VectorDraw.Geometry.gPoint(x, y)
        circle.PenColor = New VectorDraw.Professional.vdObjects.vdColor(c)

        BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(circle)
        Return circle.Center
    End Function
    'This method is used to create all the needed points as well as the vdPolyLine, so that a Line Chart will be designed.
    Private Sub CreateLine(ByVal titles As String(), ByVal values As Double(), ByVal c As Color)
        Dim valuesNum As Integer = values.Length
        'In this xGap variable is stored the space between two consecutive points projected on the X axis. Using this variable, all the points of the chart
        'have the appropriate x value.
        Dim xGap As Double = 10.0 / valuesNum
        Dim maxValue As Double = 0
        Dim i As Integer
        For i = 0 To valuesNum - 1
            If values(i) > maxValue Then
                maxValue = values(i)
            End If
        Next i
        maxValue = Math.Round(maxValue)
        CreateLineAxis("Axis X", "Axis Y", maxValue)
        'This vdPolyLine object (connector) will connect all the points that we will place in the Chart.
        Dim connector As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline()
        connector.SetUnRegisterDocument(BaseControl.ActiveDocument)
        connector.setDocumentDefaults()
        connector.PenWidth = 0.08
        connector.PenColor = New VectorDraw.Professional.vdObjects.vdColor(c)
        'This loop will place the title of every point in the right place on the X axis.
        For i = 0 To valuesNum - 1
            Dim title As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText()
            title.SetUnRegisterDocument(BaseControl.ActiveDocument)
            title.setDocumentDefaults()
            title.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Black)
            title.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorRight
            title.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
            title.Rotation = 3.14 / 3
            title.Height = 0.2
            title.TextString = titles(i)
            If chart3DCheckBox.Checked Then
                'If we are drawing a 3D chart we'll just insert the vdPolyLine object.
                connector.VertexList.Add(New VectorDraw.Geometry.gPoint(xGap / 2 + (i * xGap), values(i) * (4.5 / maxValue)))
            Else
                'If we are drawing a 3d chart we'll insert the vdPolyLine and the points for every value.
                connector.VertexList.Add(placePoint(xGap / 2 + (i * xGap), values(i) * (4.5 / maxValue), c))
                title.InsertionPoint = New VectorDraw.Geometry.gPoint(connector.VertexList(i).x, -0.1)
                BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(title)
            End If
        Next i
        If chart3DCheckBox.Checked Then
            'If we are drawing a 3D chart, we add thickness to the vdPolyLine object.
            connector.Thickness = 1
        End If
        BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(connector)
        BaseControl.ActiveDocument.ActiveLayOut.Entities.InsertAt(0, connector)
    End Sub
    'This method creates a new Document to the BaseControl, accesses the data in the DataGrid and calls the method to create the Chart.
    Private Sub DrawLineChart()
        BaseControl.ActiveDocument.[New]()
        BaseControl.ActiveDocument.ActiveLayOut.BkColorEx = Color.Gainsboro
        BaseControl.ActiveDocument.ShowUCSAxis = False
        BaseControl.ActiveDocument.CommandAction.View3D("RENDER")
        Dim valuesCount As Integer = DataGrid.RowCount
        Dim values(valuesCount - 1) As Double
        Dim titles(valuesCount - 1) As String
        Dim i As Integer
        For i = 0 To valuesCount - 1
            Try
                values(i) = Double.Parse(DataGrid(1, i).Value.ToString())
            Catch
                values(i) = 0
            End Try
            titles(i) = DataGrid(0, i).Value.ToString()
        Next i
        Dim mat As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix()
        BaseControl.ActiveDocument.Model.World2ViewMatrix = mat
        CreateLine(titles, values, Color.Yellow)
        BaseControl.ActiveDocument.ActiveLayOut.ZoomExtents()
        BaseControl.ActiveDocument.Redraw(False)
    End Sub
#End Region
#Region "Bars Chart"
    'This method creates a bar given the place on the X axis it will be created and the percentage it will represent.
    Private Function CreateBar(ByVal x As Double, ByVal percentage As Double, ByVal maxValue As Double, ByVal c As Color, ByVal label As String) As VectorDraw.Geometry.gPoint
        Dim rect As VectorDraw.Professional.vdFigures.vdRect = New VectorDraw.Professional.vdFigures.vdRect()
        rect.SetUnRegisterDocument(BaseControl.ActiveDocument)
        rect.setDocumentDefaults()
        rect.InsertionPoint = New VectorDraw.Geometry.gPoint(x - 0.3, 0, -1)
        rect.Height = 4.5 / maxValue * percentage
        rect.Width = 0.6
        rect.HatchProperties = New VectorDraw.Professional.vdObjects.vdHatchProperties()
        'The FillMode property of the HatchProperties object defines how the vdRect is filled. In this case, it uses a solid color.
        rect.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid
        rect.HatchProperties.FillColor = New VectorDraw.Professional.vdObjects.vdColor(c)
        rect.PenColor = New VectorDraw.Professional.vdObjects.vdColor(c)
        'If the chart3DCheckBox is selected, a 3D chart is being drawn, so we add thickness to the vdRect object.
        If chart3DCheckBox.Checked Then
            rect.Thickness = 1
        End If
        Dim Text As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText()
        Text.SetUnRegisterDocument(BaseControl.ActiveDocument)
        Text.setDocumentDefaults()
        Text.TextString = label
        Text.InsertionPoint = New VectorDraw.Geometry.gPoint(rect.InsertionPoint.x + 0.3, rect.InsertionPoint.y)
        Text.Rotation = 3.14 / 2
        Text.Height = 0.25
        Text.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        Text.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Black)
        'When drawing a 3D chart, we add some minor thickness to the text, to make it easier to read.
        If chart3DCheckBox.Checked Then
            Text.Thickness = 0.01
        End If
        BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(rect)
        BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(Text)
        Return rect.InsertionPoint
    End Function
    'This method is used to create all the Bars needed to draw the Bars Chart.
    Private Sub CreateBarsChart(ByVal values As Double(), ByVal titles As String())
        Dim valueNum As Integer = values.Length
        Dim maxValue As Integer
        Dim i As Integer
        For i = 0 To valueNum - 1
            If maxValue < values(i) Then
                maxValue = values(i)
            End If
        Next i
        maxValue = Math.Round(maxValue)
        CreateLineAxis("X", "Y", maxValue)
        Dim randomize As Random = New Random()
        'This loop provides three random numbers so that we will get a random color to make Bar with so that Every Bar gets a different color.
        For i = 0 To valueNum - 1
            Dim r As Integer = randomize.Next(70, 255)
            Dim g As Integer = randomize.Next(70, 255)
            Dim b As Integer = randomize.Next(70, 255)
            CreateBar(10.0 / valueNum / 2 + 9.5 / valueNum * i, values(i), maxValue, Color.FromArgb(r, g, b), titles(i))
        Next i
    End Sub
    'This method creates a new Document to the BaseControl, accesses the data in the DataGrid and calls the method to create the Chart.
    Private Sub DrawBarsChart()
        BaseControl.ActiveDocument.[New]()
        BaseControl.ActiveDocument.ActiveLayOut.BkColorEx = Color.Gainsboro
        BaseControl.ActiveDocument.ShowUCSAxis = False
        BaseControl.ActiveDocument.CommandAction.View3D("RENDER")
        Dim barsCount As Integer = DataGrid.RowCount
        Dim values(barsCount - 1) As Double
        Dim titles(barsCount - 1) As String
        Dim i As Integer
        For i = 0 To barsCount - 1
            Try
                values(i) = Double.Parse(DataGrid(1, i).Value.ToString())
            Catch
                values(i) = 0
            End Try
            titles(i) = DataGrid(0, i).Value.ToString()
        Next i
        Dim mat As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix()
        BaseControl.ActiveDocument.Model.World2ViewMatrix = mat
        CreateBarsChart(values, titles)
        BaseControl.ActiveDocument.ActiveLayOut.ZoomExtents()
        BaseControl.ActiveDocument.Redraw(False)
    End Sub
#End Region
#Region "Wave Chart"
    'This method is used to create the X and Y axes the Wave Chart will be created upon.
    Private Sub CreateWaveAxis(ByVal labelX As String, ByVal labelY As String, ByVal maxValue As Double)
        Dim img As VectorDraw.Professional.vdPrimaries.vdImageDef = New VectorDraw.Professional.vdPrimaries.vdImageDef()
        img.FileName = "wave_chart_backround.jpg"
        img.Name = "backroundImage"
        'Before an image can be used, it needs to be inserted to the Images list of the ActiveDocument.
        BaseControl.ActiveDocument.Images.AddItem(img)
        Dim imageBack As VectorDraw.Professional.vdFigures.vdImage = New VectorDraw.Professional.vdFigures.vdImage()
        imageBack.SetUnRegisterDocument(BaseControl.ActiveDocument)
        imageBack.setDocumentDefaults()
        imageBack.ImageDefinition = img
        imageBack.InsertionPoint = New VectorDraw.Geometry.gPoint(0, 0, 0)
        'When changing the Height of an image, the Width will change according to the aspect ratio, keeping the proportions intact.
        imageBack.Height = 4.95

        Dim mat As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix()
        mat.RotateXMatrix(3.14 / 2)
        imageBack.Transformby(mat)
        BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(imageBack)
        Dim img2 As VectorDraw.Professional.vdPrimaries.vdImageDef = New VectorDraw.Professional.vdPrimaries.vdImageDef()
        img2.FileName = "wave_chart_Y_axis.jpg"
        img2.Name = "yAxisImage"
        BaseControl.ActiveDocument.Images.AddItem(img2)
        Dim imageY As VectorDraw.Professional.vdFigures.vdImage = New VectorDraw.Professional.vdFigures.vdImage()
        imageY.SetUnRegisterDocument(BaseControl.ActiveDocument)
        imageY.setDocumentDefaults()
        imageY.ImageDefinition = img2
        imageY.InsertionPoint = New VectorDraw.Geometry.gPoint(0, 0, 0)
        imageY.Height = 4.95
        mat = New VectorDraw.Geometry.Matrix()
        mat.RotateXMatrix(3.14 / 2)
        mat.RotateZMatrix(-3.14 / 2)
        imageY.Transformby(mat)
        BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(imageY)

        img2 = New VectorDraw.Professional.vdPrimaries.vdImageDef()
        img2.FileName = "wave_chart_bottom.jpg"
        img2.Name = "yBottomImage"
        BaseControl.ActiveDocument.Images.AddItem(img2)
        Dim imageBottom As VectorDraw.Professional.vdFigures.vdImage = New VectorDraw.Professional.vdFigures.vdImage()
        imageBottom.SetUnRegisterDocument(BaseControl.ActiveDocument)
        imageBottom.setDocumentDefaults()
        imageBottom.ImageDefinition = img2
        imageBottom.InsertionPoint = New VectorDraw.Geometry.gPoint(0, 0, 0)
        imageBottom.Height = 4
        mat = New VectorDraw.Geometry.Matrix()
        mat.TranslateMatrix(0, -4, 0)
        imageBottom.Transformby(mat)
        BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(imageBottom)
    End Sub
    'This method creates the vdGroundSurface object with all its points that will be the wave of the Wave Chart.
    Private Sub CreateWaveChart()
        Dim waveChart As VectorDraw.Professional.vdFigures.vdGroundSurface = New VectorDraw.Professional.vdFigures.vdGroundSurface()
        waveChart.SetUnRegisterDocument(BaseControl.ActiveDocument)
        waveChart.setDocumentDefaults()
        Dim points As VectorDraw.Geometry.gPoints = New VectorDraw.Geometry.gPoints()
        Dim i As Integer
        For i = 0 To -DataGrid.ColumnCount + 1 Step -1
            Dim j As Integer
            For j = 0 To DataGrid.RowCount - 2
                'A vdGroundSurface is very easy to create. Someone just need to provide a list of points and the vdGroudSurface will create the mesh
                'and PolyFaces neede on its own. It is important to remember though, that the vdGroudSurface is designed to use the Z axis as the 
                'height dimension and it's not advisable trying to rotate it.
                points.Add(j * 0.1, i * 0.4, Double.Parse(DataGrid(Math.Abs(i), j).Value.ToString()))
            Next j
        Next i
        'The DispMode property of the vdGroundSurface gives the option of the way the object will be displayed. The Mesh option allows to mofify the size of it
        'so offering more or less smoothness (the smaller the Mesh size, the smoother the surface).
        waveChart.DispMode = VectorDraw.Professional.vdFigures.vdGroundSurface.DisplayMode.Mesh
        waveChart.MeshSize = 0.4
        waveChart.GradientFill = True
        'The Gradient of a vdGroundSurface colors the highest points (bigger Z value) with a color and the lower points (smaller Z value) with a different one.
        'All the points in between are colored relatively to which side are closer to.
        waveChart.GradientMaximunColor.FromRGB(42, 220, 19)
        waveChart.GradientMinimunColor.FromRGB(255, 81, 88)
        waveChart.Points = points
        BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(waveChart)
    End Sub
    'This method creates a new Document to the BaseControl, accesses the data in the DataGrid, sets the diagonal view to the Chart
    'and calls the method to create the Chart.
    Private Sub DrawWaveChart()
        BaseControl.ActiveDocument.[New]()
        BaseControl.ActiveDocument.ActiveLayOut.BkColorEx = Color.Gainsboro
        BaseControl.ActiveDocument.CommandAction.View3D("RENDER")
        CreateWaveAxis("x", "y", 45)
        CreateWaveChart()
        Dim mat As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix()
        'This String (str) contains the definition of the matrix of a specific view we want to use. Using this String we create a new Matrix (mat)
        'and replace the World2ViewMatrix with this one. By replacing the World2ViewMatrix with the new Matrix (mat) we get exactly the angle, we want
        'the user to see our chart from.
        'You can find this number by doing this.
        'Go to a running vdFramedControl and adjust the camera as you wish it to be. On the Properties List to the left go to the Collections->vdViews property.
        'Create a new vdView, select the current Layout you have just edited and export the World2ViewMatrix of the vdView, using the toString method. 
        Dim str As String = "0.68563743,0.72791465,0.00644788,-1.90495088,-0.61329384,0.5728569,0.54378823,2.7252583,0.39213771,-0.37679601,0.8391977,-4.79055158,0,0,0,1"
        mat.FromString(Str)
        BaseControl.ActiveDocument.Model.World2ViewMatrix = mat
        BaseControl.ActiveDocument.Model.ZoomExtents()
        BaseControl.Redraw()
    End Sub
#End Region
#Region "Horizontal Bars Chart"
    'This method is used to create all the Bars needed to draw the Horizontal Bars Chart.
    Private Sub DrawHorBarChart()
        BaseControl.ActiveDocument.[New]()
        BaseControl.ActiveDocument.ActiveLayOut.BkColorEx = Color.Gainsboro
        BaseControl.ActiveDocument.ShowUCSAxis = False
        BaseControl.ActiveDocument.CommandAction.View3D("RENDER")
        Dim barsCount As Integer = DataGrid.RowCount
        Dim values(barsCount - 1) As Double
        Dim titles(barsCount - 1) As String
        Dim i As Integer
        For i = 0 To barsCount - 1
            Try
                values(i) = Double.Parse(DataGrid(1, i).Value.ToString())
            Catch
                values(i) = 0
            End Try
            titles(i) = DataGrid(0, i).Value.ToString()
        Next i
        Dim mat As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix()
        BaseControl.ActiveDocument.Model.World2ViewMatrix = mat
        BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-2, -5.5), New VectorDraw.Geometry.gPoint(2, 5.5))
        CreateHorBarChart(values, titles)
        BaseControl.ActiveDocument.Redraw(False)
    End Sub
    'This method is used to create the X and Y axes the Horizontal Bars Chart will be created upon.
    Private Sub CreateHorBarsAxis(ByVal labelX As String, ByVal labelY As String, ByVal maxValue As Double)
        'This method is almost identical to the CreateLineAxis. The only difference is where the labels are located, since this chart places the bars
        'horizontally unlike the BarsChart that places them vertically. For more details, see the CreateLineAxis method.
        Dim xAxis As VectorDraw.Professional.vdFigures.vdLine = New VectorDraw.Professional.vdFigures.vdLine()
        xAxis.SetUnRegisterDocument(BaseControl.ActiveDocument)
        xAxis.setDocumentDefaults()
        xAxis.StartPoint = New VectorDraw.Geometry.gPoint(-0.5, 0, 0)
        xAxis.EndPoint = New VectorDraw.Geometry.gPoint(10, 0, 0)
        xAxis.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Gray)
        xAxis.PenWidth = 0.1
        Dim yAxis As VectorDraw.Professional.vdFigures.vdLine = New VectorDraw.Professional.vdFigures.vdLine()
        yAxis.SetUnRegisterDocument(BaseControl.ActiveDocument)
        yAxis.setDocumentDefaults()
        yAxis.StartPoint = New VectorDraw.Geometry.gPoint(0, -0.5, 0)
        yAxis.EndPoint = New VectorDraw.Geometry.gPoint(0, 4.95, 0)
        yAxis.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Gray)
        yAxis.PenWidth = 0.1
        Dim textX As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText()
        textX.SetUnRegisterDocument(BaseControl.ActiveDocument)
        textX.setDocumentDefaults()
        textX.TextString = labelX
        textX.Height = 0.3
        textX.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Black)
        textX.InsertionPoint = New VectorDraw.Geometry.gPoint(xAxis.EndPoint.x + 0.2, yAxis.StartPoint.y, 0)
        Dim textY As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText()
        textY.SetUnRegisterDocument(BaseControl.ActiveDocument)
        textY.setDocumentDefaults()
        textY.TextString = labelY
        textY.Height = 0.3
        textY.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Black)
        textY.InsertionPoint = New VectorDraw.Geometry.gPoint(xAxis.StartPoint.x, yAxis.EndPoint.y + 0.5, 0)
        BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(yAxis.EndPoint.x - 2, yAxis.EndPoint.y - 2), New VectorDraw.Geometry.gPoint(xAxis.EndPoint.x + 2, xAxis.EndPoint.y + 2))
        Dim matt As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix()
        BaseControl.ActiveDocument.Model.World2ViewMatrix = matt
        Dim i As Integer
        For i = 0 To 11
            Dim txt As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText()
            txt.SetUnRegisterDocument(BaseControl.ActiveDocument)
            txt.setDocumentDefaults()
            txt.Height = 0.2
            txt.TextString = (maxValue * i / 10).ToString()
            txt.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Black)
            If i = 0 Then
                txt.InsertionPoint = New VectorDraw.Geometry.gPoint(-0.3, -0.3)
            Else
                txt.InsertionPoint = New VectorDraw.Geometry.gPoint(i * 10.0 / 11.0, -0.2, 0)
                txt.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorLeft
                txt.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
                txt.Rotation = -3.14 / 2
                Dim line As VectorDraw.Professional.vdFigures.vdLine = New VectorDraw.Professional.vdFigures.vdLine()
                line.SetUnRegisterDocument(BaseControl.ActiveDocument)
                line.setDocumentDefaults()
                line.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Gray)
                line.StartPoint = New VectorDraw.Geometry.gPoint(txt.InsertionPoint.x, -0.1, 0)
                line.EndPoint = New VectorDraw.Geometry.gPoint(txt.InsertionPoint.x, 0.1, 0)
                BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(line)
            End If
            BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(txt)
        Next i
        BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(xAxis)
        BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(yAxis)
        BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textX)
        BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(textY)
    End Sub
    'This method creates a bar given the place on the Y axis it will be created and the value it represents.
    Private Sub CreateHorBar(ByVal y As Double, ByVal value As Double, ByVal maxValue As Double, ByVal c As Color, ByVal label As String)
        'This vdCircle will be the base shape the vdPolyFace will use as shape.
        Dim circle As VectorDraw.Professional.vdFigures.vdCircle = New VectorDraw.Professional.vdFigures.vdCircle()
        circle.SetUnRegisterDocument(BaseControl.ActiveDocument)
        circle.setDocumentDefaults()
        circle.Radius = 0.2
        Dim hp As VectorDraw.Professional.vdObjects.vdHatchProperties = New VectorDraw.Professional.vdObjects.vdHatchProperties()
        hp.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid
        circle.HatchProperties = hp
        'This vdLine will be used to provide the path that the vdPolyFace object will be drawn on.
        Dim line As VectorDraw.Professional.vdFigures.vdLine = New VectorDraw.Professional.vdFigures.vdLine()
        line.SetUnRegisterDocument(BaseControl.ActiveDocument)
        line.setDocumentDefaults()
        line.StartPoint = New VectorDraw.Geometry.gPoint(0, y)
        line.EndPoint = New VectorDraw.Geometry.gPoint(value * 9.09 / maxValue, y)

        Dim Text As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText()
        Text.SetUnRegisterDocument(BaseControl.ActiveDocument)
        Text.setDocumentDefaults()
        Text.Height = 0.2
        Text.TextString = label
        Text.InsertionPoint = line.EndPoint
        Text.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorLeft
        Text.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        Text.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Black)
        BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(Text)

        Dim face As VectorDraw.Professional.vdFigures.vdPolyface = New VectorDraw.Professional.vdFigures.vdPolyface()
        face.SetUnRegisterDocument(BaseControl.ActiveDocument)
        face.setDocumentDefaults()
        face.PenColor = New VectorDraw.Professional.vdObjects.vdColor(c)
        'This chart uses the Generate3dPathSection method of the vdPolyFace object, similarly to the Bar Chart. A vdCircle and a vdLine are used as parameters
        'to create a vdPolyface shaping a 3D cylinder.
        face.Generate3dPathSection(line, circle, New VectorDraw.Geometry.gPoint(), 0, 1)
        BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(face)
    End Sub
    'This method creates a new Document to the BaseControl, accesses the data in the DataGrid and calls the method to create the Chart.
    Private Sub CreateHorBarChart(ByVal values As Double(), ByVal titles As String())
        Dim valueNum As Integer = values.Length
        If (valueNum Mod 2) = 1 Then
            MessageBox.Show("For this chart, you need to enter an even number of values")
            Exit Sub
        End If
        Dim maxValue As Double
        Dim i As Integer
        For i = 0 To valueNum - 1

            If maxValue < values(i) Then
                maxValue = values(i)
            End If
        Next i
        maxValue = Math.Round(maxValue)
        CreateHorBarsAxis("X", "Y", maxValue)
        'A random color is used for every two horizontal bars in this chart, by getting three random integers that represent the RGB color map.
        'The second bar is slightly darker, we achieve that by bringing all the r, g, b variables closer to 0, wich is the RBG number for Black.
        Dim randomize As Random = New Random()
        For i = valueNum To 1 Step -2
            Dim r As Integer = randomize.Next(50, 255)
            Dim g As Integer = randomize.Next(50, 255)
            Dim b As Integer = randomize.Next(50, 255)
            CreateHorBar(4.75 / valueNum * i, values(valueNum - i), maxValue, Color.FromArgb(r, g, b), titles(valueNum - i))
            CreateHorBar(4.75 / valueNum * i - 0.4, values(valueNum - (i - 1)), maxValue, Color.FromArgb(r - 40, g - 40, b - 40), titles(valueNum - (i - 1)))
        Next i
    End Sub
#End Region
End Class
