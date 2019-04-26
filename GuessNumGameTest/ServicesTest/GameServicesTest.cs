using System;
using System.Collections.Generic;
using System.Text;
using Dal.IRepository;
using Dal.Model;
using GuessNumGame.Interfaces;
using GuessNumGame.Services;
using Moq;
using NUnit.Framework;

namespace GuessNumGameTest.ServicesTest
{
    public class GameServicesTest
    {
        private IBaseRepository<PlayerModel> Rep { get; set; }
        private IMessageService MessageService { get; set; }
        private PlayerModel Player { get; set; }
        private GameServices gameServices;

        [SetUp]
        public void Setup()
        {
            gameServices = new GameServices(Rep, MessageService);
        }

        [Test]
        public void GameServices_CreatePlayerTest()
        {
            var player = gameServices.CreatePlayer();
            Assert.That(player, Is.Not.Null);
        }

        //[Test]
        //public void LoadPlayerTest()
        //{
        //    Player
        //    Rep.
        //    gameServices.LoadPlayer();
        //}
    }
}
