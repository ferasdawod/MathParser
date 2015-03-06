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
        public bool Evaluated { get; set; }


        // these helper are here so if we want them we wont have to recalculate them
        public string OptimizedExpression { get; set; }
        public List<string> ExtractedTokens { get; set; }
        public List<string> PostfixTokens { get; set; }

        private double _answer = 0.0d;

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
            if (Evaluated)
            {
                return _answer;
            }
            else
            {
                _answer = Root.Evaluate();
                Evaluated = true;
                return _answer;
            }
        }

        public bool BuildFromInfix(string infixExpression)
        {
            try
            {
                Initialized = false;

                // first prepare the infix string by extracting all the math tokens in it
                OptimizedExpression = MathHelper.OptimizeExpression(infixExpression);
                ExtractedTokens = MathHelper.ExtractMathTokens(OptimizedExpression);
                if (ExtractedTokens.Count == 0)
                {
                    LastError = "Failed to build the tree, Failed to extract math tokens, " + MathHelper.LastError;
                    return false;
                }

                // then we covert those tokens to postfix form
                PostfixTokens = MathHelper.ConvertToPostfix(ExtractedTokens);
                if (PostfixTokens.Count == 0)
                {
                    LastError = "Failed to build the tree, Failed to convert to postfix, " + MathHelper.LastError;
                    return false;
                }

                // we use a stack to build the expression tree
                Stack<MathNode> nodeStack = new Stack<MathNode>();

                for (int i = 0; i < PostfixTokens.Count; i++)
                {
                    string currentToken = PostfixTokens[i];

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
                if (nodeStack.Count > 1)
                {
                    LastError = "Failed to create the math tree, most likely you have a math or syntac error.\n Check your input and try again !";
                    return false;
                }

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
