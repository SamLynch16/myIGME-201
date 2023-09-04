using System;

namespace SquashTheBugs
{
    // Class Program
    // Author: David Schuh
    // Purpose: Bug squashing exercise
    // Restrictions: None
    class Program
    {
        // Method: Main
        // Purpose: Loop through the numbers 1 through 10 
        //          Output N/(N-1) for all 10 numbers
        //          and list all numbers processed
        // Restrictions: None
        static void Main(string[] args)
        {
            // declare int counter
            //the line below is a compile time error because it is missing a semicolon
            int i = 0;

            // loop through the numbers 1 through 10
            for (i = 1; i < 10; ++i)
            {
                // declare string to hold all numbers
                string allNumbers = null;

                // output explanation of calculation
                //This is a runtime error because you cant put a string and a int + together or else you will mess up the syntax. 
                Console.Write(i + "/" , i - 1 + " = ");

                // output the calculation based on the numbers
                Console.WriteLine(i / (i - 1));

                // concatenate each number to allNumbers
                allNumbers += i + " ";

                // increment the counter
                i = i + 1;


                // output all numbers which have been processed
                //This was a logic error the variable was outside of where it was declared so I had to move the 
                //code into the brackets.
                Console.WriteLine("These numbers have been processed: ", allNumbers);
            }
        }
    }
}