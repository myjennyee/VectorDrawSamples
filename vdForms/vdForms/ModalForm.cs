using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace vdForms
{
    public partial class ModalForm : Form
    {
#region Variables
        //private variables required.
        private VectorDraw.Professional.vdObjects.vdDocument mDoc = null;
        private VectorDraw.Geometry.gPoint UserPt = null;
#endregion

#region Initialize/Load Form
        public ModalForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// A initialization method used to pass the document to the form, or any other variable needed.
        /// </summary>
        /// <param name="Document"></param>
        public void InitializeVariables(VectorDraw.Professional.vdObjects.vdDocument Document)
        {
            mDoc = Document;
        }
        /// <summary>
        /// OnLoad event of the form. Be very carefull because when the form is closed(so the user presses the button)
        /// and reopened the code will pass every time from this event so you should have some options like UserPt == null
        /// in order to know in which state your dialog is.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModalForm_Load(object sender, EventArgs e)
        {
            if (UserPt == null) return;
            labPointX.Text = mDoc.lunits.FormatLength(UserPt.x);
            labPointY.Text = mDoc.lunits.FormatLength(UserPt.y);
        }
#endregion

#region Buttons
        private void butExit_Click(object sender, EventArgs e)
        {
            //Button exit,DialogResult = OK so the while in the ShowMyForm exits.
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void butPick_Click(object sender, EventArgs e)
        {
            //Button Pick Point,DialogResult = Ignore so the while in the ShowMyForm runs the select point code.
            this.DialogResult = DialogResult.Ignore;
            this.Close();
        }
#endregion
        /// <summary>
        /// This is the main Show modal dialog method.
        /// </summary>
        /// <param name="Document"></param>
        /// <returns></returns>
        public static DialogResult ShowMyForm(VectorDraw.Professional.vdObjects.vdDocument Document)
        {
            ModalForm frm = new ModalForm();
            frm.InitializeVariables(Document);
            DialogResult res = DialogResult.No;
            //This while command will ensure that the dialog will keep showing until the user exits with DialogResult =  OK
            do
            {
                res = frm.ShowDialog(Document.ActionControl);
                Application.DoEvents();
                switch (res)
                {
                    case DialogResult.Ignore:
                        //Code to Select the point,Entity or any other needed information from the main document.
                        VectorDraw.Geometry.gPoint retPT = null;
                        VectorDraw.Actions.StatusCode ret = Document.ActionUtility.getUserPoint (out retPT);
                        if (ret == VectorDraw.Actions.StatusCode.Cancel || retPT == null) frm.UserPt = null;
                        else if (ret == VectorDraw.Actions.StatusCode.Success)
                        {
                            frm.UserPt = new VectorDraw.Geometry.gPoint(retPT);
                        }
                        break;
                }

            }
            while (res!= DialogResult.OK);
            return res;
        }
    }
}