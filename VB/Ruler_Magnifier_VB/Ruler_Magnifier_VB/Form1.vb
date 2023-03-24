Public Class Form1

    WithEvents control As VectorDraw.Professional.Control.VectorDrawBaseControl
    

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim filename As String
        filename = VectorDraw.Professional.Utilities.vdGlobals.GetDirectoryName(Application.ExecutablePath) + "\\sample.vdml"
        VdFramedControl1.BaseControl.ActiveDocument.Open(filename)
        control = VdFramedControl1.BaseControl
        rulerProps.SelectedObject = VdFramedControl1.ScrollableControl.RulerObject
    End Sub

    
    Private Sub ButMagnifier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButMagnifier.Click
        Dim retptWorld As VectorDraw.Geometry.gPoint
        retptWorld = VectorDraw.Professional.ActionUtility.ActionMagnifier.getUserMagnifierPoint(VdFramedControl1.BaseControl.ActiveDocument, 3, 210, Keys.ShiftKey)
    End Sub

   
    Private Sub control_vdKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs, ByRef cancel As Boolean) Handles control.vdKeyDown
        If (TypeOf VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.ActiveAction Is VectorDraw.Actions.ActionGetRectFromPointSelectDCS) Then Exit Sub

        Dim Action As VectorDraw.Actions.BaseAction
        Action = VdFramedControl1.BaseControl.ActiveDocument.ActiveLayOut.OverAllActiveAction
        If (Not (TypeOf Action Is VectorDraw.Professional.ActionUtility.ActionMagnifier) And VectorDraw.Actions.BaseAction.PressedKeyCode = Keys.Shift And System.Windows.Forms.Control.MouseButtons = MouseButtons.None) Then
            Dim retptWorld As VectorDraw.Geometry.gPoint
            retptWorld = VectorDraw.Professional.ActionUtility.ActionMagnifier.getUserMagnifierPoint(VdFramedControl1.BaseControl.ActiveDocument, 3, 210, Keys.ShiftKey)
        End If
    End Sub

    Private Sub btRuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btRuler.Click
        VdFramedControl1.ScrollableControl.RulerObject.Visible = Not VdFramedControl1.ScrollableControl.RulerObject.Visible
    End Sub
End Class
