Public Class Form2
    Private contours As VectorDraw.Geometry.DoubleArray = New VectorDraw.Geometry.DoubleArray()
    Private MaxCountour As Double = 0.0
    Private MinCountour As Double = 0.0
    Private Sub vdFramedControl1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vdFramedControl1.Load

    End Sub

    Private Sub radioequasion1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioequasion1.CheckedChanged
        If (Not radioequasion1.Checked) Then Exit Sub
        contours.RemoveAll()
        labContours.Text = contours.Count.ToString() + " contours active"
        LoadEquasion(1)
    End Sub
    Private Sub radioequasion2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioequasion2.CheckedChanged
        If (Not radioequasion2.Checked) Then Exit Sub
        contours.RemoveAll()
        labContours.Text = contours.Count.ToString() + " contours active"
        LoadEquasion(2)
    End Sub

    Private Sub radioMappedImage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioMappedImage.CheckedChanged
        If (Not radioMappedImage.Checked) Then Exit Sub
        contours.RemoveAll()
        labContours.Text = contours.Count.ToString() + " contours active"
        LoadMappedImage()
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        vdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.CommandLine, False)
        vdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.LayoutTab, False)
        vdFramedControl1.UnLoadMenu()
        contours.RemoveAll()
        labContours.Text = contours.Count.ToString() + " contours active"
        radioequasion1.Checked = True
        vdFramedControl1.BaseControl.ActiveDocument.ShowUCSAxis = False
    End Sub

    Private Sub butRotate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRotate.Click
        VectorDraw.Professional.ActionUtilities.vdCommandAction.View3D_Vrot(vdFramedControl1.BaseControl.ActiveDocument)
    End Sub

    Private Sub butAddContour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAddContour.Click
        Dim level As String = VectorDraw.Professional.Dialogs.frmInputText.Show("From " + MaxCountour.ToString("0.00") + " to " + MinCountour.ToString("0.00") + ")", "Countour level", "0.0", vdFramedControl1.BaseControl.ActiveDocument.ActionControl)
        If level <> "0.0" Then
            Dim val As Double = 0.0
            Try
                val = Double.Parse(level)
            Catch
                val = 0.0
            End Try
            contours.Add(val)
            labContours.Text = contours.Count.ToString() + " contours active"

            AddContour()
        End If
    End Sub

    Private Sub AddContour()
        Dim ground As VectorDraw.Professional.vdFigures.vdGroundSurface = New VectorDraw.Professional.vdFigures.vdGroundSurface()
        'We know that the only entity of the document od the GroundSurface so we can obtain this object simply by getting the 0 item of the entities collection.
        ground = vdFramedControl1.BaseControl.ActiveDocument.Model.Entities(0)

        If Not ground Is Nothing Then
            'We add levels.This means that points that have z value equal to the values added will be added to the contours PolyCurves.Then we will add these creates polylines to the document with different colors.
            ground.ContourLevels.RemoveAll()
            Dim var As Double
            For Each var In contours
                ground.ContourLevels.Add(var)
            Next
            ground.Update()
            'We add the Contours polylines.
            If Not ground.Contours Is Nothing Then
                Dim i As Short = 0
                Dim var1 As VectorDraw.Professional.vdCollections.vdCurves
                For Each var1 In ground.Contours
                    Dim var2 As VectorDraw.Professional.vdFigures.vdCurve
                    For Each var2 In var1
                        var2.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument)
                        var2.setDocumentDefaults()
                        var2.PenColor.ColorIndex = i
                        var2.PenWidth = 0.3
                        vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(var2.Clone(vdFramedControl1.BaseControl.ActiveDocument))
                    Next
                    i = i + 1
                Next
            End If
            vdFramedControl1.BaseControl.ActiveDocument.Redraw(True)
        End If
    End Sub
    Private Sub LoadEquasion(ByVal equa As Integer)
        groupBox1.Enabled = True
        vdFramedControl1.BaseControl.ActiveDocument.[New]()
        vdFramedControl1.BaseControl.ActiveDocument.ShowUCSAxis = False
        Dim ground As VectorDraw.Professional.vdFigures.vdGroundSurface = New VectorDraw.Professional.vdFigures.vdGroundSurface()
        ground.SetUnRegisterDocument(vdFramedControl1.BaseControl.ActiveDocument)
        ground.setDocumentDefaults()
        'We will fill the GroundFurface object's points using mathematical equasions that generate points that look like mountains.

        If equa = 1 Then
            ground.Points = Equasion1()
        Else
            ground.Points = Equasion2()
        End If
        MaxCountour = ground.MaxLevel()
        MinCountour = ground.MinLevel()
        'Display properties.
        ground.DispMode = VectorDraw.Professional.vdFigures.vdGroundSurface.DisplayMode.Triangle
        ground.MeshSize = 0.3
        ground.PenColor.ColorIndex = 250

        'We add the groundSurface object to the Model Layout.
        vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(ground)

        VectorDraw.Professional.ActionUtilities.vdCommandAction.View3D_VLeft(vdFramedControl1.BaseControl.ActiveDocument)
        vdFramedControl1.BaseControl.ActiveDocument.Redraw(True)
    End Sub
