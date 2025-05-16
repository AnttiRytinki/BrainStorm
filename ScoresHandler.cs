using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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

        public void SaveScores()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(Scores, options);
            File.WriteAllText(ScoresFile, json);
        }

        public void LoadScores()
        {
            if (File.Exists(ScoresFile))
            {
                string json = File.ReadAllText(ScoresFile);
                Scores = JsonSerializer.Deserialize<List<TimeScorePair>>(json) ?? new List<TimeScorePair>();
            }

            else
            {
                Scores = new List<TimeScorePair>();
            }
        }

        public void AddScore(TimeScorePair? score)
        {
            if (score != null)
                Scores.Add(score);
        }
    }
}
