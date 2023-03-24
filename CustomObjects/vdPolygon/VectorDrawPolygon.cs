using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using VectorDraw.Serialize;
using VectorDraw.Professional;
using VectorDraw.Professional.vdPrimaries;
using VectorDraw.Professional.vdFigures;
using VectorDraw.Professional.vdCollections;
using VectorDraw.Professional.vdObjects;
using VectorDraw.Professional.Constants;
using VectorDraw.Geometry;
using VectorDraw.Render;
using VectorDraw.Professional.Actions;
using VectorDraw.Actions;

//This custom object also demonstrates how you can serialize an array of objects in vdml/vdcl format

//the VectorDrawCustomFigs.dll must be in the folder of vdrawcomponents
//or the supportpath must contain the path of the assemply dll
namespace VectorDrawCustomFigs
{
    public class VectorDrawPolygon : vdShape
    {
        #region main variables
        private vdTextstyle mTextStyle = null;
        private int mNumSides = 4;
        private string mText = "";
        private double mTextHeight = 1.0d;
        private double mRadius = 1.0d;
        private VectorDraw.Generics.vdArray<double> mMyArray = new VectorDraw.Generics.vdArray<double>();  
        #endregion

        #region ctor
        public VectorDrawPolygon()
        {
        }
        public VectorDrawPolygon(vdDocument doc)
        {
            SetUnRegisterDocument(doc);
            setDocumentDefaults();
        }
        #endregion
        #region not vdShape supported properties
        [Browsable(false)]
        public override double Rotation
        {//do not support vdShape Rotation
            get
            {
                //return base.Rotation;
                return 0.0d;
            }
            set
            {
                //base.Rotation = value;
            }
        }
        [Browsable(false)]
        public override Vector Scales
        {//do not support vdShape Scales
            get
            {
                //return base.Scales;
                return new Vector(1.0d, 1.0d, 1.0d);
            }
            set
            {
                //base.Scales = value;
            }
        }
        #endregion
        #region vdShape override properties
        public override gPoint Origin
        {
            get
            {
                return base.Origin;
            }
            set
            {
                base.Origin = value;
                Update();
            }
        }
        #endregion
        #region properties
        //You should use the AddHistory command in your properties so any change will be writen to the history
        //The string in the AddHistory command is the name of the property exactly and should be called before the property change.
        public int NumSides
        {
            get { return mNumSides; }
            set
            {
                AddHistory("NumSides", value);
                mNumSides = value;
            }
        }
        public string TextString
        {
            get { return mText; }
            set
            {
                AddHistory("TextString", value);
                mText = value;
            }
        }
        public double Radius
        {
            get { return mRadius; }
            set
            {
                AddHistory("Radius", value);
                mRadius = value;
            }
        }
        public vdTextstyle TextStyle
        {
            get
            {
                return mTextStyle;
            }
            set
            {
                AddHistory("TextStyle", value);
                mTextStyle = value;
            }
        }
        public double TextHeight
        {
            get
            {
                return mTextHeight;
            }
            set
            {
                AddHistory("TextHeight", value);
                mTextHeight = value;
            }
        }

        public void AddSomeValues()
        {
            mMyArray.AddItem(2.0);
            mMyArray.AddItem(3.0);
            mMyArray.AddItem(4.0);
            mMyArray.AddItem(5.0);
        }

