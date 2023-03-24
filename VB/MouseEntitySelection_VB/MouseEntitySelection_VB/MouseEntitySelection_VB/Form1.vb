Imports VectorDraw.Professional.vdCollections
Imports VectorDraw.Geometry
Imports VectorDraw.Render
Imports VectorDraw.Serialize
Imports VectorDraw.Generics
Imports VectorDraw.Professional.vdFigures
Imports VectorDraw.Professional.vdPrimaries
Imports VectorDraw.Professional.vdObjects
Public Class Form1

    WithEvents Basedoc As VectorDraw.Professional.Control.VectorDrawBaseControl

#Region "Initialization and variables"
    Dim state As Integer
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        state = 0
        Basedoc = VdFramedControl1.BaseControl
        VdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.CommandLine, False)
        VdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.LayoutTab, False)
        AddSeveralEntities()
    End Sub
#End Region

#Region "Needed extra methods"
    Private Function GetGripsCollection() As vdSelection
        Dim selsetname As String
        If (Not VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveViewPort Is Nothing) Then
            selsetname = "VDGRIPSET_" + VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Handle.ToStringValue() + VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveViewPort.Handle.ToStringValue()
        Else
            selsetname = "VDGRIPSET_" + VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Handle.ToStringValue()
        End If
        Dim gripset As vdSelection = VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.Selections.FindName(selsetname)
        If (gripset Is Nothing) Then gripset = VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.Selections.Add(selsetname)
        GetGripsCollection = gripset
    End Function
    Private Sub ClearAllGrips(ByVal GripSelection As vdSelection)
        For Each fig As vdFigure In GripSelection
            fig.ShowGrips = False
        Next fig
        If (GripSelection.Count > 0) Then
            GripSelection.RemoveAll()
            VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.RefreshGraphicsControl(VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.control)
        End If
    End Sub

    Private Sub DrawGrips(ByVal GripSelection As vdSelection)
        If GripSelection.Count = 0 Then
            Return
        End If
        Dim oldScreenmode As Boolean = VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.SetScreenMode(True)
        Dim isstarted As Boolean = VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.Started
        If Not isstarted Then
            VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.StartDraw(True)
        End If
        VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.PushPenstyle(VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.GripColor, 0.0, Nothing)
        Dim i As Integer = 0
        For Each fig As vdFigure In GripSelection
            fig.DrawGrips(VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender)
            i += 1
            If Not VectorDraw.WinMessages.MessageManager.IsMessageQueEmpty(IntPtr.Zero, VectorDraw.WinMessages.MessageManager.BreakMessageMethod.All) Then
                Exit For
            End If
        Next
        VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.PopPenstyle()
        If Not isstarted Then
            VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.EndDraw()
        End If
        VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.SetScreenMode(oldScreenmode)
    End Sub
