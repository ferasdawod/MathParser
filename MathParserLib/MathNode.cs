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
    }
}
