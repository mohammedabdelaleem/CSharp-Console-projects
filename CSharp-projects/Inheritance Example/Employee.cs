using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
	abstract class Employee
	{
		#region Data Members - Fields

		protected const byte minHoursRequierd = 176;
		protected const float overTimeRate = 1.25f;

		protected int id;
		protected string name;
		protected float loggedHours;
		protected float wage;
		#endregion

		#region  properties

		public float Wage
		{
			get { return wage; }
		}

		public float LoggedHours
		{
			get { return loggedHours; }
		}

		public string Name
		{
			get { return name; }
		}

		public int ID
		{
			get { return id; }
		}

		#endregion

		#region Constructors 
		protected Employee(int _id, string _name, float _loggedHours, float _wage)
		{
			id = _id;
			name = _name;
			loggedHours = _loggedHours;
			wage = _wage;
		}

		public Employee() : this(0, null, 0, 0) { }
		#endregion

		#region Mehods

		public float BasicSalary() => minHoursRequierd * wage;

		private float AdditionalHours() => (loggedHours - minHoursRequierd) > 0 ? (loggedHours - minHoursRequierd) : 0;

		public float OverTime() => AdditionalHours() * wage * overTimeRate;

		protected float TotalSalary() => BasicSalary() + OverTime();

		public abstract float NetSalary();

        public override string ToString()
        {
			string type = GetType().ToString().Replace("Inheritance.","");///////////////////SUPER//////////////////
            return 
				$"\n\n{type} Info:\n" +
				$"----------------------\n" +
                $"ID:{id}\n" +
				$"Name:{name}\n" +
                $"LoggedHours:{loggedHours} HRs" +
                $"\nWage:{wage} $/HR\n" +
                $"BasicSalary:${Math.Round(BasicSalary(),2):N0}" +
                $"\nOvertime:${Math.Round(OverTime(),2):N0}\n";
        }
        #endregion
    }
}
