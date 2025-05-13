using System.IO;

namespace BrainStorm
{
    public class User
    {
        public string NickName { get; set; } = "";
        public List<TimeScorePair> ScoreList { get; set; } = new List<TimeScorePair>();

        public User(string nickName)
        {
            if (LoadUserFromFile(nickName, "User_" + nickName) == true)
                NickName = nickName;
        }

        private bool LoadUserFromFile(string nickName, string userFile)
        {
            string userFileText = "";

            try
            {
                userFileText = File.ReadAllText(userFile);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
