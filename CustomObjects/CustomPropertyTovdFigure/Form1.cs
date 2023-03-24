using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using VectorDraw.Professional.vdFigures;
using VectorDraw.Geometry;
using VectorDraw.Professional.vdPrimaries;

///Description:

//In this example we demonstrate a way to add to the properties list properties that are not implemented in VectorDraw figures.
//For example you can add extra properties like Area , Length , Handle etc... to our figures like vdLine vdCircle etc...
//We do not by default add these properties to our objects because they require calculation and it can be very heavy depending the object but if someone really needs these properties they can be added as explained below.
//Specially when a lot of objects are selected at the same time , for example 10.000 polylines , try to imagine the calculations of the area that are going to be made.
//This is because when a lot of objects are selected the properties list gets all the properties of the objects and compares them in order to find similar values. In some cases this can slow down a lot selecting of entities.

//Note that this is not a way to Globalize the Properties list. It is to add some custom properties that may be required to an application.
//This way can slow the properties list functionality so please be carefull on how many properties you additionally add to figures.

///Use:

//First of all you need to add the VectorDraw.Serialize.PropertyDescriptorEvents.GlobalPropertyDescriptorEvents.OnAddExtraProperties event.
//This event is fired only once when the object descriptor is created to the properties list. It will not pass every time you select an item.
// In this event you basically state the extra properties that you are going to implement for certain types using the  VectorDraw.Serialize.CustomizePropertyDescriptor.Create method.
//This method takes the following parameters
//param name="ObjectType">The type of the object.
//param name="PropertyName">The name of the property.
//param name="PropertyType">The type of the property.
//param name="typeconverter">A typeConverter to be used for the properties list.
//param name="GetSetValueType">The type of the class that implements the Get/Set values.
//param name="IsReadOnly">A boolean value that represents if the property is readonly.
//param name="Category">The category where the property is going to be displayed in the properties list.
//param name="DisplayName">The globalised Display name.
//param name="Description">The description of the property shown below at the properties list.
//returns>The created PropertyDescriptor.

//The Below example demonstrates the creation of 3 custom properties.
//1)For all vdCurve objects a readonly Area property is added and displayed. Note that this property is not displayed when multiple items are selected.
//2)For all vdCurve objects a Length property is added and displayed.Note that for vdLine objects this property has also set value which changes the EndPoint of the Line. Note that this property is not displayed when multiple items are selected.
//3)For all vdFigure objects a readonly Handle property is added and displayed.Note that this property is not displayed when multiple items are selected.

//The visibility of the property when multiple items are selected is controlled by the public bool GetContextVisibility.

//NOTE: Custom vdFigure objects do not need this implemantation because developer can export his own properties and make them visible to property grid.



