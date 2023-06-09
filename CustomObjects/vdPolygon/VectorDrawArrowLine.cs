﻿using System;
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
    public class VectorDrawArrowLine: vdFigure, IvdProxyFigure
    {
        
        #region private fields
        private gPoints mArrowPoints = new gPoints();
        private double mArrowSize = 1.0d;
        private gPoint mStartPoint = new gPoint();
        private gPoint mEndPoint = new gPoint();

        #endregion
        #region ctor
        public VectorDrawArrowLine()
        {
            mArrowPoints.Add(new gPoint(0.0d, 0.0d, 0.0d));
            mArrowPoints.Add(new gPoint(-1.0d, -0.1665d, 0.0d));
            mArrowPoints.Add(new gPoint(-1.0d, 0.1665d, 0.0d));
            mArrowPoints.Add(new gPoint(0.0d, 0.0d, 0.0d));
        }
        public VectorDrawArrowLine(vdDocument doc)
        {
            SetUnRegisterDocument(doc);
            setDocumentDefaults();
            mArrowPoints.Add(new gPoint(0.0d, 0.0d, 0.0d));
            mArrowPoints.Add(new gPoint(-1.0d, -0.1665d, 0.0d));
            mArrowPoints.Add(new gPoint(-1.0d, 0.1665d, 0.0d));
            mArrowPoints.Add(new gPoint(0.0d, 0.0d, 0.0d));
        }
        #endregion
        #region public properties
        //You should use the AddHistory command in your properties so any change will be writen to the history
        //The string in the AddHistory command is the name of the property exactly and should be called before the property change.
        public double arrowSize 
        {
            get 
            {
                return mArrowSize;
            }
            set 
            {
                AddHistory("arrowSize", value);
                mArrowSize = value;
            } 
        }
        public gPoint StartPoint
        {
            get
            {
                return mStartPoint;
            }
            set
            {
                AddHistory("StartPoint", value);
                mStartPoint.CopyFrom( value);
            }
        }
        public gPoint EndPoint
        {
            get
            {
                return mEndPoint;
            }
            set
            {
                AddHistory("EndPoint", value);
                mEndPoint.CopyFrom( value);
            }
        }
        #endregion
        #region private methods
        
        
        Matrix ArrowEcsMatrix(Vector ViewDir)
        {
                Matrix  mArrowMatrix = new Matrix();
                mArrowMatrix.ScaleMatrix(mArrowSize, mArrowSize, 1.0d);
                mArrowMatrix.ApplyECS2WCS(ViewDir, new Vector(StartPoint, EndPoint));
                mArrowMatrix.TranslateMatrix(EndPoint);
                return mArrowMatrix;
            
        }
        #endregion
        #region pline overrides

        //Note that not all values/objects can be saved/serialize by VDF, and you need to write code for such properties in serialize/deserialize override of this object. 
        //You can set value of custom property to any of the following type values: 
        //     String, Double, Int32, Boolean, Byte, Int16, Int64, UInt16, UInt64, UInt32, Single, ushort, System.Color, VectorDraw.Serialize.IVDHandle and IVDSerialise

        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(mArrowSize, "arrowSize");
            serializer.Serialize(mStartPoint, "StartPoint");
            serializer.Serialize(mEndPoint, "EndPoint");
        }
        public override bool DeSerialize(DeSerializer deserializer, string fieldname, object value)
        {
            if (base.DeSerialize(deserializer, fieldname, value)) return true;
            else if (fieldname == "arrowSize") mArrowSize = (double)value;
            else if (fieldname == "StartPoint") mStartPoint = (gPoint)value;
            else if (fieldname == "EndPoint") mEndPoint = (gPoint)value;
            else return false;
            return true;
        }
        public override bool getOsnapPoints(Matrix object2viewcs, OsnapMode mode, gPoint pickPoi, gPoint LastPoi, int SegCount, OsnapPoints osnaps)
        {
            vdLine line = new vdLine();
            line.StartPoint = StartPoint;
            line.EndPoint = EndPoint;
            line.MatchProperties(this, Document);

            return line.getOsnapPoints(object2viewcs, mode, pickPoi, LastPoi, SegCount, osnaps);
        }
        public override Box BoundingBox
        {
            get
            {
                if (!mBoundBox.IsEmpty) return mBoundBox;
                mBoundBox = new Box();
                mBoundBox.AddPoint(StartPoint);
                mBoundBox.AddPoint(EndPoint);
                gPoints pts = new gPoints();
                pts.AddRange(mArrowPoints);
                ArrowEcsMatrix(new Vector(0,0,1)).Transform(pts);
                mBoundBox.AddPoints(pts);
                return mBoundBox;
                
            }
        }
        public override void Transformby(Matrix mat)
        {
            StartPoint = mat.Transform(StartPoint);
            EndPoint = mat.Transform(EndPoint);
            base.Transformby(mat);
        }
        public override vdRender.DrawStatus Draw(vdRender render)
        {
            if (ListStart(render)) return render.StatusDraw;
            vdRender.DrawStatus doDraw = base.Draw(render);
            if (doDraw == vdRender.DrawStatus.Successed)
            {
                render.DrawLine(this, StartPoint,EndPoint);
                render.PushMatrix(ArrowEcsMatrix(render.ViewDir));
                render.DrawSolidPolygon(this, mArrowPoints, vdRender.PolygonType.Simple);
                render.PopMatrix();   
            }
            AfterDraw(render);
            if (ListEnd(render)) doDraw = render.StatusDraw;
            return doDraw;
        }
        public override gPoints GetGripPoints()
        {
            gPoints ret = new gPoints();
            ret.Add(StartPoint);
            ret.Add(EndPoint);
            return ret;
        }
        public override void MoveGripPointsAt(Int32Array Indexes, double dx, double dy, double dz)
        {
            if (Indexes == null || Indexes.Count == 0 || (dx == 0.0 && dy == 0.0 && dz == 0.0)) return;
            gPoints grips = GetGripPoints();
            if (Indexes.Count == grips.Count)
            {
                Matrix mat = new Matrix();
                mat.TranslateMatrix(dx, dy, dz);
                Transformby(mat);
            }
            else
            {
                foreach (int index in Indexes)
                {
                    switch (index)
                    {
                        case 0:
                            StartPoint += new gPoint(dx, dy, dz);
                            break;
                        case 1:
                            EndPoint += new gPoint(dx, dy, dz);
                            break;
                        default:
                            break;
                    }
                }
            }
            Update();

        }
        public override void MatchProperties(VectorDraw.Professional.vdObjects.vdPrimary _from, VectorDraw.Professional.vdObjects.vdDocument thisdocument)
        {
            base.MatchProperties(_from, thisdocument);
            VectorDrawArrowLine from = _from as VectorDrawArrowLine;
            if (from == null) return;
            StartPoint = from.StartPoint;
            EndPoint = from.EndPoint;
            arrowSize = from.arrowSize;
        }
        public override vdEntities Explode()
        {
            vdEntities Entities = new vdEntities();
            Entities.SetUnRegisterDocument(Document);
            if (Document != null) Document.UndoHistory.PushEnable(false);
            vdLine line = new vdLine();
            line.StartPoint = StartPoint;
            line.EndPoint = EndPoint;
            line.MatchProperties(this,Document);
            Entities.AddItem(line);

            vdPolyline pl = new vdPolyline();
            pl.VertexList.AddRange(this.mArrowPoints);
            pl.Flag = VdConstPlineFlag.PlFlagCLOSE;
            pl.HatchProperties = new vdHatchProperties();
            pl.HatchProperties.FillMode = VdConstFill.VdFillModeSolid;
            pl.HatchProperties.FillColor.ByBlock = true;
            pl.Transformby(ArrowEcsMatrix(new Vector(0,0,1)));
            pl.MatchProperties(this,Document);
            Entities.AddItem(pl);
            if (Document != null) Document.UndoHistory.PopEnable();
            return Entities;
        }
        public override bool IsTableObjectDependOn(vdPrimary table)
        {
            //we call only the base check because there are not tables objects reference to this object properties.
            if (Deleted) return false;
            if(base.IsTableObjectDependOn(table)) return true;
            return false;
        }
        public override void GetTableDependecies(vdTableDependeciesArgs args)
        {
            //Since there no extra dependencies the base call is enough.
            base.GetTableDependecies(args);
        }
        #endregion
    }
    public class ActionArrowLine : ActionEntity
    {
        private VectorDrawArrowLine line;
        public ActionArrowLine(gPoint reference, vdLayout layout)
            : base(reference, layout)
        {
            line = new VectorDrawArrowLine();
            line.SetUnRegisterDocument(layout.Document);
            line.setDocumentDefaults();
            line.StartPoint = reference;
            line.EndPoint = reference;
        }
        public override bool HideRubberLine
        {
            get
            {
                return true;
            }
        }
        public override vdFigure Entity
        {
            get
            {
                return line;
            }
        }
        protected override void OnMyPositionChanged(gPoint newPosition)
        {
            line.EndPoint = newPosition;
        }
        public override bool needUpdate
        {
            get
            {
                return true;
            }
        }

        public static void CmdArrowLine(vdDocument document)
        {  
            gPoint EPT, SPT;
            document.Prompt("Start Point:");
            object ret = document.ActionUtility.getUserPoint();
            document.Prompt(null);
            if (ret == null || !(ret is gPoint)) return;
            SPT = ret as gPoint;

            ActionArrowLine aFig = new ActionArrowLine(SPT, document.ActiveLayOut);
            document.Prompt("End Point :");

            document.ActionAdd(aFig);
            StatusCode scode = aFig.WaitToFinish();
            document.Prompt(null);
            if (scode != VectorDraw.Actions.StatusCode.Success) return;

            EPT = aFig.Value as gPoint;

            VectorDrawArrowLine line = new VectorDrawArrowLine();
            document.ActionLayout.Entities.AddItem(line);
            document.UndoHistory.PushEnable(false);
            line.InitializeProperties();
            line.setDocumentDefaults();
            line.StartPoint = SPT;
            line.EndPoint = EPT;
            line.Transformby(document.User2WorldMatrix);
            document.UndoHistory.PopEnable();
            document.ActionDrawFigure(line);
        }
    }

}
