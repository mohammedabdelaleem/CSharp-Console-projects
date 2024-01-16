using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Maintanace:Employee
    {
        #region Fields
        const byte hardshipAllowance = 100;

        #endregion

        #region Properties
        public byte Hardship => hardshipAllowance;

        #endregion


        #region Constructors


        public Maintanace(int _id, string _name, float _loggedHours, float _wage)
            : base(_id, _name, _loggedHours, _wage) { }

        #endregion


        #region Methods

        public override float NetSalary()
        {
            return TotalSalary() + hardshipAllowance; 
        }

        public override string ToString()
        {
            return base.ToString() + $"Hardship:${Math.Round((float)hardshipAllowance, 2):N0}\nNetSalary:${Math.Round(NetSalary(), 2):N0}";
        }

        #endregion

    }
}
