﻿// See https://aka.ms/new-console-template for more information
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Diagnostics;
using System.Reflection;

namespace Rasterizer.Console
{
    abstract class AbstractRasterizer
    {
        Window? window = null;

        protected abstract void Load();

        protected abstract void Update();

        protected abstract void Render();

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
    }
}
