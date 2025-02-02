using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Rasterizer.Console
{
    public class RasterizeWindow
    {
        private struct PixelEntry
        {
            public int X;
            public int Y;
            public float R;
            public float G;
            public float B;

            public PixelEntry()
            {
                X = 0; 
                Y = 0; 
                R = 1f; 
                G = 1f; 
                B = 1f;
            }
        }

        private PixelEntry[] PixelEntryArray;
        private int PixelEntryArrayIndex = 0;

        public RasterizeWindow(int width, int height)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                ClientSize = (width, height),
                Title = "Rasterizer - Console Window",
                Profile = ContextProfile.Compatability, // needed for OpenGL Immediate Mode
                WindowBorder = WindowBorder.Hidden,
            };

            using (Window window = new Window(GameWindowSettings.Default, nativeWindowSettings))
            {


                window.Run();
            }
        }

        public void Clear()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        public void Pixel(int x, int y, float r = 1f, float g = 1f, float b = 1f)
        {
            PixelEntryArray[PixelEntryArrayIndex].X = x;
            PixelEntryArray[PixelEntryArrayIndex].Y = y;
            PixelEntryArray[PixelEntryArrayIndex].R = r;
            PixelEntryArray[PixelEntryArrayIndex].G = g;
            PixelEntryArray[PixelEntryArrayIndex].B = b;
        }
    }
}
