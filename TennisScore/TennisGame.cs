using System;
using System.Collections.Generic;

namespace TennisScore
{
    public class TennisGame
    {
        private readonly IRepository<Game> _repo;

        private readonly Dictionary<int, string> _scoreLookUp = new Dictionary<int, string>()
        {
            [0]="Love",
            [1] = "Fifteen",
            [2] = "Thirty",
            [3] = "Forty"
        };

        public TennisGame(IRepository<Game> repo)
        {
            _repo = repo;
        }

        public string ScoreResult(int gameId)
        {
            var game = this._repo.GetGame(gameId);
            if (game.IsDiffScore())
            {
                return $"{_scoreLookUp[game.FirstPlayerScore]} {_scoreLookUp[game.SecondPlayerScore]}";
            }
            if (game.IsDeuce())
            {
                return "Deuce";
            }
            return $"{_scoreLookUp[game.FirstPlayerScore]} All";
        }
    }
}