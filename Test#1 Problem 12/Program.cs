using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1_Problem_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sName;
            double dSalary = 30000;

            Console.WriteLine("What is your name?");
            sName = Console.ReadLine();
            GiveRaise(sName, ref dSalary);
            Console.WriteLine($"Congratulations, {sName} you got a raise! New Salary:{dSalary}");
        }
        static bool GiveRaise(string name, ref double salary)
        {
            if (name == name)
            {
                salary += 19999.99;
                return true;
                
            }
            else
            {
                return false;
            }
        }

    }
}
