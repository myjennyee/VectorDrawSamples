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
'the VectorDrawCustomFigs.dll must be in the folder of vdrawcomponents
'or the supportpath must contain the path of the assemply dll

    Public Class VectorDrawPolygon
        Inherits vdShape
#Region "main variables"
        Private mTextStyle As vdTextstyle = Nothing
        Private mNumSides As Integer = 4
        Private mText As String = ""
        Private mTextHeight As Double = 1D
        Private mRadius As Double = 1D
#End Region

#Region "ctor"
        Public Sub New()
        End Sub
#End Region

#Region "not vdShape supported properties"
        <Browsable(False)> _
        Public Overrides Property Rotation() As Double
            Get
                'return base.Rotation;
                Return 0D
            End Get
            Set(ByVal Value As Double)
                'base.Rotation = value;
            End Set
        End Property
        <Browsable(False)> _
        Public Overrides Property Scales() As Vector
            Get
                'return base.Scales;
                Return New Vector(1D, 1D, 1D)
            End Get
            Set(ByVal Value As Vector)
                'base.Scales = value;
            End Set
        End Property
#End Region
#Region "vdShape override properties"
        Public Overrides Property Origin() As gPoint
            Get
                Return MyBase.Origin
            End Get
            Set(ByVal Value As gPoint)
                MyBase.Origin = Value
                Update()
            End Set
        End Property
#End Region
#Region "properties"
        'You should use the AddHistory command in your properties so any change will be writen to the history
    'The string in the AddHistory command is the name of the property exactly and should be called before the property change.
        Public Property NumSides() As Integer
            Get
                Return mNumSides
            End Get
            Set(ByVal Value As Integer)
                AddHistory("NumSides", Value)
                mNumSides = Value
            End Set
        End Property
        Public Property TextString() As String
            Get
                Return mText
            End Get
            Set(ByVal Value As String)
                AddHistory("TextString", Value)
                mText = Value
            End Set
        End Property
        Public Property Radius() As Double
            Get
                Return mRadius
            End Get
            Set(ByVal Value As Double)
                AddHistory("Radius", Value)
                mRadius = Value
            End Set
        End Property
        Public Property TextStyle() As vdTextstyle
            Get
                Return mTextStyle
            End Get
            Set(ByVal Value As vdTextstyle)
                AddHistory("TextStyle", Value)
                mTextStyle = Value
            End Set
        End Property
        Public Property TextHeight() As Double
            Get
                Return mTextHeight
            End Get
            Set(ByVal Value As Double)
                AddHistory("TextHeight", Value)
                mTextHeight = Value
            End Set
        End Property
#End Region
#Region "serialization"
    'Note that not all values/objects can be saved/serialize by VDF, and you need to write code for such properties in serialize/deserialize override of this object. 
    'You can set value of custom property to any of the following type values: 
    '     String, Double, Int32, Boolean, Byte, Int16, Int64, UInt16, UInt64, UInt32, Single, ushort, System.Color, VectorDraw.Serialize.IVDHandle and IVDSerialise
    Public Overrides Sub Serialize(ByVal serializer As Serializer)
        MyBase.Serialize(serializer)
        serializer.Serialize(mNumSides, "NumSides")
        serializer.Serialize(mRadius, "Radius")
        serializer.Serialize(mText, "TextString")
        serializer.Serialize(mTextStyle, "TextStyle")
        serializer.Serialize(mTextHeight, "TextHeight")
    End Sub
    Public Overrides Function DeSerialize(ByVal deserializer As DeSerializer, ByVal fieldname As String, ByVal value As Object) As Boolean
        If MyBase.DeSerialize(deserializer, fieldname, value) Then
            Return True
        ElseIf fieldname = "NumSides" Then
            mNumSides = CType(value, Integer)
        ElseIf fieldname = "Radius" Then
            mRadius = CType(value, Double)
        ElseIf fieldname = "TextString" Then
            mText = CType(value, String)
        ElseIf fieldname = "TextStyle" Then
            mTextStyle = CType(value, vdTextstyle)
        ElseIf fieldname = "TextHeight" Then
            mTextHeight = CType(value, Double)
        Else : Return False
        End If
        Return True
    End Function
