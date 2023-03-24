Public Class Form1

    Private Sub butNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butNew.Click
        VdFramedControl.BaseControl.ActiveDocument.[New]()
        VdFramedControl.BaseControl.ActiveDocument.ShowUCSAxis = False
        butLine.Enabled = True
        butCircle.Enabled = True
        butEllipse.Enabled = True
        butArc.Enabled = True
        butRect.Enabled = True
        butText.Enabled = True
        butPoint.Enabled = True
        butImage.Enabled = True
        butDims.Enabled = True
        butInserts.Enabled = True
        butPolyline.Enabled = True
        butSpline.Enabled = True
        buthatch.Enabled = True
        butMtext.Enabled = True
        but3dobjects.Enabled = True
    End Sub

    Private Sub butLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butLine.Click
        butLine.Enabled = False
        'We will create a vdLine object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
        Dim oneline As VectorDraw.Professional.vdFigures.vdLine = New VectorDraw.Professional.vdFigures.vdLine()
        'We set the document where the line is going to be added.This is important for the vdLine in order to obtain initial properties with setDocumentDefaults.
        oneline.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        oneline.setDocumentDefaults()

        'The two previus steps are important if a vdFigure object is going to be added to a document.
        'Now we will change some properties of the line.
        oneline.StartPoint = New VectorDraw.Geometry.gPoint(10.0, 10.0)
        oneline.EndPoint = New VectorDraw.Geometry.gPoint(30.0, 30.0, 0.0)
        oneline.PenColor.ColorIndex = 3
        'Pen width is depended from the zoom.See in the vdRect object about LineWeight.
        oneline.PenWidth = 0.4
        oneline.ToolTip = "This is a vdLine object \n Click to see it's properties."

        'Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(oneline)

        'Zoom in order to see the object.
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-30.0, -10.0), New VectorDraw.Geometry.gPoint(80.0, 50.0))
        'Redraw the document to see the above changes.
        VdFramedControl.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub butCircle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butCircle.Click
        butCircle.Enabled = False
        'We will create a vdCircle object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
        Dim onecircle As VectorDraw.Professional.vdFigures.vdCircle = New VectorDraw.Professional.vdFigures.vdCircle()
        'We set the document where the circle is going to be added.This is important for the vdCircle in order to obtain initial properties with setDocumentDefaults.
        onecircle.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        onecircle.setDocumentDefaults()

        'The two previus steps are important if a vdFigure object is going to be added to a document.
        'Now we will change some properties of the circle.
        onecircle.Center = New VectorDraw.Geometry.gPoint(30, 30)
        onecircle.Radius = 5
        onecircle.PenColor.SystemColor = Color.BurlyWood
        onecircle.Label = "This is a vdCircle object."
        'This line Type is the same indipending from the zoom.Also the LineTypeScale has no effect,See next object for other linetypes.
        onecircle.LineType = VdFramedControl.BaseControl.ActiveDocument.LineTypes.DPIDashDotDot

        'Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onecircle)

        'Zoom in order to see the object.
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-30.0, -10.0), New VectorDraw.Geometry.gPoint(80.0, 50.0))
        'Redraw the document to see the above changes.
        VdFramedControl.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub butEllipse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butEllipse.Click
        butEllipse.Enabled = False
        'We will create a vdEllipse object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
        Dim oneellipse As VectorDraw.Professional.vdFigures.vdEllipse = New VectorDraw.Professional.vdFigures.vdEllipse()
        'We set the document where the ellipse is going to be added.This is important for the vdEllipse in order to obtain initial properties with setDocumentDefaults.
        oneellipse.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        oneellipse.setDocumentDefaults()

        'The two previus steps are important if a vdFigure object is going to be added to a document.
        'Now we will change some properties of the ellipse.
        oneellipse.Center = New VectorDraw.Geometry.gPoint(10.0, 10.0)
        oneellipse.MajorLength = 7.0
        'We get the angle of the previously added vdLine object using a globals utility.
        oneellipse.MajorAngle = VectorDraw.Geometry.Globals.GetAngle(New VectorDraw.Geometry.gPoint(0.0, 0.0), New VectorDraw.Geometry.gPoint(30.0, 30.0))
        oneellipse.MinorLength = 5.0
        oneellipse.PenColor.FromRGB(255, 0, 128)
        oneellipse.URL = "www.vdraw.com"
        oneellipse.ToolTip = "Go to : www.vdraw.com"
        'For Linetype we choose a linetype called DOT2 from the Linetypes collection.
        oneellipse.LineType = VdFramedControl.BaseControl.ActiveDocument.LineTypes.FindName("DOT2")
        oneellipse.LineTypeScale = 6

        'Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(oneellipse)

        'Zoom in order to see the object.
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-30.0, -10.0), New VectorDraw.Geometry.gPoint(80.0, 50.0))
        'Redraw the document to see the above changes.
        VdFramedControl.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub butArc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butArc.Click
        butArc.Enabled = False
        'We will create a vdArc object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
        Dim onearc As VectorDraw.Professional.vdFigures.vdArc = New VectorDraw.Professional.vdFigures.vdArc()
        'We set the document where the arc is going to be added.This is important for the vdArc in order to obtain initial properties with setDocumentDefaults.
        onearc.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        onearc.setDocumentDefaults()

        'The two previus steps are important if a vdFigure object is going to be added to a document.
        'Now we will change some properties of the arc.
        onearc.Center = New VectorDraw.Geometry.gPoint(20, 22)
        onearc.Radius = 4
        onearc.PenColor.Green = 200
        onearc.StartAngle = VectorDraw.Geometry.Globals.GetAngle(New VectorDraw.Geometry.gPoint(0.0, 0.0), New VectorDraw.Geometry.gPoint(30.0, 30.0))
        onearc.EndAngle = onearc.StartAngle + VectorDraw.Geometry.Globals.PI

        'Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onearc)

        'Zoom in order to see the object.
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-30.0, -10.0), New VectorDraw.Geometry.gPoint(80.0, 50.0))
        'Redraw the document to see the above changes.
        VdFramedControl.BaseControl.ActiveDocument.Redraw(True)

    End Sub

    Private Sub butRect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butRect.Click
        butRect.Enabled = False
        'We will create a vdRect object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
        Dim onerect As VectorDraw.Professional.vdFigures.vdRect = New VectorDraw.Professional.vdFigures.vdRect()
        'We set the document where the rect is going to be added.This is important for the vdRect in order to obtain initial properties with setDocumentDefaults.
        onerect.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        onerect.setDocumentDefaults()

        'The two previus steps are important if a vdFigure object is going to be added to a document.
        'Now we will change some properties of the rect.
        onerect.InsertionPoint = New VectorDraw.Geometry.gPoint() 'Initial value for a gPoint is (0.0,0.0)
        onerect.Width = 40
        onerect.Height = 40
        onerect.PenColor.Red = 255
        onerect.PenColor.Blue = 0
        onerect.PenColor.Green = 0
        'This gives Depth to the vdFigure object visible in 3D.
        onerect.Thickness = 5.0
        'LineWeight is indipended from the zoom.
        onerect.LineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_140

        'Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onerect)

        'Zoom in order to see the object.
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-30.0, -10.0), New VectorDraw.Geometry.gPoint(80.0, 50.0))
        'Redraw the document to see the above changes.
        VdFramedControl.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub butText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butText.Click
        butText.Enabled = False
        'We will create a vdText object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
        Dim onetext As VectorDraw.Professional.vdFigures.vdText = New VectorDraw.Professional.vdFigures.vdText()
        'We set the document where the text is going to be added.This is important for the vdText in order to obtain initial properties with setDocumentDefaults.
        onetext.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        onetext.setDocumentDefaults()

        'The two previus steps are important if a vdFigure object is going to be added to a document.
        'Now we will change some properties of the text.
        onetext.PenColor.ColorIndex = 3
        onetext.TextString = "Vectordraw Development Framework"
        'vdText object with setDocumentDefaults has the STANDARD TextStyle.We will change the font of this textstyle to Verdana.
        VdFramedControl.BaseControl.ActiveDocument.TextStyles.Standard.FontFile = "Verdana"
        'We set the insertion point depending the width of the Text from the vdFigure's BoundingBox
        onetext.InsertionPoint = New VectorDraw.Geometry.gPoint(40.0 - onetext.BoundingBox.Width, 2)
        onetext.TextLine = VectorDraw.Render.grTextStyleExtra.TextLineFlags.OverLine
        'Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onetext)

        'Zoom in order to see the object.
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-30.0, -10.0), New VectorDraw.Geometry.gPoint(80.0, 50.0))
        'Redraw the document to see the above changes.
        VdFramedControl.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub butPoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butPoint.Click
        butPoint.Enabled = False
        'We change the global PointStyle and PointSize used for all added points.You can set these values to the property list using the 
        'PointStyle form by pressing the button at the right of these Document's properties.
        VdFramedControl.BaseControl.ActiveDocument.PointStyleMode = 36
        VdFramedControl.BaseControl.ActiveDocument.PointStyleSize = 1.2

        'We will create a vdPoint object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
        Dim onepoint As VectorDraw.Professional.vdFigures.vdPoint = New VectorDraw.Professional.vdFigures.vdPoint()
        'We set the document where the point is going to be added.This is important for the vdPoint in order to obtain initial properties with setDocumentDefaults.
        onepoint.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        onepoint.setDocumentDefaults()

        'The two previus steps are important if a vdFigure object is going to be added to a document.
        'Now we will change some properties of the point.
        onepoint.InsertionPoint = New VectorDraw.Geometry.gPoint(20, 22)
        onepoint.PenColor.ColorIndex = 1
        onepoint.ToolTip = "vdPoint object"

        'Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onepoint)

        'Zoom in order to see the object.
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-30.0, -10.0), New VectorDraw.Geometry.gPoint(80.0, 50.0))
        'Redraw the document to see the above changes.
        VdFramedControl.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub butImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butImage.Click
        butImage.Enabled = False
        'We will create a vdImage object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
        Dim oneimage As VectorDraw.Professional.vdFigures.vdImage = New VectorDraw.Professional.vdFigures.vdImage()
        'We set the document where the point is going to be added.This is important for the vdPoint in order to obtain initial properties with setDocumentDefaults.
        oneimage.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        oneimage.setDocumentDefaults()

        'The two previus steps are important if a vdFigure object is going to be added to a document.
        'Now we will change some properties of the point.
        oneimage.InsertionPoint = New VectorDraw.Geometry.gPoint(10, 1.1)
        oneimage.Width = 2.9


        'We add a new image definition to the document and set this object to be the ImageDef of this image.
        Dim path As String = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + "vdimage.bmp"
        oneimage.ImageDefinition = VdFramedControl.BaseControl.ActiveDocument.Images.Add(path)

        'Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(oneimage)

        'Zoom in order to see the object.
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-30.0, -10.0), New VectorDraw.Geometry.gPoint(80.0, 50.0))
        'Redraw the document to see the above changes.
        VdFramedControl.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub butDims_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDims.Click
        butDims.Enabled = False
        'To add a dimension object more easily see the command Action sample.
        'We will create vdDimension objects and add them to the Active Layout which is the basic Model Layout always existing in a Document.
        Dim onedim1 As VectorDraw.Professional.vdFigures.vdDimension = New VectorDraw.Professional.vdFigures.vdDimension()
        'We set the document where the dimension is going to be added.This is important for the vdDimension in order to obtain initial properties with setDocumentDefaults.
        onedim1.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        onedim1.setDocumentDefaults()

        'The two previus steps are important if a vdFigure object is going to be added to a document.
        'Now we will change some properties of the point.
        onedim1.PenColor.SystemColor = Color.BlanchedAlmond
        onedim1.dimType = VectorDraw.Professional.Constants.VdConstDimType.dim_Aligned
        onedim1.DefPoint1 = New VectorDraw.Geometry.gPoint(10, 10)
        onedim1.DefPoint2 = New VectorDraw.Geometry.gPoint(30, 30)
        onedim1.LinePosition = VectorDraw.Geometry.gPoint.Polar(New VectorDraw.Geometry.gPoint(10, 10), -VectorDraw.Geometry.Globals.HALF_PI / 2.0, 3)
        onedim1.Rotation = VectorDraw.Geometry.Globals.HALF_PI
        onedim1.ArrowSize = 2.0
        onedim1.TextHeight = 1.0

        'Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onedim1)

        'We also will add a diameter dimension.
        Dim onedim2 As VectorDraw.Professional.vdFigures.vdDimension = New VectorDraw.Professional.vdFigures.vdDimension()
        onedim2.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        onedim2.setDocumentDefaults()
        onedim2.PenColor.SystemColor = Color.Azure
        onedim2.dimType = VectorDraw.Professional.Constants.VdConstDimType.dim_Diameter
        onedim2.DefPoint1 = New VectorDraw.Geometry.gPoint(25, 30)
        onedim2.DefPoint2 = New VectorDraw.Geometry.gPoint(30, 30)
        onedim2.DefPoint3 = New VectorDraw.Geometry.gPoint(30, 30)
        onedim2.DefPoint4 = New VectorDraw.Geometry.gPoint(30, 30)
        onedim2.LinePosition = New VectorDraw.Geometry.gPoint(35, 30)
        onedim2.ArrowSize = 1.5
        onedim2.TextHeight = 0.8
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onedim2)


        'Zoom in order to see the object.
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-30.0, -10.0), New VectorDraw.Geometry.gPoint(80.0, 50.0))
        'Redraw the document to see the above changes.
        VdFramedControl.BaseControl.ActiveDocument.Redraw(True)

    End Sub

    Private Sub butInserts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butInserts.Click
        butInserts.Enabled = False
        'We will add a simple block at the Blocks collection consisting of two circles and one line.
        Dim circ1 As VectorDraw.Professional.vdFigures.vdCircle = New VectorDraw.Professional.vdFigures.vdCircle()
        circ1.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        circ1.setDocumentDefaults()
        circ1.Radius = 2.5

        Dim circ2 As VectorDraw.Professional.vdFigures.vdCircle = New VectorDraw.Professional.vdFigures.vdCircle()
        circ2.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        circ2.setDocumentDefaults()
        circ2.Radius = 5

        Dim line As VectorDraw.Professional.vdFigures.vdLine = New VectorDraw.Professional.vdFigures.vdLine()
        line.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        line.setDocumentDefaults()
        line.StartPoint = New VectorDraw.Geometry.gPoint(-2.5, 0)
        line.EndPoint = New VectorDraw.Geometry.gPoint(2.5, 0)
        'We check if the block already exists.
        If VdFramedControl.BaseControl.ActiveDocument.Blocks.FindName("BLK1") Is Nothing Then
            Dim blk As VectorDraw.Professional.vdPrimaries.vdBlock = VdFramedControl.BaseControl.ActiveDocument.Blocks.Add("BLK1")
            blk.Entities.AddItem(circ1)
            blk.Entities.AddItem(circ2)
            blk.Entities.AddItem(line)
            blk.Update()

            'Now we will add two inserts of this block to the Model layout.
            Dim ins1 As VectorDraw.Professional.vdFigures.vdInsert = New VectorDraw.Professional.vdFigures.vdInsert()
            ins1.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
            ins1.setDocumentDefaults()
            ins1.Block = VdFramedControl.BaseControl.ActiveDocument.Blocks.FindName("BLK1")
            ins1.InsertionPoint = New VectorDraw.Geometry.gPoint(10, 30)
            ins1.PenColor.ColorIndex = 55
            ins1.Rotation = VectorDraw.Geometry.Globals.HALF_PI
            VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(ins1)

            Dim ins2 As VectorDraw.Professional.vdFigures.vdInsert = New VectorDraw.Professional.vdFigures.vdInsert()
            ins2.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
            ins2.setDocumentDefaults()
            ins2.Block = VdFramedControl.BaseControl.ActiveDocument.Blocks.FindName("BLK1")
            ins2.InsertionPoint = New VectorDraw.Geometry.gPoint(30, 10)
            ins2.PenColor.ColorIndex = 75
            VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(ins2)
        End If
        'Zoom in order to see the object.
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-30.0, -10.0), New VectorDraw.Geometry.gPoint(80.0, 50.0))
        'Redraw the document to see the above changes.
        VdFramedControl.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub butPolyline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butPolyline.Click
        butPolyline.Enabled = False

        'We will create a vdPolyline object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
        Dim onepoly As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline()
        'We set the document where the polyline is going to be added.This is important for the vdPolyline in order to obtain initial properties with setDocumentDefaults.
        onepoly.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        onepoly.setDocumentDefaults()

        'The two previus steps are important if a vdFigure object is going to be added to a document.
        'Now we will change some properties of the polyline.
        onepoly.VertexList.Add(New VectorDraw.Geometry.gPoint(-10, -10))
        onepoly.VertexList.Add(New VectorDraw.Geometry.gPoint(50, -10))
        onepoly.VertexList.Add(New VectorDraw.Geometry.Vertex(50, 50, 0, 0.5))
        onepoly.VertexList.Add(New VectorDraw.Geometry.Vertex(20, 70, 0, 0.5))
        onepoly.VertexList.Add(New VectorDraw.Geometry.Vertex(-10, 50, 0))
        onepoly.Flag = VectorDraw.Professional.Constants.VdConstPlineFlag.PlFlagCLOSE
        onepoly.PenColor.ColorIndex = 200

        'Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onepoly)

        'Zoom in order to see the object.
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-30.0, -10.0), New VectorDraw.Geometry.gPoint(80.0, 50.0))
        'Redraw the document to see the above changes.
        VdFramedControl.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub butSpline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSpline.Click

        butSpline.Enabled = False
        'We will create a vdPolyline object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
        Dim onepoly As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline()
        'We set the document where the polyline is going to be added.This is important for the vdPolyline in order to obtain initial properties with setDocumentDefaults.
        onepoly.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        onepoly.setDocumentDefaults()

        'The two previus steps are important if a vdFigure object is going to be added to a document.
        'Now we will change some properties of the polyline.
        onepoly.VertexList.Add(New VectorDraw.Geometry.gPoint(10, 60))
        onepoly.VertexList.Add(New VectorDraw.Geometry.gPoint(30, 60))
        onepoly.VertexList.Add(New VectorDraw.Geometry.gPoint(30, 50))
        onepoly.VertexList.Add(New VectorDraw.Geometry.gPoint(10, 50))
        onepoly.ToolTip = "vdPolyline Quadratic"
        onepoly.Flag = VectorDraw.Professional.Constants.VdConstPlineFlag.PlFlagCLOSE
        onepoly.SPlineFlag = VectorDraw.Professional.Constants.VdConstSplineFlag.SFlagQUADRATIC
        onepoly.PenColor.SystemColor = Color.Red
        'Now we will change the hacth properties of this polyline.Hatch propertis have all curve figures(circle,arc,ellipse,rect,polyline).
        'Initialize the hatch properties object.
        onepoly.HatchProperties = New VectorDraw.Professional.vdObjects.vdHatchProperties()
        'And change it's properties
        onepoly.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid
        onepoly.HatchProperties.FillColor.ColorIndex = 156

        'Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onepoly)

        'Zoom in order to see the object.
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-30.0, -10.0), New VectorDraw.Geometry.gPoint(80.0, 50.0))
        'Redraw the document to see the above changes.
        VdFramedControl.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub buthatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buthatch.Click
        buthatch.Enabled = False
        'We will create a vdPolyHatch object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
        Dim onehatch As VectorDraw.Professional.vdFigures.vdPolyhatch = New VectorDraw.Professional.vdFigures.vdPolyhatch()
        'We set the document where the hatch is going to be added.This is important for the vdPolyhatch in order to obtain initial properties with setDocumentDefaults.
        onehatch.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        onehatch.setDocumentDefaults()

        'The two previus steps are important if a vdFigure object is going to be added to a document.
        'Now we will change some properties of the hatch.

        'First we will set the polycurves of the hatch.We will add the rect the spline and the polyline(with bulges) as one curves collection each.Each curves collection added to the hatch 
        'must be a closed sum of entities.
        Dim var As VectorDraw.Professional.vdPrimaries.vdFigure
        For Each var In VdFramedControl.BaseControl.ActiveDocument.Model.Entities
            If (TypeOf var Is VectorDraw.Professional.vdFigures.vdPolyline) Or (TypeOf var Is VectorDraw.Professional.vdFigures.vdRect) Then
                If TypeOf var Is VectorDraw.Professional.vdFigures.vdImage Then
                    Continue For
                End If
                Dim curves As VectorDraw.Professional.vdCollections.vdCurves = New VectorDraw.Professional.vdCollections.vdCurves()
                curves.AddItem(var.Clone(VdFramedControl.BaseControl.ActiveDocument))
                onehatch.PolyCurves.AddItem(curves)
            End If
        Next

        If onehatch.PolyCurves.Count > 2 Then

            onehatch.HatchProperties = New VectorDraw.Professional.vdObjects.vdHatchProperties()
            onehatch.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModePattern
            onehatch.HatchProperties.HatchPattern = VdFramedControl.BaseControl.ActiveDocument.HatchPatterns.FindName("STARS")
            onehatch.HatchProperties.HatchScale = 0.5
            onehatch.HatchProperties.FillColor.SystemColor = Color.Blue
            onehatch.HatchProperties.FillBkColor.SystemColor = Color.Aquamarine


            'Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
            VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onehatch)

            'Zoom in order to see the object.
            VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-30.0, -10.0), New VectorDraw.Geometry.gPoint(80.0, 50.0))
            'Redraw the document to see the above changes.
            VdFramedControl.BaseControl.ActiveDocument.Redraw(True)
        Else
            buthatch.Enabled = True
            MessageBox.Show("Please Add All entities for better result.")
        End If
    End Sub

    Private Sub butMtext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMtext.Click
        butMtext.Enabled = False
        'We will create a vdMText object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
        Dim onemtext As VectorDraw.Professional.vdFigures.vdMText = New VectorDraw.Professional.vdFigures.vdMText()
        'We set the document where the Mtext is going to be added.This is important for the vdMText in order to obtain initial properties with setDocumentDefaults.
        onemtext.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        onemtext.setDocumentDefaults()

        'The two previus steps are important if a vdFigure object is going to be added to a document.
        'Now we will change some properties of the text.
        onemtext.InsertionPoint = New VectorDraw.Geometry.gPoint(20, -15)
        onemtext.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        onemtext.BoxWidth = 30
        onemtext.TextString = "\C1;\H5.0;VectorDraw \C2;\H3.5;Development \C3;\H2.5;Framework"
        '             
        '             \0...\o             Turns overline on and off 
        '             \L...\l               Turns underline on and off 
        '             \\                      Inserts a backslash 
        '             \
        '             {
        '             	...\
        '             }
        '                 Inserts an opening and closing brace
        '             \Cindex        Changes to the  specified color 
        '             \Hvalue       Changes to the text height specified in drawing units 
        '             \Hvaluex     Changes the text height  to a multiple of the current text height 
        '             \Tvalue       Adjusts the space between characters, from .75 to 4 times 
        '             \Qangle      Changes obliquing angle 
        '             \Wvalue     Changes width factor to produce wide text 
        '             \Ffile name Changes to the specified font file  
        '             \A                   Sets the alignment value valid values: 0, 1, 2 
        '             \P                   Ends paragraph 
        '             \S...^...         Stacks the subsequent text at the \, #, or ^ symbol 
        '             */



        'Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onemtext)

        'Zoom in order to see the object.
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-30.0, -10.0), New VectorDraw.Geometry.gPoint(80.0, 50.0))
        'Redraw the document to see the above changes.
        VdFramedControl.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub but3dobjects_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles but3dobjects.Click
        but3dobjects.Enabled = False
        'We will create a vdPolyface object and add it to the Active Layout which is the basic Model Layout always existing in a Document.
        Dim onepolyface As VectorDraw.Professional.vdFigures.vdPolyface = New VectorDraw.Professional.vdFigures.vdPolyface()
        'We set the document where the polyface is going to be added.This is important for the vdPolyface in order to obtain initial properties with setDocumentDefaults.
        onepolyface.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        onepolyface.setDocumentDefaults()

        'The two previus steps are important if a vdFigure object is going to be added to a document.
        'Now we will change some properties of the circle.
        onepolyface.VertexList.Add(New VectorDraw.Geometry.gPoint(-10, 85))
        onepolyface.VertexList.Add(New VectorDraw.Geometry.gPoint(-10, 75))
        onepolyface.VertexList.Add(New VectorDraw.Geometry.gPoint(0, 85, 10))
        onepolyface.VertexList.Add(New VectorDraw.Geometry.gPoint(0, 75, 10))
        onepolyface.VertexList.Add(New VectorDraw.Geometry.gPoint(10, 85))
        onepolyface.VertexList.Add(New VectorDraw.Geometry.gPoint(10, 75))
        onepolyface.VertexList.Add(New VectorDraw.Geometry.gPoint(20, 85, 10))
        onepolyface.VertexList.Add(New VectorDraw.Geometry.gPoint(20, 75, 10))
        onepolyface.VertexList.Add(New VectorDraw.Geometry.gPoint(30, 85))
        onepolyface.VertexList.Add(New VectorDraw.Geometry.gPoint(30, 75))
        onepolyface.VertexList.Add(New VectorDraw.Geometry.gPoint(40, 85, 10))
        onepolyface.VertexList.Add(New VectorDraw.Geometry.gPoint(40, 75, 10))
        onepolyface.VertexList.Add(New VectorDraw.Geometry.gPoint(50, 85))
        onepolyface.VertexList.Add(New VectorDraw.Geometry.gPoint(50, 75))

        onepolyface.AddFaceItem(1, 2, 4, 3, 1)
        onepolyface.AddFaceItem(3, 4, 6, 5, 2)
        onepolyface.AddFaceItem(5, 6, 8, 7, 3)
        onepolyface.AddFaceItem(7, 8, 10, 9, 4)
        onepolyface.AddFaceItem(9, 10, 12, 11, 5)
        onepolyface.AddFaceItem(11, 12, 14, 13, 6)

        'Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(onepolyface)

        'We change the active pen color so the created(and added to the document by the cmdSphere function) spheres will take this color.More information about command action functions in other sample.
        VdFramedControl.BaseControl.ActiveDocument.ActivePenColor.ColorIndex = 9
        VdFramedControl.BaseControl.ActiveDocument.CommandAction.CmdSphere(New VectorDraw.Geometry.gPoint(-15, 80), 5.0, 10, 10)
        VdFramedControl.BaseControl.ActiveDocument.CommandAction.CmdSphere(New VectorDraw.Geometry.gPoint(55, 80), 5.0, 10, 10)

        'Zoom in order to see the object.
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-30.0, -10.0), New VectorDraw.Geometry.gPoint(100.0, 50.0))
        'Redraw the document to see the above changes.
        VdFramedControl.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub ButConstructionLines_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButConstructionLines.Click
        ButConstructionLines.Enabled = False

        'We will AddEntities 2 construction lines.
        Dim ConstructionLine As New VectorDraw.Professional.vdFigures.vdInfinityLine
        'We set the document where the ConstructionLines are going to be added.This is important for the vdInfinityLine object in order to obtain initial properties with setDocumentDefaults.
        ConstructionLine.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        ConstructionLine.setDocumentDefaults()
        'Now we will change some properties of the vdInfinityLine.
        ConstructionLine.BasePoint = New VectorDraw.Geometry.gPoint(19.3, -12.4)
        ConstructionLine.Direction = New VectorDraw.Geometry.Vector(1.0, 0.0, 0.0)
        ConstructionLine.PenColor.ColorIndex = 3
        'And also we set the type of the construction line (Ray or Xline).
        ConstructionLine.InfinityType = VectorDraw.Professional.vdFigures.vdInfinityLine.InfinityTypes.XLine

        'The vdInfinityLine has to be added to the document.
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(ConstructionLine)

        'And another one but Ray this time...
        ConstructionLine = New VectorDraw.Professional.vdFigures.vdInfinityLine()
        'We set the document where the ConstructionLines are going to be added.This is important for the vdInfinityLine object in order to obtain initial properties with setDocumentDefaults.
        ConstructionLine.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        ConstructionLine.setDocumentDefaults()
        'Now we will change some properties of the vdInfinityLine.
        ConstructionLine.BasePoint = New VectorDraw.Geometry.gPoint(-25.0, -12.4)
        ConstructionLine.Direction = New VectorDraw.Geometry.Vector(0.0, 1.0, 0.0)
        ConstructionLine.PenColor.ColorIndex = 2
        'And also we set the type of the construction line (Ray or Xline).
        ConstructionLine.InfinityType = VectorDraw.Professional.vdFigures.vdInfinityLine.InfinityTypes.Ray

        'The vdInfinityLine has to be added to the document.
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(ConstructionLine)

        'Zoom in order to see the object.
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-100.0, -40.0), New VectorDraw.Geometry.gPoint(140.0, 90.0))
        'Redraw the document to see the above changes.
        VdFramedControl.BaseControl.ActiveDocument.Redraw(True)
    End Sub
   

    Private Sub butSurf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butSurf.Click
        Dim frm As Form2 = New Form2()
        frm.ShowDialog(Me)
    End Sub

