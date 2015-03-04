using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MathParser
{
    public class MathTree
    {
        public MathNode Root { get; set; }
        public string LastError { get; private set; }
        public bool Initialized { get; set; }

        #region Constructors

        public MathTree()
        {
            LastError = "";
            Root = null;
            Initialized = false;
        }

        #endregion

        public double Evaluate()
        {
            return Root.Evaluate();
        }

        /// <summary>
        /// parses the given string into a binary tree representing the equivalent math expression
        /// </summary>
        /// <param name="mathExpression">the string representing the math expression</param>
        /// <returns>return true if parsing is successful</returns>
        public bool BuildFromPostfix(string postfixExpression)
        {
            return BuildFromPostfix(MathHelper.ExtractMathTokens(postfixExpression));
        }

        public bool BuildFromPostfix(List<string> postfixTokens)
        {
            try
            {
                Stack<MathNode> nodeStack = new Stack<MathNode>();

                for (int i = 0; i < postfixTokens.Count; i++)
                {
                    string currentToken = postfixTokens[i];

                    MathNode node = MathNodeFactory.CreateNode(currentToken);
                    if (node.NodeType == MathNodeType.Value)
                    {
                        nodeStack.Push(node);
                    }
                    else if (node.NodeType == MathNodeType.Operation)
                    {
                        if (MathHelper.HasOneOperand(node.Operation))
                        {
                            node.LeftChild = nodeStack.Pop();
                            node.RightChild = new MathNode();
                        }
                        else
                        {
                            node.RightChild = nodeStack.Pop();
                            node.LeftChild = nodeStack.Pop();
                        }

                        nodeStack.Push(node);
                    }
                }

                // by the end of the algorithm we should only have one node in the stack
                System.Diagnostics.Debug.Assert(nodeStack.Count == 1, "the stack has more than one node");
                Root = nodeStack.Pop();
                LastError = "";
                Initialized = true;
                return true;
            }
            catch (Exception ex)
            {
                LastError = "Failed to build the tree, error information : " + ex.Message + "\nAdditional Information : " + MathHelper.LastError +
                    "\nStack Trace : \n" + ex.StackTrace;
                Initialized = false;
                return false;
            }
        }

        public Bitmap RenderToImage()
        {
            return Root.RenderToImage();
        }
    }
}
