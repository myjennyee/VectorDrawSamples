' This sample project aims to present the new boolean operations developed in the Vectordraw framework.
' You can check the capabilities by using the four different buttons. 
Public Class Form1
    Private Sub globalTimer_Tick(ByVal sender As Object, ByVal e As EventArgs)
        demo()
    End Sub
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        AddHandler globalTimer.Tick, AddressOf Me.globalTimer_Tick
        globalTimer.Start()
    End Sub
    ReadOnly Property doc() As VectorDraw.Professional.vdObjects.vdDocument
        Get
            Return vdraw.ActiveDocument
        End Get
    End Property
    Private Sub createScene(ByVal state As Integer)

        If state = 2 Then
            doc.CommandAction.CmdBox3d(New VectorDraw.Geometry.gPoint(-1.5, -1.5, -1.5), 3, 3, 3, 0)

        ElseIf state = 3 Then
            'doc.CommandAction.CmdSphere(new VectorDraw.Geometry.gPoint(0, 0, 0), 1.8, 20, 20)
            doc.CommandAction.CmdTorus(New VectorDraw.Geometry.gPoint(0, 0, 0), 1.9, 0.5, 20, 20)
            doc.CommandAction.CmdRotate3d("x", doc.Model.Entities.Last, New VectorDraw.Geometry.gPoint(), 45.0)
            doc.CommandAction.CmdRotate3d("y", doc.Model.Entities.Last, New VectorDraw.Geometry.gPoint(), 45.0)
            doc.Model.Entities.Last.Update()
        End If
    End Sub
    Private Sub initDoc()
        doc.[New]()
        VectorDraw.Professional.ActionUtilities.vdCommandAction.View3D_VTop(doc)
        doc.RenderMode = VectorDraw.Render.vdRender.Mode.ShadeOn
        doc.Redraw(True)
        doc.CommandAction.Zoom("w", New VectorDraw.Geometry.gPoint(-11, -10), New VectorDraw.Geometry.gPoint(10, 10))
        doc.GlobalRenderProperties.SelectionPreview = VectorDraw.Render.vdRenderGlobalProperties.SelectionPreviewFlags.ON
        doc.FreezeActions = True
    End Sub
    Dim step1 As Integer = 1
    Dim globalTimer As Timer = New Timer()
    Dim mergedPlface As VectorDraw.Professional.vdFigures.vdPolyface = Nothing
    Dim txt As VectorDraw.Professional.vdFigures.vdText = Nothing
    Private Sub demo()
        globalTimer.Stop()

        Dim delay As Integer = 1000
        If step1 = 1 Then
            initDoc()
        ElseIf step1 = 2 Then
            createScene(2)
            doc.Redraw(True)
        ElseIf step1 = 3 Then
            createScene(3)
            doc.Redraw(True)
        ElseIf step1 = 4 Then
            PerformOperation(VectorDraw.Professional.vdFigures.BooleanOperation.Union, Color.FromArgb(255, 200, 200))
        ElseIf step1 > 4 And step1 < 15 Then
            delay = 50
            translatePlFaces(New VectorDraw.Geometry.gPoint(-1, 0.5))
        ElseIf step1 = 15 Then
            PerformOperation(VectorDraw.Professional.vdFigures.BooleanOperation.Intersection, Color.FromArgb(200, 255, 200))
        ElseIf step1 > 15 And step1 < 26 Then
            delay = 50
            translatePlFaces(New VectorDraw.Geometry.gPoint(1, 0.5))
        ElseIf (step1 = 26) Then
            PerformOperation(VectorDraw.Professional.vdFigures.BooleanOperation.Substraction, Color.FromArgb(200, 200, 255))
        ElseIf (step1 > 26 And step1 < 37) Then
            delay = 50
            translatePlFaces(New VectorDraw.Geometry.gPoint(1, -0.5))
        ElseIf (step1 = 37) Then
            PerformOperation(VectorDraw.Professional.vdFigures.BooleanOperation.ReverseSubsctraction, Color.FromArgb(255, 255, 200))
        ElseIf (step1 > 37 And step1 < 48) Then
            delay = 50
            translatePlFaces(New VectorDraw.Geometry.gPoint(-1, -0.5))
        Else
            endDemo()
            Return
        End If

        step1 += 1
        globalTimer.Interval = delay
        globalTimer.Start()
    End Sub

    Private Sub endDemo()
        buttonIntersection.Enabled = True
        buttonRevSubstraction.Enabled = True
        buttonUnion.Enabled = True
        buttonSubstract.Enabled = True
        doc.FreezeActions = False
    End Sub

    'This function handles the several boolean operations.
    Private Sub PerformOperation(ByRef operation As VectorDraw.Professional.vdFigures.BooleanOperation, ByRef color As Color)
        Dim plface1 As VectorDraw.Professional.vdFigures.vdPolyface = doc.Model.Entities(0) 'as VectorDraw.Professional.vdFigures.vdPolyface
        Dim plface2 As VectorDraw.Professional.vdFigures.vdPolyface = doc.Model.Entities(1) 'as VectorDraw.Professional.vdFigures.vdPolyface

        'The result of every boolean operation are triangles.
        Dim triangles As VectorDraw.Geometry.gTriangles = VectorDraw.Professional.vdFigures.vdPolyface.CombinePolyfaces(plface1, plface2, operation)

        mergedPlface = New VectorDraw.Professional.vdFigures.vdPolyface(doc)
        'Triangles with zero area are removed from the collection.
        triangles.RemoveZeroAreaTriangles()
        'All the created triangles are merged in this polyface object. This object is now the result of the boolean operation.
        mergedPlface.MergeTriangles(triangles)
        mergedPlface.PenColor = New VectorDraw.Professional.vdObjects.vdColor(color)

        txt = New VectorDraw.Professional.vdFigures.vdText(doc, operation.ToString(), New VectorDraw.Geometry.gPoint(), 1)
        txt.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        txt.InsertionPoint = New VectorDraw.Geometry.gPoint(0, 2)

        doc.Model.Entities.AddItem(mergedPlface)
        doc.Model.Entities.AddItem(txt)
        doc.Redraw(True)
    End Sub
    'Used to move the result polyface.
    Private Sub translatePlFaces(ByRef p As VectorDraw.Geometry.gPoint)
        doc.CommandAction.CmdMove(mergedPlface, New VectorDraw.Geometry.gPoint(0, 0, 0), p)
        txt.InsertionPoint = mergedPlface.BoundingBox.MidPoint + New VectorDraw.Geometry.gPoint(0, 2)
        txt.Update()
        doc.Invalidate()
    End Sub

    Private Sub buttonUnion_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonUnion.Click
        If (Not doc.CommandAction.CmdCombinePolyfaces(Nothing, Nothing, VectorDraw.Professional.vdFigures.BooleanOperation.Union)) Then
            Return
        End If
    End Sub

    Private Sub buttonSubstract_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonSubstract.Click
        If (Not doc.CommandAction.CmdCombinePolyfaces(Nothing, Nothing, VectorDraw.Professional.vdFigures.BooleanOperation.Substraction)) Then
            Return
        End If
    End Sub

    Private Sub buttonIntersection_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonIntersection.Click
        If (Not doc.CommandAction.CmdCombinePolyfaces(Nothing, Nothing, VectorDraw.Professional.vdFigures.BooleanOperation.Intersection)) Then
            Return
        End If
    End Sub

    Private Sub buttonRevSubstraction_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonRevSubstraction.Click
        If (Not doc.CommandAction.CmdCombinePolyfaces(Nothing, Nothing, VectorDraw.Professional.vdFigures.BooleanOperation.ReverseSubsctraction)) Then
            Return
        End If
    End Sub

    Private Sub buttonCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonCancel.Click
        globalTimer.Stop()
        initDoc()
        createScene(2)
        createScene(3)
        endDemo()
    End Sub
End Class
