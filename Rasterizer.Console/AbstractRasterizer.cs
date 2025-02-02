// See https://aka.ms/new-console-template for more information
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System.Diagnostics;

namespace Rasterizer.Console
{
    internal abstract class AbstractRasterizer : IDisposable
    {
        Window? window = null;

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
            };

            using (window = new Window(GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Load += InternalLoad;
                window.UpdateFrame += InternalUpdateFrame;
                window.RenderFrame += InternalRenderFrame;

                window.Run();
            }

            Debug.WriteLine("Closing in 1 second...");

            Thread.Sleep(1000);
        }

        private void InternalLoad()
        {
            Load();
        }

        private void InternalUpdateFrame(FrameEventArgs a) 
        { 
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
