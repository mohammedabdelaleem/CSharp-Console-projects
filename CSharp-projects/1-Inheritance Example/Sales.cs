using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Inheritance
{
    internal class Sales:Employee
    {
        #region Fields
        double volumeOfSales;
        float commission;

        #endregion

        #region  Constuctor

        public Sales(int _id, string _name, float _loggedHours, float _wage, double _volumeOfSales, float _commission)
            : base(_id, _name, _loggedHours, _wage) {
            volumeOfSales = _volumeOfSales;
            commission = _commission;
        }

        #endregion

        #region Properties
        public float Commission { get { return commission; } }
        public double VolumeOfSales { get {  return volumeOfSales; } }

        #endregion

        #region Methods
        public float Bonus()
        {
            return (float)(commission*volumeOfSales);
        }

        public override float NetSalary()
        {
            return TotalSalary() + Bonus();
        }

        public override string ToString()
        {
            return base.ToString() + $"Sales:{volumeOfSales}\n" +
                $"Commission:{Math.Round(commission*100,2)}%\nBonus:${Math.Round(Bonus(), 2):N0}\nNetSalary:${Math.Round(NetSalary(), 2):N0}";
        }
        #endregion

    }
}
