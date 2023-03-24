Imports VectorDraw.Professional
Imports VectorDraw.Professional.vdObjects
Imports VectorDraw.Geometry
Imports VectorDraw.Professional.vdFigures
Imports VectorDraw.Professional.vdPrimaries

' 
' Description : 
'   In tis sample a drawing is loaded into a vdFramedControl and some already fixed areas in
'   this drawing are exported to simple 2D line-segemnts. Then these line segments are added 
'   to a new vdLayout object as vdLine objects
' 
' Use:
'   This sample uses the GetModel2dProjection function to create the segment lines from the 
'   model. This function needs two parameters: i) the "eye" position and "direction" that the
'   eye looks to. It also needs a rotation of the view, but in this sample the 0 rotation is
'   the rotation that should be used to get the correct results.
' 


Public Class TwoD_Projection

    Dim doc As vdDocument
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        doc = VdFramedControl1.BaseControl.ActiveDocument
        If (doc.Open("kindergarden.vdcl")) Then
            VdFramedControl1.UnLoadCommands() ' commands are not necessary
            VdFramedControl1.UnLoadMenu() 'menu is not necessary
            VdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.CommandLine, False) ' commandline is not necessary
            doc.Redraw(True)
            MessageBox.Show("3D Drawing opened. The roof of this drawing is set to be transparent for better visual result")
        End If
    End Sub

    Private Sub AnnotationLayers(ByVal frozen As Boolean)
        doc.Layers.FindName("Annotations1").Frozen = frozen ' setting the yelow rect and label to frozen/thaw as thay were added for demonstration issues
        doc.Layers.FindName("Annotations2").Frozen = frozen ' setting the green rect and label to frozen/thaw as thay were added for demonstration issues
        doc.Layers.FindName("Annotations3").Frozen = frozen ' setting the blue rect and label to frozen/thaw as thay were added for demonstration issues
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click

        Dim segs As linesegments = New linesegments() ' this is the collection of the simple line segments where will be calculated by GetModel2dProjection
        AnnotationLayers(True) '  set  the annotations invisible so they don't mess up with the 2D export

        '1st Layout - 2D projection
        Dim origin As gPoint = New gPoint(0, -11.3, 0) ' set origin point of the "eye"
        Dim dir As gPoint = New gPoint(0, 0, 0)
        segs = doc.GetModel2dProjection(origin, New Vector(origin, dir), 0.0) ' get the 2D projection as line-segments
        Dim layout As vdLayout
        layout = doc.LayOuts.Add("2DProjection_Area1") ' add a layout to add the results
        layout.Entities.RemoveAll()
        Dim line As linesegment
        For Each line In segs
            layout.Entities.AddItem(New vdLine(doc, line.StartPoint, line.EndPoint)) ' add each line-segment as vdLine
        Next
        layout.DisableShowPrinterPaper = True : layout.ZoomExtents()
        AnnotationLayers(False)
        MessageBox.Show("The 2D projection (as simple lines) of the model for this yellow area is created and is available in the layout: " + layout.Name + ". Click on this layout to see the results")
    End Sub

    Private Sub button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button2.Click
        AnnotationLayers(True)
        '2nd Layout - 2D projection
        Dim segs As linesegments = New linesegments() ' this is the collection of the simple line segments where will be calculated by GetModel2dProjection
        Dim origin As gPoint = New gPoint(0, -5.3, 0) ' set origin point of the "eye"
        Dim dir As gPoint = New gPoint(0, 0, 0) ' and direction of the "eye"
        Dim layout As vdLayout
        Dim line As linesegment

        layout = doc.LayOuts.Add("2DProjection_Area2") ' add a layout to add the results
        layout.Entities.RemoveAll()
        segs.RemoveAll()
        segs = doc.GetModel2dProjection(origin, New Vector(origin, Dir), 0.0) ' get the 2D projection as line-segments

        For Each line In segs

            Layout.Entities.AddItem(New vdLine(doc, line.StartPoint, line.EndPoint)) ' add each line-segment as vdLine
        Next

        Layout.DisableShowPrinterPaper = True : Layout.ZoomExtents()
        MessageBox.Show("The 2D projection (as simple lines) of the model for this green area is created and is available in the layout: " + layout.Name + ". Click on this layout to see the results")

        AnnotationLayers(False)
    End Sub

    Private Sub button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button3.Click
        AnnotationLayers(True)
        '3rd Layout - 2D projection
        ' some section clips will be applied to isolate the area from the other objects
        Dim segs As linesegments = New linesegments() ' this is the collection of the simple line segments where will be calculated by GetModel2dProjection

        Dim clip1 As vdSectionClip = New vdSectionClip(doc, "clip1", New gPoint(0.3, 8, 0), New Vector(1, 0, 0), True)
        doc.Model.Sections.AddItem(clip1)
        Dim clip2 As vdSectionClip = New vdSectionClip(doc, "clip2", New gPoint(5.3, 8, 0), New Vector(-1, 0, 0), True)
        doc.Model.Sections.AddItem(clip2)
        Dim clip3 As vdSectionClip = New vdSectionClip(doc, "clip3", New gPoint(1.8, 5.8, 0), New Vector(0, 1, 0), True)
        doc.Model.Sections.AddItem(clip3)


        Dim origin As gPoint = New gPoint(2.8, 6.8, 0) ' set origin point
        Dim dir As gPoint = New gPoint(2.8, 9.8, 0) 'and direction of the "eye"
        Dim layout As vdLayout
        Dim line As linesegment
        layout = doc.LayOuts.Add("2DProjection_Area3") ' add a layout to add the results
        layout.Entities.RemoveAll()
        segs.RemoveAll()
        segs = doc.GetModel2dProjection(origin, New Vector(origin, Dir), 0.0) ' get the 2D projection as line-segments

        For Each line In segs
            layout.Entities.AddItem(New vdLine(doc, line.StartPoint, line.EndPoint)) ' add each line-segment as vdLine
        Next


        clip1.Enable = False : clip2.Enable = False : clip3.Enable = False ' disable the Model's clip-sections are not necessary any more

        Dim view As vdViewport = New vdViewport(doc) ' create a vdViewport that has the same view as the area that was exported as 2D using GetModel2dProjection
        layout.Entities.AddItem(view) ' for more information on vdLayouts/vdViewports see sample "Collections"
        doc.ActiveLayOut = Layout ' with this viewport that will displayed above the line segments you would be able to compare the results
        layout.ActiveViewPort = view
        doc.CommandAction.View3D("VFRONT")
        Layout.ActiveViewPort = Nothing
        view.ViewCenter = New gPoint(2.8, 0.8, 0.0)
        view.ViewSize = 4.2
        view.Center = New gPoint(2.7, 4)
        view.Height = 4
        view.Width = 5.5
        view.RenderMode = VectorDraw.Render.vdRender.Mode.ShadeOn
        view.Sections.AddItem(clip1.Clone()) ' apply the same section-clips as in model 
        view.Sections.AddItem(clip2.Clone()) ' 
        view.Sections.AddItem(clip3.Clone()) ' 
        Layout.DisableShowPrinterPaper = True : Layout.ZoomExtents()
        doc.ActiveLayOut = doc.Model


        AnnotationLayers(False) '  set back the annotations visible

        MessageBox.Show("The 2D projection (as simple lines) of the model for this blue area is created and is available in the layout: " + layout.Name + ". Click on this layout to see the results, note also that this layout has also a viewport with section clipping for comparing.")

    End Sub

    
End Class
