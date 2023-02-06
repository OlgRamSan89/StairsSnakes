namespace StairsSnakesTest
{
    public class TokenCanMoveAcrossTheBoardTest
    {
        private IGameStairsSnakes _game;
        private List<TokenPlayer> _listTokens;
        private IGeneratorRandom _generatorRandom;

        [SetUp]
        public void Setup()
        {
            _generatorRandom = new GeneratorRandom();
            _game = new GameStairsSnakes(2, _generatorRandom);
            _listTokens = _game.GetListTokens();
        }

        [Test]
        public void Game_is_started_and_tokens_are_in_first_position()
        {
            var result = _game.IsStarted();
            var tokenPositionsAreFirst = _listTokens.All(x => x.Position == 1);
            Assert.IsTrue(result);
            Assert.IsTrue(tokenPositionsAreFirst);
        }

        [Test]
        [TestCase(1, 3)]
        [TestCase(4, 4)]
        public void Tokens_is_in_first_position_and_move_three_spaces(int position, int spaces)
        {
            var token1 = _listTokens.First();
            token1.Position = position;
            var expectedToken = new TokenPlayer
            {
                Id = token1.Id,
                Position = position + spaces,
            };

            var tokenMoved = _game.MoveToken(token1.Id, spaces);

            Assert.That(tokenMoved.Id, Is.EqualTo(expectedToken.Id));
            Assert.That(tokenMoved.Position, Is.EqualTo(expectedToken.Position));
        }
    }
}