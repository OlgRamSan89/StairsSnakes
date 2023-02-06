namespace StairsSnakesTest
{
    public class GeneratorRandom : IGeneratorRandom
    {
        public virtual int GetRandom(int n, int m)
        {
            var rnd = new Random();
            return rnd.Next(n, m);
        }
    }
}