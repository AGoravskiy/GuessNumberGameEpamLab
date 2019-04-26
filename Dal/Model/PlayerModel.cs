using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Model
{
    public class PlayerModel : BaseModel
    {
        public string Name { get; set; }

        public Dictionary<string, int> Scores { get; set; }
    }
}
