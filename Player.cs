using System.IO;

namespace BrainStorm
{
    public class Player
    {
        public string Name { get; set; } = "";
        public DateTime? DateOfBirth { get; set; } = null;
        public List<TimeScorePair> ScoreList { get; set; } = new List<TimeScorePair>();

        public Player(string playerName, DateTime? dateOfBirth)
        {
            if (LoadPlayerFromFile(playerName, "Player_" + playerName) == true)
            {
                Name = playerName;
            }
            else
            {
                Name = playerName;
                DateOfBirth = dateOfBirth;
            }
        }

        private bool LoadPlayerFromFile(string playerName, string playerFile)
        {
            string playerFileText = "";

            try
            {
                playerFileText = File.ReadAllText(playerFile);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
