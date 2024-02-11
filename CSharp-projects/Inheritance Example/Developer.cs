using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class Developer : Employee
    {
        #region Fields

        bool taskCompleted;

        #endregion


        #region Properties 
        public bool TaskCompleted => taskCompleted;
        #endregion


        #region Constructors 
        public Developer(int _id, string _name, float _loggedHours, float _wage, bool _taskCompleted)
            : base(_id, _name, _loggedHours, _wage) {
            taskCompleted = _taskCompleted;
        }

        #endregion

        #region  Properties
        public float Bonus => taskCompleted? 0.03f * TotalSalary():0 ;

        #endregion

        #region Methods

        public override float NetSalary()
        {
            return TotalSalary() + Bonus;
        }

        public override string ToString()
        {
            return base.ToString() + $"TaskCompleted:{taskCompleted}\n" + $"Bonus:${Math.Round(Bonus, 2):N0}\nNetSalary:${Math.Round(NetSalary(), 2):N0}";
        }
        #endregion
    }
}
