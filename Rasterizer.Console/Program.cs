using Rasterizer.Console.Rasterizers;

namespace Rasterizer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var rasterizer = new RotatingCubeWithMatricesRasterizer())
            {
                rasterizer.Run(800, 800);
            }
        }
    }
}
