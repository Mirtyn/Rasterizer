// See https://aka.ms/new-console-template for more information
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Diagnostics;
using System.Reflection;

namespace Rasterizer.Console
{
    internal class SimplePixelRasterizer : AbstractRasterizer
    {
        Random random = new Random();

        public override void Load()
        {
            
        }

        public override void Render()
        {
            Clear();

            for (var i = 0; i < 100; i++)
            {
                Pixel(random.Next(0, Width), random.Next(0, Height));
            }
        }

        public override void Update()
        {
            
        }
    }
}
