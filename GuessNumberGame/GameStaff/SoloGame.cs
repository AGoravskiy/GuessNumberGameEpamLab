using Dal.Model;
using GuessNumberGame.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumberGame.GameStaff
{
    class SoloGame : BaseGame
    {
        public SoloGame(Player player)
        {
            Player = player;
        }

        public override void ComeUpWithNumber()
        {
            Random random = new Random();
            Console.Clear();
            HiddenNumber = random.Next(1, 10000);
            MinValue = HiddenNumber - random.Next(1, HiddenNumber);
            MaxValue = HiddenNumber + random.Next(1, HiddenNumber);
            MaxAttempt = CalcMaxAttempt(MinValue, MaxValue);

            var rangeValidator = new RangeValidator(MinValue, MaxValue);

            if (MinValue < 0)
            {
                MinValue = 0;
            }
        }

        public override void EndGame()
        {
            if (Win)
            {
                Player.SoloScore += MaxAttempt - Attempt;
                Console.WriteLine($"Congratulations, you guessed the number and spend {Attempt} from {MaxAttempt} attempt(s)!");
                Console.WriteLine($"Year score: {Player.SoloScore}");
            }
            else
            {
                Console.WriteLine($"Sorry, next time. Number was  {HiddenNumber}.");
            }
            Console.ReadLine();
        }
    }
}