#Region "ROTATE"

    Dim degrees As Double = 0.0
    Private WithEvents mtimer As Timer = New Timer()
    Private Sub mtimer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles mtimer.Tick
        If degrees > 360.0 Then
            degrees = 0.0
        End If
        degrees += 1.0
        Dim matt As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix()
        matt.RotateXMatrix(VectorDraw.Geometry.Globals.DegreesToRadians(degrees))
        matt.RotateYMatrix(VectorDraw.Geometry.Globals.DegreesToRadians(degrees))
        matt.RotateZMatrix(VectorDraw.Geometry.Globals.DegreesToRadians(degrees))
        Console.WriteLine(degrees.ToString())
        VdFramedControl.BaseControl.ActiveDocument.Model.World2ViewMatrix = matt
        VdFramedControl.BaseControl.ActiveDocument.Redraw(False)
    End Sub


    Private Sub checkRot_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles checkRot.CheckedChanged
        mtimer.Interval = 80
        If (checkRot.Checked) Then
            VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-140.0, -70.0), New VectorDraw.Geometry.gPoint(140.0, 100.0))
            mtimer.Start()
        Else
            mtimer.Stop()
        End If
    End Sub
#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

   
    
    Private Sub butLeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butLeader.Click

        butLeader.Enabled = False
        'We will add 2 vdLeader objects with Low Level code changing some basic properties of the object that affect it's appearence.
        Dim lead1 As VectorDraw.Professional.vdFigures.vdLeader = New VectorDraw.Professional.vdFigures.vdLeader()
        'We set the document where the leader is going to be added.This is important for the vdLeader in order to obtain initial properties with setDocumentDefaults.
        lead1.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        lead1.setDocumentDefaults()
        'Now we will change some properties of the leader.
        lead1.VertexList.Add(New VectorDraw.Geometry.gPoint(60.0, 30.0))
        lead1.VertexList.Add(New VectorDraw.Geometry.gPoint(75.0, 50.0))
        lead1.VertexList.Add(New VectorDraw.Geometry.gPoint(78.0, 60.0))
        lead1.ArrowSize = 5.0
        lead1.PenColor.ColorIndex = 169

        'We will create an Mtext object (described above) and we will give it to the leader object.
        Dim mtext1 As VectorDraw.Professional.vdFigures.vdMText = New VectorDraw.Professional.vdFigures.vdMText()
        mtext1.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        mtext1.setDocumentDefaults()
        mtext1.InsertionPoint = New VectorDraw.Geometry.gPoint(81.5, 61.5)
        mtext1.TextString = "\C1;\H5.0;VectorDraw Objects"
        mtext1.BoxWidth = 40.0
        mtext1.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerBottom
        mtext1.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorLeft
       
        'Assign the Mtext to the Leader object.
        lead1.LeaderMText = mtext1
        lead1.Update()
        lead1.Invalidate()
        'Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(lead1)
        'The Mtext has to be added to the document also after the vdLeader.
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(mtext1)


        'And we add the second Leader object...
        Dim lead2 As VectorDraw.Professional.vdFigures.vdLeader = New VectorDraw.Professional.vdFigures.vdLeader()
        lead2.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        lead2.setDocumentDefaults()
        lead2.VertexList.Add(New VectorDraw.Geometry.gPoint(-20.0, 30.0))
        lead2.VertexList.Add(New VectorDraw.Geometry.gPoint(-38.0, 45.0))
        lead2.VertexList.Add(New VectorDraw.Geometry.gPoint(-38.0, 60.0))
        lead2.ArrowSize = 5.0
        lead2.PenColor.ColorIndex = 230
        lead2.LeaderType = VectorDraw.Professional.vdFigures.vdLeader.DimLeaderType.Spline_with_arrow

        Dim mtext2 As VectorDraw.Professional.vdFigures.vdMText = New VectorDraw.Professional.vdFigures.vdMText()
        mtext2.SetUnRegisterDocument(VdFramedControl.BaseControl.ActiveDocument)
        mtext2.setDocumentDefaults()
        mtext2.InsertionPoint = New VectorDraw.Geometry.gPoint(-41.5, 61.5)
        mtext2.TextString = "\H5.0;VectorDraw Objects"
        mtext2.BoxWidth = 40.0
        mtext2.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerBottom
        mtext2.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorRight
        mtext2.PenColor.ColorIndex = 230       
        lead2.LeaderMText = mtext2
        lead2.Update()
        lead2.Invalidate()
        'Now we will add this object to the Entities collection of the Model Layout(ActiveLayout).
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(lead2)
        'The Mtext2 has to be added to the document also after the vdLeader.
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(mtext2)


        'Zoom in order to see the object.
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-100.0, -40.0), New VectorDraw.Geometry.gPoint(140.0, 90.0))
        'Redraw the document to see the above changes.
        VdFramedControl.BaseControl.ActiveDocument.Redraw(True)

    End Sub

    Private Sub butMultiline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butMultiline.Click

        butMultiline.Enabled = False

        'Create a vdMultiline object
        Dim line As VectorDraw.Professional.vdFigures.vdMultiline = New VectorDraw.Professional.vdFigures.vdMultiline(VdFramedControl.BaseControl.ActiveDocument)
        line.VertexList.Add(New VectorDraw.Geometry.Vertex(63, 5, 0))
        line.VertexList.Add(New VectorDraw.Geometry.Vertex(80, 25, 0))
        line.VertexList.Add(New VectorDraw.Geometry.Vertex(110, 25, 0))
        line.VertexList.Add(New VectorDraw.Geometry.Vertex(127, 5, 0))
        line.ScaleFactor = 10.0

        'The vdMultiline has to be added to the document.
        VdFramedControl.BaseControl.ActiveDocument.Model.Entities.AddItem(line)

        'Create a vdMultilineStyle object with 4 Element lines
        Dim mLine As VectorDraw.Professional.vdPrimaries.vdMultilineStyle = New VectorDraw.Professional.vdPrimaries.vdMultilineStyle(VdFramedControl.BaseControl.ActiveDocument, "Test")

        '1st Element
        Dim elem As VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement = New VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement()
        elem.ElementColor.ColorIndex = 0
        elem.ElementLineType = VdFramedControl.BaseControl.ActiveDocument.LineTypes.FindName("DASHDOT0")
        elem.ElementLineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_120
        elem.Offset = 1.0
        mline.Elements.Add(elem)

        'Second Element
        elem = New VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement()
        elem.ElementColor.ColorIndex = 1
        elem.ElementLineType = VdFramedControl.BaseControl.ActiveDocument.LineTypes.FindName("DASHDOTDOT0")
        elem.Offset = 0.25
        mline.Elements.Add(elem)

        'Third Element
        elem = New VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement()
        elem.ElementColor.ColorIndex = 1
        elem.ElementLineType = VdFramedControl.BaseControl.ActiveDocument.LineTypes.FindName("DASHDOTDOT0")
        elem.Offset = -0.25
        mline.Elements.Add(elem)

        'Fourth Element
        elem = New VectorDraw.Professional.vdPrimaries.vdMultilineStyleElement()
        elem.ElementColor.ColorIndex = 0
        elem.ElementLineType = VdFramedControl.BaseControl.ActiveDocument.LineTypes.FindName("DASHDOT0")
        elem.Offset = -1.0
        mline.Elements.Add(elem)

        'Other MultilineStyle properties
        mline.StartAngle = VectorDraw.Geometry.Globals.DegreesToRadians(90.0)
        mline.EndAngle = VectorDraw.Geometry.Globals.DegreesToRadians(90.0)
        mLine.Flags = mLine.Flags Or VectorDraw.Professional.Constants.VdMultilineFlags.Start_Square_Line
        mLine.Flags = mLine.Flags Or VectorDraw.Professional.Constants.VdMultilineFlags.End_Square_Line
        mLine.Flags = mLine.Flags Or VectorDraw.Professional.Constants.VdMultilineFlags.DisplayMiters
        mLine.Flags = mLine.Flags Or VectorDraw.Professional.Constants.VdMultilineFlags.Start_Outer_Arc
        mLine.Flags = mLine.Flags Or VectorDraw.Professional.Constants.VdMultilineFlags.Start_Inner_Arc
        mLine.Flags = mLine.Flags Or VectorDraw.Professional.Constants.VdMultilineFlags.End_Inner_Arc
        mLine.Flags = mLine.Flags Or VectorDraw.Professional.Constants.VdMultilineFlags.End_Outer_Arc
        mline.Update()

        'Add the MultilineStyle to the Document's collection
        VdFramedControl.BaseControl.ActiveDocument.MultilineStyles.AddItem(mline)

        'Assign the newlly created MultilineStyle to the Multiline.
        line.Invalidate()
        line.MultilineStyle = mline
        line.Update()
        line.Invalidate()

        'Zoom in order to see the object.
        VdFramedControl.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New VectorDraw.Geometry.gPoint(-100.0, -40.0), New VectorDraw.Geometry.gPoint(140.0, 90.0))
        'Redraw the document to see the above changes.
        VdFramedControl.BaseControl.ActiveDocument.Redraw(True)
    End Sub
End Class
