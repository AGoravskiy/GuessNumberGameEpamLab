using Dal.IRepository;
using Dal.Model;
using GuessNumGame.GameStaff;
using GuessNumGame.Interfaces;
using GuessNumGame.Services;
using GuessNumGame.Validators;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MultiplayerGameTest
{
    public class MultiplayerGameTest
    {
        private Mock<IPlayerRepository> Rep { get; set; }
        private Mock<IMessageService> MessageService { get; set; }
        private GameServices Servise { get; set; }
        private PlayerModel Player { get; set; }
        private MultiplayerGame MultiPlayer { get; set; }
        private Mock<IValidator> Validator { get; set; }
        private Mock<IControlServices> ControlServices { get; set; }

        [SetUp]
        public void Setup()
        {
            Rep = new Mock<IPlayerRepository>();
            MessageService = new Mock<IMessageService>();
            Servise = new GameServices(Rep.Object, MessageService.Object);
            Player = new PlayerModel()
            {
                Name = "Alexey",
                Scores = new Dictionary<string, int>()
            };
            MultiPlayer = new MultiplayerGame(Player, MessageService.Object);
            Validator = new Mock<IValidator>();
            ControlServices = new Mock<IControlServices>();
            MultiPlayer.gameResources.GameType = "Multiplayer";
        }

        [Test]
        public void EndGame_TotalScoreTest()
        {
            MultiPlayer.gameResources.Player.Scores["Multiplayer"] = 0;
            var expeced = 6;
            
            MultiPlayer.gameResources.MaxAttempt = 12;
            MultiPlayer.gameResources.Attempt = 6;
            
            MultiPlayer.EndGame();

            Assert.IsTrue(expeced == MultiPlayer.gameResources.Player.Scores["Multiplayer"]);
        }

        [Test]
        public void CalcMaxAttempt_TotalScoreTest()
        {
            MultiPlayer.gameResources.MinValue = 1;
            MultiPlayer.gameResources.MaxValue = 100;

            var calcMaxAttempt = MultiPlayer.CalcMaxAttempt(MultiPlayer.gameResources.MinValue, 
                MultiPlayer.gameResources.MaxValue);

            var expected = 7;

            Assert.IsTrue(expected == calcMaxAttempt);
        }

        [Test]
        public void CheckMoreOrLessTest()
        {
            MultiPlayer.gameResources.OptionNumber = 10;
            MultiPlayer.gameResources.HiddenNumber = 100;

            var expected = MultiPlayer.CheckMoreOrLess();

            Assert.IsTrue(expected == "less");
        }

        [Test]
        public void GiveHelpTest()
        {
            var expected = MultiPlayer.GiveHelp();

            Assert.IsFalse(expected);
        }

        [Test]
        public void CheckWinTest_True()
        {
            MultiPlayer.gameResources.OptionNumber = 100;
            MultiPlayer.gameResources.HiddenNumber = 100;

            MultiPlayer.CheckWin();

            Assert.IsTrue(MultiPlayer.gameResources.Win);
        }

        [Test]
        public void AddNewGameTypeTest()
        {
            var gameNumber = Player.Scores.Count;
            MultiPlayer.gameResources.Score = 0;

            MultiPlayer.AddNewGameType();

            Assert.IsTrue(Player.Scores.Count == gameNumber + 1);
        }

        [Test]
        [TestCase(1)]
        [TestCase(34)]
        [TestCase(446)]
        public void Initialize_TakeExistingScore(int score)
        {
            var gameNumber = Player.Scores.Count;
            MultiPlayer.gameResources.Score = score;

            MultiPlayer.gameResources.Player.Scores.Add(MultiPlayer.gameResources.GameType,
                MultiPlayer.gameResources.Score);

            MultiPlayer.Initialize();

            var scoreWhichPlayerHasAfterInitialize =
                MultiPlayer.gameResources.Player.Scores[MultiPlayer.gameResources.GameType];

            Assert.AreEqual(scoreWhichPlayerHasAfterInitialize, score);
        }

        [Test]
        public void Initialize_AddNewGameType()
        {

            MultiPlayer.Initialize();
            
            Assert.That(Player.Scores.Count, Is.Not.EqualTo(0));
        }
    }
}