Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports VectorDraw.Geometry

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Set the support path for the dll that contains the custom objects so the commands of the command line can find the dll and load the specified static method action that implements the custom object.
        Dim path As String = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\"
        'VectorDrawCustomFigs_VB.dll
        VdFramedControl1.BaseControl.ActiveDocument.SupportPath = path



        VdFramedControl1.UnLoadCommands()
        VdFramedControl1.UnLoadMenu()
        VdFramedControl1.LoadCommands(path, "Commands.txt")
        VdFramedControl1.LoadMenu(path, "Menu.txt")
        VdFramedControl1.ShowMenu(True)

        Dim arrowline As VectorDrawCustomFigs_VB.VectorDrawArrowLine = New VectorDrawCustomFigs_VB.VectorDrawArrowLine()
        arrowline.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        arrowline.setDocumentDefaults()
        arrowline.StartPoint = New VectorDraw.Geometry.gPoint(10, 10)
        arrowline.EndPoint = New VectorDraw.Geometry.gPoint(20, 20)
        VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(arrowline)

        Dim blink As VectorDrawCustomFigs_VB.VectorDrawBlink = New VectorDrawCustomFigs_VB.VectorDrawBlink()
        blink.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        blink.setDocumentDefaults()
        blink.Origin = New VectorDraw.Geometry.gPoint(-20, -20)
        blink.Radius = 8
        VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(blink)

        Dim multiline As VectorDrawCustomFigs_VB.VectorDrawOffsetLine = New VectorDrawCustomFigs_VB.VectorDrawOffsetLine()
        multiline.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        multiline.setDocumentDefaults()
        multiline.VertexList.Add(New gPoint(0, 0))
        multiline.VertexList.Add(New gPoint(-10, 10))
        multiline.VertexList.Add(New gPoint(-20, 15))
        multiline.VertexList.Add(New gPoint(-10, 20))
        multiline.Flag = VectorDraw.Professional.Constants.VdConstPlineFlag.PlFlagCLOSE
        multiline.NumOfLines = 3
        multiline.LinesColor.ColorIndex = 1
        multiline.PenColor.ColorIndex = 0
        multiline.LinesDistance = 0.7
        VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(multiline)

        Dim polygon As VectorDrawCustomFigs_VB.VectorDrawPolygon = New VectorDrawCustomFigs_VB.VectorDrawPolygon()
        polygon.SetUnRegisterDocument(VdFramedControl1.BaseControl.ActiveDocument)
        polygon.setDocumentDefaults()
        polygon.Origin = New gPoint(30, -10)
        polygon.NumSides = 5
        polygon.Radius = 10
        polygon.PenColor.ColorIndex = 4
        polygon.TextString = "Hello World"
        VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(polygon)


        Dim c As VectorDraw.Professional.vdFigures.vdCircle = New VectorDraw.Professional.vdFigures.vdCircle(VdFramedControl1.BaseControl.ActiveDocument, New gPoint(85.0, 40.0), 3.0)
        VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(c)

        Dim verts As Vertexes = New Vertexes()
        verts.Add(New gPoint(134.0, -11.0))
        verts.Add(New gPoint(148.0, -6.0))
        verts.Add(New gPoint(161.0, -28.0))
        verts.Add(New gPoint(143.0, -30.0))
        Dim poly As VectorDraw.Professional.vdFigures.vdPolyline = New VectorDraw.Professional.vdFigures.vdPolyline(VdFramedControl1.BaseControl.ActiveDocument, verts)
        poly.VertexList.makeClosed()
        VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(poly)

        Dim lineconnection As VectorDrawCustomFigs_VB.vdLineConnection = New VectorDrawCustomFigs_VB.vdLineConnection(VdFramedControl1.BaseControl.ActiveDocument)
        lineconnection.Figure1 = c
        lineconnection.Figure2 = poly
        VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(lineconnection)

        VdFramedControl1.BaseControl.ActiveDocument.CommandAction.Zoom("E", 0, 0)
    End Sub
End Class
