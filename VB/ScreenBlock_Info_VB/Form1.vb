Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports VectorDraw.Professional.vdObjects
Imports VectorDraw.Professional.vdPrimaries
Imports VectorDraw.Professional.vdFigures
Imports System.Drawing.Drawing2D
Imports VectorDraw.Professional.vdCollections
Imports VectorDraw.Geometry

Public Class Form1

#Region "Variables"
    'private variables required.
    Private Doc As VectorDraw.Professional.vdObjects.vdDocument = Nothing
    ' the vdDocument object
    Private ScreenBLK As New vdScreenBlock()
    ' The ScreenBlock object 
#End Region

#Region "Form_Events"
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Doc = VdFramedControl1.BaseControl.ActiveDocument

        ' set the filename and author
        Doc.FileName = "VectorDraw.VDML"
        Doc.FileProperties.Author = "Matt"

        ' hide the unnecessary components
        VdFramedControl1.BaseControl.EnableAutoGripOn = False
        VdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.CommandLine, False)
        VdFramedControl1.SetLayoutStyle(vdControls.vdFramedControl.LayoutStyle.PropertyGrid, False)
        Doc.GlobalRenderProperties.Wire2dUseFontOutLines = VectorDraw.Render.vdRenderGlobalProperties.Wire2dUseFontOutLinesFlag.UseAPIWithScaleText

        AddHandler Doc.OnDrawOverAll, AddressOf Docu_OnDrawOverAll ' here we will draw the screen blocks
        AddHandler Doc.OnAfterNewDocument, AddressOf Docu_OnAfterNewDocument
        AddHandler Doc.OnScroll, AddressOf Docu_OnScroll
        AddHandler Doc.OnAfterOpenDocument, AddressOf Docu_OnAfterOpenDocument ' this event is used for the update of the INFO block
        AddHandler Doc.OnAfterNewDocument, AddressOf Docu_OnAfterNewDocument ' this event is used for the update of the INFO block
        AddHandler VdFramedControl1.BaseControl.vdMouseDown, AddressOf BaseControl_vdMouseDown

        ' create a small 3D drawing
        Doc.CommandAction.CmdSphere(New gPoint(27, 2), 4.0, 15, 15)
        Doc.CommandAction.CmdSphere(New gPoint(9, 27, 2), 11.0, 15, 15)
        'initialization for the demonstration
        Doc.ShowUCSAxis = False
        cbVDFAxis.Checked = False
        rdb3D.Checked = True
        rdb3D_CheckedChanged(sender, e)
        rdbInfo.Checked = False
        Doc.CommandAction.Zoom("E", 0, 0)

    End Sub
    'override in order to avoid the screen bitmap scrolling when we are in 2d render mode.
    Private Sub Docu_OnScroll(ByVal sender As Object, ByRef cx As Double, ByRef cy As Double, ByRef cancel As Boolean)
        Dim render As VectorDraw.Render.vdRender = TryCast(sender, VectorDraw.Render.vdRender)
        If render.PerspectiveMod = VectorDraw.Render.vdRender.VdConstPerspectiveMod.PerspectON Then

            Dim m As New VectorDraw.Geometry.Matrix()
            m.TranslateMatrix(-cx, -cy, 0.0)
            Doc.World2ViewMatrix *= m
        Else
            Doc.ViewCenter += New gPoint(cx, cy)
        End If
        Doc.Invalidate()
        cancel = True
    End Sub

    'override in order to get the entities of the screen block over the mouse location
    Private Sub BaseControl_vdMouseDown(ByVal e As MouseEventArgs, ByRef cancel As Boolean)
        If Doc Is Nothing OrElse ScreenBLK Is Nothing OrElse e.Button <> MouseButtons.Left Then
            Return
        End If
        Dim selectedObjects As VectorDraw.Render.RenderSelect.RenterSelectObjectArray = ScreenBLK.HitTestEx2(Doc, e.Location)
        If selectedObjects IsNot Nothing Then
            Dim fig As vdFigure = TryCast(selectedObjects(0).Outer(), vdFigure)
            MessageBox.Show(String.Format("Screen Block Entity of type {0} was picked", fig._TypeName))

            cancel = True
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
        If ScreenBLK IsNot Nothing Then
            ScreenBLK.Dispose()
        End If
        ' this is necessary
        ScreenBLK = Nothing
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Doc.CommandAction.View3D("VROT")
    End Sub

    Private Sub rdb3D_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdb3D.CheckedChanged
        If Doc Is Nothing Then Exit Sub
        If rdb3D.Checked Then
            ' enable the Custom3D  ScreenBlock

            ScreenBLK.Rendermode = VectorDraw.Render.vdRender.Mode.Shade
            ScreenBLK.Block = CreateCustom3D()
            ScreenBLK.Location = vdScreenBlock.LocationFlag.LeftTop
            ScreenBLK.Tranformation = vdScreenBlock.TranformationFlag.UserCS

            ScreenBLK.Height = 200
            ScreenBLK.Width = 200
            lblInfo.Text = "A custom 3D box labeled TOP, BOTTOM, LEFT etc that follow the View CS"
        End If
        Doc.Redraw(False)
    End Sub



    Private Sub rdbInfo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbInfo.CheckedChanged
        If Doc Is Nothing Then Exit Sub
        If rdbInfo.Checked Then
            ' enable the Information ScreenBlock

            ScreenBLK.Block = CreateInfo()
            'blkInfo;
            ScreenBLK.Rendermode = VectorDraw.Render.vdRender.Mode.Wire2dGdiPlus
            ScreenBLK.Location = vdScreenBlock.LocationFlag.RightBottom
            ScreenBLK.Tranformation = vdScreenBlock.TranformationFlag.ViewCS
            ScreenBLK.Height = 120
            ScreenBLK.Width = 270
            lblInfo.Text = "Some information, like the company name, date, author and filename"
        End If
        Doc.Redraw(False)
    End Sub

    Private Sub btnRotate3DView_Click(ByVal sender As Object, ByVal e As EventArgs)
        Doc.CommandAction.View3D("VROT")
    End Sub

