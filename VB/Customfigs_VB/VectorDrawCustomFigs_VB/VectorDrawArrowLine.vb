Imports System
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports VectorDraw.Serialize
Imports VectorDraw.Professional
Imports VectorDraw.Professional.vdPrimaries
Imports VectorDraw.Professional.vdFigures
Imports VectorDraw.Professional.vdCollections
Imports VectorDraw.Professional.vdObjects
Imports VectorDraw.Professional.Constants
Imports VectorDraw.GeomeTry
Imports VectorDraw.Render
Imports VectorDraw.Professional.Actions
Imports VectorDraw.Actions

'namespace 
Public Class VectorDrawArrowLine
    Inherits vdFigure ', IvdProxyFigure
    Implements IvdProxyFigure

#Region "Private fields"
    Private mArrowPoints As gPoints = New gPoints()
    Private mArrowSize As Double = 1D
    Private mStartPoint As gPoint = New gPoint()
    Private mEndPoint As gPoint = New gPoint()
#End Region

#Region "ctor"
    Public Sub New()
        mArrowPoints.Add(New gPoint(0D, 0D, 0D))
        mArrowPoints.Add(New gPoint(-1D, -0.1665D, 0D))
        mArrowPoints.Add(New gPoint(-1D, 0.1665D, 0D))
        mArrowPoints.Add(New gPoint(0D, 0D, 0D))
    End Sub
#End Region

#Region "Public properties"
    'You should use the AddHistory command in your properties so any change will be writen to the history
    'The string in the AddHistory command is the name of the property exactly and should be called before the property change.
    Public Property arrowSize() As Double
        Get
            Return mArrowSize
        End Get
        Set(ByVal Value As Double)
            AddHistory("arrowSize", Value)
            mArrowSize = Value
        End Set
    End Property
    Public Property StartPoint() As gPoint
        Get
            Return mStartPoint
        End Get
        Set(ByVal Value As gPoint)
            AddHistory("StartPoint", Value)
            mStartPoint.CopyFrom(Value)
        End Set
    End Property
    Public Property EndPoint() As gPoint
        Get
            Return mEndPoint
        End Get
        Set(ByVal Value As gPoint)
            AddHistory("EndPoint", Value)
            mEndPoint.CopyFrom(Value)
        End Set
    End Property
#End Region

#Region "private methods"


    Private Function ArrowEcsMatrix(ByVal ViewDir As Vector) As Matrix
        Dim mArrowMatrix As Matrix = New Matrix()
        mArrowMatrix.ScaleMatrix(mArrowSize, mArrowSize, 1D)
        mArrowMatrix.ApplyECS2WCS(ViewDir, New Vector(StartPoint, EndPoint))
        mArrowMatrix.TranslateMatrix(EndPoint)
        Return mArrowMatrix

    End Function
