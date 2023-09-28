using System;

namespace UT1_BugSquash
{
    class Program
    {
        // Calculate x^y for y > 0 using a recursive function
        static void Main(string[] args)
        {
            string sNumber;
            int nX;
            //Compile time: there is no semicolon
            int nY;

            int nAnswer;

            //Compile time: there is no quotes around the string
            Console.WriteLine("This program calculates x ^ y.");

            do
            {
                Console.Write("Enter a whole number for x: ");
                //Logical error: did not make sNumber = the Console.Readline
                sNumber = Console.ReadLine();
            } while (!int.TryParse(sNumber, out nX));

            do
            {
                Console.Write("Enter a positive whole number for y: ");
                sNumber = Console.ReadLine();
            //Logical error: put nX instead of nY
            } while (!int.TryParse(sNumber, out nY));

            // compute the exponent of the number using a recursive function
            nAnswer = Power(nX, nY);

            //Runtime error: never put a dollar sign infront of the quotes to show the variables.
            Console.WriteLine($"{nX}^{nY} = {nAnswer}");
        }


        //Logical error: did not put static infront of int
        static int Power(int nBase, int nExponent)
        {
            int returnVal = 0;
            int nextVal = 0;

            // the base case for exponents is 0 (x^0 = 1)
            if (nExponent == 0)
            {
                // return the base case and do not recurse
                //RUntime Error: when the exponent is zero it was returning 0 when it should return 1
                returnVal = 1;
            }
            else
            {
                // compute the subsequent values using nExponent-1 to eventually reach the base case
                //Runtime error: didn't have a negative instead put a + 1, this could also be a logical error 
                //but I think it is runtime because the program still ran. 
                nextVal = Power(nBase, nExponent - 1);

                // multiply the base with all subsequent values
               returnVal = nBase * nextVal;
            }
            //Logical error: never put return infront of returnVal
            return returnVal;
        }
    }
}
