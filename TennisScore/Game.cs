namespace TennisScore
{
    public class Game
    {
        public int SecondPlayerScore { get; set; }
        public int FirstPlayerScore { get; set; }
        public int Id { get; set; }
        public string FirstPlayerName { get; set; }
        public string SecondPlayerName { get; set; }

        public bool IsDiffScore()
        {
            return FirstPlayerScore != SecondPlayerScore;
        }

        public bool IsDeuce()
        {
            var isSameScore = FirstPlayerScore == SecondPlayerScore;
            return FirstPlayerScore >= 3 && isSameScore;
        }
    }
}