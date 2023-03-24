using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace StatisticsProject
{
    public partial class Form2 : Form
    {
        VectorDraw.Professional.vdObjects.vdDocument document = null;
        VectorDraw.Geometry.Matrix mat = new VectorDraw.Geometry.Matrix();
        //Form1.
        //This Form2 constructor get a vdDocument Type parameter. When called, the vdDocument of the BaseControl is passed through, so that the world2VewMatrix
        //can be modified without being public.
        public Form2(VectorDraw.Professional.vdObjects.vdDocument dcmnt)
        {
            InitializeComponent();
            document = dcmnt;
            //The World2ViewMatrix of the Document is stored in a Matrix object (mat), in order to be used as a point of reference every time we edit the view.
            mat.FromString(document.Model.World2ViewMatrix.ToString());
        }
        //This event handler is executed whenever we scroll up or down every one of the three scrollBars in the second Form.
        private void Scrolled(object sender, EventArgs e)
        {
            //The middle of the scrollBars (value 11) is considered the neutral position, not altering our View. 
            double yRotateBy = (trackBar1.Value - 11) / 2;
            double xRotateBy = (trackBar2.Value - 11) / 2;
            //The neutral position for the scrollBar3 is 25.
            double zoomBy = trackBar3.Value / 25.0;
            VectorDraw.Geometry.Matrix mat2 = new VectorDraw.Geometry.Matrix();
            //Whenever this event handler is called, the Matrix object (mat2) is defined as a copy of the global mat object. We don't use the = operator in order to
            //keep mat intact. If we used the = operator, every change on the mat2 object would be affecting mat as well, since they would be references to the same
            //object.
            mat2.FromString(mat.ToString());
            //After the mat2 ojbect is created, we modify it using the new values of the scrollBars.
            mat2.RotateYMatrix(yRotateBy * 0.0872);
            mat2.RotateXMatrix(xRotateBy * 0.0872);
            mat2.ScaleMatrix(zoomBy, zoomBy, zoomBy);
            //Finally we set mat2 as the World2ViewMatrix and the changes are visible in the BaseControl in Form1.
            document.Model.World2ViewMatrix = mat2;
            document.Redraw(false);
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            //When the Form2 is loaded, the three scrollBars are set to their respective midpoints.
            trackBar2.Value = 11;
            trackBar1.Value = 11;
            trackBar3.Value = 25;
        }
    }
}
