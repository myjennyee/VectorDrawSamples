Public Class MainForm

    Public ReadOnly Property doc() As VectorDraw.Professional.vdObjects.vdDocument
        Get
            Return VdFramedControl1.BaseControl.ActiveDocument
        End Get
    End Property

    Private Sub butOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butOpen.Click
        'Open a default drawing
        VdFramedControl1.BaseControl.ActiveDocument.Open("Tool.vdml")
    End Sub

    Private Sub butDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butDialog.Click
        'Open the dialog designed to edit (the active) or create a new Multiview Layout.
        Dim dialogs As VectorDraw.Professional.Dialogs.VdrawDialogs
        dialogs = New VectorDraw.Professional.Dialogs.VdrawDialogs(VdFramedControl1.BaseControl.ActiveDocument, VdFramedControl1.BaseControl.ActiveDocument.ActionControl)
        dialogs.GetMultiViewDialog()
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler doc.OnAfterOpenDocument, AddressOf doc_OnAfterOpenDocument
    End Sub
    Private Sub doc_OnAfterOpenDocument(ByVal sender As Object)
        If TypeOf VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut Is VectorDraw.Professional.vdPrimaries.vdLayoutSplit Then
            'After opening a file , if it is saved having a Multiview layout active simply hide the model.
            VdFramedControl1.BaseControl.ActiveDocument.Model.VisibleOnForms = False
            VdFramedControl1.ScrollableControl.ReFillTabs()
        Else
            'After opening a file create a new Multiview layout and apply some default values, also hide the model.
            Dim multiview As VectorDraw.Professional.vdPrimaries.vdLayoutSplit
            multiview = New VectorDraw.Professional.vdPrimaries.vdLayoutSplit(VdFramedControl1.BaseControl.ActiveDocument, "View", VectorDraw.Professional.vdPrimaries.vdLayoutSplit.SplitStyleEnum.Three_Left)
            DirectCast(multiview.Entities(1), VectorDraw.Professional.vdFigures.vdViewport).RenderMode = VectorDraw.Render.vdRender.Mode.ShadeOn
            DirectCast(multiview.Entities(1), VectorDraw.Professional.vdFigures.vdViewport).PerspectiveMod = VectorDraw.Render.vdRender.VdConstPerspectiveMod.PerspectON
            DirectCast(multiview.Entities(1), VectorDraw.Professional.vdFigures.vdViewport).ZoomExtents()
            DirectCast(multiview.Entities(2), VectorDraw.Professional.vdFigures.vdViewport).RenderMode = VectorDraw.Render.vdRender.Mode.Wire3d
            DirectCast(multiview.Entities(2), VectorDraw.Professional.vdFigures.vdViewport).ZoomExtents()
            DirectCast(multiview.Entities(3), VectorDraw.Professional.vdFigures.vdViewport).RenderMode = VectorDraw.Render.vdRender.Mode.Render
            DirectCast(multiview.Entities(3), VectorDraw.Professional.vdFigures.vdViewport).ZoomExtents()
            VdFramedControl1.BaseControl.ActiveDocument.LayOuts.AddItem(Multiview)
            'Hide all layouts from the layouts tab to show only the Multiview layout.
            VdFramedControl1.BaseControl.ActiveDocument.Model.VisibleOnForms = False
            For Each var As VectorDraw.Professional.vdPrimaries.vdLayout In VdFramedControl1.BaseControl.ActiveDocument.LayOuts
                If var.Equals(multiview) Then
                    Continue For
                End If
                var.VisibleOnForms = False
            Next
            VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut = multiview
            VdFramedControl1.ScrollableControl.ReFillTabs()
        End If
    End Sub
End Class
