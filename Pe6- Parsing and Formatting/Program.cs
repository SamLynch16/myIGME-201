using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pe6__Parsing_and_Formatting
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            bool valid= false;
            int guessnum = 0;
            Random rand = new Random();
            int randomNumber = rand.Next(0, 101);
 
                for (int guesses = 0; guesses <= 8; guesses++)
                {
                    do
                    {
                        Console.Write("Turn #");
                        Console.Write(guesses);
                        Console.Write(" Enter your guess: ");
                        string sGuess = Console.ReadLine();
                        valid = int.TryParse(sGuess, out guessnum);

                    } while (!valid);
                    if (guessnum > 100 | guessnum < 1)
                    {
                        Console.WriteLine("Guesses should be between 1-100");
                        break;
                    }
                    else if (guessnum > randomNumber)
                    {
                        Console.WriteLine("Too high!");

                    }
                    else if (guessnum < randomNumber)
                    {
                        Console.WriteLine("Too Low!");
                    }
                    else { 
                        Console.WriteLine("Thats correct!");
                        break;
                    }
                }
            }
        }
    }

