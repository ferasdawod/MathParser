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
        // whether we should fill the node or not
        public static bool FillNode { get; set; }

        // the width of the node shape if we are not filling it
        public static int NodeShapeWidth { get; set; }

        // the node back color
        public static Color NodeColor { get; set; }

        // the text color
        public static Color TextColor { get; set; }

        // the width of the node shape
        public static int NodeImageWidth { get; set; }

        // the height of the node shape
        public static int NodeImageHeight { get; set; }

        // the pen used to draw the node
        private static Pen nodePen;
        // the pen used to draw the arrows connecting the nodes
        private static Pen nodeArrowsPen;
        // the font use when writing text
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
            // the center of the left child node
            int leftCenter = 0;
            // the center of the right child node
            int rightCenter = 0;

            // images of the left and right children
            Image leftImage = null;
            Image rightImage = null;

            // only draw them if they are not null
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


            Size leftSize = (leftImage != null) ? leftImage.Size : new Size();
            Size rightSize = (rightImage != null) ? rightImage.Size : new Size();

            bool hasChildNodes = (leftImage != null) || (rightImage != null);

            int maxHeight = (leftSize.Height > rightSize.Height) ? leftSize.Height : rightSize.Height;

            var finalSize = new Size
            {
                Width = myNodeImage.Size.Width + leftSize.Width + rightSize.Width,
                Height = myNodeImage.Size.Height + (hasChildNodes ? maxHeight + myNodeImage.Size.Height : 0)
            };

            Bitmap result = new Bitmap(finalSize.Width, finalSize.Height);
            myNodeGraphics = Graphics.FromImage(result);
            myNodeGraphics.SmoothingMode = SmoothingMode.HighQuality;

            // image background color
            // myNodeGraphics.FillRectangle(Brushes.Red, new Rectangle(new Point(0, 0), resSize));

            myNodeGraphics.DrawImage(myNodeImage, leftSize.Width, 0);

            string value = node.NodeType == MathNodeType.Value ? node.Value.ToString("0.00") : node.Operation.ToString();

            // draw the text and center it inside the node
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

                // the points used to draw the arrow
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
