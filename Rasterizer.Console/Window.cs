using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Diagnostics;

namespace Rasterizer.Console
{
    public class Window : GameWindow
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

        private Matrix4 ProjectionMatrix;
        private PixelEntry[] PixelEntryArray;
        private int PixelEntryArrayIndex = 0;

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
            PixelEntryArray = new PixelEntry[(int)(Size.X * Size.Y)];
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            Debug.WriteLine(GL.GetString(StringName.Vendor));
            Debug.WriteLine(GL.GetString(StringName.Renderer));
            Debug.WriteLine(GL.GetString(StringName.Version));
            Debug.WriteLine(GL.GetString(StringName.ShadingLanguageVersion));

            GL.Disable(EnableCap.DepthTest);
            GL.Disable(EnableCap.Texture2D);
            GL.Disable(EnableCap.CullFace);
            GL.Disable(EnableCap.Blend);

            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            VSync = VSyncMode.On;

            Clear();

            SwapBuffers();

            Clear();
        }

        protected override void OnUnload()
        {
            base.OnUnload();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            ProjectionMatrix = Matrix4.CreateOrthographicOffCenter(0, Size.X, 0, -Size.Y, 0.1f, 1000f);

            GL.Viewport(0, 0, Size.X, Size.Y);

            int pixelArrayLength = (int)(Size.X * Size.Y);

            if(pixelArrayLength != PixelEntryArray.Length)
            {
                PixelEntryArray = new PixelEntry[pixelArrayLength];
                PixelEntryArrayIndex = 0;

                for(var i = 0; i < pixelArrayLength; i++)
                {
                    PixelEntryArray[0] = new PixelEntry();
                }
            }
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            if (KeyboardState.IsKeyDown(Keys.C))
            {
                Clear();
            }
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref ProjectionMatrix);

            GL.PointSize(1);
            GL.Begin(PrimitiveType.Points);

            for (int i = 0; i < PixelEntryArrayIndex; i++)
            {
                var p = PixelEntryArray[i];

                GL.Color3(p.R, p.G, p.B);
                GL.Vertex3(p.X, p.Y - Size.Y + 1, -10.0f);
            }

            PixelEntryArrayIndex = 0;

            GL.End();

            SwapBuffers();
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

            PixelEntryArrayIndex++;
        }

        public void FillSquare(int x1, int y1, int x2, int y2, float r = 1f, float g = 1f, float b = 1f)
        {
            //Clip(x1, y1);
            //Clip(x2, y2);
            for (int x = x1; x < x2; x++)
            {
                for (int y = y1; y < y2; y++)
                {
                    Pixel(x, y, r, g, b);
                }
            }
        }

        public void DrawLine(int x1, int y1, int x2, int y2, float r = 1f, float g = 1f, float b = 1f)
        {
            int x, y, dx, dy, dx1, dy1, px, py, xe, ye, i;
            dx = x2 - x1; dy = y2 - y1;
            dx1 = Math.Abs(dx); dy1 = Math.Abs(dy);
            px = 2 * dy1 - dx1; py = 2 * dx1 - dy1;
            if (dy1 <= dx1)
            {
                if (dx >= 0)
                { x = x1; y = y1; xe = x2; }
                else
                { x = x2; y = y2; xe = x1; }

                Pixel(x, y, r, g, b);

                for (i = 0; x < xe; i++)
                {
                    x = x + 1;
                    if (px < 0)
                        px = px + 2 * dy1;
                    else
                    {
                        if ((dx < 0 && dy < 0) || (dx > 0 && dy > 0)) y = y + 1; else y = y - 1;
                        px = px + 2 * (dy1 - dx1);
                    }
                    Pixel(x, y, r, g, b);
                }
            }
            else
            {
                if (dy >= 0)
                { x = x1; y = y1; ye = y2; }
                else
                { x = x2; y = y2; ye = y1; }

                Pixel(x, y, r, g, b);

                for (i = 0; y < ye; i++)
                {
                    y = y + 1;
                    if (py <= 0)
                        py = py + 2 * dx1;
                    else
                    {
                        if ((dx < 0 && dy < 0) || (dx > 0 && dy > 0)) x = x + 1; else x = x - 1;
                        py = py + 2 * (dx1 - dy1);
                    }
                    Pixel(x, y, r, g, b);
                }
            }
        }
    }
}
