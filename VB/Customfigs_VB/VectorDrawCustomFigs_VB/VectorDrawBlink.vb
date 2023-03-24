Imports System
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Windows.Forms
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

    Public Class VectorDrawBlink
        Inherits vdShape
#Region "Main Variables"
        Private mRadius As Double = 1D
        Private mhatchprops As vdHatchProperties = Nothing
        Private mtimer As System.Windows.Forms.Timer = Nothing
        Private mAngle As Double = 0D
        Private mAngleDifference As Double = VectorDraw.Geometry.Globals.DegreesToRadians(5.0)
        Private mInterval As Integer = 500
        Private mShowLines As Boolean = True
#End Region

#Region "ctors + Timer"
        Public Sub New()
            mhatchprops = New vdHatchProperties()
            mhatchprops.SetUnRegisterDocument(Document)
            mhatchprops.FillMode = VdConstFill.VdFillModeSolid
        End Sub
        Private Function IsTimerOn() As Boolean
            If Not (mtimer Is Nothing) And mtimer.enabled Then Return True
            Return False
        End Function
        Private Sub SetTimer()
            ReleaseTimer()
            mtimer = New Timer()
            mtimer.Interval = mInterval
            AddHandler mtimer.Tick, AddressOf mtimer_Tick
            mtimer.Start()
        End Sub
        Private Sub ReleaseTimer()
            If (mtimer Is Nothing) Then Return
            RemoveHandler mtimer.Tick, AddressOf mtimer_Tick
            mtimer.Stop()
            mtimer = Nothing
        End Sub
        'Sub overrides Finalize()
        Protected Overrides Sub Finalize()
            ReleaseTimer()
        End Sub
        Sub mtimer_Tick(ByVal sender As Object, ByVal e As EventArgs)

            If (Not Me.IsDocumentRegister) Then Return
            If (Document.ActiveLayOut.OverAllActiveActions.Count > 1) Then Return
            Me.Invalidate()
            If (mhatchprops.FillMode = VdConstFill.VdFillModeSolid) Then
                mhatchprops.FillMode = VdConstFill.VdFillModeNone
            Else

                mhatchprops.FillMode = VdConstFill.VdFillModeSolid
                mAngle += mAngleDifference
                If (mAngle > VectorDraw.Geometry.Globals.VD_TWOPI) Then mAngle = 0.0
            End If
            Me.Update()
            Me.Invalidate()
        End Sub
        Protected Overrides Sub OnDocumentSelected(ByVal document As vdDocument)
            MyBase.OnDocumentSelected(document)
            If (Me.IsDocumentRegister) Then
                SetTimer()
            Else
                ReleaseTimer()
            End If
        End Sub
        Public Overrides Property Deleted() As Boolean
            Get
                Return MyBase.Deleted
            End Get
            Set(ByVal Value As Boolean)
                MyBase.Deleted = Value
                If (Value) Then
                    ReleaseTimer()
                Else
                    SetTimer()
                End If
            End Set
        End Property
        Protected Overrides Sub OnOwnerChanged()

            MyBase.OnOwnerChanged()
            If (Me.Owner Is Nothing) Then ReleaseTimer()
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

#Region "Public Properties"
        'You should use the AddHistory command in your properties so any change will be writen to the history
    'The string in the AddHistory command is the name of the property exactly and should be called before the property change.
        Public Property Radius() As Double
            Get
                Return mRadius
            End Get
            Set(ByVal Value As Double)
                AddHistory("Radius", Value)
                mRadius = Value
            End Set
        End Property
        Public Property Interval() As Integer
            Get
                Return mInterval
            End Get
            Set(ByVal Value As Integer)
                AddHistory("Interval", Value)
                mInterval = Value
                If IsTimerOn() Then
                    mtimer.Interval = mInterval
                End If
            End Set
        End Property
        Public Property LineRotAngleDifference() As Double
            Get
                Return VectorDraw.Geometry.Globals.RadiansToDegrees(mAngleDifference)
            End Get
            Set(ByVal Value As Double)
                AddHistory("LineRotAngleDifference", Value)
                mAngleDifference = VectorDraw.Geometry.Globals.DegreesToRadians(Value)
            End Set
        End Property
        Public Property ShowLines() As Boolean
            Get
                Return mShowLines
            End Get
            Set(ByVal Value As Boolean)
                AddHistory("ShowLines", Value)
                mShowLines = Value
            End Set
        End Property
#End Region

#Region "Serialization"
    'Note that not all values/objects can be saved/serialize by VDF, and you need to write code for such properties in serialize/deserialize override of this object. 
    'You can set value of custom property to any of the following type values: 
    '     String, Double, Int32, Boolean, Byte, Int16, Int64, UInt16, UInt64, UInt32, Single, ushort, System.Color, VectorDraw.Serialize.IVDHandle and IVDSerialise
    Public Overrides Sub Serialize(ByVal serializer As Serializer)
        MyBase.Serialize(serializer)
        serializer.Serialize(mRadius, "Radius")
        serializer.Serialize(mInterval, "Interval")
        serializer.Serialize(mAngleDifference, "LineRotAngleDifference")
        serializer.Serialize(mShowLines, "ShowLines")

    End Sub
    Public Overrides Function DeSerialize(ByVal deserializer As DeSerializer, ByVal fieldname As String, ByVal value As Object) As Boolean
        If MyBase.DeSerialize(deserializer, fieldname, value) Then
            Return True
        ElseIf fieldname = "Radius" Then
            mRadius = CType(value, Double)
        ElseIf fieldname = ("Interval") Then
            mInterval = CType(value, Integer)
        ElseIf fieldname = ("LineRotAngleDifference") Then
            mAngleDifference = CType(value, Double)
        ElseIf fieldname = ("ShowLines") Then
            mShowLines = CType(value, Boolean)
        Else : Return False
        End If
        Return True
    End Function
