using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

///Description:

///In the following example is demonstrated how someone can create an Invoice Form Application. This is achieved by using an existing
///Vector Draw .vdml document template and modifying its Attributes, using a Vector Draw BaseControl and other simple controls,
///such as Textboxes and Buttons. In further detail someone can review the use, creation and removal of Insert objects. How to search
///for an Insert object using its BlockName or its Label. The way to locate and control an Insert's Attributes in order to present text
///dynamically, and finally how to rearrange- move shapes or inserts pressing a button. 

///Use:

///Once the Application is started, the template .vdml document is loaded. By using the Application's Components (TextBoxes, DataGrid etc),
///the values of the various Attributes can be altered. Whenever an Attribute needs to be modified, all we have to do is insert the value in
///the right TextBox and press "Enter" (or press the "Update" button at the bottom). Finally the Items DataGrid. We can add, remove and modify
///up to 4 items (Due to the functionality of the component, pressing "Enter" won't work in the DataGrid).

namespace Invoice_Form
{
    public partial class Form1 : Form
    {
        private int width;
        //This Boolean Array is set to true if a specific row has been initialized.
        private bool[] initializedRow ={ false, false, false, false };

        public Form1()
        {
            InitializeComponent();
        }

        #region EVENT HANDLERS
        private void Form1_Load(object sender, EventArgs e)
        {
            //We add the "RequiredFiles" folder to the support path. This addition is made in order for our samples to get the required files from this extra folder used in distribution of our sample files.
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\RequiredFiles\\";
            vectorDrawBaseControl1.ActiveDocument.SupportPath = path;

            //The invoice.vdml file that is located in the application's home folder, is used as template. If we need to use another file,
            //we should use the full pathname as parameter.
            vectorDrawBaseControl1.ActiveDocument.Open("invoice.vdml");
            loadForm();
            //We store the initial width of the Panel2 in order to keep the size of the panel that contains the textboxes steady.
            width = splitContainer1.Panel2.Width;

            vectorDrawBaseControl1.Redraw();
        }
        //This Event Handler ensures that whenever we enter the DataGrid control the whole row of the current Cell will be filled with ""
        //so that we won't get an Exception when inserting the Item details into the Invoice Form.
        //This Event Handler ensures that whenever we click on a DataGrid Cell the whole row of the current Cell will be filled with ""
        //so that we won't get an Exception when inserting the Item details into the Invoice Form.
        void ItemsTable_MouseUp(object sender, MouseEventArgs e)
        {
            InitRows();
        }
        //This Event Handler ensures that whenever we swap from a DataGrid Cell to another, anyway we do it (with the mouse or the keyboard)
        //the whole row of the current Cell will be filled with "" so that we won't get an Exception when inserting the Item details into the Invoice Form.
        void ItemsTable_CurrentCellChanged(object sender, EventArgs e)
        {
            InitRows();
        }
        private void updateClick(object sender, EventArgs e)
        {
            updateInvoiceForm();
        }
        private void DateValueChanged(object sender, EventArgs e)
        {
            updateInvoiceForm();
        }
        void KeyPressed(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                updateInvoiceForm();
        }
        #region FILE MENU
        //
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vectorDrawBaseControl1.ActiveDocument.Open("invoice.vdml");
            loadForm();
        }
        private void exportToPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Printer.PrinterName = Application.ExecutablePath.Substring(0, Application.ExecutablePath.Length - 4) + ".pdf";
            vectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Printer.PrintExtents();
            vectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Printer.PrintWindow.AddWidth(5.0);
            vectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Printer.PrintScaleToFit();
            vectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Printer.PrintOut();
            MessageBox.Show("A PDF file was created in the home folder of the application.");
        }
        //
        #endregion
        //
        #endregion

        #region APPLICATION FORM HANDLING
        //
        //This method makes the value of all the cells in the current Row equal to "".
        private void InitRows()
        {
            int row = ItemsTable.CurrentRowIndex;
            if (row < 4)
                if (!initializedRow[row])
                {
                    for (int i = 0; i < 5; i++)
                    {
                        ItemsTable[row, i] = "";
                    }
                    initializedRow[row] = true;
                }
        }
        //Initialization of the Application Form's TextBoxes.
        private void loadForm()
        {
            //The user cannot alter the way he views the Invoice Form, on the left part of the Window, or alter any objects in it.
            vectorDrawBaseControl1.ActiveDocument.ShowUCSAxis = false;

            setAttrValue("invoiceInfo", "date", tbDate.Text);
            tbInvoiceNum.Text = getAttrValue("invoiceInfo", "invoiceNum");

            stbName.Text = getAttrValue("fromCredentials", "fromName");
            stbAddress.Text = getAttrValue("fromCredentials", "fromAddress");
            stbPhone.Text = getAttrValue("fromCredentials", "fromPhones").Replace("Phone: ", "");
            stbFax.Text = getAttrValue("fromCredentials", "fromFax").Replace("Fax: ", "");
            stbTax.Text = getAttrValue("fromCredentials", "fromTaxNum").Replace("TAX Number: ", "");

            rtbName.Text = getAttrValue("toCredentials", "toCompany");
            rtbAddress.Text = getAttrValue("toCredentials", "toAddress");
            rtbArea.Text = getAttrValue("toCredentials", "toArea");
            rtbCountry.Text = getAttrValue("toCredentials", "toCountry");
            rtbPhone.Text = getAttrValue("toCredentials", "toPhone");
            rtbZip.Text = getAttrValue("toCredentials", "toZipCode");
            rtbFax.Text = getAttrValue("toCredentials", "toFAX");
            rtbVat.Text = getAttrValue("toCredentials", "toVAT");
            rtbContact.Text = getAttrValue("toContactInfo", "toContact");
            rtbEmail.Text = getAttrValue("toContactInfo", "toEmail");

            setAttrValue("dueDate", "dueDate", dueDate.Text);
        }
        //
        #endregion

        #region INVOICE FORM MODIFYING
        //
        //This method Updates the Invoice Form, according to the contents of the TextBoxes of the Application Form.
        private void updateInvoiceForm()
        {
            setAttrValue("fromCredentials", "fromName", stbName.Text);

            setAttrValue("fromCredentials", "fromAddress", stbAddress.Text);
            setAttrValue("fromCredentials", "fromPhones", "Phone: " + stbPhone.Text);
            setAttrValue("fromCredentials", "fromFax", "Fax: " + stbFax.Text);
            setAttrValue("fromCredentials", "fromTaxNum", "TAX Number: " + stbTax.Text);

            setAttrValue("invoiceInfo", "date", tbDate.Text);
            setAttrValue("invoiceInfo", "invoiceNum", tbInvoiceNum.Text);

            setAttrValue("toCredentials", "toCompany", rtbName.Text);
            setAttrValue("toCredentials", "toAddress", rtbAddress.Text);
            setAttrValue("toCredentials", "toArea", rtbArea.Text);
            setAttrValue("toCredentials", "toCountry", rtbCountry.Text);
            setAttrValue("toCredentials", "toPhone", rtbPhone.Text);
            setAttrValue("toCredentials", "toZipCode", rtbZip.Text);
            setAttrValue("toCredentials", "toFAX", rtbFax.Text);
            setAttrValue("toCredentials", "toVAT", rtbVat.Text);
            setAttrValue("toContactInfo", "toContact", rtbContact.Text);
            setAttrValue("toContactInfo", "toEmail", rtbEmail.Text);

            setAttrValue("dueDate", "duedate", dueDate.Text);

            updateItems();
            //After the completion of the alterations in the Invoice Form's data, we use the Redraw method to make them visible to the user.
            vectorDrawBaseControl1.ActiveDocument.Update();
            vectorDrawBaseControl1.ActiveDocument.Invalidate();
        }
        //The following method is used whenever we want to insert/modify/delete data the user has inserted in the ItemsTable, into the Invoice Form.
        private void updateItems()
        {
            float total = 0;
            clearItemBlocks(ItemsTable.BindingContext[ItemsTable.DataSource].Count);
            //This for loop is executed as many times, as many rows we have in our DataGrid (ItemsTable) control.
            int repeat;
            for (repeat = 0; repeat < ItemsTable.BindingContext[ItemsTable.DataSource].Count; repeat++)
            {
                //Incase more than 1 items are inserted, we have to create additional Item Blocks in the Invoice Form.
                if (repeat > 0)
                {
                    if (repeat > 3) { MessageBox.Show("You can insert up to 4 items."); break; }
                    bool itemBlockExists = false;
                    VectorDraw.Professional.vdFigures.vdInsert lastItemBlock = null, insertTotal = null;
                    //We check every object in our Document.
                    foreach (VectorDraw.Professional.vdPrimaries.vdFigure item in vectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Entities)
                    {
                        VectorDraw.Professional.vdFigures.vdInsert ins = null;
                        ins = item as VectorDraw.Professional.vdFigures.vdInsert;
                        //If the object is not an Insert we check the next.
                        if (ins == null) continue;
                        //When this foreach loop is completed lastItemBlock will be referencing the last Item Block that is inserted;
                        if (ins.Block.Name.Equals("itemBlock")) lastItemBlock = ins;
                        //When this foreach loop is completed isertTotal will be referencing the Item Total Block;
                        if (ins.Block.Name.Equals("itemTotal")) insertTotal = ins;
                        //If an insert labeled with the current repeat exists, it was created earlier, so we just need to update the content.
                        //If it does not exist, we need to insert one more Item Block.
                        if (ins.Label.CompareTo(repeat.ToString()) == 0)
                        {
                            //If the current Insert was created and deleted before, we just change the Deleted property of the Insert to false.
                            if (ins.Deleted) ins.Deleted = false;
                            itemBlockExists = true;
                            break;
                        }
                    }
                    //If an insert labeled with the current repeat does not exist, we will clone the latest Item Block that was inserted and label it
                    //with the current repeat.
                    if (!itemBlockExists)
                    {
                        VectorDraw.Professional.vdFigures.vdInsert ins = new VectorDraw.Professional.vdFigures.vdInsert();
                        ins = lastItemBlock.Clone(vectorDrawBaseControl1.ActiveDocument) as VectorDraw.Professional.vdFigures.vdInsert;
                        //The new Item Block will be inserted right under the last Item Block inserted.
                        ins.InsertionPoint = new VectorDraw.Geometry.gPoint(lastItemBlock.BoundingBox.Left, (lastItemBlock.BoundingBox.Top - lastItemBlock.BoundingBox.Height));
                        ins.Label = repeat.ToString();
                        vectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Entities.AddItem(ins);
                    }
                    //The Item Total Block will be moved under the last inserted Item Block.
                    insertTotal.InsertionPoint = new VectorDraw.Geometry.gPoint(insertTotal.BoundingBox.Left, (110 - (repeat + 1) * lastItemBlock.BoundingBox.Height));
                    insertTotal.Update();
                }
                setItemAttrValue("itemBlock", "item", ItemsTable[repeat, 0].ToString(), repeat.ToString());
                //In this "Set Description Value" region, we make sure that if the text in the description column of the DataGrid is more than
                //30 characters will be wraped, so that it won't exceed the borders of its box.
                # region Set Description Value
                string descriptionValue = ItemsTable[repeat, 1].ToString();
                if (descriptionValue.Length > 30)
                {
                    int j = ItemsTable[repeat, 1].ToString().Length;
                    string description = null;
                    string[] str = new string[j / 30 + 1];
                    for (int k = 0; k < j / 30 + 1; k++)
                    {
                        if (k != j / 30)
                        {
                            str[k] = descriptionValue.Substring(k * 30, 30);
                            if (!descriptionValue.Substring((k + 1) * 30, 1).Equals(" ") && !descriptionValue.Substring(((k + 1) * 30) + 1, 1).Equals(" "))
                                str[k] += "-";
                        }
                        else
                        {
                            str[k] = descriptionValue.Substring(k * 30, j % 30);
                        }
                        description += str[k] + "\n";
                    }
                    setItemAttrValue("itemBlock", "description", description, repeat.ToString());
                }
                else setItemAttrValue("itemBlock", "description", descriptionValue, repeat.ToString());

                #endregion
                setItemAttrValue("itemBlock", "quantity", ItemsTable[repeat, 2].ToString(), repeat.ToString());
                setItemAttrValue("itemBlock", "rate", ItemsTable[repeat, 3].ToString() + " EUR", repeat.ToString());

                //The following lines (try - catch), calculate the total amount of an item. If the value inserted is not numeric, the amount
                //is set to 0 automatically.
                try
                {
                    float subtotal;
                    float quantity = float.Parse(ItemsTable[repeat, 2].ToString());
                    float rate = float.Parse(ItemsTable[repeat, 3].ToString());
                    subtotal = quantity * rate;
                    total += subtotal;
                    setItemAttrValue("itemBlock", "amount", subtotal.ToString() + " EUR", repeat.ToString());
                    ItemsTable[repeat, 4] = subtotal.ToString();
                }
                catch
                {
                    setItemAttrValue("itemBlock", "amount", "0 EUR", repeat.ToString());
                    ItemsTable[repeat, 4] = "0";
                }
            }
            tbTotal.Text = total.ToString() + " EUR";
            setAttrValue("itemTotal", "total", tbTotal.Text);
        }
        //The following method makes sure that there are as many Item Blocks as there are Items in the DataGrid (ItemsTable);
        private void clearItemBlocks(int rows)
        {
            VectorDraw.Professional.vdFigures.vdInsert itemTotal = null;
            foreach (VectorDraw.Professional.vdPrimaries.vdFigure item in vectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Entities)
            {
                VectorDraw.Professional.vdFigures.vdInsert ins = item as VectorDraw.Professional.vdFigures.vdInsert;
                int i;
                if (ins == null) continue;
                if (ins.Block.Name.Equals("itemTotal")) itemTotal = ins;
                if (ins.Block.Name.Equals("itemBlock"))
                {
                    i = int.Parse(ins.Label.ToString());
                    if (i >= rows && i != 0)
                    {
                        //If there are more Item Blocks than the Items the user has inserted in the DataGrid (ItemsTable), they are removed
                        //from the Entities of the vectorDrawBaseControl and the Item Total Block is relocated accordingly.
                        if (rows > 0)
                            itemTotal.InsertionPoint = new VectorDraw.Geometry.gPoint(itemTotal.BoundingBox.Left, 110 - (rows * ins.BoundingBox.Height));
                        itemTotal.Update();
                        //vectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Entities.RemoveItem(ins);
                        ins.Deleted = true;
                        initializedRow[i] = false;
                    }
                }
            }
        }
        //
        #endregion

        #region ATTRIBUTE MODIFYING
        //
        //This method is used to change the values of the Attributes in the Invoice Form (except the Attributes in the Item Blocks).
        private void setAttrValue(string blockName, string attrName, string value)
        {
            VectorDraw.Professional.vdFigures.vdAttrib attr = null;
            foreach (VectorDraw.Professional.vdPrimaries.vdFigure item in vectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Entities)
            {
                VectorDraw.Professional.vdFigures.vdInsert ins = item as VectorDraw.Professional.vdFigures.vdInsert;
                if (ins == null) continue;
                if (ins.Block.Name.CompareTo(blockName) == 0)
                {
                    //Once we locate the insert with the corresponding Block name we edit the attribute we want, using its Tag name.
                    attr = ins.Attributes.FindTagName(attrName);
                    attr.ValueString = value;
                    //Every time we modify an attribute we shoule use the Update method to make sure the modifications are visible.
                    attr.Update();
                }
            }
        }
        //This method is used to change the values of the Attributes of the Item Blocks in the Invoice Form.
        //We use a different method, because the Item Block Inserts can be multiple so we can't identify them by their Block names. Instead we 
        //use their labels.
        private void setItemAttrValue(string blockName, string attrName, string value, string insertLabel)
        {
            VectorDraw.Professional.vdFigures.vdAttrib attr = null;
            foreach (VectorDraw.Professional.vdPrimaries.vdFigure item in vectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Entities)
            {
                VectorDraw.Professional.vdFigures.vdInsert ins = item as VectorDraw.Professional.vdFigures.vdInsert;
                if (ins == null) continue;
                if (ins.Label.CompareTo(insertLabel) == 0)
                {
                    //Once we locate the insert with the corresponding Label we edit the attribute we want, using its Tag name.
                    attr = ins.Attributes.FindTagName(attrName);
                    attr.ValueString = value;
                    //Every time we modify an attribute we shoule use the Update method to make sure the modifications are visible.
                    attr.Update();
                }
            }
        }
        //This method returns the value string of the corresponding Attribute, from a specific Block.
        private string getAttrValue(string blockName, string attrName)
        {
            foreach (VectorDraw.Professional.vdPrimaries.vdFigure item in vectorDrawBaseControl1.ActiveDocument.ActiveLayOut.Entities)
            {
                VectorDraw.Professional.vdFigures.vdInsert ins = item as VectorDraw.Professional.vdFigures.vdInsert;
                if (ins == null) continue;
                if (ins.Block.Name.CompareTo(blockName) == 0)
                {
                    return ins.Attributes.FindTagName(attrName).ValueString;
                }
            }
            return null;
        }
        #endregion
    }
    //This class is used as a template for the Form's DataGrid (ItemsTable).
    class Items
    {
        string l_item;
        string l_description;
        string l_quantity;
        string l_rate;
        string l_amount;
        public string item { get { return l_item; } set { l_item = value; } }
        public string description { get { return l_description; } set { l_description = value; } }
        public string quantity { get { return l_quantity; } set { l_quantity = value; } }
        public string rate { get { return l_rate; } set { l_rate = value; } }
        public string amount { get { return l_amount; } set { l_amount = value; } }
        public Items()
        {
            item = l_item; description = l_description; quantity = l_quantity; rate = l_rate; amount = l_amount;
        }
    }
}
