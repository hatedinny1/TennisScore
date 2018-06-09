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

        private bool IsDiffScore()
        {
            return FirstPlayerScore != SecondPlayerScore;
        }

        private bool IsDeuce()
        {
            var isSameScore = FirstPlayerScore == SecondPlayerScore;
            return FirstPlayerScore >= 3 && isSameScore;
        }

        private string AdvPlayer()
        {
            return FirstPlayerScore > SecondPlayerScore
                ? FirstPlayerName
                : SecondPlayerName;
        }

        private bool IsAdv()
        {
            return Math.Abs(FirstPlayerScore - SecondPlayerScore) == 1;
        }

        private bool IsGamePoint()
        {
            return FirstPlayerScore > 3 || SecondPlayerScore > 3;
        }

        private static Dictionary<int, string> _scoreLookUp = new Dictionary<int, string>()
        {
            [0] = "Love",
            [1] = "Fifteen",
            [2] = "Thirty",
            [3] = "Forty"
        };

        private static string Deuce = "Deuce";

        private string ScoreLookupResult()
        {
            return $"{Game._scoreLookUp[FirstPlayerScore]} {Game._scoreLookUp[SecondPlayerScore]}";
        }

        private string GamePointState()
        {
            return IsAdv() ? $"{AdvPlayer()} Adv" : $"{AdvPlayer()} Win";
        }

        private string SameScoreResult()
        {
            return $"{Game._scoreLookUp[FirstPlayerScore]} All";
        }

        public string ScoreResult()
        {
            return IsDiffScore()
                ? (IsGamePoint() ? GamePointState() : ScoreLookupResult())
                : (IsDeuce() ? Game.Deuce : SameScoreResult());
        }
    }
}