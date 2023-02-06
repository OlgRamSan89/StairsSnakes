using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace StairsSnakesTest
{
    public class GameStairsSnakes:IGameStairsSnakes
    {
        private bool _isStarted;
        private List<TokenPlayer> _tokens;
        private IGeneratorRandom _die;
        private const int WINNER_POSITION = 100;
        public GameStairsSnakes(int nPlayers, IGeneratorRandom die)
        {
            _isStarted = true;
            _tokens = new List<TokenPlayer>();
            _die = die;
            ListTokens(nPlayers);
        }

        public bool IsStarted()
        {
            return _isStarted;
        }
        public List<TokenPlayer> GetListTokens()
        {
            return _tokens;
        }

        public void ListTokens(int nPlayers)
        {
            _tokens = new List<TokenPlayer>();
            for (var i = 0; nPlayers > i; i++)
            {
                _tokens.Add(new TokenPlayer
                {
                    Id = i,
                    Position = 1,
                });
            }
        }

        public TokenPlayer MoveToken(int idToken, int spaces)
        {
            TokenPlayer tokenMoved = _tokens.FirstOrDefault(x => x.Id == idToken);
            tokenMoved.Position = CalculatePosition(spaces, tokenMoved.Position);
            return tokenMoved;
        }
        public bool IsWinner(TokenPlayer tokenMoved)
        {
            return tokenMoved.Position == WINNER_POSITION;
        }

        public int RollDie(TokenPlayer token)
        {
            int result = _die.GetRandom(1, 7);
            MoveToken(token.Id, result);
            return result;
        }

        private int CalculatePosition(int spaces, int position)
        {
            var resultPosition = position + spaces;
            if (resultPosition == WINNER_POSITION)
            {
                _isStarted = false;
            }
            return resultPosition > 100 ? position : resultPosition;
        }

    }
}