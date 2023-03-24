Imports VectorDraw.Professional.vdFigures
Imports VectorDraw.Professional.vdPrimaries
Imports VectorDraw.Professional.vdCollections
Imports VectorDraw.Geometry

Public Class Form1
    WithEvents source As VectorDraw.Professional.Control.VectorDrawBaseControl
    WithEvents dest As VectorDraw.Professional.Control.VectorDrawBaseControl

    Private Sub CreateSourceEntities()
        'create entities to drop over to the Source BaseControl

        Dim circle As New vdCircle
        circle.SetUnRegisterDocument(vdSource.ActiveDocument)
        circle.setDocumentDefaults()
        circle.Center = New VectorDraw.Geometry.gPoint()
        circle.Radius = vdSource.ActiveDocument.ViewSize / 4D
        vdSource.ActiveDocument.ActiveLayOut.Entities.AddItem(circle)
        vdSource.Redraw()
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MessageBox.Show("This Sample will NOT work on evaluation mode!!!")
        label.Text = "Click Mouse down over the top-left VectorDraw control and drag" + Chr(13) + Chr(10) + "Drop on the top-right VectorDraw Control to insert the data as block " + Chr(13) + "or on the bottom-left button to insert the data as bitmap." + Chr(13) + " You can also drag from the top left and drop to an explorer(or desktop) to create a vdml file with the destination's entities." + Chr(13) + Chr(10) + Chr(13) + Chr(10) + "You can also drag a file from a file explorer and drop it to the top left Base control and it will be opened there."
        CreateSourceEntities()
        source = vdSource
        dest = vdDest
    End Sub
#Region "Image Button"
    Private Sub ImageButton_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ImageButton.DragDrop
        'drop the bitmap image to the Button control
        Dim bmp As System.Drawing.Bitmap
        bmp = e.Data.GetData(GetType(System.Drawing.Bitmap))
        If (bmp Is Nothing) Then Exit Sub
        ImageButton.Image = bmp
    End Sub

    Private Sub ImageButton_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ImageButton.DragEnter
        'allow drop for the Image to the Button control
        e.Effect = DragDropEffects.Copy
    End Sub
#End Region

#Region "SOURCE"
    Private Sub source_vdDragDrop(ByVal drgevent As System.Windows.Forms.DragEventArgs, ByRef cancel As Boolean) Handles source.vdDragDrop
        'by default VectorDraw attaches the dropped file as xref to the current file. We will change
        'this behaviour in order to open the dropped file.
        cancel = True
        Dim dataobject As System.Windows.Forms.DataObject
        dataobject = New DataObject(drgevent.Data)
        Dim strings As System.Collections.Specialized.StringCollection
        strings = dataobject.GetFileDropList()
        Dim success As Boolean
        success = vdSource.ActiveDocument.Open(strings(0))
        If (Not success) Then MessageBox.Show("The file could not be opened")
    End Sub


    Private Sub source_vdDragEnter(ByVal drgevent As System.Windows.Forms.DragEventArgs, ByRef cancel As Boolean) Handles source.vdDragEnter
        'Show the copy drag icon to the source control. This means that also accepts drag objects.
        drgevent.Effect = DragDropEffects.Copy
    End Sub


    Private Sub source_vdMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs, ByRef cancel As Boolean) Handles source.vdMouseDown
        'begin a drag drop to the Source BaseCotnrol
        If (e.Button = MouseButtons.Left) Then
            cancel = True
            Dim selset As vdSelection
            selset = vdSource.ActiveDocument.Selections.Add("dragdrop")
            selset.RemoveAll()
            selset.Select(VectorDraw.Render.RenderSelect.SelectingMode.All, Nothing)
            Dim setBound As Box
            setBound = selset.GetBoundingBox()
            Dim dragOrigin As gPoint
            dragOrigin = setBound.MidPoint
            'The DoDragDrop (with flag = 3) command will create a stream vdml file from the selection , an image and a vdml file to drop.
            'The stream will be used to the destination BaseControl in order to add the entities to a block .
            'The image is going to be used in the Button Control in order to show the image.
            'The file can be dropped in a file explorer (desktop) in order to create a vdml file. 
            vdSource.ActiveDocument.CommandAction.DoDragDrop(selset, vdSelection.DragDropEffects.Copy, dragOrigin, ImageButton.Width, ImageButton.Height, 3)
        End If
    End Sub
#End Region

    Private Sub dest_vdDragDrop(ByVal drgevent As System.Windows.Forms.DragEventArgs, ByRef cancel As Boolean) Handles dest.vdDragDrop
        'drop the stream as block to the Destination BaseControl
        cancel = True

        Dim stream As System.IO.MemoryStream
        stream = DirectCast(drgevent.Data.GetData("VectorDraw.6"), System.IO.MemoryStream)
        If (stream Is Nothing) Then Exit Sub
        Dim block As vdBlock
        block = vdDest.ActiveDocument.Blocks.AddFromStream("dragdrop", stream)
        If (block Is Nothing) Then Exit Sub
        Dim success As Boolean
        success = vdDest.ActiveDocument.CommandAction.CmdInsert(block.Name, vdDest.ActiveDocument.CCS_CursorPos(), 1.0, 1.0, 0.0)

    End Sub


    Private Sub dest_vdDragEnter(ByVal drgevent As System.Windows.Forms.DragEventArgs, ByRef cancel As Boolean) Handles dest.vdDragEnter
        'allow drop to the Destination BaseControl
        drgevent.Effect = DragDropEffects.Copy
    End Sub
End Class
