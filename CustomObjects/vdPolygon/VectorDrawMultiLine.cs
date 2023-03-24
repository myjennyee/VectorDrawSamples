using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
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
using VectorDraw.Generics;

//This custom object also explains how to export and import via xProperties the properties of the object into a dwg file.
//Also check the code to the CustomObjects project at the Form1.cs

namespace VectorDrawCustomFigs
{
    public class VectorDrawOffsetLine : vdPolyline, IvdProxyFigure
    {
        #region ctor
        public VectorDrawOffsetLine()
        {

        }
        public VectorDrawOffsetLine(vdDocument doc)
            : this()
        {
            SetUnRegisterDocument(doc);
            setDocumentDefaults();
        }
        #endregion

        #region private properties
        private vdArray<vdCurves> mOffsetcurves = null;
        private vdColor mLinesColor = null;
        private double mLinesDistance = 0.3;
        private int mNumOfLines = 2;
        #endregion

        #region public properties
        //You should use the AddHistory command in your properties so any change will be writen to the history
        //The string in the AddHistory command is the name of the property exactly and should be called before the property change.
        public int NumOfLines
        {
            get
            {
                return mNumOfLines;
            }
            set
            {
                AddHistory("NumOfLines", value);
                mNumOfLines = value;
            }
        }
        public vdColor LinesColor
        {
            get
            {
                if (mLinesColor == null) mLinesColor = new vdColor(System.Drawing.Color.Red);
                return mLinesColor;
            }
            set
            {
                AddHistory("LinesColor", value);
                if (mLinesColor == null) mLinesColor = new vdColor(System.Drawing.Color.Red);
                mLinesColor.CopyFrom(value);
            }
        }
        public double LinesDistance
        {
            get
            {
                return mLinesDistance;
            }
            set
            {
                AddHistory("LinesDistance", value);
                mLinesDistance = value;
            }
        }
        #endregion

        #region Polyline overrides
        //This code is to hide the Xproperties property of this custom object for the properties list.
        [Browsable(false)]
        public new vdXProperties XProperties { get { return base.XProperties; } } 
    
        [Browsable(false)]
        public override VdConstSplineFlag SPlineFlag
        {//Do not implement the SPline Flag for this object.
            get
            {
                return VdConstSplineFlag.SFlagSTANDARD;
            }
            set
            {
                base.SPlineFlag = VdConstSplineFlag.SFlagSTANDARD;
            }
        }
        public override bool Break(gPoint p1, gPoint p2, out vdFigure newEntity)
        {
            return base.Break(p1, p2, out newEntity);
        }

