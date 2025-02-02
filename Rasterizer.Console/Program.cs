
namespace Rasterizer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var rasterizer = new MovingPixelRasterizer())
            {
                rasterizer.Run(800, 600);
            }
        }
    }
}
