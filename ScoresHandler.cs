using System.IO;

namespace BrainStorm
{
    public class ScoresHandler
    {
        public List<TimeScorePair> Scores { get; set; } = new List<TimeScorePair>();
        public string ScoresFile { get; set; } = $"./Scores.txt";

        public ScoresHandler()
        {
            if (File.Exists(ScoresFile) == false)
                File.Create(ScoresFile);

            else
            {
                LoadScores();
            }
        }

        public void LoadScores()
        {
            
        }

        public void SaveScores()
        {
        }

        public void AddScore(TimeScorePair? score)
        {
            throw new NotImplementedException();
        }
    }
}
