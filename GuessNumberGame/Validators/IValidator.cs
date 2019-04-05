using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessNumberGame.Validators
{
    public interface IValidator
    {
        string Error { get; set; }

        bool Valid(int value);
    }
}
