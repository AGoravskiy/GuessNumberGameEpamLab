using Dal.Model;
using GuessNumberGame.GameStaff;
using GuessNumberGame.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Repository;

namespace GuessNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("                 *******Welcom to GuessNumberGame!*******\n");
            Console.WriteLine("Do you want play single(press 's') or multiplayer(press 'm')?");

            ConsoleKeyInfo key;
            key = Console.ReadKey();
            
            var playerRepository = new PlayerRepository();
            var player = playerRepository.Get(1);

            if (player == null)
            {
                player = new Player {
                    Id = 1, Name = "Alex", SoloScore = 0, MultiScore = 0
                };
            }
            if (key.Key == ConsoleKey.S)
            {
                var soloGame = new SoloGame(player);
                soloGame.PlayOneRound();
            }
            else if (key.Key == ConsoleKey.M)
            {
                var multiPlayer = new MultiplayerGame(player);
                multiPlayer.PlayOneRound();   
            }

            playerRepository.Save(player);
        }
    }
}
