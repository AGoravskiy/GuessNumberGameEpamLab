using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Model
{
    public class Player : BaseModel
    {
        public string Name { get; set; }

        public int SoloScore { get; set; }

        public int MultiScore { get; set; }
    }
}
