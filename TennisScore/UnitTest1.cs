using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Core;

namespace TennisScore
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IRepository<Game> _repository = Substitute.For<IRepository<Game>>();
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
        private void ScoreResultShouldBe(string expected)
        {
            var scoreResult = _tennisGame.ScoreResult(AnyGameId);
            Assert.AreEqual(expected, scoreResult);
        }

        private ConfiguredCall GivenGame(int firstPlayerScore, int secondPlayerScore)
        {
            return _repository.GetGame(AnyGameId).Returns(new Game { Id = AnyGameId, FirstPlayerScore = firstPlayerScore, SecondPlayerScore = secondPlayerScore });
        }
    }
}