#Region "Equasions"
    Private Function Equasion1() As VectorDraw.Geometry.gPoints

        Dim points As VectorDraw.Geometry.gPoints = New VectorDraw.Geometry.gPoints()
        Dim x As Integer
        Dim y As Integer
        Dim ix As Double = x / 10.0
        Dim iy As Double = y / 10.0
        For x = -15 To 15 Step 2
            For y = -15 To 15 Step 2
                ix = x / 10.0
                iy = y / 10.0
                Dim num1 As Double = ((ix * ix) + (iy - 0.842) * (iy + 0.842))
                Dim num2 As Double = (ix * (iy - 0.842) + (ix * (iy + 0.842)))
                Dim z As Double = 1 / ((num1 * num1) + (num2 * num2))
                points.Add(New VectorDraw.Geometry.gPoint(ix * 10.0, iy * 10.0, z))
            Next
        Next

        Return points
    End Function
    Private Function Equasion2() As VectorDraw.Geometry.gPoints

        Dim points As VectorDraw.Geometry.gPoints = New VectorDraw.Geometry.gPoints()
        Dim x As Integer
        Dim y As Integer
        Dim ix As Double
        Dim iy As Double
        For x = -12 To 11.9
            For y = -12 To 11.9
                ix = x / 10 * VectorDraw.Geometry.Globals.VD_TWOPI
                iy = y / 10 * VectorDraw.Geometry.Globals.VD_TWOPI
                Dim z As Double = Math.Sin(Math.Pow((ix * ix + iy * iy), 0.5)) + 1 / (Math.Pow((Math.Pow((ix - 1), 2) + iy * iy), 0.5))
                points.Add(New VectorDraw.Geometry.gPoint(ix, iy, z * 5.0))
            Next
        Next

        Return points
    End Function

    Private Sub LoadMappedImage()

        Dim ground As VectorDraw.Professional.vdFigures.vdGroundSurface
        Dim idef As VectorDraw.Professional.vdPrimaries.vdImageDef
        groupBox1.Enabled = False
        vdFramedControl1.BaseControl.ActiveDocument.[New]()

        vdFramedControl1.BaseControl.ActiveDocument.ShowUCSAxis = False
        ''open a drawing that contains a predefined ground surface.
        If (vdFramedControl1.BaseControl.ActiveDocument.Open("ground.vdcl") = False) Then Exit Sub

        ground = vdFramedControl1.BaseControl.ActiveDocument.Model.Entities(0)
        ''we add an image definition representing an aerial photo of the ground surface area.
        idef = vdFramedControl1.BaseControl.ActiveDocument.Images.Add("ground.jpg")
        ''we create a new vdMapped Image object and attach it in to our surface object, using a rectangle that represents the tranformation matrix from image object on to our surface coordinate system.
        ground.MappedImages.AddItem(New VectorDraw.Professional.vdObjects.vdMappedImage(idef, New VectorDraw.Geometry.Box(New VectorDraw.Geometry.gPoint(17, 29), New VectorDraw.Geometry.gPoint(3317, 2183)), VectorDraw.Render.vdRectangle.Empty))

        vdFramedControl1.BaseControl.ActiveDocument.CommandAction.Zoom("E", 0, 0)
        vdFramedControl1.BaseControl.ActiveDocument.Redraw(True)
    End Sub
#End Region


   
End Class