using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumGame.Interfaces
{
    public interface IMessageService
    {
        void ReadyToStart();

        void ChooseGameTypeMessage();
    }
}
