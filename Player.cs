using System.IO;

namespace BrainStorm
{
    public class Player
    {
        public string Name { get; set; } = "";
        public DateTime? DateOfBirth { get; set; } = null;

        public Player(string playerName, DateTime? dateOfBirth)
        {
            Name = playerName;
            DateOfBirth = dateOfBirth;
        }
    }
}
