using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstPlayerNumber = 0;
            var secondPlayerNumber = 0;
            var minValue = 0;
            var maxValue = 0;
            var attempt = 0;
            var maxAttempt = 0;
            var win = false;
            Random random = new Random();

            Console.WriteLine("                 *******Welcom to GuessNumberGame!*******\n");
            Console.WriteLine("Do you want play single(press 's') or multiplayer(press 'm')?");

            ConsoleKeyInfo key;
            key = Console.ReadKey();

            if (key.Key == ConsoleKey.S)
            {
                Console.Clear();
                firstPlayerNumber = random.Next(1, 10000);
                minValue = firstPlayerNumber - random.Next(1, firstPlayerNumber);
                maxValue = firstPlayerNumber + random.Next(1, firstPlayerNumber);
                maxAttempt = CalcMaxAttempt(minValue, maxValue);

                if (minValue < 0)
                {
                    minValue = 0;
                }

                do
                {
                    Console.WriteLine($"Guess the number in the range of {minValue} to {maxValue}.");
                    Console.WriteLine($"Attempt {++attempt} out of {maxAttempt}.");
                    Console.WriteLine("Enter the number: ");
                    secondPlayerNumber = ReadIntFromConsole();

                    if (secondPlayerNumber > firstPlayerNumber)
                    {
                        Console.WriteLine($"Your number {secondPlayerNumber} is more than hidden number.");
                    }
                    else if (secondPlayerNumber < firstPlayerNumber)
                    {
                        Console.WriteLine($"Your number {secondPlayerNumber} is less than hidden number.");
                    }
                    else
                    {
                        win = true;
                    }

                } while (attempt < maxAttempt);

                if (win)
                {
                    Console.WriteLine($"Congratulations, you guessed the number and spend {attempt} from {maxAttempt} attempt(s)!");
                }
                else
                {
                    Console.WriteLine($"Sorry, next time. Number was {firstPlayerNumber}.");
                }
                Console.ReadLine();
            }
            else if (key.Key == ConsoleKey.M)
            {
                Console.Clear();
                Console.WriteLine("Player 1 pleas enter min value of the range: ");
                minValue = ReadIntFromConsole();
                Console.WriteLine("Player 1 pleas enter max value of the range: ");
                maxValue = ReadIntFromConsole();
                maxAttempt = CalcMaxAttempt(minValue, maxValue);
                Console.WriteLine("Player 1 pleas enter the number: ");
                firstPlayerNumber = ReadIntFromConsole();
                Console.Clear();
                Console.WriteLine("Player 2 are you ready to guess the number?");
                Console.ReadLine();
                Console.Clear();

                do
                {
                    Console.WriteLine($"Guess the number in the range of {minValue} to {maxValue}.");
                    Console.WriteLine($"Attempt {++attempt} out of {maxAttempt}.");
                    Console.WriteLine("Enter the number: ");
                    secondPlayerNumber = ReadIntFromConsole();

                    if (secondPlayerNumber > firstPlayerNumber)
                    {
                        Console.WriteLine($"Your number {secondPlayerNumber} is more than hidden number.");
                    }
                    else if (secondPlayerNumber < firstPlayerNumber)
                    {
                        Console.WriteLine($"Your number {secondPlayerNumber} is less than hidden number.");
                    }
                    else
                    {
                        win = true;
                    }

                } while (attempt < maxAttempt);

                if (win)
                {
                    Console.WriteLine($"Congratulations, you guessed the number and spend {attempt} from {maxAttempt} attempt(s)!");
                }
                else
                {
                    Console.WriteLine($"Sorry, next time. Number was {firstPlayerNumber}.");
                }
                Console.ReadLine();
            }
        }

        private static int ReadIntFromConsole()
        {
            var input = Console.ReadLine();
            int number;

            while (!int.TryParse(input, out number))
            {
                Console.WriteLine("It's not a number. Pleas enter the number: ");
                input = Console.ReadLine();
            }

            return number;
        }

        private static int CalcMaxAttempt(int minValue, int maxValue)
        {
            var rangeMinMaxValue = maxValue - minValue;
            var twoPower = 2;
            var maxAttempt = 1;

            while (rangeMinMaxValue > twoPower)
            {
                twoPower *= 2;
                maxAttempt++;
            }

            return maxAttempt;
        }
    }
}
