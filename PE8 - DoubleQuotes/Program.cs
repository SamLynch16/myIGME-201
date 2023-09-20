using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string: ");
            string quotes = Console.ReadLine();
     
            foreach (string s in quotes.Split())
            {
                quotes = Regex.Replace(quotes, @"\w+", "\"$0\"");
                Console.WriteLine(quotes);
                break;
            }
       
        }
    }
}
