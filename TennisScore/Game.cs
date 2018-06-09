using System;
using System.Collections.Generic;

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

        public static Dictionary<int, string> _scoreLookUp = new Dictionary<int, string>()
        {
            [0] = "Love",
            [1] = "Fifteen",
            [2] = "Thirty",
            [3] = "Forty"
        };

        public static string Deuce = "Deuce";

        public string ScoreLookupResult()
        {
            return $"{Game._scoreLookUp[FirstPlayerScore]} {Game._scoreLookUp[SecondPlayerScore]}";
        }

        public string GamePointState()
        {
            return IsAdv() ? $"{AdvPlayer()} Adv" : $"{AdvPlayer()} Win";
        }

        public string SameScoreResult()
        {
            return $"{Game._scoreLookUp[FirstPlayerScore]} All";
        }
    }
}