#End Region
#Region "pline overrides"
    'Note that not all values/objects can be saved/serialize by VDF, and you need to write code for such properties in serialize/deserialize override of this object. 
    'You can set value of custom property to any of the following type values: 
    '     String, Double, Int32, Boolean, Byte, Int16, Int64, UInt16, UInt64, UInt32, Single, ushort, System.Color, VectorDraw.Serialize.IVDHandle and IVDSerialise
    Public Overrides Sub Serialize(ByVal serializer As Serializer)
        MyBase.Serialize(serializer)
        serializer.Serialize(mArrowSize, "arrowSize")
        serializer.Serialize(mStartPoint, "StartPoint")
        serializer.Serialize(mEndPoint, "EndPoint")
    End Sub
    Public Overrides Function DeSerialize(ByVal deserializer As DeSerializer, ByVal fieldname As String, ByVal value As Object) As Boolean
        If MyBase.DeSerialize(deserializer, fieldname, value) Then
            Return True
        ElseIf (fieldname = "arrowSize") Then
            mArrowSize = CType(value, Double)
        ElseIf (fieldname = "StartPoint") Then
            mStartPoint = CType(value, gPoint)
        ElseIf (fieldname = "EndPoint") Then
            mEndPoint = CType(value, gPoint)
        Else
            Return False
        End If
        Return True
    End Function
    Public Overrides ReadOnly Property BoundingBox() As Box
        Get
            If Not mBoundBox.IsEmpty Then
                Return mBoundBox
            End If
            mBoundBox = New Box()
            mBoundBox.AddPoint(StartPoint)
            mBoundBox.AddPoint(EndPoint)
            Dim pts As gPoints = New gPoints()
            pts.AddRange(mArrowPoints)
            ArrowEcsMatrix(New Vector(0, 0, 1)).Transform(pts)
            mBoundBox.AddPoints(pts)
            Return mBoundBox

        End Get
    End Property
    Public Overrides Sub Transformby(ByVal mat As Matrix)
        StartPoint = mat.Transform(StartPoint)
        EndPoint = mat.Transform(EndPoint)
        MyBase.Transformby(mat)
    End Sub
    Public Overrides Function Draw(ByVal render As vdRender) As vdRender.DrawStatus
        Dim doDraw As vdRender.DrawStatus = MyBase.Draw(render)
        If doDraw = vdRender.DrawStatus.Successed Then

            render.DrawLine(Me, StartPoint, EndPoint)

            render.PushMatrix(ArrowEcsMatrix(render.ViewDir))
            render.DrawSolidPolygon(Me, mArrowPoints, vdRender.PolygonType.Simple)
            render.PopMatrix()


        End If
        AfterDraw(render)
        Return doDraw
    End Function
    Public Overrides Function GetGripPoints() As gPoints
        Dim ret As gPoints = New gPoints()
        ret.Add(StartPoint)
        ret.Add(EndPoint)
        Return ret
    End Function
    Public Overrides Sub MoveGripPointsAt(ByVal Indexes As Int32Array, ByVal dx As Double, ByVal dy As Double, ByVal dz As Double)
        If Indexes Is Nothing Or Indexes.Count = 0 Or (dx = 0.0 And dy = 0.0 And dz = 0.0) Then
            Return
        End If
        Dim grips As gPoints = GetGripPoints()
        If Indexes.Count = grips.Count Then
            Dim mat As Matrix = New Matrix()
            mat.TranslateMatrix(dx, dy, dz)
            Transformby(mat)
        Else
            Dim index As Integer
            For Each index In Indexes
                Select Case index
                    Case 0
                        StartPoint += New gPoint(dx, dy, dz)
                        Exit For
                    Case 1
                        EndPoint += New gPoint(dx, dy, dz)
                        Exit For
                    Case Else
                        Exit For
                End Select
            Next
        End If
        Update()

    End Sub
    Public Overrides Sub MatchProperties(ByVal _from As VectorDraw.Professional.vdObjects.vdPrimary, ByVal thisdocument As VectorDraw.Professional.vdObjects.vdDocument)
        MyBase.MatchProperties(_from, thisdocument)
        Dim from1 As VectorDrawArrowLine = _from
        If from1 Is Nothing Then
            Return
        End If
        StartPoint = from1.StartPoint
        EndPoint = from1.EndPoint
        arrowSize = from1.arrowSize
    End Sub
    Public Overrides Function Explode() As vdEntities
        Dim Entities As vdEntities = New vdEntities()
        Entities.SetUnRegisterDocument(Document)
        If Not Document Is Nothing Then
            Document.UndoHistory.PushEnable(False)
        End If
        Dim line As vdLine = New vdLine()
        line.StartPoint = StartPoint
        line.EndPoint = EndPoint
        line.MatchProperties(Me, Document)
        Entities.AddItem(line)

        Dim pl As vdPolyline = New vdPolyline()
        pl.VertexList.AddRange(Me.mArrowPoints)
        pl.Flag = VdConstPlineFlag.PlFlagCLOSE
        pl.HatchProperties = New vdHatchProperties()
        pl.HatchProperties.FillMode = VdConstFill.VdFillModeSolid
        pl.HatchProperties.FillColor.ByBlock = True
        pl.Transformby(ArrowEcsMatrix(New Vector(0, 0, 1)))
        pl.MatchProperties(Me, Document)
        Entities.AddItem(pl)
        If Not Document Is Nothing Then
            Document.UndoHistory.PopEnable()
        End If
        Return Entities
    End Function
    Public Overrides Function IsTableObjectDependOn(ByVal table As VectorDraw.Professional.vdObjects.vdPrimary) As Boolean
        ''we call only the base check because there are not tables objects reference to this object properties.
        If Deleted = True Then Return False
        If MyBase.IsTableObjectDependOn(table) = True Then Return True
        Return False
    End Function
#End Region
End Class



Public Class ActionArrowLine
    Inherits ActionEntity
    Private line As VectorDrawArrowLine

    Private Sub New(ByVal reference As gPoint, ByVal layout As vdLayout)
        MyBase.New(reference, layout)
        line = New VectorDrawArrowLine

        line.SetUnRegisterDocument(layout.Document)
        line.setDocumentDefaults()
        line.StartPoint = reference
        line.EndPoint = reference
    End Sub

    Public Overrides ReadOnly Property HideRubberLine() As Boolean
        Get
            Return True
        End Get
    End Property
    Public Overrides ReadOnly Property Entity() As vdFigure
        Get
            Return line
        End Get
    End Property
    Protected Overrides Sub OnMyPositionChanged(ByVal NewPosition As gPoint)
        line.EndPoint = NewPosition
    End Sub
    Public Overrides ReadOnly Property needUpdate() As Boolean
        Get
            Return True
        End Get
    End Property

    Public Shared Sub CmdArrowLine(ByVal document As vdDocument)
        Dim EPT As gPoint, SPT As gPoint
        document.Prompt("Start Point:")
        Dim ret As Object = document.ActionUtility.getUserPoint()
        document.Prompt(Nothing)
        If ret Is Nothing Or Not (TypeOf ret Is gPoint) Then
            Return
        End If
        SPT = CType(ret, gPoint)

        Dim aFig As ActionArrowLine = New ActionArrowLine(SPT, document.ActiveLayOut)
        document.Prompt("End Point :")

        document.ActionAdd(aFig)
        Dim scode As StatusCode = aFig.WaitToFinish()
        document.Prompt(Nothing)
        If scode <> VectorDraw.Actions.StatusCode.Success Then
            Return
        End If

        EPT = CType(aFig.Value, gPoint)

        Dim line As VectorDrawArrowLine = New VectorDrawArrowLine()
        document.ActionLayout.Entities.AddItem(line)
        document.UndoHistory.PushEnable(False)
        line.InitializeProperties()
        line.setDocumentDefaults()
        line.StartPoint = SPT
        line.EndPoint = EPT
        line.Transformby(document.User2WorldMatrix)
        document.UndoHistory.PopEnable()
        document.ActionDrawFigure(line)
    End Sub
End Class
