using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reverseorder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write a word");
            string normal = Console.ReadLine();
            string reversestring = "";
            char[] reversearray= normal.ToCharArray();
            for (int i = normal.Length - 1; i > -1; i--)
            {
                reversestring += reversearray[i];
            }
            Console.WriteLine(reversestring);
            
            }
               
        }
    }

