using Dal.Model;
using GuessNumGame.Interfaces;
using GuessNumGame.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumGame.GameStaff
{
    class SoloGame : BaseGame
    {
        Random random = new Random();

        public SoloGame(PlayerModel player, IMessageService messageService) 
             : base (messageService)
        {
            gameResources.Player = player;
            gameResources.GameType = "Solo";
        }

        public override void ComeUpWithNumber()
        {
            Console.Clear();

            SetMinMaxValue();
            
            gameResources.HiddenNumber = random.Next(gameResources.MinValue, gameResources.MaxValue);

            gameResources.MaxAttempt = CalcMaxAttempt(gameResources.MinValue, gameResources.MaxValue);
        }

        public override void SetMinMaxValue()
        {
            gameResources.MinValue = random.Next(1, 50);
            gameResources.MaxValue = random.Next(gameResources.MinValue + 2, 100);
        }
    }
}
