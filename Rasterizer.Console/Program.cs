using Rasterizer.Console.Rasterizers;

namespace Rasterizer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var rasterizer = new RotatingCubeRasterizer())
            {
                rasterizer.Run(800, 800);
            }
        }
    }
}
