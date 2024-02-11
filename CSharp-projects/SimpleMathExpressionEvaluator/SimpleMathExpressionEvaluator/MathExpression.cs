using SimpleMathExpressionEvaluator.SimpleMathExpressionEvaluator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMathExpressionEvaluator
{
    public class MathExpression
    {
        public double LeftsideOperand { set; get; }
        public double RightsideOperand { set; get;}
        public enMathOperation Operation { set; get; }

    }
}
