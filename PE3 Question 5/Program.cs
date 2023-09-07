using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int convertedin1 = 0;
            int convertedin2 = 0;
            int convertedin3 = 0;
            int convertedin4 = 0;
            Console.WriteLine("Please enter a int: ");
            string int1 = Console.ReadLine();
            Console.WriteLine("Enter another int: ");
            string int2 = Console.ReadLine();
            Console.WriteLine("Enter another int: ");
            string int3 = Console.ReadLine();
            Console.WriteLine("Enter another int: ");
            string int4 = Console.ReadLine();

            convertedin1 = Convert.ToInt32(int1);
            convertedin2 = Convert.ToInt32(int2);
            convertedin3 = Convert.ToInt32(int3);  
            convertedin4 = Convert.ToInt32(int4);


            int product = convertedin1 * convertedin2 * convertedin3 * convertedin4;
            Console.Write(product);

            
        }
    }
}
