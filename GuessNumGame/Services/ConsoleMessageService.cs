using GuessNumGame.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumGame.Services
{
    public class ConsoleMessageService : IMessageService
    {
        public void ReadyToStart()
        {
            Console.Clear();
            Console.WriteLine("Player 2 are you ready to guess the number?");
            Input.ReadLineFromKeybord();
            Console.Clear();
        }

        public void ChooseGameTypeMessage()
        {
            View.Print("Do you want play single(press '1') or multiplayer(press '2')?");
        }
    }
}
