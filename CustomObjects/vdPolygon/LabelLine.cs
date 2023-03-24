using VectorDraw.Geometry;
using VectorDraw.Professional.Actions;
using VectorDraw.Professional.vdCollections;
using VectorDraw.Professional.vdFigures;
using VectorDraw.Professional.vdObjects;
using VectorDraw.Professional.vdPrimaries;
using VectorDraw.Render;
using VectorDraw.Serialize;

namespace VectorDrawCustomFigs
{
    public class LabelLine : vdLine, IvdProxyFigure
    {
        //a text label always in the center of the line on the left side
        vdText mTextLabel = null;
        
        public LabelLine()
        {

        }
        public LabelLine(vdDocument doc) :base(doc)
        {

        }
        public vdText TextLabel
        {
            get { return mTextLabel; }
            set
            {
                if (object.ReferenceEquals(mTextLabel,value)) return;
                AddHistory("TextLabel", value);
                if (value == null) mTextLabel = null;
                else mTextLabel = value.Clone(null) as vdText;
            }
        }
        public override vdEntities Explode()
        {
            vdEntities Entities = new vdEntities();
            Entities.SetUnRegisterDocument(Document);
            vdLine l = new vdLine();
            l.MatchProperties(this, Document);
            Entities.AddItem(l);
            Entities.AddItem(TextLabel.Clone(Document));
            return Entities;
        }
        
        public override void MatchProperties(vdPrimary _from, vdDocument thisdocument)
        {
            base.MatchProperties(_from, thisdocument);
            if (this == _from) return;
            base.MatchProperties(_from, thisdocument);
            LabelLine from = _from as LabelLine;
            if (from == null) return;
            TextLabel = from.TextLabel;
        }
        
        public override void Serialize(Serializer serializer)
        {
            base.Serialize(serializer);
            serializer.Serialize(TextLabel, "TextLabel");
        }
        public override bool DeSerialize(DeSerializer deserializer, string fieldname, object value)
        {
            if (base.DeSerialize(deserializer, fieldname, value)) return true;
            else if (fieldname == "TextLabel") mTextLabel = (vdText)value;
            else return false;
            return true;
        }

        public override void Update()
        {
            base.Update();
            if (TextLabel != null)
            {
                SetTextLabelPosition();
                TextLabel.Update();
            }
        }

        /// <summary>
        /// Set the TextLabel position so  always in the center of the line on the left side
        /// </summary>
        void SetTextLabelPosition()
        {
            if (TextLabel == null) return;
            gPoint pos = gPoint.MidPoint(StartPoint, EndPoint);
            double lineangle = StartPoint.GetAngle(EndPoint);
            pos = gPoint.Polar(pos, lineangle + Globals.HALF_PI, TextLabel.Height * 0.2);//set the insertion point of the TextLabel offset
            TextLabel.InsertionPoint = pos;
            TextLabel.Rotation = lineangle;
            TextLabel.VerJustify = VectorDraw.Professional.Constants.VdConstVerJust.VdTextVerBottom;
            TextLabel.HorJustify = VectorDraw.Professional.Constants.VdConstHorJust.VdTextHorCenter;
            TextLabel.Update();
        }
        public override Box BoundingBox
        {
            get
            {
                if (mBoundBox.IsEmpty)
                {
                    mBoundBox = base.BoundingBox;
                    if (TextLabel != null)
                    {
                        SetTextLabelPosition();
                        mBoundBox.AddBox(TextLabel.BoundingBox);
                    }
                }
                return mBoundBox;
            }
        }
        public override vdRender.DrawStatus Draw(vdRender render)
        {
            lock (this)
            {
                vdRender.DrawStatus doDraw = base.Draw(render);
                if (TextLabel != null && doDraw == vdRender.DrawStatus.Successed) TextLabel.Draw(render);
                return doDraw;
            }
        }

    }

    /// <summary>
    /// A class that manage a user action to draw a new LabelLine object
    /// </summary>
    public class ActionLabelLine : ActionEntity
    {
        /// <summary>
        /// prompts the user for a Label and 2 points of line and add a new LabelLine to document
        /// </summary>
        public static void UserCommandExecute(vdDocument doc)
        {
            doc.Prompt("Label Text");
            string label = doc.ActionUtility.getUserString();
            doc.Prompt(null);
            doc.Prompt("Start Point");
            object opt = doc.ActionUtility.getUserPoint();
            doc.Prompt(null);
            gPoint spt = opt as gPoint;
            if (spt == null) return;

            doc.Prompt("End Point");
            ActionLabelLine aFig = new ActionLabelLine(spt, label, doc.ActiveLayOut);
            object userget = doc.ActionUtility.getUserActionEntity(aFig);
            doc.Prompt(null);
            if (userget != null)
            {
                doc.ActionLayout.Entities.AddItem(aFig.Entity);
                doc.ActionDrawFigure(aFig.Entity);
            }
        }
        private LabelLine line;
        /// <summary>
        /// Initializes the object with the given paramaters.
        /// </summary>
        /// <param name="reference">Start point of the line.</param>
        /// <param name="layout">The vdLayout object where the action takes place.</param>
        public ActionLabelLine(gPoint reference, string label, vdLayout layout)
            : base(reference, layout)
        {
            line = new LabelLine(layout.Document);
            line.StartPoint = reference;
            line.EndPoint = reference;
            vdText txt = new vdText(layout.Document, label, new gPoint(), 0.0);//use the default vdDocument.ActiveTextStyle.Height
            line.TextLabel = txt;
        }
        /// <summary>
        /// the reference point of the action in World Coordinate System.
        /// </summary>
        public override gPoint ReferencePoint
        {
            get
            {
                return base.ReferencePoint;
            }
            set
            {
                base.ReferencePoint = value;
                if (ReferencePoint != null && this.Entity != null && Layout != null)
                {
                    line.StartPoint = Layout.Document.World2UserMatrix.Transform(ReferencePoint);
                }
            }
        }
        /// <summary>
        /// Get a value that represents if the rubber line is drawn or not.Returns true since a rubber line is not needed.
        /// </summary>
        public override bool HideRubberLine
        {
            get
            {
                return true;
            }
        }
        /// <summary>
        /// The entity which is currently selected for this action.Returns the created line.
        /// </summary>
        public override vdFigure Entity
        {
            get
            {
                return line;
            }
        }
        /// <summary>
        /// Called when the mouse position changes.Changes the end point of the created line entity to be drawn each time the mouse moves..
        /// </summary>
        /// <param name="newPosition">A gPoint representing the new mouse position in User Coordinate System.</param>
        protected override void OnMyPositionChanged(gPoint newPosition)
        {
            line.EndPoint = newPosition;
        }
        /// <summary>
        /// Get a value that represents if the entity should be updated after each position change.Returns true since an update is needed.
        /// </summary>
        public override bool needUpdate
        {
            get
            {
                return true;
            }
        }
    }
}
