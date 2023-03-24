Public Class Form1


    

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        VdFramedControl1.UnLoadMenu()
        VdFramedControl1.UnLoadCommands()
    End Sub

    Private Sub closeDropDownItems(ByVal sender As Object)
        CType(sender, ToolStripDropDownItem).DropDown.Hide()
        Dim var As ToolStripDropDownItem
        For Each var In menuStrip1.Items
            var.DropDown.Hide()
        Next
        vdFramedControl1.Focus()
    End Sub

    Private Sub MnFile_DropDownItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MnFile.DropDownItemClicked, zoomToolStripMenuItem.DropDownItemClicked, utilityToolStripMenuItem.DropDownItemClicked, uCSToolStripMenuItem.DropDownItemClicked, MnEdit.DropDownItemClicked, MnDraw.DropDownItemClicked, dSurfacesToolStripMenuItem.DropDownItemClicked, clipActionsToolStripMenuItem.DropDownItemClicked, circleToolStripMenuItem.DropDownItemClicked, arcToolStripMenuItem.DropDownItemClicked, viewsToolStripMenuItem.DropDownItemClicked, view3DToolStripMenuItem.DropDownItemClicked, MnModify.DropDownItemClicked, dimensionsToolStripMenuItem.DropDownItemClicked, blocksToolStripMenuItem.DropDownItemClicked, arrayEntitiesToolStripMenuItem.DropDownItemClicked, rectangularArrayToolStripMenuItem.DropDownItemClicked, polarArrayToolStripMenuItem.DropDownItemClicked, pointsArcToolStripMenuItem.DropDownItemClicked, arcToolStripMenuItem1.DropDownItemClicked
        Dim command As String = e.ClickedItem.Text
        If command <> "Zoom" And command <> "UCS" And command <> "Clip Actions" And command <> "Circles" And command <> "Arcs" And command <> "3D Surfaces" And command <> "Utility" And command <> "Dimensions" And command <> "Array Entities" And command <> "Views" Then
            closeDropDownItems(sender)
            ExecuteCommand(command)
        End If

    End Sub
    Private Sub ExecuteCommand(ByVal command As String)

        Select Case Command.ToLower()
            Case "new"
                'Just call the New function that clears the document to it's defaults.
                VdFramedControl1.BaseControl.ActiveDocument.[New]()

            Case "open"
                'First we call the dialog to select the file to open and then open the file.
                Dim ret As Object = VdFramedControl1.BaseControl.ActiveDocument.GetOpenFileNameDlg(0, "", 0)
                If (ret Is Nothing) Then Return
                Dim fname As String = CType(ret, String)
                Dim success As Boolean = VdFramedControl1.BaseControl.ActiveDocument.Open(fname)
                If (success) Then VdFramedControl1.BaseControl.ActiveDocument.Redraw(True)

            Case "save"
                'Save the document using it's own filename.
                If (Not (VdFramedControl1.BaseControl.ActiveDocument.FileName Is Nothing) And VdFramedControl1.BaseControl.ActiveDocument.FileName.Trim() <> "") Then
                    VdFramedControl1.BaseControl.ActiveDocument.SaveAs(VdFramedControl1.BaseControl.ActiveDocument.FileName)
                End If
            Case "saveas"
                'First we open a dialog to get the save filename and then save the document to the specified filename by ther user.
                Dim ver As String = ""
                Dim fname As String = VdFramedControl1.BaseControl.ActiveDocument.GetSaveFileNameDlg(VdFramedControl1.BaseControl.ActiveDocument.FileName, ver)
                If Not (fname Is Nothing) Then
                    VdFramedControl1.BaseControl.ActiveDocument.SaveAs(fname)
                End If

            Case "print"
                'Open the print dialog for printing using Extends and scaletoFit default options.
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdPrintDialog("E", "F")


            Case "undo"
                VdFramedControl1.BaseControl.ActiveDocument.UndoHistory.Undo()

            Case "redo"
                VdFramedControl1.BaseControl.ActiveDocument.UndoHistory.Redo()

            Case "redraw"
                VdFramedControl1.BaseControl.ActiveDocument.Redraw(False)

            Case "regen"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.RegenAll()
                'Or you can use the following sequence of commands to do the same thing.
                'vdFramedControl1.BaseControl.ActiveDocument.Update()
                'vdFramedControl1.BaseControl.ActiveDocument.Redraw(false)

            Case "extends"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.Zoom("e", Nothing, Nothing)
                'or
                'vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ZoomExtents()

            Case "window"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.Zoom("w", Nothing, Nothing)
                'Or
                'vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ZoomWindow(new VectorDraw.Geometry.gPoint(), new VectorDraw.Geometry.gPoint(100.0, 100.0))

            Case "all"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.Zoom("A", Nothing, Nothing)
                'Or
                'vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ZoomAll()

            Case "previous"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.Zoom("p", Nothing, Nothing)
                'Or
                'vdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ZoomPrevious()
            Case "in 20%"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.Zoom("s", CDbl(1.0 / 0.8), Nothing)
            Case "out 20%"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.Zoom("s", CDbl(0.8), Nothing)
            Case "view"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.UCS("VIEW", Nothing, Nothing)

            Case "world"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.UCS("WORLD", Nothing, Nothing)

            Case "clip copy"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdClipCopy(Nothing)

            Case "clip paste"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdClipPaste(Nothing)

            Case "clip cut"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdClipCut(Nothing)
                'parameter Nothing means that the user will pick the required point- distance or everything that is required for the command.
            Case "line"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdLine(Nothing)
            Case "xline"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdXLine(Nothing)
            Case "ray"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdRay(Nothing)
            Case "point"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdPoint(Nothing)

            Case "arc"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdArc(Nothing, Nothing, Nothing, Nothing)

            Case "3 points arc"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdArc("3p", Nothing, Nothing, Nothing)

            Case "center-radius circle"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdCircle(Nothing, Nothing)

            Case "2 points circle"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdCircle("2p", Nothing)

            Case "3 points circle"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdCircle("3p", Nothing)

            Case "ellipse"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdEllipse(Nothing, Nothing, Nothing)

            Case "polyline"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdPolyLine(Nothing)

            Case "text"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdText(Nothing, Nothing, Nothing)

            Case "rectangle"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdRect(Nothing, Nothing)

            Case "image"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdImage("", Nothing)

            Case "add attribute"
                Dim def As VectorDraw.Professional.vdFigures.vdAttribDef = VectorDraw.Professional.Dialogs.frmAddAttribute.Show(VdFramedControl1.BaseControl.ActiveDocument)
                VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.Entities.AddItem(def)
                VdFramedControl1.BaseControl.ActiveDocument.ActionDrawFigure(def)

            Case "vertical"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdDim(VectorDraw.Professional.Constants.VdConstDimType.dim_Rotated, Nothing, Nothing, VectorDraw.Geometry.Globals.HALF_PI)

            Case "horizontal"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdDim(VectorDraw.Professional.Constants.VdConstDimType.dim_Rotated, Nothing, Nothing, 0.0)

            Case "aligned"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdDim(VectorDraw.Professional.Constants.VdConstDimType.dim_Aligned, Nothing, Nothing, 0.0)

            Case "angular"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdDim(VectorDraw.Professional.Constants.VdConstDimType.dim_Angular, Nothing, Nothing, 0.0)

            Case "diameter"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdDim(VectorDraw.Professional.Constants.VdConstDimType.dim_Diameter, Nothing, Nothing, 0.0)

            Case "radial"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdDim(VectorDraw.Professional.Constants.VdConstDimType.dim_Radial, Nothing, Nothing, 0.0)
            Case "box"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdBox3d(Nothing, Nothing, Nothing, Nothing, Nothing)

            Case "sphere"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdSphere(Nothing, Nothing, Nothing, Nothing)

            Case "cone"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdCone(Nothing, Nothing, Nothing, Nothing, Nothing)

            Case "3dmesh"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.Cmd3DMesh(Nothing, Nothing, Nothing)

            Case "3dface"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.Cmd3dFace(Nothing)

            Case "bhatch"
                VectorDraw.Professional.Dialogs.frmGetHatchDialog.Show(Nothing, VdFramedControl1.BaseControl.ActiveDocument, VdFramedControl1.BaseControl.ActiveDocument.ActionControl)

            Case "plinetomesh"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdPlineToMesh(Nothing, Nothing, Nothing)
            Case "leader"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdLeader(Nothing, Nothing)
            Case "multiline"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdMultiLine(Nothing)

            Case "edit attribute"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.EditAttrib(Nothing)

            Case "make block"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdMakeBlock(Nothing, Nothing, Nothing)

            Case "insert block"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdInsertBlockDialog()


            Case "rotate"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdRotate(Nothing, Nothing, Nothing)

            Case "copy"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdCopy(Nothing, Nothing, Nothing)

            Case "erase"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdErase(Nothing)

            Case "move"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdMove(Nothing, Nothing, Nothing)

            Case "explode"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdExplode(Nothing)

            Case "mirror"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdMirror(Nothing, Nothing, Nothing, Nothing)

            Case "break"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdBreak(Nothing, Nothing, Nothing)

            Case "offset"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdOffset(Nothing, Nothing, Nothing)

            Case "extend"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdExtend(Nothing, Nothing)

            Case "trim"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdTrim(Nothing, Nothing)

            Case "fillet"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdFillet(Nothing, Nothing)

            Case "stretch"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdStretch(Nothing, Nothing, Nothing, Nothing, Nothing)

            Case "polar array"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdArrayPolar(Nothing, Nothing, Nothing, Nothing, Nothing)

            Case "rectangular array"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdArrayRectangular(Nothing, Nothing, Nothing, Nothing, Nothing)

            Case "rotate 3d"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VROT")

            Case "render"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("RENDER")

            Case "shade"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("SHADE")

            Case "shadeon"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("SHADEON")

            Case "hide"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("HIDE")

            Case "wire"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("WIRE")

            Case "wire 2d"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("WIRE2D")

            Case "top"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VTOP")

            Case "bottom"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VBOTTOM")

            Case "left"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VLEFT")

            Case "right"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VRIGHT")

            Case "front"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VFRONT")

            Case "back"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VBACK")

            Case "ne"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VINE")

            Case "nw"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VINW")

            Case "se"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VISE")

            Case "sw"
                VdFramedControl1.BaseControl.ActiveDocument.CommandAction.View3D("VISW")

        End Select
    End Sub

    

End Class