        [TypeConverterAttribute()]
        [EditorAttribute(typeof(VectorDraw.Generics.vdCollectionDialogEditorNOSorted), typeof(System.Drawing.Design.UITypeEditor))]
        [Browsable(true)]
        public VectorDraw.Generics.vdArray<double> MyArray
        {
            get { return mMyArray; }
            set { mMyArray = value; }
        }
        #endregion
        #region serialization
        //Note that not all values/objects can be saved/serialize by VDF, and you need to write code for such properties in serialize/deserialize override of this object. 
        //You can set value of custom property to any of the following type values: 
        //     String, Double, Int32, Boolean, Byte, Int16, Int64, UInt16, UInt64, UInt32, Single, ushort, System.Color, VectorDraw.Serialize.IVDHandle and IVDSerialise

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(mNumSides, "NumSides");
            serializer.Serialize(mRadius, "Radius");
            serializer.Serialize(mText, "TextString");
            serializer.Serialize(mTextStyle, "TextStyle");
            serializer.Serialize(mTextHeight, "TextHeight");
            serializer.Serialize(MyArray.Count, "_Count");
            foreach (double obj in MyArray)
            {
                serializer.Serialize(obj, "_Item");
            }

        }
        public override bool DeSerialize(DeSerializer deserializer, string fieldname, object value)
        {
            if (base.DeSerialize(deserializer, fieldname, value)) return true;
            else if (fieldname == "NumSides") mNumSides = (int)value;
            else if (fieldname == "Radius") mRadius = (double)value;
            else if (fieldname == "TextString") mText = (string)value;
            else if (fieldname == "TextStyle") mTextStyle = (vdTextstyle)value;
            else if (fieldname == "TextHeight") mTextHeight = (double)value;
            else if (fieldname == "_Item" && value != null) MyArray.AddItem((double)value);
            else return false;
            return true;
        }
        #endregion
        #region curve calulation
        public override void FillShapeEntities(ref vdEntities entities)
        {//calculate shape entities in ecs 
            
                gPoint cen = new gPoint();
                vdText text = new vdText();
                entities.AddItem(text);
                text.MatchProperties(this, Document);

                text.Style = TextStyle;
                text.TextString = TextString;
                text.VerJustify = VdConstVerJust.VdTextVerCen;
                text.HorJustify = VdConstHorJust.VdTextHorCenter;
                text.Height = TextHeight;
                text.InsertionPoint = cen ;

                vdPolyline pl = new vdPolyline();
                entities.AddItem(pl);
                pl.MatchProperties(this, Document);
                Vertexes verts = new Vertexes();
                double stepangle = Globals.VD_TWOPI / this.NumSides;
                double sang = 0.0d;
                
                for (int i = 0; i < NumSides; i++)
                {
                    verts.Add(gPoint.Polar(cen, sang, Radius));
                    sang += stepangle;
                }
                pl.VertexList = verts;
                pl.Flag = VdConstPlineFlag.PlFlagCLOSE;
           
        }
        #endregion
        #region overrides
        protected override void OnDocumentDefaults()
        {
            base.OnDocumentDefaults();
            mTextStyle = Document.ActiveTextStyle;
            if (mTextStyle == null) mTextStyle = Document.TextStyles.Standard;
        }
        public override void InitializeProperties()
        {
            mNumSides = 4;
            mText = "";
            mTextHeight = 1.0d;
            mTextStyle = null;
            if (Document != null) mTextStyle = Document.TextStyles.Standard;
            mRadius = 1.0d;
            base.InitializeProperties();
        }
        public override void MatchProperties(VectorDraw.Professional.vdObjects.vdPrimary _from, VectorDraw.Professional.vdObjects.vdDocument thisdocument)
        {
            base.MatchProperties(_from, thisdocument);
            VectorDrawPolygon from = _from as VectorDrawPolygon;
            if (from == null) return;
            TextString = from.TextString;
            NumSides = from.NumSides;
            Radius = from.Radius;
            TextStyle = from.TextStyle;
            TextHeight = from.TextHeight;
        }
        public override void Transformby(Matrix mat)
        {
            if (mat.IsUnitMatrix()) return;
            Matrix mult = (ECSMatrix * mat);
            MatrixProperties matprops = mult.Properties;
            Radius *= matprops.GetScaleXY();
            TextHeight *= matprops.GetScaleXY();
            base.Transformby(mat);
        }
        public override gPoints GetGripPoints()
        {
            gPoints ret = new gPoints();
            gPoint cen = new gPoint();
            ret.Add(cen);
            double stepangle = Globals.VD_TWOPI / this.NumSides;
            double sang = 0.0d;
            for (int i = 0; i < NumSides; i++)
            {
                ret.Add(gPoint.Polar(cen, sang, Radius));
                sang += stepangle;
            }
            ECSMatrix.Transform(ret);
            return ret;
        }
        public override void MoveGripPointsAt(Int32Array Indexes, double dx, double dy, double dz)
        {
            if (Indexes == null || Indexes.Count == 0 || (dx == 0.0 && dy == 0.0 && dz == 0.0)) return;
            Matrix mat = new Matrix();
            mat.TranslateMatrix(dx, dy, dz);
            gPoints grips = GetGripPoints();
            ECSMatrix.GetInvertion().Transform(grips);
            if (Indexes.Count == grips.Count)
            {

                Transformby(mat);
            }
            else
            {
                foreach (int index in Indexes)
                {
                    switch (index)
                    {
                        case 0:
                            Transformby(mat);
                            break;
                        default:
                            gPoint grip = new gPoint(grips[index]);
                            grip = ECSMatrix.Transform(grip);
                            grip += new gPoint(dx, dy, dz);
                            this.Radius = gPoint.Distance2D(grip, this.Origin);
                            break;
                    }
                }
            }
            Update();
        }
        public override bool IsTableObjectDependOn(vdPrimary table)
        {
            if (Deleted) return false;//always check if this object is deleted
            if (base.IsTableObjectDependOn(table)) return true;//always check the base implamentation
            //check properties of object that reference the table object.
            if (TextStyle != null && object.ReferenceEquals(TextStyle,table)) return true;
            return false;
        }
        public override void GetTableDependecies(vdTableDependeciesArgs args)
        {
            base.GetTableDependecies(args);
            if (args.IsObjectFound) return;
            if (Deleted) return;
            args.AddItem(TextStyle);
            if (TextStyle != null) TextStyle.GetTableDependecies(args);
        }
        #endregion
    }
    public class ActionPolygon : ActionEntity
    {
        private VectorDrawPolygon figure;
        public ActionPolygon(int NumSides, string text, double textheight, gPoint reference, vdLayout layout)
            : base(reference, layout)
        {
            ValueTypeProp |= valueType.DISTANCE;
            figure = new VectorDrawPolygon();
            figure.SetUnRegisterDocument(layout.Document);
            figure.setDocumentDefaults();
            figure.Origin = reference;
            figure.Radius = 0.0d;
            figure.TextHeight = textheight;
            figure.TextString = text;
            figure.NumSides = NumSides;
        }
        protected override void OnMyPositionChanged(gPoint newPosition)
        {
            figure.Radius = newPosition.Distance3D(figure.Origin);
        }
        public override vdFigure Entity
        {
            get
            {
                return figure;
            }
        }
        public static void CmdPolygon(vdDocument doc)
        {
            gPoint cen = new gPoint();
            doc.Prompt("Origin Point : ");
            object ret = doc.ActionUtility.getUserPoint();
            doc.Prompt(null);
            if (ret == null || !(ret is gPoint)) goto error;
            cen = ret as gPoint;
            doc.Prompt("Textstring : ");
            string text = doc.ActionUtility.getUserString();
            doc.Prompt(null);
            if (text == null) goto error;
            doc.Prompt("Textheight : ");
            ret = doc.ActionUtility.getUserDist(cen);
            doc.Prompt(null);
            if (ret == null) goto error;
            double textheight = (double)ret;
            int numsides = 0;
            doc.Prompt("NumSides : ");
            StatusCode scode = doc.ActionUtility.getUserInt(out numsides);
            doc.Prompt(null);
            if (scode != VectorDraw.Actions.StatusCode.Success) goto error;
            doc.Prompt("Radius : ");
            ActionPolygon aFig = new ActionPolygon(numsides, text, textheight, cen, doc.ActiveLayOut);
            doc.ActionAdd(aFig);
            scode = aFig.WaitToFinish();
            doc.Prompt(null);
            if (scode != VectorDraw.Actions.StatusCode.Success) goto error;
            aFig.Entity.Transformby(doc.User2WorldMatrix);
            doc.ActionLayout.Entities.AddItem(aFig.Entity);
            doc.ActionDrawFigure(aFig.Entity);
            return;
        error:
            return;
        }
    }
}
