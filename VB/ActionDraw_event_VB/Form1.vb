Public Class Form1

    WithEvents doc As VectorDraw.Professional.vdObjects.vdDocument

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        doc = vdSC.BaseControl.ActiveDocument
        Me.vdSC.BaseControl.ActiveDocument.ShowUCSAxis = False
        Me.vdSC.BaseControl.ActiveDocument.FreezeEntityDrawEvents.Push(False)
    End Sub

    Private Sub btLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btLine.Click
        Me.vdSC.BaseControl.ActiveDocument.CommandAction.CmdLine("USER")
    End Sub

    Private Sub doc_OnActionDraw(ByVal sender As Object, ByVal action As Object, ByVal isHideMode As Boolean, ByRef cancel As Boolean) Handles doc.OnActionDraw
        If Not (chkBox.Checked) Then Return
        If Not (TypeOf action Is VectorDraw.Actions.ActionGetRefPoint) Then Return
        Dim act As VectorDraw.Actions.BaseAction = action
        Dim refpoint As VectorDraw.Geometry.gPoint = act.ReferencePoint
        Dim currentpoint As VectorDraw.Geometry.gPoint = act.OrthoPoint
        Dim circle As VectorDraw.Professional.vdFigures.vdCircle = New VectorDraw.Professional.vdFigures.vdCircle()
        circle.SetUnRegisterDocument(vdSC.BaseControl.ActiveDocument)
        circle.setDocumentDefaults()
        circle.Center = VectorDraw.Geometry.gPoint.MidPoint(refpoint, currentpoint)
        circle.Radius = circle.Center.Distance3D(refpoint)
        circle.Draw(act.Render)
    End Sub

    Private Sub doc_OnFigureDrawGrips(ByVal sender As Object, ByVal render As VectorDraw.Render.vdRender, ByRef cancel As Boolean) Handles doc.OnFigureDrawGrips
        If (sender Is Nothing) Then Exit Sub
        If (Not chkBox_GripDraw.Checked) Then Exit Sub
        Dim mat As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix(render.CurrentMatrix)
        render.PushToViewMatrix() ' do these 3 lines in the start of the EVENT and do not break them

        Dim fig As VectorDraw.Professional.vdPrimaries.vdFigure = sender
        Dim gripPTs As VectorDraw.Geometry.gPoints
        Dim gripPT As VectorDraw.Geometry.gPoint
        Dim circ As New VectorDraw.Professional.vdFigures.vdCircle
        circ.SetUnRegisterDocument(doc)
        circ.setDocumentDefaults()
        circ.HatchProperties = New VectorDraw.Professional.vdObjects.vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid)
        circ.Radius = render.PixelSize * 10.0
        circ.HatchProperties.FillColor.SystemColor = Color.Red
        gripPTs = fig.GetGripPoints()
        Dim tmpPt As VectorDraw.Geometry.gPoint = New VectorDraw.Geometry.gPoint()
        For Each gripPT In gripPTs
            tmpPt = mat.Transform(gripPT)
            circ.Center = tmpPt
            circ.Draw(render)
            circ.Update()
        Next
        cancel = 1
        render.PopMatrix() ' GETTING THE VIEW MATRIX TO mat
    End Sub

    Private Sub chkBox_GripDraw_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBox_GripDraw.CheckedChanged
        vdSC.BaseControl.Redraw()
    End Sub
End Class
