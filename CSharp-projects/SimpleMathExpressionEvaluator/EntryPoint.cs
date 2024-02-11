using SimpleMathExpressionEvaluator.SimpleMathExpressionEvaluator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleMathExpressionEvaluator
{
    internal class EntryPoint
    {
        static void Main(string[] args)
        {

          while (true)
            {
                Console.Write("please enter a math expression: ");
                var input = Console.ReadLine();
                var expression = ExpressionParser.Parse(input);
                Console.Write($"{OptimizeString(input)} = {EvaluateExpression(expression)}");
                Console.WriteLine("\n-----------------------------------------------------------\n\n");
            }
              }

        static string OptimizeString(string input)
        {
            // Use regex to replace multiple spaces with a single space
            input = Regex.Replace(input, @"\s+", " ");//We use Regex.Replace to replace multiple consecutive space characters with a single space.
            return input.Trim(); // Trim leading and trailing spaces
        }
             
        private static double EvaluateExpression(MathExpression expression)
        {
            switch (expression.Operation) {
                case enMathOperation.Additonn:
                    return expression.LeftsideOperand + expression.RightsideOperand;

                case enMathOperation.Subtraction:
                    return expression.LeftsideOperand - expression.RightsideOperand;

                case enMathOperation.Multiplication:
                    return expression.LeftsideOperand * expression.RightsideOperand;

                case enMathOperation.Division:
                    return expression.LeftsideOperand / expression.RightsideOperand;

                case enMathOperation.Modulus:
                    return expression.LeftsideOperand % expression.RightsideOperand;

                case enMathOperation.Poewer:
                    return Math.Pow(expression.LeftsideOperand ,expression.RightsideOperand);

                case enMathOperation.Sin:
                    return Math.Sin(expression.RightsideOperand);

                case enMathOperation.Cos:
                    return Math.Cos(expression.RightsideOperand);

                case enMathOperation.Tan:
                    return Math.Tan(expression.RightsideOperand);
                default:
                    return 0.0;
            }
        }
    }
}