namespace CustomPropertyTovdFigure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //The required event is added when the form is loaded.
            VectorDraw.Serialize.PropertyDescriptorEvents.GlobalPropertyDescriptorEvents.OnAddExtraProperties += new VectorDraw.Serialize.PropertyDescriptorEvents.AddExtraPropertiesDelegate(GlobalPropertyDescriptorEvents_OnAddExtraProperties);

            //Add some figures
            vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdCircle(new gPoint(0, 0, 0), 3.0);
            vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdCircle(new gPoint(5, 0, 0), 2.0);
            gPoints pts = new gPoints ();
            pts.Add (new gPoint (0,0,0));
            pts.Add (new gPoint (5,0,0));
            vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdLine (pts);


            gPoints vrts = new gPoints();
            vrts.Add(new gPoint(2, 2, 0));
            vrts.Add(new gPoint(5, 2, 0));
            vrts.Add(new gPoint(5, 5, 0));
            vrts.Add(new gPoint(0, 5, 0));
            //vdPolyline pl = new vdPolyline(vdFramedControl1.BaseControl.ActiveDocument, vrts);
            vdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdPolyLine(vrts);

            MessageBox.Show("Select Individual figures to see their extra Area,Length,Handle properties");
        }

        void GlobalPropertyDescriptorEvents_OnAddExtraProperties(Type t, PropertyDescriptorCollection properties)
        {
            //This event is going to be called once per object type. For a vdLine it will be fired only once.
            if (t.IsSubclassOf(typeof(vdCurve)))
            {
                PropertyDescriptor curveArea = VectorDraw.Serialize.CustomizePropertyDescriptor.Create(
                    t, //The type of the object
                    "Area", //The name of the property.
                     typeof(double), //property 'Area' is a Double Type value
                     typeof(DoubleLinearConverter), //define the TypeConverter of 'Area' property to be a VectorDraw DoubleLinearConverter
                    //(type converter attribute is used by PropertyDescriptor when 
                    //the property is converted to string in order to be displayed in property grid
                    //-or- when the user is type a new value string on grid for this property and need to be converted from this string.
                    //Generaly the following VectorDraw predefined TypeConverters can be used.
                    //    DoubleAngularConverter : for double values that represent an angle and display according to vdDocument.Aunits
                    //    DoubleLinearConverter : for double values that represent a distance and display according to vdDocument.Lunits
                    //    EnumTypeConverter : for Enum values
                    //    null for default Microsoft Type Converter.

                     typeof(MyNewAreaObjectProperty), //a class that Implements IExtraPropertyGetSetValue interface used to get and set the value of the properties to-or-from property grid.This value is then filter by the passed Typed converter in Attributes collection as in previous parameter
                     true, //Set the readOnly property .The 'Area' in this case is defined as read only.
                     "Extras", //The Category of the property grid where the 'Area' property will be added.
                     "", //A localized Display Name of the property.Set it to Empty string in order the passed PropertyName to be used.
                     "Area of object in Drawing Units"//The description of the property that will be displayed in the info area of property grid.
                     );
                properties.Add(curveArea);//add the Area PropertyDescriptor to the existing properties of the selected object type.

                //create a new 'Legth' property  that will be displayed in property grid when an object of vdCurve type will be selected.
                PropertyDescriptor curveLength = VectorDraw.Serialize.CustomizePropertyDescriptor.Create(
                    t,//The type of the object
                    "Length",//The name of the property.
                    typeof(double), //property 'Length' is a Double Type value
                    typeof(DoubleLinearConverter),//same as 'Area' property
                    typeof(MyNewLengthObjectProperty), //same as 'Area' property
                    !t.Equals(typeof(vdLine)),//The 'Length' can be changed only for vdLine object type.In all other types is readonly.
                    "Extras", //same as 'Area' property
                    "", //same as 'Area' property
                    "Get/Set Legth of object in Drawing Units"//The description of the property thta will be displayed in the info area of property grid.
                    );
                properties.Add(curveLength);//add the Length PropertyDescriptor to the existing properties of the selected object type.
            }

            if (t.IsSubclassOf(typeof(vdFigure)))
            {
                PropertyDescriptor FigureHandle = VectorDraw.Serialize.CustomizePropertyDescriptor.Create(
                    t, 
                    "Handle",
                    typeof(string),
                    null,
                    typeof(MyNewHandleObjectProperty),
                    true,
                    "Extras",
                    "",
                    "Handle of the Object"
                );
                properties.Add(FigureHandle);
            }
            if (t.Equals(typeof(vdPolyline))) // This "NAME" will be available ONLY in vdPolyline objects
            {
                PropertyDescriptor FigureName = VectorDraw.Serialize.CustomizePropertyDescriptor.Create(
                    t, 
                    "Name",
                    typeof(string),
                    typeof (StringConverter),
                    typeof(MyNewNameObjectProperty),
                    false,
                    "Extras",
                    "",
                    "Name of the Object"
                );
                properties.Add(FigureName);
            }
        }

        class MyNewAreaObjectProperty : VectorDraw.Serialize.IExtraPropertyGetSetValue
        {
            public MyNewAreaObjectProperty() { }
            public object GetValue(PropertyDescriptor sender, object component)
            {
                vdCurve curve = component as vdCurve;
                return curve.Area();
            }
            public void SetValue(PropertyDescriptor sender, object component, object value)
            {
                //Property Area is defined as read-only
            }
            //implement visibility depend on the object that is connected with specific property and is usally the property grid selected object.
            public bool GetContextVisibility(PropertyDescriptor sender, object instance)
            {
                //Show the property only in case that selected object on the grid is a single vdCurve type object
                if (instance is vdCurve) return true;
                return false;
            }
        }
        class MyNewLengthObjectProperty : VectorDraw.Serialize.IExtraPropertyGetSetValue
        {

            public MyNewLengthObjectProperty() { }
            public object GetValue(PropertyDescriptor sender, object component)
            {
                vdCurve curve = component as vdCurve;
                return curve.Length();
            }
            public void SetValue(PropertyDescriptor sender, object component, object value)
            {
                //Property can be Set only in case of vdLine object type.
                vdLine l = component as vdLine;
                if (l == null) return;
                //Change the EndPoint property of vdLine so the distance between StartPoint and new EndPoint to be Equal to passed value
                l.EndPoint = l.StartPoint + (new Vector(l.StartPoint, l.EndPoint) * (double)value);
            }
            //implement visibility depend on the object that is connected with specic property and is usally the property grid selected object.
            public bool GetContextVisibility(PropertyDescriptor sender, object instance)
            {
                //Show the property only in case that selected object on the grid is a single vdCurve type object
                if (instance is vdCurve) return true;
                return false;
            }
        }
        class MyNewHandleObjectProperty : VectorDraw.Serialize.IExtraPropertyGetSetValue
        {
            public MyNewHandleObjectProperty() { }
            public object GetValue(PropertyDescriptor sender, object component)
            {
                vdFigure fig = component as vdFigure;
                return fig.Handle .ToString();
            }
            public void SetValue(PropertyDescriptor sender, object component, object value)
            {
                //Property Handle is defined as read-only
            }
            //implement visibility depend on the object that is connected with specic property and is usally the property grid selected object.
            public bool GetContextVisibility(PropertyDescriptor sender, object instance)
            {
                //Show the property only in case that selected object on the grid is a single vdFigure type object
                if (instance is vdFigure) return true;
                return false;
            }
        }
        class MyNewNameObjectProperty : VectorDraw.Serialize.IExtraPropertyGetSetValue
        {
            public MyNewNameObjectProperty() { } // this property will be saved and read from the XProperties of the the vdPolyline
            public object GetValue(PropertyDescriptor sender, object component)
            {
                vdPolyline fig = component as vdPolyline;

                VectorDraw.Professional.vdObjects.vdXProperty xprop =  fig.XProperties.FindName("Name");
                if (xprop == null) { xprop = fig.XProperties.Add("Name"); xprop.PropValue = ""; }// create the xproperty if it doesn't exist
                return xprop.PropValue.ToString();
            }
            public void SetValue(PropertyDescriptor sender, object component, object value)
            {
                vdPolyline fig = component as vdPolyline;
                if (fig == null) return;
                VectorDraw.Professional.vdObjects.vdXProperty xprop = fig.XProperties.FindName("Name");
                if (xprop == null) { xprop = fig.XProperties.Add("Name"); xprop.PropValue = ""; } // create the xproperty if it doesn't exist
                xprop.PropValue = (string)value;
            }
            //implement visibility depend on the object that is connected with specic property and is usally the property grid selected object.
            public bool GetContextVisibility(PropertyDescriptor sender, object instance)
            {
                //Show the property only in case that selected object on the grid is a single vdFigure type object
                if (instance is vdPolyline) return true;
                return false;
            }
        }
    }
}