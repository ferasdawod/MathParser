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

        public bool BuildFromInfix(string infixExpression)
        {
            try
            {
                Initialized = false;

                // first prepare the infix string by extracting all the math tokens in it
                List<string> mathTokens = MathHelper.ExtractMathTokens(infixExpression);
                if (mathTokens.Count == 0)
                {
                    LastError = "Failed to build the tree, Failed to extract math tokens, " + MathHelper.LastError;
                    return false;
                }

                // then we covert those tokens to postfix form
                List<string> postfixTokens = MathHelper.ConvertToPostfix(mathTokens);
                if (postfixTokens.Count == 0)
                {
                    LastError = "Failed to build the tree, Failed to convert to postfix, " + MathHelper.LastError;
                    return false;
                }

                // we use a stack to build the expression tree
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
                // if everything is ok this should never be called
                System.Diagnostics.Debug.Assert(nodeStack.Count == 1, "the stack has more than one node");

                // the root is the one remaining node in the stack
                Root = nodeStack.Pop();

                // setting the flags
                LastError = "";
                Initialized = true;

                return true;
            }
            catch (Exception ex)
            {
                LastError = "Failed to create the math tree, please make sure that your expression is correct and try again";

                Initialized = false;
                return false;
            }
        }
    }
}