#End Region
#Region "curve calulation"
        Public Overrides Sub FillShapeEntities(ByRef entities As vdEntities) 'calculate shape entities in ecs 
            Dim text As vdText = New vdText()
            entities.AddItem(text)
            text.MatchProperties(Me, Document)

            text.Style = TextStyle
            text.TextString = TextString
            text.VerJustify = VdConstVerJust.VdTextVerCen
            text.HorJustify = VdConstHorJust.VdTextHorCenter
            text.Height = TextHeight

            Dim pl As vdPolyline = New vdPolyline()
            entities.AddItem(pl)
            pl.MatchProperties(Me, Document)
            Dim verts As Vertexes = New Vertexes()
            Dim stepangle As Double = Globals.VD_TWOPI / Me.NumSides
            Dim sang As Double = 0D
            Dim cen As gPoint = New gPoint()
            Dim i As Integer
            For i = 0 To NumSides - 1 Step i + 1
                verts.Add(gPoint.Polar(cen, sang, Radius))
                sang += stepangle
            Next
            pl.VertexList = verts
            pl.Flag = VdConstPlineFlag.PlFlagCLOSE

        End Sub
#End Region
#Region "overrides"
        Protected Overrides Sub OnDocumentDefaults()
            MyBase.OnDocumentDefaults()
            mTextStyle = Document.ActiveTextStyle
            If mTextStyle Is Nothing Then
                mTextStyle = Document.TextStyles.Standard
            End If
        End Sub
        Public Overrides Sub InitializeProperties()
            mNumSides = 4
            mText = ""
            mTextHeight = 1D
            mTextStyle = Nothing
            If Not Document Is Nothing Then
                mTextStyle = Document.TextStyles.Standard
            End If
            mRadius = 1D
            MyBase.InitializeProperties()
        End Sub
        Public Overrides Sub MatchProperties(ByVal _from As VectorDraw.Professional.vdObjects.vdPrimary, ByVal thisdocument As VectorDraw.Professional.vdObjects.vdDocument)
            MyBase.MatchProperties(_from, thisdocument)
            Dim from As VectorDrawPolygon = CType(_from, VectorDrawPolygon)
            If from Is Nothing Then
                Return
            End If
            TextString = from.TextString
            NumSides = from.NumSides
            Radius = from.Radius
            TextStyle = from.TextStyle
            TextHeight = from.TextHeight
        End Sub
        Public Overrides Sub Transformby(ByVal mat As Matrix)
            If mat.IsUnitMatrix() Then
                Return
            End If
            Dim mult As Matrix = (ECSMatrix * mat)
            Dim matprops As MatrixProperties = mult.Properties
            Radius *= matprops.GetScaleXY()
            TextHeight *= matprops.GetScaleXY()
            MyBase.Transformby(mat)
        End Sub
        Public Overrides Function GetGripPoints() As gPoints
            Dim ret As gPoints = New gPoints()
            Dim cen As gPoint = New gPoint()
            ret.Add(cen)
            Dim stepangle As Double = Globals.VD_TWOPI / Me.NumSides
            Dim sang As Double = 0D
            Dim i As Integer
            For i = 0 To NumSides - 1 Step i + 1
                ret.Add(gPoint.Polar(cen, sang, Radius))
                sang += stepangle
            Next
            ECSMatrix.Transform(ret)
            Return ret
        End Function

        Public Overrides Sub MoveGripPointsAt(ByVal Indexes As Int32Array, ByVal dx As Double, ByVal dy As Double, ByVal dz As Double)
            If Indexes Is Nothing Or Indexes.Count = 0 Or (dx = 0.0 And dy = 0.0 And dz = 0.0) Then
                Return
            End If
            Dim mat As Matrix = New Matrix()
            mat.TranslateMatrix(dx, dy, dz)
            Dim grips As gPoints = GetGripPoints()
            ECSMatrix.GetInvertion().Transform(grips)
            If Indexes.Count = grips.Count Then

                Transformby(mat)
            Else
                Dim index As Integer
                For Each index In Indexes
                    Select Case index
                        Case 0
                            Transformby(mat)
                            Exit For
                        Case Else
                            Dim grip As gPoint = New gPoint(grips(index))
                            grip = ECSMatrix.Transform(grip)
                            grip += New gPoint(dx, dy, dz)
                            Me.Radius = gPoint.Distance2D(grip, Me.Origin)
                            Exit For
                    End Select
                Next
            End If
            Update()
    End Sub

    Public Overrides Function IsTableObjectDependOn(ByVal table As VectorDraw.Professional.vdObjects.vdPrimary) As Boolean
        If Deleted = True Then Return False ''always check if this object is deleted
        If MyBase.IsTableObjectDependOn(table) = True Then Return True ''always check the base implamentation
        ''check properties of object that reference the table object.
        If Not TextStyle Is Nothing And Object.ReferenceEquals(TextStyle, table) = True Then Return True
        Return False
    End Function
