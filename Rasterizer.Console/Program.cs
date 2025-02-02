using Rasterizer.Console.Samples;

namespace Rasterizer.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.WriteLine("test");

            TestGame game = new TestGame("Test_1", 800, 600);
            game.Run();
        }
    }
}