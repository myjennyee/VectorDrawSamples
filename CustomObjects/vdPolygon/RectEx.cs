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

namespace VectorDrawCustomFigs
{
    public class RectEx : vdShape, IvdProxyFigure
    {
        #region Variables
        private double mRectHeight = 1.0;
        private double mRectWidth = 1.0;
        #endregion

        #region ctor
        public RectEx()
        {
        }
        public RectEx(vdDocument doc)
        {
            SetUnRegisterDocument(doc);
            setDocumentDefaults();
        }
        #endregion
        #region not vdShape supported properties
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
        #region Properties
        public double RectHeight
        {
            get { return mRectHeight; }
            set
            {
                AddHistory("RectHeight", value);
                mRectHeight = value;
            }
        }
        public double RectWidth
        {
            get { return mRectWidth; }
            set
            {
                AddHistory("RectWidth", value);
                mRectWidth = value;
            }
        }
        #endregion
        #region serialization
        
        //Note that not all values/objects can be saved/serialize by VDF, and you need to write code for such properties in serialize/deserialize override of this object. 
        //You can set value of custom property to any of the following type values: 
        //     String, Double, Int32, Boolean, Byte, Int16, Int64, UInt16, UInt64, UInt32, Single, ushort, System.Color, VectorDraw.Serialize.IVDHandle and IVDSerialise

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(mRectHeight, "RectHeight");
            serializer.Serialize(mRectWidth, "RectWidth");
        }
        public override bool DeSerialize(DeSerializer deserializer, string fieldname, object value)
        {
            if (base.DeSerialize(deserializer, fieldname, value)) return true;
            else if (fieldname == "RectHeight") mRectHeight = (double)value;
            else if (fieldname == "RectWidth") mRectWidth = (double)value;
            else return false;
            return true;
        }
        #endregion

        #region Rect calulation
        public override void FillShapeEntities(ref vdEntities entities)
        {//calculate shape entities in ecs 

            gPoint Orig = new gPoint();

            vdRect rect = new vdRect();
            entities.AddItem(rect);
            rect.MatchProperties(this, Document);
            rect.InsertionPoint = new gPoint (  - RectWidth /2.0 , - RectHeight /2.0 , 0.0) ;
            rect.Width = RectWidth;
            rect.Height = RectHeight;
        }
        #endregion

        #region overrides
        public override void InitializeProperties()
        {
            mRectHeight = 1.0;
            mRectWidth = 1.0;
        }
        public override void MatchProperties(VectorDraw.Professional.vdObjects.vdPrimary _from, VectorDraw.Professional.vdObjects.vdDocument thisdocument)
        {
            base.MatchProperties(_from, thisdocument);
            RectEx from = _from as RectEx;
            if (from == null) return;
            RectHeight = from.RectHeight;
            RectWidth = from.RectWidth;
        }
        public override gPoints GetGripPoints()
        {
            gPoints ret = new gPoints();
            gPoint cen = new gPoint();
            ret.Add(cen);
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
                            break;
                    }
                }
            }
            Update();
        }
        #endregion
    }
    public class ActionRectEx : ActionEntity
    {
        private RectEx figure;
        public ActionRectEx(gPoint reference, vdLayout layout)
            : base(reference, layout)
        {
            ValueTypeProp |= valueType.DISTANCE;
            figure = new RectEx();
            figure.SetUnRegisterDocument(layout.Document);
            figure.setDocumentDefaults();
            figure.Origin = reference;
        }
        protected override void OnMyPositionChanged(gPoint newPosition)
        {
            figure.RectHeight = Math.Abs(figure.Origin.y - newPosition.y)*2.0;
            figure.RectWidth  = Math.Abs(figure.Origin.x - newPosition.x)*2.0;
        }
        public override vdFigure Entity
        {
            get
            {
                return figure;
            }
        }
        public static void CmdRectEx(vdDocument doc)
        {
            gPoint cen = new gPoint();
            doc.Prompt("Origin Point : ");
            object ret = doc.ActionUtility.getUserPoint();
            doc.Prompt(null);
            if (ret == null || !(ret is gPoint)) goto error;
            cen = ret as gPoint;
            doc.Prompt("Width & Height : ");
            ActionRectEx aFig = new ActionRectEx(cen, doc.ActiveLayOut);
            doc.ActionAdd(aFig);
            VectorDraw.Actions.StatusCode scode = aFig.WaitToFinish();
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
