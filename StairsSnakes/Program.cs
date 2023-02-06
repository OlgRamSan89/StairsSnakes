// See https://aka.ms/new-console-template for more information
using StairsSnakesTest;
using System.Runtime.ConstrainedExecution;

Console.WriteLine("To Start Staris & Snakes, insert players number:");
string nPlayers = Console.ReadLine();
int result = 0;
if (Int32.TryParse(nPlayers, out result) && result > 1)
{
    IGameStairsSnakes newGame = new GameStairsSnakes(result, new GeneratorRandom());
    List<TokenPlayer> players = newGame.GetListTokens();
    while (newGame.IsStarted())
    {
        foreach (var player in players)
        {
            Console.WriteLine("Player {0} press a key to roll die", player.Id + 1);
            Console.ReadKey();
            var dieResult = newGame.RollDie(player);
            if (player.Position == 100)
            {
                Console.WriteLine("\n{0}!! YOU WIN Player {1}!!!!! ", dieResult, player.Id + 1);
                break;
            }
            Console.WriteLine("\n{0}!! Your position is {1}", dieResult, player.Position);
        }
    }
}
