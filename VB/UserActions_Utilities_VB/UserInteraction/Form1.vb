Imports VectorDraw.Professional.vdCollections
Imports VectorDraw.Geometry
Imports VectorDraw.Render
Imports VectorDraw.Serialize
Imports VectorDraw.Generics
Imports VectorDraw.Professional.vdFigures
Imports VectorDraw.Professional.vdPrimaries
Imports VectorDraw.Professional.vdObjects

Public Class Form1

    Dim ShowActionEntities As Boolean
    ReadOnly Property doc() As VectorDraw.Professional.vdObjects.vdDocument
        Get
            Return vd.BaseControl.ActiveDocument
        End Get
    End Property

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MessageBox.Show("This sample is provided to show you ways to interact with users.Here you can find useful functions to create your own commands.")
        ShowActionEntities = False
        AddHandler doc.OnActionDraw, AddressOf doc_OnActionDraw
    End Sub
    Private Sub doc_OnActionDraw(ByVal sender As Object, ByVal action As Object, ByVal isHideMode As Boolean, ByRef cancel As Boolean) 'Handles doc.OnActionDraw
        If Not ShowActionEntities Then Return
        Dim act As VectorDraw.Actions.BaseAction = action
        Dim refpoint As VectorDraw.Geometry.gPoint = act.ReferencePoint
        Dim currentpoint As VectorDraw.Geometry.gPoint = act.OrthoPoint

        If refpoint = Nothing Or currentpoint = Nothing Then
            Exit Sub
        End If

        Dim line As New VectorDraw.Professional.vdFigures.vdLine
        line.SetUnRegisterDocument(vd.BaseControl.ActiveDocument)
        line.setDocumentDefaults()
        line.StartPoint = New VectorDraw.Geometry.gPoint(refpoint)
        line.EndPoint = New VectorDraw.Geometry.gPoint(refpoint.Polar(0.0, refpoint.Distance3D(currentpoint)))
        line.PenColor.SystemColor = Color.Orange
        line.Draw(act.Render)

        Dim arc = New VectorDraw.Professional.vdFigures.vdArc
        arc.SetUnRegisterDocument(vd.BaseControl.ActiveDocument)
        arc.setDocumentDefaults()
        arc.Radius = refpoint.Distance3D(currentpoint)
        arc.Center = New VectorDraw.Geometry.gPoint(refpoint)
        arc.StartAngle = 0.0
        arc.EndAngle = VectorDraw.Geometry.Globals.GetAngle(refpoint, currentpoint)
        arc.PenColor.SystemColor = Color.Orange
        arc.Draw(act.Render)
    End Sub

    Private Sub AddSomeEntities()
        Dim circ As New VectorDraw.Professional.vdFigures.vdCircle
        vd.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(circ)
        circ.setDocumentDefaults()
        circ.PenColor.SystemColor = Color.Red
        circ.Center = New gpoint(5, 5)
        circ.Radius = 2.0

        circ = New VectorDraw.Professional.vdFigures.vdCircle
        vd.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(circ)
        circ.setDocumentDefaults()
        circ.PenColor.SystemColor = Color.Blue
        circ.Center = New gPoint(10, 5)
        circ.Radius = 2

        circ = New VectorDraw.Professional.vdFigures.vdCircle
        vd.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(circ)
        circ.setDocumentDefaults()
        circ.PenColor.SystemColor = Color.Green
        circ.Center = New gPoint(15, 5)
        circ.Radius = 2

        vd.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(New gPoint(), New gPoint(20, 15))
        vd.BaseControl.ActiveDocument.Redraw(True)
    End Sub

    Private Sub ButGetPoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButGetPoint.Click
        vd.BaseControl.ActiveDocument.[New]()
        Dim userpoint As VectorDraw.Geometry.gPoint
        vd.BaseControl.ActiveDocument.Prompt("Select a Point:")
        'The user can either click a point or type at the command line a point like 5,5,2
        Dim ret As VectorDraw.Actions.StatusCode
        userpoint = Nothing
        ret = vd.BaseControl.ActiveDocument.ActionUtility.getUserPoint(userpoint)
        vd.BaseControl.ActiveDocument.Prompt(Nothing)
        If ret = VectorDraw.Actions.StatusCode.Success Then
            MessageBox.Show("The user selected: x:" + userpoint.x.ToString() + "  y:" + userpoint.y.ToString() + "  z:" + userpoint.z.ToString() + " In UCS(user coordinate system)")
        End If
    End Sub
    Private Sub ButUserRect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButUserRect.Click
        vd.BaseControl.ActiveDocument.[New]()
        AddSomeEntities()

        vd.BaseControl.ActiveDocument.Prompt("Other corner:")
        Dim p1 = New gPoint(2, 2)
        'The user can either click a point or type at the command line a point like 5,5,2
        Dim ret As Object = vd.BaseControl.ActiveDocument.ActionUtility.getUserRect(p1)
        vd.BaseControl.ActiveDocument.Prompt(Nothing)
        Dim v As Vector
        v = ret
        If Not (v = Nothing) Then
            Dim angle As Double = v.x
            Dim width As Double = v.y
            Dim height As Double = v.z

            'Calculate the point the user clicked.
            'Use polar command to find the bottom right point moving width distance from the initial point.
            Dim pt2 As gPoint = p1.Polar(0.0, width)
            'Use the polar again to go up height distance to find the upper right point.
            pt2 = pt2.Polar(VectorDraw.Geometry.Globals.HALF_PI, height)

            'Just zoom using the user's rect.
            vd.BaseControl.ActiveDocument.ZoomWindow(p1, pt2)
            vd.BaseControl.ActiveDocument.Redraw(True)
        End If
    End Sub
    Private Sub butGetFigure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butGetFigure.Click
        vd.BaseControl.ActiveDocument.[New]()
        AddSomeEntities()
        vd.BaseControl.ActiveDocument.Prompt("Select a Figure")
        Dim fig As vdFigure
        Dim userpt As gPoint
        'This command waits until thew user clicks an entity.
        fig = Nothing
        userpt = Nothing
        Dim code As VectorDraw.Actions.StatusCode = vd.BaseControl.ActiveDocument.ActionUtility.getUserEntity(fig, userpt)
        vd.BaseControl.ActiveDocument.Prompt(Nothing)
        If (code = VectorDraw.Actions.StatusCode.Success) Then
            If Not (fig Is Nothing) Then
                Dim handle As String = fig.Handle.ToStringValue()
                Dim color As String = fig.PenColor.ToString()
                MessageBox.Show("The user clicked the circle with handle :" + handle + " and with color:" + color + " at point X:" + userpt.x.ToString() + "  Y:" + userpt.y.ToString() + "  Z:" + userpt.z.ToString())
            End If

        Else
            MessageBox.Show("The user cancelled the command")
        End If
    End Sub
    Private Sub butGetDistance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butGetDistance.Click
        vd.BaseControl.ActiveDocument.[New]()
        Dim start As gPoint = New gPoint(0.0, 0.0)
        vd.BaseControl.ActiveDocument.Prompt("Select Distance:")

        'The user can either click a point or type at the command line a point like 5,5,2
        Dim tmpend As Object = vd.BaseControl.ActiveDocument.ActionUtility.getUserDist(start)
        vd.BaseControl.ActiveDocument.Prompt(Nothing)
        If Not (tmpend = Nothing) Then
            Dim distance As Double = tmpend
            MessageBox.Show("Distance:" + distance.ToString())
        End If
    End Sub

    Private Sub butGetAngle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butGetAngle.Click
        vd.BaseControl.ActiveDocument.[New]()
        'Enable the action event to draw extra figures.
        ShowActionEntities = True

        Dim start As gPoint = New gPoint(2.0, 3.0)
        vd.BaseControl.ActiveDocument.Prompt("Select Angle:")
        'Using the ActionDraw event we draw a line and an arc for better results.
        Dim tmpend As Object = vd.BaseControl.ActiveDocument.ActionUtility.getUserAngle(start)
        vd.BaseControl.ActiveDocument.Prompt(Nothing)
        If Not (tmpend = Nothing) Then
            Dim radians As Double = tmpend
            Dim degrees As Double = VectorDraw.Geometry.Globals.RadiansToDegrees(radians)
            MessageBox.Show("Angle:" + radians.ToString() + " in radians    or " + degrees.ToString() + " in degrees")
        End If

        ShowActionEntities = False
    End Sub

    Private Sub butGetSelection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butGetSelection.Click
        vd.BaseControl.ActiveDocument.[New]()
        AddSomeEntities()
        vd.BaseControl.ActiveDocument.Prompt("Select Entities:")
        Dim selset As vdSelection = vd.BaseControl.ActiveDocument.ActionUtility.getUserSelection()
        vd.BaseControl.ActiveDocument.Prompt(Nothing)
        If Not (selset Is Nothing) Then
            MessageBox.Show("You have selected " + selset.Count.ToString() + " figures")
            For Each var As vdFigure In selset
                var.HighLight = True
            Next
            vd.BaseControl.ActiveDocument.Redraw(True)
        End If
    End Sub


    Private Sub butAcceptedValues_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butAcceptedValues.Click
        vd.BaseControl.ActiveDocument.[New]()
        AddSomeEntities()
        'We will ask the user to select an entity or to type Red,Green,Blue in order to select the entity.
        vd.BaseControl.ActiveDocument.Prompt("Select One Entity or [Red,Blue,Green]:")
        vd.BaseControl.ActiveDocument.ActionUtility.SetAcceptedStringValues(New String() {"Red;R;r", "Blue;B;b", "Green;G;g"}, "Red")
        Dim ret As Object = vd.BaseControl.ActiveDocument.ActionUtility.getUserPoint()
        If TypeOf ret Is gPoint Then
            Dim p1 As gPoint = vd.BaseControl.ActiveDocument.World2PixelMatrix.Transform(TryCast(ret, gPoint))
            Dim location As New Point(CInt(p1.x), CInt(p1.y))
            Dim fig As vdFigure = vd.BaseControl.ActiveDocument.ActiveLayOut.GetEntityFromPoint(location, vd.BaseControl.ActiveDocument.ActiveLayOut.Render.GlobalProperties.PickSize, False)
            If fig IsNot Nothing Then
                fig.HighLight = True

            End If

        ElseIf String.Compare(DirectCast(ret, String), "Red") = 0 Then
            'Select the Red circle.
            Dim p1 As gPoint = vd.BaseControl.ActiveDocument.World2PixelMatrix.Transform(New gPoint(7.0, 5.0))
            Dim location As New Point(CInt(p1.x), CInt(p1.y))
            Dim fig As vdFigure = vd.BaseControl.ActiveDocument.ActiveLayOut.GetEntityFromPoint(location, vd.BaseControl.ActiveDocument.ActiveLayOut.Render.GlobalProperties.PickSize, False)
            fig.HighLight = True
        ElseIf String.Compare(DirectCast(ret, String), "Blue") = 0 Then
            'Select the Blue circle.
            Dim p1 As gPoint = vd.BaseControl.ActiveDocument.World2PixelMatrix.Transform(New gPoint(12.0, 5.0))
            Dim location As New Point(CInt(p1.x), CInt(p1.y))
            Dim fig As vdFigure = vd.BaseControl.ActiveDocument.ActiveLayOut.GetEntityFromPoint(location, vd.BaseControl.ActiveDocument.ActiveLayOut.Render.GlobalProperties.PickSize, False)
            fig.HighLight = True
        ElseIf String.Compare(DirectCast(ret, String), "Green") = 0 Then
            'Select the Green circle.
            Dim p1 As gPoint = vd.BaseControl.ActiveDocument.World2PixelMatrix.Transform(New gPoint(17.0, 5.0))
            Dim location As New Point(CInt(p1.x), CInt(p1.y))
            Dim fig As vdFigure = vd.BaseControl.ActiveDocument.ActiveLayOut.GetEntityFromPoint(location, vd.BaseControl.ActiveDocument.ActiveLayOut.Render.GlobalProperties.PickSize, False)
            fig.HighLight = True
        Else
            vd.BaseControl.ActiveDocument.Prompt(Nothing)
            Return
        End If
        vd.BaseControl.ActiveDocument.Prompt(Nothing)
        vd.BaseControl.ActiveDocument.Redraw(True)
    End Sub




End Class