#End Region

#Region "blocks_for_ScreenBlock"
    Private Function CreateCustom3D() As vdBlock
        ' create the block for the Custom 3D axis/box
        Dim textheight As Double = 0.15
        Dim textthick As Double = 0.01
        Dim boxsize As Double = 0.7
        Dim halfboxsize As Double = boxsize / 2.0
        Dim ph As New vdPolyhatch(Doc, New vdPolyCurves(New vdCurves() {New vdCurves(New vdCurve() {New vdCircle(Doc, New gPoint(), 1.0), New vdCircle(Doc, New gPoint(), 0.8)})}), New vdColor(Color.LightGray, 64), True)
        Dim text_N As New vdText(Doc, "N", New gPoint(0.0, 0.9), 0.5, VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter, VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen, _
         Nothing)
        text_N.Thickness = textthick
        text_N.PenColor.FromSystemColor(Color.Green)

        Dim text_S As New vdText(Doc, "S", New gPoint(0.0, -0.9), 0.5, VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter, VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen, _
         Nothing)
        text_S.Thickness = textthick
        text_S.PenColor.FromSystemColor(Color.Green)
        Dim text_E As New vdText(Doc, "E", New gPoint(0.9, 0.0), 0.5, VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter, VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen, _
         Nothing)
        text_E.Thickness = textthick
        text_E.PenColor.FromSystemColor(Color.Red)
        Dim text_W As New vdText(Doc, "W", New gPoint(-0.9, 0.0), 0.5, VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter, VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen, _
         Nothing)
        text_W.Thickness = textthick
        text_W.PenColor.FromSystemColor(Color.Red)
        Dim box As New vdPolyface(Doc)
        box.CreateBox(New gPoint(-halfboxsize, -halfboxsize), boxsize, boxsize, boxsize, 0.0)
        Dim m As New VectorDraw.Geometry.Matrix()
        m.SetFrom(New gPoint(0.0, 0.0, boxsize), New Vector(1, 0, 0), New Vector(0, 1, 0))
        Dim text_TOP As New vdText(Doc, "TOP", New gPoint(), textheight, VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter, VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen, _
         Nothing)
        text_TOP.Thickness = textthick
        text_TOP.PenColor.FromSystemColor(Color.Blue)
        text_TOP.Transformby(m.GetInvertion())
        m.SetFrom(New gPoint(0.0, 0.0, 0.0), New Vector(1, 0, 0), New Vector(0, -1, 0))
        Dim text_BOTTOM As New vdText(Doc, "BOTTOM", New gPoint(), textheight, VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter, VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen, _
         Nothing)
        text_BOTTOM.Thickness = textthick
        text_BOTTOM.PenColor.FromSystemColor(Color.Blue)
        text_BOTTOM.WidthFactor = 0.7
        text_BOTTOM.Transformby(m.GetInvertion())
        text_BOTTOM.Rotation = 0.0
        m.SetFrom(New gPoint(-halfboxsize, 0.0, halfboxsize), New Vector(0, -1, 0), New Vector(0, 0, 1))
        Dim text_LEFT As New vdText(Doc, "LEFT", New gPoint(), textheight, VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter, VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen, _
         Nothing)
        text_LEFT.Thickness = textthick
        text_LEFT.PenColor.FromSystemColor(Color.Red)
        text_LEFT.Transformby(m.GetInvertion())
        m.SetFrom(New gPoint(halfboxsize, 0.0, halfboxsize), New Vector(0, 1, 0), New Vector(0, 0, 1))
        Dim text_RIGHT As New vdText(Doc, "RIGHT", New gPoint(), textheight, VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter, VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen, _
         Nothing)
        text_RIGHT.Thickness = textthick
        text_RIGHT.PenColor.FromSystemColor(Color.Red)
        text_RIGHT.Transformby(m.GetInvertion())
        m.SetFrom(New gPoint(0.0, -halfboxsize, halfboxsize), New Vector(1, 0, 0), New Vector(0, 0, 1))
        Dim text_FRONT As New vdText(Doc, "FRONT", New gPoint(), textheight, VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter, VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen, _
         Nothing)
        text_FRONT.Thickness = textthick
        text_FRONT.PenColor.FromSystemColor(Color.Green)
        text_FRONT.Transformby(m.GetInvertion())
        m.SetFrom(New gPoint(0.0, halfboxsize, halfboxsize), New Vector(-1, 0, 0), New Vector(0, 0, 1))
        Dim text_BACK As New vdText(Doc, "BACK", New gPoint(), textheight, VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter, VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen, _
         Nothing)
        text_BACK.Thickness = textthick
        text_BACK.PenColor.FromSystemColor(Color.Green)
        text_BACK.Transformby(m.GetInvertion())
        Dim figs As vdFigure() = New vdFigure() {ph, box, text_N, text_S, text_E, text_W, _
         text_TOP, text_BOTTOM, text_LEFT, text_RIGHT, text_FRONT, text_BACK}
        Dim block As New vdBlock(Doc)
        block.Entities.AddItems(figs)
        Return block

    End Function



    Private Function CreateInfo() As vdBlock
        ' create the block that displays the CompanyName, date, filename and author of the drawing 
        Dim block As New vdBlock(Doc)
        Dim mtext As New vdMText(Doc, String.Format("{{\C1;VectorDraw & CO. E.E.}}\P{{\C2;{0}}}\P{{\C3;{1}}}", Doc.FileProperties.Author, VectorDraw.Professional.Utilities.vdGlobals.GetFileName(Doc.FileName)), New gPoint(), 1.0)
        mtext.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        block.Entities.AddItem(mtext)
        Return block
    End Function

