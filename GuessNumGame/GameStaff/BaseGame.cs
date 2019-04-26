using GuessNumGame.Validators;
using System;
using Dal.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Repository;
using GuessNumGame.Services;
using GuessNumGame.Interfaces;

namespace GuessNumGame.GameStaff
{
    public abstract class BaseGame
    {
        public GameResources gameResources = new GameResources();

        public IMessageService MessageService { get; }

        public BaseGame(IMessageService messageService)
        {
            MessageService = messageService;
        }

        public void PlayOneRound()
        {
            Initialize();

            ComeUpWithNumber();

            GuessNumber(new RangeValidator(gameResources.MinValue, gameResources.MaxValue), 
                new ControlService());

            EndGame();
        }

        public void Initialize()
        {
            gameResources.Score = (gameResources.Player.Scores.ContainsKey(gameResources.GameType)) ? 
                gameResources.Player.Scores[gameResources.GameType] : AddNewGameType();
        }

        public int AddNewGameType()
        {
            gameResources.Player.Scores.Add(gameResources.GameType, gameResources.Score);
            return 0;
        }

        public abstract void ComeUpWithNumber();

        public abstract void SetMinMaxValue();

        public void GuessNumber(IValidator rangeValidator, IControlServices consolInput)
        {
            while (!gameResources.Win && gameResources.Attempt < gameResources.MaxAttempt)
            {
                WriteRoundMasseg();

                gameResources.OptionNumber = consolInput.ReadIntFromConsole(rangeValidator);

                CheckWin();
            }
        }

        public void WriteRoundMasseg()
        {
            View.Print($"Guess the number in the range of {gameResources.MinValue} to {gameResources.MaxValue}.\n" +
                    $"Attempt {++gameResources.Attempt} out of {gameResources.MaxAttempt}.\n" +
                    "Enter the number: ");
        }

        public void CheckWin()
        {
            gameResources.Win = (gameResources.OptionNumber == gameResources.HiddenNumber) ? true : GiveHelp();
        }

        public bool GiveHelp()
        {
            View.Print($"Your number {gameResources.OptionNumber} is {CheckMoreOrLess()} than hidden number.");
            return false;
        }

        public string CheckMoreOrLess()
        {
            return (gameResources.OptionNumber > gameResources.HiddenNumber) ? "more" : "less";
        }

        public void EndGame()
        {
            gameResources.Player.Scores[gameResources.GameType] += gameResources.MaxAttempt - gameResources.Attempt;

            View.Print((gameResources.Win) ? $"Congratulations, you guessed the number " +
                $"and spend {gameResources.Attempt} from {gameResources.MaxAttempt} attempt(s)!\n" +
                $"Your score: {gameResources.MaxAttempt - gameResources.Attempt}.\n" +
                $"Total score: {gameResources.Player.Scores[gameResources.GameType]}"
                : $"Sorry, next time. Number was  {gameResources.HiddenNumber}.");
        }

        public int CalcMaxAttempt(int minValue, int maxValue)
        {
            var twoPower = 2;
            var maxAttempt = 1;

            while (maxValue - minValue > twoPower)
            {
                twoPower *= 2;
                maxAttempt++;
            }

            return maxAttempt;
        }
    }
}

