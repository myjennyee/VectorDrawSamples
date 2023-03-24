Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports VectorDraw.Professional.vdCollections
Imports VectorDraw.Professional.vdObjects
Imports VectorDraw.Professional.vdPrimaries
Imports VectorDraw.Professional.vdFigures
Imports VectorDraw.Geometry

' Description : 
' This is a simple sample demonstrating another aspect of our control.
' A speedometer is created using code and then the speed is increased to show a different progress bar from 0 to 100 count.


Public Class Form1
#Region "Initialize Form"
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        VectorDrawBaseControl1.ActiveDocument.ShowUCSAxis = False
        VectorDrawBaseControl1.ActiveDocument.EnableAutoGripOn = False
        VectorDrawBaseControl1.ActiveDocument.MouseWheelZoomScale = 1.0
        comboSpeed.SelectedIndex = 1
        DrawScene()
    End Sub

    Private Sub VectorDrawBaseControl1_ActionStart(ByVal sender As Object, ByVal actionName As String, ByRef cancel As Boolean) Handles VectorDrawBaseControl1.ActionStart
        If (actionName = "BaseAction_ActionPan") Then cancel = True
    End Sub

    Private Sub VectorDrawBaseControl1_vdMouseEnter(ByVal e As System.EventArgs, ByRef cancel As Boolean) Handles VectorDrawBaseControl1.vdMouseEnter
        VectorDrawBaseControl1.SetCustomMousePointer(System.Windows.Forms.Cursors.No)
    End Sub