#End Region

    Private Sub Basedoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Basedoc.KeyDown
        If (e.KeyCode = Keys.Escape) Then
            ClearAllGrips(GetGripsCollection())
        End If
    End Sub


    Private Sub Basedoc_vdMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs, ByRef cancel As Boolean) Handles Basedoc.vdMouseDown
        If state = 0 Then
            Return
        End If
        If e.Button <> MouseButtons.Left Then
            Return
        End If
        If VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.OverAllActiveActions Is Nothing Then
            Return
        End If
        If VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.OverAllActiveActions.Count > 1 Then
            Return
        End If

        If TypeOf VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveAction Is VectorDraw.Professional.CommandActions.ActionLine Then
            Return
        End If
        Dim GripEntities As vdSelection = GetGripsCollection()
        Dim p1 As gPoint = VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.World2Pixelmatrix.Transform(VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.OverAllActiveAction.MouseLocation)
        Dim p1viewCS As gPoint = VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.CurrentMatrix.Transform(VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.OverAllActiveAction.MouseLocation)
        Dim location As New POINT(CInt(p1.x), CInt(p1.y))

        '#Region "Grip Move Code"
        If System.Windows.Forms.Control.ModifierKeys = Keys.None Then
            Dim box As New Box()
            box.AddPoint(p1viewCS)
            box.AddWidth(VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.GripSize * VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.PixelSize / 2.0)

            Dim selset As New vdSelection()
            Dim indexesArray As New vdArray(Of Int32Array)()
            Dim pt As gPoint = VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.World2UserMatrix.Transform(VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.OverAllActiveAction.MouseLocation)
            For Each fig__1 As vdFigure In GripEntities
                Dim indexes As Int32Array = VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.getGripIndexes(fig__1, box)
                If indexes.Count <> 0 Then
                    selset.AddItem(fig__1, False, vdSelection.AddItemCheck.Nochecking)
                    indexesArray.AddItem(indexes)
                End If
            Next
            If selset.Count > 0 Then
                Dim MoveGrips As New VectorDraw.Professional.ActionUtilities.CmdMoveGripPoints(pt, VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut, selset, indexesArray)
                VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActionAdd(MoveGrips)
                Dim ret As VectorDraw.Actions.StatusCode = MoveGrips.WaitToFinish()
                cancel = True
                Return
            End If
        End If
        '#End Region

        If state = 1 Then
            '#Region "One by One implementation"
            Dim Fig__2 As vdFigure = Nothing
            Fig__2 = VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.GetEntityFromPoint(location, VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.PickSize, False, vdDocument.LockLayerMethodEnum.EnableGetObjectGrip)
            Dim value
            If (VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.LockLayerMethod And vdDocument.LockLayerMethodEnum.EnableGetObjectGrip) <> 0 Then
                value = vdDocument.LockLayerMethodEnum.EnableAddToSelections
            Else
                value = 0
            End If


            VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.LockLayerMethodStack.Push(vdDocument.LockLayerMethodEnum.DisableAll Or value)
            Dim bShift As Boolean = ((System.Windows.Forms.Control.ModifierKeys And Keys.Shift) = Keys.Shift)
            If Fig__2 IsNot Nothing Then
                ClearAllGrips(GripEntities)
                GripEntities.AddItem(Fig__2, True, vdSelection.AddItemCheck.RemoveInVisibleEntities)
                Fig__2.ShowGrips = True
                DrawGrips(GripEntities)
                VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.RefreshGraphicsControl(VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.control)
            End If
            '#End Region
            VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.LockLayerMethodStack.Pop()
        ElseIf state = 2 Then
            '#Region "Multiple select implementation."
            Dim Fig__2 As vdFigure = Nothing
            Fig__2 = VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.GetEntityFromPoint(location, VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.PickSize, False, vdDocument.LockLayerMethodEnum.EnableGetObjectGrip)
            Dim value
            If (VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.LockLayerMethod And vdDocument.LockLayerMethodEnum.EnableGetObjectGrip) <> 0 Then
                value = vdDocument.LockLayerMethodEnum.EnableAddToSelections
            Else
                value = 0
            End If
            VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.LockLayerMethodStack.Push(vdDocument.LockLayerMethodEnum.DisableAll Or value)
            Dim bShift As Boolean = ((System.Windows.Forms.Control.ModifierKeys And Keys.Shift) = Keys.Shift)
            If Fig__2 IsNot Nothing Then
                If Not bShift AndAlso VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.PickAdd = False Then
                    ClearAllGrips(GripEntities)
                End If
                If bShift AndAlso GripEntities.FindItem(Fig__2) Then
                    GripEntities.RemoveItem(Fig__2)
                    Fig__2.ShowGrips = False

                    DrawGrips(GripEntities)
                    VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.RefreshGraphicsControl(VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.control)
                Else
                    If GripEntities.FindItem(Fig__2) = False Then
                        If GripEntities.AddItem(Fig__2, True, vdSelection.AddItemCheck.RemoveInVisibleEntities) Then
                            Dim oldScreenmode As Boolean = VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.SetScreenMode(True)
                            Dim isstarted As Boolean = VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.Started
                            If Not isstarted Then
                                VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.StartDraw(True)
                            End If
                            Fig__2.ShowGrips = True
                            VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.PushPenstyle(VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.GripColor, 0.0, Nothing)
                            Fig__2.DrawGrips(VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender)
                            VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.PopPenstyle()
                            If Not isstarted Then
                                VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.EndDraw()
                            End If
                            VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.SetScreenMode(oldScreenmode)
                            VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.RefreshGraphicsControl(VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.control)

                        End If
                    End If
                End If
            Else
                'Window selection
                Dim [set] As vdSelection = Nothing
                Dim scode As VectorDraw.Actions.StatusCode = VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActionUtility.getUserStartWindowSelection(New POINT(e.X, e.Y), [set])
                If scode = VectorDraw.Actions.StatusCode.Success Then
                    If Not bShift AndAlso VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.PickAdd = False Then
                        ClearAllGrips(GripEntities)
                    End If
                    For Each entity As vdFigure In [set]
                        If bShift Then

                            If GripEntities.FindItem(entity) = True Then
                                entity.ShowGrips = False

                                GripEntities.RemoveItem(entity)
                            Else
                                entity.ShowGrips = True
                                GripEntities.AddItem(entity, False, vdSelection.AddItemCheck.RemoveInVisibleEntities)
                            End If
                        Else

                            If GripEntities.FindItem(entity) = False Then
                                entity.ShowGrips = True
                                GripEntities.AddItem(entity, False, vdSelection.AddItemCheck.RemoveInVisibleEntities)
                            End If
                        End If
                    Next
                    [set].RemoveAll()
                    DrawGrips(GripEntities)

                    VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.RefreshGraphicsControl(VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.control)
                End If
            End If
            '#End Region
            VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.LockLayerMethodStack.Pop()
            ElseIf state = 3 Then
                '#Region "Select Specific Layer entities (red entities)"
                'Almost same code as above with a Layer Check.
                Dim Fig__2 As vdFigure = Nothing
                Fig__2 = VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.GetEntityFromPoint(location, VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.PickSize, False, vdDocument.LockLayerMethodEnum.EnableGetObjectGrip)
                Dim value
                If (VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.LockLayerMethod And vdDocument.LockLayerMethodEnum.EnableGetObjectGrip) <> 0 Then
                    value = vdDocument.LockLayerMethodEnum.EnableAddToSelections
                Else
                    value = 0
                End If

                VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.LockLayerMethodStack.Push(vdDocument.LockLayerMethodEnum.DisableAll Or value)
                Dim bShift As Boolean = ((System.Windows.Forms.Control.ModifierKeys And Keys.Shift) = Keys.Shift)
                If Fig__2 IsNot Nothing Then
                    If Not bShift AndAlso VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.PickAdd = False Then
                        ClearAllGrips(GripEntities)
                    End If
                    If bShift AndAlso GripEntities.FindItem(Fig__2) Then
                        GripEntities.RemoveItem(Fig__2)
                        Fig__2.ShowGrips = False
                        DrawGrips(GripEntities)
                        VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.RefreshGraphicsControl(VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.control)
                    Else
                        If GripEntities.FindItem(Fig__2) = False Then
                            If Fig__2.Layer.Name = "Select" Then
                                If GripEntities.AddItem(Fig__2, True, vdSelection.AddItemCheck.RemoveInVisibleEntities) Then
                                    Dim oldScreenmode As Boolean = VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.SetScreenMode(True)
                                    Dim isstarted As Boolean = VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.Started
                                    If Not isstarted Then
                                        VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.StartDraw(True)
                                    End If
                                    Fig__2.ShowGrips = True
                                    VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.PushPenstyle(VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.GripColor, 0.0, Nothing)
                                    Fig__2.DrawGrips(VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender)
                                    VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.PopPenstyle()
                                    If Not isstarted Then
                                        VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.EndDraw()
                                    End If
                                    VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.SetScreenMode(oldScreenmode)
                                End If
                            End If
                        End If
                    End If
                Else
                    'Window selection
                    Dim [set] As vdSelection = Nothing
                    Dim scode As VectorDraw.Actions.StatusCode = VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActionUtility.getUserStartWindowSelection(New POINT(e.X, e.Y), [set])
                    If scode = VectorDraw.Actions.StatusCode.Success Then
                        If Not bShift AndAlso VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.PickAdd = False Then
                            ClearAllGrips(GripEntities)
                        End If
                        For Each entity As vdFigure In [set]
                            If bShift Then

                                If GripEntities.FindItem(entity) = True Then
                                    entity.ShowGrips = False

                                    GripEntities.RemoveItem(entity)
                                Else
                                    If entity.Layer.Name = "Select" Then
                                        entity.ShowGrips = True
                                        GripEntities.AddItem(entity, False, vdSelection.AddItemCheck.RemoveInVisibleEntities)
                                    End If
                                End If
                            Else

                                If GripEntities.FindItem(entity) = False Then
                                    If entity.Layer.Name = "Select" Then
                                        entity.ShowGrips = True
                                        GripEntities.AddItem(entity, False, vdSelection.AddItemCheck.RemoveInVisibleEntities)
                                    End If
                                End If
                            End If
                        Next
                        [set].RemoveAll()

                        DrawGrips(GripEntities)
                        VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.RefreshGraphicsControl(VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.control)
                    End If
                End If
                '#End Region
                VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Document.LockLayerMethodStack.Pop()

            ElseIf state = 4 Then
            End If
    End Sub

