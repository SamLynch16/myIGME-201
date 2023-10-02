
using System;
using System.Timers;


class Program
{
    // bTimeOut boolean
    static bool bTimeOut = false;
    // timeOutTimer Timer
    static Timer timeOutTimer;


    static void TimesUp(object source, ElapsedEventArgs e)
    {

        Console.WriteLine();
        Console.WriteLine("Your time is up!");
        Console.WriteLine("Please press Enter.");
        // set the bTimeOut flag to invalidate the current question
        bTimeOut = true;
        // stop the timeOutTimer
        timeOutTimer.Stop();
    }

    static void Main()
    {
        // store user name
        string myName = "";
        // string and int of # of questions
        string sQuestions = "";
        int nQuestions = 0;
        // string and base value related to difficulty
        // constant for setting difficulty with 1 variable
    
        // question and # correct counters
        int nCntr = 0;
        int nCorrect = 0;
        // operator picker
        int nOp = 0;
        // operands and solution
        
        string firstAnswer = "black";
        int secondAnswer = 42;
        string thirdAnswer = "What do you mean? African or European swallow?";
        // string and int for the response
        string firstResponse = "";
        string sResponse = "";
        string thirdResponse = "";
        Int32 secondResponse = 0;

        // boolean for checking valid input
        bool bValid = false;
        // play again?
        string sAgain = "";
    // seed the random number generator

    // fetch the user's name into myName
    // label to return to if they want to play again
    start:
        // initialize correct responses for each time around



        // ask each question

        Console.Write("Choose your question (1-3): ");
        string response = Console.ReadLine();
        nOp = Convert.ToInt32(response);
        if (nOp == 1)
        {
            firstAnswer = "black";
            sQuestions = "What is your favorite Color? ";
        }
        else if (nOp == 2)
        {
            secondAnswer = 42;
            sQuestions = "What is the answer to life, the universe and everything?";
        }
        else
        {
            thirdAnswer = "What do you mean? African or European swallow?";
            sQuestions = "What is the airspeed velocity of an uladen swallow?";
        }

        // create timeOutTimer with an elapsed time of 5 seconds (5000ms)
        timeOutTimer = new Timer(5000);
        /*
        // Timer calls the Timer.Elapsed event handler when the time elapses
        // The Timer.Elapsed event handler uses a delegate function with the following
        signature:
        public delegate void ElapsedEventHandler(object sender, ElapsedEventArgs
        e);
        // we want TimesUp() to be called when the timer elapses
        // we can assign our delegate function variable in several steps like we did
        before
        ElapsedEventHandler elapsedEventHandler;
        elapsedEventHandler = new ElapsedEventHandler(TimesUp);
        // add the TimesUp() delegate function to the timeOutTimer.Elapsed event handler
        timeOutTimer.Elapsed += elapsedEventHandler;
        */
        // or we can just do that in one line
        // add the TimesUp() delegate function to the timeOutTimer.Elapsed event handler
        // TimesUp() will be called when the Timer elapses
        timeOutTimer.Elapsed += new ElapsedEventHandler(TimesUp);
        // initialize timeout flag
        bTimeOut = false;
        // start the timeOutTimer
        timeOutTimer.Start();
        // display the question and prompt for the answer
        do
        {
            if (nOp == 1)
            {
                Console.Write(sQuestions);
                firstResponse = Console.ReadLine();
            }
            if (nOp == 2)
            {
                Console.Write(sQuestions);
                sResponse = Console.ReadLine();
            }
            else
            {
                Console.Write(sQuestions);
                thirdResponse = Console.ReadLine();
            }
            // stop the timer when they press enter
            timeOutTimer.Stop();
            // if the timer timed out
            if (bTimeOut)
            {
                // set the response to the wrong answer
                firstResponse = "Wrong";
                secondResponse = secondAnswer + 1;
                thirdResponse = "Wrong";
                // break from the loop
                break;
            }
            try
            {
                secondResponse = int.Parse(sResponse);
                bValid = true;
            }
            catch
            {


                Console.WriteLine("Please enter an integer.");
                bValid = false;

            } while (!bValid) ;
            // if response == answer, output flashy reward and increment # correct
            // else output stark answer
            if (firstResponse == firstAnswer)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Well done, {0}!!!", myName);
                ++nCorrect;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("I'm sorry {0}. The answer is {1}", myName, firstAnswer);
            }
            if (secondResponse == secondAnswer)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Well done, {0}!!!", myName);
                ++nCorrect;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("I'm sorry {0}. The answer is {1}", myName, secondAnswer);
            }
            if (thirdResponse == thirdAnswer)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Well done, {0}!!!", myName);
                ++nCorrect;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("I'm sorry {0}. The answer is {1}", myName, thirdAnswer);
            }


            do
            {
                // prompt if they want to play again
                Console.Write("Do you want to play again? ");
                sAgain = Console.ReadLine();
                if (sAgain.ToLower().StartsWith("y"))
                {
                    goto start;
                }
                else if (sAgain.ToLower().StartsWith("n"))
                {
                    break;
                }
            } while (true);

            // TimesUp() is called when the timer elapses
            
        }while (!true);
    }
}
