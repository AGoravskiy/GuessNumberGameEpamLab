using Dal.Model;
using GuessNumGame.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumGame.GameStaff
{
    public class MultiplayerGame : BaseGame
    {
        public MultiplayerGame(Player player)
        {
            Player = player;
        }

        public override void ComeUpWithNumber()
        {
            Console.Clear();
            Console.WriteLine("Player 1 pleas enter min value of the range: ");
            MinValue = ReadIntFromConsole();

            Console.WriteLine("Player 1 pleas enter max value of the range: ");
            var minValueValidator = new MinValueValidator(MinValue);
            MaxValue = ReadIntFromConsole(minValueValidator);

            var rangeValidator = new RangeValidator(MinValue, MaxValue);

            Console.WriteLine("Player 1 pleas enter the number: ");
            HiddenNumber = ReadIntFromConsole(rangeValidator);

            Console.Clear();
            Console.WriteLine("Player 2 are you ready to guess the number?");
            Console.ReadLine();
            Console.Clear();

            MaxAttempt = CalcMaxAttempt(MinValue, MaxValue);
        }

        public override void EndGame()
        {
            if (Win)
            {
                Player.MultiScore += MaxAttempt - Attempt;
                Console.WriteLine($"Congratulations, you guessed the number and spend {Attempt} from {MaxAttempt} attempt(s)!");
                Console.WriteLine($"Your score: {MaxAttempt - Attempt}");
                Console.WriteLine($"Total score: {Player.MultiScore}");
            }
            else
            {
                Console.WriteLine($"Sorry, next time. Number was  {HiddenNumber}.");
            }
            Console.ReadLine();
        }
    }
}
