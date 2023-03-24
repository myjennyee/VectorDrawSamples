using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vdForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void butShowForm_Click(object sender, EventArgs e)
        {
            //In order to Show the Form we call a static Show method that we have implemented passing 
            //any variables that we may need , in our case the ActiveDocument.
            ModalForm.ShowMyForm(vdFramedControl1.BaseControl.ActiveDocument);
        }
    }
}