#End Region

#Region "Object Figure Calculations"
        Public Overrides Sub FillShapeEntities(ByRef entities As vdEntities)

            Dim circle As vdCircle = New vdCircle()
            entities.AddItem(circle)
            circle.MatchProperties(Me, Document)
            circle.Radius = mRadius
            circle.HatchProperties = mhatchprops

            If (mShowLines) Then

                Dim cen As gPoint = New gPoint()
                Dim line1 As vdLine
                Dim angle As Double = 0.0
                Dim i As Integer
                For i = 0 To 4 - 1 Step i + 1
                    line1 = New vdLine()
                    line1.MatchProperties(Me, Document)
                    If (mhatchprops.FillMode = VdConstFill.VdFillModeNone) Then line1.LineType = Document.LineTypes.Invisible

                    line1.StartPoint = New gPoint(gPoint.Polar(cen, angle + mAngle, 3D * mRadius / 2D))
                    line1.EndPoint = New gPoint(gPoint.Polar(cen, angle + mAngle, 2D * mRadius))
                    angle += VectorDraw.Geometry.Globals.HALF_PI
                    entities.AddItem(line1)
                Next
            End If
        End Sub
#End Region

#Region "Overrides"
        Public Overrides Sub InitializeProperties()
            mRadius = 1D
            mhatchprops = Nothing
            mAngle = 0D
            mAngleDifference = VectorDraw.Geometry.Globals.DegreesToRadians(5.0)
            mInterval = 500
            mShowLines = True
            MyBase.InitializeProperties()
        End Sub
        Public Overrides Sub MatchProperties(ByVal _from As VectorDraw.Professional.vdObjects.vdPrimary, ByVal thisdocument As VectorDraw.Professional.vdObjects.vdDocument)
            MyBase.MatchProperties(_from, thisdocument)
            Dim from1 As VectorDrawBlink = CType(_from, VectorDrawBlink)
            If from1 Is Nothing Then
                Return
            End If
            Radius = from1.Radius
            LineRotAngleDifference = from1.LineRotAngleDifference
            Interval = from1.Interval
            ShowLines = from1.ShowLines
        End Sub

        Public Overrides Sub Transformby(ByVal mat As Matrix)
            If mat.IsUnitMatrix() Then
                Return
            End If
            Dim mult As Matrix = (ECSMatrix * mat)
            Dim matprops As MatrixProperties = mult.Properties
            Radius *= matprops.GetScaleXY()
            MyBase.Transformby(mat)
        End Sub
        Public Overrides Function GetGripPoints() As gPoints
            Dim ret As gPoints = New gPoints()
            Dim cen As gPoint = New gPoint()
            ret.Add(cen)
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
            Transformby(mat)
            Update()
    End Sub
    Public Overrides Function IsTableObjectDependOn(ByVal table As VectorDraw.Professional.vdObjects.vdPrimary) As Boolean
        If Deleted = True Then Return False ''always check if this object is deleted
        If MyBase.IsTableObjectDependOn(table) = True Then Return True ''always check the base implamentation
        ''check properties of object that reference the table object.
        If Not mhatchprops Is Nothing And mhatchprops.IsTableObjectDependOn(table) = True Then Return True
        Return False
    End Function
#End Region
    End Class

    Public Class ActionBlink
        Inherits ActionEntity
        Private figure As VectorDrawBlink
        Public Sub New(ByVal reference As gPoint, ByVal layout As vdLayout)
            MyBase.New(reference, Layout)
            ' ValueType = Valuetype | valueType.DISTANCE
            figure = New VectorDrawBlink()
            figure.SetUnRegisterDocument(layout.Document)
            figure.setDocumentDefaults()
            figure.Origin = reference
        End Sub
        Protected Overrides Sub OnMyPositionChanged(ByVal NewPosition As gPoint)
            figure.Radius = NewPosition.Distance3D(figure.Origin)
        End Sub
        Public Overrides ReadOnly Property Entity() As vdFigure
            Get
                Return figure
            End Get
        End Property
        Public Shared Sub CmdBlink(ByVal doc As vdDocument)
            Dim cen As gPoint = New gPoint()
            doc.Prompt("Origin-Center Point : ")
            Dim ret As Object = doc.ActionUtility.getUserPoint()
            doc.Prompt(Nothing)
            If ret Is Nothing Or Not (TypeOf ret Is gPoint) Then
                Return
            End If
            cen = CType(ret, gPoint)
            doc.Prompt("Radius : ")
            Dim aFig As ActionBlink = New ActionBlink(cen, doc.ActiveLayOut)
            doc.ActionAdd(aFig)
            Dim scode As StatusCode = aFig.WaitToFinish()
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

