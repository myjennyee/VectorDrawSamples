Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OpenDrawing(vdFramedControl1)
        combodegrees.SelectedIndex = 0
    End Sub

    Private Sub OpenDrawing(ByRef control As vdControls.vdFramedControl)
        If (control.Equals(vdFramedControl1)) Then
            vdFramedControl1.BaseControl.ActiveDocument.Open(Application.StartupPath + "\\Testdrawing.vdml")
            vdFramedControl1.BaseControl.ActiveDocument.RenderMode = VectorDraw.Render.vdRender.Mode.Wire2d
        ElseIf (control.Equals(VdFramedControl2)) Then
            VdFramedControl2.BaseControl.ActiveDocument.Open(Application.StartupPath + "\\Testdrawing 2.vdml")
            VdFramedControl2.BaseControl.ActiveDocument.RenderMode = VectorDraw.Render.vdRender.Mode.Render
        End If
        control.BaseControl.ActiveDocument.ShowUCSAxis = False
        control.BaseControl.ActiveDocument.Invalidate()
    End Sub

    Private Sub combodegrees_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        OpenDrawing(vdFramedControl1)
    End Sub

    Private Sub Calculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Calculate.Click
        If (tabControl1.SelectedIndex = 0) Then
            Dim degrees As Double = Double.Parse(combodegrees.Text)
            Dim radians As Double = VectorDraw.Geometry.Globals.DegreesToRadians(degrees)

            'We will provide 4 different ways to get entities and then we will calculate the area of these polylines and make a quick representation in the CalculateArea Method.

            '1)Get the first polyline dirrectly from the entities collection knowing it's position to the entities collection.
            Dim poly As VectorDraw.Professional.vdFigures.vdPolyline = vdFramedControl1.BaseControl.ActiveDocument.Model.Entities(1)
            If Not poly Is Nothing Then
                CalculateArea(poly, radians)
            End If


            '2) Get the second polyline from it's handle
            poly = vdFramedControl1.BaseControl.ActiveDocument.FindFromHandle(New VectorDraw.Professional.vdObjects.vdHandle(CULng(106)), GetType(VectorDraw.Professional.vdFigures.vdPolyline))
            If Not (poly Is Nothing) Then
                CalculateArea(poly, radians)
            End If


            '3) Get the first polyline from a point in the drawing.
            Dim point As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint(-4.14, -12.61, 0.0)
            Dim pt As VectorDraw.Geometry.gPoint = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.World2Pixelmatrix.Transform(point)

            poly = vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.GetEntityFromPoint(New Point(CInt(pt.x), CInt(pt.y)), vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.PickSize, False)
            If Not (poly Is Nothing) Then
                CalculateArea(poly, radians)
            End If


            '4) Get the last polyline from an XProperty that has been added to this vdFigure named "AreaCalculation" with value "Area".
            'Create a filter.
            Dim filter As VectorDraw.Professional.vdObjects.vdFilterObject = New VectorDraw.Professional.vdObjects.vdFilterObject()
            filter.Types.AddItem("vdPolyline")
            filter.XProperties.AddItem("AreaCalculation")

            'Create a selection set to apply the filter.
            Dim selset As VectorDraw.Professional.vdCollections.vdSelection = New VectorDraw.Professional.vdCollections.vdSelection("Myselset")
            selset.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument)
            selset.FilterSelect(filter)

            'Get the polyline from the selection set.
            If Not (selset.Count = 0) Then
                poly = selset(0)
                If Not (poly Is Nothing) Then
                    CalculateArea(poly, radians)
                End If
            End If
        ElseIf (tabControl1.SelectedIndex = 1) Then
            Dim doc As VectorDraw.Professional.vdObjects.vdDocument
            doc = VdFramedControl2.BaseControl.ActiveDocument
            'Cleaning our document from unwanted, previously created texts and points.
            For Each entity As VectorDraw.Professional.vdPrimaries.vdFigure In doc.ActiveLayOut.Entities
                If (TypeOf entity Is VectorDraw.Professional.vdFigures.vdMText Or TypeOf entity Is VectorDraw.Professional.vdFigures.vdPoint) Then
                    entity.Deleted = True
                End If
            Next entity
            'The precision actually means how big the squares will be. These squares will be used to measure how many fit in every one of our solid surface.
            Dim precision As Double = textPrecision.Value
            'The 0,0,1 Vector transformed from Vew to World coordination system, points from the user's eyes towards the screen. So, we will always get the
            'entities that are visible to the user. Different vectors can be used to calculate the "visible" areas from different directions.
            Dim viewVector As VectorDraw.Geometry.Vector = New VectorDraw.Geometry.Vector(0, 0, 1)
            doc.View2WorldMatrix.TransformVector(viewVector)

            Dim ents As VectorDraw.Professional.vdCollections.vdEntities = New VectorDraw.Professional.vdCollections.vdEntities()
            For Each entity As VectorDraw.Professional.vdPrimaries.vdFigure In doc.ActiveLayOut.Entities
                If (Not (TypeOf entity Is VectorDraw.Professional.vdFigures.vdDimension)) Then
                    If (entity.visibility = VectorDraw.Professional.vdPrimaries.vdFigure.VisibilityEnum.Visible And entity.Deleted = False) Then
                        ents.AddItem(entity)
                    End If
                End If
            Next (entity)

            'The GetVisibleArea method of vdDocument, returns a collection of EntityViewArea objects. Within these objects lie the properties that allow us 
            'to extract the visible area for each of the entities we pass as arguments, or for all of them together.
            Dim areas As VectorDraw.Render.PrimitivesExport.RenderProperties.EntityViewAreas = doc.GetVisibleArea(ents, viewVector, precision)

            Dim str As String = ""
            Dim counter = 0
            For Each entity As VectorDraw.Professional.vdPrimaries.vdFigure In ents
                Dim tempStr As String = entity.GetType().Name + " entity -> " + CalculateAreaSolid(areas, counter, precision).ToString("0.0000") + vbCrLf + "Square Drawing Units"
                str += tempStr
                Dim posX As Double = entity.BoundingBox.Left + 0.1
                Dim posY As Double = entity.BoundingBox.Bottom - 0.5
                Dim Text As VectorDraw.Professional.vdFigures.vdMText = New VectorDraw.Professional.vdFigures.vdMText(doc, tempStr, New VectorDraw.Geometry.gPoint(posX, posY), 0.3)
                doc.Model.Entities.AddItem(Text)
                counter += 1
            Next entity
            doc.Redraw(True)
        End If
    End Sub
    Private Sub CalculateArea(ByVal poly As VectorDraw.Professional.vdFigures.vdPolyline, ByVal radians As Double)
        Dim areas As VectorDraw.Generics.vdArray(Of VectorDraw.Geometry.SimplePolygonSegment) = poly.GetPolygonsAreas(radians)

        Dim area1 As Double = poly.Area()
        Dim area2 As Double = 0.0

        Dim mattWidth As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix()
        mattWidth.TranslateMatrix(New VectorDraw.Geometry.gPoint(poly.BoundingBox.Width + 0.5, 0.0, 0.0))

        Dim mattHeight As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix()
        mattHeight.TranslateMatrix(New VectorDraw.Geometry.gPoint(0.0, -poly.BoundingBox.Height - 0.5, 0.0))

        Dim count As Integer = 1
        Dim str As String = ""

        vdFramedControl1.BaseControl.ActiveDocument.UndoHistory.StoreUndoGroup(True)
        For Each item As VectorDraw.Geometry.SimplePolygonSegment In areas
            If Not (item.IsValid) Then Continue For
            str += count.ToString() + ") " + item.SegmentType.ToString() + ":" + (item.ToString() + "\P")
            area2 += item.Area
            Dim verts As VectorDraw.Geometry.Vertexes = item.ToPolylineVertexes()
            Dim tmppoly As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline()
            tmppoly.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument)
            tmppoly.setDocumentDefaults()
            tmppoly.MatchProperties(poly, Nothing)
            tmppoly.VertexList = verts
            If Not (item.IsSubtructed) Then
                tmppoly.HatchProperties = New VectorDraw.Professional.vdObjects.vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid)
                tmppoly.HatchProperties.DrawBoundary = True
                tmppoly.HatchProperties.FillColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Green)

            Else
                tmppoly.HatchProperties = New VectorDraw.Professional.vdObjects.vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid)
                tmppoly.HatchProperties.DrawBoundary = False
                tmppoly.HatchProperties.FillColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Yellow)
                tmppoly.HatchProperties.Solid2dTransparency = 100
            End If
            tmppoly.Transformby(item.EcsMatrix)
            tmppoly.Transformby(mattWidth)  'Move the polyline segments a bit to the right.

            Dim pts As VectorDraw.Geometry.gPoints = New VectorDraw.Geometry.gPoints()
            pts = tmppoly.GetSamplePoints(0, 0)
            Dim inspt As VectorDraw.Geometry.gPoint = pts.Centroid()

            Dim indextest As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText()
            indextest.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument)
            indextest.setDocumentDefaults()
            indextest.TextString = count.ToString()
            indextest.InsertionPoint = inspt
            indextest.Height = 0.3
            indextest.PenColor.ColorIndex = 0

            vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(tmppoly)
            vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(indextest)
            count += 1
        Next item

        str += "Total : " + area2.ToString()

        Dim mt As VectorDraw.Professional.vdFigures.vdMText = New VectorDraw.Professional.vdFigures.vdMText()
        mt.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument)
        mt.setDocumentDefaults()
        mt.TextString = str
        mt.InsertionPoint = New VectorDraw.Geometry.gPoint(poly.BoundingBox.Left, poly.BoundingBox.Top, 0.0)
        mt.Transformby(mattHeight)
        mt.Height = 0.9
        vdFramedControl1.BaseControl.ActiveDocument.Model.Entities.AddItem(mt)

        vdFramedControl1.BaseControl.ActiveDocument.UndoHistory.StoreUndoGroup(False)
        vdFramedControl1.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub tabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabControl1.SelectedIndexChanged
        If (tabControl1.SelectedIndex = 0) Then
            textPrecision.Enabled = False
            combodegrees.Enabled = True
            checkProjection.Enabled = False
            OpenDrawing(vdFramedControl1)
        ElseIf (tabControl1.SelectedIndex = 1) Then
            textPrecision.Enabled = True
            combodegrees.Enabled = False
            checkProjection.Enabled = True
            OpenDrawing(VdFramedControl2)
        End If
    End Sub
    Private Sub checkProjection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkProjection.CheckedChanged
        Dim msg As String
        msg = "When projection is checked, the surface calculated is the one that is projected on the user's View, not the "
        msg += "real surface of a plane. So for example, if you have a sphere and use projection, the result area will be this of a circle."
        MessageBox.Show(msg, "Projection", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Function CalculateAreaSolid(ByRef areas As VectorDraw.Render.PrimitivesExport.RenderProperties.EntityViewAreas, ByVal index As Integer, ByVal precision As Double) As Double
        'We can extract the visible area of a specific EntityViewArea object, using "[]". If we needed the total visible area, we could call areas.Area().
        'When the projection argument is true, the surface is calculated as if projected to the plane that would have the viewDirection vector as extrusion Vector.
        'In this case, this plane is the user's View.
        Dim value As Double
        value = areas(index).Area(checkProjection.Checked)
        Return value
    End Function
End Class
