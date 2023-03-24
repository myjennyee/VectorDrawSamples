Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports VectorDraw.Professional.vdFigures
Imports VectorDraw.Geometry
Imports VectorDraw.Professional.vdPrimaries
Imports VectorDraw.Serialize

'Description:

'In this example we demonstrate a way to add to the properties list properties that are not implemented in VectorDraw figures.
'For example you can add extra properties like Area , Length , Handle etc... to our figures like vdLine vdCircle etc...
'We do not by default add these properties to our objects because they require calculation and it can be very heavy depending the object but if someone really needs these properties they can be added as explained below.
'Specially when a lot of objects are selected at the same time , for example 10.000 polylines , try to imagine the calculations of the area that are going to be made.
'This is because when a lot of objects are selected the properties list gets all the properties of the objects and compares them in order to find similar values. In some cases this can slow down a lot selecting of entities.

'Note that this is not a way to Globalize the Properties list. It is to add some custom properties that may be required to an application.
'This way can slow the properties list functionality so please be carefull on how many properties you additionally add to figures.

'/Use:

'First of all you need to add the VectorDraw.Serialize.PropertyDescriptorEvents.GlobalPropertyDescriptorEvents.OnAddExtraProperties event.
'This event is fired only once when the object descriptor is created to the properties list. It will not pass every time you select an item.
'In this event you basically state the extra properties that you are going to implement for certain types using the  VectorDraw.Serialize.CustomizePropertyDescriptor.Create method.
'This method takes the following parameters
'param name="ObjectType">The type of the object.
'param name="PropertyName">The name of the property.
'param name="PropertyType">The type of the property.
'param name="typeconverter">A typeConverter to be used for the properties list.
'param name="GetSetValueType">The type of the class that implements the Get/Set values.
'param name="IsReadOnly">A boolean value that represents if the property is readonly.
'param name="Category">The category where the property is going to be displayed in the properties list.
'param name="DisplayName">The globalised Display name.
'param name="Description">The description of the property shown below at the properties list.
'returns>The created PropertyDescriptor.

'The Below example demonstrates the creation of 3 custom properties.
'1)For all vdCurve objects a readonly Area property is added and displayed. Note that this property is not displayed when multiple items are selected.
'2)For all vdCurve objects a Length property is added and displayed.Note that for vdLine objects this property has also set value which changes the EndPoint of the Line. Note that this property is not displayed when multiple items are selected.
'3)For all vdFigure objects a readonly Handle property is added and displayed.Note that this property is not displayed when multiple items are selected.

'The visibility of the property when multiple items are selected is controlled by the public bool GetContextVisibility.

'NOTE: Custom vdFigure objects do not need this implemantation because developer can export his own properties and make them visible to property grid.

