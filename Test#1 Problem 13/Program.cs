using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Test_1_Problem_13
{
    internal class Program
    {
        struct Employee
        {
            public string sName;
            public double dSalary;

        }

        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Employee emp = new Employee();
            emp.sName = name;
            emp.dSalary = 30000;
            bool newsalary = GiveRaise(ref emp);

            Console.WriteLine($"Congratulations, {emp.sName} you got a raise! New Salary:{emp.dSalary}");
        }
        static bool GiveRaise(ref Employee emp)
        {
            if (emp.sName == emp.sName)
            {
                emp.dSalary += 19999.99;
                return true;

            }
            else
            {
                return false;
            }
        }

    }
}
        
       

    


