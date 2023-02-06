namespace StairsSnakesTest
{
    public class TokenCanWinTheGameTest
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
        public void When_token_move_to_100_position_win_the_game()
        {
            var token1 = _listTokens.First();
            token1.Position = 97;
            var expectedToken = new TokenPlayer
            {
                Id = token1.Id,
                Position = 100,
            };

            var tokenMoved = _game.MoveToken(token1.Id, 3);

            Assert.That(tokenMoved.Id, Is.EqualTo(expectedToken.Id));
            Assert.That(tokenMoved.Position, Is.EqualTo(expectedToken.Position));
            Assert.IsTrue(_game.IsWinner(tokenMoved));
        }

        [Test]
        public void Tokens_not_move_when_the_result_position_is_greater_than_100_then_not_win_the_game()
        {
            var token1 = _listTokens.First();
            token1.Position = 97;
            var expectedToken = new TokenPlayer
            {
                Id = token1.Id,
                Position = 97,
            };

            var tokenMoved = _game.MoveToken(token1.Id, 4);

            Assert.That(tokenMoved.Id, Is.EqualTo(expectedToken.Id));
            Assert.That(tokenMoved.Position, Is.EqualTo(expectedToken.Position));
            Assert.IsFalse(_game.IsWinner(tokenMoved));
        }
    }
}