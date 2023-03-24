Imports System
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Drawing
Imports VectorDraw.Serialize
Imports VectorDraw.Professional
Imports VectorDraw.Professional.vdPrimaries
Imports VectorDraw.Professional.vdFigures
Imports VectorDraw.Professional.vdCollections
Imports VectorDraw.Professional.vdObjects
Imports VectorDraw.Professional.Constants
Imports VectorDraw.Geometry
Imports VectorDraw.Render
Imports VectorDraw.Professional.Actions
Imports VectorDraw.Actions

Imports VectorDraw.Generics



Public Class VectorDrawOffsetLine
    Inherits vdPolyline
    Implements IvdProxyFigure

#Region "ctor"
    Public Sub VectorDrawOffsetLine()

    End Sub
#End Region

#Region "private properties"
    Private mOffsetcurves As vdArray(Of vdCurves) = Nothing

    Private mLinesColor As vdColor = Nothing
    Private mLinesDistance As Double = 0.3
    Private mNumOfLines As Integer = 2
#End Region

#Region "Public properties"
    'You should use the AddHistory command in your properties so any change will be writen to the history
    'The string in the AddHistory command is the name of the property exactly and should be called before the property change.
    Public Property NumOfLines() As Integer
        Get
            Return mNumOfLines
        End Get
        Set(ByVal Value As Integer)
            AddHistory("NumOfLines", Value)
            mNumOfLines = Value
        End Set
    End Property
    Public Property LinesColor() As vdColor
        Get
            If (mLinesColor Is Nothing) Then mLinesColor = New vdColor(System.Drawing.Color.Red)
            Return mLinesColor
        End Get
        Set(ByVal Value As vdColor)
            AddHistory("LinesColor", Value)
            If (mLinesColor Is Nothing) Then mLinesColor = New vdColor(System.Drawing.Color.Red)
            mLinesColor.CopyFrom(Value)
        End Set
    End Property
    Public Property LinesDistance() As Double
        Get

            Return mLinesDistance
        End Get
        Set(ByVal Value As Double)
            AddHistory("LinesDistance", Value)
            mLinesDistance = Value
        End Set
    End Property
#End Region

#Region "Polyline overrides"
    <Browsable(False)> _
    Public Shadows ReadOnly Property XProperties() As vdXProperties
        Get '{ get { return base.XProperties; } }
            Return MyBase.XProperties
        End Get
    End Property

    <Browsable(False)> _
    Public Overrides Property SPlineFlag() As VdConstSplineFlag
        Get
            Return VdConstSplineFlag.SFlagSTANDARD
        End Get
        Set(ByVal Value As VdConstSplineFlag)
            MyBase.SPlineFlag = VdConstSplineFlag.SFlagSTANDARD
        End Set
    End Property

    Public Overloads Overrides Function Explode() As vdEntities

        Dim Entities As New vdEntities()
        Entities.SetUnRegisterDocument(Document)
        If Document IsNot Nothing Then
            Document.UndoHistory.PushEnable(False)
        End If

        Dim curvesArray As vdArray(Of vdCurves) = Offsetcurves()
        For Each curves As vdCurves In curvesArray
            For Each curve As vdCurve In curves
                curve.PenColor = mLinesColor
                Entities.AddItem(TryCast(curve.Clone(Document), vdFigure))
            Next
        Next
        Dim BaseEnts As vdEntities = MyBase.Explode()
        For Each var As vdFigure In BaseEnts
            Entities.AddItem(TryCast(var.Clone(Document), vdFigure))
        Next


        If Document IsNot Nothing Then
            Document.UndoHistory.PopEnable()
        End If
        Return Entities
    End Function


    Public Overrides Sub Update()
        MyBase.Update()
        Me.mOffsetcurves = Nothing
    End Sub
    Private Function Offsetcurves() As vdArray(Of vdCurves)
        If (Me.mOffsetcurves Is Nothing) Then
            Me.mOffsetcurves = New vdArray(Of vdCurves)
            Dim i As Integer
            For i = 0 To Me.mNumOfLines - 1
                Dim curves As vdCurves = Me.getOffsetCurve((Me.mLinesDistance * (i + 1)))
                If ((Not curves Is Nothing) AndAlso (curves.Count > 0)) Then
                    Me.mOffsetcurves.AddItem(curves)
                End If
            Next i
        End If
        Return Me.mOffsetcurves
    End Function
    Public Overrides Sub InitializeProperties()
        MyBase.InitializeProperties()
        mLinesColor = New vdColor()
        mLinesColor.SetUnRegisterDocument(Me.Document)
        mLinesColor.SystemColor = System.Drawing.Color.Red
        mLinesDistance = 0.3
        mNumOfLines = 2
    End Sub
    'Note that not all values/objects can be saved/serialize by VDF, and you need to write code for such properties in serialize/deserialize override of this object. 
    'You can set value of custom property to any of the following type values: 
    '     String, Double, Int32, Boolean, Byte, Int16, Int64, UInt16, UInt64, UInt32, Single, ushort, System.Color, VectorDraw.Serialize.IVDHandle and IVDSerialise
    Public Overrides Sub Serialize(ByVal serializer As Serializer)
        MyBase.Serialize(serializer)
        serializer.Serialize(mLinesColor, "LinesColor")
        serializer.Serialize(mLinesDistance, "LinesDistance")
        serializer.Serialize(mNumOfLines, "NumOfLines")
    End Sub
    Public Overrides Function DeSerialize(ByVal deserializer As DeSerializer, ByVal fieldname As String, ByVal value As Object) As Boolean
        If MyBase.DeSerialize(deserializer, fieldname, value) Then
            Return True
        ElseIf fieldname = "LinesColor" Then
            mLinesColor = CType(value, vdColor)
        ElseIf fieldname = "LinesDistance" Then
            mLinesDistance = CType(value, Double)
        ElseIf fieldname = "NumOfLines" Then
            mNumOfLines = CType(value, Integer)
        Else : Return False
        End If
        Return True
    End Function
    Public Overrides Sub MatchProperties(ByVal _from As vdPrimary, ByVal thisdocument As vdDocument)
        MyBase.MatchProperties(_from, thisdocument)
        Dim from As VectorDrawOffsetLine = CType(_from, VectorDrawOffsetLine)
        If from Is Nothing Then
            Return
        End If
        mLinesColor = New vdColor()
        mLinesColor.CopyFrom(from.LinesColor)
        mLinesDistance = from.LinesDistance
        mNumOfLines = from.NumOfLines
    End Sub
    Public Overrides Function Draw(ByVal render As vdRender) As vdRender.DrawStatus
        Dim doDraw As vdRender.DrawStatus = MyBase.Draw(render)
        If doDraw = vdRender.DrawStatus.Successed Then
            Dim style As vdGdiPenStyle = New vdGdiPenStyle()
            style.CopyFrom(render.PenStyle)
            style.color = mLinesColor.SystemColor
            render.PushPenstyle(style)

            Dim curvesArray As vdArray(Of vdCurves) = Me.Offsetcurves
            Dim curves As vdCurves
            For Each curves In curvesArray
                Dim curve As vdCurve
                For Each curve In curves
                    Dim pts As gPoints = curve.GetSamplePoints(0, 0)
                    If (pts.Count > 0) Then
                        render.DrawPLine(Me, pts)
                    End If
                Next
            Next

            render.PopPenstyle()
        End If
        Return doDraw
    End Function
    Public Overrides ReadOnly Property BoundingBox() As Box
        Get
            If Not mBoundBox.IsEmpty Then
                Return mBoundBox
            End If
            mBoundBox = New Box()
            Dim var As Vertex
            For Each var In Me.VertexList
                Dim pt As gPoint = CType(var, gPoint)
                mBoundBox.AddPoint(pt)
            Next
            'Make the last offset commited and include the result to the bounding box.
            Dim curvesArray As vdArray(Of vdCurves) = Me.Offsetcurves
            Dim curves As vdCurves
            For Each curves In curvesArray
                Dim curve As vdCurve
                For Each curve In curves
                    Dim pts As gPoints = curve.GetSamplePoints(0, 0)
                    If (pts.Count > 0) Then
                        MyBase.mBoundBox.AddPoints(pts)
                    End If
                Next
            Next


            Return mBoundBox
        End Get
    End Property

    Public Overrides Function IsTableObjectDependOn(ByVal table As VectorDraw.Professional.vdObjects.vdPrimary) As Boolean
        If Deleted = True Then Return False ''always check if this object is deleted
        If MyBase.IsTableObjectDependOn(table) = True Then Return True ''always check the base implamentation
        ''check properties of object that reference the table object.
        If Not LinesColor Is Nothing And LinesColor.IsTableObjectDependOn(table) = True Then Return True
        Return False
    End Function
    Public Overloads Overrides Sub GetTableDependecies(ByVal args As vdTableDependeciesArgs)
        MyBase.GetTableDependecies(args)
        If args.IsObjectFound Then
            Exit Sub
        End If
        If Deleted Then
            Exit Sub
        End If

        If mLinesColor IsNot Nothing Then
            mLinesColor.GetTableDependecies(args)
        End If
    End Sub

