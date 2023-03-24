Imports System
Imports System.Collections.Generic
Imports System.Text
Imports VectorDraw.Geometry
Imports VectorDraw.Professional.vdCollections
Imports VectorDraw.Professional.vdFigures
Imports VectorDraw.Professional.vdObjects
Imports VectorDraw.Professional.vdPrimaries
Imports VectorDraw.Render
Imports VectorDraw.Serialize

Public Class vdLineConnection
    Inherits vdFigure
    Implements IvdProxyFigure, ISupportResolveReferenceObjects

#Region "Private fields"
    Private mFig1 As vdFigure
    Private mFig2 As vdFigure
#End Region

#Region "ctor"
    Public Sub New()
    End Sub
    Public Sub New(doc as vdDocument)
        SetUnRegisterDocument(doc)
        setDocumentDefaults()
    End Sub
#End Region

#Region "Public properties"
    Public Property Figure1() As vdFigure
        Get
            Return mFig1
        End Get
        Set(ByVal Value As vdFigure)
            AddHistory("Figure1", Value)
            Disconnect(mFig1)
            mFig1 = Value
            Connect(mFig1)
        End Set
    End Property
    Public Property Figure2() As vdFigure
        Get
            Return mFig2
        End Get
        Set(ByVal Value As vdFigure)
            AddHistory("Figure2", Value)
            Disconnect(mFig2)
            mFig2 = Value
            Connect(mFig2)
        End Set
    End Property
    Private ReadOnly Property Isvalid() As Boolean
        Get
            If ((Figure1 Is Nothing) Or (Figure2 Is Nothing)) Then Return False
            If ((Figure1.Equals(Figure2)) Or (Figure1.Deleted) Or (Figure2.Deleted)) Then Return False
            Return True
        End Get
    End Property
    Public Overrides Property Deleted() As Boolean
        Get
            If (Not Isvalid) Then Return True
            Return MyBase.Deleted
        End Get
        Set(ByVal value As Boolean)
            MyBase.Deleted = value
        End Set
    End Property
    Public Overrides ReadOnly Property BoundingBox() As Box
        Get

            If (mBoundBox.IsEmpty) Then
                If (Isvalid) Then
                    mBoundBox.AddBox(Figure1.BoundingBox)
                    mBoundBox.AddBox(Figure2.BoundingBox)
                End If
            End If
            Return mBoundBox
        End Get
    End Property
    

#End Region

#Region "Methods"
    Public Overrides Function Draw(ByVal render As vdRender) As vdRender.DrawStatus

        If (Not Isvalid) Then Return vdRender.DrawStatus.Failed
        Dim doDraw As vdRender.DrawStatus = MyBase.Draw(render)
        If doDraw = vdRender.DrawStatus.Successed Then
            render.DrawLine(Me, Figure1.BoundingBox.MidPoint, Figure2.BoundingBox.MidPoint)
        End If
        AfterDraw(render)
        Return doDraw
    End Function
    Public Overrides Sub Serialize(ByVal serializer As Serializer)
        MyBase.Serialize(serializer)
        serializer.Serialize(Figure1, "Figure1")
        serializer.Serialize(Figure2, "Figure2")
    End Sub
    Public Overrides Function DeSerialize(ByVal deserializer As DeSerializer, ByVal fieldname As String, ByVal value As Object) As Boolean
        If MyBase.DeSerialize(deserializer, fieldname, value) Then
            Return True
        ElseIf (fieldname = "Figure1") Then
            Figure1 = CType(value, vdFigure)
        ElseIf (fieldname = "Figure2") Then
            Figure2 = CType(value, vdFigure)
        Else
            Return False
        End If
        Return True
    End Function
    Public Overrides Function GetGripPoints() As gPoints
        Dim ret As gPoints = New gPoints()
        If (Figure1 Is Nothing Or Figure2 Is Nothing) Then Return ret
        ret.Add(gPoint.MidPoint(Figure1.BoundingBox.MidPoint, Figure2.BoundingBox.MidPoint))
        Return ret
    End Function
    Public Overrides Sub MoveGripPointsAt(ByVal Indexes As Int32Array, ByVal dx As Double, ByVal dy As Double, ByVal dz As Double)
        If Indexes Is Nothing Or Indexes.Count = 0 Or (dx = 0.0 And dy = 0.0 And dz = 0.0) Then
            Return
        End If
        Dim grips As gPoints = GetGripPoints()
        Dim mat As Matrix = New Matrix()
        mat.TranslateMatrix(dx, dy, dz)
        Dim index As Integer
        For Each index In Indexes
            Select Case index
                Case 0
                    If (Not Figure1 Is Nothing) Then Figure1.Transformby(mat)
                    If (Not Figure2 Is Nothing) Then Figure2.Transformby(mat)
                    Exit For
                Case Else
                    Exit For
            End Select
        Next
        Update()
    End Sub
    Private Sub Connect(ByVal fig As vdFigure)
        If (fig Is Nothing) Then Return
        AddHandler fig.OnAfterModifyObjectEx, AddressOf Fig_OnAfterModifyObjectEx
    End Sub
    Private Sub Disconnect(ByVal fig As vdFigure)
        If (fig Is Nothing) Then Return
        RemoveHandler fig.OnAfterModifyObjectEx, AddressOf Fig_OnAfterModifyObjectEx
    End Sub
    Private Sub Fig_OnAfterModifyObjectEx(ByVal sender As Object, ByVal propertyname As String)
        Me.Update()
        Me.Invalidate()
    End Sub
    Private Sub ResolveReferences(ByVal sourcefigure As vdFigure, ByVal referenceObjects As ResolveReferenceObjects) Implements ISupportResolveReferenceObjects.ResolveReferences
        Dim baseobj As vdLineConnection = CType(sourcefigure, vdLineConnection)
        Figure1 = referenceObjects.AddReference(baseobj.Figure1)
        Figure2 = referenceObjects.AddReference(baseobj.Figure2)
    End Sub
    Private Sub OnAddToSameSelection(ByVal selset As vdSelection) Implements ISupportResolveReferenceObjects.OnAddToSameSelection
    End Sub
    Protected Overrides Sub OnOwnerChanged()
        MyBase.OnOwnerChanged()
        If (Owner Is Nothing) Then
            Disconnect(mFig1)
            Disconnect(mFig2)
        End If
    End Sub

#End Region
End Class
