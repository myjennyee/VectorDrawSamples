' <summary>
' OnFigureMouseOver is a new event added in version 7 of vdraw. This event was designed in order for users to be able to get control of when
' the cursor moves over a vdFigure object. Using this event you can achieve many things easily like perform custom highlight, select entities
' in a customized way and generally interact with entities under your cursor. To understand better how it works use this sample. 
' Keep in mind that this event has 6 types defined by the MouseAction property. 
' •MouseEnter - Fired when a cursor first hovers over a vdFigure.
' •MouseLeave - Fired when a cursor hovers off a vdFigure.
' •MouseMove - Fired whenever the cursor is moved and lies over a vdFigure.
' •MouseDown - Fired when a mouse button is pressed down over a vdFigure.
' •MouseUp - Fired when a mouse button is released over a vdFigure.
' •MouseOverDraw - Fired whenever the cursor is moved over a vdFigure and this figure is about to be drawn.
' 
' Also you should know that it fires only under specific conditions.
' •If the MouseEnter event is cancelled (setting the Cancel property of arguments object to true) all subsequent events won't fire.
' •The MouseOverDraw event will not fire unless the SelectionPreview of GlobalRenderProperties is set to ON.
' •The MouseEnter, MouseLeave and MouseMove events won't fire unless SelectionPreview, URLs or ToolTips are enabled.
' •There is an exception to the above condition, during an action if there are oSnaps activated the MouseEnter, MouseLeave and MouseMove fire.
' </summary>
Public Class Form1

    Public ReadOnly Property doc() As VectorDraw.Professional.vdObjects.vdDocument
        Get
            Return VectorDrawBaseControl1.ActiveDocument
        End Get
    End Property

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'doc.OnFigureMouseOver += New VectorDraw.Professional.vdObjects.vdDocument.FigureMouseOverEventHandler(doc_OnFigureMouseOver)
        AddHandler doc.OnFigureMouseOver, AddressOf doc_OnFigureMouseOver
        doc.EnableAutoGripOn = False

        doc.GlobalRenderProperties.SelectionPreview = VectorDraw.Render.vdRenderGlobalProperties.SelectionPreviewFlags.ON
        checkSelectionPreview.Checked = True
        doc.EnableToolTips = True
        checkTooltips.Checked = True
        doc.EnableUrls = True
        checkUrls.Checked = True

        Dim snaps As String() = [Enum].GetNames(GetType(VectorDraw.Geometry.OsnapMode))
        For Each osnap As String In snaps
            comboOsnaps.Items.Add(osnap)
        Next
        comboOsnaps.SelectedIndex = 1
        vdtext = New VectorDraw.Professional.vdFigures.vdText(doc)
        h_rect = New VectorDraw.Professional.vdFigures.vdRect(doc)
        h_rect.HatchProperties = New VectorDraw.Professional.vdObjects.vdHatchProperties()

        doc.Open("MouseOverFigure.vdml")
    End Sub
    Dim h_rect As VectorDraw.Professional.vdFigures.vdRect
    Dim vdtext As VectorDraw.Professional.vdFigures.vdText
    Dim eventCounter(6) As Integer
    Private Sub doc_OnFigureMouseOver(ByVal sender As Object, ByVal args As VectorDraw.Professional.vdPrimaries.vdFigure.FigureMouseEventArgs)

        Select Case args.MouseAction
            Case VectorDraw.Professional.vdPrimaries.vdFigure.FigureMouseEventArgs.FigureMouseAction.MouseDown
                eventCounter(0) += 1
                Exit Select
            Case VectorDraw.Professional.vdPrimaries.vdFigure.FigureMouseEventArgs.FigureMouseAction.MouseEnter
                eventCounter(1) += 1
                Exit Select
            Case VectorDraw.Professional.vdPrimaries.vdFigure.FigureMouseEventArgs.FigureMouseAction.MouseLeave
                eventCounter(2) += 1
                Exit Select
            Case VectorDraw.Professional.vdPrimaries.vdFigure.FigureMouseEventArgs.FigureMouseAction.MouseMove
                eventCounter(3) += 1
                Exit Select
            Case VectorDraw.Professional.vdPrimaries.vdFigure.FigureMouseEventArgs.FigureMouseAction.MouseOverDraw
                args.Cancel = True
                If args.Entity.Label = "sun" Then
                    Dim cir As VectorDraw.Professional.vdFigures.vdCircle
                    cir = args.Entity
                    drawSun(args.ActionRender, cir.Center)

                ElseIf args.Entity.Label = "rect" Then

                    drawRect(args.ActionRender, args.Entity, args.Entity.BoundingBox.MidPoint)

                ElseIf args.Entity.Label = "transparency" Then

                    drawTransparent(args.ActionRender, args.Entity.BoundingBox.MidPoint)

                ElseIf args.Entity.Label = "insert" Then

                    drawInsert(args.ActionRender, args.Entity.BoundingBox.MidPoint, args.Entity, args.InnerEntity)

                End If
                eventCounter(4) += 1
                Exit Select
            Case VectorDraw.Professional.vdPrimaries.vdFigure.FigureMouseEventArgs.FigureMouseAction.MouseUp
                eventCounter(5) += 1
                Exit Select
        End Select
        updateTextBoxes()
    End Sub
    Private Sub drawSun(ByVal render As VectorDraw.Render.vdRender, ByVal p As VectorDraw.Geometry.gPoint)

        render.LockPenStyle = New VectorDraw.Render.vdGdiPenStyle(Color.Yellow, 255)

        render.DrawLine(Nothing, p + New gPoint(0, 1.2), p + New gPoint(0, 2))
        render.DrawLine(Nothing, p + New gPoint(0.84, 0.84), p + New gPoint(1.4, 1.4))
        render.DrawLine(Nothing, p + New gPoint(1.2, 0), p + New gPoint(2, 0))
        render.DrawLine(Nothing, p + New gPoint(0.84, -0.84), p + New gPoint(1.4, -1.4))
        render.DrawLine(Nothing, p + New gPoint(0, -1.2), p + New gPoint(0, -2))
        render.DrawLine(Nothing, p + New gPoint(-0.84, -0.84), p + New gPoint(-1.4, -1.4))
        render.DrawLine(Nothing, p + New gPoint(-1.2, 0), p + New gPoint(-2, 0))
        render.DrawLine(Nothing, p + New gPoint(-0.84, 0.84), p + New gPoint(-1.4, 1.4))

        vdtext.TextString = "Draw on the fly"
        vdtext.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        vdtext.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        vdtext.Style = doc.TextStyles.Standard
        vdtext.InsertionPoint = p
        vdtext.Height = 0.2
        vdtext.Update()
        vdtext.Draw(render)

        render.LockPenStyle = Nothing
    End Sub
    Private Sub drawRect(ByVal render As VectorDraw.Render.vdRender, ByVal rect As VectorDraw.Professional.vdFigures.vdRect, ByVal p As gPoint)
        render.LockPenStyle = New VectorDraw.Render.vdGdiPenStyle(Color.LightGreen, 255)
        h_rect.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeNone

        h_rect.InsertionPoint = p + New gPoint(-1.05, -1.05)
        h_rect.Width = 2.1
        h_rect.Height = 2.1
        h_rect.Update()
        h_rect.Draw(render)

        h_rect.InsertionPoint = p + New gPoint(-0.95, -0.95)
        h_rect.Width = 1.9
        h_rect.Height = 1.9
        h_rect.Update()
        h_rect.Draw(render)

        vdtext.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        vdtext.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        vdtext.Style = doc.TextStyles.Standard
        vdtext.InsertionPoint = p + New gPoint(0, 2)
        vdtext.TextString = "Hightlight entities however you want"
        vdtext.Height = 0.3
        vdtext.Update()
        vdtext.Draw(render)

        render.LockPenStyle = Nothing
    End Sub
    Private Sub drawTransparent(ByVal render As VectorDraw.Render.vdRender, ByVal p As VectorDraw.Geometry.gPoint)

        render.LockPenStyle = New VectorDraw.Render.vdGdiPenStyle(Color.Cyan, 150)

        h_rect.InsertionPoint = p + New gPoint(-1, -1)
        h_rect.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid
        h_rect.Width = 2
        h_rect.Height = 2
        h_rect.Update()
        h_rect.Draw(render)

        vdtext.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        vdtext.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        vdtext.Style = doc.TextStyles.Standard
        vdtext.InsertionPoint = p + New gPoint(0, 2)
        vdtext.TextString = "Draw using transparency"
        vdtext.Height = 0.3
        vdtext.Update()
        vdtext.Draw(render)

        render.LockPenStyle = Nothing
    End Sub
    Private Sub drawInsert(ByVal render As VectorDraw.Render.vdRender, ByVal p As VectorDraw.Geometry.gPoint, ByVal top As vdFigure, ByVal inner As vdFigure)

        h_rect.PenColor.Dispose()
        h_rect.PenColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Red)
        h_rect.HatchProperties.FillMode = VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid
        h_rect.HatchProperties.FillColor.Dispose()
        h_rect.HatchProperties.FillColor = Nothing
        h_rect.HatchProperties.FillColor = New VectorDraw.Professional.vdObjects.vdColor(Color.Red, 100)

        h_rect.InsertionPoint = p + New gPoint(-1.05, -1.05)
        h_rect.Width = 2.1
        h_rect.Height = 2.1
        h_rect.Update()
        h_rect.Draw(render)

        vdtext.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        vdtext.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        vdtext.Style = doc.TextStyles.Standard
        vdtext.InsertionPoint = p - New gPoint(0, 2)
        vdtext.TextString = String.Format("Top entity:  {0} --- Inner entity:  {1}", top.GetType().ToString(), inner.GetType().ToString())
        vdtext.Height = 0.2
        vdtext.Update()
        vdtext.Draw(render)
    End Sub
    Private Sub updateTextBoxes()

        textMouseDown.Text = eventCounter(0).ToString()
        textMouseEnter.Text = eventCounter(1).ToString()
        textMouseLeave.Text = eventCounter(2).ToString()
        textMouseMove.Text = eventCounter(3).ToString()
        textMouseOverDraw.Text = eventCounter(4).ToString()
        textMouseUp.Text = eventCounter(5).ToString()
    End Sub
    Private Sub comboOsnaps_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles comboOsnaps.SelectedIndexChanged
        Dim snap As String
        snap = CType(comboOsnaps.Items(comboOsnaps.SelectedIndex), String)
        doc.osnapMode = [Enum].Parse(GetType(VectorDraw.Geometry.OsnapMode), snap)
    End Sub

    Private Sub checkSelectionPreview_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkSelectionPreview.CheckedChanged
        If (checkSelectionPreview.Checked) Then
            doc.GlobalRenderProperties.SelectionPreview = VectorDraw.Render.vdRenderGlobalProperties.SelectionPreviewFlags.ON
        Else
            doc.GlobalRenderProperties.SelectionPreview = VectorDraw.Render.vdRenderGlobalProperties.SelectionPreviewFlags.OFF
        End If
    End Sub

    Private Sub checkTooltips_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkTooltips.CheckedChanged

        doc.EnableToolTips = checkTooltips.Checked
    End Sub

    Private Sub checkUrls_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles checkUrls.CheckedChanged
        doc.EnableUrls = checkUrls.Checked
    End Sub

    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click

        doc.Open("MouseOverFigure.vdml")
        doc.Redraw(True)
        For i As Integer = 0 To eventCounter.Length - 1
            eventCounter(i) = 0
        Next
        updateTextBoxes()
    End Sub

    Private Sub buttonDrawline_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonDrawline.Click
        doc.CommandAction.CmdLine(Nothing)
    End Sub
End Class