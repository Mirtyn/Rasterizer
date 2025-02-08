using Rasterizer.Console.Rasterizers;

namespace Rasterizer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var rasterizer = new MovingCubeRasterizer())
            {
                rasterizer.Run(800, 600);
            }
        }
    }
}
