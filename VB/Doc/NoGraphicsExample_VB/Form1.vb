Public Class Form1
    Private Sub ButExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButExit.Click
        Application.Exit()
    End Sub

    Private Sub ButExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButExport.Click
        VdDocumentComponent1.Document.SaveAs(Application.ExecutablePath.Substring(0, Application.ExecutablePath.Length - 4) + ".svg")
        VdDocumentComponent1.Document.SaveAs(Application.ExecutablePath.Substring(0, Application.ExecutablePath.Length - 4) + ".bmp")
        VdDocumentComponent1.Document.SaveAs(Application.ExecutablePath.Substring(0, Application.ExecutablePath.Length - 4) + ".jpg")
        VdDocumentComponent1.Document.SaveAs(Application.ExecutablePath.Substring(0, Application.ExecutablePath.Length - 4) + ".png")

        VdDocumentComponent1.Document.Model.Printer.PrinterName = Application.ExecutablePath.Substring(0, Application.ExecutablePath.Length - 4) + ".pdf"
        VdDocumentComponent1.Document.Model.Printer.PrintExtents()
        VdDocumentComponent1.Document.Model.Printer.PrintWindow.AddWidth(5.0)
        VdDocumentComponent1.Document.Model.Printer.PrintScaleToFit()
        VdDocumentComponent1.Document.Model.Printer.PrintOut()

        VdDocumentComponent1.Document.Model.Printer.PrinterName = Application.ExecutablePath.Substring(0, Application.ExecutablePath.Length - 4) + ".emf"
        VdDocumentComponent1.Document.Model.Printer.PrintExtents()
        VdDocumentComponent1.Document.Model.Printer.PrintScaleToFit()
        VdDocumentComponent1.Document.Model.Printer.PrintOut()

        MessageBox.Show("6 Files have been created : PDF,EMF,SVG,BMP,JPG,PNG to tha application's path.")
    End Sub

    Private Sub CreateForm()
        Dim rect As VectorDraw.Professional.vdFigures.vdRect
        rect = New VectorDraw.Professional.vdFigures.vdRect()
        rect.SetUnRegisterDocument(VdDocumentComponent1.Document)
        rect.setDocumentDefaults()
        rect.InsertionPoint = New VectorDraw.Geometry.gPoint()
        rect.Width = 120
        rect.Height = 240
        VdDocumentComponent1.Document.Model.Entities.AddItem(rect)

        rect = New VectorDraw.Professional.vdFigures.vdRect()
        rect.SetUnRegisterDocument(VdDocumentComponent1.Document)
        rect.setDocumentDefaults()
        rect.InsertionPoint = New VectorDraw.Geometry.gPoint(-5.0, -5.0)
        rect.Width = 130.0
        rect.Height = 250.0
        VdDocumentComponent1.Document.Model.Entities.AddItem(rect)

        rect = New VectorDraw.Professional.vdFigures.vdRect()
        rect.SetUnRegisterDocument(VdDocumentComponent1.Document)
        rect.setDocumentDefaults()
        rect.InsertionPoint = New VectorDraw.Geometry.gPoint(65.0, 0.0)
        rect.Width = 55.0
        rect.Height = 30.0
        VdDocumentComponent1.Document.Model.Entities.AddItem(rect)

        Dim Signature As VectorDraw.Professional.vdFigures.vdMText
        Signature = New VectorDraw.Professional.vdFigures.vdMText()
        Signature.SetUnRegisterDocument(VdDocumentComponent1.Document)
        Signature.setDocumentDefaults()
        Signature.InsertionPoint = New VectorDraw.Geometry.gPoint(93.0, 25.0)
        Signature.TextString = "\C1;VectorDraw\NPlatonos 1 - Dafni - 17234\NPhone : 210-9739781\NFAX:210-9739159"
        Signature.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter
        VdDocumentComponent1.Document.Model.Entities.AddItem(Signature)

        UpdatePicture()
    End Sub
    Private Sub UpdatePicture()

        If (picPrev1.Width = 0 Or picPrev1.Height = 0) Then Exit Sub

        VdDocumentComponent1.Document.CommandAction.CmdSelect("ALL")
        Dim selset As VectorDraw.Professional.vdCollections.vdSelection
        selset = VdDocumentComponent1.Document.Selections.FindName("VDRAW_PREVIOUS_SELSET")
        Dim Bbox As VectorDraw.Geometry.Box
        Bbox = selset.GetBoundingBox()
        Bbox.AddWidth(5.0)

        Dim img1 As Image
        img1 = New Bitmap(picPrev1.Width, picPrev1.Height)
        Dim graph As System.Drawing.Graphics
        graph = Graphics.FromImage(img1)
        Bbox.TransformBy(VdDocumentComponent1.Document.ActiveLayOut.World2ViewMatrix)
        VdDocumentComponent1.Document.ActiveLayOut.RenderToGraphics(graph, Bbox, img1.Width, img1.Height)
        picPrev1.Image = img1
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreateForm()
        MessageBox.Show("This sample does not contain any .NET graphical component. It contains only a vdDocument component which does all the work.")
    End Sub

    Private Sub Form1_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        UpdatePicture()
    End Sub
End Class