#End Region

#Region "Command"
    Public Shared Sub CmdOffsetLine(ByVal document As vdDocument)
        document.Prompt("First Point:")
        Dim ret As Object = document.ActionUtility.getUserPoint
        document.Prompt(Nothing)
        If ((Not ret Is Nothing) AndAlso TypeOf ret Is gPoint) Then
            Dim SPT As gPoint = TryCast(ret, gPoint)
            Dim vertexes As New Vertexes
            vertexes.Add(SPT)
            Dim code As StatusCode = StatusCode.Success
            Do While (code = StatusCode.Success)
                document.Prompt("Next Point:")
                Dim aFig As New ActionOffsetLine(vertexes, document.ActiveLayOut)
                document.ActionAdd(aFig)
                code = aFig.WaitToFinish
                document.Prompt(Nothing)
                If (code = StatusCode.Success) Then
                    vertexes = DirectCast(aFig.Entity, VectorDrawOffsetLine).VertexList
                End If
            Loop
            Dim line As New VectorDrawOffsetLine
            document.UndoHistory.PushEnable(False)
            line.SetUnRegisterDocument(document)
            line.InitializeProperties()
            line.setDocumentDefaults()
            line.VertexList = vertexes
            line.Transformby(document.User2WorldMatrix)
            document.UndoHistory.PopEnable()
            document.ActionLayout.Entities.AddItem(DirectCast(line, vdFigure))
            document.ActionDrawFigure(line)
        End If
    End Sub


#End Region
End Class

Public Class ActionOffsetLine
    Inherits ActionEntity
    Private line As VectorDrawOffsetLine

    Public Sub New(ByVal vertexes As Vertexes, ByVal layout As vdLayout)
        MyBase.New(layout.Document.User2WorldMatrix.Transform(vertexes.Last()), layout)
        line = New VectorDrawOffsetLine

        line.SetUnRegisterDocument(layout.Document)
        line.InitializeProperties()

        line.setDocumentDefaults()
        vertexes.Add(vertexes.Last())
        line.VertexList = vertexes
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
        line.VertexList.Last().CopyFrom(NewPosition)
    End Sub
    Public Overrides ReadOnly Property needUpdate() As Boolean
        Get
            Return True
        End Get
    End Property

End Class