#End Region
#Region "Draw Scene"
    Dim xLine As vdLine
    Dim xText As vdText
    Private Sub DrawScene()

        VectorDrawBaseControl1.ActiveDocument.[New]()

        'Draw scene
        Dim circle As New vdCircle()
        circle.SetUnRegisterDocument(vectorDrawBaseControl1.ActiveDocument)
        circle.setDocumentDefaults()
        circle.HatchProperties = New vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid)
        circle.HatchProperties.FillColor.ColorIndex = 3
        circle.HatchProperties.gradientTypeProp = VectorDraw.Render.vdGdiPenStyle.GradientType.LinearInverted
        circle.HatchProperties.gradientColor2.FromRGB(56, 151, 198)
        circle.HatchProperties.gradientAngle = VectorDraw.Geometry.Globals.DegreesToRadians(90.0)
        circle.Radius = 20.0
        circle.PenColor.ColorIndex = 3
        vectorDrawBaseControl1.ActiveDocument.Model.Entities.AddItem(circle)

        circle = New vdCircle()
        circle.SetUnRegisterDocument(vectorDrawBaseControl1.ActiveDocument)
        circle.setDocumentDefaults()
        circle.HatchProperties = New vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid)
        circle.HatchProperties.FillColor.ColorIndex = 249
        circle.Radius = 2.5
        circle.PenColor.ColorIndex = 249
        vectorDrawBaseControl1.ActiveDocument.Model.Entities.AddItem(circle)

        circle = New vdCircle()
        circle.SetUnRegisterDocument(vectorDrawBaseControl1.ActiveDocument)
        circle.setDocumentDefaults()
        circle.HatchProperties = New vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid)
        circle.HatchProperties.FillColor.ColorIndex = 0
        circle.Radius = 1.0
        circle.PenColor.ColorIndex = 0
        vectorDrawBaseControl1.ActiveDocument.Model.Entities.AddItem(circle)

        Dim Large As Boolean
        Large = True
        Dim txtStr As Double
        txtStr = 100.0
        Dim i As Double
        For i = 0.0 To 220.0 Step i + 22.0
            Dim Line As New vdLine()
            Line.SetUnRegisterDocument(vectorDrawBaseControl1.ActiveDocument)
            Line.setDocumentDefaults()
            If (Large) Then
                Line.StartPoint = gPoint.Polar(New gPoint(), VectorDraw.Geometry.Globals.DegreesToRadians(i), 15.5)
            Else
                Line.StartPoint = gPoint.Polar(New gPoint(), VectorDraw.Geometry.Globals.DegreesToRadians(i), 18.5)
            End If

            Line.EndPoint = gPoint.Polar(New gPoint(), VectorDraw.Geometry.Globals.DegreesToRadians(i), 19.0)
            Line.LineWeight = VectorDraw.Professional.Constants.VdConstLineWeight.LW_211
            vectorDrawBaseControl1.ActiveDocument.Model.Entities.AddItem(Line)

            If (Large) Then
                Dim txt As New vdText()
                txt.SetUnRegisterDocument(vectorDrawBaseControl1.ActiveDocument)
                txt.setDocumentDefaults()
                txt.InsertionPoint = gPoint.Polar(New gPoint(), VectorDraw.Geometry.Globals.DegreesToRadians(i), 12.0)
                txt.TextString = txtStr.ToString()
                txt.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
                txt.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
                txt.Height = 2.5
                vectorDrawBaseControl1.ActiveDocument.Model.Entities.AddItem(txt)
                txtStr -= 20.0
            End If
            Large = (Not Large)
        Next i

        Dim Line1 As New vdLine()
        Line1.SetUnRegisterDocument(vectorDrawBaseControl1.ActiveDocument)
        Line1.setDocumentDefaults()
        Line1.StartPoint = New gPoint()
        Line1.EndPoint = gPoint.Polar(New gPoint(), VectorDraw.Geometry.Globals.DegreesToRadians(220.0), 17.5)
        Line1.PenWidth = 0.7
        Line1.PenColor.ColorIndex = 0
        vectorDrawBaseControl1.ActiveDocument.Model.Entities.AddItem(Line1)
        xLine = Line1

        Dim rect As New vdRect()
        rect.SetUnRegisterDocument(vectorDrawBaseControl1.ActiveDocument)
        rect.setDocumentDefaults()
        rect.HatchProperties = New vdHatchProperties(VectorDraw.Professional.Constants.VdConstFill.VdFillModeSolid)
        rect.HatchProperties.FillColor.ColorIndex = 249
        rect.PenColor.ColorIndex = 249
        rect.InsertionPoint = New gPoint(2.0, -12.0, 0.0)
        rect.Height = 7.0
        rect.Width = 11.0
        vectorDrawBaseControl1.ActiveDocument.Model.Entities.AddItem(rect)

        Dim txt1 As New vdText()
        txt1.SetUnRegisterDocument(vectorDrawBaseControl1.ActiveDocument)
        txt1.setDocumentDefaults()
        txt1.InsertionPoint = New gPoint(4.0, -9.0, 0.0)
        txt1.TextString = "0"
        txt1.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorLeft
        txt1.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerCen
        txt1.Height = 4.5
        vectorDrawBaseControl1.ActiveDocument.Model.Entities.AddItem(txt1)
        xText = txt1

        vectorDrawBaseControl1.ActiveDocument.ZoomExtents()
    End Sub
        Private Sub SetScene(value as Integer)
        Dim val As Integer
        val = value
        xText.TextString = val.ToString()
        xText.Update()
        xText.Invalidate()

        Dim rnd As New System.Random
        Dim rndint As Integer
        rndint = rnd.Next(0, 6)
        If (val = 100) Then rndint = 0
        xLine.EndPoint = gPoint.Polar(New gPoint(), VectorDraw.Geometry.Globals.DegreesToRadians(220.0 - (2.2 * val + rndint)), 17.5)
        xLine.Update()
        vectorDrawBaseControl1.ActiveDocument.Redraw(True)
    End Sub
#End Region

#Region "Button code"
    Private Sub butStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butStart.Click
        progressBar1.Value = 0
        progressBar1.Minimum = 0
        Select Case comboSpeed.SelectedIndex


            Case 0
                progressBar1.Maximum = 100
                Exit Select
            Case 1
                progressBar1.Maximum = 1000
                Exit Select
            Case 2
                progressBar1.Maximum = 10000
                Exit Select
        End Select


        Dim i As Integer
        For i = 0.0 To progressBar1.Maximum Step i + 1
            SetScene(i / (progressBar1.Maximum / 100))
            progressBar1.Increment(1)
            If (i = progressBar1.Maximum) Then

                progressBar1.Value = progressBar1.Maximum
                progressBar1.Value = progressBar1.Maximum - 1
                progressBar1.Value = progressBar1.Maximum
            End If
            Application.DoEvents()
        Next i
    End Sub
#End Region
End Class
