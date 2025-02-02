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
        static Window? window = null;

        static void Main(string[] args)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                ClientSize = (800, 600),
                Title = "Rasterizer - Console Window",
                Profile = ContextProfile.Compatability, // needed for OpenGL Immediate Mode
                WindowBorder = WindowBorder.Hidden,
            };

            using (window = new Window(GameWindowSettings.Default, nativeWindowSettings))
            {
                //window.Load += SetupRasterizer;
                window.UpdateFrame += UpdateRasterizer;

                window.Run();
            }

            Debug.WriteLine("Closing in 1 second...");

            Thread.Sleep(1000);
        }

        private static void UpdateRasterizer(FrameEventArgs obj)
        {
            window.Clear();

            var random = new Random();

            for (var i = 0; i < 100; i++)
            {
                window.Pixel(random.Next(0, window.ClientSize.X), random.Next(0, window.ClientSize.Y));
            }
        }

        //private static void SetupRasterizer()
        //{
        //    var random = new Random();

        //    for (var i = 0; i < 100; i++)
        //    {
        //        window.Pixel(random.Next(0, window.ClientSize.X), random.Next(0, window.ClientSize.Y));
        //    }
        //}
    }
}
