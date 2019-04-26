using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumGame.Validators
{
    class GameTypeValidator : IValidator
    {
        public string Error { get; set; }

        public bool Valid(int value)
        {
            switch (value)
            {
                case 1:
                    return true;
                case 2:
                    return true;
                default:
                    Error = $"Enter correct number:";
                    return false;
            };
        }
    }
}
