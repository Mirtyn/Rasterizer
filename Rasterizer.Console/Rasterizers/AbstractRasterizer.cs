// See https://aka.ms/new-console-template for more information
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using Rasterizer.Library.Mathmatics;
using System.Diagnostics;

namespace Rasterizer.Console.Rasterizers
{
    internal abstract class AbstractRasterizer : IDisposable
    {
        Window? window = null;

        public float ElapsedTime = 0.0f;
        public float TotalGameTime = 0.0f;

        DateTime _fpsTime; // marks the beginning the measurement began
        int _fpsCounter; // an increasing count
        int _fps; // the FPS calculated from the last measurement

        public virtual void Load()
        {

        }

        public virtual void Update()
        {
        }

        public abstract void Render();

        public void Run(int width, int height)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                ClientSize = (width, height),
                Title = "Rasterizer - Console Window",
                Profile = ContextProfile.Compatability, // needed for OpenGL Immediate Mode
                WindowBorder = WindowBorder.Hidden,
                //APIVersion = new System.Version(3, 2),
            };

            using (window = new Window(GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Load += InternalLoad;
                window.UpdateFrame += InternalUpdateFrame;
                window.RenderFrame += InternalRenderFrame;

                window.Run();
            }

            System.Console.WriteLine("Closing in 1 second...");

            Thread.Sleep(1000);
        }

        private void InternalLoad()
        {
            Load();
        }

        private void InternalUpdateFrame(FrameEventArgs a)
        {
            ElapsedTime = (float)a.Time;
            TotalGameTime += (float)a.Time;

            _fpsCounter++;

            if ((DateTime.Now - _fpsTime).TotalSeconds >= 1)
            {
                // one second has elapsed 

                _fps = _fpsCounter;
                _fpsCounter = 0;
                _fpsTime = DateTime.Now;

                System.Console.WriteLine($"FPS: {_fps} Elapsed time: {ElapsedTime.ToString("0.00")} Total time: {TotalGameTime.ToString("0.00")}");
            }

            Update();
        }

        private void InternalRenderFrame(FrameEventArgs a)
        {
            Render();
        }

        public void Clear()
        {
            window?.Clear();
        }

        public void Pixel(int x, int y, float r = 1f, float g = 1f, float b = 1f)
        {
            window?.Pixel(x, y, r, g, b);
        }

        public void Pixel(Vector2 v, float r = 1f, float g = 1f, float b = 1f)
        {
            window?.Pixel((int)v.X, (int)v.Y, r, g, b);
        }

        public void Pixel(Vector3 v, float r = 1f, float g = 1f, float b = 1f)
        {
            window?.Pixel((int)v.X, (int)v.Y, r, g, b);
        }

        public void FillSquare(int x1, int y1, int x2, int y2, float r = 1f, float g = 1f, float b = 1f)
        {
            window?.FillSquare(x1, y1, x2, y2, r, g, b);
        }

        public void FillSquare(Vector2 v1, Vector2 v2, float r = 1f, float g = 1f, float b = 1f)
        {
            window?.FillSquare((int)v1.X, (int)v1.Y, (int)v2.X, (int)v2.Y, r, g, b);
        }

        public void FillSquare(Vector3 v1, Vector3 v2, float r = 1f, float g = 1f, float b = 1f)
        {
            window?.FillSquare((int)v1.X, (int)v1.Y, (int)v2.X, (int)v2.Y, r, g, b);
        }

        public void DrawLine(int x1, int y1, int x2, int y2, float r = 1f, float g = 1f, float b = 1f)
        {
            window?.DrawLine(x1, y1, x2, y2, r, g, b);
        }

        public void DrawLine(Vector2 v1, Vector2 v2, float r = 1f, float g = 1f, float b = 1f)
        {
            window?.DrawLine((int)v1.X, (int)v1.Y, (int)v2.X, (int)v2.Y, r, g, b);
        }

        public void DrawLine(Vector3 v1, Vector3 v2, float r = 1f, float g = 1f, float b = 1f)
        {
            window?.DrawLine((int)v1.X, (int)v1.Y, (int)v2.X, (int)v2.Y, r, g, b);
        }

        public void DrawTriangle(int x1, int y1, int x2, int y2, int x3, int y3, float r = 1f, float g = 1f, float b = 1f)
        {
            DrawLine(x1, y1, x2, y2, r, g, b);
            DrawLine(x2, y2, x3, y3, r, g, b);
            DrawLine(x3, y3, x1, y1, r, g, b);
        }

        public void DrawTriangle(Vector2 v1, Vector2 v2, Vector2 v3, float r = 1f, float g = 1f, float b = 1f)
        {
            DrawLine((int)v1.X, (int)v1.Y, (int)v2.X, (int)v2.Y, r, g, b);
            DrawLine((int)v2.X, (int)v2.Y, (int)v3.X, (int)v3.Y, r, g, b);
            DrawLine((int)v3.X, (int)v3.Y, (int)v1.X, (int)v1.Y, r, g, b);
        }

        public void DrawTriangle(Vector3 v1, Vector3 v2, Vector3 v3, float r = 1f, float g = 1f, float b = 1f)
        {
            DrawLine((int)v1.X, (int)v1.Y, (int)v2.X, (int)v2.Y, r, g, b);
            DrawLine((int)v2.X, (int)v2.Y, (int)v3.X, (int)v3.Y, r, g, b);
            DrawLine((int)v3.X, (int)v3.Y, (int)v1.X, (int)v1.Y, r, g, b);
        }

        public void Dispose()
        {
            window?.Dispose();
        }

        public int Width
        {
            get
            {
                return window == null ? 0 : window.ClientSize.X;
            }
        }

        public int Height
        {
            get { return window == null ? 0 : window.ClientSize.Y; }
        }
    }
}
