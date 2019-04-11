using GuessNumberGame.Validators;
using System;
using Dal.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumberGame.GameStaff
{
    public abstract class BaseGame
    {
        public int HiddenNumber { get; set; }

        public int OptionNumber { get; set; }

        public int MinValue { get; set; }

        public int MaxValue { get; set; }

        public int Attempt { get; set; }

        public int MaxAttempt { get; set; }

        public bool Win { get; set; }

        public Player Player { get; set; }

        public void PlayOneRound()
        {
            ComeUpWithNumber();

            GuessNumberGame();

            EndGame();
        }

        public abstract void ComeUpWithNumber();

        public void GuessNumberGame()
        {
            var rangeValidator = new RangeValidator(MinValue, MaxValue);

            do
            {
                Console.WriteLine($"Guess the number in the range of {MinValue} to {MaxValue}.");
                Console.WriteLine($"Attempt {++Attempt} out of {MaxAttempt}.");
                Console.WriteLine("Enter the number: ");
                OptionNumber = ReadIntFromConsole(rangeValidator);

                if (OptionNumber > HiddenNumber)
                {
                    Console.WriteLine($"Your number {OptionNumber} is more than hidden number.");
                }
                else if (OptionNumber < HiddenNumber)
                {
                    Console.WriteLine($"Your number {OptionNumber} is less than hidden number.");
                }
                else
                {
                    Win = true;
                }

            } while (!Win && Attempt < MaxAttempt);
        }

        public abstract void EndGame();

        public int ReadIntFromConsole(IValidator validator = null)
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

        public int CalcMaxAttempt(int minValue, int maxValue)
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