        public override vdEntities Explode()
        {
            // In order to save this object to a DWG/DXF file and when reopened in this application to maintain and recalculate the custom object we do the following
            // Whatever information you want to preserve to the exported file it must be added as xProperty to the exploded figures , since these entities will be saved.
            // We also Add a string xproperty to all the exported figures in order to identify them while opening the file.
            // The properties of the custom object are added to the first exploded figure.
            // Note that since when openoing the file a new object will be created the Handle of the custom object will not be preserved.
            // The rest of the code is in the void ActiveDocument_OnAfterOpenDocument(object sender) event of the CustomObjects project (Form1.cs).
            
            vdEntities Entities = new vdEntities();
            Entities.SetUnRegisterDocument(Document);
            if (Document != null) Document.UndoHistory.PushEnable(false);

            vdArray<vdCurves> curvesArray = Offsetcurves();
            foreach (vdCurves curves in curvesArray)
            {
                foreach (vdCurve curve in curves)
                {
                    curve.PenColor = mLinesColor;
                    vdXProperty xprop = curve.XProperties.FindName("vdDWGXprop");
                    if (xprop == null)
                    {
                        vdXProperty xprop1 = curve.XProperties.Add("vdDWGXprop");
                        xprop1.PropValue = "vdDWGXprop";
                    }
                    else 
                    {
                        xprop.PropValue = "vdDWGXprop";
                    }
                    Entities.AddItem(curve.Clone(Document) as vdFigure);
                }
            }

            vdEntities BaseEnts = base.Explode();
            foreach (vdFigure  var in BaseEnts)
            {
                vdFigure fig = var.Clone(Document) as vdFigure;
                vdXProperty xprop = fig.XProperties.FindName("vdDWGXprop");
                if (xprop == null)
                {
                    vdXProperty xprop1 = fig.XProperties.Add("vdDWGXprop");
                    xprop1.PropValue = "vdDWGXprop";
                }
                else 
                {
                    xprop.PropValue = "vdDWGXprop";
                }

                Entities.AddItem(fig);
            }

            if (Entities.Count > 0)
            {
                vdFigure fig = Entities[0];
                vdXProperty xprop = fig.XProperties.FindName("NumLines");
                xprop.PropValue = this.NumOfLines;

                xprop = fig.XProperties.FindName("LinesColor");
                xprop.PropValue = this.LinesColor.ToInt32();

                xprop = fig.XProperties.FindName("LinesDistance");
                xprop.PropValue = this.LinesDistance;

                xprop = fig.XProperties.FindName("PenColor");
                xprop.PropValue = this.PenColor.ToInt32();

                xprop = fig.XProperties.Add("NumberOfExplodedEntities");
                xprop.PropValue = 7;

                vdEntities ents = this.Owner as vdEntities;
                if (ents != null)
                {
                    xprop = fig.XProperties.Add("vdRealPosition");
                    int  pos = ents.GetObjectRealPosition(this);
                    xprop.PropValue = pos;
                }
            }


            if (Document != null) Document.UndoHistory.PopEnable();
            return Entities;
        }
        public override void Update()
        {
            base.Update();
            mOffsetcurves = null;
        }
        private vdArray<vdCurves> Offsetcurves()
        {
            if (mOffsetcurves != null) return mOffsetcurves;
            Vector V = null;
            Matrix matt = new Matrix();
            vdPolyline tmppl = this.Clone(Document) as vdPolyline;
            if (this.VertexList.Count > 2)
            {
                V = tmppl.VertexList.GetNormal();
                matt = new Matrix();
                if (V != null)
                {
                    matt.ApplyWCS2ECS(V);
                    tmppl.Transformby(matt);
                }
            }
            mOffsetcurves = new vdArray<vdCurves>();
            for (int i = 0; i < mNumOfLines; i++)
            {
                vdCurves curves = tmppl.getOffsetCurve(mLinesDistance * (i + 1));
                if (curves != null && curves.Count > 0 && mOffsetcurves != null)
                {
                    //foreach (vdCurve var in curves) var.Transformby(matt.GetInvertion());
                    mOffsetcurves.AddItem(curves);
                }
            }
            return mOffsetcurves;
        }
        protected override void OnDocumentSelected(vdDocument document)
        {
            LinesColor.SetUnRegisterDocument(document);

            if (this.XProperties.Count == 0)
            {
                this.XProperties.Add("vdDWGXprop");
                vdXProperty xprop = this.XProperties.Add("NumLines");
                xprop.PropValue = this.NumOfLines;

                xprop = this.XProperties.Add("LinesColor");
                xprop.PropValue = this.LinesColor.ToInt32();

                xprop = this.XProperties.Add("LinesDistance");
                xprop.PropValue = this.LinesDistance;

                xprop = this.XProperties.Add("PenColor");
                xprop.PropValue = this.PenColor.ToInt32();
            }
        }
        public override void InitializeProperties()
        {
            base.InitializeProperties();
            mLinesColor = new vdColor();
            mLinesColor.SetUnRegisterDocument(this.Document);
            mLinesColor.SystemColor = System.Drawing.Color.Red;
            mLinesDistance = 0.3;
            mNumOfLines = 2;


            
        }

