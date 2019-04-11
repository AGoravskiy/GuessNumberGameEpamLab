using Dal.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dal.Repository
{
    class PlayerRepository
    {
        public Player GetPlayer()
        {
            return null;
        }

        public void SavePlayer(Player player)
        {
            var appPath = Environment.CurrentDirectory;
            var folderPath = "Player";
            var fileName = $"{player.Id}.json";
            var path = Path.Combine(appPath, folderPath, fileName);
            var json = Serialize(player);

            using (var sw = new StreamWriter(path))
            {
                sw.Write(json);
            }  
        }

        private string Serialize(Player player)
        {
            return JsonConvert.SerializeObject(player);
        }
    }
}
