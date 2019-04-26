using Dal.IRepository;
using Dal.Model;
using Dal.Repository;
using GuessNumGame.GameStaff;
using GuessNumGame.Interfaces;
using GuessNumGame.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumGame.Services
{
    public class GameServices
    {
        private IBaseRepository<PlayerModel> BaseRepository;
        private IMessageService MessageService;
        private PlayerModel Player { get; set; }


        public GameServices(IBaseRepository<PlayerModel> baseRepository, 
            IMessageService messageService)
        {
            BaseRepository = baseRepository;
            MessageService = messageService;
        }

        public void Play()
        {
            LoadPlayer();

            ChooseGameType();

            BaseRepository.Save(Player);
        }

        public void LoadPlayer()
        {
            Player = BaseRepository.Get(1) ?? CreatePlayer();
        }

        public PlayerModel CreatePlayer()
        {
            return new PlayerModel
            {
                Id = 1,
                Name = "Alex",
                Scores = new Dictionary<string, int>()
            };
        }

        public void ChooseGameType()
        {
            MessageService.ChooseGameTypeMessage();

            switch (new ControlService().ReadIntFromConsole(new GameTypeValidator()))
            {
                case 1:
                    var soloGame = new SoloGame(Player, MessageService);
                    soloGame.PlayOneRound();
                    break;
                case 2:
                    var multiPlayer = new MultiplayerGame(Player, MessageService);
                    multiPlayer.PlayOneRound();
                    break;
                default:
                    break;
            }
        }
    }
}