#Region "Radio Code... State selection and default vectordraw implementation Enable/Disable"
    Private Sub radioDefaultvdImplementation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioDefaultvdImplementation.CheckedChanged
        If VdFramedControl1.BaseControl.ActiveDocument Is Nothing Then Exit Sub
        If (radioDefaultvdImplementation.Checked) Then
            VdFramedControl1.BaseControl.ActiveDocument.EnableAutoGripOn = True
            state = 0
        Else
            VdFramedControl1.BaseControl.ActiveDocument.EnableAutoGripOn = False
        End If
    End Sub

    Private Sub radioOneByΟne_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioOneByOne.CheckedChanged
        If (radioOneByOne.Checked) Then state = 1
    End Sub

    Private Sub radioMultipleSelect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioMultipleSelect.CheckedChanged
        If (radioMultipleSelect.Checked) Then state = 2
    End Sub

    Private Sub radioSelectParticularEntities_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioSelectParticularEntities.CheckedChanged
        If (radioSelectParticularEntities.Checked) Then state = 3
    End Sub
#End Region

#Region "Open a File to Add some entities to the drawing"
    Private Sub AddSeveralEntities()
        Dim filename As String
        filename = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\VectorDraw.vdml"
        VdFramedControl1.BaseControl.ActiveDocument.Open(filename)
    End Sub
#End Region


End Class
