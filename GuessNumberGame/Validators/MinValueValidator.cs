using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumberGame.Validators
{
    public class MinValueValidator : IValidator
    {
        private int minValue;
        public string Error { get; set; }

        public MinValueValidator(int minValue)
        {
            this.minValue = minValue;
        }

        public bool Valid(int value)
        {
            if(minValue > value)
            {
                Error = $"{value} is less then {minValue}.\nEnter correct number:";
                return false;
            }

            return true;
        }
    }
}