#End Region

End Class
Public Class ActionPolygon
    Inherits ActionEntityEx
    Private figure As VectorDrawPolygon
    Public Sub New(ByVal NumSides As Integer, ByVal text As String, ByVal textheight As Double, ByVal reference As gPoint, ByVal layout As vdLayout)
        MyBase.New(reference, layout)
        figure = New VectorDrawPolygon()
        figure.SetUnRegisterDocument(layout.Document)
        figure.setDocumentDefaults()
        figure.Origin = reference
        figure.Radius = 0D
        figure.TextHeight = textheight
        figure.TextString = text
        figure.NumSides = NumSides
    End Sub
    Protected Overrides Sub OnMyPositionChanged(ByVal NewPosition As gPoint)
        figure.Radius = NewPosition.Distance3D(figure.Origin)
    End Sub
    Public Overrides ReadOnly Property Entity() As vdFigure
        Get
            Return figure
        End Get
    End Property
    Public Shared Sub CmdPolygon(ByVal doc As vdDocument)
        Dim cen As gPoint = New gPoint()
        doc.Prompt("Origin Point : ")
        Dim ret As Object = doc.ActionUtility.getUserPoint()
        doc.Prompt(Nothing)
        If ret Is Nothing Or Not (TypeOf ret Is gPoint) Then
            Return
        End If
        cen = CType(ret, gPoint)
        doc.Prompt("Textstring : ")
        Dim text As String = doc.ActionUtility.getUserString()
        doc.Prompt(Nothing)
        If text Is Nothing Then
            Return
        End If
        doc.Prompt("Textheight : ")
        ret = doc.ActionUtility.getUserDist(cen)
        doc.Prompt(Nothing)
        If ret Is Nothing Then
            Return
        End If
        Dim textheight As Double = CType(ret, Double)
        Dim numsides As Integer = 0
        doc.Prompt("NumSides : ")
        Dim scode As StatusCode = doc.ActionUtility.getUserInt(numsides)
        doc.Prompt(Nothing)
        If scode <> VectorDraw.Actions.StatusCode.Success Then
            Return
        End If
        doc.Prompt("Radius : ")
        Dim aFig As ActionPolygon = New ActionPolygon(numsides, text, textheight, cen, doc.ActiveLayOut)
        doc.ActionAdd(aFig)
        scode = aFig.WaitToFinish()
        doc.Prompt(Nothing)
        If scode <> VectorDraw.Actions.StatusCode.Success Then
            Return
        End If
        aFig.Entity.Transformby(doc.User2WorldMatrix)
        doc.ActionLayout.Entities.AddItem(aFig.Entity)
        doc.ActionDrawFigure(aFig.Entity)
        Return
    End Sub
End Class
