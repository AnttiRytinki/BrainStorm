using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace BrainStorm
{
    public class ScoresHandler
    {
        public List<Score> Scores { get; set; } = new List<Score>();
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
                Scores = JsonSerializer.Deserialize<List<Score>>(json) ?? new List<Score>();
            }

            else
            {
                Scores = new List<Score>();
            }
        }

        public void AddScore(Score? score)
        {
            if (score != null)
                Scores.Add(score);
        }
    }
}
