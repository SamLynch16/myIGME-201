using System;

namespace Mandelbrot
{
    /// <summary>
    /// This class generates Mandelbrot sets in the console window!
    /// </summary>


    class Class1
    {
        /// <summary>
        /// This is the Main() method for Class1 -
        /// this is where we call the Mandelbrot generator!
        /// </summary>
        /// <param name="args">
        /// The args parameter is used to read in
        /// arguments passed from the console window
        /// </param>

        [STAThread]
        static void Main(string[] args)
        {
            double realCoord, imagCoord;
            double realTemp, imagTemp, realTemp2, arg;
            int iterations;
            Console.WriteLine("Give me start value for imagCoord:" );
            string simagcoord = Console.ReadLine();
            Console.WriteLine("Give me end value for imagCoord");
            string eimagcoord = Console.ReadLine();
            Console.WriteLine("Give me start value for realCoord:");
            string srealcoord = Console.ReadLine();
            Console.WriteLine("Give me end value for realCoord");
            string erealcoord = Console.ReadLine();
            double startimagcoord = Convert.ToDouble(simagcoord);
            double endimagcoord = Convert.ToDouble(eimagcoord);
            double startrealcoord = Convert.ToDouble(srealcoord);
            double endrealcoord = Convert.ToDouble(erealcoord);

            for (imagCoord = startimagcoord; imagCoord >= endimagcoord; imagCoord -= 0.06)
            {
                for (realCoord = startrealcoord; realCoord <= endrealcoord; realCoord += 0.01)
                {
                    iterations = 0;
                    realTemp = realCoord;
                    imagTemp = imagCoord;
                    arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                    while ((arg < 4) && (iterations < 40))
                    {
                        realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp)
                           - realCoord;
                        imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                        realTemp = realTemp2;
                        arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                        iterations += 1;
                    }
                    switch (iterations % 4)
                    {
                        case 0:
                            Console.Write(".");
                            break;
                        case 1:
                            Console.Write("o");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 3:
                            Console.Write("@");
                            break;
                    }
                }
                Console.Write("\n");
            }

        }
    }
}