        //Note that not all values/objects can be saved/serialize by VDF, and you need to write code for such properties in serialize/deserialize override of this object. 
        //You can set value of custom property to any of the following type values: 
        //     String, Double, Int32, Boolean, Byte, Int16, Int64, UInt16, UInt64, UInt32, Single, ushort, System.Color, VectorDraw.Serialize.IVDHandle and IVDSerialise
        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(mLinesColor, "LinesColor");
            serializer.Serialize(mLinesDistance, "LinesDistance");
            serializer.Serialize(mNumOfLines, "NumOfLines");
        }
        public override bool DeSerialize(DeSerializer deserializer, string fieldname, object value)
        {
            if (base.DeSerialize(deserializer, fieldname, value)) return true;
            else if (fieldname == "LinesColor") mLinesColor = (vdColor)value;
            else if (fieldname == "LinesDistance") mLinesDistance = (double)value;
            else if (fieldname == "NumOfLines") mNumOfLines = (int)value;

            else return false;
            return true;
        }
        public override void MatchProperties(vdPrimary _from, vdDocument thisdocument)
        {
            base.MatchProperties(_from, thisdocument);
            VectorDrawOffsetLine from = _from as VectorDrawOffsetLine;
            if (from == null) return;
            mLinesColor = new vdColor();
            mLinesColor.CopyFrom(from.LinesColor);
            mLinesDistance = from.LinesDistance;
            mNumOfLines = from.NumOfLines;
        }
        public override vdRender.DrawStatus Draw(vdRender render)
        {
            if (ListStart(render)) return render.StatusDraw;
            vdRender.DrawStatus doDraw = base.Draw(render);
            if (doDraw == vdRender.DrawStatus.Successed)
            {
                render.PushDrawFigureList(this);

                vdGdiPenStyle style = new vdGdiPenStyle();
                style.CopyFrom(render.PenStyle);
                style.color = mLinesColor.SystemColor;
                render.PushPenstyle(style);

                vdArray<vdCurves> curvesArray = Offsetcurves();
                if (curvesArray == null) return vdRender.DrawStatus.Successed;
                foreach (vdCurves curves in curvesArray)
                {
                    foreach (vdCurve curve in curves)
                    {
                        gPoints pts = curve.GetSamplePoints(0, 0);
                        ECSMatrix.Transform(pts);
                        if (pts.Count > 0) render.DrawPLine(this, pts,base.Thickness);
                    }
                }
                render.PopPenstyle();

                render.PopDrawFigureList();
            }
            if (ListEnd(render)) doDraw = render.StatusDraw;
            return doDraw;
        }
        public override Box BoundingBox
        {
            get
            {
                if (!mBoundBox.IsEmpty) return mBoundBox;
                mBoundBox = new Box();
                foreach (Vertex var in this.VertexList)
                {
                    gPoint pt = var as gPoint;
                    mBoundBox.AddPoint(pt);
                }
                //Make the last offset commited and include the result to the bounding box.
                vdArray<vdCurves> curvesArray = Offsetcurves();
                if (curvesArray == null) return mBoundBox;
                foreach (vdCurves curves in curvesArray)
                {
                    foreach (vdCurve curve in curves)
                    {
                        gPoints pts = curve.GetSamplePoints(0, 0);
                        if (pts.Count > 0) mBoundBox.AddPoints(pts);
                    }
                }

                return mBoundBox;
            }
        }
        public override bool IsTableObjectDependOn(vdPrimary table)
        {
            if (Deleted) return false;//always check if this object is deleted
            if (base.IsTableObjectDependOn(table)) return true;//always check the base implamentation
            //check properties of object that reference the table object.
            if (LinesColor != null && LinesColor.IsTableObjectDependOn(table)) return true;
            return false;
        }
        public override void GetTableDependecies(vdTableDependeciesArgs args)
        {
            base.GetTableDependecies(args);
            if (args.IsObjectFound) return;
            if (Deleted) return;

            if (LinesColor != null) LinesColor.GetTableDependecies(args);
        }
        #endregion

        #region Command
        public static void CmdOffsetLine(vdDocument document)
        {
            gPoint SPT;
            document.Prompt("First Point:");
            object ret = document.ActionUtility.getUserPoint();
            document.Prompt(null);
            if (ret == null || !(ret is gPoint)) return;
            SPT = ret as gPoint;
            Vertexes vertexes = new Vertexes();
            vertexes.Add(SPT);
            StatusCode code = StatusCode.Success;
            while (code == StatusCode.Success)
            {
                document.Prompt("Next Point:");
                ActionOffsetLine aFig = new ActionOffsetLine(vertexes, document.ActiveLayOut);
                document.ActionAdd(aFig);
                code = aFig.WaitToFinish();

                document.Prompt(null);
                if (code == StatusCode.Success)
                {
                    vertexes =new Vertexes (((VectorDrawOffsetLine)aFig.Entity).VertexList);
                }
            }
            VectorDrawOffsetLine line = new VectorDrawOffsetLine();
            document.UndoHistory.PushEnable(false);
            line.SetUnRegisterDocument(document);
            line.InitializeProperties();
            line.setDocumentDefaults();
            vertexes.RemoveEqualPoints();
            line.VertexList = vertexes;
            line.Transformby(document.User2WorldMatrix);
            document.UndoHistory.PopEnable();
            document.ActionLayout.Entities.AddItem(line);
            document.ActionDrawFigure(line);
        }
        #endregion
    }

    public class ActionOffsetLine : ActionEntity
    {
        private VectorDrawOffsetLine mline;
        public ActionOffsetLine(Vertexes vertexes, vdLayout layout)
            : base(layout.Document.User2WorldMatrix.Transform(vertexes.Last()), layout)
        {
            mline = new VectorDrawOffsetLine();
            mline.SetUnRegisterDocument(layout.Document);
            mline.InitializeProperties();
            mline.setDocumentDefaults();
            vertexes.Add(vertexes.Last());
            mline.VertexList = vertexes;
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
                return mline;
            }
        }
        protected override void OnMyPositionChanged(gPoint newPosition)
        {
            mline.VertexList.Last().CopyFrom(newPosition);
        }
        public override bool needUpdate
        {
            get
            {
                return true;
            }
        }
        

    }

}
