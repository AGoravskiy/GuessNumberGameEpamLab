using GuessNumGame.Interfaces;
using GuessNumGame.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumGame.Services
{
    public class ControlService : IControlServices
    {
        public int ReadIntFromConsole(IValidator validator = null)
        {
            var input = Input.ReadLineFromKeybord();
            int number = 0;

            do
            {
                CheckNullOrEmpty(input, validator);

                TryParseString(input, out number);

            } while (!validator?.Valid(number) ?? false);

            return number;
        }

        public string CheckNullOrEmpty(string input, IValidator validator = null)
        {
            if (!string.IsNullOrEmpty(validator?.Error))
            {
                View.Print(validator.Error);
                input = Input.ReadLineFromKeybord();
            }

            return input;
        }

        public void TryParseString(string input, out int num)
        {
            while (!int.TryParse(input, out num))
            {
                View.Print("It's not a number. Pleas enter the number: ");
                input = Input.ReadLineFromKeybord();
            }
        }
    }
}
