using Dal.Model;
using GuessNumGame.Services;
using GuessNumGame.Validators;
using GuessNumGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumGame.GameStaff
{
    public class MultiplayerGame : BaseGame
    {
        public MultiplayerGame(PlayerModel player, IMessageService messageService) 
            : base (messageService)
        {
            gameResources.Player = player;
            gameResources.GameType = "Multiplayer";
        }

        public override void ComeUpWithNumber()
        {

            SetMinMaxValue();

            var rangeValidator = new RangeValidator(gameResources.MinValue, gameResources.MaxValue);

            View.Print("Player 1 pleas enter the number: ");
            gameResources.HiddenNumber = new ControlService().ReadIntFromConsole(rangeValidator);

            MessageService.ReadyToStart();

            gameResources.MaxAttempt = CalcMaxAttempt(gameResources.MinValue, gameResources.MaxValue);
        }

        public override void SetMinMaxValue()
        {
            var consolInput = new ControlService();

            Console.Clear();
            View.Print("Player 1 pleas enter min value of the range: ");
            gameResources.MinValue = consolInput.ReadIntFromConsole();

            View.Print("Player 1 pleas enter max value of the range: ");
            var minValueValidator = new MinValueValidator(gameResources.MinValue);
            gameResources.MaxValue = consolInput.ReadIntFromConsole(minValueValidator);
        }
    }
}
