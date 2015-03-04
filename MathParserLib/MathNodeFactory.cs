using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathParser
{
    public static class MathNodeFactory
    {
        public static MathNode CreateNode(string token)
        {
            if (MathHelper.IsNumber(token))
            {
                return new MathNode(double.Parse(token));
            }
            else
            {
                MathOperation operation = MathHelper.GetOperation(token);
                return new MathNode(operation);
            }
        }
    }
}
