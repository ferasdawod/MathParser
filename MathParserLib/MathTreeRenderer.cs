using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MathParser
{
    public static class MathTreeRenderer
    {
        public static bool FillNode { get; set; }
        public static int NodeShapeWidth { get; set; }

        public static Color NodeColor { get; set; }
        public static Color TextColor { get; set; }

        public static int NodeImageWidth { get; set; }
        public static int NodeImageHeight { get; set; }


        private static Pen nodePen;
        private static Pen nodeArrowsPen;
        private static Font nodeFont;

        static MathTreeRenderer()
        {
            FillNode = true;
            NodeShapeWidth = 3;
            NodeColor = Color.Gray;
            TextColor = Color.White;

            NodeImageWidth = 65;
            NodeImageHeight = 40;

            nodePen = new Pen(NodeColor, NodeShapeWidth);
            nodeArrowsPen = new Pen(Brushes.Black, 2.5f)
            {
                EndCap = LineCap.ArrowAnchor,
                StartCap = LineCap.Round
            };
            nodeFont = new Font("Tahoma", 10);
        }

        public static Image RenderTree(MathTree tree)
        {
            if (tree.Root == null || tree.Initialized == false)
                return null;

            return RenderNode(tree.Root);
        }

        public static Image RenderNode(MathNode node)
        {
            int tmp;
            return RenderNode(node, out tmp);
        }

        private static Image RenderNode(MathNode node, out int nodeCenter)
        {
            int leftCenter = 0;
            int rightCenter = 0;

            Image leftImage = null;
            Image rightImage = null;

            if (node.LeftChild != null)
                leftImage = RenderNode(node.LeftChild, out leftCenter);
            if (node.RightChild != null)
                rightImage = RenderNode(node.RightChild, out rightCenter);

            Bitmap myNodeImage = new Bitmap(NodeImageWidth, NodeImageHeight);
            Graphics myNodeGraphics = Graphics.FromImage(myNodeImage);
            myNodeGraphics.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle myNodeRect = new Rectangle(0, 0, NodeImageWidth - 1, NodeImageHeight - 1);

            if (FillNode)
                myNodeGraphics.FillEllipse(new SolidBrush(NodeColor), myNodeRect);
            else
                myNodeGraphics.DrawEllipse(nodePen, myNodeRect);


            Size leftSize = new Size();
            if (leftImage != null)
                leftSize = leftImage.Size;

            Size rightSize = new Size();
            if (rightImage != null)
                rightSize = rightImage.Size;

            bool hasChildNodes = (leftImage != null) || (rightImage != null);

            int maxHeight = (leftSize.Height > rightSize.Height) ? leftSize.Height : rightSize.Height;

            var resSize = new Size
            {
                Width = myNodeImage.Size.Width + leftSize.Width + rightSize.Width,
                Height = myNodeImage.Size.Height + (hasChildNodes ? maxHeight + myNodeImage.Size.Height : 0)
            };

            Bitmap result = new Bitmap(resSize.Width, resSize.Height);
            myNodeGraphics = Graphics.FromImage(result);
            myNodeGraphics.SmoothingMode = SmoothingMode.HighQuality;

            // image background color
            // myNodeGraphics.FillRectangle(Brushes.Red, new Rectangle(new Point(0, 0), resSize));

            myNodeGraphics.DrawImage(myNodeImage, leftSize.Width, 0);
            string value = node.NodeType == MathNodeType.Value ? node.Value.ToString("0.00") : node.Operation.ToString();
            myNodeGraphics.DrawString(value, nodeFont, new SolidBrush(TextColor),
                GetCenterX(value, leftSize.Width, leftSize.Width + myNodeImage.Width, myNodeGraphics, nodeFont),
                myNodeImage.Height / 2f - nodeFont.Size);

            nodeCenter = leftSize.Width + myNodeImage.Width / 2;

            float x1 = nodeCenter;
            float y1 = myNodeImage.Height;

            float y2 = myNodeImage.Height * 2;
            float x2 = leftCenter;

            var h = Math.Abs(y2 - y1);
            var w = Math.Abs(x2 - x1);

            if (leftImage != null)
            {
                myNodeGraphics.DrawImage(leftImage, 0, myNodeImage.Size.Height * 2);
                var points1 = new List<PointF>
                    {
                        new PointF(x1, y1),
                        new PointF(x1 - w/6, y1 + h/3.5f),
                        new PointF(x2 + w/6, y2 - h/3.5f),
                        new PointF(x2, y2),
                    };
                myNodeGraphics.DrawCurve(nodeArrowsPen, points1.ToArray(), 0.5f);
            }
            if (rightImage != null)
            {
                myNodeGraphics.DrawImage(rightImage, leftSize.Width + myNodeImage.Size.Width, myNodeImage.Size.Height * 2);
                x2 = rightCenter + leftSize.Width + myNodeImage.Width;
                w = Math.Abs(x2 - x1);
                var points = new List<PointF>
                    {
                        new PointF(x1, y1),
                        new PointF(x1 + w/6, y1 + h/3.5f),
                        new PointF(x2 - w/6, y2 - h/3.5f),
                        new PointF(x2, y2)
                    };
                myNodeGraphics.DrawCurve(nodeArrowsPen, points.ToArray(), 0.5f);
            }
            return result;
        }

        private static int GetCenterX(string text, int startX, int endX, Graphics g, Font font)
        {
            SizeF textSize = g.MeasureString(text, font);

            float center = startX + (endX - startX) / 2;
            return (int)(center - textSize.Width / 2);
        }
    }
}
