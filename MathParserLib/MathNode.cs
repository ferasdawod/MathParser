using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace MathParser
{
    public enum MathOperation
    {
        Add,
        Substract,
        Multiplay,
        Divide,
        Log10,
        Log,
        Sqrt,
        Power,
        Sin,
        Cos,
        ASin,
        ACos,
        Sinh,
        Cosh,
        Tan,
        ATan,
        Abs,
        None,
    }

    public enum MathNodeType
    {
        Value,
        Operation,
        None,
    }

    public class MathNode
    {
        public double Value { get; set; }

        public MathNode RightChild { get; set; }

        public MathNode LeftChild { get; set; }

        public MathOperation Operation { get; set; }

        public MathNodeType NodeType { get; set; }

        #region Constructors

        public MathNode()
        {
            Value = 0.0d;
            Operation = MathOperation.None;
            NodeType = MathNodeType.None;

            LeftChild = RightChild = null;
        }

        public MathNode(double value)
        {
            Value = value;
            Operation = MathOperation.None;
            NodeType = MathNodeType.Value;

            LeftChild = RightChild = null;
        }

        public MathNode(MathOperation operation)
            : this(operation, null, null)
        {
        }

        public MathNode(MathOperation operation, MathNode leftChild, MathNode rightChild)
        {
            Value = 0.0d;
            Operation = operation;
            NodeType = MathNodeType.Operation;

            LeftChild = leftChild;
            RightChild = rightChild;
        }

        #endregion

        /// <summary>
        /// Evaluates the node value
        /// </summary>
        /// <returns></returns>
        public double Evaluate()
        {
            return Evaluate(this);
        }

        private double Evaluate(MathNode node)
        {
            if (node == null || node.NodeType == MathNodeType.None) return 0.0d;
            if (node.NodeType == MathNodeType.Value) return node.Value;

            double leftSide = Evaluate(node.LeftChild);
            double rightSide = Evaluate(node.RightChild);

            return MathHelper.Evaluate(node.Operation, leftSide, rightSide);
        }

        public Bitmap RenderToImage()
        {
            int tmp;
            return RenderToImage(this, out tmp);
        }

        private Bitmap RenderToImage(MathNode node, out int center)
        {
            var lCenter = 0;
            var rCenter = 0;

            Image lImg = null, rImg = null;
            if (node.LeftChild != null)
                lImg = RenderToImage(node.LeftChild, out lCenter);
            if (node.RightChild != null)
                rImg = RenderToImage(node.RightChild, out rCenter);

            var meNodeImage = new Bitmap(80, 80);
            var meGraphics = Graphics.FromImage(meNodeImage);
            meGraphics.SmoothingMode = SmoothingMode.HighQuality;
            var meRect = new Rectangle(0, 0, meNodeImage.Width - 1, meNodeImage.Height - 1);

            // node background color
            //meGraphics.FillRectangle(Brushes.Red, meRect);

            // node shape
            //meGraphics.FillEllipse(new LinearGradientBrush(new Point(0, 0), new Point(meNodeImage.Width, meNodeImage.Height), Color.Gold, Color.Black), meRect);
            meGraphics.DrawEllipse(new Pen(Color.Gray, 3),
                new Rectangle(meRect.X + 2, meRect.Y + 2,
                    meRect.Width - 4, meRect.Height - 4));

            var lSize = new Size();
            var rSize = new Size();
            var under = (lImg != null) || (rImg != null);
            if (lImg != null)
                lSize = lImg.Size;
            if (rImg != null)
                rSize = rImg.Size;

            var maxHeight = lSize.Height;
            if (maxHeight < rSize.Height)
                maxHeight = rSize.Height;

            var resSize = new Size
            {
                Width = meNodeImage.Size.Width + lSize.Width + rSize.Width,
                Height = meNodeImage.Size.Height + (under ? maxHeight + meNodeImage.Size.Height : 0)
            };

            var result = new Bitmap(resSize.Width, resSize.Height);
            meGraphics = Graphics.FromImage(result);
            meGraphics.SmoothingMode = SmoothingMode.HighQuality;

            // image background color
            //g.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), resSize));

            meGraphics.DrawImage(meNodeImage, lSize.Width, 0);
            string value = node.NodeType == MathNodeType.Value ? node.Value.ToString() : node.Operation.ToString();
            meGraphics.DrawString(value, new Font("Tahoma", 14), Brushes.Black, lSize.Width + 5, meNodeImage.Height / 2f - 12);

            center = lSize.Width + meNodeImage.Width / 2;
            var pen = new Pen(Brushes.Black, 2.5f)
            {
                EndCap = LineCap.ArrowAnchor,
                StartCap = LineCap.Round
            };

            float x1 = center;
            float y1 = meNodeImage.Height;
            float y2 = meNodeImage.Height * 2;
            float x2 = lCenter;
            var h = Math.Abs(y2 - y1);
            var w = Math.Abs(x2 - x1);
            if (lImg != null)
            {
                meGraphics.DrawImage(lImg, 0, meNodeImage.Size.Height * 2);
                var points1 = new List<PointF>
                    {
                        new PointF(x1, y1),
                        new PointF(x1 - w/6, y1 + h/3.5f),
                        new PointF(x2 + w/6, y2 - h/3.5f),
                        new PointF(x2, y2),
                    };
                meGraphics.DrawCurve(pen, points1.ToArray(), 0.5f);
            }
            if (rImg != null)
            {
                meGraphics.DrawImage(rImg, lSize.Width + meNodeImage.Size.Width, meNodeImage.Size.Height * 2);
                x2 = rCenter + lSize.Width + meNodeImage.Width;
                w = Math.Abs(x2 - x1);
                var points = new List<PointF>
                    {
                        new PointF(x1, y1),
                        new PointF(x1 + w/6, y1 + h/3.5f),
                        new PointF(x2 - w/6, y2 - h/3.5f),
                        new PointF(x2, y2)
                    };
                meGraphics.DrawCurve(pen, points.ToArray(), 0.5f);
            }
            return result;
        }

        public override string ToString()
        {
            switch (NodeType)
            {
                case MathNodeType.Value:
                    return string.Format("Node Type = Value, Value = {0}", Value.ToString());
                    break;
                case MathNodeType.Operation:
                    return string.Format("Node Type = Operation, Operation = {0}", Operation.ToString());
                    break;
                case MathNodeType.None:
                    return string.Format("Node Type = None");
                    break;
                default:
                    return base.ToString();
                    break;
            }
        }
    }
}
