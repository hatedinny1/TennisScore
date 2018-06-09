using System;

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

        public string AdvPlayer()
        {
            return FirstPlayerScore > SecondPlayerScore
                ? FirstPlayerName
                : SecondPlayerName;
        }

        public bool IsAdv()
        {
            return Math.Abs(FirstPlayerScore - SecondPlayerScore) == 1;
        }

        public bool IsGamePoint()
        {
            return FirstPlayerScore > 3 || SecondPlayerScore > 3;
        }
    }
}