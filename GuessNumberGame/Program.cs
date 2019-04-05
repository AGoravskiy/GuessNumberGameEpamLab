using GuessNumberGame.Validators;
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
            var hiddenNumber = 0;
            var optionNumber = 0;
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
                hiddenNumber = random.Next(1, 10000);
                minValue = hiddenNumber - random.Next(1, hiddenNumber);
                maxValue = hiddenNumber + random.Next(1, hiddenNumber);
                maxAttempt = CalcMaxAttempt(minValue, maxValue);

                var rangeValidator = new RangeValidator(minValue, maxValue);

                if (minValue < 0)
                {
                    minValue = 0;
                }

                do
                {
                    Console.WriteLine($"Guess the number in the range of {minValue} to {maxValue}.");
                    Console.WriteLine($"Attempt {++attempt} out of {maxAttempt}.");
                    Console.WriteLine("Enter the number: ");
                    optionNumber = ReadIntFromConsole(rangeValidator);

                    if (optionNumber > hiddenNumber)
                    {
                        Console.WriteLine($"Your number {optionNumber} is more than hidden number.");
                    }
                    else if (optionNumber < hiddenNumber)
                    {
                        Console.WriteLine($"Your number {optionNumber} is less than hidden number.");
                    }
                    else
                    {
                        win = true;
                    }

                } while (!win && attempt < maxAttempt);

                if (win)
                {
                    Console.WriteLine($"Congratulations, you guessed the number and spend {attempt} from {maxAttempt} attempt(s)!");
                }
                else
                {
                    Console.WriteLine($"Sorry, next time. Number was  {hiddenNumber}.");
                }
                Console.ReadLine();
            }
            else if (key.Key == ConsoleKey.M)
            {
                Console.Clear();
                Console.WriteLine("Player 1 pleas enter min value of the range: ");
                minValue = ReadIntFromConsole();

                Console.WriteLine("Player 1 pleas enter max value of the range: ");
                var minValueValidator = new MinValueValidator(minValue);
                maxValue = ReadIntFromConsole(minValueValidator);

                var rangeValidator = new RangeValidator(minValue, maxValue);

                Console.WriteLine("Player 1 pleas enter the number: ");
                hiddenNumber = ReadIntFromConsole(rangeValidator);

                Console.Clear();
                Console.WriteLine("Player 2 are you ready to guess the number?");
                Console.ReadLine();
                Console.Clear();

                maxAttempt = CalcMaxAttempt(minValue, maxValue);

                do
                {
                    Console.WriteLine($"Guess the number in the range of {minValue} to {maxValue}.");
                    Console.WriteLine($"Attempt {++attempt} out of {maxAttempt}.");
                    Console.WriteLine("Enter the number: ");
                    optionNumber = ReadIntFromConsole(rangeValidator);

                    if (optionNumber > hiddenNumber)
                    {
                        Console.WriteLine($"Your number {optionNumber} is more than hidden number.");
                    }
                    else if (optionNumber < hiddenNumber)
                    {
                        Console.WriteLine($"Your number {optionNumber} is less than hidden number.");
                    }
                    else
                    {
                        win = true;
                    }

                } while (!win && attempt < maxAttempt);

                if (win)
                {
                    Console.WriteLine($"Congratulations, you guessed the number and spend {attempt} from {maxAttempt} attempt(s)!");
                }
                else
                {
                    Console.WriteLine($"Sorry, next time. Number was {hiddenNumber}.");
                }
                Console.ReadLine();
            }
        }

        private static int ReadIntFromConsole(IValidator validator = null)
        {
            var input = Console.ReadLine();
            int number;

            do
            {
                if (!string.IsNullOrEmpty(validator?.Error))
                {
                    Console.WriteLine(validator.Error);
                    input = Console.ReadLine(); 
                }

                while (!int.TryParse(input, out number))
                {
                    Console.WriteLine("It's not a number. Pleas enter the number: ");
                    input = Console.ReadLine();
                }
            } while (!validator?.Valid(number) ?? false);

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
