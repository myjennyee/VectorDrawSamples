Description:

In the following example is demonstrated how to develop an Application that, given a Template Drawing as the basic print layout, can edit the Template's text
dynamically, according to the user input. As an example, here, is demonstrated how someone can create an Invoice Form Application. This is achieved by using
an existing Vector Draw .vdml document template and modifying its Attributes, using a Vector Draw BaseControl and other simple controls, such as Textboxes
and Buttons. In further detail someone can review the use, creation and removal of Insert objects. How to searchfor an Insert object using its BlockName
or its Label. The way to locate and control an Insert's Attributes in order to present text dynamically, and finally how to rearrange- move shapes or inserts
pressing a button. 

Use:

Once the Application is started, the template .vdml document is loaded. By using the Application's Components (TextBoxes, DataGrid etc),
the values of the various Attributes can be altered. Whenever an Attribute needs to be modified, all we have to do is insert the value in
the right TextBox and press "Enter" (or press the "Update" button at the bottom). Finally in the Items DataGrid we can add, remove and modify
up to 4 items (Due to the functionality of the component, pressing "Enter" won't work in the DataGrid).