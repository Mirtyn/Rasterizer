// See https://aka.ms/new-console-template for more information
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Diagnostics;
using System.Reflection;

namespace Rasterizer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var rasterizer = new SimplePixelRasterizer())
            {
                rasterizer.Run(800, 600);
            }
        }
    }
}