#End Region

#Region "VDF_Events_to_use"
    ' this event is used for the update of the INFO block
    Private Sub Docu_OnAfterNewDocument(ByVal sender As Object) 'Handles Doc.OnAfterNewDocument
        Doc.FileProperties.Author = "Chanios Peter"
    End Sub
    ' this event is used for the update of the INFO block
    Private Sub Docu_OnAfterOpenDocument(ByVal sender As Object) 'Handles Doc.OnAfterOpenDocument
        If Doc.FileProperties.Author.Trim() = "" Then
            Doc.FileProperties.Author = "Chanios Peter"
        End If
    End Sub

    Private Sub Docu_OnDrawAfter(ByVal sender As Object, ByVal render As VectorDraw.Render.vdRender) 'Handles Doc.OnDrawAfter
        'If ScreenBLK IsNot Nothing Then  ScreenBLK.Draw(render)
    End Sub

    ' here we will draw the screen blocks
    Private Sub Docu_OnDrawOverAll(ByVal sender As Object, ByVal render As VectorDraw.Render.vdRender, ByRef cancel As Boolean) 'Handles Doc.OnDrawOverAll
        ' In this event the ScreenBlock in drawn
        ScreenBLK.Draw(render)
        ' Draw the block

    End Sub

#End Region

 
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub cbVDFAxis_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbVDFAxis.CheckedChanged
        If Doc Is Nothing Then Exit Sub
        ' enable/disable the default XYZ axis icon
        Doc.ShowUCSAxis = cbVDFAxis.Checked
        Doc.Redraw(False)
    End Sub
End Class
