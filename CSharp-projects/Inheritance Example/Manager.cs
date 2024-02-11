using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Manager : Employee
    {
        #region Fields

       const float allowanceRate=0.05f;

        #endregion

        #region Constructors 
        public Manager(int _id, string _name, float _loggedHours, float _wage)
            : base(_id, _name, _loggedHours, _wage) { }

        #endregion

        #region Properties
        public float Allowance { get => allowanceRate * TotalSalary(); }
        #endregion

        #region Methods

        public override float NetSalary()
        {
            return TotalSalary() + Allowance;
        }

        public override string ToString()
        {
            return base.ToString() + $"Allowance:${Math.Round(Allowance, 2):N0}\nNetSalary:${Math.Round( NetSalary(),2):N0}";
        }

        #endregion
    }
}
