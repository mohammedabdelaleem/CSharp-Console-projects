using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMathExpressionEvaluator.SimpleMathExpressionEvaluator
{
    public static class ExpressionParser
    {
        /*
         5+10
        10  +  5
        15+   10
        55--10
         -10-5
        10*2
        10/2
        10 % 2
        10 mod 2
        10^2
        10 Pow 2
        sin 30
        cos 30 
        tan 30
         */
        public const string MathSymbols = "+*/^%"; // without - , it has a special treatment
        public static MathExpression Parse(string input)//I Need To return AST "Abstracr Syntax Tree"
        {
            input = input.Trim();
            var expression = new MathExpression();
            char currentChar;
            var token = new StringBuilder();
            bool leftsideInitialized = false;
            //1025 + 30
            for (byte i = 0; i < input.Length; i++)
            {
                currentChar = input[i];
                if (char.IsDigit(currentChar))
                {
                    token.Append(currentChar);
                    if(i==input.Length-1)
                        expression.RightsideOperand = double.Parse(token.ToString());
                }

                else if (MathSymbols.Contains(currentChar))
                {
                    if (!leftsideInitialized)
                    {
                        expression.LeftsideOperand = double.Parse(token.ToString()); // if you entered here , then you have a leftside. **Don't Forget clear a token
                        leftsideInitialized = true;
                    }
                    expression.Operation = ParseMathOperation(currentChar.ToString());
                    token.Clear();
                }

                else if (currentChar == ' ')
                {
                    if (!leftsideInitialized)
                    {
                        expression.LeftsideOperand = double.Parse(token.ToString());
                        leftsideInitialized = true;
                        token.Clear();
                    }
                    else if (expression.Operation == enMathOperation.None)
                    {
                        expression.Operation = ParseMathOperation(token.ToString());
                        token.Clear();
                    }
                }

                else if (char.IsLetter(currentChar))
                {
                    leftsideInitialized = true;  //sin 60 
                    token.Append(currentChar);
                }

                else if (currentChar == '-' && i > 0)
                {
                    if (expression.Operation == enMathOperation.None)
                    {
                        expression.Operation = enMathOperation.Subtraction;
                        if(!leftsideInitialized)
                        {
                            expression.LeftsideOperand = double.Parse(token.ToString());
                            leftsideInitialized = true;
                        token.Clear();
                        }
                        
                    } 
                    else
                    {
                        token.Append(currentChar);
                    }
                }
                else { token.Append(currentChar); }

            }

            return expression;
        }

        private static enMathOperation ParseMathOperation(string currentChar)
        {
            switch (currentChar.ToLower())
            {
                case "+":
                    return enMathOperation.Additonn;
                case "*":
                    return enMathOperation.Multiplication;
                case "/":
                    return enMathOperation.Division;
                case "%":
                case "mod":
                    return enMathOperation.Modulus;
                case "^":
                case "pow":
                    return enMathOperation.Poewer;
                case "sin":
                    return enMathOperation.Sin;
                case "cos":
                    return enMathOperation.Cos;
                case "tan":
                    return enMathOperation.Tan;
                default:
                    return enMathOperation.None;
            }
        }
    }
}
