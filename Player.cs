using System.IO;

namespace BrainStorm
{
    public class Player
    {
        public string Name { get; set; } = "";

        public Player(string playerName)
        {
            Name = playerName;
        }
    }
}
