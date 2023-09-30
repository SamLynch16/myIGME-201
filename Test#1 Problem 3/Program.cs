using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_1_Problem_3
{
    internal class Program
    {
        delegate int MathRound(double numberdeci);

        static int nRound(double nNumber){
            return (int)Math.Round(nNumber);

}
        static void Main(string[] args)
        {
            string sNumber = null;
            double nNum = 0;
       
            do
            {
                Console.Write("Enter a decimal: ");
                sNumber = Console.ReadLine();
            } while (!double.TryParse(sNumber, out nNum));

            MathRound rDelegate = nRound;

            int rounded = rDelegate(nNum);
            Console.WriteLine(rounded);

            // prompt and convert second number
            
        }
    }
}
