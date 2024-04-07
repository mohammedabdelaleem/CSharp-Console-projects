using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcualtor
{
    internal class clsCalculator
    {
        private double _Result = 0;
        private double _LastNumber = 0;
        private string _LastOperation = "Clear";
        public void Clear()
        {
            _LastOperation = "Clear";
            _Result = 0;
            _LastNumber = 0;
        }
    public void Add(double Number)
        {
            _LastOperation = "Adding";
            _LastNumber = Number;
            _Result += Number;
        }
        public void Subtract(double Number)
        {
            _LastOperation = "Subtracting";
            _LastNumber = Number;
            _Result -= Number;
        }
        public void Multiply(double Number)
        {
            _LastOperation = "Multiplying";
            _LastNumber = Number;
            _Result *= Number;
        }
        public void Divide(double Number)
        {
            _LastOperation = "Dividing";
            _LastNumber = Number;
            if (Number == 0)
                Number = 1;
            _Result /= Number;
        }

        private double GetFinalResult()
        {
            return _Result;
        }

        public void PrintResult()
        {
            Console.WriteLine("Result After " + _LastOperation + " " + _LastNumber + " is : " + GetFinalResult());
        }

    }
}
