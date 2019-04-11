using Dal.Helper;
using Dal.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Repository
{
    public class PlayerRepository
    {
        public string AppPath = Environment.CurrentDirectory;
        public string FolderName = "Player";

        public PlayerRepository()
        {
            var folderPath = Path.Combine(AppPath, FolderName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        public Player Get(int id)
        {
            var fileName = $"{id}.json";
            var path = Path.Combine(AppPath, FolderName, fileName);

            if (!File.Exists(path))
            {
                return null;
            }

            using (var sr = new StreamReader(path))
            {
                var json = sr.ReadToEnd();
                return SerializeHelper.Desrialize<Player>(json);
            }
        }

        public void Save(Player player)
        {
            var fileName = $"{player.Id}.json";

            var path = Path.Combine(AppPath, FolderName, fileName);
            var json = SerializeHelper.Serialize(player);

            using (var sw = new StreamWriter(path))
            {
                sw.Write(json);
            }
        }
    }
}
