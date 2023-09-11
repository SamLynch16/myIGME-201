using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int convar1 = 0;
            int convar2 = 0;
            Console.WriteLine("Give me a number");
            string var1 = Console.ReadLine();
            Console.WriteLine("Give me another number");
            string var2 = Console.ReadLine();
            
            convar1 = Convert.ToInt32(var1);
            convar2 = Convert.ToInt32(var2);

            if (convar1 > 10 && convar2 <=10){
                Console.WriteLine("True");
            }
            else if (convar1 <= 10 && convar2 > 10)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }

        }
    }
}
