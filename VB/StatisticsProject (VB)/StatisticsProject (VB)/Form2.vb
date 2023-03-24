
Public Class Form2
    Dim document As VectorDraw.Professional.vdObjects.vdDocument
    Dim mat As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix()
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'When the Form2 is loaded, the three scrollBars are set to their respective midpoints.
        trackBar2.Value = 11
        trackBar1.Value = 11
        trackBar3.Value = 25
    End Sub
    'Form2.
    'This Form2 constructor get a vdDocument Type parameter. When called, the vdDocument of the BaseControl is passed through, so that the world2VewMatrix
    'can be modified without being public.
    Public Sub New(ByVal dcmnt As VectorDraw.Professional.vdObjects.vdDocument)
        InitializeComponent()
        document = dcmnt
        'The World2ViewMatrix of the Document is stored in a Matrix object (mat), in order to be used as a point of reference every time we edit the view.
        mat.FromString(document.Model.World2ViewMatrix.ToString())
    End Sub
    'This event handler is executed whenever we scroll up or down every one of the three scrollBars in the second Form.
    Private Sub Scrolled(ByVal sender As Object, ByVal e As System.EventArgs) Handles trackBar1.Scroll, trackBar2.Scroll, trackBar3.Scroll

        'The middle of the scrollBars (value 11) is considered the neutral position, not altering our View. 
        Dim yRotateBy As Double = (trackBar1.Value - 11) / 2
        Dim xRotateBy As Double = (trackBar2.Value - 11) / 2
        'The neutral position for the scrollBar3 is 25.
        Dim zoomBy As Double = trackBar3.Value / 25.0
        Dim mat2 As VectorDraw.Geometry.Matrix = New VectorDraw.Geometry.Matrix()
        'Whenever this event handler is called, the Matrix object (mat2) is defined as a copy of the global mat object. We don't use the = operator in order to
        'keep mat intact. If we used the = operator, every change on the mat2 object would be affecting mat as well, since they would be references to the same
        'object.
        mat2.FromString(mat.ToString())
        'After the mat2 ojbect is created, we modify it using the new values of the scrollBars.
        mat2.RotateYMatrix(yRotateBy * 0.0872)
        mat2.RotateXMatrix(xRotateBy * 0.0872)
        mat2.ScaleMatrix(zoomBy, zoomBy, zoomBy)
        'Finally we set mat2 as the World2ViewMatrix and the changes are visible in the BaseControl in Form1.
        document.Model.World2ViewMatrix = mat2
        document.Redraw(False)

    End Sub
End Class