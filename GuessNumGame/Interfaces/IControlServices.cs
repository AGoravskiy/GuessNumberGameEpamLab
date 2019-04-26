using GuessNumGame.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumGame.Interfaces
{
    public interface IControlServices
    {
        int ReadIntFromConsole(IValidator validator = null);

        string CheckNullOrEmpty(string input, IValidator validator = null);

        void TryParseString(string input, out int num);
    }
}
