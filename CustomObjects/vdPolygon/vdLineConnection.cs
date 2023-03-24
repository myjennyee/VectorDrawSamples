using System;
using System.Collections.Generic;
using System.Text;
using VectorDraw.Geometry;
using VectorDraw.Professional.vdCollections;
using VectorDraw.Professional.vdFigures;
using VectorDraw.Professional.vdObjects;
using VectorDraw.Professional.vdPrimaries;
using VectorDraw.Render;
using VectorDraw.Serialize;

namespace VectorDrawCustomFigs
{
    public class vdLineConnection : vdFigure, IvdProxyFigure, ISupportResolveReferenceObjects
    {
        vdFigure mFig1 = null;
        vdFigure mFig2 = null;

        public vdLineConnection()
        {
        }
        public vdLineConnection(vdDocument doc) 
        {
            SetUnRegisterDocument(doc);
            setDocumentDefaults();
        }

        public vdFigure Figure1
        {
            get { return mFig1; }
            set
            {
                AddHistory("Figure1", value);
                Disconnect(mFig1);
                mFig1 = value;
                Connect(mFig1);
            }
        }
        public vdFigure Figure2
        {
            get { return mFig2; }
            set
            {
                AddHistory("Figure2", value);
                Disconnect(mFig2);
                mFig2 = value;
                Connect(mFig2);
            }
        }
        bool Isvalid
        {
            get
            {
                if (Figure1 == null || Figure2 == null || Figure1 == Figure2 || Figure1.Deleted || Figure2.Deleted) return false;
                return true;
            }
        }
        public override bool Deleted
        {
            get
            {
                if (!Isvalid) return true;
               return base.Deleted;
            }
        }
        public override Box BoundingBox
        {
            get
            {
                if (mBoundBox.IsEmpty)
                {
                    if (Isvalid)
                    {
                        //mBoundBox = new Box(Figure1.BoundingBox.MidPoint, Figure2.BoundingBox.MidPoint);
                        mBoundBox.AddBox(Figure1.BoundingBox);
                        mBoundBox.AddBox(Figure2.BoundingBox);
                    }
                }
                return mBoundBox;
            }

        }
        public override vdRender.DrawStatus Draw(vdRender render)
        {
            if (!Isvalid) return vdRender.DrawStatus.Failed;
            vdRender.DrawStatus doDraw = base.Draw(render);
            if (doDraw == vdRender.DrawStatus.Successed)
            {
                render.DrawLine(this, Figure1.BoundingBox.MidPoint, Figure2.BoundingBox.MidPoint);
            }
            AfterDraw(render);
            return doDraw;
        }
        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(Figure1, "Figure1");
            serializer.Serialize(Figure2, "Figure2");
        }
        public override gPoints GetGripPoints()
        {
            gPoints ret = new gPoints();
            if (Figure1 != null && Figure2 != null) ret.Add(gPoint.MidPoint(Figure1.BoundingBox.MidPoint, Figure2.BoundingBox.MidPoint));
            return ret;
        }
        public override void MoveGripPointsAt(Int32Array Indexes, double dx, double dy, double dz)
        {
            if (Indexes == null || Indexes.Count == 0 || (dx == 0.0 && dy == 0.0 && dz == 0.0)) return;
            gPoints grips = GetGripPoints();

            Matrix matt = new Matrix();
            matt.TranslateMatrix(new gPoint(dx, dy, dz));
            foreach (int index in Indexes)
            {
                switch (index)
                {
                    case 0:
                        if (Figure1 != null) Figure1.Transformby(matt);
                        if (Figure2 != null) Figure2.Transformby(matt);
                        break;
                    default:
                        break;
                }
            }
            Update();
        }
        public override bool DeSerialize(DeSerializer deserializer, string fieldname, object value)
        {
            if (base.DeSerialize(deserializer, fieldname, value)) return true;
            else if (fieldname == "Figure1") Figure1 = (vdFigure)value;
            else if (fieldname == "Figure2") Figure2 = (vdFigure)value;
            else return false;
            return true;
        }

        void ISupportResolveReferenceObjects.ResolveReferences(vdFigure sourcefigure, ResolveReferenceObjects referenceObjects)
        {
            vdLineConnection baseobj = sourcefigure as vdLineConnection;
            Figure1 = referenceObjects.AddReference(baseobj.Figure1);
            Figure2 = referenceObjects.AddReference(baseobj.Figure2);
        }

        void Connect(vdFigure fig)
        {
            if (fig == null) return;
            fig.OnAfterModifyObjectEx += Fig_OnAfterModifyObjectEx;
        }
        void Disconnect(vdFigure fig)
        {
            if (fig == null) return;
            fig.OnAfterModifyObjectEx -= Fig_OnAfterModifyObjectEx;
        }

        private void Fig_OnAfterModifyObjectEx(object sender, string propertyname)
        {
            this.Update();
            this.Invalidate();
        }

        protected override void OnOwnerChanged()
        {
            base.OnOwnerChanged();
            if(Owner == null)
            {
                Disconnect(mFig1);
                Disconnect(mFig2);
            }
            
        }
        void ISupportResolveReferenceObjects.OnAddToSameSelection(vdSelection selset)
        {
        }
        private void VdLineConnection_OnAfterModifyObjectEx(object sender, string propertyname)
        {
            this.Update();
            this.Invalidate();
        }
        /// <summary>
        /// A simple command that will prompt the user to select two vdFigures and then create a LineConnection between them.
        /// </summary>
        /// <param name="doc"></param>
        public static void LineConnectionEx(vdDocument doc)
        {
             vdFigure fig1 = null, fig2 = null;
            gPoint pt;
            doc.Prompt("Select Fig1");
            doc.ActionUtility.getUserEntity(out fig1, out pt);
            doc.Prompt(null);
            if (fig1 != null)
            {
                doc.Prompt("Select Fig2");
                doc.ActionUtility.getUserEntity(out fig2, out pt);
                doc.Prompt(null);
            }

            if(fig1 == null || fig2 == null || fig1 == fig2)
            {
                doc.Prompt("\r\nYou must select 2 deferent entities:");
                doc.Prompt(null);
            }
            vdLineConnection lineconnection = new vdLineConnection(doc);
            lineconnection.Figure1 = fig1;
            lineconnection.Figure2 = fig2;
            doc.Model.Entities.AddItem(lineconnection);
            doc.ActionDrawFigure(lineconnection);
        }
    }
}
