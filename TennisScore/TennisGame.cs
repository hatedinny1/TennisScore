﻿using System;
using System.Collections.Generic;

namespace TennisScore
{
    public class TennisGame
    {
        private readonly IRepository<Game> _repo;

        public TennisGame(IRepository<Game> repo)
        {
            _repo = repo;
        }

        public string ScoreResult(int gameId)
        {
            var game = this._repo.GetGame(gameId);
            var scoreLookUp = new Dictionary<int, string>()
            {
                [1] = "Fifteen",
                [2] = "Thirty"
            };
            if (game.FirstPlayerScore > 0)
            {
                return $"{scoreLookUp[game.FirstPlayerScore]} Love";
            }
            
            return "Love All";
        }
    }
}