using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Core;

namespace TennisScore
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IRepository<Game> _repository = Substitute.For<IRepository<Game>>();
        private const string FirstPlayerName = "Alex";
        private const string SecondPlayerName = "Sam";
        private TennisGame _tennisGame;


        [TestInitialize]
        public void TestInit()
        {
            _tennisGame = new TennisGame(_repository);
        }

        private const int AnyGameId = 1;

        [TestMethod]
        public void Love_All()
        {
            GivenGame(0, 0);
            ScoreResultShouldBe("Love All");
        }

        [TestMethod]
        public void Fifteen_Love()
        {
            GivenGame(1, 0);
            ScoreResultShouldBe("Fifteen Love");
        }
        [TestMethod]
        public void Thirty_Love()
        {
            GivenGame(2, 0);
            ScoreResultShouldBe("Thirty Love");
        }
        [TestMethod]
        public void Forty_Love()
        {
            GivenGame(3, 0);
            ScoreResultShouldBe("Forty Love");
        }
        [TestMethod]
        public void Love_Fifteen()
        {
            GivenGame(0, 1);
            ScoreResultShouldBe("Love Fifteen");
        }
        [TestMethod]
        public void Love_Thirty()
        {
            GivenGame(0, 2);
            ScoreResultShouldBe("Love Thirty");
        }
        [TestMethod]
        public void Fifteen_All()
        {
            GivenGame(firstPlayerScore: 1, secondPlayerScore: 1);
            ScoreResultShouldBe(expected: "Fifteen All");
        }
        [TestMethod]
        public void Thirty_All()
        {
            GivenGame(firstPlayerScore: 2, secondPlayerScore: 2);
            ScoreResultShouldBe(expected: "Thirty All");
        }
        [TestMethod]
        public void Deuce()
        {
            GivenGame(firstPlayerScore: 3, secondPlayerScore: 3);
            ScoreResultShouldBe(expected: "Deuce");
        }
        [TestMethod]
        public void FirstPlayer_Adv()
        {
            GivenGame(firstPlayerScore: 4, secondPlayerScore: 3);
            ScoreResultShouldBe(expected: FirstPlayerName + " Adv");
        }
        [TestMethod]
        public void SecondPlayer_Adv()
        {
            GivenGame(firstPlayerScore: 3, secondPlayerScore: 4);
            ScoreResultShouldBe(expected: SecondPlayerName + " Adv");
        }
        [TestMethod]
        public void FirstPlayer_Win()
        {
            GivenGame(firstPlayerScore: 5, secondPlayerScore: 3);
            ScoreResultShouldBe(expected: FirstPlayerName + " Win");
        }

        private void ScoreResultShouldBe(string expected)
        {
            var scoreResult = _tennisGame.ScoreResult(AnyGameId);
            Assert.AreEqual(expected, scoreResult);
        }

        private ConfiguredCall GivenGame(int firstPlayerScore, int secondPlayerScore)
        {
            return _repository.GetGame(AnyGameId).Returns(
                new Game
                {
                    Id = AnyGameId,
                    FirstPlayerScore = firstPlayerScore,
                    SecondPlayerScore = secondPlayerScore,
                    FirstPlayerName = FirstPlayerName,
                    SecondPlayerName = SecondPlayerName
                });
        }
    }
}