namespace StairsSnakesTest
{
    public interface IGameStairsSnakes
    {
        List<TokenPlayer> GetListTokens();
        void ListTokens(int nPlayers);
        bool IsStarted();
        bool IsWinner(TokenPlayer tokenMoved);
        TokenPlayer MoveToken(int id, int spaces);
        int RollDie(TokenPlayer token);
    }
}