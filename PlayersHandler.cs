
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Formats.Asn1.AsnWriter;

namespace BrainStorm
{
    public class PlayersHandler
    {
        public List<Player> Players { get; set; } = new List<Player>();
        public string PlayersFile { get; set; } = $"./Players.txt";

        public PlayersHandler()
        {
            if (File.Exists(PlayersFile) == false)
                File.Create(PlayersFile);

            else
            {
                LoadPlayers();
            }
        }

        public void SavePlayers(List<Player> players)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(players, options);
            File.WriteAllText(PlayersFile, json);
        }

        public List<Player> LoadPlayers()
        {
            string json = File.ReadAllText(PlayersFile);

            if ((json != null) && json != "")
            {
                return JsonSerializer.Deserialize<List<Player>>(json) ?? new List<Player>();
            }

            return new List<Player>();
        }
    }
}