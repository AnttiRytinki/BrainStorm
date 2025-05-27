namespace BrainStorm
{
    public class Score
    {
        public Player? Player { get; set; } = null;
        public DateTime DateTime { get; set; } = DateTime.Now;
        public int ScoreValue { get; set; } = -1;
    }
}