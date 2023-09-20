using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace notoyes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write a sentence");
            string notoyes = Console.ReadLine();
            notoyes.ToLower();
            char[] notoyesarray = notoyes.ToCharArray();   
            for (int i = 0; i< notoyesarray.Length; i++)
            {
                if (notoyesarray[i] = "no")
                {
                    notoyesarray[i] = "yes";
                    notoyesarray[i] += notoyes[i];
                }
            }
            Console.WriteLine(notoyes);

        }
    }
}
   

