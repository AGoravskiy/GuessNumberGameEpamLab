using Dal.Model;
using GuessNumGame.GameStaff;
using GuessNumGame.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Repository;
using GuessNumGame.Services;
using System.Reflection;

namespace GuessNumGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("                 *******Welcom to GuessNumberGame!*******\n");

            var playerRepository = new PlayerRepository();
            var messageService = new ConsoleMessageService();
            var service = new GameServices(playerRepository, messageService);

            service.Play();

            Console.ReadLine();
        }
    }
}
