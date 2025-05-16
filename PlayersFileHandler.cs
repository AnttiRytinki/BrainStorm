
using System.IO;

namespace BrainStorm
{
    public class PlayersHandler
    {
        public List<Player> Players { get; set; } = new List<Player>();

        public PlayersHandler()
        {
            if (File.Exists($"./Players.txt") == false)
                File.Create($"./Players.txt");

            else
            {

            }
        }

        public void AddPlayer(Player? player)
        {
            throw new NotImplementedException();
        }
    }
}