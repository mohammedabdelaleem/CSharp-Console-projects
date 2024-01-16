using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    internal class EntryPoint
    {
        static void Main(string[] args)
        {

            Manager manager = new Manager(1000, "Mohammed Ali", 180,10);

            Maintanace maintanace = new Maintanace(100, "Aliaa Hassan", 185, 9);

            Sales sales = new Sales(1001, "Mosaa Ali", 176, 8, 10000, .05f);

            Developer developer = new Developer(1220, "Mohaned Adel", 180, 14, true);


            Employee[] employees = {manager, maintanace, sales,developer};
            foreach(Employee employee in employees)
            {
                Console.WriteLine(employee);
            }


            Console.ReadKey();
        }
    }
}