Public Class Form1
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler PropertyDescriptorEvents.GlobalPropertyDescriptorEvents.OnAddExtraProperties, New VectorDraw.Serialize.PropertyDescriptorEvents.AddExtraPropertiesDelegate(AddressOf Me.GlobalPropertyDescriptorEvents_OnAddExtraProperties)

        'Add some figures
        VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdCircle(New gPoint(0, 0, 0), 3.0)
        VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdCircle(New gPoint(5, 0, 0), 2.0)
        Dim pts As New gPoints()
        pts.Add(New gPoint(0, 0, 0))
        pts.Add(New gPoint(5, 0, 0))
        VdFramedControl1.BaseControl.ActiveDocument.CommandAction.CmdLine(pts)

        MessageBox.Show("Select Individual figures to see their extra Area,Length,Handle properties")
    End Sub

    Private Sub GlobalPropertyDescriptorEvents_OnAddExtraProperties(ByVal t As Type, ByVal properties As PropertyDescriptorCollection)
        If t.IsSubclassOf(GetType(vdCurve)) Then
            Dim curveArea As PropertyDescriptor = CustomizePropertyDescriptor.Create(t, "Area", GetType(Double), GetType(DoubleLinearConverter), GetType(MyNewAreaObjectProperty), True, "Extras", "", "Area of object in Drawing Units")
            properties.Add(curveArea)
            Dim curveLength As PropertyDescriptor = CustomizePropertyDescriptor.Create(t, "Length", GetType(Double), GetType(DoubleLinearConverter), GetType(MyNewLengthObjectProperty), Not t.Equals(GetType(vdLine)), "Extras", "", "Get/Set Legth of object in Drawing Units")
            properties.Add(curveLength)
        End If
        If t.IsSubclassOf(GetType(vdFigure)) Then
            Dim FigureHandle As PropertyDescriptor = CustomizePropertyDescriptor.Create(t, "Handle", GetType(String), Nothing, GetType(MyNewHandleObjectProperty), True, "Extras", "", "Handle of the Object")
            properties.Add(FigureHandle)
        End If
    End Sub

    Private Class MyNewAreaObjectProperty
        Implements VectorDraw.Serialize.IExtraPropertyGetSetValue
        ' Methods
        Public Sub New()
        End Sub
        Public Function GetValue(ByVal sender As PropertyDescriptor, ByVal component As Object) As Object Implements IExtraPropertyGetSetValue.GetValue
            Dim curve As vdCurve = TryCast(component, vdCurve)
            Return curve.Area
        End Function

        Public Sub SetValue(ByVal sender As PropertyDescriptor, ByVal component As Object, ByVal value As Object) Implements IExtraPropertyGetSetValue.SetValue
            'Property Area is defined as read-only
        End Sub

        Public Function GetContextVisibility(ByVal sender As PropertyDescriptor, ByVal instance As Object) As Boolean Implements IExtraPropertyGetSetValue.GetContextVisibility
            Return TypeOf instance Is vdCurve
        End Function
    End Class
    Private Class MyNewHandleObjectProperty
        Implements VectorDraw.Serialize.IExtraPropertyGetSetValue
        ' Methods
        Public Sub New()
        End Sub
        Public Function GetContextVisibility(ByVal sender As PropertyDescriptor, ByVal instance As Object) As Boolean Implements IExtraPropertyGetSetValue.GetContextVisibility
            Return TypeOf instance Is vdFigure
        End Function

        Public Function GetValue(ByVal sender As PropertyDescriptor, ByVal component As Object) As Object Implements IExtraPropertyGetSetValue.GetValue
            Dim fig As vdFigure = TryCast(component, vdFigure)
            Return fig.Handle.ToString
        End Function

        Public Sub SetValue(ByVal sender As PropertyDescriptor, ByVal component As Object, ByVal value As Object) Implements IExtraPropertyGetSetValue.SetValue
        End Sub
    End Class
    Private Class MyNewLengthObjectProperty
        Implements VectorDraw.Serialize.IExtraPropertyGetSetValue
        ' Methods
        Public Sub New()
        End Sub
        Public Function GetContextVisibility(ByVal sender As PropertyDescriptor, ByVal instance As Object) As Boolean Implements IExtraPropertyGetSetValue.GetContextVisibility
            Return TypeOf instance Is vdCurve
        End Function

        Public Function GetValue(ByVal sender As PropertyDescriptor, ByVal component As Object) As Object Implements IExtraPropertyGetSetValue.GetValue
            Dim curve As vdCurve = TryCast(component, vdCurve)
            Return curve.Length
        End Function

        Public Sub SetValue(ByVal sender As PropertyDescriptor, ByVal component As Object, ByVal value As Object) Implements IExtraPropertyGetSetValue.SetValue
            Dim l As vdLine = TryCast(component, vdLine)
            If (Not l Is Nothing) Then
                l.EndPoint = (l.StartPoint + DirectCast((New Vector(l.StartPoint, l.EndPoint) * CDbl(value)), gPoint))
            End If
        End Sub

    End Class
End Class


