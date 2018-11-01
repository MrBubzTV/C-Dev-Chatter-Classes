using System;
using System.Threading;

namespace Episode_0_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var randomGenerator = new Random();
            int lowerBound = 1;
            //Console.WriteLine("Please choose an upper bound for the secret number: ");
            int upperBound = 10_000_000; //int.Parse(Console.ReadLine());
            int secretNumber = randomGenerator.Next(lowerBound, upperBound + 1);
            int guess = -1;
            string message = $"Please guess a number between {lowerBound} and {upperBound}!";

            while (guess != secretNumber)
            {
                Console.WriteLine(message);

                Thread.Sleep(500); // Just ignore this, Bubz...

                // Guess the middle of possible numbers
                //guess = lowerBound + (upperBound - lowerBound) / 2;
                guess = randomGenerator.Next(lowerBound, upperBound +1);
                Console.WriteLine($"Guessing {guess} between {lowerBound} and {upperBound}.");

                if (guess < secretNumber)
                {
                    lowerBound = guess;
                    // set lowerbound to previous guess
                    message = "Higher!";
                }
                else if (guess > secretNumber)
                {
                    upperBound = guess;
                    // set upperbound to previous guess
                    message = "Lower!";
                }
            }

            Console.WriteLine("Please be sure to drink your Ovaltine.");
        }
    }
}
