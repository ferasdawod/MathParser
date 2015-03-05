using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathParser
{
    public static class MathHelper
    {
        private static Dictionary<string, int> operationsPrioritys;

        public static List<string> ValidOperaions { get { return operationsPrioritys.Keys.ToList(); } }

        public static string LastError { get; private set; }
        public static bool UsingRadians { get; set; }

        static MathHelper()
        {
            LastError = "";
            UsingRadians = false;

            operationsPrioritys = new Dictionary<string, int>();

            operationsPrioritys.Add("+", 1);
            operationsPrioritys.Add("-", 1);

            operationsPrioritys.Add("*", 2);
            operationsPrioritys.Add("/", 2);

            operationsPrioritys.Add("log", 3);
            operationsPrioritys.Add("ln", 3);

            operationsPrioritys.Add("sqrt", 3);

            operationsPrioritys.Add("sin", 3);
            operationsPrioritys.Add("sinh", 3);
            operationsPrioritys.Add("asin", 3);

            operationsPrioritys.Add("cos", 3);
            operationsPrioritys.Add("cosh", 3);
            operationsPrioritys.Add("acos", 3);

            operationsPrioritys.Add("tan", 3);
            operationsPrioritys.Add("atan", 3);

            operationsPrioritys.Add("abs", 3);

            operationsPrioritys.Add("^", 4);
            operationsPrioritys.Add("pow", 4);

            operationsPrioritys.Add("(", 0);
            operationsPrioritys.Add(")", 0);
        }

        public static double Evaluate(MathOperation operation, double leftSide, double rightSide)
        {
            double answer = 0d;

            switch (operation)
            {
                case MathOperation.Add:
                    answer = leftSide + rightSide;
                    break;
                case MathOperation.Substract:
                    answer = leftSide - rightSide;
                    break;
                case MathOperation.Multiplay:
                    answer = leftSide * rightSide;
                    break;
                case MathOperation.Divide:
                    answer = leftSide / rightSide;
                    break;
                case MathOperation.Log10:
                    answer = Math.Log10(leftSide);
                    break;
                case MathOperation.Log:
                    answer = Math.Log(leftSide);
                    break;
                case MathOperation.Sqrt:
                    answer = Math.Sqrt(leftSide);
                    break;
                case MathOperation.Power:
                    answer = Math.Pow(leftSide, rightSide);
                    break;
                case MathOperation.Sin:
                    answer = Math.Sin(GetAngleForOperation(leftSide));
                    break;
                case MathOperation.Sinh:
                    answer = Math.Sinh(GetAngleForOperation(leftSide));
                    break;
                case MathOperation.ASin:
                    answer = Math.Asin(leftSide);
                    break;
                case MathOperation.Cos:
                    answer = Math.Cos(GetAngleForOperation(leftSide));
                    break;
                case MathOperation.Cosh:
                    answer = Math.Cosh(GetAngleForOperation(leftSide));
                    break;
                case MathOperation.ACos:
                    answer = Math.Acos(leftSide);
                    break;
                case MathOperation.Tan:
                    answer = Math.Tan(GetAngleForOperation(leftSide));
                    break;
                case MathOperation.ATan:
                    answer = Math.Atan(leftSide);
                    break;
                case MathOperation.Abs:
                    answer = Math.Abs(leftSide);
                    break;
                case MathOperation.None:
                    answer = 0.0D;
                    break;
                default:
                    answer = 0.0D;
                    break;
            }

            if (operation == MathOperation.ATan || operation == MathOperation.ASin || operation == MathOperation.ACos)
                return ConvertToDegrees(answer);
            else
                return answer;
        }

        /// <summary>
        /// this method returns the right angle to use when evaluating the operation based on the using radians flag
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        private static double GetAngleForOperation(double angle)
        {
            if (UsingRadians)
                return angle;
            else
                return ConvertToRadians(angle);
        }

        public static double ConvertToRadians(double angleInDegrees)
        {
            return angleInDegrees * Math.PI / 180.0d;
        }

        public static double ConvertToDegrees(double angleInRadians)
        {
            return angleInRadians * 180.0d / Math.PI;
        }

        /// <summary>
        /// given a infix math expression returns the tokens contained in this expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static List<string> ExtractMathTokens(string expression)
        {
            /*
             * WARNING
             * this method works with magic
             * i will not try commenting it because i fear it will break something in it
             * it works and i know it works
             * if you do try to read it then do so at your own risk
             * YOU HAVE BEEN WARNED !!!!
             */

            List<string> tokens = new List<string>();

            if (expression.Length == 0)
                return tokens;

            expression = OptimizeExpression(expression);

            string tokenSoFar = string.Empty;

            bool waitingForNumber = false;
            bool waitingForOperation = false;

            for (int i = 0; i < expression.Length; i++)
            {
                char currentChar = expression[i];

                if (waitingForNumber)
                {
                    if (IsNumber(currentChar))
                    {
                        tokenSoFar += currentChar;
                    }
                    else
                    {
                        if (IsSingleLetterOperation(currentChar))
                        {
                            tokens.Add(tokenSoFar);
                            tokens.Add(currentChar.ToString());

                            tokenSoFar = string.Empty;

                            waitingForNumber = false;
                            waitingForOperation = false;
                        }
                        else
                        {
                            // the char is not a number so we are done reading the number and we should wait for an operation
                            tokens.Add(tokenSoFar);
                            tokenSoFar = string.Empty;
                            tokenSoFar += currentChar;

                            waitingForNumber = false;
                            waitingForOperation = true;
                        }
                    }
                }
                else if (waitingForOperation)
                {
                    if (IsNumber(currentChar))
                    {
                        // the char is a number so we are done reading the operation and should start reading a number
                        tokens.Add(tokenSoFar);
                        tokenSoFar = string.Empty;
                        tokenSoFar += currentChar;

                        waitingForOperation = false;
                        waitingForNumber = true;
                    }
                    else if (IsSingleLetterOperation(currentChar))
                    {
                        tokens.Add(tokenSoFar);
                        tokens.Add(currentChar.ToString());

                        tokenSoFar = string.Empty;

                        waitingForNumber = false;
                        waitingForOperation = false;
                    }
                    else
                    {
                        tokenSoFar += currentChar;
                    }
                }
                else
                {
                    if (IsNumber(currentChar))
                    {
                        tokenSoFar += currentChar;
                        waitingForNumber = true;
                        waitingForOperation = false;
                    }
                    else if (IsSingleLetterOperation(currentChar))
                    {
                        tokens.Add(currentChar.ToString());
                        tokenSoFar = string.Empty;
                    }
                    else
                    {
                        tokenSoFar += currentChar;
                        waitingForOperation = true;
                        waitingForNumber = false;
                    }
                }
            }


            if (!string.IsNullOrWhiteSpace(tokenSoFar))
            {
                tokens.Add(tokenSoFar);
            }

            PostProcessTokens(tokens);
            return tokens;
        }

        /// <summary>
        /// this method removes spaces and trims the expression to prepare it for token extraction
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static string OptimizeExpression(string expression)
        {
            string optimizedExpression = expression;
            optimizedExpression = optimizedExpression.Trim();
            optimizedExpression = optimizedExpression.Replace(" ", "");
            optimizedExpression = optimizedExpression.ToLower();

            optimizedExpression = optimizedExpression.Replace("pi", Math.PI.ToString());
            optimizedExpression = optimizedExpression.Replace("e", Math.E.ToString());

            return optimizedExpression;
        }

        /// <summary>
        /// this method walks the tokens list and performs post processing like making + and 3 a single +3 token
        /// </summary>
        /// <param name="tokens"></param>
        private static void PostProcessTokens(List<string> tokens)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                string currentToken = tokens[i];

                // we are only interested in the + and - operations right now
                if (string.Equals(currentToken, "+") || string.Equals(currentToken, "-"))
                {
                    // if we are at the beginning of the tokens then we only need to look at the next token
                    if (i == 0)
                    {
                        // make sure we have enough tokens
                        if (i + 1 != tokens.Count)
                        {
                            string nextToken = tokens[i + 1];
                            if (IsNumber(nextToken))
                            {
                                nextToken = currentToken + nextToken;
                                tokens[i + 1] = nextToken;
                                tokens.RemoveAt(i);
                            }
                        }
                    }
                    else
                    {
                        // this is the last token and should be removed
                        if (i + 1 == tokens.Count)
                        {
                            tokens.RemoveAt(i);
                        }
                        else
                        {
                            string prevToken = tokens[i - 1];
                            string nextToken = tokens[i + 1];

                            if (!IsNumber(prevToken) && IsNumber(nextToken) &&
                                (!string.Equals(prevToken, "(") || !string.Equals(prevToken, ")")))
                            {
                                nextToken = currentToken + nextToken;
                                tokens[i + 1] = nextToken;
                                tokens.RemoveAt(i);
                            }
                        }
                    }
                }
            }
        }

        public static bool IsNumber(char c)
        {
            // we count the . as a number, if we dont we will get the . as a separate token
            return char.IsDigit(c) || c == '.';
        }

        /// <summary>
        /// return true if the character is a single letter operation like +, -, *
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsSingleLetterOperation(char c)
        {
            return c == '-' ||
                c == '+' ||
                c == '*' ||
                c == '/' ||
                c == '^' ||
                c == '(' || c == ')';
        }

        public static bool IsNumber(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;

            double tmp;
            if (!double.TryParse(s, out tmp))
            {
                return false;
            }

            return true;
        }

        public static List<string> ConvertToPostfix(string infixString)
        {
            return ConvertToPostfix(ExtractMathTokens(infixString));
        }

        public static List<string> ConvertToPostfix(List<string> infixTokens)
        {
            // if its not a valid tokens then return nothing
            if (!IsValidInfix(infixTokens))
            {
                LastError = "Failed to convert to postfix notation, the provided infix tokens are invalid, " + LastError;
                return new List<string>();
            }

            Stack<string> tokenStack = new Stack<string>();
            List<string> postfixTokens = new List<string>();

            for (int i = 0; i < infixTokens.Count; i++)
            {
                string currentToken = infixTokens[i];

                if (IsNumber(currentToken))
                {
                    postfixTokens.Add(currentToken);
                }
                else if (string.Equals(currentToken, "("))
                {
                    tokenStack.Push(currentToken);
                }
                else if (string.Equals(currentToken, ")"))
                {
                    while (tokenStack.Count > 0 && tokenStack.Peek() != "(")
                    {
                        string token = tokenStack.Pop();
                        postfixTokens.Add(token);
                    }
                    if (tokenStack.Count > 0)
                        tokenStack.Pop();
                }
                else
                {
                    while (tokenStack.Count > 0 && (operationsPrioritys[tokenStack.Peek()] > operationsPrioritys[currentToken] ||
                                           operationsPrioritys[tokenStack.Peek()] == operationsPrioritys[currentToken]))
                    {
                        string topToken = tokenStack.Pop();
                        postfixTokens.Add(topToken);
                    }

                    tokenStack.Push(currentToken);
                }
            }

            while (tokenStack.Count > 0)
                postfixTokens.Add(tokenStack.Pop());

            return postfixTokens;
        }

        public static bool IsValidInfix(string expression)
        {
            return (IsValidInfix(ExtractMathTokens(expression)));
        }

        /// <summary>
        /// return true if there are no wrong operations or a missing bracket and such things
        /// </summary>
        /// <param name="expressionTokens"></param>
        /// <returns></returns>
        public static bool IsValidInfix(List<string> expressionTokens)
        {
            if (expressionTokens.Count == 0)
            {
                LastError = "the infix tokens are empty ";
                return false;
            }

            for (int i = 0; i < expressionTokens.Count; i++)
            {
                string token = expressionTokens[i];

                if (!IsNumber(token))
                {
                    int operationPriority = GetOperationPriority(token);
                    if (operationPriority == -1)
                    {
                        // this is a wrong operation
                        LastError = "we have encountered an unknown operation : " + token;
                        return false;
                    }

                    if (string.Equals(token, "("))
                    {
                        if (!HasMatchingPerenthesis(expressionTokens, i))
                        {
                            LastError = "open bracket at index " + i + " does not have matching closed bracket";
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public static int GetOperationPriority(string operation)
        {
            if (operationsPrioritys.ContainsKey(operation))
                return operationsPrioritys[operation];
            else
                return -1;
        }

        private static bool HasMatchingPerenthesis(List<string> tokenList, int startindex)
        {
            try
            {
                Stack<string> tokenStack = new Stack<string>();
                tokenStack.Push(tokenList[startindex]);

                for (int i = startindex + 1; i < tokenList.Count; i++)
                {
                    string token = tokenList[i];

                    if (string.Equals(token, "("))
                    {
                        tokenStack.Push(token);
                    }
                    else if (string.Equals(token, ")"))
                    {
                        tokenStack.Pop();
                        if (tokenStack.Count == 0)
                            return true;
                    }
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static MathOperation GetOperation(string token)
        {
            if (token.Length == 0)
                return MathOperation.None;

            switch (token)
            {
                case "+":
                    return MathOperation.Add;
                case "-":
                    return MathOperation.Substract;
                case "*":
                    return MathOperation.Multiplay;
                case "/":
                    return MathOperation.Divide;
                case "log":
                    return MathOperation.Log10;
                case "ln":
                    return MathOperation.Log;
                case "sqrt":
                    return MathOperation.Sqrt;
                case "^":
                case "pow":
                    return MathOperation.Power;
                case "sin":
                    return MathOperation.Sin;
                case "sinh":
                    return MathOperation.Sinh;
                case "asin":
                    return MathOperation.ASin;
                case "cos":
                    return MathOperation.Cos;
                case "cosh":
                    return MathOperation.Cosh;
                case "acos":
                    return MathOperation.ACos;
                case "tan":
                    return MathOperation.Tan;
                case "atan":
                    return MathOperation.ATan;
                case "abs":
                    return MathOperation.Abs;
                default:
                    return MathOperation.None;
            }
        }

        public static bool HasOneOperand(MathOperation operation)
        {
            return operation == MathOperation.Sqrt || operation == MathOperation.Abs
                || operation == MathOperation.ACos || operation == MathOperation.ASin
                || operation == MathOperation.ATan || operation == MathOperation.Cos
                || operation == MathOperation.Cosh || operation == MathOperation.Log
                || operation == MathOperation.Log10 || operation == MathOperation.Sin
                || operation == MathOperation.Sinh || operation == MathOperation.Sqrt
                || operation == MathOperation.Tan;
        }
    }
}
