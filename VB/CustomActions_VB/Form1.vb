Imports VectorDraw.Geometry
Imports VectorDraw.Geometry.Globals
Imports VectorDraw.Professional.vdObjects
Imports VectorDraw.Professional.vdFigures
Imports VectorDraw.Professional.vdPrimaries
Imports VectorDraw.Professional.vdCollections
Imports VectorDraw.Render
Public Class Form1

    Public GLB_Rect As vdRect
    WithEvents Basedoc As VectorDraw.Professional.Control.VectorDrawBaseControl
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Basedoc = VDMain.BaseControl

        Dim doc = VDMain.BaseControl.ActiveDocument

        doc.EnableAutoGripOn = False
        doc.ShowUCSAxis = False

        Dim vd_hatch As New vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid)
        vd_hatch.FillColor = New vdColor(Color.DarkGray)

        GLB_Rect = New vdRect(doc, New gPoint(0, 0), 10, 10, 0)
        GLB_Rect.HatchProperties = vd_hatch
        GLB_Rect.PenColor = New vdColor(Color.Yellow)
        GLB_Rect.PenWidth = 0.25
        GLB_Rect.ShowGrips = False
        doc.ActiveLayOut.Entities.AddItem(GLB_Rect)

        doc.ZoomExtents()
        doc.ZoomScale(4)
    End Sub

    Private Sub Basedoc_vdMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs, ByRef cancel As Boolean) Handles Basedoc.vdMouseDown
        If e.Button <> MouseButtons.Left Then Return

        Dim gpt As gPoint = VDMain.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.World2Pixelmatrix.Transform(VDMain.BaseControl.ActiveDocument.ActiveLayOut.OverAllActiveAction.MouseLocation)
        Dim pt As New POINT(CInt(gpt.x), CInt(gpt.y))

        Using vd_figure As vdFigure = VDMain.BaseControl.ActiveDocument.ActiveLayOut.GetEntityFromPoint(pt, VDMain.BaseControl.ActiveDocument.ActiveLayOut.ActiveActionRender.GlobalProperties.PickSize, False)
            If vd_figure Is Nothing Then 'OrElse (Not vd_figure Is GLB_Rect) Then
                ' no entities found at the cursor position
                Return
            End If

            ''MoveOutlineRectWithMouseProcedure(GLB_Rect, VDMain.BaseControl.ActiveDocument.CCS_CursorPos)

            ''create a new custom action that get an existing figure a draws a new one while the mouse is moving
            Dim action As New DropFigureAction(VDMain.BaseControl.ActiveDocument.CCS_CursorPos, vd_figure)
            ''starts the action and wait until it is finished
            Dim item As vdFigure = TryCast(VDMain.BaseControl.ActiveDocument.ActionUtility.getUserActionEntity(action), vdFigure)
            ''if the action is finished successfully add the temporary create figure to the active layout entities
            If (Not item Is Nothing) Then
                VDMain.BaseControl.ActiveDocument.ActiveLayOut.Entities.Add(item)
                item.Invalidate() ''post a redraw message for the bouding area of the new added figure
            End If

        End Using
    End Sub

    ''this object implement an action that draws an entity
    Friend Class DropFigureAction
        Inherits VectorDraw.Professional.Actions.ActionEntity ''default VDF action for entity
        ' Methods
        Public Sub New(ByVal refpt As gPoint, ByVal fig As vdFigure)
            MyBase.New(fig.Document.User2WorldMatrix.Transform(refpt), fig.Document.ActiveLayOut())
            Me.clonefig = Nothing
            Me.defpt = Nothing
            ''create a clone of the passed existing entity, temporary used to draw while the mouse is moving
            Me.clonefig = TryCast(fig.Clone(Nothing), vdFigure)
            ''change the color of the new created entity to be different than the passed one
            ''here you can change more properties if you like
            Me.clonefig.PenColor = New vdColor(Color.FromArgb(0, 0, 0)) ''set the pen color to black same as background in order to test the SetColorMixMode (see DrawEntity() method)
            Me.defpt = New gPoint(Me.ReferencePoint)
        End Sub

        Public Overrides Sub MouseUp(ByVal e As MouseEventArgs)
            MyBase.MouseUp(e)
            Me.FinishAction(Me) ''The action is finished when the mouse is up
        End Sub

        Protected Overrides Sub OnMyPositionChanged(ByVal newPosition As gPoint)
            Dim mat As New Matrix
            mat.TranslateMatrix((newPosition - Me.defpt))
            Me.clonefig.Transformby(mat)
            Me.defpt = New gPoint(newPosition)
        End Sub
        Protected Overrides Function DrawEntity() As vdRender.DrawStatus
            Dim ret As vdRender.DrawStatus
            Dim oldMixMode As VectorDraw.Render.vdglTypes.COLOR_MIX
            oldMixMode = Render.SetColorMixMode(vdglTypes.COLOR_MIX.Visible) ''change the active ColorMixMode to force the color that are same as background to be visible
            ret = MyBase.DrawEntity()
            Render.SetColorMixMode(oldMixMode) ''restore the COLOR_MIX
            Return ret
        End Function

        ' Properties
        Public Overrides ReadOnly Property Entity() As vdFigure
            Get
                Return Me.clonefig
            End Get
        End Property

        Public Overrides ReadOnly Property HideRubberLine() As Boolean
            Get
                Return True ''do not draw the ruber line between reference point and current point
            End Get
        End Property
        ''the return value from the getUserActionEntity call
        Public Overrides ReadOnly Property Value() As Object
            Get
                Return Entity
            End Get
        End Property


        ' Fields
        Private clonefig As vdFigure ''a new created entity that is a clone of an existing and modified while the the mouse is moving
        Private defpt As gPoint ''a point in world Coordinate System updated each time the mouse is moved, inside the OnMyPositionChanged method
    End Class

End Class
