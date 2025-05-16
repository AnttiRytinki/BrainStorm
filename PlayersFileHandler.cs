
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

        public void SavePlayers()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(Players, options);
            File.WriteAllText(PlayersFile, json);
        }

        public void LoadPlayers()
        {
            if (File.Exists(PlayersFile))
            {
                string json = File.ReadAllText(PlayersFile);
                Players = JsonSerializer.Deserialize<List<Player>>(json) ?? new List<Player>();
            }

            else
            {
                Players = new List<Player>();
            }
        }

        public void AddPlayer(Player? player)
        {
            if (player != null)
                Players.Add(player);
        }
    }
}