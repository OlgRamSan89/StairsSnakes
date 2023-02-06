using Moq;
using Newtonsoft.Json.Linq;

namespace StairsSnakesTest
{
    public class MovesAreDeterminedByDiceRollsTest
    {
        IGameStairsSnakes _game;
        List<TokenPlayer> _listTokens;
        IGeneratorRandom _generatorRandom;
        [SetUp]
        public void Setup()
        {
            _generatorRandom = new GeneratorRandom();
            _game = new GameStairsSnakes(2,_generatorRandom);
            _listTokens = _game.GetListTokens();
        }

        [Test]
        public void When_player_rolls_a_die_must_be_between_1_and_6()
        {
            var token1 = _listTokens.First();
            var tokenPosition = token1.Position;

            var resultDie = _game.RollDie(token1);

            Assert.That(resultDie, Is.GreaterThanOrEqualTo(1));
            Assert.That(resultDie, Is.LessThanOrEqualTo(6));
        }

        [Test]
        public void When_player_rolls_a_4_then_token_moves_4_spaces()
        {
            var spaces = 4;
            Mock<IGeneratorRandom> mockRnd = new Mock<IGeneratorRandom>();
            mockRnd.Setup(x => x.GetRandom(It.IsAny<int>(),It.IsAny<int>())).Returns(spaces);
            var randomMock = mockRnd.Object;
            _game = new GameStairsSnakes(2, randomMock);
            var token1 = _game.GetListTokens().First();
            token1.Position = 5;
            var expectedToken = CreateToken(token1.Id, token1.Position + spaces);

            var result = _game.RollDie(token1);

            mockRnd.Verify(x => x.GetRandom(It.IsAny<int>(),It.IsAny<int>()), Times.Once);
            Assert.That(token1.Id, Is.EqualTo(expectedToken.Id));
            Assert.That(token1.Position, Is.EqualTo(expectedToken.Position));
        }

        private TokenPlayer CreateToken(int idExpectedToken, int positionExpectedToken)
        {
            return new TokenPlayer
            {
                Id = idExpectedToken,
                Position = positionExpectedToken,
            };
        }
    }
}