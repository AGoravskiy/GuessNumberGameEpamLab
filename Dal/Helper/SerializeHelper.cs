using Dal.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Helper
{
    public class SerializeHelper
    {
        public static string Serialize<T>(T model) where T : BaseModel
        {
            return JsonConvert.SerializeObject(model);
        }

        public static T Desrialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}

