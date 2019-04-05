using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumberGame.Validators
{
    public class RangeValidator : IValidator
    {
        private int minValue;
        private int maxValue;
        public string Error { get; set; }

        public RangeValidator(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public bool Valid(int value)
        {
            if(minValue > value || maxValue < value)
            {
                Error = $"A value {value} is not in the range from {minValue} to {maxValue}.\nEnter correct number:";
                return false;
            }

            return true;
        }
    }
}
