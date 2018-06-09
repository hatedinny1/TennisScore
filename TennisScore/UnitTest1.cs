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