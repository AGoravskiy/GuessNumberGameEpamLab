using System;
using System.Collections.Generic;
using System.Text;

namespace Dal.Model
{
    public class GameResources : BaseModel
    {
        public int HiddenNumber { get; set; }

        public int OptionNumber { get; set; }

        public int MinValue { get; set; }

        public int MaxValue { get; set; }

        public int Attempt { get; set; }

        public int MaxAttempt { get; set; }

        public bool Win { get; set; }

        public string GameType { get; set; }

        public int Score { get; set; }

        public PlayerModel Player { get; set; }
    }
}
